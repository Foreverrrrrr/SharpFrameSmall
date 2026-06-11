# SharpFrameSmall

<div align="center">

**面向工业自动化产线的 WPF 上位机框架**

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/UI-WPF-purple.svg)](https://github.com/dotnet/wpf)
[![Prism](https://img.shields.io/badge/MVVM-Prism%208.0-orange.svg)](https://prismlibrary.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE.txt)

</div>

---

## 目录

- [项目简介](#项目简介)
- [技术栈](#技术栈)
- [系统架构](#系统架构)
- [项目结构](#项目结构)
- [核心模块详解](#核心模块详解)
  - [1. 流程引擎 (ProcessBase)](#1-流程引擎-processbase)
  - [2. 状态信号交换层 (Exchange)](#2-状态信号交换层-exchange)
  - [3. 流程图执行引擎 (FlowExecution)](#3-流程图执行引擎-flowexecution)
  - [4. 参数框架 (Parameter Structure)](#4-参数框架-parameter-structure)
  - [5. Modbus TCP 通信](#5-modbus-tcp-通信)
  - [6. 工业相机集成](#6-工业相机集成)
  - [7. OpenCV 视觉处理](#7-opencv-视觉处理)
  - [8. 通信模块](#8-通信模块)
  - [9. 日志系统](#9-日志系统)
  - [10. 用户权限系统](#10-用户权限系统)
  - [11. 生产信息管理](#11-生产信息管理)
  - [12. 自定义 UI 组件库](#12-自定义-ui-组件库)
  - [13. 多语言支持](#13-多语言支持)
  - [14. Excel 工具](#14-excel-工具)
  - [15. MES/SFCS 集成](#15-messfcs-集成)
  - [16. 自动更新](#16-自动更新)
  - [17. 几何计算库](#17-几何计算库)
  - [18. 开机自启动](#18-开机自启动)
- [快速开始](#快速开始)
- [页面导航](#页面导航)
- [版权声明](#版权声明)
- [致谢](#致谢)

---

## 项目简介

SharpFrameSmall 是一个面向工业自动化生产线的 WPF 桌面应用程序框架，深度整合了**机器视觉**、**PLC 通信**、**MES 对接**、**流程编排**、**参数配方管理**和**日志追溯**等核心功能。框架基于 **Prism 8.0 + DryIoc** 的 MVVM 架构，内置了一套基于反射的轻量级流程引擎，可快速搭建从设备层到业务层的全栈工业控制上位机。

### 典型应用场景

> 工控机通过本软件连接 **PLC（Modbus TCP）**、**工业相机（海康 GIGE / OPT）**、**MES 系统（SFCS WebService）**，利用 OpenCV 进行视觉检测与标定，基于自定义流程图引擎驱动自动化生产流程，配合参数配方管理、多级日志追溯和用户权限管控，完成完整的产线自动化控制。

---

## 技术栈

| 类别 | 技术 |
|------|------|
| **运行时** | .NET Framework 4.8 (x64)，允许 Unsafe 代码 |
| **UI 框架** | WPF + [MaterialDesignThemes](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) 4.8 |
| **MVVM** | [Prism 8.0](https://github.com/PrismLibrary/Prism) (DryIoc IoC) + BindableBase + PubSubEvent |
| **行为绑定** | Microsoft.Xaml.Behaviors.Wpf 1.1 |
| **流程图** | Syncfusion UI.Xaml.Diagram (节点式流程编辑器) |
| **机器视觉** | [OpenCVSharp](https://github.com/shimat/opencvsharp) + MvCameraControl.Net (海康 SDK) + SciCamera.Net (OPT SDK) |
| **工业通信** | Modbus TCP · 异步 TCP/IP · HTTP · WCF/WebService (SFCS) |
| **数据库** | SQL Server · SQLite · Excel (EPPlus 4.5) |
| **日志** | [log4net](https://logging.apache.org/log4net/) 2.0.17 + 自定义结构化 JSON + CSV |
| **序列化** | [Newtonsoft.Json](https://www.newtonsoft.com/json) 13.0 |
| **自动更新** | 独立 Update.exe + version.json 版本比对 |

---

## 系统架构

```
┌──────────────────────────────────────────────────────────┐
│                    Views (WPF XAML)                       │
│  MainWindow │ HomeView │ ParameterView │ MotionDebugView │
│  DataBaseView │ LogControl │ Dialog Views │ SharpStyle   │
├──────────────────────────────────────────────────────────┤
│                  ViewModels (Prism)                        │
│  MainWindowVM │ HomeVM │ ParameterVM │ MotionDebugVM     │
│  DataBaseVM │ LogControlVM │ Dialog VMs                  │
├──────────────────────────────────────────────────────────┤
│              Logic Layer (Business)                        │
│  ProcessBase Engine │ FlowExecution │ Exchange            │
│  Auto (Production Flow)                                   │
├────────────────────┬─────────────────────────────────────┤
│   Common Library   │      Structure / Parameter           │
│  Camera │ Modbus   │  IParameter → ParameterBase          │
│  TCP/IP │ HTTP     │  → SystemParameter                   │
│  OpenCV │ Excel    │  → ModbusParameter                   │
│  SQL │ Geometry    │  → LabelParameter                    │
│  UserManagement    │  → AttdefParameter                   │
├────────────────────┴─────────────────────────────────────┤
│  Infrastructure: LogsFolder │ Log4Net │ language │ Update │
└──────────────────────────────────────────────────────────┘
```

### 启动流程

1. `App.OnInitialized()` → 初始化生产信息数据库 + 用户管理数据库
2. `MainWindowViewModel` 构造函数 → 注册 Prism Region、订阅事件、初始化页面导航
3. `PageLoadFinish` 命令 → 加载配方列表、读取生产信息、启动换班监控
4. `HomeViewModel` 收到 `PageLoadEvent` → 调用 `ProcessBase.NewClass()` 反射扫描 `ProcessBase` 子类，自动启动所有 `[ProductionThread]` 标记的后台线程
5. `Exchange.External_IO(Send_Variable.Reset)` → 执行复位流程
6. 用户点击启动按钮 → `Exchange.External_IO(Send_Variable.Start)` → 流程开始运行

---

## 项目结构

```
SharpFrameSmall.sln
├── SharpFrameSmall/                    # 主工程 (WPF Application)
│   ├── App.xaml / App.xaml.cs          # 应用程序入口
│   ├── app.config                      # 应用程序配置
│   │
│   ├── Common/                         # 通用工具库
│   │   ├── Camera/
│   │   │   ├── Haikang.cs              # 海康 GIGE 相机完整封装
│   │   │   └── OPT.cs                  # OPT GIGE 相机完整封装
│   │   ├── Commumication/
│   │   │   ├── AsyncSharpTcpClient.cs   # 异步 TCP 客户端 (自动重连/同步收发/KeepAlive)
│   │   │   ├── AsyncSharpTcpServer.cs   # 异步 TCP 服务器 (多客户端/广播)
│   │   │   └── Http_Client.cs           # HTTP POST 客户端 (失败缓存/重试机制)
│   │   ├── ModbusTCP/
│   │   │   ├── ModbusTCPClientPlus.cs   # Modbus TCP 客户端 (全功能码/触发器引擎)
│   │   │   ├── PLC_ModbusTCP.cs         # PLC Modbus TCP 读写
│   │   │   └── Package.cs              # Modbus 数据包封装/解析
│   │   ├── SFCS/
│   │   │   └── SFCSClient.cs           # MES/SFCS WebService 客户端 (WCF)
│   │   ├── SQL/
│   │   │   ├── SQL_Server.cs           # SQL Server 操作封装
│   │   │   └── SQL_Sqlite.cs           # SQLite 操作封装
│   │   ├── OpencvHandle.cs             # OpenCV 视觉处理
│   │   ├── ExcelTool.cs                # Excel 读写 (EPPlus + 特性映射)
│   │   ├── ExcelDialogHelper.cs        # Excel 对话框辅助
│   │   ├── Geometry.cs                 # 2D/3D 几何计算库
│   │   ├── ProductionInformation.cs    # 生产信息管理 (计时/计数/换班)
│   │   ├── UserManagement.cs           # 用户账户 CRUD (SQLite)
│   │   └── AutoStartHelper.cs          # Windows 注册表开机自启动
│   │
│   ├── Logic/                          # 业务逻辑层
│   │   ├── Base/
│   │   │   ├── ProcessBase.cs          # ★ 流程引擎核心基类
│   │   │   ├── ProductionThreadBase.cs # ProductionThreadInfo + [ProductionThread] 特性
│   │   │   ├── DataConfigurationBase.cs # 数据池条目定义
│   │   │   └── Exchange.cs            # 启动/暂停/停止/复位/急停 信号互锁逻辑
│   │   └── AutoMain/
│   │       └── Auto.cs                 # 自动流程示例模板
│   │
│   ├── FlowExecution/                  # 流程图执行引擎
│   │   ├── FlowNode.cs                 # 有向图节点 (前驱/后继/层级/参数)
│   │   ├── FlowGraphPath.cs            # 图管理 (增删节点/边, BFS路径执行, JSON持久化)
│   │   ├── ComboBoxNodeViewModel.cs    # 带下拉选择的流程节点 ViewModel
│   │   └── RoutingNodeViewModel.cs     # 可视化路由节点 ViewModel (Syncfusion)
│   │
│   ├── Structure/                      # 数据结构层
│   │   └── Parameter/
│   │       ├── Parameter Structure/
│   │       │   ├── IParameter.cs       # 参数接口 (ID/Name/DeepClone/Validate)
│   │       │   ├── ParameterBase.cs    # 参数基类 (字段集合/验证/属性变更)
│   │       │   ├── ParameterField.cs   # 参数字段定义 (值/默认值/范围/公式/单位)
│   │       │   ├── ValueParameter.cs   # 值类型参数 (适配基本数据类型)
│   │       │   └── RangeObservableCollection.cs # 范围限制的可观测集合
│   │       ├── SystemParameter.cs      # 系统参数实体
│   │       ├── ModbusParameter.cs      # Modbus 参数实体 (地址/功能码/字节序)
│   │       ├── LabelParameter.cs       # 标签参数实体
│   │       ├── AttdefParameter.cs      # 属性定义参数实体
│   │       ├── ParameterConfig.cs      # 参数配置管理器
│   │       ├── ParameterJsonTool.cs    # JSON 配方序列化工具
│   │       ├── ParameterStore.cs       # 参数运行时存储
│   │       └── Parameter.config        # 参数配置文件
│   │
│   ├── ViewModels/                     # 视图模型层 (MVVM)
│   │   ├── MainWindowViewModel.cs      # 主窗口 VM (导航/权限/通知/状态机控制)
│   │   ├── HomeViewModel.cs            # 主页 VM (流程初始化/权限响应/语言切换)
│   │   ├── ParameterViewModel.cs       # 参数管理 VM
│   │   ├── MotionDebugViewModel.cs     # 运动调试 VM
│   │   ├── DataBaseViewModel.cs        # 数据库视图 VM
│   │   ├── LogControlViewModel.cs      # 日志输出 VM
│   │   ├── ParameterDialog/
│   │   │   ├── SystemLogInViewModel.cs # 系统登录 VM
│   │   │   ├── UserDialogViewModel.cs  # 用户管理 VM
│   │   │   ├── NewFormulaDialogViewModel.cs # 新建配方 VM
│   │   │   └── ErrorCodeDialogViewModel.cs  # 错误码管理 VM
│   │   └── Structure/
│   │       └── PermissionType.cs       # 用户等级枚举 + User 实体
│   │
│   ├── Views/                          # WPF 视图层
│   │   ├── MainWindow.xaml/.cs         # 主窗口 (MaterialDesign 左侧导航 + Prism Region)
│   │   ├── HomeView.xaml/.cs           # 主页 (生产状态/计数/CT)
│   │   ├── ParameterView.xaml/.cs      # 参数配置页
│   │   ├── MotionDebugView.xaml/.cs    # 运动调试页
│   │   ├── DataBaseView.xaml/.cs       # 数据库管理页
│   │   ├── LogControl.xaml/.cs         # 日志输出控件
│   │   ├── ParameterDialog/            # 弹窗视图
│   │   │   ├── SystemLogInView.xaml/.cs # 系统登录弹窗
│   │   │   ├── UserDialog.xaml/.cs     # 用户管理弹窗
│   │   │   ├── NewFormulaDialog.xaml/.cs # 新建配方弹窗
│   │   │   └── ErrorCodeDialog.xaml/.cs # 错误码管理弹窗
│   │   └── SharpStyle/                 # ★ 自定义 WPF 控件库
│   │       ├── AxisControl/            # 运动轴控制面板
│   │       │   ├── AxisControl.cs      # 轴 Jog/绝对定位 控件
│   │       │   ├── AxisMonitor.cs      # 轴实时状态监控
│   │       │   └── AxisViewModel.cs    # 轴数据 VM
│   │       ├── IOControl/              # IO 信号监控面板
│   │       │   ├── IOControl.cs        # IO 点状态显示控件
│   │       │   └── IOViewModel.cs      # IO 数据 VM
│   │       ├── Notification/           # 多级通知系统
│   │       │   ├── GenericNotification.cs    # 通知容器控件
│   │       │   ├── NotificationTemplateSelector.cs # 通知模板选择器
│   │       │   ├── Notification_Info.cs     # 信息通知 (自动消失)
│   │       │   ├── Notification_Warning.cs  # 警告通知
│   │       │   ├── Notification_Error.cs    # 错误通知 (可手动关闭)
│   │       │   ├── Notification_Fatal.cs    # 致命错误通知
│   │       │   └── TimedNotification.cs     # 定时自动移除基类
│   │       ├── OpenVision/
│   │       │   ├── DisplayVision.cs    # WriteableBitmap 图像显示控件
│   │       │   └── RelayCommand.cs     # ICommand 实现
│   │       └── ParameterDataGrid/
│   │           └── ParameterDataGrid.cs # 参数 DataGrid 控件
│   │
│   ├── LogsFolder/                     # 结构化日志系统
│   │   ├── LogsManage.cs               # 日志管理器 (双队列异步写盘/过期清理/目录树)
│   │   ├── LogsEventJson.cs            # MES 事件日志 (STATUS 类型, SITE/LINE/STATION/MACHINE)
│   │   ├── LogsProductJson.cs          # MES 产品日志 (PCS 类型, USN/CT/TORQUE/WAYPOINTS)
│   │   ├── LogsRecipeJson.cs           # 配方变更日志
│   │   ├── LogsResultJson.cs           # 生产结果日志 (Pass/Fail + 失败原因)
│   │   ├── ScrewdriverJson.cs          # 螺丝刀扭矩数据日志
│   │   ├── PLC_ModbusTCP.cs            # PLC 通信日志
│   │   └── ErrorCode.cs                # 错误码实体 (ExcelColumn 特性映射)
│   │
│   ├── Log4Net/                        # log4net 日志配置
│   │   ├── Log.cs                      # 静态日志封装 (Info/Error)
│   │   └── log4net.config              # log4net 配置文件
│   │
│   ├── language/                       # 多语言资源 (WPF ResourceDictionary)
│   │   ├── LocalizationService.cs      # 语言切换服务 (动态加载/持久化)
│   │   ├── zh-CN.xaml                  # 简体中文
│   │   ├── zh-TW.xaml                  # 繁体中文
│   │   ├── en-US.xaml                  # 英文
│   │   └── vi-VN.xaml                  # 越南语
│   │
│   ├── Themes/Generic.xaml             # WPF 全局控件样式
│   ├── Properties/                     # 程序集信息/资源/设置
│   ├── Lib/                            # 外部 DLL 引用
│   │   ├── MvCameraControl.Net.dll     # 海康相机 SDK
│   │   ├── SciCamera.Net.dll           # OPT 相机 SDK
│   │   ├── EPPlus.dll                  # Excel 读写
│   │   ├── log4net.dll                 # 日志框架
│   │   └── Newtonsoft.Json.dll         # JSON 序列化
│   └── ExportNuGet.ps1                 # NuGet 包导出脚本
│
├── Update/                             # 自动更新工具 (独立工程)
│   ├── Update.csproj
│   ├── Program.cs                      # 入口
│   ├── Update/
│   │   ├── Updater.cs                  # 更新逻辑 (停主进程 → 替换文件 → 重启)
│   │   └── UpdateServer.cs             # 更新服务器交互
│   ├── Properties/AssemblyInfo.cs
│   ├── Lib/Newtonsoft.Json.dll
│   └── App.config
│
├── .gitattributes
├── .gitignore
├── CodeMap1.dgml                       # Visual Studio 代码依赖图
└── LICENSE.txt                         # MIT License
```

---

## 核心模块详解

### 1. 流程引擎 (ProcessBase)

整个框架的心脏，定义于 [Logic/Base/ProcessBase.cs](SharpFrameSmall/Logic/Base/ProcessBase.cs)。它是一个抽象基类，为所有生产流程提供统一的生命周期管理。

#### 1.1 全局状态机

使用 `bool[65535]` 数组作为全局数据池，枚举项通过反射映射到数组索引，实现类型安全的跨流程信号通信：

| 方法 | 签名 | 用途 |
|------|------|------|
| `SetEnum<TEnum>` | `(TEnum input, bool state)` | 设置指定枚举项的状态信号 |
| `SetEnumBatch<TEnum>` | `(IEnumerable<TEnum>, bool)` | 批量设置状态信号 |
| `AwaitEnum<TEnum>` | `(TEnum input, bool state, ...)` | 阻塞等待指定信号到达目标状态，支持超时/取消/外部 ManualResetEvent |
| `GetEnumValue<TEnum>` | `(TEnum input) → bool` | 获取指定枚举项的当前状态 |

`AwaitEnum` 在等待期间会响应线程的 `Interrupt`（暂停信号量），实现暂停时所有等待同步阻塞。

#### 1.2 自动线程管理

通过 `[ProductionThread]` 特性标记的方法会被反射自动发现并启动：

```
ProcessBase.NewClass(object[] sharedObjects, int spintime=50)
  → 扫描 Assembly 中所有 ProcessBase 子类
  → 反射实例化每个子类
  → 调用 OnGetShared() 获取共享参数
  → 扫描 [ProductionThread] 标记的方法
  → 为每个方法创建 ProductionThreadInfo
  → 启动后台线程，循环执行标记方法
```

每个线程的生命周期管理：

| 方法 | 作用 |
|------|------|
| `Thread_Stop()` | 暂停所有流程线程 (`ManualResetEvent.Reset()`) |
| `Thread_Reset()` | 恢复所有流程线程 (`ManualResetEvent.Set()`) |
| `Thread_Dispose()` | 销毁所有流程线程 (Cancel Token + Join + Abort) |
| `Thread_Dispose(string)` | 销毁指定名称的流程线程 |

#### 1.3 线程异常自恢复

线程中抛出 `ThreadAbortException` 时自动调用 `ThreadRestartEvent` 回调，然后重新创建线程实例；其他异常触发 `ThreadError` 回调后同样自动重建，保证产线不会因为单次异常而中断。

#### 1.4 共享参数系统

`ConcurrentDictionary<Type, object>` 实现的类型安全跨流程参数共享：

```csharp
// 注册共享参数（同时注册到自身类型、接口、基类）
ProcessBase.SetShared(myObject);
ProcessBase.SetSharedObjects(obj1, obj2, obj3);

// 获取共享参数
var aggregator = ProcessBase.GetShared<IEventAggregator>();
var auto = ProcessBase.GetShared<Auto>();
```

#### 1.5 子类实现模板

```csharp
public class Auto : ProcessBase
{
    // 内部枚举自动注册为状态机信号
    public enum MyEnum { One, Two }

    public override ManualResetEvent Interrupt { get; set; }
    public override event Action<DateTime, string> LogEvent;

    // 获取共享参数
    protected override void OnGetShared()
    {
        eventAggregator = GetShared<IEventAggregator>();
    }

    // 初始化
    public override void Initialize(object thread) { }

    // ★ 主循环 — 被后台线程以 spintime 间隔循环调用
    [ProductionThread]
    protected override void Main(ProcessBase thread)
    {
        SetEnum(MyEnum.One, true);
        AwaitEnum(MyEnum.Two, true, token: ThreadToken, time: 5000);
    }

    // 异常恢复回调
    protected override void ThreadRestartEvent(string name, ProcessBase thread,
        ThreadAbortException ex) { }
    protected override void ThreadError(string name, ProcessBase thread,
        Exception exception) { }
}
```

---

### 2. 状态信号交换层 (Exchange)

定义于 [Logic/Base/Exchange.cs](SharpFrameSmall/Logic/Base/Exchange.cs)，在 UI 按钮和流程引擎之间建立互锁逻辑。

```
Send_Variable 枚举：
  Start → AwaitStarted → Suspend → Stop → Reset → ResetOver → E_Stop
```

#### 信号转换真值表

| 操作 | 前置条件 | 信号变更 |
|------|----------|----------|
| **启动** | `ResetOver=true` 且 (暂停中 / 复位后 / 连续启动) | `Start=true, AwaitStarted=true` |
| **暂停** | `AwaitStarted=true, Start=true` | `Suspend=true, Start=false` |
| **停止** | 无前置条件 | 全部复位为 false, `Stop=true` |
| **复位** | `ResetOver=false` 且 (停止中 / 暂停中) | `Reset=true`, 同时调用 `Thread_Dispose()` |

这确保了按钮操作的状态安全性——例如无法在未复位完成时启动，复位后必须经过停止或暂停状态才能再次复位。

---

### 3. 流程图执行引擎 (FlowExecution)

#### 3.1 FlowNode — 有向图节点

```csharp
public class FlowNode
{
    string Name;                          // 节点名称
    Action<FlowNode, object[]> Method;    // 节点执行方法
    List<FlowNode> NextNodes;             // 后继节点集合
    List<FlowNode> PreNodes;              // 前驱节点集合
    bool IsExecuted;                      // 执行状态标记
    int Level;                            // 拓扑层级
    bool IsConnect;                       // 是否有连接
    object Parameter;                     // 节点自定义参数
}
```

#### 3.2 FlowGraphPath — 图管理与 BFS 执行

- **节点管理**: `AddNode`, `RemoveNode`, `SetNodeObject`
- **边管理**: `AddEdge`, `RemoveEdge` — 自动维护前后驱关系、层级计算、连接状态
- **广度优先执行**: `Route_Planning(object[])` — 校验所有节点已连接 → 找到唯一入口节点 → BFS 遍历执行
- **持久化**: `ConnectortoFlowGraphParameter` 将 Syncfusion 可视化节点转为可序列化结构 → JSON 保存/读取

#### 3.3 RoutingNodeViewModel / ComboBoxNodeViewModel

基于 Syncfusion `NodeViewModel` 的可视化流程节点，支持 ShapeStyle 绑定和 ComboBox 选择项。

---

### 4. 参数框架 (Parameter Structure)

一套层次化的参数管理系统，位于 [Structure/Parameter/Parameter Structure/](SharpFrameSmall/Structure/Parameter/Parameter%20Structure/)。

#### 4.1 接口层

```csharp
public interface IParameter : INotifyPropertyChanged
{
    int ID { get; set; }                      // 唯一标识
    string Name { get; set; }                 // 参数名称
    string Description { get; set; }           // 描述
    string Category { get; }                   // 类别标识
    IParameter DeepClone();                    // 深拷贝
    bool Validate(out string errorMessage);    // 验证
}
```

#### 4.2 核心层 (ParameterBase)

```csharp
public abstract class ParameterBase : IParameter
{
    ObservableCollection<ParameterField> Fields;   // 字段集合
    ValidationResult ValidateAll();                // 聚合验证 (参数级+字段级)
    // 支持属性变更通知、编辑模式、错误信息
}
```

#### 4.3 字段定义 (ParameterField)

```csharp
public class ParameterField : INotifyPropertyChanged
{
    string Value;              // 当前值
    string DefaultValue;       // 默认值
    string Expression;         // 公式表达式
    string Unit;               // 单位
    bool IsReadOnly;           // 只读
    double MinValue/MaxValue;  // 数值范围
    // 值变化时自动触发关联字段的公式重算
}
```

#### 4.4 派生参数类型

| 类型 | 用途 |
|------|------|
| `SystemParameter` | 系统配置参数 |
| `ModbusParameter` | Modbus 地址/功能码/字节序绑定 |
| `LabelParameter` | 标签显示参数 |
| `AttdefParameter` | 属性定义参数 |
| `ValueParameter` | 泛型值类型参数适配器 |

#### 4.5 配套设施

- `ParameterStore` — 运行时参数存储与事件通知
- `ParameterJsonTool` — JSON 配方文件读写（读取/保存/获取配方名列表）
- `ParameterConfig` — 参数配置管理
- `Parameter.config` — 参数配置文件
- `RangeObservableCollection<T>` — 带容量限制的可观察集合

---

### 5. Modbus TCP 通信

定义于 [Common/ModbusTCP/ModbusTCPClientPlus.cs](SharpFrameSmall/Common/ModbusTCP/ModbusTCPClientPlus.cs)，是一个功能完备的 Modbus TCP 客户端。

#### 5.1 功能码支持

| 功能码 | 操作 | 方法 |
|--------|------|------|
| `0x01` | 读线圈 | `ReadCoils` |
| `0x02` | 读离散输入 | `ReadDiscreteInputs` |
| `0x03` | 读保持寄存器 | `ReadHoldingRegisters` |
| `0x04` | 读输入寄存器 | `ReadInputRegisters` |
| `0x05` | 写单线圈 | `WriteSingleCoil` |
| `0x06` | 写单寄存器 | `WriteSingleRegister` |
| `0x0F` | 写多线圈 | `WriteMultipleCoils` |
| `0x10` | 写多寄存器 | `WriteMultipleRegisters` |

#### 5.2 字节序

支持 `ABCD` / `BADC` / `CDAB` / `DCBA` 四种字节序，适配不同 PLC 厂商的字序约定。

#### 5.3 触发器引擎

内置于 `ModbusTCPClientPlus` 中的值监控系统：

```csharp
// 触发条件
enum TriggerCondition { Equal, NotEqual, GreaterThan, LessThan,
                        GreaterThanOrEqual, LessThanOrEqual, Changed }

// 支持的数据类型
enum TriggerDataType { Bit, Bool, Int16, UInt16, Int32, UInt32,
                       Int64, Float, Double, String }
```

每个触发器绑定到特定 Modbus 地址，后台定时轮询，当值满足条件时触发回调事件。

#### 5.4 PLC 封装

`PLC_ModbusTCP` 基于 `ModbusTCPClientPlus` 提供更高层的 PLC 读写方法。

---

### 6. 工业相机集成

#### 6.1 海康相机 (Haikang.cs)

封装 [MvCameraControl.Net](https://www.hikrobotics.com/) SDK：

- **设备枚举**: GIGE 协议枚举在线设备，获取序列号/型号/用户自定义名称
- **设备管理**: 批量打开/关闭，设置 Optimal Packet Size
- **采集模式**: 连续采集 / 单帧触发
- **触发模式**: 软触发 / 硬触发 Line0，支持上升沿/下降沿/高电平/低电平
- **像素格式**: Mono8 / BGR8 / RGB8 / BayerRG8 → `WriteableBitmap`
- **图像回调**: `ImageCallBack` → `CopyMemory` → `MV_CC_DisplayOneFrame_NET` 直接渲染到控件句柄
- **Bitmap 输出**: `GetBitmapImage(int Index)` 将 WriteableBitmap 编码为 PNG 的 BitmapImage
- **曝光控制**: `SetExposure(int indexes, UInt32 time)`

#### 6.2 OPT 相机 (OPT.cs)

封装 [SciCamera.Net](https://www.optmv.com/) SDK：

- **设备枚举**: GIGE 协议，获取 IP 地址和序列号
- **回调取流**: `RegisterPayloadCallBack` → `PayloadGetImage` → `PayloadConvertImageEx`
- **像素格式转换**: 自动识别 Mono/RGB → 统一转为 Mono8 或 RGB8
- **图像输出**: `GrabBitmap` / `GrabMat` 同步抓图，超时 5000ms
- **WinForms 兼容**: 通过 `PictureBox` 显示
- **OpenCV Mat 输出**: RGB8 自动转换为 BGR 排列

---

### 7. OpenCV 视觉处理

定义于 [Common/OpencvHandle.cs](SharpFrameSmall/Common/OpencvHandle.cs)：

#### 7.1 图像格式转换

- `ConvertBitmapToImageSource(Bitmap)` → WPF `ImageSource`
- `BitmapToImageSource` 使用 `CreateBitmapSourceFromHBitmap` + GDI 互操作

#### 7.2 相机标定 (Calibration_Matrix)

完整的棋盘格标定流程：

```
读取标定图片 → 灰度转换 → 查找棋盘格角点 (FindChessboardCorners)
  → 亚像素精炼 (CornerSubPix) → 标定计算 (CalibrateCamera)
  → 畸变矫正 (Undistort) → 计算像素/mm 尺寸
```

返回 `Matrix_returns` 结构：
- `Reprojection` — 重投影误差
- `CameraMatrix` — 3×3 内参矩阵
- `DistCoeffs` — 8 元素畸变系数
- `Pixel` — 平均像素/mm 尺寸

#### 7.3 内参矩阵计算 (Camera_Intrinsic_Matrix)

根据镜头焦距(mm)、像元尺寸(μm)、图像分辨率计算初始内参矩阵。

---

### 8. 通信模块

#### 8.1 AsyncSharpTcpClient — 异步 TCP 客户端

- **异步连接**: `BeginConnect` + 超时控制
- **断开自动重连**: 任何 Socket/IO 异常自动触发 3s 延迟重连
- **KeepAlive**: Socket 级别配置 60s 保活 + 10s 间隔
- **同步收发**: `SyncSendReceive(msg)` 发送并阻塞等待响应
- **响应校验**: `SyncSendReceive(msg, expected)` 发送并验证响应
- **事件驱动**: `ReceiveEvent` / `DisconnectionEvent` / `SuccessfuConnectEvent`
- 线程安全: `_connectionToken` 对象确保回调匹配最新连接

#### 8.2 AsyncSharpTcpServer — 异步 TCP 服务器

- **多客户端管理**: `List<ClientSession>` 维护所有连接
- **异步 Accept**: `BeginAccept` 循环接受连接
- **异步 Receive**: 每客户端独立 `BeginReceive` 回调
- **发送方式**: 按 IP / 按 IP:Port / 发第一个客户端 / 广播所有客户端
- **安全移除**: `RemoveClient` 先 Shutdown 再 Close
- UTF8 编码通信

#### 8.3 Http_Client — HTTP 客户端

- **PostJsonAsync**: JSON POST 请求，支持自定义 Header 和超时
- **PostFormAsync**: 表单 POST 请求
- **失败缓存与重试**: `RequestCache` 类实现
  - 失败请求写入 `failed_requests.json`
  - 后台 `BlockingCollection` 队列异步写盘
  - `RetryFailedRequestsAsync()` 循环重试缓存中的请求（成功后自动移除）
  - 支持事件通知缓存状态变化

---

### 9. 日志系统

#### 9.1 log4net 集成 (Log.cs)

```csharp
[assembly: XmlConfigurator(ConfigFile = @"Log4Net\\log4net.config", Watch = true)]

Log.Info("message");              // 普通日志
Log.Info(MainLogStructure);       // 结构化日志 (通过 Prism Event 广播到 UI)
Log.Error("message");             // 错误日志
Log.Error("message", exception);  // 错误日志带异常
```

同时定义了 Prism 事件 `MainLogOutput` / `AutoLogOutput` 将日志推送到 UI 日志控件。

#### 9.2 结构化日志管理器 (LogsManage.cs)

双队列异步写盘架构：

```
BlockingCollection<(string, EventType)> _logqueue     → LogWorker → CSV 按天归档
BlockingCollection<(LogsEventJson, int)> _eventqueue  → EventWorker → JSON 变更日志
```

**日志目录树**:
```
{Path}/
├── Event/          # CSV 按天 (yyyyMMdd.csv) + JSON 变更
├── Recipe/         # 配方变更 JSON
├── Product/        # 产品 JSON (USN_ID_时间戳.json)
├── Result/
│   ├── Pass/       # OK 结果 JSON
│   └── Fail/       # NG 结果 JSON
├── Image/
│   ├── Pass/       # OK 产品图片
│   └── Fail/       # NG 产品图片
└── Program/        # 程序日志
```

自动过期清理（默认 120 天），写入时先 `.tmp` 再 `Move` 防止崩溃损坏。

#### 9.3 MES 数据结构

| 结构 | 类型 | 核心字段 |
|------|------|----------|
| `LogsEventJson` | STATUS | SITE_ID, LINE_ID, STATION_ID, MACHINE_STATUS, MACHINE_ERROR, ERROR_CODE |
| `LogsProductJson` | PCS | USN_ID, CT_OPERATION, CT_TOTAL, RESULT, TORQUE, WAYPOINTS, PRODUCT_ERROR |
| `LogsResultJson` | Result | machine_id, result (0/1), fail_reason, utime |
| `LogsRecipeJson` | Recipe | machine_id, torquesetting, pressuresetting, utime |

#### 9.4 错误码系统 (ErrorCode.cs)

`ErrorCode` 实体使用 `[ExcelColumn]` 特性映射到 Excel 列：
- `error_class` — 错误类别（分组键）
- `error_code` — 异常代码
- `error_description` — 错误详情
- `error_analysis` — 维护建议
- `plc_site` — 关联 PLC 地址

---

### 10. 用户权限系统

定义于 [Common/UserManagement.cs](SharpFrameSmall/Common/UserManagement.cs) 和 [ViewModels/Structure/PermissionType.cs](SharpFrameSmall/ViewModels/Structure/PermissionType.cs)。

#### 10.1 权限等级

```csharp
enum UserLevel { Operator = 0, Technician = 1, Engineer = 2, Admin = 3 }
```

#### 10.2 用户管理 (SQLite)

| 操作 | 说明 |
|------|------|
| `CreateUser` | 创建用户 (Name/Password/Level) |
| `ModifyUserInformation` | 修改用户名/密码/等级（支持部分更新） |
| `DeleteUser` | 删除用户（至少保留一个 Admin 和 Operator） |
| `LoginUser` | 验证用户名密码，返回 User 实体 |
| `GetAllUser` | 获取所有用户列表 |
| `SetUseDB` | 自动建表 + 创建默认用户 (Admin/kskt2026, Operator/12345) |

#### 10.3 UI 权限集成

- `MainWindowViewModel` 通过 `LoginPermission` 事件广播当前用户
- `HomeViewModel` 根据 `UserLevel` 设定参数编辑模式 (`ReadOnly` / `Full`)
- XAML 使用 `PermissionToEnabledConverter` 根据权限控制 UI 元素 IsEnabled

---

### 11. 生产信息管理

定义于 [Common/ProductionInformation.cs](SharpFrameSmall/Common/ProductionInformation.cs)。

#### 11.1 生产计时

```csharp
ProductionInformation.StartProduction();                     // 开始计时
var (elapsed, total) = ProductionInformation.EndProduction(); // 停止计时
var total = ProductionInformation.GetTotalProductionTime();  // 累计时间
```

#### 11.2 生产计数 (SQLite)

`InfoStructure` 结构持久化到 `ProductionInformation.db`:
- `ProductionTotal` — 生产总数
- `QualifiedCount` — 合格数
- `NGCount` — 不良数
- `YieldRate` — 良率
- `ProductionTime` / `ActualProductionTime` — 生产时间

通过 `ReadProductionInfo` / `SaveProductionInfo` 读写，按日期去重。

#### 11.3 换班监控

`StartShiftWatcher(amTime, pmTime)` 启动 300ms 间隔定时器：
- 08:00:00 触发白班开始事件
- 20:00:00 触发夜班开始事件
- `ShiftChanged` 事件供订阅者处理换班逻辑（清零计数器等）

---

### 12. 自定义 UI 组件库

位于 [Views/SharpStyle/](SharpFrameSmall/Views/SharpStyle/)。

#### 12.1 AxisControl — 轴控制面板

- **AxisControl**: 轴 Jog+/Jog-、绝对定位、回零、使能/去使能
- **AxisMonitor**: 实时显示轴的当前位置、速度、状态
- **AxisViewModel**: 轴参数数据绑定

#### 12.2 IOControl — IO 监控面板

- **IOControl**: 以指示灯形式展示 DI/DO 点状态
- **IOViewModel**: IO 数据绑定

#### 12.3 Notification — 多级通知系统

基于 `ObservableCollection<NotificationModel>` 的悬浮通知：

| 级别 | 类 | 行为 |
|------|-----|------|
| Info | `NotificationInfoModel` | 定时自动消失 |
| Warning | `NotificationWarningModel` | 定时自动消失 |
| Error | `NotificationErrorModel` | 手动关闭，带 DeleteCommand |
| Fatal | `NotificationFatalModel` | 持续显示 |

`TimedNotification` 基类实现 `AutoRemoveRequested` 事件，到期后自动从集合中移除。

#### 12.4 OpenVision — 视觉显示控件

`DisplayVision` 基于 `WriteableBitmap` 的高性能图像渲染控件，`RelayCommand` 提供 ICommand 实现。

#### 12.5 ParameterDataGrid — 参数 DataGrid

专门为参数框架设计的 DataGrid 控件，支持参数字段的内联编辑。

---

### 13. 多语言支持

位于 [language/](SharpFrameSmall/language/)。

```
LocalizationService
  → ChangeCulture("zh-CN" | "zh-TW" | "en-US" | "vi-VN")
  → 移除旧 ResourceDictionary → 加载新 language/{culture}.xaml
  → 持久化到 Properties.Settings.Default.Language
```

UI 通过 `{DynamicResource Key}` 绑定，切换语言后自动刷新。语言选项通过主窗口右下角的 ComboBox 展示。

---

### 14. Excel 工具

定义于 [Common/ExcelTool.cs](SharpFrameSmall/Common/ExcelTool.cs)。

#### 14.1 ExcelColumnAttribute 特性映射

```csharp
[ExcelColumn(0, HeaderName = "error_class", IsGroupKey = true)]
public string error_class { get; set; }
```

- `Index` — 列索引 (0-based)
- `HeaderName` — 表头名称
- `IsGroupKey` — 分组键（当前行值为空时继承上一行）

#### 14.2 读写操作

| 方法 | 功能 |
|------|------|
| `ReadExcelData<T>` | 基于 `[ExcelColumn]` 特性自动映射列 → 对象列表 |
| `WriteExcelData<T>` | 基于特性写入数据 + 自动表头 |
| `UpdateExcelData<T>` | 按行索引更新指定数据 |
| `WriteExcel<T>` (重载) | 基于 `[Description]` 特性的通用写入 |
| `CompareItems<T>` | 比较两个对象所有映射属性的差异 |
| `GetItemDiffs<T>` | 获取字段级别的变更详情 |

支持自动清理过期 Excel 文件、Kill 占用文件的 Excel 进程、不可见 Unicode 字符过滤。

---

### 15. MES/SFCS 集成

定义于 [Common/SFCS/SFCSClient.cs](SharpFrameSmall/Common/SFCS/SFCSClient.cs)。

基于 WCF WebService 的 SFCS（Shop Floor Control System）客户端：
- `GetLinkUSN` — 获取关联 USN
- `BarcodeValidationWithGivenCategory` — 条码校验
- `CheckInOutMaterials` — 物料进出站校验
- `GetMaterialCategory` / `UpdateMaterialCategory` — 物料类别管理
- `GetWipInAllRoute` — 在制品路由查询
- `GetNextAndRuleStation` — 获取下一工站和规则

---

### 16. 自动更新

独立工程 `Update/`，编译为 `Update.exe`：

```
主程序关闭前调用 new CheckUpdate(serverVersionPath)
  → 启动 Update.exe (传入: 主程序路径, 服务器版本JSON, 本地版本, bin目录)
  → Update.exe 比对本/远程版本号
  → 有新版本 → Kill 主进程 → 复制新文件 → 重启主程序
```

`VersionInfo` 结构包含版本号和文件列表，通过 JSON 序列化传输。

---

### 17. 几何计算库

定义于 [Common/Geometry.cs](SharpFrameSmall/Common/Geometry.cs)，提供 2D/3D 几何运算：

- `Line2D` — 2D 线段结构，计算长度、中点
- `Angle` — 计算两线段夹角（水平基准/垂直基准）
- `Circle` — 圆拟合（最小二乘法）
- `Point2D` / `Point3D` — 点结构
- 直线交点、点到直线距离、向量运算

---

### 18. 开机自启动

定义于 [Common/AutoStartHelper.cs](SharpFrameSmall/Common/AutoStartHelper.cs)：

```csharp
AutoStartHelper.SetAutoStart("SharpFrameSmall", true);   // 注册开机启动
AutoStartHelper.IsAutoStart("SharpFrameSmall");          // 检查是否已注册
```

通过 `HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run` 注册表项实现。

---

## 快速开始

### 环境要求

- **操作系统**: Windows 7/10/11 (x64)
- **运行时**: [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- **开发工具**: Visual Studio 2019+ (推荐)
- **外部 SDK**: 海康 MvCameraControl.Net (如需相机功能)

### 构建与运行

```bash
# 克隆仓库
git clone https://github.com/Foreverrrrrr/SharpFrameSmall.git

# Visual Studio 打开解决方案
start SharpFrameSmall.sln

# MSBuild 命令行构建 (Release)
msbuild SharpFrameSmall.sln /p:Configuration=Release /p:Platform=x64
```

### 依赖说明

**NuGet 包** (自动还原):
- `MaterialDesignThemes` 4.8.0 — Material Design UI 主题
- `Prism.DryIoc` 8.0.0 — MVVM 框架 + IoC 容器
- `Microsoft.Xaml.Behaviors.Wpf` 1.1.135 — XAML 行为绑定
- `System.Data.SQLite` 1.0.119 — SQLite 数据库

**Lib/ 目录 DLL** (手动引用):
- `MvCameraControl.Net.dll` — 海康机器人相机 SDK
- `SciCamera.Net.dll` — OPT 相机 SDK
- `EPPlus.dll` 4.5.3.3 — Excel 读写
- `log4net.dll` 2.0.17 — 日志框架
- `Newtonsoft.Json.dll` 13.0 — JSON 序列化

---

## 页面导航

| 页面 | Prism 路由 | 区域 | 功能说明 |
|------|-----------|------|----------|
| 主页 | `HomeView` | MainRegion | 设备状态概览、生产计数、CT 显示 |
| 参数配置 | `ParameterView` | MainRegion | 系统参数/Modbus 参数/配方管理 |
| 运动调试 | `MotionDebugView` | MainRegion | 轴 Jog 控制、绝对定位、状态监控 |
| 数据库 | `DataBaseView` | MainRegion | 生产数据查询与管理 |
| 生产信息 | `ProduceInfoView` | MainRegion | 工单/产品/良率信息 |
| 日志 | `LogView` | MainRegion | 日志查询与导出 |
| 日志控件 | `LogControl` | ToolRegion | 底部实时日志输出 |

---

## 版权声明

> Copyright (c) 2024 Mr. Xu YiFan
>
> 本软件仅用于演示和教育目的，禁止商业用途。
> 未经作者授权，禁止修改、复制或重新分发。
>
> 问题或建议请联系：**awalkingonthecloud@gmail.com**

---

## 致谢

- [Prism Library](https://prismlibrary.com/) — MVVM 框架
- [Material Design In XAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) — UI 主题
- [OpenCVSharp](https://github.com/shimat/opencvsharp) — .NET 版 OpenCV
- [log4net](https://logging.apache.org/log4net/) — 日志框架
- [EPPlus](https://github.com/EPPlusSoftware/EPPlus) — Excel 读写库
- [Syncfusion](https://www.syncfusion.com/) — 流程图控件
- [海康机器人](https://www.hikrobotics.com/) — 工业相机 SDK
- [OPT (奥普特)](https://www.optmv.com/) — 工业相机 SDK
