using OpenCvSharp;
using SciCamera.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static SciCamera.Net.SciCam;

namespace SharpFrameSmallAOI.Common.Camera
{
    public class OPT
    {
        private bool[] _optopen;

        public bool[] OPTpen
        {
            get { return _optopen; }
            set { _optopen = value; }
        }

        private SciCam[] DeviceObject { get; set; }

        private SCI_DEVICE_INFO_LIST dEVICE_INFO_LIST;
        public List<StringBuilder> Devicelist { get; set; }
        public PictureBox[] PictureBoxes { get; set; }  // PictureBox 控件引用

        private SciCam.fnOnPayloadDelegate[] _payloadCallbacks;

        private IntPtr[] m_convertPtr;          // 非托管转换buffer
        private int[] m_convertPtrSize;         // buffer大小
        private object[] m_camLocks;            // 相机锁

        private static System.Drawing.Imaging.ColorPalette _grayPalette;
        private static readonly object _palettelock = new object();

        // 用于单次抓图的同步事件和数据
        private Bitmap[] _capturedBitmaps;
        private Mat[] _capturedMats;
        private AutoResetEvent[] _captureEvents;
        private bool[] _captureRequests;
        private bool[] _captureMatRequests;

        public List<StringBuilder> GetDevice()
        {
            Devicelist = new List<StringBuilder>();
            dEVICE_INFO_LIST = new SCI_DEVICE_INFO_LIST();
            SciCam.DiscoveryDevices(ref dEVICE_INFO_LIST, (uint)0);
            DeviceObject = new SciCam[dEVICE_INFO_LIST.count];
            PictureBoxes = new PictureBox[dEVICE_INFO_LIST.count];
            m_convertPtr = new IntPtr[dEVICE_INFO_LIST.count];
            m_convertPtrSize = new int[dEVICE_INFO_LIST.count];
            m_camLocks = new object[dEVICE_INFO_LIST.count];
            for (int i = 0; i < dEVICE_INFO_LIST.count; i++)
            {
                m_camLocks[i] = new object();
                DeviceObject[i] = new SciCam();
                SciCam.SCI_DEVICE_GIGE_INFO gigeDevInfo = (SciCam.SCI_DEVICE_GIGE_INFO)SciCam.ByteToStruct(
                    dEVICE_INFO_LIST.pDevInfo[i].info.gigeInfo,
                    typeof(SciCam.SCI_DEVICE_GIGE_INFO));
                uint ip = gigeDevInfo.ip;
                int nIp1 = (int)(ip & 0x000000ff);
                int nIp2 = (int)((ip & 0x0000ff00) >> 8);
                int nIp3 = (int)((ip & 0x00ff0000) >> 16);
                int nIp4 = (int)((ip & 0xff000000) >> 24);
                Devicelist.Add(new StringBuilder(gigeDevInfo.modelName + $" {nIp1}.{nIp2}.{nIp3}.{nIp4} " + $"({gigeDevInfo.serialNumber})"));
            }
            return Devicelist;
        }

        public void OpenDevice()
        {
            if (DeviceObject != null)
            {
                _payloadCallbacks = new SciCam.fnOnPayloadDelegate[DeviceObject.Length];
                for (int i = 0; i < DeviceObject.Length; i++)
                {
                    _payloadCallbacks[i] = ImageCallBack;
                    Mistake(DeviceObject[i].CreateDevice(ref dEVICE_INFO_LIST.pDevInfo[i]));
                    Mistake(DeviceObject[i].OpenDevice());
                    Mistake(DeviceObject[i].RegisterPayloadCallBack(_payloadCallbacks[i], (IntPtr)i, false));
                }
            }
        }

        /// <summary>
        /// 设置相机属性
        /// </summary>
        /// <param name="dev">相机id</param>
        /// <param name="name">属性名称</param>
        /// <param name="value">设置属性值</param>
        public void SetDeviceProperty(int dev, string name, string value)
        {
            Mistake(DeviceObject[dev].SetEnumValueByStringEx(SciCam.SciCamDeviceXmlType.SciCam_DeviceXml_Camera, name, value));
        }

        /// <summary>
        /// 开始取流
        /// </summary>
        /// <param name="dev">相机id</param>
        public void StartGrabbing(int dev)
        {
            Mistake(DeviceObject[dev].StartGrabbing());
        }

        public void CloseDevice()
        {
            foreach (var item in DeviceObject)
            {
                Mistake(item.StopGrabbing());
            }
            ReleaseConvertBuffers();
        }

