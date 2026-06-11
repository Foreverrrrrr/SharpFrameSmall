using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SharpFrameSmall.Views.SharpStyle
{
    #region 绘制模式转换器

    /// <summary>
    /// DrawingMode 转换器 - 用于 RadioButton 绑定
    /// </summary>
    public class DrawingModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DrawingMode mode && parameter is string paramStr)
            {
                if (Enum.TryParse<DrawingMode>(paramStr, out var targetMode))
                {
                    return mode == targetMode;
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked && parameter is string paramStr)
            {
                if (Enum.TryParse<DrawingMode>(paramStr, out var targetMode))
                {
                    return targetMode;
                }
            }
            return Binding.DoNothing;
        }
    }

    #endregion

    #region 图形绘制类型定义

    /// <summary>
    /// 绘制模式枚举 - 用于选择当前要绘制的图形类型
    /// </summary>
    public enum DrawingMode
    {
        None,           // 无绘制模式（普通浏览）
        Rectangle,      // 矩形（原ROI功能）
        Line,           // 直线
        Circle,         // 圆形
        Ellipse,        // 椭圆
        Arrow,          // 箭头
        Crosshair,      // 十字准星（单击放置）
        Polygon         // 多边形（多次点击，双击完成）
    }

    /// <summary>
    /// 图形类型枚举
    /// </summary>
    public enum ShapeType
    {
        Line,           // 直线
        Rectangle,      // 矩形
        Circle,         // 圆形
        Ellipse,        // 椭圆
        Polygon,        // 多边形
        Text,           // 文字
        Crosshair,      // 十字准星
        Arrow           // 箭头
    }

    /// <summary>
    /// 图形信息基类
    /// </summary>
    public class ShapeInfo : INotifyPropertyChangedBase
    {
        private ShapeType _shapeType;
        private Color _strokeColor = Colors.Lime;
        private Color _fillColor = Colors.Transparent;
        private double _strokeThickness = 2;
        private bool _isVisible = true;
        private string _tag;
        private string _name;

        /// <summary>
        /// 图形类型
        /// </summary>
        public ShapeType ShapeType
        {
            get => _shapeType;
            set { _shapeType = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 图形名称（用于标识和显示）
        /// </summary>
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 边框颜色
        /// </summary>
        public Color StrokeColor
        {
            get => _strokeColor;
            set { _strokeColor = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 填充颜色
        /// </summary>
        public Color FillColor
        {
            get => _fillColor;
            set { _fillColor = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 线宽
        /// </summary>
        public double StrokeThickness
        {
            get => _strokeThickness;
            set { _strokeThickness = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set { _isVisible = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// 标签（可用于自定义数据）
        /// </summary>
        public string Tag
        {
            get => _tag;
            set { _tag = value; OnPropertyChanged(); }
        }
    }

    /// <summary>
    /// 直线信息
    /// </summary>
    public class LineShapeInfo : ShapeInfo
    {
        public LineShapeInfo() { ShapeType = ShapeType.Line; }
        
        /// <summary>
        /// 起点（图像坐标）
        /// </summary>
        public Point StartPoint { get; set; }
        
        /// <summary>
        /// 终点（图像坐标）
        /// </summary>
        public Point EndPoint { get; set; }
    }

    /// <summary>
    /// 矩形信息
    /// </summary>
    public class RectangleShapeInfo : ShapeInfo
    {
        public RectangleShapeInfo() { ShapeType = ShapeType.Rectangle; }
        
        /// <summary>
        /// 矩形区域（图像坐标）
        /// </summary>
        public Rect Rect { get; set; }
    }

    /// <summary>
    /// 圆形信息
    /// </summary>
    public class CircleShapeInfo : ShapeInfo
    {
        public CircleShapeInfo() { ShapeType = ShapeType.Circle; }
        
        /// <summary>
        /// 圆心（图像坐标）
        /// </summary>
        public Point Center { get; set; }
        
        /// <summary>
        /// 半径（图像坐标）
        /// </summary>
        public double Radius { get; set; }
    }

    /// <summary>
    /// 椭圆信息
    /// </summary>
    public class EllipseShapeInfo : ShapeInfo
    {
        public EllipseShapeInfo() { ShapeType = ShapeType.Ellipse; }
        
        /// <summary>
        /// 中心点（图像坐标）
        /// </summary>
        public Point Center { get; set; }
        
        /// <summary>
        /// X轴半径（图像坐标）
        /// </summary>
        public double RadiusX { get; set; }
        
        /// <summary>
        /// Y轴半径（图像坐标）
        /// </summary>
        public double RadiusY { get; set; }
    }

    /// <summary>
    /// 多边形信息
    /// </summary>
    public class PolygonShapeInfo : ShapeInfo
    {
        public PolygonShapeInfo() { ShapeType = ShapeType.Polygon; }
        
        /// <summary>
        /// 顶点集合（图像坐标）
        /// </summary>
        public List<Point> Points { get; set; } = new List<Point>();
    }

    /// <summary>
    /// 文字信息
    /// </summary>
    public class TextShapeInfo : ShapeInfo
    {
        public TextShapeInfo() { ShapeType = ShapeType.Text; }
        
        /// <summary>
        /// 文字位置（图像坐标）
        /// </summary>
        public Point Position { get; set; }
        
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        
        /// <summary>
        /// 字体大小
        /// </summary>
        public double FontSize { get; set; } = 14;
        
        /// <summary>
        /// 背景色
        /// </summary>
        public Color BackgroundColor { get; set; } = Colors.Transparent;
    }

    /// <summary>
    /// 十字准星信息
    /// </summary>
    public class CrosshairShapeInfo : ShapeInfo
    {
        public CrosshairShapeInfo() { ShapeType = ShapeType.Crosshair; }
        
        /// <summary>
        /// 中心点（图像坐标）
        /// </summary>
        public Point Center { get; set; }
        
        /// <summary>
        /// 十字线长度（图像坐标）
        /// </summary>
        public double Size { get; set; } = 20;
        
        /// <summary>
        /// 是否显示中心圆点
        /// </summary>
        public bool ShowCenterDot { get; set; } = true;
    }

    /// <summary>
    /// 箭头信息
    /// </summary>
    public class ArrowShapeInfo : ShapeInfo
    {
        public ArrowShapeInfo() { ShapeType = ShapeType.Arrow; }
        
        /// <summary>
        /// 起点（图像坐标）
        /// </summary>
        public Point StartPoint { get; set; }
        
        /// <summary>
        /// 终点（图像坐标，箭头指向）
        /// </summary>
        public Point EndPoint { get; set; }
        
        /// <summary>
        /// 箭头大小
        /// </summary>
        public double ArrowSize { get; set; } = 10;
    }

    #endregion

    /// <summary>
    /// ROI信息类，包含ROI的完整信息
    /// </summary>
    public class RoiInfo : INotifyPropertyChangedBase
    {
        private int _index;
        private Rect _imageRect;
        private bool _isSelected;
        private string _name;

        public int Index
        {
            get => _index;
            set { _index = value; OnPropertyChanged(); }
        }

        public Rect ImageRect
        {
            get => _imageRect;
            set { _imageRect = value; OnPropertyChanged(); }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name ?? $"ROI {Index}";
            set { _name = value; OnPropertyChanged(); }
        }

        // 图像坐标属性（方便访问）
        public int X => (int)Math.Round(ImageRect.X);
        public int Y => (int)Math.Round(ImageRect.Y);
        public int Width => (int)Math.Round(ImageRect.Width);
        public int Height => (int)Math.Round(ImageRect.Height);

        /// <summary>
        /// 创建副本
        /// </summary>
        public RoiInfo Clone()
        {
            return new RoiInfo
            {
                Index = this.Index,
                ImageRect = this.ImageRect,
                IsSelected = this.IsSelected,
                Name = this._name
            };
        }
    }

    /// <summary>
    /// ROI变化事件参数
    /// </summary>
    public class RoiChangedEventArgs : EventArgs
    {
        public enum ChangeType { Added, Removed, Modified, Cleared, Applied }
        
        public ChangeType Type { get; }
        public RoiInfo AffectedRoi { get; }
        public IReadOnlyList<RoiInfo> AllRois { get; }

        public RoiChangedEventArgs(ChangeType type, RoiInfo affectedRoi, IReadOnlyList<RoiInfo> allRois)
        {
            Type = type;
            AffectedRoi = affectedRoi;
            AllRois = allRois;
        }
    }

    /// <summary>
    /// 图形绘制变化事件参数
    /// </summary>
    public class ShapeDrawnEventArgs : EventArgs
    {
        public enum ChangeType { Added, Removed, Modified, Cleared }
        
        /// <summary>
        /// 变化类型
        /// </summary>
        public ChangeType Type { get; }
        
        /// <summary>
        /// 受影响的图形
        /// </summary>
        public ShapeInfo AffectedShape { get; }
        
        /// <summary>
        /// 所有图形列表
        /// </summary>
        public IReadOnlyList<ShapeInfo> AllShapes { get; }

        public ShapeDrawnEventArgs(ChangeType type, ShapeInfo affectedShape, IReadOnlyList<ShapeInfo> allShapes)
        {
            Type = type;
            AffectedShape = affectedShape;
            AllShapes = allShapes;
        }
    }

    /// <summary>
    /// 简单的属性变更通知基类
    /// </summary>
    public class INotifyPropertyChangedBase : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    /// <summary>
    /// DisplayVision 图像显示控件 - 支持图形绘制、ROI选择、缩放平移等功能
    /// 使用 partial class 拆分为多个文件以便维护
    /// </summary>
    public partial class DisplayVision : Control, IDisposable
    {
        #region 调试辅助方法
        
        /// <summary>
        /// 条件调试输出（仅在DEBUG模式下输出）
        /// </summary>
        [System.Diagnostics.Conditional("DEBUG")]
        private static void DebugLog(string message)
        {
            System.Diagnostics.Debug.WriteLine($"[DisplayVision] {message}");
        }
        
        #endregion

        #region 事件定义
        
        /// <summary>
        /// ROI变化事件
        /// </summary>
        public event EventHandler<RoiChangedEventArgs> RoiChanged;

        /// <summary>
        /// 图形绘制变化事件
        /// </summary>
        public event EventHandler<ShapeDrawnEventArgs> ShapeDrawn;

        /// <summary>
        /// 触发ROI变化事件
        /// </summary>
        private void OnRoiChanged(RoiChangedEventArgs.ChangeType type, RoiInfo affectedRoi = null)
        {
            RoiChanged?.Invoke(this, new RoiChangedEventArgs(type, affectedRoi, roiInfoList.AsReadOnly()));
        }

        /// <summary>
        /// 触发图形绘制变化事件
        /// </summary>
        private void OnShapeDrawn(ShapeDrawnEventArgs.ChangeType type, ShapeInfo affectedShape = null)
        {
            ShapeDrawn?.Invoke(this, new ShapeDrawnEventArgs(type, affectedShape, shapeInfoList.AsReadOnly()));
        }
        
        #endregion

        #region 私有字段
        
        private Canvas ImageCanvas;
        private Rectangle SelectionRectangle; // 当前正在绘制的选择框
        
        // ROI管理
        private List<Grid> drawnRoiContainers = new List<Grid>(); // ROI容器（包含矩形和标签）
        private List<RoiInfo> roiInfoList = new List<RoiInfo>(); // ROI信息列表
        private int selectedRoiIndex = -1; // 当前选中的ROI索引
        private bool isResizingRoi = false; // 是否正在调整ROI大小
        private bool isDraggingRoi = false; // 是否正在拖拽ROI
        private string currentResizeHandle = null; // 当前调整大小的手柄
        private Point roiDragStartPoint; // ROI拖拽起始点
        private Rect roiOriginalRect; // ROI原始矩形（图像坐标）
        
        // 图形绘制管理
        private List<ShapeInfo> shapeInfoList = new List<ShapeInfo>(); // 图形信息列表
        private List<FrameworkElement> drawnShapeElements = new List<FrameworkElement>(); // 已绘制的图形元素
        private List<Grid> drawnShapeContainers = new List<Grid>(); // 图形容器
        private bool isUpdatingShapeCollection = false; // 防止ShapeCollection更新时的循环调用
        
        // 图形选中和调整状态
        private int selectedShapeIndex = -1; // 当前选中的图形索引
        private bool isDraggingShape = false; // 是否正在拖拽图形
        private bool isResizingShape = false; // 是否正在调整图形大小
        private string currentShapeResizeHandle = null; // 当前调整大小的手柄
        private Point shapeDragStartPoint; // 图形拖拽起始点
        private ShapeInfo originalShapeData = null; // 原始图形数据
        
        // 交互式图形绘制状态
        private bool isDrawingShape = false; // 是否正在绘制图形
        private Point shapeDrawStartPoint; // 图形绘制起始点
        private FrameworkElement currentDrawingElement; 
        private List<Point> polygonPoints = new List<Point>(); // 多边形顶点集合
        
        private Image _originalImageControl; // 缓存 Image 控件
        private Point startPoint;
        private bool isSelecting;
        private bool isRoiSelectionEnabled; // ROI选取模式是否启用
        private TransformGroup transformGroup = new TransformGroup();
        private ScaleTransform scaleTransform = new ScaleTransform();
        private TranslateTransform translateTransform = new TranslateTransform();
        private const double ZoomFactor = 1.15; // 增大缩放因子，减少缩放次数
        private bool isDragging;
        private Point lastMousePosition;
        private const double MaxScale = 10;

        private byte[] pixelBuffer = new byte[4]; // 重用缓冲区避免重复分配
        private Point lastPixelInfoPosition = new Point(-1, -1); // 避免重复计算相同位置

        private bool isComponentsValid = false; // 缓存组件有效性检查

        // 使用 Stopwatch 替代 DateTime 以获得更高精度的计时
        private readonly Stopwatch moveStopwatch = Stopwatch.StartNew();
        private long lastMoveTimeTicks = 0;
        private const long MouseMoveThrottleTicks = 50000; 
        
        private bool isTransformCacheValid = false; // 变换缓存有效性
        private Matrix cachedTransformMatrix; // 缓存的变换矩阵
        private Matrix cachedInverseMatrix; // 缓存的逆变换矩阵
        private long lastCacheTimeTicks = 0;
        private const long CacheValidityTicks = 500000;
        private bool isHighPerformanceMode = true;
        
        private long lastWheelTimeTicks = 0;
        private const long WheelThrottleTicks = 330000; // 30fps
        private int pendingWheelDelta = 0; // 滚轮增量
        private bool isWheelUpdatePending = false; // 是否有待处理的滚轮更新
        private bool isLargeImage = false; // 是否为大图
        
        // 内存管理
        private int zoomOperationCount = 0; // 缩放计数
        private const int ZoomOperationsBeforeCleanup = 30; // 每30次缩放操作后清理GC
        private long lastMemoryCleanupTicks = 0;
        private const long MemoryCleanupIntervalTicks = 100000000; // 10秒

        private WeakReference lastImageReference; 
        private static readonly object disposeLock = new object(); // 线程锁
        
        // 像素信息更新的延迟调度器
        private DispatcherOperation pendingPixelInfoUpdate;
        
        // 缓存 BitmapSource
        private WeakReference<BitmapSource> cachedBitmapSourceRef;
        
        // 缓存图像尺寸
        private int cachedImageWidth;
        private int cachedImageHeight;
        
        // 对象池
        private PixelInfo reusablePixelInfo = new PixelInfo();
        
       
        private PixelInfoRoutedEventArgs reusablePixelInfoEventArgs;
        
        // 预分配的字符串构建器用于坐标显示
        private readonly System.Text.StringBuilder coordStringBuilder = new System.Text.StringBuilder(32);
        
        // 标记是否已释放
        private bool isDisposed = false;
        
        // 缓存的委托
        private Action cachedUpdateSelectionAction;
        private Action cachedUpdatePixelInfoAction;
        private Action cachedResetImageScaleAction;
        private Action cachedProcessPendingWheelZoomAction; 
        private Action cachedLightweightMemoryCleanupAction; 
        
        // 待处理的选择框
        private DispatcherOperation pendingSelectionUpdate;
        
        private BitmapSource _cachedBitmapSource;
        private BitmapSource cachedBitmapSource
        {
            get
            {
                if (_cachedBitmapSource != null)
                    return _cachedBitmapSource;
                if (cachedBitmapSourceRef != null && cachedBitmapSourceRef.TryGetTarget(out var bitmap))
                {
                    return bitmap;
                }
                return null;
            }
            set
            {
                _cachedBitmapSource = value;
                if (value != null)
                {
                    cachedBitmapSourceRef = new WeakReference<BitmapSource>(value);
                }
                else
                {
                    cachedBitmapSourceRef = null;
                }
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool ValidateComponents()
        {
            if (cachedBitmapSource == null || cachedImageWidth <= 0 || cachedImageHeight <= 0)
            {
                if (InputImage is BitmapSource bitmapSource)
                {
                    cachedBitmapSource = bitmapSource;
                    cachedImageWidth = bitmapSource.PixelWidth;
                    cachedImageHeight = bitmapSource.PixelHeight;
                }
            }
            
            if (!isComponentsValid)
            {
                isComponentsValid = ImageCanvas != null && SelectionRectangle != null && cachedBitmapSource != null && cachedImageWidth > 0 && cachedImageHeight > 0;
            }
            return isComponentsValid;
        }

        private void InvalidateComponents()
        {
            isComponentsValid = false;
            InvalidateTransformCache();
        }

        /// <summary>
        /// 失效变换缓存
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void InvalidateTransformCache()
        {
            isTransformCacheValid = false;
        }

        /// <summary>
        /// 获取缓存的变换矩阵（避免重复计算）
        /// </summary>
        /// <returns>变换矩阵</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Matrix GetCachedTransformMatrix()
        {
            var currentTicks = moveStopwatch.ElapsedTicks;
            if (!isTransformCacheValid || (currentTicks - lastCacheTimeTicks) > CacheValidityTicks)
            {
                UpdateTransformCache(currentTicks);
            }
            return cachedTransformMatrix;
        }
        
        /// <summary>
        /// 更新变换缓存（分离出来减少内联方法的大小）
        /// </summary>
        private void UpdateTransformCache(long currentTicks)
        {
            if (transformGroup != null)
            {
                cachedTransformMatrix = transformGroup.Value;
                try
                {
                    var inverse = transformGroup.Inverse;
                    if (inverse is MatrixTransform matrixTransform)
                    {
                        cachedInverseMatrix = matrixTransform.Value;
                    }
                    else if (inverse != null)
                    {
                        Point origin = inverse.Transform(new Point(0, 0));
                        Point testPoint = inverse.Transform(new Point(1, 0));
                        Point testPoint2 = inverse.Transform(new Point(0, 1));
                        cachedInverseMatrix = new Matrix(
                            testPoint.X - origin.X,
                            testPoint.Y - origin.Y,
                            testPoint2.X - origin.X,
                            testPoint2.Y - origin.Y,
                            origin.X,
                            origin.Y
                        );
                    }
                    else
                    {
                        cachedInverseMatrix = Matrix.Identity;
                    }
                }
                catch (InvalidOperationException)
                {
                    cachedInverseMatrix = Matrix.Identity;
                }
            }
            else
            {
                cachedTransformMatrix = Matrix.Identity;
                cachedInverseMatrix = Matrix.Identity;
            }
            isTransformCacheValid = true;
            lastCacheTimeTicks = currentTicks;
        }

        /// <summary>
        /// 获取缓存的逆变换矩阵
        /// </summary>
        /// <returns>逆变换矩阵</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Matrix GetCachedInverseMatrix()
        {
            GetCachedTransformMatrix();
            return cachedInverseMatrix;
        }

        /// <summary>
        /// 使用变换进行坐标转换（支持GeneralTransform）
        /// </summary>
        /// <param name="point">要转换的点</param>
        /// <param name="useInverse">是否使用逆变换</param>
        /// <returns>转换后的点</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Point TransformPoint(Point point, bool useInverse = false)
        {
            try
            {
                if (useInverse)
                {
                    return GetCachedInverseMatrix().Transform(point);
                }
                else
                {
                    return GetCachedTransformMatrix().Transform(point);
                }
            }
            catch (InvalidOperationException)
            {
                return point;
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            ImageCanvas = GetTemplateChild("ImageCanvas") as Canvas;
            SelectionRectangle = GetTemplateChild("SelectionRectangle") as Rectangle;
            Image originalImage = GetTemplateChild("OriginalImageControl") as Image;
            InvalidateComponents();
            if (originalImage != null)
            {
                originalImage.RenderTransform = transformGroup;
                transformGroup.Children.Add(scaleTransform);
                transformGroup.Children.Add(translateTransform);
                RenderOptions.SetBitmapScalingMode(originalImage, BitmapScalingMode.NearestNeighbor);
                RenderOptions.SetEdgeMode(originalImage, EdgeMode.Aliased);
                
                RenderOptions.SetClearTypeHint(originalImage, ClearTypeHint.Auto);
                
                originalImage.CacheMode = null;
                
                _originalImageControl = originalImage;
            }

            if (ImageCanvas != null)
            {
                ImageCanvas.MouseLeftButtonDown += MouseLDown;
                ImageCanvas.MouseLeftButtonUp += MouseLUp;
                ImageCanvas.MouseMove += Mouse_Move;
                ImageCanvas.MouseWheel += Mouse_Wheel;
                ImageCanvas.MouseRightButtonDown += MouseRDown;
                ImageCanvas.MouseRightButtonUp += MouseRUp;
                ImageCanvas.PreviewMouseDown += OnPreviewMouseDown;
                ImageCanvas.PreviewMouseUp += OnPreviewMouseUp;
                ImageCanvas.MouseLeave += ImageCanvas_MouseLeave;
            }
            
            cachedUpdateSelectionAction = UpdateSelectionRectanglePosition;
            cachedUpdatePixelInfoAction = UpdatePixelInfoAtCurrentPosition;
            cachedResetImageScaleAction = ResetImageScale;
            cachedProcessPendingWheelZoomAction = ProcessPendingWheelZoom;
            cachedLightweightMemoryCleanupAction = TriggerLightweightMemoryCleanup;
            
            InitializeDefaultCommands();
        }

        /// <summary>
        /// 初始化默认命令
        /// </summary>
        private void InitializeDefaultCommands()
        {
            if (SaveImageCommand == null)
            {
                SaveImageCommand = new RelayCommand(
                    _ => SaveCurrentImage(),
                    _ => cachedBitmapSource != null
                );
            }
            
            if (SetRoiCommand == null)
            {
                SetRoiCommand = new RelayCommand(
                    _ => ToggleRoiMode(),
                    _ => ValidateComponents()
                );
            }
            
            if (ResetSizeCommand == null)
            {
                ResetSizeCommand = new RelayCommand(
                    _ => ResetImageScale(),
                    _ => ValidateComponents()
                );
            }
            
            if (ClearRoiCommand == null)
            {
                ClearRoiCommand = new RelayCommand(
                    _ => ClearAllRoiRectangles(),
                    _ => roiInfoList.Count > 0 || shapeInfoList.Count > 0 
                );
            }
            
            if (DeleteSelectedRoiCommand == null)
            {
                DeleteSelectedRoiCommand = new RelayCommand(
                    _ => DeleteSelectedRoi(),
                    _ => selectedRoiIndex >= 0
                );
            }

            if (ApplyRoiCommand == null)
            {
                ApplyRoiCommand = new RelayCommand(
                    _ => ApplyCurrentRoi(),
                    _ => roiInfoList.Count > 0 || shapeInfoList.Count > 0
                );
            }
            
            if (ClearShapesCommand == null)
            {
                ClearShapesCommand = new RelayCommand(
                    _ => ClearAllShapes(),
                    _ => shapeInfoList.Count > 0
                );
            }
        }

        /// <summary>
        /// 切换ROI选取模式
        /// </summary>
        private void ToggleRoiMode()
        {
            IsRoiMode = !IsRoiMode;
        }

        #region 命令依赖属性

        public ICommand SaveImageCommand
        {
            get => (ICommand)GetValue(SaveImageCommandProperty);
            set => SetValue(SaveImageCommandProperty, value);
        }

        public static readonly DependencyProperty SaveImageCommandProperty =
            DependencyProperty.Register(nameof(SaveImageCommand), typeof(ICommand), typeof(DisplayVision), 
                new PropertyMetadata(null));

        /// <summary>
        /// 保存当前显示的图像到文件
        /// </summary>
        /// <param name="filePath">文件路径（如果为空则弹出保存对话框）</param>
        /// <returns>是否保存成功</returns>
        public bool SaveCurrentImage(string filePath = null)
        {
            if (cachedBitmapSource == null)
            {
                DebugLog("没有图像可保存");
                return false;
            }

            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    var saveDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "PNG图像|*.png|JPEG图像|*.jpg|BMP图像|*.bmp|所有文件|*.*",
                        DefaultExt = ".png",
                        FileName = $"Image_{DateTime.Now:yyyyMMdd_HHmmss}"
                    };

                    if (saveDialog.ShowDialog() != true)
                        return false;

                    filePath = saveDialog.FileName;
                }

                BitmapEncoder encoder;
                string extension = System.IO.Path.GetExtension(filePath).ToLower();
                switch (extension)
                {
                    case ".jpg":
                    case ".jpeg":
                        encoder = new JpegBitmapEncoder { QualityLevel = 95 };
                        break;
                    case ".bmp":
                        encoder = new BmpBitmapEncoder();
                        break;
                    case ".png":
                    default:
                        encoder = new PngBitmapEncoder();
                        break;
                }

                encoder.Frames.Add(BitmapFrame.Create(cachedBitmapSource));

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }

                DebugLog($"图像已保存到: {filePath}");
                return true;
            }
            catch (Exception ex)
            {
                DebugLog($"保存图像失败: {ex.Message}");
                return false;
            }
        }

        public ICommand SetRoiCommand
        {
            get => (ICommand)GetValue(SetRoiCommandProperty);
            set => SetValue(SetRoiCommandProperty, value);
        }

        public static readonly DependencyProperty SetRoiCommandProperty =
            DependencyProperty.Register(nameof(SetRoiCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// ROI选取模式是否启用（用于绑定ToggleButton.IsChecked）
        /// </summary>
        public bool IsRoiMode
        {
            get => (bool)GetValue(IsRoiModeProperty);
            set => SetValue(IsRoiModeProperty, value);
        }

        public static readonly DependencyProperty IsRoiModeProperty =
            DependencyProperty.Register(nameof(IsRoiMode), typeof(bool), typeof(DisplayVision),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsRoiModeChanged));

        private static void OnIsRoiModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DisplayVision)d;
            bool isEnabled = (bool)e.NewValue;
            
            if (isEnabled)
            {
                control.EnableRoiSelection();
            }
            else
            {
                control.DisableRoiSelection();
            }
        }

        /// <summary>
        /// 当前绘制模式
        /// </summary>
        public DrawingMode CurrentDrawingMode
        {
            get => (DrawingMode)GetValue(CurrentDrawingModeProperty);
            set => SetValue(CurrentDrawingModeProperty, value);
        }

        public static readonly DependencyProperty CurrentDrawingModeProperty =
            DependencyProperty.Register(nameof(CurrentDrawingMode), typeof(DrawingMode), typeof(DisplayVision),
                new FrameworkPropertyMetadata(DrawingMode.None, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnCurrentDrawingModeChanged));

        private static void OnCurrentDrawingModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DisplayVision)d;
            var newMode = (DrawingMode)e.NewValue;
            var oldMode = (DrawingMode)e.OldValue;
            
            control.CancelCurrentDrawing();
            
            if (newMode != DrawingMode.None)
            {
                control.EnableDrawingMode();
                control.isRoiSelectionEnabled = true;
                control.IsRoiMode = true;
            }
            else
            {
                bool hasDrawnItems = control.roiInfoList.Count > 0 || control.shapeInfoList.Count > 0;
                
                if (hasDrawnItems)
                {
                    control.isRoiSelectionEnabled = true;
                    if (control.ImageCanvas != null)
                    {
                        control.ImageCanvas.Cursor = Cursors.Arrow;
                    }
                }
                else
                {
                    control.DisableDrawingMode();
                }
                
                if (oldMode == DrawingMode.Rectangle && control.IsRoiMode)
                {
                    control.IsRoiMode = false;
                }
            }
            
            DebugLog($"绘制模式切换: {oldMode} -> {newMode}");
        }

        /// <summary>
        /// 是否启用绘制功能（true=显示绘制工具栏，false=只显示选择功能，隐藏绘制工具栏）
        /// </summary>
        public bool IsDrawingEnabled
        {
            get => (bool)GetValue(IsDrawingEnabledProperty);
            set => SetValue(IsDrawingEnabledProperty, value);
        }

        public static readonly DependencyProperty IsDrawingEnabledProperty =
            DependencyProperty.Register(nameof(IsDrawingEnabled), typeof(bool), typeof(DisplayVision),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnIsDrawingEnabledChanged));

        private static void OnIsDrawingEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DisplayVision)d;
            var isEnabled = (bool)e.NewValue;
            
            if (!isEnabled)
            {
                control.CurrentDrawingMode = DrawingMode.None;
            }
            
            DebugLog($"绘制功能启用状态: {isEnabled}");
        }

        /// <summary>
        /// 绘制图形的边框颜色
        /// </summary>
        public Color DrawingStrokeColor
        {
            get => (Color)GetValue(DrawingStrokeColorProperty);
            set => SetValue(DrawingStrokeColorProperty, value);
        }

        public static readonly DependencyProperty DrawingStrokeColorProperty =
            DependencyProperty.Register(nameof(DrawingStrokeColor), typeof(Color), typeof(DisplayVision),
                new PropertyMetadata(Colors.Lime));

        /// <summary>
        /// 绘制图形的填充颜色
        /// </summary>
        public Color DrawingFillColor
        {
            get => (Color)GetValue(DrawingFillColorProperty);
            set => SetValue(DrawingFillColorProperty, value);
        }

        public static readonly DependencyProperty DrawingFillColorProperty =
            DependencyProperty.Register(nameof(DrawingFillColor), typeof(Color), typeof(DisplayVision),
                new PropertyMetadata(Colors.Transparent));

        /// <summary>
        /// 绘制图形的线宽
        /// </summary>
        public double DrawingStrokeThickness
        {
            get => (double)GetValue(DrawingStrokeThicknessProperty);
            set => SetValue(DrawingStrokeThicknessProperty, value);
        }

        public static readonly DependencyProperty DrawingStrokeThicknessProperty =
            DependencyProperty.Register(nameof(DrawingStrokeThickness), typeof(double), typeof(DisplayVision),
                new PropertyMetadata(2.0));

        /// <summary>
        /// 启用ROI选取模式
        /// </summary>
        public void EnableRoiSelection()
        {
            if (!ValidateComponents())
                return;

            isRoiSelectionEnabled = true;
            if (ImageCanvas != null)
                ImageCanvas.Cursor = Cursors.Cross;
            
            CommandManager.InvalidateRequerySuggested();
            DebugLog("ROI选取模式已启用");
        }

        /// <summary>
        /// 禁用ROI选取模式
        /// </summary>
        public void DisableRoiSelection()
        {
            isRoiSelectionEnabled = false;
            isSelecting = false;
            isDraggingRoi = false;
            isResizingRoi = false;
            currentResizeHandle = null;
            
            if (selectedRoiIndex >= 0 && selectedRoiIndex < roiInfoList.Count)
            {
                roiInfoList[selectedRoiIndex].IsSelected = false;
                UpdateRoiAppearance(selectedRoiIndex, false);
            }
            selectedRoiIndex = -1;
            
            foreach (var container in drawnRoiContainers)
                container.ReleaseMouseCapture();
            
            if (ImageCanvas != null)
            {
                ImageCanvas.Cursor = Cursors.Arrow;
                ImageCanvas.ReleaseMouseCapture();
            }
            
            if (SelectionRectangle != null)
                SelectionRectangle.Visibility = Visibility.Collapsed;
            
            CommandManager.InvalidateRequerySuggested();
            DebugLog("ROI选取模式已禁用");
        }

        /// <summary>
        /// 启用绘制模式
        /// </summary>
        private void EnableDrawingMode()
        {
            if (!ValidateComponents())
                return;

            if (ImageCanvas != null)
                ImageCanvas.Cursor = Cursors.Cross;
            
            CommandManager.InvalidateRequerySuggested();
            DebugLog($"绘制模式已启用: {CurrentDrawingMode}");
        }

        /// <summary>
        /// 禁用绘制模式
        /// </summary>
        private void DisableDrawingMode()
        {
            CancelCurrentDrawing();
            isRoiSelectionEnabled = false;
            
            if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
            {
                var selectionBorder = drawnShapeContainers[selectedShapeIndex].Children
                    .OfType<Rectangle>().FirstOrDefault(r => r.Name == "SelectionBorder");
                if (selectionBorder != null)
                    selectionBorder.Visibility = Visibility.Collapsed;
            }
            selectedShapeIndex = -1;
            isDraggingShape = false;
            
            foreach (var container in drawnShapeContainers)
                container.ReleaseMouseCapture();
            
            if (ImageCanvas != null)
            {
                ImageCanvas.Cursor = Cursors.Arrow;
                ImageCanvas.ReleaseMouseCapture();
            }
            
            CommandManager.InvalidateRequerySuggested();
            DebugLog("绘制模式已禁用");
        }

        /// <summary>
        /// 取消当前正在进行的绘制
        /// </summary>
        private void CancelCurrentDrawing()
        {
            isDrawingShape = false;
            isSelecting = false;
            
            if (currentDrawingElement != null && ImageCanvas != null)
            {
                ImageCanvas.Children.Remove(currentDrawingElement);
                currentDrawingElement = null;
            }
            
            polygonPoints.Clear();
            
            if (SelectionRectangle != null)
                SelectionRectangle.Visibility = Visibility.Collapsed;
        }

        public ICommand ResetSizeCommand
        {
            get => (ICommand)GetValue(ResetSizeCommandProperty);
            set => SetValue(ResetSizeCommandProperty, value);
        }

        public static readonly DependencyProperty ResetSizeCommandProperty =
            DependencyProperty.Register(nameof(ResetSizeCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// 清除所有ROI命令
        /// </summary>
        public ICommand ClearRoiCommand
        {
            get => (ICommand)GetValue(ClearRoiCommandProperty);
            set => SetValue(ClearRoiCommandProperty, value);
        }

        public static readonly DependencyProperty ClearRoiCommandProperty =
            DependencyProperty.Register(nameof(ClearRoiCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// 删除选中ROI命令
        /// </summary>
        public ICommand DeleteSelectedRoiCommand
        {
            get => (ICommand)GetValue(DeleteSelectedRoiCommandProperty);
            set => SetValue(DeleteSelectedRoiCommandProperty, value);
        }

        public static readonly DependencyProperty DeleteSelectedRoiCommandProperty =
            DependencyProperty.Register(nameof(DeleteSelectedRoiCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// 应用/保存ROI命令 - 将当前绘制的ROI传递出去
        /// </summary>
        public ICommand ApplyRoiCommand
        {
            get => (ICommand)GetValue(ApplyRoiCommandProperty);
            set => SetValue(ApplyRoiCommandProperty, value);
        }

        public static readonly DependencyProperty ApplyRoiCommandProperty =
            DependencyProperty.Register(nameof(ApplyRoiCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// 根据RoiInfo添加ROI显示
        /// </summary>
        private void AddRoiFromInfo(RoiInfo roiInfo)
        {
            if (ImageCanvas == null || roiInfo == null)
                return;

            // 创建新的RoiInfo（使用新索引）
            int newIndex = roiInfoList.Count + 1;
            var newRoiInfo = new RoiInfo
            {
                Index = newIndex,
                ImageRect = roiInfo.ImageRect,
                IsSelected = false,
                Name = roiInfo.Name
            };
            roiInfoList.Add(newRoiInfo);

            // 将图像坐标转换为屏幕坐标
            Point screenStart = TransformPoint(roiInfo.ImageRect.TopLeft, useInverse: false);
            Point screenEnd = TransformPoint(roiInfo.ImageRect.BottomRight, useInverse: false);
            
            double screenLeft = Math.Min(screenStart.X, screenEnd.X);
            double screenTop = Math.Min(screenStart.Y, screenEnd.Y);
            double screenWidth = Math.Abs(screenEnd.X - screenStart.X);
            double screenHeight = Math.Abs(screenEnd.Y - screenStart.Y);

            // 创建ROI显示容器
            var container = CreateRoiContainer(newRoiInfo, screenLeft, screenTop, screenWidth, screenHeight);
            
            // 添加到画布
            ImageCanvas.Children.Add(container);
            drawnRoiContainers.Add(container);
            
            // 刷新命令状态
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 应用当前ROI - 将当前绘制的ROI和形状合并为ShapeCollection，并触发InterceptROI事件
        /// </summary>
        public void ApplyCurrentRoi()
        {
            if (roiInfoList.Count == 0 && shapeInfoList.Count == 0)
            {
                DebugLog("没有ROI或形状可应用");
                return;
            }
            isUpdatingShapeCollection = true;
            try
            {
                var allShapes = new ObservableCollection<ShapeInfo>();

                foreach (var roi in roiInfoList)
                {
                    var rectShape = new RectangleShapeInfo
                    {
                        Rect = roi.ImageRect,
                        StrokeColor = Colors.Lime,  // ROI 默认颜色
                        StrokeThickness = 2,
                        FillColor = Color.FromArgb(50, 0, 255, 0),
                        Name = roi.Name ?? $"ROI_{roi.Index}"
                    };
                    allShapes.Add(rectShape);
                }

                foreach (var shape in shapeInfoList)
                {
                    allShapes.Add(shape);
                }

                var existingShapeCollection = ShapeCollection;
                if (existingShapeCollection != null)
                {
                    existingShapeCollection.Clear();
                    foreach (var shape in allShapes)
                    {
                        existingShapeCollection.Add(shape);
                    }
                }
                else
                {
                    ShapeCollection = allShapes;
                    existingShapeCollection = allShapes;
                }

                // 触发InterceptROI事件，传递集合
                RaiseInterceptROIEvent(existingShapeCollection);
            }
            finally
            {
                isUpdatingShapeCollection = false;
            }
            
            OnRoiChanged(RoiChangedEventArgs.ChangeType.Applied);
            
            DebugLog($"已应用 {roiInfoList.Count} 个ROI，{shapeInfoList.Count} 个形状，共 {roiInfoList.Count + shapeInfoList.Count} 个形状");
        }

        /// <summary>
        /// ROI列表（只读，用于外部绑定显示）
        /// </summary>
        public IReadOnlyList<RoiInfo> RoiList => roiInfoList.AsReadOnly();

        /// <summary>
        /// 当前选中的ROI索引
        /// </summary>
        public int SelectedRoiIndex
        {
            get => selectedRoiIndex;
            set
            {
                if (selectedRoiIndex != value)
                {
                    if (selectedRoiIndex >= 0 && selectedRoiIndex < roiInfoList.Count)
                    {
                        roiInfoList[selectedRoiIndex].IsSelected = false;
                        UpdateRoiAppearance(selectedRoiIndex, false);
                    }
                    selectedRoiIndex = value;
                    if (selectedRoiIndex >= 0 && selectedRoiIndex < roiInfoList.Count)
                    {
                        roiInfoList[selectedRoiIndex].IsSelected = true;
                        UpdateRoiAppearance(selectedRoiIndex, true);
                    }
                }
            }
        }

        #endregion

        #region 图形绘制功能

        /// <summary>
        /// 图形集合依赖属性 - 支持绑定
        /// </summary>
        public ObservableCollection<ShapeInfo> ShapeCollection
        {
            get => (ObservableCollection<ShapeInfo>)GetValue(ShapeCollectionProperty);
            set => SetValue(ShapeCollectionProperty, value);
        }

        public static readonly DependencyProperty ShapeCollectionProperty =
            DependencyProperty.Register(nameof(ShapeCollection), typeof(ObservableCollection<ShapeInfo>), typeof(DisplayVision),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnShapeCollectionChanged));

        private static void OnShapeCollectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (DisplayVision)d;
            if (e.OldValue is ObservableCollection<ShapeInfo> oldCollection)
            {
                oldCollection.CollectionChanged -= control.ShapeCollection_CollectionChanged;
            }
            if (e.NewValue is ObservableCollection<ShapeInfo> newCollection)
            {
                newCollection.CollectionChanged += control.ShapeCollection_CollectionChanged;
                if (!control.isUpdatingShapeCollection)
                {
                    control.shapeInfoList.Clear();
                    foreach (var shape in newCollection)
                    {
                        control.shapeInfoList.Add(shape);
                    }
                    control.RedrawAllShapes();
                }
            }
            else
            {
                control.shapeInfoList.Clear();
                control.RedrawAllShapes();
            }
        }

        private void ShapeCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (isUpdatingShapeCollection) return;
            
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (ShapeInfo shape in e.NewItems)
                    {
                        if (!shapeInfoList.Contains(shape))
                        {
                            shapeInfoList.Add(shape);
                        }
                        DrawShape(shape);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (ShapeInfo shape in e.OldItems)
                    {
                        shapeInfoList.Remove(shape);
                    }
                    RedrawAllShapes();
                    break;
                case NotifyCollectionChangedAction.Reset:
                    ClearShapesInternal();
                    break;
                default:
                    shapeInfoList.Clear();
                    if (ShapeCollection != null)
                    {
                        foreach (var shape in ShapeCollection)
                        {
                            shapeInfoList.Add(shape);
                        }
                    }
                    RedrawAllShapes();
                    break;
            }
        }

        /// <summary>
        /// 清除图形命令
        /// </summary>
        public ICommand ClearShapesCommand
        {
            get => (ICommand)GetValue(ClearShapesCommandProperty);
            set => SetValue(ClearShapesCommandProperty, value);
        }

        public static readonly DependencyProperty ClearShapesCommandProperty =
            DependencyProperty.Register(nameof(ClearShapesCommand), typeof(ICommand), typeof(DisplayVision),
                new PropertyMetadata(null));

        /// <summary>
        /// 绘制直线
        /// </summary>
        public void DrawLine(Point start, Point end, Color? color = null, double thickness = 2, string tag = null)
        {
            var shape = new LineShapeInfo
            {
                StartPoint = start,
                EndPoint = end,
                StrokeColor = color ?? Colors.Lime,
                StrokeThickness = thickness,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        public void DrawRectangle(Rect rect, Color? strokeColor = null, Color? fillColor = null, double thickness = 2, string tag = null)
        {
            var shape = new RectangleShapeInfo
            {
                Rect = rect,
                StrokeColor = strokeColor ?? Colors.Lime,
                FillColor = fillColor ?? Colors.Transparent,
                StrokeThickness = thickness,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制圆形
        /// </summary>
        public void DrawCircle(Point center, double radius, Color? strokeColor = null, Color? fillColor = null, double thickness = 2, string tag = null)
        {
            var shape = new CircleShapeInfo
            {
                Center = center,
                Radius = radius,
                StrokeColor = strokeColor ?? Colors.Lime,
                FillColor = fillColor ?? Colors.Transparent,
                StrokeThickness = thickness,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制椭圆
        /// </summary>
        public void DrawEllipse(Point center, double radiusX, double radiusY, Color? strokeColor = null, Color? fillColor = null, double thickness = 2, string tag = null)
        {
            var shape = new EllipseShapeInfo
            {
                Center = center,
                RadiusX = radiusX,
                RadiusY = radiusY,
                StrokeColor = strokeColor ?? Colors.Lime,
                FillColor = fillColor ?? Colors.Transparent,
                StrokeThickness = thickness,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制多边形
        /// </summary>
        public void DrawPolygon(List<Point> points, Color? strokeColor = null, Color? fillColor = null, double thickness = 2, string tag = null)
        {
            var shape = new PolygonShapeInfo
            {
                Points = points,
                StrokeColor = strokeColor ?? Colors.Lime,
                FillColor = fillColor ?? Colors.Transparent,
                StrokeThickness = thickness,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制文字
        /// </summary>
        public void DrawText(Point position, string text, Color? color = null, double fontSize = 14, Color? backgroundColor = null, string tag = null)
        {
            var shape = new TextShapeInfo
            {
                Position = position,
                Text = text,
                StrokeColor = color ?? Colors.Lime,
                FontSize = fontSize,
                BackgroundColor = backgroundColor ?? Colors.Transparent,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制十字准星
        /// </summary>
        public void DrawCrosshair(Point center, double size = 20, Color? color = null, double thickness = 2, bool showCenterDot = true, string tag = null)
        {
            DebugLog($"DrawCrosshair: 图像坐标=({center.X:F1}, {center.Y:F1}), Size={size}");
            
            var shape = new CrosshairShapeInfo
            {
                Center = center,
                Size = size,
                StrokeColor = color ?? Colors.Lime,
                StrokeThickness = thickness,
                ShowCenterDot = showCenterDot,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 绘制箭头
        /// </summary>
        public void DrawArrow(Point start, Point end, Color? color = null, double thickness = 2, double arrowSize = 10, string tag = null)
        {
            var shape = new ArrowShapeInfo
            {
                StartPoint = start,
                EndPoint = end,
                StrokeColor = color ?? Colors.Lime,
                StrokeThickness = thickness,
                ArrowSize = arrowSize,
                Tag = tag
            };
            AddShape(shape);
        }

        /// <summary>
        /// 添加图形到列表并绘制
        /// </summary>
        private void AddShape(ShapeInfo shape)
        {
            shapeInfoList.Add(shape);
            DrawShape(shape);
            if (ShapeCollection != null)
            {
                isUpdatingShapeCollection = true;
                try
                {
                    ShapeCollection.Add(shape);
                }
                finally
                {
                    isUpdatingShapeCollection = false;
                }
            }
        }

        /// <summary>
        /// 绘制单个图形
        /// </summary>
        private void DrawShape(ShapeInfo shape)
        {
            if (ImageCanvas == null || shape == null || !shape.IsVisible) return;
            
            InvalidateTransformCache();

            FrameworkElement element = null;
            Rect bounds = GetShapeBounds(shape);

            switch (shape.ShapeType)
            {
                case ShapeType.Line:
                    element = CreateLineElement(shape as LineShapeInfo);
                    break;
                case ShapeType.Rectangle:
                    element = CreateRectangleElement(shape as RectangleShapeInfo);
                    break;
                case ShapeType.Circle:
                    element = CreateCircleElement(shape as CircleShapeInfo);
                    break;
                case ShapeType.Ellipse:
                    element = CreateEllipseElement(shape as EllipseShapeInfo);
                    break;
                case ShapeType.Polygon:
                    element = CreatePolygonElement(shape as PolygonShapeInfo);
                    break;
                case ShapeType.Text:
                    element = CreateTextElement(shape as TextShapeInfo);
                    break;
                case ShapeType.Crosshair:
                    element = CreateCrosshairElement(shape as CrosshairShapeInfo);
                    break;
                case ShapeType.Arrow:
                    element = CreateArrowElement(shape as ArrowShapeInfo);
                    break;
            }

            if (element != null)
            {
                int shapeIndex = shapeInfoList.IndexOf(shape);
                var container = CreateShapeContainer(element, shape, shapeIndex, bounds);
                
                ImageCanvas.Children.Add(container);
                drawnShapeContainers.Add(container);
                drawnShapeElements.Add(element);
            }
        }

        /// <summary>
        /// 获取图形的边界框（图像坐标）
        /// </summary>
        private Rect GetShapeBounds(ShapeInfo shape)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Line:
                    var line = shape as LineShapeInfo;
                    return new Rect(
                        Math.Min(line.StartPoint.X, line.EndPoint.X),
                        Math.Min(line.StartPoint.Y, line.EndPoint.Y),
                        Math.Abs(line.EndPoint.X - line.StartPoint.X),
                        Math.Abs(line.EndPoint.Y - line.StartPoint.Y));
                        
                case ShapeType.Rectangle:
                    return (shape as RectangleShapeInfo).Rect;
                    
                case ShapeType.Circle:
                    var circle = shape as CircleShapeInfo;
                    return new Rect(
                        circle.Center.X - circle.Radius,
                        circle.Center.Y - circle.Radius,
                        circle.Radius * 2,
                        circle.Radius * 2);
                        
                case ShapeType.Ellipse:
                    var ellipse = shape as EllipseShapeInfo;
                    return new Rect(
                        ellipse.Center.X - ellipse.RadiusX,
                        ellipse.Center.Y - ellipse.RadiusY,
                        ellipse.RadiusX * 2,
                        ellipse.RadiusY * 2);
                        
                case ShapeType.Crosshair:
                    var crosshair = shape as CrosshairShapeInfo;
                    return new Rect(
                        crosshair.Center.X - crosshair.Size,
                        crosshair.Center.Y - crosshair.Size,
                        crosshair.Size * 2,
                        crosshair.Size * 2);
                        
                case ShapeType.Arrow:
                    var arrow = shape as ArrowShapeInfo;
                    return new Rect(
                        Math.Min(arrow.StartPoint.X, arrow.EndPoint.X),
                        Math.Min(arrow.StartPoint.Y, arrow.EndPoint.Y),
                        Math.Abs(arrow.EndPoint.X - arrow.StartPoint.X),
                        Math.Abs(arrow.EndPoint.Y - arrow.StartPoint.Y));
                        
                case ShapeType.Polygon:
                    var polygon = shape as PolygonShapeInfo;
                    if (polygon.Points == null || polygon.Points.Count == 0)
                        return Rect.Empty;
                    double minX = polygon.Points.Min(p => p.X);
                    double minY = polygon.Points.Min(p => p.Y);
                    double maxX = polygon.Points.Max(p => p.X);
                    double maxY = polygon.Points.Max(p => p.Y);
                    return new Rect(minX, minY, maxX - minX, maxY - minY);
                    
                default:
                    return Rect.Empty;
            }
        }

        /// <summary>
        /// 创建图形容器（包含图形元素和交互功能）
        /// </summary>
        private Grid CreateShapeContainer(FrameworkElement element, ShapeInfo shape, int index, Rect imageBounds)
        {
            Point screenTopLeft = TransformPoint(imageBounds.TopLeft, useInverse: false);
            Point screenBottomRight = TransformPoint(imageBounds.BottomRight, useInverse: false);
            
            double left = Math.Min(screenTopLeft.X, screenBottomRight.X);
            double top = Math.Min(screenTopLeft.Y, screenBottomRight.Y);
            double width = Math.Max(Math.Abs(screenBottomRight.X - screenTopLeft.X), 10);
            double height = Math.Max(Math.Abs(screenBottomRight.Y - screenTopLeft.Y), 10);

            var container = new Grid
            {
                Width = width,
                Height = height,
                Tag = index,
                Background = Brushes.Transparent 
            };

            var contentCanvas = new Canvas
            {
                Width = width,
                Height = height,
                ClipToBounds = false,
                IsHitTestVisible = false 
            };
            
            AdjustElementPosition(element, shape, left, top);
            contentCanvas.Children.Add(element);
            container.Children.Add(contentCanvas);

            var nameLabel = new Border
            {
                Background = Brushes.Lime,
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(4, 2, 4, 2),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(2, 2, 0, 0),
                Tag = "NameLabel",
                IsHitTestVisible = false,
                Child = new TextBlock
                {
                    Text = shape.Name ?? GetShapeDefaultName(shape.ShapeType, index + 1),
                    Foreground = Brushes.Black,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold,
                    Tag = "NameText"
                }
            };
            container.Children.Add(nameLabel);
            var nameEditBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(220, 50, 50, 50)),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(2),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(2, 0, 0, 2),
                Visibility = Visibility.Collapsed,
                Tag = "NameEdit"
            };
            
            var nameTextBox = new TextBox
            {
                Text = shape.Name ?? GetShapeDefaultName(shape.ShapeType, index + 1),
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                FontSize = 11,
                MinWidth = 60,
                MaxWidth = 150,
                Padding = new Thickness(2),
                Tag = "NameTextBox"
            };
            nameTextBox.LostFocus += ShapeNameTextBox_LostFocus;
            nameTextBox.KeyDown += ShapeNameTextBox_KeyDown;
            nameEditBorder.Child = nameTextBox;
            container.Children.Add(nameEditBorder);
            var selectionBorder = new Rectangle
            {
                Name = "SelectionBorder",
                Stroke = Brushes.Cyan,
                StrokeThickness = 1,
                StrokeDashArray = new DoubleCollection { 4, 2 },
                Fill = Brushes.Transparent,
                IsHitTestVisible = false,
                Visibility = Visibility.Collapsed
            };
            container.Children.Add(selectionBorder);

            CreateShapeResizeHandles(container, shape.ShapeType);

            container.MouseLeftButtonDown += Shape_MouseLeftButtonDown;
            container.MouseLeftButtonUp += Shape_MouseLeftButtonUp;
            container.MouseMove += Shape_MouseMove;
            container.MouseRightButtonDown += Shape_MouseRightButtonDown;
            container.Cursor = Cursors.SizeAll;
            Canvas.SetLeft(container, left);
            Canvas.SetTop(container, top);

            return container;
        }

        /// <summary>
        /// 为图形容器创建调整大小的手柄
        /// </summary>
        private void CreateShapeResizeHandles(Grid container, ShapeType shapeType)
        {
            // 根据图形类型决定手柄类型
            // 矩形、椭圆：8个方向手柄
            // 线条、箭头：只有起点和终点手柄
            // 圆形：4个方向手柄（保持圆形）
            // 十字准星：调整大小手柄
            // 多边形：顶点手柄（暂不实现，只支持移动）
            
            string[] handles;
            switch (shapeType)
            {
                case ShapeType.Line:
                case ShapeType.Arrow:
                    handles = new[] { "Start", "End" };
                    break;
                case ShapeType.Circle:
                    handles = new[] { "N", "E", "S", "W" };
                    break;
                case ShapeType.Rectangle:
                case ShapeType.Ellipse:
                    handles = new[] { "NW", "N", "NE", "W", "E", "SW", "S", "SE" };
                    break;
                case ShapeType.Crosshair:
                    handles = new[] { "N", "E", "S", "W" };
                    break;
                default:
                    return; // 多边形暂不支持调整大小
            }
            
            foreach (var handle in handles)
            {
                var thumb = new Rectangle
                {
                    Name = $"ShapeHandle_{handle}",
                    Width = 8,
                    Height = 8,
                    Fill = Brushes.White,
                    Stroke = Brushes.DarkCyan,
                    StrokeThickness = 1,
                    Tag = handle,
                    Visibility = Visibility.Collapsed 
                };
                SetShapeHandlePosition(thumb, handle, shapeType);

                thumb.MouseLeftButtonDown += ShapeResizeHandle_MouseLeftButtonDown;
                thumb.MouseLeftButtonUp += ShapeResizeHandle_MouseLeftButtonUp;
                thumb.MouseMove += ShapeResizeHandle_MouseMove;
                container.Children.Add(thumb);
            }
        }

        /// <summary>
        /// 设置图形调整手柄的位置和光标
        /// </summary>
        private void SetShapeHandlePosition(Rectangle thumb, string handle, ShapeType shapeType)
        {
            switch (handle)
            {
                case "NW":
                    thumb.HorizontalAlignment = HorizontalAlignment.Left;
                    thumb.VerticalAlignment = VerticalAlignment.Top;
                    thumb.Cursor = Cursors.SizeNWSE;
                    thumb.Margin = new Thickness(-4, -4, 0, 0);
                    break;
                case "N":
                    thumb.HorizontalAlignment = HorizontalAlignment.Center;
                    thumb.VerticalAlignment = VerticalAlignment.Top;
                    thumb.Cursor = Cursors.SizeNS;
                    thumb.Margin = new Thickness(0, -4, 0, 0);
                    break;
                case "NE":
                    thumb.HorizontalAlignment = HorizontalAlignment.Right;
                    thumb.VerticalAlignment = VerticalAlignment.Top;
                    thumb.Cursor = Cursors.SizeNESW;
                    thumb.Margin = new Thickness(0, -4, -4, 0);
                    break;
                case "W":
                    thumb.HorizontalAlignment = HorizontalAlignment.Left;
                    thumb.VerticalAlignment = VerticalAlignment.Center;
                    thumb.Cursor = Cursors.SizeWE;
                    thumb.Margin = new Thickness(-4, 0, 0, 0);
                    break;
                case "E":
                    thumb.HorizontalAlignment = HorizontalAlignment.Right;
                    thumb.VerticalAlignment = VerticalAlignment.Center;
                    thumb.Cursor = Cursors.SizeWE;
                    thumb.Margin = new Thickness(0, 0, -4, 0);
                    break;
                case "SW":
                    thumb.HorizontalAlignment = HorizontalAlignment.Left;
                    thumb.VerticalAlignment = VerticalAlignment.Bottom;
                    thumb.Cursor = Cursors.SizeNESW;
                    thumb.Margin = new Thickness(-4, 0, 0, -4);
                    break;
                case "S":
                    thumb.HorizontalAlignment = HorizontalAlignment.Center;
                    thumb.VerticalAlignment = VerticalAlignment.Bottom;
                    thumb.Cursor = Cursors.SizeNS;
                    thumb.Margin = new Thickness(0, 0, 0, -4);
                    break;
                case "SE":
                    thumb.HorizontalAlignment = HorizontalAlignment.Right;
                    thumb.VerticalAlignment = VerticalAlignment.Bottom;
                    thumb.Cursor = Cursors.SizeNWSE;
                    thumb.Margin = new Thickness(0, 0, -4, -4);
                    break;
                case "Start": // 线起点
                    thumb.HorizontalAlignment = HorizontalAlignment.Left;
                    thumb.VerticalAlignment = VerticalAlignment.Top;
                    thumb.Cursor = Cursors.Cross;
                    thumb.Margin = new Thickness(-4, -4, 0, 0);
                    break;
                case "End": // 线终点
                    thumb.HorizontalAlignment = HorizontalAlignment.Right;
                    thumb.VerticalAlignment = VerticalAlignment.Bottom;
                    thumb.Cursor = Cursors.Cross;
                    thumb.Margin = new Thickness(0, 0, -4, -4);
                    break;
            }
        }

        /// <summary>
        /// 图形调整手柄鼠标按下事件
        /// </summary>
        private void ShapeResizeHandle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CurrentDrawingMode != DrawingMode.None)
                return;
                
            if (sender is Rectangle handle && handle.Parent is Grid container && container.Tag is int index)
            {
                SelectShape(index);
                
                isResizingShape = true;
                currentShapeResizeHandle = handle.Tag as string;
                shapeDragStartPoint = e.GetPosition(ImageCanvas);
                originalShapeData = CloneShapeInfo(shapeInfoList[index]);
                container.CaptureMouse();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 图形调整手柄鼠标移动事件
        /// </summary>
        private void ShapeResizeHandle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isResizingShape || selectedShapeIndex < 0)
                return;
                
            Point currentPoint = e.GetPosition(ImageCanvas);
            HandleShapeResize(currentPoint);
            e.Handled = true;
        }

        /// <summary>
        /// 图形调整手柄鼠标释放事件
        /// </summary>
        private void ShapeResizeHandle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isResizingShape)
                return;
                
            if (sender is Rectangle handle && handle.Parent is Grid container)
            {
                int resizedIndex = selectedShapeIndex;
                ShapeInfo resizedShape = resizedIndex >= 0 && resizedIndex < shapeInfoList.Count 
                    ? shapeInfoList[resizedIndex] : null;
                
                isResizingShape = false;
                currentShapeResizeHandle = null;
                originalShapeData = null;
                container.ReleaseMouseCapture();
                RedrawAllShapes();
                if (resizedIndex >= 0 && resizedIndex < drawnShapeContainers.Count)
                {
                    SelectShape(resizedIndex);
                }
                
                if (resizedShape != null)
                {
                    OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Modified, resizedShape);
                }
                
                e.Handled = true;
            }
        }

        /// <summary>
        /// 处理图形调整大小
        /// </summary>
        private void HandleShapeResize(Point currentPoint)
        {
            if (selectedShapeIndex < 0 || selectedShapeIndex >= shapeInfoList.Count || originalShapeData == null)
                return;
                
            double screenDeltaX = currentPoint.X - shapeDragStartPoint.X;
            double screenDeltaY = currentPoint.Y - shapeDragStartPoint.Y;
            Point imageDelta = TransformVector(new Vector(screenDeltaX, screenDeltaY), useInverse: true);

            var shape = shapeInfoList[selectedShapeIndex];
            
            switch (shape.ShapeType)
            {
                case ShapeType.Rectangle:
                    ResizeRectangleShape(shape as RectangleShapeInfo, originalShapeData as RectangleShapeInfo, imageDelta);
                    break;
                case ShapeType.Ellipse:
                    ResizeEllipseShape(shape as EllipseShapeInfo, originalShapeData as EllipseShapeInfo, imageDelta);
                    break;
                case ShapeType.Circle:
                    ResizeCircleShape(shape as CircleShapeInfo, originalShapeData as CircleShapeInfo, imageDelta);
                    break;
                case ShapeType.Line:
                    ResizeLineShape(shape as LineShapeInfo, originalShapeData as LineShapeInfo, imageDelta);
                    break;
                case ShapeType.Arrow:
                    ResizeArrowShape(shape as ArrowShapeInfo, originalShapeData as ArrowShapeInfo, imageDelta);
                    break;
                case ShapeType.Crosshair:
                    ResizeCrosshairShape(shape as CrosshairShapeInfo, originalShapeData as CrosshairShapeInfo, imageDelta);
                    break;
            }

            UpdateShapeContainerForResize();
        }

        /// <summary>
        /// 调整矩形大小
        /// </summary>
        private void ResizeRectangleShape(RectangleShapeInfo shape, RectangleShapeInfo original, Point delta)
        {
            double newLeft = original.Rect.Left;
            double newTop = original.Rect.Top;
            double newRight = original.Rect.Right;
            double newBottom = original.Rect.Bottom;

            switch (currentShapeResizeHandle)
            {
                case "NW":
                    newLeft += delta.X;
                    newTop += delta.Y;
                    break;
                case "N":
                    newTop += delta.Y;
                    break;
                case "NE":
                    newRight += delta.X;
                    newTop += delta.Y;
                    break;
                case "W":
                    newLeft += delta.X;
                    break;
                case "E":
                    newRight += delta.X;
                    break;
                case "SW":
                    newLeft += delta.X;
                    newBottom += delta.Y;
                    break;
                case "S":
                    newBottom += delta.Y;
                    break;
                case "SE":
                    newRight += delta.X;
                    newBottom += delta.Y;
                    break;
            }
            if (newRight - newLeft < 5) newRight = newLeft + 5;
            if (newBottom - newTop < 5) newBottom = newTop + 5;

            shape.Rect = new Rect(
                Math.Min(newLeft, newRight),
                Math.Min(newTop, newBottom),
                Math.Abs(newRight - newLeft),
                Math.Abs(newBottom - newTop));
        }

        /// <summary>
        /// 调整椭圆大小
        /// </summary>
        private void ResizeEllipseShape(EllipseShapeInfo shape, EllipseShapeInfo original, Point delta)
        {
            double left = original.Center.X - original.RadiusX;
            double top = original.Center.Y - original.RadiusY;
            double right = original.Center.X + original.RadiusX;
            double bottom = original.Center.Y + original.RadiusY;

            switch (currentShapeResizeHandle)
            {
                case "NW":
                    left += delta.X;
                    top += delta.Y;
                    break;
                case "N":
                    top += delta.Y;
                    break;
                case "NE":
                    right += delta.X;
                    top += delta.Y;
                    break;
                case "W":
                    left += delta.X;
                    break;
                case "E":
                    right += delta.X;
                    break;
                case "SW":
                    left += delta.X;
                    bottom += delta.Y;
                    break;
                case "S":
                    bottom += delta.Y;
                    break;
                case "SE":
                    right += delta.X;
                    bottom += delta.Y;
                    break;
            }

            double radiusX = Math.Max(Math.Abs(right - left) / 2, 5);
            double radiusY = Math.Max(Math.Abs(bottom - top) / 2, 5);
            
            shape.Center = new Point((left + right) / 2, (top + bottom) / 2);
            shape.RadiusX = radiusX;
            shape.RadiusY = radiusY;
        }

        /// <summary>
        /// 调整圆形大小
        /// </summary>
        private void ResizeCircleShape(CircleShapeInfo shape, CircleShapeInfo original, Point delta)
        {
            double radiusChange = 0;
            
            switch (currentShapeResizeHandle)
            {
                case "N":
                    radiusChange = -delta.Y;
                    break;
                case "S":
                    radiusChange = delta.Y;
                    break;
                case "W":
                    radiusChange = -delta.X;
                    break;
                case "E":
                    radiusChange = delta.X;
                    break;
            }

            shape.Radius = Math.Max(original.Radius + radiusChange, 5);
        }

        /// <summary>
        /// 调整线条端点
        /// </summary>
        private void ResizeLineShape(LineShapeInfo shape, LineShapeInfo original, Point delta)
        {
            switch (currentShapeResizeHandle)
            {
                case "Start":
                    shape.StartPoint = new Point(original.StartPoint.X + delta.X, original.StartPoint.Y + delta.Y);
                    break;
                case "End":
                    shape.EndPoint = new Point(original.EndPoint.X + delta.X, original.EndPoint.Y + delta.Y);
                    break;
            }
        }

        /// <summary>
        /// 调整箭头端点
        /// </summary>
        private void ResizeArrowShape(ArrowShapeInfo shape, ArrowShapeInfo original, Point delta)
        {
            switch (currentShapeResizeHandle)
            {
                case "Start":
                    shape.StartPoint = new Point(original.StartPoint.X + delta.X, original.StartPoint.Y + delta.Y);
                    break;
                case "End":
                    shape.EndPoint = new Point(original.EndPoint.X + delta.X, original.EndPoint.Y + delta.Y);
                    break;
            }
        }

        /// <summary>
        /// 调整十字准星大小
        /// </summary>
        private void ResizeCrosshairShape(CrosshairShapeInfo shape, CrosshairShapeInfo original, Point delta)
        {
            double sizeChange = 0;
            
            switch (currentShapeResizeHandle)
            {
                case "N":
                    sizeChange = -delta.Y;
                    break;
                case "S":
                    sizeChange = delta.Y;
                    break;
                case "W":
                    sizeChange = -delta.X;
                    break;
                case "E":
                    sizeChange = delta.X;
                    break;
            }

            shape.Size = Math.Max(original.Size + sizeChange * 2, 10);
        }

        /// <summary>
        /// 更新容器以反映调整大小的变化
        /// </summary>
        private void UpdateShapeContainerForResize()
        {
            if (selectedShapeIndex < 0 || selectedShapeIndex >= drawnShapeContainers.Count)
                return;

            var shape = shapeInfoList[selectedShapeIndex];
            var bounds = GetShapeBounds(shape);
            
            // 转换到屏幕坐标
            Point screenTopLeft = TransformPoint(new Point(bounds.Left, bounds.Top), useInverse: false);
            Point screenBottomRight = TransformPoint(new Point(bounds.Right, bounds.Bottom), useInverse: false);
            
            double left = Math.Min(screenTopLeft.X, screenBottomRight.X);
            double top = Math.Min(screenTopLeft.Y, screenBottomRight.Y);
            double width = Math.Max(Math.Abs(screenBottomRight.X - screenTopLeft.X), 10);
            double height = Math.Max(Math.Abs(screenBottomRight.Y - screenTopLeft.Y), 10);

            var container = drawnShapeContainers[selectedShapeIndex];
            container.Width = width;
            container.Height = height;
            Canvas.SetLeft(container, left);
            Canvas.SetTop(container, top);
            var contentCanvas = container.Children.OfType<Canvas>().FirstOrDefault();
            if (contentCanvas != null)
            {
                contentCanvas.Width = width;
                contentCanvas.Height = height;
            }
        }

        /// <summary>
        /// 调整元素位置使其相对于容器
        /// </summary>
        private void AdjustElementPosition(FrameworkElement element, ShapeInfo shape, double containerLeft, double containerTop)
        {
            if (element is Line line)
            {
                line.X1 -= containerLeft;
                line.Y1 -= containerTop;
                line.X2 -= containerLeft;
                line.Y2 -= containerTop;
            }
            else if (element is System.Windows.Shapes.Rectangle rect)
            {
                double rectLeft = Canvas.GetLeft(rect);
                double rectTop = Canvas.GetTop(rect);
                Canvas.SetLeft(rect, rectLeft - containerLeft);
                Canvas.SetTop(rect, rectTop - containerTop);
            }
            else if (element is Ellipse ellipse)
            {
                double ellipseLeft = Canvas.GetLeft(ellipse);
                double ellipseTop = Canvas.GetTop(ellipse);
                Canvas.SetLeft(ellipse, ellipseLeft - containerLeft);
                Canvas.SetTop(ellipse, ellipseTop - containerTop);
            }
            else if (element is Canvas canvas)
            {
                foreach (UIElement child in canvas.Children)
                {
                    if (child is Line childLine)
                    {
                        childLine.X1 -= containerLeft;
                        childLine.Y1 -= containerTop;
                        childLine.X2 -= containerLeft;
                        childLine.Y2 -= containerTop;
                    }
                    else if (child is Ellipse childEllipse)
                    {
                        double childLeft = Canvas.GetLeft(childEllipse);
                        double childTop = Canvas.GetTop(childEllipse);
                        Canvas.SetLeft(childEllipse, childLeft - containerLeft);
                        Canvas.SetTop(childEllipse, childTop - containerTop);
                    }
                }
            }
            else if (element is Polygon polygon)
            {
                var newPoints = new PointCollection();
                foreach (var pt in polygon.Points)
                {
                    newPoints.Add(new Point(pt.X - containerLeft, pt.Y - containerTop));
                }
                polygon.Points = newPoints;
            }
        }

        /// <summary>
        /// 图形左键按下事件 - 开始拖拽
        /// </summary>
        private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (CurrentDrawingMode != DrawingMode.None)
                return; 
                
            if (sender is Grid container && container.Tag is int index)
            {
                SelectShape(index);
                
                // 开始拖拽
                isDraggingShape = true;
                shapeDragStartPoint = e.GetPosition(ImageCanvas);
                originalShapeData = CloneShapeInfo(shapeInfoList[index]);
                container.CaptureMouse();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 图形鼠标移动事件 - 处理拖拽
        /// </summary>
        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDraggingShape || selectedShapeIndex < 0)
                return;
                
            if (sender is Grid container && container.Tag is int index && index == selectedShapeIndex)
            {
                Point currentPoint = e.GetPosition(ImageCanvas);
                HandleShapeDrag(currentPoint);
                e.Handled = true;
            }
        }

        /// <summary>
        /// 图形鼠标释放事件 - 结束拖拽
        /// </summary>
        private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!isDraggingShape)
                return;
                
            if (sender is Grid container)
            {
                // 保存当前选中的索引和图形信息
                int draggedIndex = selectedShapeIndex;
                ShapeInfo draggedShape = draggedIndex >= 0 && draggedIndex < shapeInfoList.Count 
                    ? shapeInfoList[draggedIndex] : null;
                
                isDraggingShape = false;
                originalShapeData = null;
                container.ReleaseMouseCapture();
                
                // 重绘所有图形以确保显示正确
                RedrawAllShapes();
                
                // 重新选中之前拖动的图形
                if (draggedIndex >= 0 && draggedIndex < drawnShapeContainers.Count)
                {
                    SelectShape(draggedIndex);
                }
                
                // 触发修改事件
                if (draggedShape != null)
                {
                    OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Modified, draggedShape);
                }
                
                e.Handled = true;
            }
        }

        /// <summary>
        /// 图形右键按下事件 - 显示上下文菜单
        /// </summary>
        private void Shape_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Grid container && container.Tag is int index)
            {
                SelectShape(index);
                var contextMenu = new ContextMenu();
                
                var deleteItem = new MenuItem { Header = "删除图形" };
                deleteItem.Click += (s, args) => DeleteShape(index);
                contextMenu.Items.Add(deleteItem);
                
                var moveToTopItem = new MenuItem { Header = "移到顶层" };
                moveToTopItem.Click += (s, args) => MoveShapeToTop(index);
                contextMenu.Items.Add(moveToTopItem);
                
                var moveToBottomItem = new MenuItem { Header = "移到底层" };
                moveToBottomItem.Click += (s, args) => MoveShapeToBottom(index);
                contextMenu.Items.Add(moveToBottomItem);
                
                contextMenu.IsOpen = true;
                e.Handled = true;
            }
        }

        /// <summary>
        /// 图形名称文本框失去焦点事件
        /// </summary>
        private void ShapeNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Parent is Border border && border.Parent is Grid container)
            {
                if (container.Tag is int index && index >= 0 && index < shapeInfoList.Count)
                {
                    shapeInfoList[index].Name = textBox.Text;
                    UpdateShapeNameLabel(container, textBox.Text);
                    
                    DebugLog($"图形 {index + 1} 名称已更新为: {textBox.Text}");
                }
            }
        }

        /// <summary>
        /// 图形名称文本框按键事件
        /// </summary>
        private void ShapeNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // 按回车确认修改，移除焦点
                Keyboard.ClearFocus();
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                // 按ESC取消修改，恢复原名称
                if (sender is TextBox textBox && textBox.Parent is Border border && border.Parent is Grid container)
                {
                    if (container.Tag is int index && index >= 0 && index < shapeInfoList.Count)
                    {
                        textBox.Text = shapeInfoList[index].Name ?? GetShapeDefaultName(shapeInfoList[index].ShapeType, index + 1);
                    }
                    Keyboard.ClearFocus();
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 更新图形名称标签显示
        /// </summary>
        private void UpdateShapeNameLabel(Grid container, string name)
        {
            foreach (var child in container.Children)
            {
                if (child is Border border && border.Tag is string tag && tag == "NameLabel")
                {
                    if (border.Child is TextBlock textBlock)
                    {
                        textBlock.Text = name;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 选中图形
        /// </summary>
        private void SelectShape(int index)
        {
            // 取消之前的选中
            if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
            {
                UpdateShapeSelectionAppearance(selectedShapeIndex, false);
            }
            
            selectedShapeIndex = index;
            
            if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
            {
                UpdateShapeSelectionAppearance(selectedShapeIndex, true);
            }
        }

        /// <summary>
        /// 更新图形选中外观
        /// </summary>
        private void UpdateShapeSelectionAppearance(int index, bool isSelected)
        {
            if (index < 0 || index >= drawnShapeContainers.Count)
                return;
                
            var container = drawnShapeContainers[index];
            foreach (UIElement child in container.Children)
            {
                if (child is Rectangle rect)
                {
                    // 选中边框
                    if (rect.Name == "SelectionBorder")
                    {
                        rect.Visibility = isSelected ? Visibility.Visible : Visibility.Collapsed;
                    }
                    // 调整大小手柄
                    else if (rect.Name != null && rect.Name.StartsWith("ShapeHandle_"))
                    {
                        rect.Visibility = isSelected ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
                else if (child is Border border && border.Tag is string borderTag)
                {
                    if (borderTag == "NameLabel")
                    {
                        // 名称标签：选中时变黄色
                        border.Background = isSelected ? Brushes.Yellow : Brushes.Lime;
                    }
                    else if (borderTag == "NameEdit")
                    {
                        // 名称编辑框：选中时显示
                        border.Visibility = isSelected ? Visibility.Visible : Visibility.Collapsed;
                        
                        // 更新文本框中的名称
                        if (isSelected && border.Child is TextBox textBox && index < shapeInfoList.Count)
                        {
                            textBox.Text = shapeInfoList[index].Name ?? GetShapeDefaultName(shapeInfoList[index].ShapeType, index + 1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 删除图形
        /// </summary>
        public void DeleteShape(int index)
        {
            if (index < 0 || index >= shapeInfoList.Count)
                return;
                
            var shape = shapeInfoList[index];
            
            // 移除容器
            if (index < drawnShapeContainers.Count)
            {
                var container = drawnShapeContainers[index];
                UnsubscribeShapeContainerEvents(container);
                ImageCanvas?.Children.Remove(container);
                drawnShapeContainers.RemoveAt(index);
            }
            
            if (index < drawnShapeElements.Count)
            {
                drawnShapeElements.RemoveAt(index);
            }
            
            // 移除图形数据
            shapeInfoList.RemoveAt(index);
            for (int i = index; i < drawnShapeContainers.Count; i++)
            {
                drawnShapeContainers[i].Tag = i;
            }
            // 同步到绑定的集合
            if (ShapeCollection != null)
            {
                isUpdatingShapeCollection = true;
                try
                {
                    ShapeCollection.Remove(shape);
                }
                finally
                {
                    isUpdatingShapeCollection = false;
                }
            }
            if (selectedShapeIndex == index)
            {
                selectedShapeIndex = -1;
            }
            else if (selectedShapeIndex > index)
            {
                selectedShapeIndex--;
            }
            OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Removed, shape);
        }

        /// <summary>
        /// 将图形移到顶层
        /// </summary>
        private void MoveShapeToTop(int index)
        {
            if (index < 0 || index >= shapeInfoList.Count)
                return;

            // 将图形移到列表末尾（最后绘制 = 最顶层）
            var shape = shapeInfoList[index];
            shapeInfoList.RemoveAt(index);
            shapeInfoList.Add(shape);
                
            // 重绘所有图形
            RedrawAllShapes();
        }

        /// <summary>
        /// 将图形移到底层
        /// </summary>
        private void MoveShapeToBottom(int index)
        {
            if (index < 0 || index >= shapeInfoList.Count)
                return;
                
            // 将图形移到列表开头
            var shape = shapeInfoList[index];
            shapeInfoList.RemoveAt(index);
            shapeInfoList.Insert(0, shape);
            
            // 重绘所有图形
            RedrawAllShapes();
        }

        /// <summary>
        /// 取消订阅图形容器事件
        /// </summary>
        private void UnsubscribeShapeContainerEvents(Grid container)
        {
            container.MouseLeftButtonDown -= Shape_MouseLeftButtonDown;
            container.MouseLeftButtonUp -= Shape_MouseLeftButtonUp;
            container.MouseMove -= Shape_MouseMove;
            container.MouseRightButtonDown -= Shape_MouseRightButtonDown;
            
            foreach (UIElement child in container.Children)
            {
                if (child is Rectangle rect && rect.Name != null && rect.Name.StartsWith("ShapeHandle_"))
                {
                    rect.MouseLeftButtonDown -= ShapeResizeHandle_MouseLeftButtonDown;
                    rect.MouseLeftButtonUp -= ShapeResizeHandle_MouseLeftButtonUp;
                    rect.MouseMove -= ShapeResizeHandle_MouseMove;
                }
                else if (child is Border border && border.Tag is string tag && tag == "NameEdit")
                {
                    if (border.Child is TextBox textBox)
                    {
                        textBox.LostFocus -= ShapeNameTextBox_LostFocus;
                        textBox.KeyDown -= ShapeNameTextBox_KeyDown;
                    }
                }
            }
        }

        /// <summary>
        /// 克隆图形信息
        /// </summary>
        private ShapeInfo CloneShapeInfo(ShapeInfo shape)
        {
            switch (shape.ShapeType)
            {
                case ShapeType.Line:
                    var line = shape as LineShapeInfo;
                    return new LineShapeInfo
                    {
                        StartPoint = line.StartPoint,
                        EndPoint = line.EndPoint,
                        StrokeColor = line.StrokeColor,
                        StrokeThickness = line.StrokeThickness,
                        Tag = line.Tag
                    };
                case ShapeType.Rectangle:
                    var rect = shape as RectangleShapeInfo;
                    return new RectangleShapeInfo
                    {
                        Rect = rect.Rect,
                        StrokeColor = rect.StrokeColor,
                        FillColor = rect.FillColor,
                        StrokeThickness = rect.StrokeThickness,
                        Tag = rect.Tag
                    };
                case ShapeType.Circle:
                    var circle = shape as CircleShapeInfo;
                    return new CircleShapeInfo
                    {
                        Center = circle.Center,
                        Radius = circle.Radius,
                        StrokeColor = circle.StrokeColor,
                        FillColor = circle.FillColor,
                        StrokeThickness = circle.StrokeThickness,
                        Tag = circle.Tag
                    };
                case ShapeType.Ellipse:
                    var ellipse = shape as EllipseShapeInfo;
                    return new EllipseShapeInfo
                    {
                        Center = ellipse.Center,
                        RadiusX = ellipse.RadiusX,
                        RadiusY = ellipse.RadiusY,
                        StrokeColor = ellipse.StrokeColor,
                        FillColor = ellipse.FillColor,
                        StrokeThickness = ellipse.StrokeThickness,
                        Tag = ellipse.Tag
                    };
                case ShapeType.Crosshair:
                    var crosshair = shape as CrosshairShapeInfo;
                    return new CrosshairShapeInfo
                    {
                        Center = crosshair.Center,
                        Size = crosshair.Size,
                        StrokeColor = crosshair.StrokeColor,
                        StrokeThickness = crosshair.StrokeThickness,
                        ShowCenterDot = crosshair.ShowCenterDot,
                        Tag = crosshair.Tag
                    };
                case ShapeType.Arrow:
                    var arrow = shape as ArrowShapeInfo;
                    return new ArrowShapeInfo
                    {
                        StartPoint = arrow.StartPoint,
                        EndPoint = arrow.EndPoint,
                        StrokeColor = arrow.StrokeColor,
                        StrokeThickness = arrow.StrokeThickness,
                        ArrowSize = arrow.ArrowSize,
                        Tag = arrow.Tag
                    };
                case ShapeType.Polygon:
                    var polygon = shape as PolygonShapeInfo;
                    return new PolygonShapeInfo
                    {
                        Points = new List<Point>(polygon.Points),
                        StrokeColor = polygon.StrokeColor,
                        FillColor = polygon.FillColor,
                        StrokeThickness = polygon.StrokeThickness,
                        Tag = polygon.Tag
                    };
                default:
                    return null;
            }
        }

        /// <summary>
        /// 创建直线元素
        /// </summary>
        private Line CreateLineElement(LineShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenStart = TransformPoint(shape.StartPoint, useInverse: false);
            Point screenEnd = TransformPoint(shape.EndPoint, useInverse: false);

            return new Line
            {
                X1 = screenStart.X,
                Y1 = screenStart.Y,
                X2 = screenEnd.X,
                Y2 = screenEnd.Y,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
        }

        /// <summary>
        /// 创建矩形元素
        /// </summary>
        private Rectangle CreateRectangleElement(RectangleShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenTopLeft = TransformPoint(shape.Rect.TopLeft, useInverse: false);
            Point screenBottomRight = TransformPoint(shape.Rect.BottomRight, useInverse: false);

            double left = Math.Min(screenTopLeft.X, screenBottomRight.X);
            double top = Math.Min(screenTopLeft.Y, screenBottomRight.Y);
            double width = Math.Abs(screenBottomRight.X - screenTopLeft.X);
            double height = Math.Abs(screenBottomRight.Y - screenTopLeft.Y);

            var rect = new Rectangle
            {
                Width = width,
                Height = height,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness,
                Fill = shape.FillColor == Colors.Transparent ? null : new SolidColorBrush(shape.FillColor)
            };

            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);

            return rect;
        }

        /// <summary>
        /// 创建圆形元素
        /// </summary>
        private Ellipse CreateCircleElement(CircleShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenCenter = TransformPoint(shape.Center, useInverse: false);
            double screenRadius = shape.Radius * scaleTransform.ScaleX;

            var ellipse = new Ellipse
            {
                Width = screenRadius * 2,
                Height = screenRadius * 2,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness,
                Fill = shape.FillColor == Colors.Transparent ? null : new SolidColorBrush(shape.FillColor)
            };

            Canvas.SetLeft(ellipse, screenCenter.X - screenRadius);
            Canvas.SetTop(ellipse, screenCenter.Y - screenRadius);

            return ellipse;
        }

        /// <summary>
        /// 创建椭圆元素
        /// </summary>
        private Ellipse CreateEllipseElement(EllipseShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenCenter = TransformPoint(shape.Center, useInverse: false);
            double screenRadiusX = shape.RadiusX * scaleTransform.ScaleX;
            double screenRadiusY = shape.RadiusY * scaleTransform.ScaleY;

            var ellipse = new Ellipse
            {
                Width = screenRadiusX * 2,
                Height = screenRadiusY * 2,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness,
                Fill = shape.FillColor == Colors.Transparent ? null : new SolidColorBrush(shape.FillColor)
            };

            Canvas.SetLeft(ellipse, screenCenter.X - screenRadiusX);
            Canvas.SetTop(ellipse, screenCenter.Y - screenRadiusY);

            return ellipse;
        }

        /// <summary>
        /// 创建多边形元素
        /// </summary>
        private Polygon CreatePolygonElement(PolygonShapeInfo shape)
        {
            if (shape == null || shape.Points == null || shape.Points.Count < 3) return null;

            var polygon = new Polygon
            {
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness,
                Fill = shape.FillColor == Colors.Transparent ? null : new SolidColorBrush(shape.FillColor)
            };

            foreach (var point in shape.Points)
            {
                Point screenPoint = TransformPoint(point, useInverse: false);
                polygon.Points.Add(screenPoint);
            }

            return polygon;
        }

        /// <summary>
        /// 创建文字元素
        /// </summary>
        private Border CreateTextElement(TextShapeInfo shape)
        {
            if (shape == null || string.IsNullOrEmpty(shape.Text)) return null;

            Point screenPos = TransformPoint(shape.Position, useInverse: false);

            var textBlock = new TextBlock
            {
                Text = shape.Text,
                Foreground = new SolidColorBrush(shape.StrokeColor),
                FontSize = shape.FontSize,
                FontWeight = FontWeights.Bold
            };

            var border = new Border
            {
                Child = textBlock,
                Background = shape.BackgroundColor == Colors.Transparent ? null : new SolidColorBrush(shape.BackgroundColor),
                Padding = new Thickness(2),
                CornerRadius = new CornerRadius(2)
            };

            Canvas.SetLeft(border, screenPos.X);
            Canvas.SetTop(border, screenPos.Y);

            return border;
        }

        /// <summary>
        /// 创建十字准星元素
        /// </summary>
        private Canvas CreateCrosshairElement(CrosshairShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenCenter = TransformPoint(shape.Center, useInverse: false);
            double screenSize = shape.Size * scaleTransform.ScaleX;
            
            DebugLog($"CreateCrosshairElement: 图像坐标=({shape.Center.X:F1}, {shape.Center.Y:F1}) -> 屏幕坐标=({screenCenter.X:F1}, {screenCenter.Y:F1}), Scale={scaleTransform.ScaleX:F3}");

            var container = new Canvas();

            // 水平线
            var hLine = new Line
            {
                X1 = screenCenter.X - screenSize,
                Y1 = screenCenter.Y,
                X2 = screenCenter.X + screenSize,
                Y2 = screenCenter.Y,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
            container.Children.Add(hLine);

            // 垂直线
            var vLine = new Line
            {
                X1 = screenCenter.X,
                Y1 = screenCenter.Y - screenSize,
                X2 = screenCenter.X,
                Y2 = screenCenter.Y + screenSize,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
            container.Children.Add(vLine);

            // 中心点
            if (shape.ShowCenterDot)
            {
                var dot = new Ellipse
                {
                    Width = 6,
                    Height = 6,
                    Fill = new SolidColorBrush(shape.StrokeColor)
                };
                Canvas.SetLeft(dot, screenCenter.X - 3);
                Canvas.SetTop(dot, screenCenter.Y - 3);
                container.Children.Add(dot);
            }

            return container;
        }

        /// <summary>
        /// 创建箭头元素
        /// </summary>
        private Canvas CreateArrowElement(ArrowShapeInfo shape)
        {
            if (shape == null) return null;

            Point screenStart = TransformPoint(shape.StartPoint, useInverse: false);
            Point screenEnd = TransformPoint(shape.EndPoint, useInverse: false);

            var container = new Canvas();

            // 主线
            var line = new Line
            {
                X1 = screenStart.X,
                Y1 = screenStart.Y,
                X2 = screenEnd.X,
                Y2 = screenEnd.Y,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
            container.Children.Add(line);

            // 计算箭头方向
            double angle = Math.Atan2(screenEnd.Y - screenStart.Y, screenEnd.X - screenStart.X);
            double arrowAngle = Math.PI / 6; // 30度

            // 箭头两翼
            double arrowSize = shape.ArrowSize;
            Point arrow1 = new Point(
                screenEnd.X - arrowSize * Math.Cos(angle - arrowAngle),
                screenEnd.Y - arrowSize * Math.Sin(angle - arrowAngle));
            Point arrow2 = new Point(
                screenEnd.X - arrowSize * Math.Cos(angle + arrowAngle),
                screenEnd.Y - arrowSize * Math.Sin(angle + arrowAngle));

            var arrowLine1 = new Line
            {
                X1 = screenEnd.X,
                Y1 = screenEnd.Y,
                X2 = arrow1.X,
                Y2 = arrow1.Y,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
            container.Children.Add(arrowLine1);

            var arrowLine2 = new Line
            {
                X1 = screenEnd.X,
                Y1 = screenEnd.Y,
                X2 = arrow2.X,
                Y2 = arrow2.Y,
                Stroke = new SolidColorBrush(shape.StrokeColor),
                StrokeThickness = shape.StrokeThickness
            };
            container.Children.Add(arrowLine2);

            return container;
        }

        /// <summary>
        /// 重绘所有图形
        /// </summary>
        public void RedrawAllShapes()
        {
            // 清除现有图形容器
            foreach (var container in drawnShapeContainers)
            {
                UnsubscribeShapeContainerEvents(container);
                ImageCanvas?.Children.Remove(container);
            }
            drawnShapeContainers.Clear();
            drawnShapeElements.Clear();

            // 重新绘制所有图形
            foreach (var shape in shapeInfoList)
            {
                DrawShape(shape);
            }
            
            // 恢复选中状态
            if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
            {
                UpdateShapeSelectionAppearance(selectedShapeIndex, true);
            }
        }

        /// <summary>
        /// 更新所有图形位置（缩放/平移后调用）
        /// </summary>
        private void UpdateAllShapesPosition()
        {
            if (shapeInfoList.Count > 0)
            {
                RedrawAllShapes();
            }
        }

        /// <summary>
        /// 清除所有图形（内部方法，不修改 ShapeCollection）
        /// </summary>
        private void ClearShapesInternal()
        {
            // 清除容器
            foreach (var container in drawnShapeContainers)
            {
                UnsubscribeShapeContainerEvents(container);
                ImageCanvas?.Children.Remove(container);
            }
            drawnShapeContainers.Clear();
            drawnShapeElements.Clear();
            shapeInfoList.Clear();
            selectedShapeIndex = -1;
            
            // 触发事件
            OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Cleared);
        }

        /// <summary>
        /// 清除所有图形
        /// </summary>
        public void ClearAllShapes()
        {
            // 清除内部数据和画布元素
            ClearShapesInternal();

            // 同步到绑定的集合
            if (ShapeCollection != null)
            {
                isUpdatingShapeCollection = true;
                try
                {
                    ShapeCollection.Clear();
                }
                finally
                {
                    isUpdatingShapeCollection = false;
                }
            }
        }

        /// <summary>
        /// 根据Tag清除图形
        /// </summary>
        public void ClearShapesByTag(string tag)
        {
            if (string.IsNullOrEmpty(tag)) return;

            var shapesToRemove = shapeInfoList.Where(s => s.Tag == tag).ToList();
            foreach (var shape in shapesToRemove)
            {
                shapeInfoList.Remove(shape);
                
                // 同步到绑定的集合
                if (ShapeCollection != null)
                {
                    isUpdatingShapeCollection = true;
                    try
                    {
                        ShapeCollection.Remove(shape);
                    }
                    finally
                    {
                        isUpdatingShapeCollection = false;
                    }
                }
            }

            RedrawAllShapes();
        }

        /// <summary>
        /// 获取图形数量
        /// </summary>
        public int ShapeCount => shapeInfoList.Count;

        #endregion


        private void MouseRUp(object sender, MouseButtonEventArgs e)
        {
            //isDragging = false;
            //ImageCanvas.ReleaseMouseCapture();
        }

        /// <summary>
        /// 预览鼠标按下事件 - 处理中键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Pressed)
            {
                MouseMiddleDown(sender, e);
            }
        }

        /// <summary>
        /// 预览鼠标松开事件 - 处理中键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.MiddleButton == MouseButtonState.Released && isDragging)
            {
                MouseMiddleUp(sender, e);
            }
        }

        /// <summary>
        /// 中键按下 - 开始拖拽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMiddleDown(object sender, MouseButtonEventArgs e)
        {
            if (!ValidateComponents())
                return;

            isDragging = true;
            lastMousePosition = e.GetPosition(ImageCanvas);
            ImageCanvas.CaptureMouse();
        }

        /// <summary>
        /// 中键松开 - 结束拖拽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseMiddleUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            ImageCanvas.ReleaseMouseCapture();
        }

        /// <summary>
        /// 鼠标离开画布事件 - 清空坐标显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            // 当鼠标离开图像区域时，清空右下角的坐标显示
            BottomRightText = string.Empty;
        }

        /// <summary>
        /// 右键按下 - 不再自动重置，由ResetSizeCommand命令触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseRDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void ResetImageScale()
        {
            if (!ValidateComponents())
                return;
            var visualSize = GetActualVisibleSize();
            double controlWidth = visualSize.Width;
            double controlHeight = visualSize.Height;

            var bitmapSource = (BitmapSource)InputImage;
            double imageWidth = bitmapSource.PixelWidth;
            double imageHeight = bitmapSource.PixelHeight;

            if (controlWidth <= 0 || controlHeight <= 0 || imageWidth <= 0 || imageHeight <= 0)
                return;
            var margin = ImageMargin;
            double availableWidth = controlWidth - margin.Left - margin.Right;
            double availableHeight = controlHeight - margin.Top - margin.Bottom;
            if (availableWidth <= 0 || availableHeight <= 0)
                return;
            
            // 计算等比例缩放因子（取最小值保持宽高比）
            double scaleX = availableWidth / imageWidth;
            double scaleY = availableHeight / imageHeight;
            double uniformScale = Math.Min(scaleX, scaleY);
            
            // 计算缩放后的图像尺寸
            double scaledWidth = imageWidth * uniformScale;
            double scaledHeight = imageHeight * uniformScale;
            
            // 计算居中偏移量
            double offsetX = margin.Left + (availableWidth - scaledWidth) / 2;
            double offsetY = margin.Top + (availableHeight - scaledHeight) / 2;
            
            scaleTransform.CenterX = 0;
            scaleTransform.CenterY = 0;
            scaleTransform.ScaleX = uniformScale;
            scaleTransform.ScaleY = uniformScale;
            translateTransform.X = offsetX;
            translateTransform.Y = offsetY;
            
            // 失效变换缓存
            InvalidateTransformCache();
            
            // 更新已绘制的ROI框和图形位置
            if (drawnRoiContainers.Count > 0 || shapeInfoList.Count > 0)
            {
                UpdateAllRoiRectanglesPosition();
            }
            
            if (SelectionRectangle != null && SelectionRectangle.Visibility == Visibility.Visible)
            {
                SelectionRectangle.Visibility = Visibility.Collapsed;
            }
            DebugLog($"等比例缩放居中: 可用区域({availableWidth:F1}, {availableHeight:F1}), 图像尺寸({imageWidth}, {imageHeight}), 统一缩放{uniformScale:F3}, 偏移({offsetX:F1}, {offsetY:F1})");
        }

        /// <summary>
        /// 线程安全的设置图像方法（异步版本）
        /// </summary>
        /// <param name="imageSource">新的图像源</param>
        public void SetImageSafe(ImageSource imageSource)
        {
            if (Dispatcher.CheckAccess())
            {
                InputImage = imageSource;
            }
            else
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    InputImage = imageSource;
                }), DispatcherPriority.Background);
            }
        }

        /// <summary>
        /// 线程安全的设置图像方法（同步版本，会阻塞直到设置完成）
        /// </summary>
        /// <param name="imageSource">新的图像源</param>
        public void SetImageSafeSync(ImageSource imageSource)
        {
            if (Dispatcher.CheckAccess())
            {
                InputImage = imageSource;
            }
            else
            {
                Dispatcher.Invoke(() =>
                {
                    InputImage = imageSource;
                });
            }
        }

        /// <summary>
        /// 公共方法：重置图像缩放和位置到居中状态
        /// </summary>
        public void ResetImageToCenter()
        {
            ResetImageScale();
        }

        /// <summary>
        /// 强制重置图像到适合控件的尺寸（调试用）
        /// </summary>
        public void ForceResetToFit()
        {
            if (Dispatcher.CheckAccess())
            {
                ForceResetImageFit();
            }
            else
            {
                Dispatcher.Invoke(() => ForceResetImageFit());
            }
        }

        /// <summary>
        /// 获取控件实际可视区域尺寸
        /// </summary>
        /// <returns>实际可视区域的尺寸</returns>
        private Size GetActualVisibleSize()
        {
            if (ImageCanvas == null)
                return new Size(0, 0);

            try
            {
                var renderSize = ImageCanvas.RenderSize;
                var clip = ImageCanvas.Clip;
                if (clip != null)
                {
                    var clipBounds = clip.Bounds;
                    renderSize.Width = Math.Min(renderSize.Width, clipBounds.Width);
                    renderSize.Height = Math.Min(renderSize.Height, clipBounds.Height);
                }
                var parent = ImageCanvas.Parent as FrameworkElement;
                if (parent != null)
                {
                    if (parent.ActualWidth > 0 && parent.ActualWidth < renderSize.Width)
                        renderSize.Width = parent.ActualWidth;
                    if (parent.ActualHeight > 0 && parent.ActualHeight < renderSize.Height)
                        renderSize.Height = parent.ActualHeight;

                    if (parent is Control parentControl)
                    {
                        var padding = parentControl.Padding;
                        renderSize.Width = Math.Max(0, renderSize.Width - padding.Left - padding.Right);
                        renderSize.Height = Math.Max(0, renderSize.Height - padding.Top - padding.Bottom);
                    }
                    else if (parent is Border border)
                    {
                        var padding = border.Padding;
                        var borderThickness = border.BorderThickness;
                        renderSize.Width = Math.Max(0, renderSize.Width - padding.Left - padding.Right - borderThickness.Left - borderThickness.Right);
                        renderSize.Height = Math.Max(0, renderSize.Height - padding.Top - padding.Bottom - borderThickness.Top - borderThickness.Bottom);
                    }
                }
                try
                {
                    var visualBounds = VisualTreeHelper.GetDescendantBounds(ImageCanvas);
                    if (!visualBounds.IsEmpty)
                    {
                        renderSize.Width = Math.Min(renderSize.Width, visualBounds.Width);
                        renderSize.Height = Math.Min(renderSize.Height, visualBounds.Height);
                    }
                }
                catch
                {
                }
                if (renderSize.Width <= 0 || renderSize.Height <= 0)
                {
                    return new Size(
                        Math.Max(0, ImageCanvas.ActualWidth),
                        Math.Max(0, ImageCanvas.ActualHeight)
                    );
                }

                return renderSize;
            }
            catch (Exception ex)
            {
                DebugLog($"获取可视区域尺寸时出错: {ex.Message}");
                return new Size(
                    Math.Max(0, ImageCanvas.ActualWidth),
                    Math.Max(0, ImageCanvas.ActualHeight)
                );
            }
        }

        /// <summary>
        /// 强制重置图像适应控件（更彻底的重置）
        /// </summary>
        private void ForceResetImageFit()
        {
            if (!ValidateComponents())
                return;
            isDragging = false;
            isSelecting = false;
            ImageCanvas.ReleaseMouseCapture();
            var visualSize = GetActualVisibleSize();
            double controlWidth = visualSize.Width;
            double controlHeight = visualSize.Height;
            var bitmapSource = (BitmapSource)InputImage;
            double imageWidth = bitmapSource.PixelWidth;
            double imageHeight = bitmapSource.PixelHeight;
            if (controlWidth <= 0 || controlHeight <= 0 || imageWidth <= 0 || imageHeight <= 0)
                return;
            var margin = ImageMargin;
            double availableWidth = controlWidth - margin.Left - margin.Right;
            double availableHeight = controlHeight - margin.Top - margin.Bottom;
            if (availableWidth <= 0 || availableHeight <= 0)
                return;
            
            // 计算等比例缩放因子（取最小值保持宽高比）
            double scaleX = availableWidth / imageWidth;
            double scaleY = availableHeight / imageHeight;
            double uniformScale = Math.Min(scaleX, scaleY);
            
            // 计算缩放后的图像尺寸
            double scaledWidth = imageWidth * uniformScale;
            double scaledHeight = imageHeight * uniformScale;
            
            // 计算居中偏移量
            double offsetX = margin.Left + (availableWidth - scaledWidth) / 2;
            double offsetY = margin.Top + (availableHeight - scaledHeight) / 2;
            
            scaleTransform.CenterX = 0;
            scaleTransform.CenterY = 0;
            scaleTransform.ScaleX = uniformScale;
            scaleTransform.ScaleY = uniformScale;
            translateTransform.X = offsetX;
            translateTransform.Y = offsetY;
            
            // 失效变换缓存
            InvalidateTransformCache();
            
            // 更新已绘制的ROI框和图形位置
            if (drawnRoiContainers.Count > 0 || shapeInfoList.Count > 0)
            {
                UpdateAllRoiRectanglesPosition();
            }
            
            if (SelectionRectangle != null)
            {
                SelectionRectangle.Visibility = Visibility.Collapsed;
            }

            DebugLog($"强制等比例缩放居中: 可用区域({availableWidth:F1}, {availableHeight:F1}), 图像({imageWidth}, {imageHeight}), 统一缩放{uniformScale:F3}, 偏移({offsetX:F1}, {offsetY:F1})");
        }

        /// <summary>
        /// 获取当前内存使用情况（用于调试）
        /// </summary>
        /// <returns>内存使用信息</returns>
        public string GetMemoryInfo()
        {
            var process = System.Diagnostics.Process.GetCurrentProcess();
            var workingSet = process.WorkingSet64 / 1024 / 1024; // MB
            var privateMemory = process.PrivateMemorySize64 / 1024 / 1024; // MB
            var gcMemory = GC.GetTotalMemory(false) / 1024 / 1024; // MB
            var gen0 = GC.CollectionCount(0);
            var gen1 = GC.CollectionCount(1);
            var gen2 = GC.CollectionCount(2);

            return $"WorkingSet: {workingSet}MB, Private: {privateMemory}MB, GC: {gcMemory}MB, " +
                   $"Gen0: {gen0}, Gen1: {gen1}, Gen2: {gen2}";
        }

        /// <summary>
        /// 设置高性能模式（用于大分辨率图像）
        /// </summary>
        /// <param name="enabled">是否启用高性能模式</param>
        public void SetHighPerformanceMode(bool enabled)
        {
            isHighPerformanceMode = enabled;
            var originalImage = GetTemplateChild("OriginalImageControl") as Image;
            if (originalImage != null)
            {
                if (enabled)
                {
                    RenderOptions.SetBitmapScalingMode(originalImage, BitmapScalingMode.LowQuality);
                    RenderOptions.SetEdgeMode(originalImage, EdgeMode.Aliased);
                    RenderOptions.SetClearTypeHint(originalImage, ClearTypeHint.Enabled);
                }
                else
                {
                    RenderOptions.SetBitmapScalingMode(originalImage, BitmapScalingMode.HighQuality);
                    RenderOptions.SetEdgeMode(originalImage, EdgeMode.Unspecified);
                    RenderOptions.SetClearTypeHint(originalImage, ClearTypeHint.Auto);
                }
            }

            DebugLog($"高性能模式: {(enabled ? "启用" : "禁用")}");
        }

        /// <summary>
        /// 获取当前性能模式状态
        /// </summary>
        /// <returns>是否为高性能模式</returns>
        public bool IsHighPerformanceMode => isHighPerformanceMode;

        /// <summary>
        /// 根据图像尺寸自动调整性能模式
        /// </summary>
        /// <param name="imageSource">图像源</param>
        private void AutoAdjustPerformanceMode(ImageSource imageSource)
        {
            if (imageSource is BitmapSource bitmapSource)
            {
                long totalPixels = (long)bitmapSource.PixelWidth * bitmapSource.PixelHeight;
                
                // 标记是否为大图（超过1亿像素）
                isLargeImage = totalPixels > 100000000;
                
                SetHighPerformanceMode(true);
                DebugLog($"自动调整性能模式: 图像尺寸 {bitmapSource.PixelWidth}x{bitmapSource.PixelHeight}, " +
                                                 $"总像素 {totalPixels:N0}, 大图模式: {isLargeImage}");
            }
        }

        /// <summary>
        /// 强制内存清理
        /// </summary>
        public void ForceMemoryCleanup()
        {
            lock (disposeLock)
            {
                // 清除缓存引用
                cachedBitmapSource = null;
                cachedImageWidth = 0;
                cachedImageHeight = 0;
                lastImageReference = null;
                InvalidateTransformCache();
                
                // 请求 GC 回收
                GC.Collect(2, GCCollectionMode.Optimized);
                GC.WaitForPendingFinalizers();
            }
        }

        /// <summary>
        /// 安全地设置图像文件路径（推荐使用这个方法而不是直接设置HandleImage）
        /// </summary>
        /// <param name="imagePath">图像文件路径</param>
        public void SetImagePathSafe(string imagePath)
        {
            try
            {
                var optimizedImage = CreateOptimizedBitmapImage(imagePath);
                if (optimizedImage != null)
                {
                    SetImageSafe(optimizedImage);
                }
            }
            catch (Exception ex)
            {
                DebugLog($"设置图像路径时出错: {ex.Message}");
            }
        }

        /// <summary>
        /// 滚轮移动 - 使用稳定的纯平移+缩放算法（内存优化版）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Wheel(object sender, MouseWheelEventArgs e)
        {
            if (!ValidateComponents() || isSelecting)
                return;

            // 累积滚轮增量
            pendingWheelDelta += e.Delta;
            
            // 大图模式下使用更激进的节流（100ms）
            var currentTicks = moveStopwatch.ElapsedTicks;
            long throttle = isLargeImage ? 1000000 : WheelThrottleTicks; // 大图100ms，普通图33ms
            
            if ((currentTicks - lastWheelTimeTicks) < throttle)
            {
                // 节流期间，只累积不处理
                if (!isWheelUpdatePending)
                {
                    isWheelUpdatePending = true;
                    // 大图模式使用更低优先级，让UI保持响应
                    var priority = isLargeImage ? DispatcherPriority.Background : DispatcherPriority.Input;
                    if (cachedProcessPendingWheelZoomAction != null)
                    {
                        Dispatcher.BeginInvoke(cachedProcessPendingWheelZoomAction, priority);
                    }
                }
                return;
            }
            
            // 执行缩放操作
            lastWheelTimeTicks = currentTicks;
            ApplyWheelZoom(e.GetPosition(ImageCanvas), pendingWheelDelta);
            pendingWheelDelta = 0;
            isWheelUpdatePending = false;
        }
        
        /// <summary>
        /// 处理待处理的滚轮缩放（节流后的合并处理）
        /// </summary>
        private void ProcessPendingWheelZoom()
        {
            if (!isWheelUpdatePending || pendingWheelDelta == 0)
                return;
            
            isWheelUpdatePending = false;
            lastWheelTimeTicks = moveStopwatch.ElapsedTicks;
            
            // 获取当前鼠标位置
            Point mousePosition;
            try
            {
                mousePosition = Mouse.GetPosition(ImageCanvas);
            }
            catch
            {
                pendingWheelDelta = 0;
                return;
            }
            
            ApplyWheelZoom(mousePosition, pendingWheelDelta);
            pendingWheelDelta = 0;
        }
        
        /// <summary>
        /// 应用滚轮缩放（核心缩放逻辑，避免重复代码）
        /// </summary>
        /// <param name="mousePosition">鼠标位置</param>
        /// <param name="wheelDelta">滚轮增量（正数放大，负数缩小）</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ApplyWheelZoom(Point mousePosition, int wheelDelta)
        {
            if (!ValidateComponents() || wheelDelta == 0)
                return;
            
            // 根据累积的滚轮增量计算缩放因子
            int steps = wheelDelta / 120;
            if (steps == 0) steps = wheelDelta > 0 ? 1 : -1;
            
            // 大图模式下使用更大的缩放步进（3倍），大幅减少渲染次数
            if (isLargeImage)
            {
                steps = steps > 0 ? Math.Max(steps, 3) : Math.Min(steps, -3);
            }
            
            // 优化：使用快速幂计算替代 Math.Pow 减少装箱
            double zoom = CalculateZoomFactor(steps);
            
            double currentScaleX = scaleTransform.ScaleX;
            double currentScaleY = scaleTransform.ScaleY;
            double newScaleX = currentScaleX * zoom;
            double newScaleY = currentScaleY * zoom;

            // 限制最大缩放
            if (newScaleX > MaxScale || newScaleY > MaxScale)
                return;
            
            // 动态计算最小缩放值
            double minScale = Math.Max(Math.Min(10.0 / cachedImageWidth, 10.0 / cachedImageHeight), 0.0001);
            
            if (newScaleX < minScale || newScaleY < minScale)
                return;
            
            // 保存当前平移值
            double oldTranslateX = translateTransform.X;
            double oldTranslateY = translateTransform.Y;
            
            // 计算鼠标对应的图像坐标（内联计算，避免方法调用开销）
            double imageX = (mousePosition.X - oldTranslateX) / currentScaleX;
            double imageY = (mousePosition.Y - oldTranslateY) / currentScaleY;
            
            // 检查图像坐标有效性
            if (double.IsNaN(imageX) || double.IsInfinity(imageX) ||
                double.IsNaN(imageY) || double.IsInfinity(imageY))
                return;
            
            // 计算新的平移值
            double newTranslateX = mousePosition.X - imageX * newScaleX;
            double newTranslateY = mousePosition.Y - imageY * newScaleY;
            
            // 检查平移值有效性
            if (double.IsNaN(newTranslateX) || double.IsInfinity(newTranslateX) ||
                double.IsNaN(newTranslateY) || double.IsInfinity(newTranslateY))
                return;
            
            // 基本的合理性检查（防止极端值）
            const double MaxReasonableTranslate = 100000;
            if (Math.Abs(newTranslateX) > MaxReasonableTranslate || Math.Abs(newTranslateY) > MaxReasonableTranslate)
                return;
            
            // 应用变换
            scaleTransform.ScaleX = newScaleX;
            scaleTransform.ScaleY = newScaleY;
            translateTransform.X = newTranslateX;
            translateTransform.Y = newTranslateY;
            
            // 失效缓存（仅标记，不立即重建）
            isTransformCacheValid = false;
            
            // 更新已绘制的ROI框和图形位置
            if (drawnRoiContainers.Count > 0 || shapeInfoList.Count > 0)
            {
                UpdateAllRoiRectanglesPosition();
            }
            
            // 选择框位置更新（使用缓存的委托，取消之前的待处理操作）
            if (SelectionRectangle != null && SelectionRectangle.Visibility == Visibility.Visible)
            {
                // 取消之前待处理的更新，避免堆积
                if (pendingSelectionUpdate != null && pendingSelectionUpdate.Status == DispatcherOperationStatus.Pending)
                {
                    pendingSelectionUpdate.Abort();
                }
                
                if (isHighPerformanceMode && cachedUpdateSelectionAction != null)
                {
                    pendingSelectionUpdate = Dispatcher.BeginInvoke(cachedUpdateSelectionAction, DispatcherPriority.Background);
                }
                else
                {
                    UpdateSelectionRectanglePosition();
                }
            }
            
            // 定期清理内存：每隔一定次数的缩放操作或时间间隔后触发
            zoomOperationCount++;
            var currentTicks2 = moveStopwatch.ElapsedTicks;
            if (zoomOperationCount >= ZoomOperationsBeforeCleanup || 
                (currentTicks2 - lastMemoryCleanupTicks) > MemoryCleanupIntervalTicks)
            {
                zoomOperationCount = 0;
                lastMemoryCleanupTicks = currentTicks2;
                // 异步清理，不阻塞UI，使用缓存的委托
                if (cachedLightweightMemoryCleanupAction != null)
                {
                    Dispatcher.BeginInvoke(cachedLightweightMemoryCleanupAction, DispatcherPriority.ApplicationIdle);
                }
            }
        }
        
        /// <summary>
        /// 轻量级内存清理（在缩放操作后异步执行）
        /// </summary>
        private void TriggerLightweightMemoryCleanup()
        {
            if (isDisposed) return;
            
            try
            {
                // 触发 Gen0 和 Gen1 回收，确保短命对象被清理
                GC.Collect(1, GCCollectionMode.Optimized, false, true);
            }
            catch
            {
                // 忽略清理过程中的异常
            }
        }
        
        /// <summary>
        /// 预计算的缩放因子表（避免重复计算 Math.Pow）
        /// </summary>
        private static readonly double[] ZoomFactorTable;
        private static readonly double[] ZoomFactorInverseTable;
        private const int ZoomTableSize = 20; // 支持 -20 到 +20 步
        
        static DisplayVision()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DisplayVision), new FrameworkPropertyMetadata(typeof(DisplayVision)));
            
            // 预计算缩放因子表
            ZoomFactorTable = new double[ZoomTableSize + 1];
            ZoomFactorInverseTable = new double[ZoomTableSize + 1];
            for (int i = 0; i <= ZoomTableSize; i++)
            {
                ZoomFactorTable[i] = Math.Pow(ZoomFactor, i);
                ZoomFactorInverseTable[i] = Math.Pow(1.0 / ZoomFactor, i);
            }
        }
        
        /// <summary>
        /// 快速计算缩放因子（使用查表法替代 Math.Pow）
        /// </summary>
        /// <param name="steps">缩放步数（正数放大，负数缩小）</param>
        /// <returns>缩放因子</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double CalculateZoomFactor(int steps)
        {
            int absSteps = Math.Abs(steps);
            if (absSteps <= ZoomTableSize)
            {
                return steps > 0 ? ZoomFactorTable[absSteps] : ZoomFactorInverseTable[absSteps];
            }
            // 超出预计算范围时回退到 Math.Pow
            return steps > 0 ? Math.Pow(ZoomFactor, steps) : Math.Pow(1.0 / ZoomFactor, -steps);
        }
        
        /// <summary>
        /// 检查点坐标是否有效
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsPointValid(Point p)
        {
            return !double.IsNaN(p.X) && !double.IsInfinity(p.X) && 
                   !double.IsNaN(p.Y) && !double.IsInfinity(p.Y);
        }
        
        /// <summary>
        /// 检查数值是否有效（非NaN且非无穷大）
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsValueValid(double value)
        {
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        private void UpdateSelectionRectanglePosition()
        {
            if (SelectionRectangle.Visibility == Visibility.Visible)
            {
                try
                {
                    double left = Canvas.GetLeft(SelectionRectangle);
                    double top = Canvas.GetTop(SelectionRectangle);
                    double width = SelectionRectangle.Width;
                    double height = SelectionRectangle.Height;
                    
                    Point rectStart = new Point(left, top);
                    Point rectEnd = new Point(left + width, top + height);
                    
                    // 转换到图像坐标再转回屏幕坐标
                    rectStart = TransformPoint(TransformPoint(rectStart, useInverse: true), useInverse: false);
                    rectEnd = TransformPoint(TransformPoint(rectEnd, useInverse: true), useInverse: false);

                    Canvas.SetLeft(SelectionRectangle, rectStart.X);
                    Canvas.SetTop(SelectionRectangle, rectStart.Y);
                    SelectionRectangle.Width = rectEnd.X - rectStart.X;
                    SelectionRectangle.Height = rectEnd.Y - rectStart.Y;
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        /// <summary>
        /// 鼠标移动 - 优化性能版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (!ValidateComponents())
                return;
            
            // 使用 Stopwatch 进行高精度节流
            var currentTicks = moveStopwatch.ElapsedTicks;
            if ((currentTicks - lastMoveTimeTicks) < MouseMoveThrottleTicks)
                return;
            lastMoveTimeTicks = currentTicks;

            Point currentPoint = e.GetPosition(ImageCanvas);

            // 处理ROI拖拽
            if (isDraggingRoi && selectedRoiIndex >= 0)
            {
                HandleRoiDrag(currentPoint);
                return;
            }

            // 处理ROI调整大小
            if (isResizingRoi && selectedRoiIndex >= 0)
            {
                HandleRoiResize(currentPoint);
                return;
            }
            
            // 处理图形拖拽
            if (isDraggingShape && selectedShapeIndex >= 0)
            {
                HandleShapeDrag(currentPoint);
                return;
            }
            
            // 处理图形调整大小
            if (isResizingShape && selectedShapeIndex >= 0)
            {
                HandleShapeResize(currentPoint);
                return;
            }

            if (isSelecting)
            {
                UpdateSelectionRectangle(currentPoint);
            }
            else if (isDrawingShape)
            {
                // 更新图形绘制预览
                UpdateDrawingPreview(currentPoint);
            }
            else if (isDragging)
            {
                double offsetX = currentPoint.X - lastMousePosition.X;
                double offsetY = currentPoint.Y - lastMousePosition.Y;
                translateTransform.X += offsetX;
                translateTransform.Y += offsetY;
                lastMousePosition = currentPoint;
                InvalidateTransformCache();
                
                // 更新已绘制的ROI框和图形位置
                if (drawnRoiContainers.Count > 0 || shapeInfoList.Count > 0)
                {
                    UpdateAllRoiRectanglesPosition();
                }
                
                if (SelectionRectangle.Visibility == Visibility.Visible)
                {
                    double left = Canvas.GetLeft(SelectionRectangle) + offsetX;
                    double top = Canvas.GetTop(SelectionRectangle) + offsetY;
                    Canvas.SetLeft(SelectionRectangle, left);
                    Canvas.SetTop(SelectionRectangle, top);
                }
            }
            else if (e.MiddleButton == MouseButtonState.Pressed ||
                     (e.LeftButton == MouseButtonState.Pressed && Keyboard.Modifiers == ModifierKeys.Control))
            {
                if (!isDragging)
                {
                    isDragging = true;
                    lastMousePosition = currentPoint;
                    ImageCanvas.CaptureMouse();
                }
                else
                {
                    double offsetX = currentPoint.X - lastMousePosition.X;
                    double offsetY = currentPoint.Y - lastMousePosition.Y;
                    translateTransform.X += offsetX;
                    translateTransform.Y += offsetY;
                    lastMousePosition = currentPoint;
                    InvalidateTransformCache();
                    
                    // 更新已绘制的ROI框和图形位置
                    if (drawnRoiContainers.Count > 0 || shapeInfoList.Count > 0)
                    {
                        UpdateAllRoiRectanglesPosition();
                    }
                }
            }
            else
            {
                if (isDragging)
                {
                    isDragging = false;
                    ImageCanvas.ReleaseMouseCapture();
                }
            }
            
            // 像素信息更新：仅在非拖拽状态或非高性能模式下执行
            if (!isDragging || !isHighPerformanceMode)
            {
                SchedulePixelInfoUpdate(currentPoint);
            }
        }

        /// <summary>
        /// 处理ROI拖拽
        /// </summary>
        private void HandleRoiDrag(Point currentPoint)
        {
            // 计算屏幕偏移
            double screenDeltaX = currentPoint.X - roiDragStartPoint.X;
            double screenDeltaY = currentPoint.Y - roiDragStartPoint.Y;

            // 将屏幕偏移转换为图像坐标偏移
            Point imageDelta = TransformVector(new Vector(screenDeltaX, screenDeltaY), useInverse: true);

            // 更新图像坐标
            var newRect = new Rect(
                roiOriginalRect.X + imageDelta.X,
                roiOriginalRect.Y + imageDelta.Y,
                roiOriginalRect.Width,
                roiOriginalRect.Height);
            roiInfoList[selectedRoiIndex].ImageRect = newRect;

            // 更新显示
            UpdateAllRoiRectanglesPosition();
        }

        /// <summary>
        /// 处理图形拖拽
        /// </summary>
        private void HandleShapeDrag(Point currentPoint)
        {
            if (selectedShapeIndex < 0 || selectedShapeIndex >= shapeInfoList.Count || originalShapeData == null)
                return;
                
            // 计算屏幕偏移
            double screenDeltaX = currentPoint.X - shapeDragStartPoint.X;
            double screenDeltaY = currentPoint.Y - shapeDragStartPoint.Y;

            // 将屏幕偏移转换为图像坐标偏移
            Point imageDelta = TransformVector(new Vector(screenDeltaX, screenDeltaY), useInverse: true);

            // 根据图形类型更新坐标
            var shape = shapeInfoList[selectedShapeIndex];
            switch (shape.ShapeType)
            {
                case ShapeType.Line:
                    var origLine = originalShapeData as LineShapeInfo;
                    var line = shape as LineShapeInfo;
                    line.StartPoint = new Point(origLine.StartPoint.X + imageDelta.X, origLine.StartPoint.Y + imageDelta.Y);
                    line.EndPoint = new Point(origLine.EndPoint.X + imageDelta.X, origLine.EndPoint.Y + imageDelta.Y);
                    break;
                    
                case ShapeType.Rectangle:
                    var origRect = originalShapeData as RectangleShapeInfo;
                    var rect = shape as RectangleShapeInfo;
                    rect.Rect = new Rect(
                        origRect.Rect.X + imageDelta.X,
                        origRect.Rect.Y + imageDelta.Y,
                        origRect.Rect.Width,
                        origRect.Rect.Height);
                    break;
                    
                case ShapeType.Circle:
                    var origCircle = originalShapeData as CircleShapeInfo;
                    var circle = shape as CircleShapeInfo;
                    circle.Center = new Point(origCircle.Center.X + imageDelta.X, origCircle.Center.Y + imageDelta.Y);
                    break;
                    
                case ShapeType.Ellipse:
                    var origEllipse = originalShapeData as EllipseShapeInfo;
                    var ellipse = shape as EllipseShapeInfo;
                    ellipse.Center = new Point(origEllipse.Center.X + imageDelta.X, origEllipse.Center.Y + imageDelta.Y);
                    break;
                    
                case ShapeType.Crosshair:
                    var origCrosshair = originalShapeData as CrosshairShapeInfo;
                    var crosshair = shape as CrosshairShapeInfo;
                    crosshair.Center = new Point(origCrosshair.Center.X + imageDelta.X, origCrosshair.Center.Y + imageDelta.Y);
                    break;
                    
                case ShapeType.Arrow:
                    var origArrow = originalShapeData as ArrowShapeInfo;
                    var arrow = shape as ArrowShapeInfo;
                    arrow.StartPoint = new Point(origArrow.StartPoint.X + imageDelta.X, origArrow.StartPoint.Y + imageDelta.Y);
                    arrow.EndPoint = new Point(origArrow.EndPoint.X + imageDelta.X, origArrow.EndPoint.Y + imageDelta.Y);
                    break;
                    
                case ShapeType.Polygon:
                    var origPolygon = originalShapeData as PolygonShapeInfo;
                    var polygon = shape as PolygonShapeInfo;
                    polygon.Points = origPolygon.Points.Select(p => new Point(p.X + imageDelta.X, p.Y + imageDelta.Y)).ToList();
                    break;
            }

            // 拖动中只更新容器位置，不重绘所有图形（避免破坏鼠标捕获）
            if (selectedShapeIndex < drawnShapeContainers.Count)
            {
                var container = drawnShapeContainers[selectedShapeIndex];
                double currentLeft = Canvas.GetLeft(container);
                double currentTop = Canvas.GetTop(container);
                Canvas.SetLeft(container, currentLeft + screenDeltaX);
                Canvas.SetTop(container, currentTop + screenDeltaY);
                
                // 更新起始点为当前点，实现增量移动
                shapeDragStartPoint = currentPoint;
                
                // 更新原始数据为当前数据，用于下一次增量计算
                originalShapeData = CloneShapeInfo(shape);
            }
        }

        /// <summary>
        /// 处理ROI调整大小
        /// </summary>
        private void HandleRoiResize(Point currentPoint)
        {
            // 计算屏幕偏移
            double screenDeltaX = currentPoint.X - roiDragStartPoint.X;
            double screenDeltaY = currentPoint.Y - roiDragStartPoint.Y;

            // 将屏幕偏移转换为图像坐标偏移
            Point imageDelta = TransformVector(new Vector(screenDeltaX, screenDeltaY), useInverse: true);

            double newLeft = roiOriginalRect.Left;
            double newTop = roiOriginalRect.Top;
            double newRight = roiOriginalRect.Right;
            double newBottom = roiOriginalRect.Bottom;

            // 根据手柄调整大小
            switch (currentResizeHandle)
            {
                case "NW":
                    newLeft += imageDelta.X;
                    newTop += imageDelta.Y;
                    break;
                case "N":
                    newTop += imageDelta.Y;
                    break;
                case "NE":
                    newRight += imageDelta.X;
                    newTop += imageDelta.Y;
                    break;
                case "W":
                    newLeft += imageDelta.X;
                    break;
                case "E":
                    newRight += imageDelta.X;
                    break;
                case "SW":
                    newLeft += imageDelta.X;
                    newBottom += imageDelta.Y;
                    break;
                case "S":
                    newBottom += imageDelta.Y;
                    break;
                case "SE":
                    newRight += imageDelta.X;
                    newBottom += imageDelta.Y;
                    break;
            }

            // 确保矩形有效（宽高为正）
            if (newRight > newLeft && newBottom > newTop)
            {
                var newRect = new Rect(newLeft, newTop, newRight - newLeft, newBottom - newTop);
                roiInfoList[selectedRoiIndex].ImageRect = newRect;
                UpdateAllRoiRectanglesPosition();
            }
        }

        /// <summary>
        /// 转换向量（用于偏移计算）
        /// </summary>
        private Point TransformVector(Vector vector, bool useInverse)
        {
            if (useInverse)
            {
                return new Point(vector.X / scaleTransform.ScaleX, vector.Y / scaleTransform.ScaleY);
            }
            else
            {
                return new Point(vector.X * scaleTransform.ScaleX, vector.Y * scaleTransform.ScaleY);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void UpdateSelectionRectangle(Point currentPoint)
        {
            double x = Math.Min(startPoint.X, currentPoint.X);
            double y = Math.Min(startPoint.Y, currentPoint.Y);
            double width = Math.Abs(currentPoint.X - startPoint.X);
            double height = Math.Abs(currentPoint.Y - startPoint.Y);
            Canvas.SetLeft(SelectionRectangle, x);
            Canvas.SetTop(SelectionRectangle, y);
            SelectionRectangle.Width = width;
            SelectionRectangle.Height = height;
        }

        /// <summary>
        /// 更新图形绘制预览
        /// </summary>
        private void UpdateDrawingPreview(Point currentPoint)
        {
            if (currentDrawingElement == null)
                return;
            
            switch (CurrentDrawingMode)
            {
                case DrawingMode.Line:
                case DrawingMode.Arrow:
                    // 更新直线/箭头预览
                    if (currentDrawingElement is Line line)
                    {
                        line.X2 = currentPoint.X;
                        line.Y2 = currentPoint.Y;
                    }
                    break;
                    
                case DrawingMode.Circle:
                    // 更新圆形预览（以起点为圆心，取较大的半径）
                    if (currentDrawingElement is Ellipse circleEllipse)
                    {
                        double radiusX = Math.Abs(currentPoint.X - startPoint.X);
                        double radiusY = Math.Abs(currentPoint.Y - startPoint.Y);
                        double radius = Math.Max(radiusX, radiusY);
                        
                        Canvas.SetLeft(circleEllipse, startPoint.X - radius);
                        Canvas.SetTop(circleEllipse, startPoint.Y - radius);
                        circleEllipse.Width = radius * 2;
                        circleEllipse.Height = radius * 2;
                    }
                    break;
                    
                case DrawingMode.Ellipse:
                    // 更新椭圆预览（以起点为圆心）
                    if (currentDrawingElement is Ellipse ellipse)
                    {
                        double rx = Math.Abs(currentPoint.X - startPoint.X);
                        double ry = Math.Abs(currentPoint.Y - startPoint.Y);
                        
                        Canvas.SetLeft(ellipse, startPoint.X - rx);
                        Canvas.SetTop(ellipse, startPoint.Y - ry);
                        ellipse.Width = rx * 2;
                        ellipse.Height = ry * 2;
                    }
                    break;
            }
        }

        private void SchedulePixelInfoUpdate(Point mousePosition)
        {
            // 快速检查位置是否变化（使用平方比较避免开方运算）
            double dx = mousePosition.X - lastPixelInfoPosition.X;
            double dy = mousePosition.Y - lastPixelInfoPosition.Y;
            if (dx * dx + dy * dy < 1)
                return;
            
            lastPixelInfoPosition = mousePosition;
            
            // 取消之前的待处理更新
            if (pendingPixelInfoUpdate != null && pendingPixelInfoUpdate.Status == DispatcherOperationStatus.Pending)
            {
                pendingPixelInfoUpdate.Abort();
            }
            
            // 异步更新像素信息，使用缓存的委托
            if (cachedUpdatePixelInfoAction != null)
            {
                pendingPixelInfoUpdate = Dispatcher.BeginInvoke(cachedUpdatePixelInfoAction, DispatcherPriority.Input);
            }
        }

        private void UpdatePixelInfoAtCurrentPosition()
        {
            if (!ValidateComponents() || cachedBitmapSource == null || pixelBuffer == null)
                return;

            Point mousePosition = lastPixelInfoPosition;
            try
            {
                // 直接计算图像坐标，避免调用 TransformPoint 方法
                double scaleX = scaleTransform.ScaleX;
                double scaleY = scaleTransform.ScaleY;
                if (scaleX == 0 || scaleY == 0) return;
                
                int pixelx = (int)((mousePosition.X - translateTransform.X) / scaleX);
                int pixely = (int)((mousePosition.Y - translateTransform.Y) / scaleY);

                if (pixelx >= 0 && pixelx < cachedImageWidth &&
                    pixely >= 0 && pixely < cachedImageHeight)
                {
                    cachedBitmapSource.CopyPixels(new Int32Rect(pixelx, pixely, 1, 1), pixelBuffer, 4, 0);
                    byte blue = pixelBuffer[0];
                    byte green = pixelBuffer[1];
                    byte red = pixelBuffer[2];
                    byte alpha = pixelBuffer[3];
                    
                    // 重用 PixelInfo 对象避免 GC 压力
                    reusablePixelInfo.X = pixelx;
                    reusablePixelInfo.Y = pixely;
                    reusablePixelInfo.R = red;
                    reusablePixelInfo.G = green;
                    reusablePixelInfo.B = blue;
                    reusablePixelInfo.A = alpha;
                    // 使用整数运算优化灰度计算
                    reusablePixelInfo.Gray = (77 * red + 150 * green + 29 * blue) >> 8;

                    // 使用 StringBuilder 减少字符串分配
                    coordStringBuilder.Clear();
                    coordStringBuilder.Append("X: ").Append(pixelx).Append(", Y: ").Append(pixely);
                    BottomRightText = coordStringBuilder.ToString();

                    RaiseMovePixelInfoEvent(reusablePixelInfo);
                }
                else
                {
                    // 当鼠标移出图像范围时，清空坐标显示
                    BottomRightText = string.Empty;
                }
            }
            catch (InvalidOperationException)
            {
                // 发生异常时也清空坐标显示
                BottomRightText = string.Empty;
            }
        }


        /// <summary>
        /// 左键松开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLUp(object sender, MouseButtonEventArgs e)
        {
            if (!ValidateComponents())
                return;

            // 处理ROI拖拽结束
            if (isDraggingRoi)
            {
                isDraggingRoi = false;
                if (selectedRoiIndex >= 0 && selectedRoiIndex < drawnRoiContainers.Count)
                {
                    drawnRoiContainers[selectedRoiIndex].ReleaseMouseCapture();
                }
                return;
            }

            // 处理ROI调整大小结束
            if (isResizingRoi)
            {
                isResizingRoi = false;
                currentResizeHandle = null;
                if (selectedRoiIndex >= 0 && selectedRoiIndex < drawnRoiContainers.Count)
                {
                    drawnRoiContainers[selectedRoiIndex].ReleaseMouseCapture();
                }
                return;
            }
            
            // 处理图形拖拽结束
            if (isDraggingShape)
            {
                // 保存当前选中的索引和图形信息
                int draggedIndex = selectedShapeIndex;
                ShapeInfo draggedShape = draggedIndex >= 0 && draggedIndex < shapeInfoList.Count 
                    ? shapeInfoList[draggedIndex] : null;
                
                isDraggingShape = false;
                originalShapeData = null;
                if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
                {
                    drawnShapeContainers[selectedShapeIndex].ReleaseMouseCapture();
                }
                
                // 重绘所有图形以确保显示正确
                RedrawAllShapes();
                
                // 重新选中之前拖动的图形
                if (draggedIndex >= 0 && draggedIndex < drawnShapeContainers.Count)
                {
                    SelectShape(draggedIndex);
                }
                
                // 触发修改事件
                if (draggedShape != null)
                {
                    OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Modified, draggedShape);
                }
                return;
            }
            
            // 处理图形调整大小结束
            if (isResizingShape)
            {
                int resizedIndex = selectedShapeIndex;
                ShapeInfo resizedShape = resizedIndex >= 0 && resizedIndex < shapeInfoList.Count 
                    ? shapeInfoList[resizedIndex] : null;
                
                isResizingShape = false;
                currentShapeResizeHandle = null;
                originalShapeData = null;
                if (selectedShapeIndex >= 0 && selectedShapeIndex < drawnShapeContainers.Count)
                {
                    drawnShapeContainers[selectedShapeIndex].ReleaseMouseCapture();
                }
                
                // 重绘所有图形
                RedrawAllShapes();
                
                // 重新选中
                if (resizedIndex >= 0 && resizedIndex < drawnShapeContainers.Count)
                {
                    SelectShape(resizedIndex);
                }
                
                // 触发修改事件
                if (resizedShape != null)
                {
                    OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Modified, resizedShape);
                }
                return;
            }

            // 处理图形绘制完成
            if (isDrawingShape)
            {
                FinishShapeDrawing(e);
                return;
            }

            if (!isSelecting)
                return;

            isSelecting = false;
            ImageCanvas.ReleaseMouseCapture();

            if (SelectionRectangle.Width > 0 && SelectionRectangle.Height > 0)
            {
                // 创建一个新的矩形来保存当前绘制的ROI框
                CreatePersistentRoiRectangle();
                
                // 处理选区（触发事件等）
                ProcessSelectionArea();
            }

            // 隐藏当前选择框，准备下一次绘制
            if (SelectionRectangle != null)
            {
                SelectionRectangle.Visibility = Visibility.Collapsed;
            }

            // 如果IsRoiMode为false，自动禁用ROI选取模式
            if (!IsRoiMode)
            {
                DisableRoiSelection();
            }
            // 在IsRoiMode模式下，保持十字光标，允许继续绘制下一个ROI
        }

        /// <summary>
        /// 完成图形绘制
        /// </summary>
        private void FinishShapeDrawing(MouseButtonEventArgs e)
        {
            isDrawingShape = false;
            ImageCanvas.ReleaseMouseCapture();
            
            Point screenPoint = e.GetPosition(ImageCanvas);
            Point imageEndPoint = TransformPoint(screenPoint, useInverse: true);
            
            // 移除预览元素
            if (currentDrawingElement != null)
            {
                ImageCanvas.Children.Remove(currentDrawingElement);
                currentDrawingElement = null;
            }
            
            switch (CurrentDrawingMode)
            {
                case DrawingMode.Rectangle:
                    FinishRectangleDrawing(imageEndPoint);
                    break;
                    
                case DrawingMode.Line:
                    FinishLineDrawing(imageEndPoint);
                    break;
                    
                case DrawingMode.Arrow:
                    FinishArrowDrawing(imageEndPoint);
                    break;
                    
                case DrawingMode.Circle:
                    FinishCircleDrawing(imageEndPoint);
                    break;
                    
                case DrawingMode.Ellipse:
                    FinishEllipseDrawing(imageEndPoint);
                    break;
                    
                case DrawingMode.Polygon:
                    // 多边形在双击时完成，这里不处理
                    break;
            }
            
            // 隐藏选择框
            if (SelectionRectangle != null)
            {
                SelectionRectangle.Visibility = Visibility.Collapsed;
            }
            isSelecting = false;
            
            // 绘制完成后自动切换到选择模式
            CurrentDrawingMode = DrawingMode.None;
        }

        /// <summary>
        /// 完成矩形绘制
        /// </summary>
        private void FinishRectangleDrawing(Point imageEndPoint)
        {
            // 检查是否有有效大小
            double width = Math.Abs(imageEndPoint.X - shapeDrawStartPoint.X);
            double height = Math.Abs(imageEndPoint.Y - shapeDrawStartPoint.Y);
            
            if (width < 5 || height < 5)
                return;
            
            // 计算矩形区域
            double left = Math.Min(shapeDrawStartPoint.X, imageEndPoint.X);
            double top = Math.Min(shapeDrawStartPoint.Y, imageEndPoint.Y);
            Rect rect = new Rect(left, top, width, height);
            
            // 统一使用 Shape 系统创建矩形，所有矩形都作为 ROI 处理
            var shape = new RectangleShapeInfo
            {
                Rect = rect,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                FillColor = DrawingFillColor
            };
            
            AddShapeToCollection(shape);
            DebugLog($"完成矩形绘制: ({rect.X:F1}, {rect.Y:F1}, {rect.Width:F1}, {rect.Height:F1})");
        }

        /// <summary>
        /// 完成直线绘制
        /// </summary>
        private void FinishLineDrawing(Point imageEndPoint)
        {
            // 检查是否有有效长度
            double length = Math.Sqrt(Math.Pow(imageEndPoint.X - shapeDrawStartPoint.X, 2) + 
                                     Math.Pow(imageEndPoint.Y - shapeDrawStartPoint.Y, 2));
            if (length < 5)
                return;
            
            var shape = new LineShapeInfo
            {
                StartPoint = shapeDrawStartPoint,
                EndPoint = imageEndPoint,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness
            };
            
            AddShapeToCollection(shape);
            DebugLog($"完成直线绘制: ({shapeDrawStartPoint.X:F1}, {shapeDrawStartPoint.Y:F1}) -> ({imageEndPoint.X:F1}, {imageEndPoint.Y:F1})");
        }

        /// <summary>
        /// 完成箭头绘制
        /// </summary>
        private void FinishArrowDrawing(Point imageEndPoint)
        {
            // 检查是否有有效长度
            double length = Math.Sqrt(Math.Pow(imageEndPoint.X - shapeDrawStartPoint.X, 2) + 
                                     Math.Pow(imageEndPoint.Y - shapeDrawStartPoint.Y, 2));
            if (length < 5)
                return;
            
            var shape = new ArrowShapeInfo
            {
                StartPoint = shapeDrawStartPoint,
                EndPoint = imageEndPoint,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                ArrowSize = 10
            };
            
            AddShapeToCollection(shape);
            DebugLog($"完成箭头绘制: ({shapeDrawStartPoint.X:F1}, {shapeDrawStartPoint.Y:F1}) -> ({imageEndPoint.X:F1}, {imageEndPoint.Y:F1})");
        }

        /// <summary>
        /// 完成圆形绘制
        /// </summary>
        private void FinishCircleDrawing(Point imageEndPoint)
        {
            // 计算半径（取X和Y方向的平均值）
            double radiusX = Math.Abs(imageEndPoint.X - shapeDrawStartPoint.X);
            double radiusY = Math.Abs(imageEndPoint.Y - shapeDrawStartPoint.Y);
            double radius = Math.Max(radiusX, radiusY); // 圆形取较大值
            
            if (radius < 5)
                return;
            
            var shape = new CircleShapeInfo
            {
                Center = shapeDrawStartPoint,
                Radius = radius,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                FillColor = DrawingFillColor
            };
            
            AddShapeToCollection(shape);
            DebugLog($"完成圆形绘制: 中心({shapeDrawStartPoint.X:F1}, {shapeDrawStartPoint.Y:F1}), 半径{radius:F1}");
        }

        /// <summary>
        /// 完成椭圆绘制
        /// </summary>
        private void FinishEllipseDrawing(Point imageEndPoint)
        {
            double radiusX = Math.Abs(imageEndPoint.X - shapeDrawStartPoint.X);
            double radiusY = Math.Abs(imageEndPoint.Y - shapeDrawStartPoint.Y);
            
            if (radiusX < 5 || radiusY < 5)
                return;
            
            var shape = new EllipseShapeInfo
            {
                Center = shapeDrawStartPoint,
                RadiusX = radiusX,
                RadiusY = radiusY,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                FillColor = DrawingFillColor
            };
            
            AddShapeToCollection(shape);
            System.Diagnostics.Debug.WriteLine($"完成椭圆绘制: 中心({shapeDrawStartPoint.X:F1}, {shapeDrawStartPoint.Y:F1}), 半径X={radiusX:F1}, 半径Y={radiusY:F1}");
        }

        #region ROI管理

        /// <summary>
        /// 创建一个持久化的ROI矩形（保持显示）
        /// </summary>
        private void CreatePersistentRoiRectangle()
        {
            if (SelectionRectangle == null || ImageCanvas == null)
                return;

            // 获取当前选择框的屏幕坐标
            double screenLeft = Canvas.GetLeft(SelectionRectangle);
            double screenTop = Canvas.GetTop(SelectionRectangle);
            double screenWidth = SelectionRectangle.Width;
            double screenHeight = SelectionRectangle.Height;

            // 转换为图像坐标
            Point screenStart = new Point(screenLeft, screenTop);
            Point screenEnd = new Point(screenLeft + screenWidth, screenTop + screenHeight);
            Point imageStart = TransformPoint(screenStart, useInverse: true);
            Point imageEnd = TransformPoint(screenEnd, useInverse: true);

            // 创建ROI信息
            Rect imageRect = new Rect(imageStart, imageEnd);
            int newIndex = roiInfoList.Count + 1;
            var roiInfo = new RoiInfo
            {
                Index = newIndex,
                ImageRect = imageRect,
                IsSelected = false,
                Name = $"ROI_{newIndex}"  // 自动设置ROI名称
            };
            roiInfoList.Add(roiInfo);

            // 创建ROI显示容器
            var container = CreateRoiContainer(roiInfo, screenLeft, screenTop, screenWidth, screenHeight);
            
            // 添加到画布
            ImageCanvas.Children.Add(container);
            drawnRoiContainers.Add(container);

            // 触发ROI添加事件
            OnRoiChanged(RoiChangedEventArgs.ChangeType.Added, roiInfo);
            
            // 刷新命令状态，使应用ROI和清除ROI按钮可用
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 创建ROI显示容器（包含矩形、标签和调整手柄）
        /// </summary>
        private Grid CreateRoiContainer(RoiInfo roiInfo, double left, double top, double width, double height)
        {
            var container = new Grid
            {
                Width = width,
                Height = height,
                Tag = roiInfo.Index - 1 // 保存索引用于识别
            };

            // 创建ROI矩形
            var rect = new Rectangle
            {
                Stroke = Brushes.Lime,
                StrokeThickness = 2,
                Fill = new SolidColorBrush(Color.FromArgb(50, 0, 255, 0)),
                Cursor = Cursors.SizeAll
            };

            // 添加鼠标事件
            rect.MouseLeftButtonDown += Roi_MouseLeftButtonDown;
            rect.MouseRightButtonDown += Roi_MouseRightButtonDown;
            
            container.Children.Add(rect);

            // 创建名称标签（始终显示）
            var nameLabel = new Border
            {
                Background = Brushes.Lime,
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(4, 2, 4, 2),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Margin = new Thickness(2, 2, 0, 0),
                Tag = "NameLabel",
                Child = new TextBlock
                {
                    Text = roiInfo.Name ?? $"ROI_{roiInfo.Index}",
                    Foreground = Brushes.Black,
                    FontSize = 11,
                    FontWeight = FontWeights.Bold,
                    Tag = "NameText"
                }
            };
            container.Children.Add(nameLabel);

            // 创建名称编辑框（默认隐藏，选中时显示）
            var nameEditBorder = new Border
            {
                Background = new SolidColorBrush(Color.FromArgb(220, 50, 50, 50)),
                CornerRadius = new CornerRadius(3),
                Padding = new Thickness(2),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(2, 0, 0, 2),
                Visibility = Visibility.Collapsed,
                Tag = "NameEdit"
            };
            
            var nameTextBox = new TextBox
            {
                Text = roiInfo.Name ?? $"ROI_{roiInfo.Index}",
                Foreground = Brushes.White,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0),
                FontSize = 11,
                MinWidth = 60,
                MaxWidth = 150,
                Padding = new Thickness(2),
                Tag = "NameTextBox"
            };
            nameTextBox.LostFocus += RoiNameTextBox_LostFocus;
            nameTextBox.KeyDown += RoiNameTextBox_KeyDown;
            nameEditBorder.Child = nameTextBox;
            container.Children.Add(nameEditBorder);

            // 创建调整大小的手柄（8个方向）
            CreateResizeHandles(container);

            // 设置位置
            Canvas.SetLeft(container, left);
            Canvas.SetTop(container, top);

            return container;
        }

        /// <summary>
        /// 创建调整大小的手柄
        /// </summary>
        private void CreateResizeHandles(Grid container)
        {
            string[] handles = { "NW", "N", "NE", "W", "E", "SW", "S", "SE" };
            
            foreach (var handle in handles)
            {
                var thumb = new Rectangle
                {
                    Width = 8,
                    Height = 8,
                    Fill = Brushes.White,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Tag = handle,
                    Visibility = Visibility.Collapsed // 默认隐藏，选中时显示
                };

                // 设置位置和光标
                switch (handle)
                {
                    case "NW":
                        thumb.HorizontalAlignment = HorizontalAlignment.Left;
                        thumb.VerticalAlignment = VerticalAlignment.Top;
                        thumb.Cursor = Cursors.SizeNWSE;
                        thumb.Margin = new Thickness(-4, -4, 0, 0);
                        break;
                    case "N":
                        thumb.HorizontalAlignment = HorizontalAlignment.Center;
                        thumb.VerticalAlignment = VerticalAlignment.Top;
                        thumb.Cursor = Cursors.SizeNS;
                        thumb.Margin = new Thickness(0, -4, 0, 0);
                        break;
                    case "NE":
                        thumb.HorizontalAlignment = HorizontalAlignment.Right;
                        thumb.VerticalAlignment = VerticalAlignment.Top;
                        thumb.Cursor = Cursors.SizeNESW;
                        thumb.Margin = new Thickness(0, -4, -4, 0);
                        break;
                    case "W":
                        thumb.HorizontalAlignment = HorizontalAlignment.Left;
                        thumb.VerticalAlignment = VerticalAlignment.Center;
                        thumb.Cursor = Cursors.SizeWE;
                        thumb.Margin = new Thickness(-4, 0, 0, 0);
                        break;
                    case "E":
                        thumb.HorizontalAlignment = HorizontalAlignment.Right;
                        thumb.VerticalAlignment = VerticalAlignment.Center;
                        thumb.Cursor = Cursors.SizeWE;
                        thumb.Margin = new Thickness(0, 0, -4, 0);
                        break;
                    case "SW":
                        thumb.HorizontalAlignment = HorizontalAlignment.Left;
                        thumb.VerticalAlignment = VerticalAlignment.Bottom;
                        thumb.Cursor = Cursors.SizeNESW;
                        thumb.Margin = new Thickness(-4, 0, 0, -4);
                        break;
                    case "S":
                        thumb.HorizontalAlignment = HorizontalAlignment.Center;
                        thumb.VerticalAlignment = VerticalAlignment.Bottom;
                        thumb.Cursor = Cursors.SizeNS;
                        thumb.Margin = new Thickness(0, 0, 0, -4);
                        break;
                    case "SE":
                        thumb.HorizontalAlignment = HorizontalAlignment.Right;
                        thumb.VerticalAlignment = VerticalAlignment.Bottom;
                        thumb.Cursor = Cursors.SizeNWSE;
                        thumb.Margin = new Thickness(0, 0, -4, -4);
                        break;
                }

                thumb.MouseLeftButtonDown += ResizeHandle_MouseLeftButtonDown;
                container.Children.Add(thumb);
            }
        }

        /// <summary>
        /// ROI矩形左键按下事件
        /// </summary>
        private void Roi_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 只有在ROI模式启用时才允许操作
            if (!isRoiSelectionEnabled) return;
            
            if (sender is Rectangle rect && rect.Parent is Grid container)
            {
                int index = (int)container.Tag;
                SelectedRoiIndex = index;

                // 开始拖拽ROI
                isDraggingRoi = true;
                roiDragStartPoint = e.GetPosition(ImageCanvas);
                roiOriginalRect = roiInfoList[index].ImageRect;
                container.CaptureMouse();
                e.Handled = true;
            }
        }

        /// <summary>
        /// ROI名称文本框失去焦点事件
        /// </summary>
        private void RoiNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Parent is Border border && border.Parent is Grid container)
            {
                int index = (int)container.Tag;
                if (index >= 0 && index < roiInfoList.Count)
                {
                    roiInfoList[index].Name = textBox.Text;
                    
                    // 同步更新名称标签显示
                    UpdateRoiNameLabel(container, textBox.Text);
                    
                    System.Diagnostics.Debug.WriteLine($"ROI {index + 1} 名称已更新为: {textBox.Text}");
                }
            }
        }

        /// <summary>
        /// 更新ROI名称标签显示
        /// </summary>
        private void UpdateRoiNameLabel(Grid container, string name)
        {
            foreach (var child in container.Children)
            {
                if (child is Border border && border.Tag is string tag && tag == "NameLabel")
                {
                    if (border.Child is TextBlock textBlock)
                    {
                        textBlock.Text = name;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// ROI名称文本框按键事件
        /// </summary>
        private void RoiNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // 按回车确认修改，移除焦点
                if (sender is TextBox textBox)
                {
                    // 触发 LostFocus 事件来保存
                    Keyboard.ClearFocus();
                    e.Handled = true;
                }
            }
            else if (e.Key == Key.Escape)
            {
                // 按ESC取消修改，恢复原名称
                if (sender is TextBox textBox && textBox.Parent is Border border && border.Parent is Grid container)
                {
                    int index = (int)container.Tag;
                    if (index >= 0 && index < roiInfoList.Count)
                    {
                        textBox.Text = roiInfoList[index].Name;
                    }
                    Keyboard.ClearFocus();
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// ROI矩形右键按下事件（显示上下文菜单）
        /// </summary>
        private void Roi_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 只有在ROI模式启用时才允许操作
            if (!isRoiSelectionEnabled) return;
            
            if (sender is Rectangle rect && rect.Parent is Grid container)
            {
                int index = (int)container.Tag;
                SelectedRoiIndex = index;

                // 创建右键菜单
                var contextMenu = new ContextMenu();
                
                var deleteItem = new MenuItem { Header = $"删除 ROI {roiInfoList[index].Index}" };
                deleteItem.Click += (s, args) => DeleteRoiAt(index);
                contextMenu.Items.Add(deleteItem);

                var clearAllItem = new MenuItem { Header = "清除所有ROI" };
                clearAllItem.Click += (s, args) => ClearAllRoiRectangles();
                contextMenu.Items.Add(clearAllItem);

                contextMenu.IsOpen = true;
                e.Handled = true;
            }
        }

        /// <summary>
        /// 调整手柄左键按下事件
        /// </summary>
        private void ResizeHandle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // 只有在ROI模式启用时才允许操作
            if (!isRoiSelectionEnabled) return;
            
            if (sender is Rectangle handle && handle.Parent is Grid container)
            {
                int index = (int)container.Tag;
                SelectedRoiIndex = index;

                isResizingRoi = true;
                currentResizeHandle = handle.Tag as string;
                roiDragStartPoint = e.GetPosition(ImageCanvas);
                roiOriginalRect = roiInfoList[index].ImageRect;
                container.CaptureMouse();
                e.Handled = true;
            }
        }

        /// <summary>
        /// 更新ROI外观（选中/未选中）
        /// </summary>
        private void UpdateRoiAppearance(int index, bool isSelected)
        {
            if (index < 0 || index >= drawnRoiContainers.Count)
                return;

            var container = drawnRoiContainers[index];
            
            // 更新矩形样式
            var rect = container.Children.OfType<Rectangle>().FirstOrDefault(r => r.Tag == null || !(r.Tag is string));
            if (rect != null)
            {
                rect.Stroke = isSelected ? Brushes.Yellow : Brushes.Lime;
                rect.StrokeThickness = isSelected ? 3 : 2;
                rect.Fill = new SolidColorBrush(isSelected ? Color.FromArgb(80, 255, 255, 0) : Color.FromArgb(50, 0, 255, 0));
            }

            // 显示/隐藏调整手柄和名称编辑框，更新标签样式
            foreach (var child in container.Children)
            {
                if (child is Rectangle handle && handle.Tag is string handleTag)
                {
                    handle.Visibility = isSelected ? Visibility.Visible : Visibility.Collapsed;
                }
                else if (child is Border border && border.Tag is string borderTag)
                {
                    if (borderTag == "NameLabel")
                    {
                        // 名称标签：更新背景颜色
                        border.Background = isSelected ? Brushes.Yellow : Brushes.Lime;
                    }
                    else if (borderTag == "NameEdit")
                    {
                        // 名称编辑框：选中时显示
                        border.Visibility = isSelected ? Visibility.Visible : Visibility.Collapsed;
                        
                        // 更新文本框中的名称
                        if (isSelected && border.Child is TextBox textBox && index < roiInfoList.Count)
                        {
                            textBox.Text = roiInfoList[index].Name ?? $"ROI_{index + 1}";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 更新所有已绘制ROI框的位置（根据当前变换重新计算）
        /// </summary>
        private void UpdateAllRoiRectanglesPosition()
        {
            // 更新 ROI 位置
            if (drawnRoiContainers.Count == roiInfoList.Count && drawnRoiContainers.Count > 0)
            {
                for (int i = 0; i < drawnRoiContainers.Count; i++)
                {
                    var container = drawnRoiContainers[i];
                    var imageRect = roiInfoList[i].ImageRect;

                    // 将图像坐标转换为屏幕坐标
                    Point screenStart = TransformPoint(imageRect.TopLeft, useInverse: false);
                    Point screenEnd = TransformPoint(imageRect.BottomRight, useInverse: false);

                    double width = Math.Abs(screenEnd.X - screenStart.X);
                    double height = Math.Abs(screenEnd.Y - screenStart.Y);

                    // 更新容器位置和大小
                    Canvas.SetLeft(container, Math.Min(screenStart.X, screenEnd.X));
                    Canvas.SetTop(container, Math.Min(screenStart.Y, screenEnd.Y));
                    container.Width = width;
                    container.Height = height;
                }
            }
            
            // 同时更新图形位置（无论是否有 ROI 都需要更新）
            UpdateAllShapesPosition();
        }

        /// <summary>
        /// 清除所有已绘制的ROI框和形状
        /// </summary>
        public void ClearAllRoiRectangles()
        {
            if (ImageCanvas == null)
                return;

            // 清除所有 ROI
            foreach (var container in drawnRoiContainers)
            {
                // 取消订阅事件，防止内存泄漏
                UnsubscribeRoiContainerEvents(container);
                ImageCanvas.Children.Remove(container);
            }
            drawnRoiContainers.Clear();
            roiInfoList.Clear();
            selectedRoiIndex = -1;

            // 同时清除所有形状
            ClearAllShapes();

            // 触发ROI清除事件
            OnRoiChanged(RoiChangedEventArgs.ChangeType.Cleared);
            
            // 刷新命令状态
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 取消ROI容器的所有事件订阅
        /// </summary>
        private void UnsubscribeRoiContainerEvents(Grid container)
        {
            if (container == null) return;
            
            foreach (var child in container.Children)
            {
                if (child is Rectangle rect)
                {
                    // 检查是否是ROI主矩形还是调整手柄
                    if (rect.Tag is string) // 调整手柄
                    {
                        rect.MouseLeftButtonDown -= ResizeHandle_MouseLeftButtonDown;
                    }
                    else // ROI主矩形
                    {
                        rect.MouseLeftButtonDown -= Roi_MouseLeftButtonDown;
                        rect.MouseRightButtonDown -= Roi_MouseRightButtonDown;
                    }
                }
                else if (child is Border border && border.Tag is string borderTag && borderTag == "NameEdit")
                {
                    // 取消订阅名称文本框的事件
                    if (border.Child is TextBox textBox)
                    {
                        textBox.LostFocus -= RoiNameTextBox_LostFocus;
                        textBox.KeyDown -= RoiNameTextBox_KeyDown;
                    }
                }
            }
            
            // 释放鼠标捕获
            container.ReleaseMouseCapture();
        }

        /// <summary>
        /// 删除指定索引的ROI框
        /// </summary>
        public void DeleteRoiAt(int index)
        {
            if (index < 0 || index >= drawnRoiContainers.Count || ImageCanvas == null)
                return;

            // 获取被删除的ROI信息
            var deletedRoi = roiInfoList[index].Clone();

            // 取消订阅事件，防止内存泄漏
            UnsubscribeRoiContainerEvents(drawnRoiContainers[index]);
            
            // 移除容器
            ImageCanvas.Children.Remove(drawnRoiContainers[index]);
            drawnRoiContainers.RemoveAt(index);
            roiInfoList.RemoveAt(index);

            // 更新剩余ROI的索引
            for (int i = 0; i < roiInfoList.Count; i++)
            {
                roiInfoList[i].Index = i + 1;
                drawnRoiContainers[i].Tag = i;
                
                // 更新标签文本
                var label = drawnRoiContainers[i].Children.OfType<Border>().FirstOrDefault();
                if (label?.Child is TextBlock textBlock)
                {
                    textBlock.Text = (i + 1).ToString();
                }
            }

            // 清除选中状态
            if (selectedRoiIndex >= roiInfoList.Count)
            {
                selectedRoiIndex = roiInfoList.Count - 1;
            }
            if (selectedRoiIndex >= 0)
            {
                UpdateRoiAppearance(selectedRoiIndex, true);
            }

            // 触发ROI删除事件
            OnRoiChanged(RoiChangedEventArgs.ChangeType.Removed, deletedRoi);
        }

        /// <summary>
        /// 删除选中的ROI
        /// </summary>
        public void DeleteSelectedRoi()
        {
            if (selectedRoiIndex >= 0)
            {
                DeleteRoiAt(selectedRoiIndex);
            }
        }

        /// <summary>
        /// 清除最后一个绘制的ROI框
        /// </summary>
        public void ClearLastRoiRectangle()
        {
            if (roiInfoList.Count > 0)
            {
                DeleteRoiAt(roiInfoList.Count - 1);
            }
        }

        /// <summary>
        /// 获取当前已绘制的ROI框数量
        /// </summary>
        public int DrawnRoiCount => roiInfoList.Count;

        #endregion

        /// <summary>
        /// 处理选区 - 绘制完单个ROI后的处理（不再自动触发事件，需点击保存按钮）
        /// </summary>
        private void ProcessSelectionArea()
        {
            // 仅用于调试输出，实际的ROI已经在CreatePersistentRoiRectangle中创建
            Point rectStart = new Point(Canvas.GetLeft(SelectionRectangle), Canvas.GetTop(SelectionRectangle));
            Point rectEnd = rectStart + new Vector(SelectionRectangle.Width, SelectionRectangle.Height);
            rectStart = TransformPoint(rectStart, useInverse: true);
            rectEnd = TransformPoint(rectEnd, useInverse: true);
            int cropX = (int)Math.Round(rectStart.X);
            int cropY = (int)Math.Round(rectStart.Y);
            int cropWidth = (int)Math.Round(rectEnd.X - rectStart.X);
            int cropHeight = (int)Math.Round(rectEnd.Y - rectStart.Y);
            
            System.Diagnostics.Debug.WriteLine($"ROI绘制完成: X={cropX}, Y={cropY}, W={cropWidth}, H={cropHeight}");
            // 注意：InterceptROI事件现在只在点击保存按钮（ApplyRoiCommand）时触发
        }

        /// <summary>
        /// 左键按下 - 只有在ROI选取模式启用时才开始选取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseLDown(object sender, MouseButtonEventArgs e)
        {
            if (!ValidateComponents())
                return;

            // 如果没有绘制模式，不处理（让事件冒泡到图形容器）
            if (CurrentDrawingMode == DrawingMode.None)
            {
                return;
            }

            Point screenPoint = e.GetPosition(ImageCanvas);
            Point imagePoint = TransformPoint(screenPoint, useInverse: true);
            
            switch (CurrentDrawingMode)
            {
                case DrawingMode.Rectangle:
                    // 矩形绘制（原ROI功能）
                    StartRectangleDrawing(screenPoint);
                    break;
                    
                case DrawingMode.Line:
                case DrawingMode.Arrow:
                    // 直线/箭头绘制
                    StartLineDrawing(screenPoint, imagePoint);
                    break;
                    
                case DrawingMode.Circle:
                case DrawingMode.Ellipse:
                    // 圆形/椭圆绘制
                    StartCircleDrawing(screenPoint, imagePoint);
                    break;
                    
                case DrawingMode.Crosshair:
                    // 十字准星 - 单击直接放置
                    PlaceCrosshair(imagePoint);
                    break;
                    
                case DrawingMode.Polygon:
                    // 多边形 - 添加顶点
                    AddPolygonPoint(screenPoint, imagePoint, e);
                    break;
            }
        }

        /// <summary>
        /// 开始矩形绘制
        /// </summary>
        private void StartRectangleDrawing(Point screenPoint)
        {
            startPoint = screenPoint;
            shapeDrawStartPoint = TransformPoint(screenPoint, useInverse: true);
            isSelecting = true;
            isDrawingShape = true;
            SelectionRectangle.Visibility = Visibility.Visible;
            Canvas.SetLeft(SelectionRectangle, startPoint.X);
            Canvas.SetTop(SelectionRectangle, startPoint.Y);
            SelectionRectangle.Width = 0;
            SelectionRectangle.Height = 0;
            ImageCanvas.CaptureMouse();
        }

        /// <summary>
        /// 开始直线/箭头绘制
        /// </summary>
        private void StartLineDrawing(Point screenPoint, Point imagePoint)
        {
            startPoint = screenPoint;
            shapeDrawStartPoint = imagePoint;
            isDrawingShape = true;
            
            // 创建预览线条
            var previewLine = new Line
            {
                X1 = screenPoint.X,
                Y1 = screenPoint.Y,
                X2 = screenPoint.X,
                Y2 = screenPoint.Y,
                Stroke = new SolidColorBrush(DrawingStrokeColor),
                StrokeThickness = DrawingStrokeThickness,
                StrokeDashArray = new DoubleCollection { 4, 2 } // 虚线预览
            };
            
            currentDrawingElement = previewLine;
            ImageCanvas.Children.Add(previewLine);
            ImageCanvas.CaptureMouse();
        }

        /// <summary>
        /// 开始圆形/椭圆绘制
        /// </summary>
        private void StartCircleDrawing(Point screenPoint, Point imagePoint)
        {
            startPoint = screenPoint;
            shapeDrawStartPoint = imagePoint;
            isDrawingShape = true;
            
            // 创建预览椭圆
            var previewEllipse = new Ellipse
            {
                Stroke = new SolidColorBrush(DrawingStrokeColor),
                StrokeThickness = DrawingStrokeThickness,
                StrokeDashArray = new DoubleCollection { 4, 2 }, // 虚线预览
                Fill = DrawingFillColor == Colors.Transparent ? null : new SolidColorBrush(DrawingFillColor)
            };
            
            Canvas.SetLeft(previewEllipse, screenPoint.X);
            Canvas.SetTop(previewEllipse, screenPoint.Y);
            previewEllipse.Width = 0;
            previewEllipse.Height = 0;
            
            currentDrawingElement = previewEllipse;
            ImageCanvas.Children.Add(previewEllipse);
            ImageCanvas.CaptureMouse();
        }

        /// <summary>
        /// 放置十字准星
        /// </summary>
        private void PlaceCrosshair(Point imagePoint)
        {
            var shape = new CrosshairShapeInfo
            {
                Center = imagePoint,
                Size = 20,
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                ShowCenterDot = true
            };
            
            // 添加到集合
            AddShapeToCollection(shape);
            
            System.Diagnostics.Debug.WriteLine($"放置十字准星: ({imagePoint.X:F1}, {imagePoint.Y:F1})");
            
            // 绘制完成后自动切换到选择模式
            CurrentDrawingMode = DrawingMode.None;
        }

        /// <summary>
        /// 添加多边形顶点
        /// </summary>
        private void AddPolygonPoint(Point screenPoint, Point imagePoint, MouseButtonEventArgs e)
        {
            // 双击完成多边形
            if (e.ClickCount == 2 && polygonPoints.Count >= 3)
            {
                FinishPolygonDrawing();
                return;
            }
            
            polygonPoints.Add(imagePoint);
            
            // 更新或创建预览多边形
            UpdatePolygonPreview();
            
            System.Diagnostics.Debug.WriteLine($"添加多边形顶点 {polygonPoints.Count}: ({imagePoint.X:F1}, {imagePoint.Y:F1})");
        }

        /// <summary>
        /// 更新多边形预览
        /// </summary>
        private void UpdatePolygonPreview()
        {
            // 移除旧的预览
            if (currentDrawingElement != null)
            {
                ImageCanvas.Children.Remove(currentDrawingElement);
            }
            
            if (polygonPoints.Count < 2)
                return;
            
            // 创建预览多边形
            var previewPolygon = new Polygon
            {
                Stroke = new SolidColorBrush(DrawingStrokeColor),
                StrokeThickness = DrawingStrokeThickness,
                StrokeDashArray = new DoubleCollection { 4, 2 },
                Fill = DrawingFillColor == Colors.Transparent ? null : new SolidColorBrush(DrawingFillColor)
            };
            
            foreach (var pt in polygonPoints)
            {
                Point screenPt = TransformPoint(pt, useInverse: false);
                previewPolygon.Points.Add(screenPt);
            }
            
            currentDrawingElement = previewPolygon;
            ImageCanvas.Children.Add(previewPolygon);
        }

        /// <summary>
        /// 完成多边形绘制
        /// </summary>
        private void FinishPolygonDrawing()
        {
            if (polygonPoints.Count < 3)
            {
                CancelCurrentDrawing();
                return;
            }
            
            var shape = new PolygonShapeInfo
            {
                Points = new List<Point>(polygonPoints),
                StrokeColor = DrawingStrokeColor,
                StrokeThickness = DrawingStrokeThickness,
                FillColor = DrawingFillColor
            };
            
            // 添加到集合
            AddShapeToCollection(shape);
            
            // 清理
            if (currentDrawingElement != null)
            {
                ImageCanvas.Children.Remove(currentDrawingElement);
                currentDrawingElement = null;
            }
            polygonPoints.Clear();
            
            System.Diagnostics.Debug.WriteLine($"完成多边形绘制，顶点数: {shape.Points.Count}");
            
            // 绘制完成后自动切换到选择模式
            CurrentDrawingMode = DrawingMode.None;
        }

        /// <summary>
        /// 将图形添加到集合并触发事件
        /// </summary>
        private void AddShapeToCollection(ShapeInfo shape)
        {
            // 自动设置图形名称（如果未设置）
            if (string.IsNullOrEmpty(shape.Name))
            {
                int index = shapeInfoList.Count(s => s.ShapeType == shape.ShapeType) + 1;
                shape.Name = GetShapeDefaultName(shape.ShapeType, index);
            }

            // 添加到内部列表
            shapeInfoList.Add(shape);
            
            // 绘制图形
            DrawShape(shape);
            
            // 同步到绑定的集合
            if (ShapeCollection != null)
            {
                isUpdatingShapeCollection = true;
                try
                {
                    ShapeCollection.Add(shape);
                }
                finally
                {
                    isUpdatingShapeCollection = false;
                }
            }
            
            // 触发事件
            OnShapeDrawn(ShapeDrawnEventArgs.ChangeType.Added, shape);
            
            // 刷新命令状态，使应用ROI和清除ROI按钮可用
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 获取图形的默认名称
        /// </summary>
        private string GetShapeDefaultName(ShapeType shapeType, int index)
        {
            switch (shapeType)
            {
                case ShapeType.Rectangle:
                    return $"矩形_{index}";
                case ShapeType.Line:
                    return $"直线_{index}";
                case ShapeType.Circle:
                    return $"圆形_{index}";
                case ShapeType.Ellipse:
                    return $"椭圆_{index}";
                case ShapeType.Arrow:
                    return $"箭头_{index}";
                case ShapeType.Crosshair:
                    return $"十字_{index}";
                case ShapeType.Polygon:
                    return $"多边形_{index}";
                default:
                    return $"图形_{index}";
            }
        }

        /// <summary>
        /// 注册ROI集合路由事件 - 点击保存ROI按钮时触发，传递所有ROI数据
        /// </summary>
        public static readonly RoutedEvent InterceptROIEvent = EventManager.RegisterRoutedEvent(
            "InterceptROI", RoutingStrategy.Bubble, typeof(RoiCollectionEventHandler), typeof(DisplayVision));

        /// <summary>
        /// ROI集合事件 - 当点击保存ROI按钮时触发
        /// </summary>
        public event RoiCollectionEventHandler InterceptROI
        {
            add { AddHandler(InterceptROIEvent, value); }
            remove { RemoveHandler(InterceptROIEvent, value); }
        }

        /// <summary>
        /// 触发ROI集合事件
        /// </summary>
        /// <param name="shapeCollection">形状集合（包含所有绘制的形状，矩形ROI也会转换为RectangleShapeInfo）</param>
        protected void RaiseInterceptROIEvent(ObservableCollection<ShapeInfo> shapeCollection)
        {
            RoiCollectionEventArgs args = new RoiCollectionEventArgs(InterceptROIEvent, shapeCollection);
            RaiseEvent(args);
        }

        // 注册鼠标移动路由事件
        public static readonly RoutedEvent MovePixelInfoEvent = EventManager.RegisterRoutedEvent(
            "MovePixelInfo", RoutingStrategy.Bubble, typeof(PixelInfoRoutedEventHandler), typeof(DisplayVision));

        // 鼠标位移像素Command
        public event PixelInfoRoutedEventHandler MovePixelInfo
        {
            add { AddHandler(MovePixelInfoEvent, value); }
            remove { RemoveHandler(MovePixelInfoEvent, value); }
        }

        /// <summary>
        /// 鼠标像素信息路由触发
        /// </summary>
        /// <param name="roi">X,Y,R,G,B</param>
        protected void RaiseMovePixelInfoEvent(PixelInfo pixelInfo)
        {
            // 重用事件参数对象，避免频繁创建
            if (reusablePixelInfoEventArgs == null)
            {
                reusablePixelInfoEventArgs = new PixelInfoRoutedEventArgs(MovePixelInfoEvent, pixelInfo);
            }
            else
            {
                reusablePixelInfoEventArgs.UpdatePixelInfo(pixelInfo);
            }
            RaiseEvent(reusablePixelInfoEventArgs);
        }

        public static readonly DependencyProperty OpenVisionHeight = DependencyProperty.Register(
            "VisionHeight",
            typeof(double),
            typeof(DisplayVision),
            new PropertyMetadata(100.0));

        /// <summary>
        /// 控件高度
        /// </summary>
        public double VisionHeight
        {
            get { return (double)GetValue(OpenVisionHeight); }
            set { SetValue(OpenVisionHeight, value); }
        }

        public static readonly DependencyProperty OpenVisionWidth = DependencyProperty.Register(
            "VisionWidth",
            typeof(double),
            typeof(DisplayVision),
            new PropertyMetadata(100.0));

        /// <summary>
        /// 控件宽度
        /// </summary>
        public double VisionWidth
        {
            get { return (double)GetValue(OpenVisionWidth); }
            set { SetValue(OpenVisionWidth, value); }
        }

        public static readonly DependencyProperty ImageMarginProperty = DependencyProperty.Register(
            "ImageMargin",
            typeof(Thickness),
            typeof(DisplayVision),
            new PropertyMetadata(new Thickness(10)));

        /// <summary>
        /// 图像显示时与控件边界的边距
        /// </summary>
        public Thickness ImageMargin
        {
            get { return (Thickness)GetValue(ImageMarginProperty); }
            set { SetValue(ImageMarginProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(DisplayVision),
            new PropertyMetadata(string.Empty));

        /// <summary>
        /// 控件标题
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleBackgroundProperty = DependencyProperty.Register(
            "TitleBackground",
            typeof(Brush),
            typeof(DisplayVision),
            new PropertyMetadata(new SolidColorBrush(Color.FromRgb(240, 240, 240))));

        /// <summary>
        /// 标题背景颜色
        /// </summary>
        public Brush TitleBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty BottomRightTextProperty = DependencyProperty.Register(
            "BottomRightText",
            typeof(string),
            typeof(DisplayVision),
            new PropertyMetadata(string.Empty));

        /// <summary>
        /// 右下角显示的字符串
        /// </summary>
        public string BottomRightText
        {
            get { return (string)GetValue(BottomRightTextProperty); }
            set { SetValue(BottomRightTextProperty, value); }
        }

        public static readonly DependencyProperty OpenVisionImage = DependencyProperty.Register(
           "InputImage",
           typeof(ImageSource),
           typeof(DisplayVision),
           new PropertyMetadata(null, OnImageChanged));

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var openVision = (DisplayVision)d;
            
            // 检查是否已释放
            if (openVision.isDisposed) return;
            
            if (!openVision.Dispatcher.CheckAccess())
            {
                openVision.Dispatcher.BeginInvoke(new Action(() => OnImageChanged(d, e)), DispatcherPriority.Normal);
                return;
            }
            
            // 清理旧图像的缓存引用（不阻止 GC）
            if (e.OldValue is ImageSource oldImageSource)
            {
                openVision.CleanupImageSource(oldImageSource);
            }
            
            ImageSource newImageSource = e.NewValue as ImageSource;
            openVision.InvalidateComponents();
            
            // 更新缓存的 BitmapSource 引用和尺寸
            if (newImageSource is BitmapSource bitmapSource)
            {
                openVision.cachedBitmapSource = bitmapSource;
                openVision.cachedImageWidth = bitmapSource.PixelWidth;
                openVision.cachedImageHeight = bitmapSource.PixelHeight;
            }
            else
            {
                openVision.cachedBitmapSource = null;
                openVision.cachedImageWidth = 0;
                openVision.cachedImageHeight = 0;
            }
            
            if (newImageSource != null)
            {
                openVision.AutoAdjustPerformanceMode(newImageSource);

                // 使用缓存的委托或创建一次
                if (openVision.cachedResetImageScaleAction != null)
                {
                    openVision.Dispatcher.BeginInvoke(openVision.cachedResetImageScaleAction, DispatcherPriority.Loaded);
                }
                else
                {
                    openVision.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        if (!openVision.isDisposed)
                        {
                            openVision.ResetImageScale();
                        }
                    }), DispatcherPriority.Loaded);
                }
            }
        }

        /// <summary>
        /// 清理图像源资源
        /// </summary>
        /// <param name="imageSource">要清理的图像源</param>
        private void CleanupImageSource(ImageSource imageSource)
        {
            if (imageSource == null) return;
            
            try
            {
                // 不要在这里持有任何引用，让 GC 自然回收
                // WPF 的 BitmapSource 大多数情况下不需要手动释放
                
                // 如果是 BitmapImage 且未冻结，尝试冻结以允许跨线程访问并优化内存
                if (imageSource is BitmapImage bitmapImage)
                {
                    try
                    {
                        if (!bitmapImage.IsFrozen && bitmapImage.CanFreeze)
                        {
                            bitmapImage.Freeze();
                        }
                    }
                    catch (InvalidOperationException)
                    {
                        // 忽略：图像可能正在使用中
                    }
                }
                
                // 清除缓存引用
                if (ReferenceEquals(cachedBitmapSource, imageSource))
                {
                    cachedBitmapSource = null;
                    cachedImageWidth = 0;
                    cachedImageHeight = 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"清理图像源时出错: {ex.Message}");
            }
        }

        /// <summary>
        /// 创建内存优化的BitmapImage
        /// 使用这个方法代替直接创建BitmapImage以避免内存泄漏
        /// </summary>
        /// <param name="imagePath">图像文件路径</param>
        /// <returns>优化的BitmapImage</returns>
        public static BitmapImage CreateOptimizedBitmapImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
                return null;

            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();
                if (bitmap.CanFreeze)
                {
                    bitmap.Freeze();
                }
                return bitmap;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"创建BitmapImage失败: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 从流创建内存优化的BitmapImage
        /// </summary>
        /// <param name="stream">图像流</param>
        /// <returns>优化的BitmapImage</returns>
        public static BitmapImage CreateOptimizedBitmapImageFromStream(Stream stream)
        {
            if (stream == null) return null;

            try
            {
                var bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.CreateOptions = BitmapCreateOptions.IgnoreColorProfile;
                bitmap.StreamSource = stream;
                bitmap.EndInit();

                if (bitmap.CanFreeze)
                {
                    bitmap.Freeze();
                }

                return bitmap;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"从流创建BitmapImage失败: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// 图像源
        /// </summary>
        public ImageSource InputImage
        {
            get { return (ImageSource)GetValue(OpenVisionImage); }
            set
            {
                if (Dispatcher.CheckAccess())
                {
                    SetValue(OpenVisionImage, value);
                }
                else
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        SetValue(OpenVisionImage, value);
                    }), DispatcherPriority.Background);
                }
            }
        }

        public void Dispose()
        {
            if (isDisposed) return;
            
            lock (disposeLock)
            {
                if (isDisposed) return;
                isDisposed = true;
                
                try
                {
                    // 取消订阅所有事件（防止内存泄漏的关键！）
                    if (ImageCanvas != null)
                    {
                        ImageCanvas.MouseLeftButtonDown -= MouseLDown;
                        ImageCanvas.MouseLeftButtonUp -= MouseLUp;
                        ImageCanvas.MouseMove -= Mouse_Move;
                        ImageCanvas.MouseWheel -= Mouse_Wheel;
                        ImageCanvas.MouseRightButtonDown -= MouseRDown;
                        ImageCanvas.MouseRightButtonUp -= MouseRUp;
                        ImageCanvas.PreviewMouseDown -= OnPreviewMouseDown;
                        ImageCanvas.PreviewMouseUp -= OnPreviewMouseUp;
                        ImageCanvas.MouseLeave -= ImageCanvas_MouseLeave;
                        ImageCanvas = null;
                    }
                    
                    if (SelectionRectangle != null)
                    {
                        SelectionRectangle.Visibility = Visibility.Collapsed;
                        SelectionRectangle = null;
                    }
                    
                    // 清理已绘制的ROI框及其事件订阅
                    if (drawnRoiContainers != null)
                    {
                        foreach (var container in drawnRoiContainers)
                        {
                            UnsubscribeRoiContainerEvents(container);
                        }
                        drawnRoiContainers.Clear();
                        drawnRoiContainers = null;
                    }
                    
                    if (roiInfoList != null)
                    {
                        roiInfoList.Clear();
                        roiInfoList = null;
                    }
                    
                    // 清理已绘制的图形
                    if (drawnShapeElements != null)
                    {
                        drawnShapeElements.Clear();
                        drawnShapeElements = null;
                    }
                    
                    if (shapeInfoList != null)
                    {
                        shapeInfoList.Clear();
                        shapeInfoList = null;
                    }
                    
                    // 取消订阅ShapeCollection事件
                    if (ShapeCollection != null)
                    {
                        ShapeCollection.CollectionChanged -= ShapeCollection_CollectionChanged;
                    }
                    
                    _originalImageControl = null;
                    
                    if (transformGroup != null)
                    {
                        transformGroup.Children.Clear();
                        transformGroup = null;
                    }
                    scaleTransform = null;
                    translateTransform = null;
                    
                    // 清理图像引用（不持有图像，让 GC 回收）
                    // 仅在 UI 线程上才能访问 DependencyProperty
                    if (Dispatcher.CheckAccess())
                    {
                        SetValue(OpenVisionImage, null);
                    }
                    
                    // 清理待处理的像素信息更新
                    if (pendingPixelInfoUpdate != null && pendingPixelInfoUpdate.Status == DispatcherOperationStatus.Pending)
                    {
                        pendingPixelInfoUpdate.Abort();
                    }
                    pendingPixelInfoUpdate = null;
                    
                    // 清理待处理的选择框更新
                    if (pendingSelectionUpdate != null && pendingSelectionUpdate.Status == DispatcherOperationStatus.Pending)
                    {
                        pendingSelectionUpdate.Abort();
                    }
                    pendingSelectionUpdate = null;
                    
                    // 清理缓存的委托
                    cachedUpdateSelectionAction = null;
                    cachedUpdatePixelInfoAction = null;
                    cachedResetImageScaleAction = null;
                    cachedProcessPendingWheelZoomAction = null;
                    cachedLightweightMemoryCleanupAction = null;
                    
                    // 清理所有缓存引用
                    _cachedBitmapSource = null;
                    cachedBitmapSourceRef = null;
                    cachedImageWidth = 0;
                    cachedImageHeight = 0;
                    reusablePixelInfo = null;
                    reusablePixelInfoEventArgs = null;
                    lastImageReference = null;
                    pixelBuffer = null;
                    
                    // 重置状态
                    isSelecting = false;
                    isDragging = false;
                    isRoiSelectionEnabled = false;
                    isComponentsValid = false;
                    isTransformCacheValid = false;
                    isWheelUpdatePending = false;
                    pendingWheelDelta = 0;
                    zoomOperationCount = 0;

                    // 清理命令引用（仅在 UI 线程上才能访问 DependencyProperty）
                    if (Dispatcher.CheckAccess())
                    {
                        SetValue(SaveImageCommandProperty, null);
                        SetValue(SetRoiCommandProperty, null);
                        SetValue(ResetSizeCommandProperty, null);
                    }

                    GC.SuppressFinalize(this);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Dispose过程中出错: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// 析构函数，确保资源被释放
        /// </summary>
        ~DisplayVision()
        {
            Dispose();
        }

        /// <summary>
        /// 手动清理当前图像资源
        /// </summary>
        public void ClearCurrentImage()
        {
            var currentImage = InputImage;
            if (currentImage != null)
            {
                CleanupImageSource(currentImage);
                InputImage = null;
            }
            if (transformGroup != null)
            {
                scaleTransform.ScaleX = 1.0;
                scaleTransform.ScaleY = 1.0;
                scaleTransform.CenterX = 0;
                scaleTransform.CenterY = 0;
                translateTransform.X = 0;
                translateTransform.Y = 0;
            }
            if (SelectionRectangle != null)
            {
                SelectionRectangle.Visibility = Visibility.Collapsed;
            }

            InvalidateComponents();
        }

        /// <summary>
        /// 强制执行垃圾回收
        /// </summary>
        public static void ForceGarbageCollection()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }

    #region 鼠标跟随像素信息路由事件

    public class PixelInfo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }
        public int Gray { get; set; }
    }

    public class PixelInfoRoutedEventArgs : RoutedEventArgs
    {
        public PixelInfo PixelInfo { get; private set; }

        public PixelInfoRoutedEventArgs(RoutedEvent routedEvent, PixelInfo pixelInfo) : base(routedEvent)
        {
            PixelInfo = pixelInfo;
        }
        
        /// <summary>
        /// 更新像素信息（用于重用事件参数对象）
        /// </summary>
        /// <param name="pixelInfo">新的像素信息</param>
        public void UpdatePixelInfo(PixelInfo pixelInfo)
        {
            PixelInfo = pixelInfo;
            // 重置 Handled 状态，确保事件可以继续传播
            Handled = false;
        }
    }

    public delegate void PixelInfoRoutedEventHandler(object sender, PixelInfoRoutedEventArgs e);
    #endregion

    #region 鼠标截取功能路由事件

    /// <summary>
    /// 旧版ROI类（保留用于兼容，单个ROI裁剪图像）
    /// </summary>
    public class ROI : IDisposable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public CroppedBitmap RoiBitmap { get; set; }

        public void Dispose()
        {
            RoiBitmap = null;
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// ROI集合事件参数 - 用于InterceptROI事件，包含所有绘制的形状（矩形ROI也会转换为RectangleShapeInfo）
    /// </summary>
    public class RoiCollectionEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// 形状集合（所有绘制的形状，包括矩形ROI、线条、圆形、椭圆等）
        /// </summary>
        public ObservableCollection<ShapeInfo> ShapeCollection { get; private set; }

        public RoiCollectionEventArgs(RoutedEvent routedEvent, ObservableCollection<ShapeInfo> shapeCollection) : base(routedEvent)
        {
            ShapeCollection = shapeCollection ?? new ObservableCollection<ShapeInfo>();
        }
    }

    /// <summary>
    /// ROI集合事件委托
    /// </summary>
    public delegate void RoiCollectionEventHandler(object sender, RoiCollectionEventArgs e);

    // 保留旧版泛型类用于兼容
    public class RoutedEventArgs<ROI> : RoutedEventArgs
    {
        public ROI MousetROI { get; private set; }

        public RoutedEventArgs(RoutedEvent routedEvent, ROI roi) : base(routedEvent)
        {
            MousetROI = roi;
        }
    }

    public delegate void RoutedEventHandler<ROI>(object sender, RoutedEventArgs<ROI> e);

    #endregion
}
    #endregion