using SharpFrameSmall.Common.Modbus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SharpFrameSmall.LogsFolder
{
    public class PLC_ModbusTCP : IDisposable
    {
        public ManualResetEvent Interrupt { get; set; }
        /// <summary>
        /// 连接成功
        /// </summary>
        public event Action<string, int> ConnectRun;
        /// <summary>
        /// 连接失败
        /// </summary>
        public event Action<string, int> ConnectLose;
        /// <summary>
        /// 报警触发
        /// </summary>
        public event Action<Dictionary<ReadStruct, ErrorCode>, int> ErrorTriggerEvent;
        /// <summary>
        /// 报警复位
        /// </summary>
        public event Action<Dictionary<ReadStruct, ErrorCode>, int> ErrorResetEvent;
        /// <summary>
        /// Pcs触发
        /// </summary>
        public event Action<ModbusTCPClientPlus> PCSTriggerEvent;
        /// <summary>
        /// CT触发
        /// </summary>
        public event Action<ModbusTCPClientPlus> CTTriggerEvent;
        /// <summary>
        /// 三色灯触发 true=触发上抛 false=定时上抛
        /// </summary>
        public event Action<bool, int, int, ErrorCode[]> TricolourLightTriggerEvent;
        /// <summary>
        /// 换班触发
        /// </summary>
        public event Action<ModbusTCPClientPlus> ChangeShiftsTriggerEvent;
        public static int Timedtime = 0;
        public List<ErrorCode> error_queue;
        public ModbusTCPClientPlus modbus;
        public bool dog_lock;
        public string Ip;
        public int Port;

        private bool _isconnet;
        public bool IsConnet
        {
            get { return _isconnet; }
            set { _isconnet = value; }
        }

        public struct AlarmTimeInfo
        {
            /// <summary>
            /// 报警触发时间
            /// </summary>
            public DateTime TriggerTime { get; set; }
            /// <summary>
            /// 报警复位时间
            /// </summary>
            public DateTime ResetTime { get; set; }
            /// <summary>
            /// 报警复位用时
            /// </summary>
            public TimeSpan ElapsedTime { get; set; }
        }

        public struct ReadStruct
        {
            public bool Value { get; set; }
            public string Size { get; set; }
            public AlarmTimeInfo TimeStruct { get; set; }
        }

        private Dictionary<string, AlarmTimeInfo> triggerTimes = new Dictionary<string, AlarmTimeInfo>();
        private Dictionary<ReadStruct, ErrorCode> _triggerList = new Dictionary<ReadStruct, ErrorCode>(); // 缓存上升沿的 ErrorCode
        private Dictionary<ReadStruct, ErrorCode> _resetList = new Dictionary<ReadStruct, ErrorCode>();   // 缓存下降沿的 ErrorCode
        private List<ErrorCode> _AllList = new List<ErrorCode>();

        private ReadStruct[] _read_d;
        public ReadStruct[] Read_D
        {
            get { return _read_d; }
            set
            {
                if (dog_lock && _read_d != null)
                {
                    _triggerList.Clear();
                    _resetList.Clear();
                    for (int i = 0; i < _read_d.Length; i++)
                    {
                        if (value[i].Value == true && _read_d[i].Value == false) // 上升沿
                        {
                            ErrorCode t = error_queue.Find(x => x.plc_site == value[i].Size);
                            triggerTimes[value[i].Size] = new AlarmTimeInfo
                            {
                                TriggerTime = DateTime.Now,
                                ResetTime = DateTime.MinValue,
                                ElapsedTime = TimeSpan.Zero
                            };
                            _triggerList.Add(new ReadStruct()
                            {
                                Value = value[i].Value,
                                Size = value[i].Size,
                                TimeStruct = triggerTimes.ContainsKey(value[i].Size) ? triggerTimes[value[i].Size] : new AlarmTimeInfo()
                            }, t);
                            _AllList.Add(t);
                        }
                        else if (value[i].Value == false && _read_d[i].Value == true) // 下降沿
                        {
                            ErrorCode t = error_queue.Find(x => x.plc_site == value[i].Size);
                            if (triggerTimes.ContainsKey(value[i].Size))
                            {
                                var alarmInfo = triggerTimes[value[i].Size];
                                alarmInfo.ResetTime = DateTime.Now;
                                alarmInfo.ElapsedTime = alarmInfo.ResetTime - alarmInfo.TriggerTime;
                                triggerTimes[value[i].Size] = alarmInfo;
                            }
                            _resetList.Add(new ReadStruct()
                            {
                                Value = value[i].Value,
                                Size = value[i].Size,
                                TimeStruct = triggerTimes.ContainsKey(value[i].Size) ? triggerTimes[value[i].Size] : new AlarmTimeInfo()
                            }, t);
                            if (_AllList.IndexOf(t) > -1)
                            {
                                _AllList.Remove(t);
                            }
                        }
                    }
                    if (_triggerList.Count > 0)
                        ErrorTriggerEvent?.BeginInvoke(_triggerList, DeviceState, null, null);
                    if (_resetList.Count > 0)
                        ErrorResetEvent?.BeginInvoke(_resetList, DeviceState, null, null);
                }
                _read_d = value;
            }
        }

        private int _cttrigger;

        public int CTTrigger
        {
            get { return _cttrigger; }
            set
            {
                if (value == 1 && _cttrigger == 0)
                {
                    if (modbus != null)
                    {
                        CTTriggerEvent?.Invoke(modbus);
                    }
                }
                _cttrigger = value;
            }
        }


        private int _pcstrigger;
        /// <summary>
        /// 产品触发
        /// </summary>
        public int PCSTrigger
        {
            get { return _pcstrigger; }
            set
            {
                if (value == 1 && _pcstrigger == 0)
                {
                    if (modbus != null)
                    {
                        PCSTriggerEvent?.Invoke(modbus);
                    }
                }
                _pcstrigger = value;
            }
        }

        private int _devicestate;
        /// <summary>
        /// 三色灯
        /// </summary>
        public int DeviceState
        {
            get { return _devicestate; }
            set
            {
                if (value != 0 && value != _devicestate)
                {
                    TricolourLightTriggerEvent?.Invoke(true, value, Timedtime, _AllList.ToArray());
                }
                _devicestate = value;
            }
        }

        private int _changeshifts;

        public int ChangeShifts
        {
            get { return _changeshifts; }
            set
            {
                if (value != 0 && value != _changeshifts)
                {
                    ChangeShiftsTriggerEvent?.Invoke(modbus);
                }
                _changeshifts = value;
            }
        }


        Thread threadReal;
        Thread threadTimed;
        public PLC_ModbusTCP()
        {

        }

        /// <summary>
        /// 连接PLC
        /// </summary>
        /// <param name="ip">plc ip</param>
        /// <param name="port">plc port</param>
        /// <param name="timed">三色灯定时上抛时间（S）</param>
        /// <param name="error_list">报警定义</param>
        public void Connect(string ip, int port, int timed, List<ErrorCode> error_list)
        {
            this.Ip = ip;
            this.Port = port;
            Interrupt = new ManualResetEvent(true);
            Timedtime = timed * 1000;
            error_queue = error_list;
            modbus = new ModbusTCPClientPlus(ip, port);
            modbus.InteractionEvent += ((t, t1, t2, t3, t4, t5) =>
            {
                // Log.Info($"耗时：{t.TotalMilliseconds},操作结果：{t1},方法：{t2}，地址{t3}，寄存器个数{t4}");
            });
            if (threadReal != null)
                threadReal.Abort();
            if (threadTimed != null)
                threadTimed.Abort();
            threadReal = new Thread(Real_time_reading);
            threadReal.Name = "Real_time_reading";
            threadReal.IsBackground = true;
            threadReal.Start();
            threadTimed = new Thread(Timed_Upward_Throw);
            threadTimed.Name = "Timed_Upward_Throw";
            threadTimed.IsBackground = true;
            threadTimed.Start();
        }

        public void Error_queueNew(List<ErrorCode> error_list)
        {
            Interrupt.Reset();
            Thread.Sleep(150);
            error_queue = error_list;
            Interrupt.Set();
        }
        private bool Real_time = true;


        Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// 触发上抛
        /// </summary>
        private void Real_time_reading()
        {
            try
            {
                int[] light = new int[3];
                string[] status = { "Error", "Wait", "Run" }; // 对应 1, 2, 3
                while (Real_time)
                {
                    Thread.Sleep(100);
                    var read_d = modbus.ReadBitArray("7300", 50);//error
                    if (read_d.IsSuccess)
                    {
                        Interrupt.WaitOne();
                        if (!IsConnet)
                        {
                            ConnectRun?.Invoke(Ip, Port);
                            IsConnet = true;
                        }
                        if (IsConnet && error_queue != null)
                        {
                            light[0] = modbus.ReadInt32("7254").Value;//红色
                            light[1] = modbus.ReadInt32("7250").Value;//橙色
                            light[2] = modbus.ReadInt32("7252").Value;//绿色
                            DeviceState = GetDeviceStatus(light);
                            PCSTrigger = modbus.ReadInt32("7264").Value;
                            Read_D = BytesToBoolArray("D", 7300, read_d.Value);
                            ChangeShifts = modbus.ReadInt32("7280").Value;
                            CTTrigger = modbus.ReadInt16("7230").Value;
                        }
                    }
                    else
                    {
                        if (IsConnet)
                        {
                            IsConnet = false;
                            ConnectLose?.Invoke(Ip, Port);
                        }
                    }
                    if (!dog_lock)
                        dog_lock = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Overtime()
        {
            CTTriggerEvent?.Invoke(modbus);
        }

        /// <summary>
        /// 实时上抛
        /// </summary>
        private void Timed_Upward_Throw()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                while (Real_time)
                {
                    stopwatch.Start();
                    do
                    {
                        Thread.Sleep(100);
                    } while (stopwatch.ElapsedMilliseconds < Timedtime);
                    stopwatch.Stop();
                    stopwatch.Reset();
                    if (IsConnet)
                    {
                        //if (DeviceState != 0)
                        TricolourLightTriggerEvent?.Invoke(false, DeviceState, Timedtime, _AllList.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private ReadStruct[] BytesToBoolArray(string size, int start_size, bool[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            ReadStruct[] readStru = new ReadStruct[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                int addressOffset = i / 16;
                int bitOffset = i % 16;
                readStru[i].Value = bytes[i];
                readStru[i].Size = $"{size}{start_size + addressOffset}.{bitOffset}";
            }
            return readStru;
        }

        public int GetDeviceStatus(int[] light)
        {
            if (light[0] == 1)
            {
                return 3;
            }
            else if (light[0] == 0 && light[1] == 1)
            {
                return 2;
            }
            else if (light[0] == 0 && light[1] == 0 && light[2] == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public void Dispose()
        {
            Real_time = false;
            Thread.Sleep(200);
            if (modbus != null)
                modbus.Dispose();
        }
    }
}