        private void ImageCallBack(IntPtr payload, IntPtr tag)
        {
            int pUser = tag.ToInt32();
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                if (payload == IntPtr.Zero || DeviceObject == null || pUser < 0 || pUser >= DeviceObject.Length || DeviceObject[pUser] == null)
                    return;
                lock (m_camLocks[pUser])
                {
                    IntPtr m_imgdata = IntPtr.Zero;
                    var sCI_CAM_PAYLOAD_ATTRIBUTEs = new SciCam.SCI_CAM_PAYLOAD_ATTRIBUTE();
                    Mistake(SciCam.PayloadGetAttribute(payload, ref sCI_CAM_PAYLOAD_ATTRIBUTEs));
                    if (!sCI_CAM_PAYLOAD_ATTRIBUTEs.isComplete)
                        return;
                    var targetPixelType = PayloadConvertImageExType(sCI_CAM_PAYLOAD_ATTRIBUTEs.imgAttr.pixelType);
                    Mistake(SciCam.PayloadGetImage(payload, ref m_imgdata));
                    long destImgSize = 0;
                    Mistake(SciCam.PayloadConvertImageEx(ref sCI_CAM_PAYLOAD_ATTRIBUTEs.imgAttr, m_imgdata, targetPixelType, IntPtr.Zero, ref destImgSize, false, 0));
                    EnsureConvertBuffer(pUser, (int)destImgSize);
                    Mistake(SciCam.PayloadConvertImageEx(ref sCI_CAM_PAYLOAD_ATTRIBUTEs.imgAttr, m_imgdata, targetPixelType, m_convertPtr[pUser], ref destImgSize, false, 0));

                    int width = (int)sCI_CAM_PAYLOAD_ATTRIBUTEs.imgAttr.width;
                    int height = (int)sCI_CAM_PAYLOAD_ATTRIBUTEs.imgAttr.height;
                    bool isMono = (targetPixelType == SciCam.SciCamPixelType.Mono8);

                    bool hasBitmapRequest = _captureRequests != null && _captureRequests[pUser];
                    bool hasMatRequest = _captureMatRequests != null && _captureMatRequests[pUser];

                    if (hasBitmapRequest)
                    {
                        // 抓取Bitmap
                        _capturedBitmaps[pUser] = ConvertToBitmap(m_convertPtr[pUser], width, height, isMono);
                        _captureRequests[pUser] = false;
                        _captureEvents[pUser].Set();
                    }
                    else if (hasMatRequest)
                    {
                        // 抓取Mat
                        _capturedMats[pUser] = ConvertToMat(m_convertPtr[pUser], width, height, isMono);
                        _captureMatRequests[pUser] = false;
                        _captureEvents[pUser].Set();
                    }
                    Bitmap bitmap = ConvertToBitmap(m_convertPtr[pUser], width, height, isMono);
                    DisplayImage(pUser, bitmap);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ImageCallBack Exception: " + ex);
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
                DeviceObject[pUser]?.FreePayload(payload);
            }
        }

        /// <summary>
        /// 复用缓冲区内存
        /// </summary>
        private void EnsureConvertBuffer(int camIndex, int requiredSize)
        {
            if (m_convertPtr[camIndex] == IntPtr.Zero || m_convertPtrSize[camIndex] < requiredSize)
            {
                if (m_convertPtr[camIndex] != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(m_convertPtr[camIndex]);
                }
                int allocSize = (int)(requiredSize * 1.2);
                m_convertPtr[camIndex] = Marshal.AllocHGlobal(allocSize);
                m_convertPtrSize[camIndex] = allocSize;
            }
        }

        /// <summary>
        /// 将图像数据转换为Bitmap
        /// </summary>
        /// <param name="data">图像数据指针</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="isMono">是否为灰度图</param>
        /// <returns>转换后的Bitmap</returns>
        private Bitmap ConvertToBitmap(IntPtr data, int width, int height, bool isMono)
        {
            if (data == IntPtr.Zero || width <= 0 || height <= 0)
                return null;
            Bitmap bitmap = null;
            System.Drawing.Imaging.BitmapData bmpData = null;
            try
            {
                if (isMono)
                {
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    bitmap.Palette = GetGrayPalette(bitmap);
                    bmpData = bitmap.LockBits(
                        new Rectangle(0, 0, width, height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    CopyImageData(data, bmpData.Scan0, width, height, width, bmpData.Stride);
                }
                else
                {
                    bitmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    bmpData = bitmap.LockBits(
                        new Rectangle(0, 0, width, height),
                        System.Drawing.Imaging.ImageLockMode.WriteOnly,
                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                    int srcStride = width * 3;
                    CopyImageData(data, bmpData.Scan0, srcStride, height, srcStride, bmpData.Stride);
                }

                bitmap.UnlockBits(bmpData);
                return bitmap;
            }
            catch
            {
                if (bmpData != null)
                    bitmap?.UnlockBits(bmpData);
                throw;
            }
        }

        /// <summary>
        /// 复制图像数据
        /// </summary>
        private void CopyImageData(IntPtr src, IntPtr dst, int srcRowBytes, int height, int srcStride, int dstStride)
        {
            if (srcStride == dstStride)
            {
                CopyMemory(dst, src, (uint)(srcRowBytes * height));
            }
            else
            {
                for (int y = 0; y < height; y++)
                {
                    IntPtr srcRow = IntPtr.Add(src, y * srcStride);
                    IntPtr dstRow = IntPtr.Add(dst, y * dstStride);
                    CopyMemory(dstRow, srcRow, (uint)srcRowBytes);
                }
            }
        }

        private System.Drawing.Imaging.ColorPalette GetGrayPalette(Bitmap bmp)
        {
            if (_grayPalette == null)
            {
                lock (_palettelock)
                {
                    if (_grayPalette == null)
                    {
                        _grayPalette = bmp.Palette;
                        for (int i = 0; i < 256; i++)
                        {
                            _grayPalette.Entries[i] = Color.FromArgb(i, i, i);
                        }
                    }
                }
            }
            return _grayPalette;
        }

        /// <summary>
        /// 释放所有相机的缓冲区
        /// </summary>
        public void ReleaseConvertBuffers()
        {
            if (m_convertPtr == null) return;

            for (int i = 0; i < m_convertPtr.Length; i++)
            {
                if (m_convertPtr[i] != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(m_convertPtr[i]);
                    m_convertPtr[i] = IntPtr.Zero;
                    m_convertPtrSize[i] = 0;
                }
            }
        }

        [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        private static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        private void DisplayImage(int camIndex, Bitmap bitmap)
        {
            if (PictureBoxes == null || camIndex < 0 || camIndex >= PictureBoxes.Length || PictureBoxes[camIndex] == null)
            {
                bitmap?.Dispose();
                return;
            }

            PictureBox pictureBox = PictureBoxes[camIndex];

            if (pictureBox.InvokeRequired)
            {
                pictureBox.BeginInvoke(new Action(() =>
                {
                    var oldImage = pictureBox.Image;
                    pictureBox.Image = bitmap;
                    oldImage?.Dispose();
                }));
            }
            else
            {
                var oldImage = pictureBox.Image;
                pictureBox.Image = bitmap;
                oldImage?.Dispose();
            }
        }

        /// <summary>
        /// 从相机获取一张Bitmap图像
        /// </summary>
        /// <param name="camIndex">相机索引</param>
        /// <param name="timeoutMs">超时时间，默认5000ms</param>
        /// <returns>捕获的Bitmap图像，超时返回null</returns>
        public Bitmap GrabBitmap(int camIndex, int timeoutMs = 5000)
        {
            if (DeviceObject == null || camIndex < 0 || camIndex >= DeviceObject.Length)
                return null;
            EnsureCaptureArrays();
            lock (m_camLocks[camIndex])
            {
                _capturedBitmaps[camIndex] = null;
                _captureRequests[camIndex] = true;
                _captureEvents[camIndex].Reset();
            }
            if (_captureEvents[camIndex].WaitOne(timeoutMs))
            {
                lock (m_camLocks[camIndex])
                {
                    return _capturedBitmaps[camIndex];
                }
            }
            lock (m_camLocks[camIndex])
            {
                _captureRequests[camIndex] = false;
            }
            return null;
        }

        /// <summary>
        /// 从相机获取一张OpenCvSharp Mat图像
        /// </summary>
        /// <param name="camIndex">相机索引</param>
        /// <param name="timeoutMs">超时时间，默认5000ms</param>
        /// <returns>捕获的Mat图像，超时返回null</returns>
        public Mat GrabMat(int camIndex, int timeoutMs = 5000)
        {
            if (DeviceObject == null || camIndex < 0 || camIndex >= DeviceObject.Length)
                return null;
            EnsureCaptureArrays();

            lock (m_camLocks[camIndex])
            {
                _capturedMats[camIndex] = null;
                _captureMatRequests[camIndex] = true;
                _captureEvents[camIndex].Reset();
            }
            if (_captureEvents[camIndex].WaitOne(timeoutMs))
            {
                lock (m_camLocks[camIndex])
                {
                    return _capturedMats[camIndex];
                }
            }
            lock (m_camLocks[camIndex])
            {
                _captureMatRequests[camIndex] = false;
            }
            return null;
        }

        /// <summary>
        /// 捕获数组初始化
        /// </summary>
        private void EnsureCaptureArrays()
        {
            if (_captureEvents == null)
            {
                int count = DeviceObject.Length;
                _capturedBitmaps = new Bitmap[count];
                _capturedMats = new Mat[count];
                _captureEvents = new AutoResetEvent[count];
                _captureRequests = new bool[count];
                _captureMatRequests = new bool[count];
                for (int i = 0; i < count; i++)
                {
                    _captureEvents[i] = new AutoResetEvent(false);
                }
            }
        }

        /// <summary>
        /// 将图像数据转换为OpenCvSharp Mat
        /// </summary>
        /// <param name="data">图像数据指针</param>
        /// <param name="width">图像宽度</param>
        /// <param name="height">图像高度</param>
        /// <param name="isMono">是否为灰度图</param>
        /// <returns>转换后的Mat</returns>
        private Mat ConvertToMat(IntPtr data, int width, int height, bool isMono)
        {
            if (data == IntPtr.Zero || width <= 0 || height <= 0)
                return null;
            Mat mat;
            if (isMono)
            {
                mat = new Mat(height, width, MatType.CV_8UC1);
                int srcStride = width;
                int dstStride = (int)mat.Step();
                if (srcStride == dstStride)
                {
                    CopyMemory(mat.Data, data, (uint)(width * height));
                }
                else
                {
                    for (int y = 0; y < height; y++)
                    {
                        IntPtr srcRow = IntPtr.Add(data, y * srcStride);
                        IntPtr dstRow = IntPtr.Add(mat.Data, y * dstStride);
                        CopyMemory(dstRow, srcRow, (uint)srcStride);
                    }
                }
            }
            else
            {
                // 彩色图：RGB8 -> BGR 
                mat = new Mat(height, width, MatType.CV_8UC3);
                int srcStride = width * 3;
                int dstStride = (int)mat.Step();
                unsafe
                {
                    byte* srcPtr = (byte*)data.ToPointer();
                    byte* dstPtr = (byte*)mat.Data.ToPointer();
                    for (int y = 0; y < height; y++)
                    {
                        byte* srcRow = srcPtr + y * srcStride;
                        byte* dstRow = dstPtr + y * dstStride;
                        for (int x = 0; x < width; x++)
                        {
                            int srcIdx = x * 3;
                            int dstIdx = x * 3;
                            dstRow[dstIdx + 0] = srcRow[srcIdx + 2]; // B
                            dstRow[dstIdx + 1] = srcRow[srcIdx + 1]; // G
                            dstRow[dstIdx + 2] = srcRow[srcIdx + 0]; // R
                        }
                    }
                }
            }
            return mat;
        }

        private SciCamPixelType PayloadConvertImageExType(SciCamPixelType pixelType)
        {
            bool isMono = (
                   pixelType == SciCam.SciCamPixelType.Mono1p ||
                   pixelType == SciCam.SciCamPixelType.Mono2p ||
                   pixelType == SciCam.SciCamPixelType.Mono4p ||
                   pixelType == SciCam.SciCamPixelType.Mono8s ||
                   pixelType == SciCam.SciCamPixelType.Mono8 ||
                   pixelType == SciCam.SciCamPixelType.Mono10 ||
                   pixelType == SciCam.SciCamPixelType.Mono10p ||
                   pixelType == SciCam.SciCamPixelType.Mono12 ||
                   pixelType == SciCam.SciCamPixelType.Mono12p ||
                   pixelType == SciCam.SciCamPixelType.Mono14 ||
                   pixelType == SciCam.SciCamPixelType.Mono16 ||
                   pixelType == SciCam.SciCamPixelType.Mono10Packed ||
                   pixelType == SciCam.SciCamPixelType.Mono12Packed ||
                   pixelType == SciCam.SciCamPixelType.Mono14p
               );
            SciCam.SciCamPixelType targetPixelType = isMono ? SciCam.SciCamPixelType.Mono8 : SciCam.SciCamPixelType.RGB8;
            return targetPixelType;
        }

        private bool Mistake(uint outint)
        {
            if (outint != 0)
            {
                //MessageBox.Show($"相机api错误:{outint:x8}", "错误");
            }
            return true;
        }
    }
}
