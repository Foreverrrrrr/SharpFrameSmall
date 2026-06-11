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
- [启动流程](#启动流程)
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
  - [12. Excel 工具](#12-excel-工具)
  - [13. MES/SFCS 集成](#13-messfcs-集成)
  - [14. 几何计算库](#14-几何计算库)
  - [15. 多语言支持](#15-多语言支持)
  - [16. 自动更新](#16-自动更新)
  - [17. 开机自启动](#17-开机自启动)
- [自定义 UI 组件库 (SharpStyle)](#自定义-ui-组件库-sharpstyle)
  - [I. 轴控制面板 (AxisControl)](#i-轴控制面板-axiscontrol)
  - [II. IO 监控面板 (IOControl)](#ii-io-监控面板-iocontrol)
  - [III. 通知系统 (Notification)](#iii-通知系统-notification)
  - [IV. 视觉显示控件 (OpenVision)](#iv-视觉显示控件-openvision)
  - [V. 参数 DataGrid (ParameterDataGrid)](#v-参数-datagrid-parameterdatagrid)
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
│   │   ├── ParameterDialog/            # 弹窗 VM (登录/用户/配方/错误码)
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
│   │   ├── ParameterDialog/            # 弹窗视图 (登录/用户/配方/错误码)
│   │   └── SharpStyle/                 # ★ 自定义 WPF 控件库
│   │       ├── AxisControl/            # 运动轴控制面板
│   │       ├── IOControl/              # IO 信号监控面板
│   │       ├── Notification/           # 多级通知系统
│   │       ├── OpenVision/             # 视觉图像显示控件
│   │       └── ParameterDataGrid/      # 参数 DataGrid 控件
│   │
│   ├── LogsFolder/                     # 结构化日志系统
│   │   ├── LogsManage.cs               # 日志管理器 (双队列异步写盘/过期清理/目录树)
│   │   ├── LogsEventJson.cs            # MES 事件日志 (STATUS 类型)
│   │   ├── LogsProductJson.cs          # MES 产品日志 (PCS 类型)
│   │   ├── LogsRecipeJson.cs           # 配方变更日志
│   │   ├── LogsResultJson.cs           # 生产结果日志
│   │   ├── ScrewdriverJson.cs          # 螺丝刀扭矩数据
│   │   ├── PLC_ModbusTCP.cs            # PLC 通信日志
│   │   └── ErrorCode.cs                # 错误码实体 (ExcelColumn 特性映射)
│   │
│   ├── Log4Net/                        # log4net 配置
│   ├── language/                       # 多语言资源 (zh-CN/zh-TW/en-US/vi-VN)
│   ├── Themes/Generic.xaml             # WPF 全局控件样式
│   ├── Properties/                     # 程序集信息/资源/设置
│   ├── Lib/                            # 外部 DLL 引用
│   └── ExportNuGet.ps1                 # NuGet 包导出脚本
│
├── Update/                             # 自动更新工具 (独立工程)
│   ├── Update.csproj
│   ├── Program.cs                      # 入口
│   ├── Update/
│   │   ├── Updater.cs                  # 更新逻辑 (停主进程 → 替换文件 → 重启)
│   │   └── UpdateServer.cs             # 更新服务器交互
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

整个框架的心脏，定义于 `Logic/Base/ProcessBase.cs`。

#### 1.1 全局状态机

使用 `bool[65535]` 数组作为全局数据池，枚举值通过完整类型名反射映射到数组索引。

**API 表**:

| 方法 | 签名 | 用途 |
|------|------|------|
| `SetEnum<TEnum>` | `(TEnum input, bool state)` | 设置指定枚举项的状态信号 |
| `SetEnumBatch<TEnum>` | `(IEnumerable<TEnum>, bool)` | 批量设置状态信号 |
| `AwaitEnum<TEnum>` | `(TEnum, bool, CancellationToken, int timeout, Action onTimeout)` | 阻塞等待信号到达目标状态 |
| `AwaitEnum<TEnum>` | `(TEnum, bool, ManualResetEvent, int, CancellationToken)` | 带外部暂停信号量的等待重载 |
| `GetEnumValue<TEnum>` | `(TEnum input) → bool` | 获取指定枚举项的当前状态 |

`AwaitEnum` 在等待期间会响应线程的 `Interrupt`（暂停信号量）和 `CancellationToken`（取消通知），超时可通过 `onTimeout` 回调处理。

#### 1.2 共享参数系统

```csharp
// 接口
void SetShared<T>(T obj)                         // 注册单个共享参数
T GetShared<T>()                                  // 获取指定类型共享参数
bool RemoveShared<T>()                            // 移除共享参数
void SetSharedObjects(params object[] objects)    // 批量注册

// 实现：ConcurrentDictionary<Type, object>
// 注册时同时映射到自身类型、接口和基类链
```

#### 1.3 线程管理 API

| 方法 | 作用 |
|------|------|
| `NewClass(object[], int spintime)` | 反射扫描所有 ProcessBase 子类, 自动实例化并启动 `[ProductionThread]` 线程 |
| `InitializeStart()` | 初始化所有流程线程 |
| `InitializeStart(string name)` | 初始化指定名称的线程 |
| `Thread_Stop()` | 暂停所有流程线程 (`ManualResetEvent.Reset()`) |
| `Thread_Reset()` | 恢复所有流程线程 (`ManualResetEvent.Set()`) |
| `Thread_Dispose()` | 销毁所有流程线程 |
| `Thread_Dispose(string)` | 销毁指定线程 |

**异常恢复**: 线程抛出 `ThreadAbortException` → 触发 `ThreadRestartEvent` 回调 → 自动重建线程；其他异常 → 触发 `ThreadError` 回调 → 自动重建。

#### 1.4 子类实现模板

```csharp
public class Auto : ProcessBase
{
    // 嵌套枚举自动注册为全局状态机信号
    public enum MyEnum { One, Two }

    public override ManualResetEvent Interrupt { get; set; }
    public override event Action<DateTime, string> LogEvent;

    // 1. 获取共享参数
    protected override void OnGetShared()
    {
        eventAggregator = GetShared<IEventAggregator>();
    }

    // 2. 初始化
    public override void Initialize(object thread) { }

    // 3. ★ 主循环 — 被后台线程以 spintime 间隔(默认50ms)循环调用
    [ProductionThread]
    protected override void Main(ProcessBase thread)
    {
        SetEnum(MyEnum.One, true);
        AwaitEnum(MyEnum.Two, true, token: ThreadToken, time: 5000);
    }

    // 4. 异常恢复
    protected override void ThreadRestartEvent(string name, ProcessBase thread,
        ThreadAbortException ex) { }
    protected override void ThreadError(string name, ProcessBase thread,
        Exception exception) { }
}
```

---

### 2. 状态信号交换层 (Exchange)

定义于 `Logic/Base/Exchange.cs`。在 UI 操作和流程引擎之间建立互锁逻辑。

```
Send_Variable 枚举状态流转：
  Start → AwaitStarted → Suspend → Stop → Reset → ResetOver → E_Stop
```

#### 信号转换真值表

| 操作 | 前置条件 | 信号变更 |
|------|----------|----------|
| **启动** | `ResetOver=true` 且 (暂停中 OR 复位后 OR 连续启动) | `Start=true, AwaitStarted=true` |
| **暂停** | `AwaitStarted=true, Start=true` | `Suspend=true, Start=false` |
| **停止** | 无前置条件 | 全部复位为 false, `Stop=true` |
| **复位** | `ResetOver=false` 且 (停止中 OR 暂停中) | `Reset=true`, 同时调用 `Thread_Dispose()` |

这确保了按钮操作的状态安全性——例如无法在未复位完成时启动，复位后必须经过停止或暂停状态才能再次触发复位。

##### 使用示例：

```csharp
// 在 MainWindowViewModel 中，启动按钮绑定到 Start_State 属性：
public bool Start_State
{
    get => _start_state;
    set
    {
        if (!_start_state && value && Exchange.External_IO(Send_Variable.Start))
        {
            eventAggregator.GetEvent<StartInform>().Publish();
            _start_state = value;
            SystemState = "自动运行";
        }
        else if (!value) { _start_state = value; }
    }
}
```

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
    int Level;                            // 拓扑层级 (自动计算)
    bool IsConnect;                       // 是否有连接
    object Parameter;                     // 节点自定义参数
}
```

#### 3.2 FlowGraphPath 图管理 API

| 方法 | 功能 |
|------|------|
| `AddNode(FlowNode)` | 添加节点到全局字典 |
| `AddEdge(string from, string to)` | 添加连接边, 自动维护前后驱关系、层级计算、连接状态 |
| `RemoveEdge(string from, string to)` | 移除边, 自动修复层级 |
| `SetNodeObject(string name, object value)` | 设置节点参数 |
| `Route_Planning(object[])` | BFS 广度优先路径执行 (校验连通性 → 找入口 → 遍历执行) |
| `ConnectortoFlowGraphParameter(...)` | Syncfusion 可视化节点 → JSON 持久化结构 |
| `ReadJson<T>` / `Set_NullJson<T>` | JSON 序列化/反序列化 |

##### 使用示例：

```csharp
// 构建流程
FlowGraphPath.AddNode(new FlowNode("Start", node => Console.WriteLine("Start")));
FlowGraphPath.AddNode(new FlowNode("Step1", node => Console.WriteLine("Step1")));
FlowGraphPath.AddNode(new FlowNode("End",   node => Console.WriteLine("End")));
FlowGraphPath.AddEdge("Start", "Step1");
FlowGraphPath.AddEdge("Step1", "End");

// 保存到 JSON
var param = FlowGraphPath.ConnectortoFlowGraphParameter(nodes, connectors);
FlowGraphPath.Set_NullJson(param);

// 执行流程
FlowGraphPath.Route_Planning(new object[] { "param1", "param2" });
```

---

### 4. 参数框架 (Parameter Structure)

层次化参数管理系统。

#### 4.1 接口层 (IParameter)

```csharp
public interface IParameter : INotifyPropertyChanged
{
    int ID { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    string Category { get; }
    IParameter DeepClone();
    bool Validate(out string errorMessage);
}
```

#### 4.2 核心层 (ParameterBase)

```csharp
public abstract class ParameterBase : IParameter
{
    ObservableCollection<ParameterField> Fields;   // 字段集合
    ValidationResult ValidateAll();                // 聚合验证 (参数级+字段级)
}
```

#### 4.3 字段定义 (ParameterField)

```csharp
public class ParameterField : INotifyPropertyChanged
{
    string Value;              // 当前值
    string DefaultValue;       // 默认值
    string Expression;         // 公式表达式 (值变化时自动触发关联字段重算)
    string Unit;               // 单位
    bool IsReadOnly;           // 只读
    double MinValue;           // 数值范围下限
    double MaxValue;           // 数值范围上限
}
```

#### 4.4 派生参数类型

| 类型 | 基类 | 用途 |
|------|------|------|
| `SystemParameter` | `ParameterBase` | 系统配置参数 |
| `ModbusParameter` | `ParameterBase` | Modbus 地址/功能码/字节序绑定 |
| `LabelParameter` | `ParameterBase` | 标签显示参数 |
| `AttdefParameter` | `ParameterBase` | 属性定义参数 |
| `ValueParameter` | `ParameterBase` | 泛型值类型参数适配器 |

##### 使用示例：

```csharp
// 创建系统参数
var sysParam = new SystemParameter
{
    ID = 1,
    Name = "曝光时间",
    Description = "相机曝光时间(ms)"
};
sysParam.Fields.Add(new ParameterField
{
    Value = "100",
    DefaultValue = "100",
    MinValue = 1,
    MaxValue = 1000,
    Unit = "ms"
});

// 保存到 JSON
ParameterJsonTool.SaveParameter("SystemConfig", sysParam);

// 读取所有配方
var recipeNames = ParameterJsonTool.GetRecipeNames();
```

---

### 5. Modbus TCP 通信

#### 5.1 功能码支持

| 功能码 | 常量 | 操作 | 对应方法 |
|--------|------|------|----------|
| `0x01` | `ReadCoils` | 读线圈 | `ReadCoils(slaveId, startAddr, count)` |
| `0x02` | `ReadDiscreteInputs` | 读离散输入 | `ReadDiscreteInputs(slaveId, startAddr, count)` |
| `0x03` | `ReadHoldingRegisters` | 读保持寄存器 | `ReadHoldingRegisters(slaveId, startAddr, count)` |
| `0x04` | `ReadInputRegisters` | 读输入寄存器 | `ReadInputRegisters(slaveId, startAddr, count)` |
| `0x05` | `WriteSingleCoil` | 写单线圈 | `WriteSingleCoil(slaveId, addr, value)` |
| `0x06` | `WriteSingleRegister` | 写单寄存器 | `WriteSingleRegister(slaveId, addr, value)` |
| `0x0F` | `WriteMultipleCoils` | 写多线圈 | `WriteMultipleCoils(slaveId, addr, values)` |
| `0x10` | `WriteMultipleRegisters` | 写多寄存器 | `WriteMultipleRegisters(slaveId, addr, values)` |

#### 5.2 字节序

```csharp
enum ByteOrder { ABCD, BADC, CDAB, DCBA }
```

#### 5.3 触发器引擎

```csharp
// 触发条件
enum TriggerCondition {
    Equal, NotEqual, GreaterThan, LessThan,
    GreaterThanOrEqual, LessThanOrEqual, Changed
}

// 支持的数据类型
enum TriggerDataType {
    Bit, Bool, Int16, UInt16, Int32, UInt32,
    Int64, Float, Double, String
}
```

每个触发器绑定到特定 Modbus 地址，后台定时轮询，当值满足条件时触发回调。

##### 使用示例：

```csharp
var client = new ModbusTCPClientPlus("192.168.1.100", 502);

// 读取保持寄存器
ushort[] values = client.ReadHoldingRegisters(1, 0, 10, ByteOrder.ABCD);

// 写单寄存器
client.WriteSingleRegister(1, 100, 1234);

// 添加触发器：监控地址 0 的 Int32 值 > 1000
client.AddTrigger(1, 0, TriggerDataType.Int32, 1000,
    TriggerCondition.GreaterThan, ByteOrder.ABCD,
    (value) => Console.WriteLine($"触发! 当前值: {value}"));

client.Dispose();
```

---

### 6. 工业相机集成

#### 6.1 海康相机 (Haikang.cs)

封装 [MvCameraControl.Net](https://www.hikrobotics.com/) SDK，GIGE 协议。

**核心 API**:

| 方法 | 功能 |
|------|------|
| `GetDevice() → List<StringBuilder>` | GIGE 枚举在线设备 |
| `OpenDevice(int index)` | 打开指定相机 |
| `OpenDevice()` | 打开所有已发现相机 |
| `Gathercamera(int index, FetchModel, Trigger)` | 开始采集 (Continuous/Einmal × Software/Line0) |
| `SetTriggerModel(int, FetchModel, Trigger, Trigger_Model)` | 触发模式配置 (含边沿/电平类型) |
| `SetExposure(int, uint time)` | 曝光时间设置 |
| `StopGathercamera()` | 停止所有相机采集 |
| `Close()` | 关闭并销毁所有设备 |
| `GetBitmapImage(int) → BitmapImage` | 获取当前帧的 WPF BitmapImage |

**像素格式链**: `Mono8 / BGR8 / RGB8 / BayerRG8 → CopyMemory → WriteableBitmap`

##### 使用示例：

```csharp
var camera = new Haikang();
var devices = camera.GetDevice();           // 枚举设备

camera.OpenDevice(0);                       // 打开第一个相机
camera.SetExposure(0, 10000);               // 曝光 10000μs
camera.Gathercamera(0,
    Haikang.FetchModel.Continuous,          // 连续采集
    Haikang.Trigger.Software);              // 软触发

// 获取图像
BitmapImage img = camera.GetBitmapImage(0);

// 停止
camera.StopGathercamera();
camera.Close();
```

#### 6.2 OPT 相机 (OPT.cs)

封装 [SciCamera.Net](https://www.optmv.com/) SDK。API 风格与海康类似。

**核心 API**:

| 方法 | 功能 |
|------|------|
| `GetDevice() → List<StringBuilder>` | GIGE 枚举在线设备 |
| `OpenDevice()` | 创建并打开所有已发现设备 |
| `StartGrabbing(int dev)` | 开始取流 |
| `SetDeviceProperty(int dev, string name, string value)` | 设置相机属性 |
| `GrabBitmap(int camIndex, int timeoutMs) → Bitmap` | 同步抓取 Bitmap |
| `GrabMat(int camIndex, int timeoutMs) → Mat` | 同步抓取 OpenCV Mat |
| `CloseDevice()` | 停止并关闭所有设备 |

##### 使用示例：

```csharp
var opt = new OPT();
opt.GetDevice();
opt.OpenDevice();
opt.SetDeviceProperty(0, "ExposureTime", "10000");
opt.StartGrabbing(0);

// 抓取图片
Bitmap bmp = opt.GrabBitmap(0, 5000);       // 5s 超时
Mat mat = opt.GrabMat(0, 5000);             // OpenCV Mat 格式

opt.CloseDevice();
```

---

### 7. OpenCV 视觉处理

定义于 `Common/OpencvHandle.cs`。

#### 7.1 图像格式转换

```csharp
// Bitmap → WPF ImageSource
ImageSource source = OpencvHandle.ConvertBitmapToImageSource(bitmap);
```

#### 7.2 相机标定 API

```csharp
public struct Matrix_returns
{
    double Reprojection;       // 重投影误差
    double Pixel;              // 像素/mm 尺寸
    double[,] CameraMatrix;    // 3×3 内参矩阵
    double[] DistCoeffs;       // 8 元素畸变系数
}

// 棋盘格标定
Matrix_returns result = OpencvHandle.Calibration_Matrix(
    calibration_picture_path,    // 标定图片文件夹
    cornersubPixpath,            // 角点图保存路径
    angular_point_width,         // 横向角点数
    angular_point_height,        // 竖向角点数
    imagewidth, imageheigth,    // 图像尺寸
    pixelsize,                   // 棋盘格物理尺寸 mm
    cameraMatrix                 // 初始内参矩阵 (可由下面方法计算)
);

// 计算初始内参矩阵
double[,] matrix = OpencvHandle.Camera_Intrinsic_Matrix(
    focal_length,                // 镜头焦距 mm
    pixel_size_width,            // 像元尺寸 x μm
    pixel_size_heigth,           // 像元尺寸 y μm
    imagewidth, imageheigth     // 图像分辨率
);
```

##### 使用示例：

```csharp
// 计算内参矩阵
var initialMatrix = OpencvHandle.Camera_Intrinsic_Matrix(25, 3.45, 3.45, 2448, 2048);

// 执行标定
var result = OpencvHandle.Calibration_Matrix(
    @"D:\CalibrationPics", @"D:\Output\Corners",
    9, 6, 2448, 2048, 10.0f, initialMatrix
);

Console.WriteLine($"重投影误差: {result.Reprojection}");
Console.WriteLine($"像素/mm: {result.Pixel}");
```

---

### 8. 通信模块

#### 8.1 AsyncSharpTcpClient — 异步 TCP 客户端

**核心特性**:
- **异步连接**: `BeginConnect` + 可配置超时 (`ConnectionTimeoutMs`, 默认 3000ms)
- **断线自动重连**: 任何 Socket/IO 异常自动触发延时重连 (`ReconnectDelayMs`, 默认 3000ms)
- **KeepAlive**: Socket 层 60s 保活 + 10s 探测间隔
- **同步收发**: `SyncSendReceive(msg)` 发送并阻塞等待响应
- **响应校验**: `SyncSendReceive(msg, expected)` 发送并验证

**事件**:
- `ReceiveEvent(DateTime, IPEndPoint, string)` — 数据接收
- `DisconnectionEvent(DateTime, Exception)` — 连接断开
- `SuccessfuConnectEvent(DateTime, IPEndPoint)` — 连接成功

##### 使用示例：

```csharp
var client = new AsyncSharpTcpClient("192.168.1.100", 8000);
client.ReceiveEvent += (time, ep, msg) => Console.WriteLine($"[{time}] {ep}: {msg}");

// 异步发送
client.SendMessage("GET_STATUS\n");

// 同步发送+接收
string response = client.SyncSendReceive("GET_POSITION\n");

// 发送+验证
bool ok = client.SyncSendReceive("PING\n", "PONG");

client.Close();
```

#### 8.2 AsyncSharpTcpServer — 异步 TCP 服务器

```csharp
var server = new AsyncSharpTcpServer("0.0.0.0", 8000);
server.OnTCPReadEvent += (time, ep, msg) => { /* 处理消息 */ };

// 发送方式
server.AsyncWrite("192.168.1.10", "Hello");          // 按 IP
server.AsyncWrite("192.168.1.10", 8001, "Hello");    // 按 IP:Port
server.AsyncWrite("Hello");                           // 发第一个客户端
server.BroadcastMessage("Hello All");                 // 广播

server.CloseTCPServer();
```

#### 8.3 Http_Client — HTTP 客户端

```csharp
// POST JSON
PostResult result = await PostHelper.PostJsonAsync(
    "http://server/api/data",
    "{\"key\":\"value\"}",
    timeout: TimeSpan.FromSeconds(5)
);

// POST 表单
string response = await PostHelper.PostFormAsync(
    "http://server/api/form",
    new Dictionary<string, string> { { "key", "value" } }
);
```

**失败缓存机制**: `RequestCache` 自动缓存失败的请求到 `failed_requests.json`，通过 `RetryFailedRequestsAsync()` 后台循环重试。

---

### 9. 日志系统

#### 9.1 log4net 集成 (Log.cs)

```csharp
Log.Info("message");                     // 普通日志
Log.Info(mainLogStructure);              // 结构化日志 (Prism Event 推送到 UI)
Log.Error("message");                    // 错误日志
Log.Error("message", exception);         // 错误日志带异常
```

#### 9.2 结构化日志管理器 (LogsManage.cs)

双队列异步写盘架构：
```
BlockingCollection<(string, EventType)> _logqueue     → LogWorker → CSV 按天归档
BlockingCollection<(LogsEventJson, int)> _eventqueue  → EventWorker → JSON 变更日志
```

**日志目录树**:
```
{Path}/
├── Event/          # CSV 按天 + JSON 变更
├── Recipe/         # 配方变更
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

##### 使用示例：

```csharp
var logManager = new LogsManage();
logManager.NewLogsFolder(@"D:\ProductionLogs");

// 软件日志
LogsManage.SoftwareLog("流程启动", LogsManage.EventType.Normal);

// MES 事件日志
logManager.SaveEventJson(new LogsEventJson
{
    data = new LogsEventJson.DataContent
    {
        LINE_ID = "L01",
        STATION_ID = "ST01",
        MACHINE_STATUS = "1"  // Run
    }
});

// 产品日志
logManager.SaveProductJson(new LogsProductJson
{
    data = new Data
    {
        USN_ID = "USN20240611001",
        RESULT = "0",  // 0=OK, 1=NG
        CT_OPERATION = "12.5"
    }
});

// 结果日志 (按 Pass/Fail 自动分流)
logManager.SaveResultJson(new LogsResultJson
{
    machine_id = "M01",
    result = 0,
    fail_reason = ""
}, result: true, sn: "SN001");
```

---

### 10. 用户权限系统

```csharp
enum UserLevel
{
    Operator = 0,    // 操作员 — 只读
    Technician = 1,  // 技术员
    Engineer = 2,    // 工程师
    Admin = 3        // 管理员 — 完全控制
}

class User { string Name; string PassWord; UserLevel Level; }
```

**UserManagement API**:

| 方法 | 功能 |
|------|------|
| `CreateUser(User)` / `CreateUser(string, string)` | 创建用户 |
| `ModifyUserInformation(oldUser, newUser)` | 修改用户信息 |
| `DeleteUser(User)` / `DeleteUser(string)` | 删除用户 (至少保留 1 个 Admin 和 1 个 Operator) |
| `LoginUser(string, string) → User` | 用户登入验证 |
| `GetAllUser() → List<User>` | 获取所有用户 |
| `SetUseDB()` | 自动建表 + 创建默认用户 |

**默认账户**: `Admin` / `kskt2026` (管理员) | `Operator` / `12345` (操作员)

**UI 集成**: `LoginPermission` Prism 事件广播登录用户 → `HomeViewModel` 根据 `UserLevel` 设 `ParameterEditMode` → XAML `PermissionToEnabledConverter` 控制控件 IsEnabled。

---

### 11. 生产信息管理

```csharp
// 计时
ProductionInformation.StartProduction();
var (elapsed, total) = ProductionInformation.EndProduction();
TimeSpan totalTime = ProductionInformation.GetTotalProductionTime();
```

**生产计数 (SQLite `ProductionInformation.db`)**:
- `InfoStructure`: SetTime / ProductionTotal / QualifiedCount / NGCount / YieldRate / ProductionTime / ActualProductionTime

```csharp
InfoStructure info = new InfoStructure();
ProductionInformation.ReadProductionInfo(ref info);
info.ProductionTotal++;
info.QualifiedCount++;
info.YieldRate = (double)info.QualifiedCount / info.ProductionTotal * 100;
ProductionInformation.SaveProductionInfo(info);
```

**换班监控**:

```csharp
// 启动 08:00 白班 / 20:00 夜班 切换监控 (300ms 轮询)
ProductionInformation.StartShiftWatcher(
    DateTime.Today.AddHours(8),
    DateTime.Today.AddHours(20)
);

// 订阅换班事件
ProductionInformation.ShiftChanged += (shiftTime) =>
{
    // 清零计数器、切换班次名称等
};
```

---

### 12. Excel 工具

#### 12.1 ExcelColumnAttribute 特性

```csharp
[ExcelColumn(0, HeaderName = "error_class", IsGroupKey = true)]
public string error_class { get; set; }

[ExcelColumn(1, HeaderName = "error_code")]
public string error_code { get; set; }
```

- `Index` — 列索引 (0-based)
- `HeaderName` — 表头名称 (默认属性名)
- `IsGroupKey` — 分组键 (空值继承上一行的值)

#### 12.2 API

| 方法 | 功能 |
|------|------|
| `ReadExcelData<T>(path, table, ref List<T>)` | 基于特性自动列映射读取 |
| `WriteExcelData<T>(path, table, List<T>)` | 基于特性写入 + 自动表头 |
| `UpdateExcelData<T>(path, table, Dictionary<int,T>)` | 按行号更新指定数据 |
| `WriteExcel<T>(path, T, int autoDelete)` | 基于 `[Description]` 特性写入 |
| `WriteExcel<T>(path, ObservableCollection<T>)` | 集合写入 |
| `CompareItems<T>(T a, T b) → bool` | 比较两个对象映射列 |
| `GetItemDiffs<T>(T original, T modified) → List<string>` | 字段级差异 |
| `CopyItem<T>(T source) → T` | 深拷贝映射属性 |

##### 使用示例：

```csharp
// 读取错误码 Excel
List<ErrorCode> errors = new List<ErrorCode>();
ExcelTool.ReadExcelData(@"D:\Config\ErrorCodes.xlsx", "Sheet1", ref errors);

// 写入
ExcelTool.WriteExcelData(@"D:\Output\Report.xlsx", "Report", reportList);

// 更新第 3 行
var updates = new Dictionary<int, ErrorCode> { { 3, modifiedError } };
ExcelTool.UpdateExcelData(@"D:\Config\ErrorCodes.xlsx", "Sheet1", updates);

// 比较差异
var diffs = ExcelTool.GetItemDiffs(oldError, newError);
// 输出: ["error_code: \"E001\" → \"E002\"", ...]
```

---

### 13. MES/SFCS 集成

基于 WCF WebService 的 SFCS（Shop Floor Control System）客户端，命名空间 `http://localhost/Tester.WebService/WebService`。

| 方法 | 功能 |
|------|------|
| `GetLinkUSN` | 获取关联 USN |
| `BarcodeValidationWithGivenCategory` | 条码校验 (USN/Stage/Category 多维验证) |
| `CheckInOutMaterials` | 物料进出站校验 |
| `GetMaterialCategory` | 获取物料类别 |
| `UpdateMaterialCategory` | 更新物料类别 |
| `GetWipInAllRoute` | 在制品(WIP)路由查询 |
| `GetNextAndRuleStation` | 获取下一工站及规则 |

---

### 14. 几何计算库

```csharp
// 2D 线段
Line2D line = new Line2D(0, 0, 100, 100);
double length = line.Length;
Point2D mid = line.MidPoint;

// 角度计算
double angle = Geometry.Angle(line1, line2, Geometry.AngleCriterion.HorizontalLine);

// 圆拟合 (最小二乘法)
Circle circle = Geometry.FitCircle(pointList);

// 点到直线距离
double dist = Geometry.PointToLineDistance(point, line);
```

---

### 15. 多语言支持

```
LocalizationService.ChangeCulture("zh-CN")  // 简体中文
LocalizationService.ChangeCulture("zh-TW")  // 繁体中文
LocalizationService.ChangeCulture("en-US")  // 英文
LocalizationService.ChangeCulture("vi-VN")  // 越南语
```

原理: WPF `ResourceDictionary` 动态切换 → 持久化到 `Properties.Settings.Default.Language` → `{DynamicResource Key}` 自动刷新 UI。

---

### 16. 自动更新

```
主程序 Close 时:
  new CheckUpdate(serverVersionPath)
    → 启动 Update.exe (参数: 主程序路径, 服务器 version.json, 本地版本, bin 目录)
    → Update.exe 比对版本号
    → 有新版本 → Kill 主进程 → 复制文件 → 重启主程序
```

---

### 17. 开机自启动

```csharp
// 注册开机自启动
AutoStartHelper.SetAutoStart("SharpFrameSmall", true);

// 检查是否已注册
bool isAuto = AutoStartHelper.IsAutoStart("SharpFrameSmall");

// 取消
AutoStartHelper.SetAutoStart("SharpFrameSmall", false);
```

通过 `HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\Run` 注册表项实现。

---

## 自定义 UI 组件库 (SharpStyle)

位于 `Views/SharpStyle/`，共有 **5 大组件**，提供完整的 WPF 依赖属性和命令绑定接口。

### I. 轴控制面板 (AxisControl)

#### 枚举定义

```csharp
public enum AxisStatus
{
    Unknown,         // 未知
    Ready,           // 就绪 (轴已使能)
    Moving,          // 运动中
    Alarm,           // 报警
    EmergencyStop,   // 急停
    Disabled         // 未使能
}
```

#### AxisViewModel — 单轴数据模型

```csharp
public class AxisViewModel : INotifyPropertyChanged
{
    int AxisNo;                // 轴号
    string AxisName;           // 轴名称 (默认 "Axis")
    double PulsePosition;      // 指令脉冲位置
    double EncoderPosition;    // 编码器反馈位置
    string PositionUnit;       // 位置单位 (默认 "mm")
    bool IsServoOn;            // 伺服使能状态
    AxisStatus AxisStatus;     // 轴当前状态 (设置时自动推断 IsServoOn)
    bool IsHomeSensor;         // 原点传感器
    bool IsLimitPositive;      // 正向限位
    bool IsLimitNegative;      // 负向限位

    // 可重写方法
    protected virtual bool ResolveServoOnFromStatus(AxisStatus status);
}
```

##### 使用示例：

```csharp
// 构建轴数据
var axes = new ObservableCollection<AxisViewModel>
{
    new AxisViewModel
    {
        AxisNo = 1, AxisName = "X轴",
        PulsePosition = 123.4567, EncoderPosition = 123.4500,
        PositionUnit = "mm", IsServoOn = true,
        AxisStatus = AxisStatus.Ready, IsHomeSensor = true
    },
    new AxisViewModel
    {
        AxisNo = 2, AxisName = "Y轴",
        PulsePosition = 0.0, EncoderPosition = 0.0,
        PositionUnit = "mm", IsServoOn = false,
        AxisStatus = AxisStatus.Disabled
    }
};

// 定时更新编码器位置
var timer = new DispatcherTimer();
timer.Tick += (s, e) => axes[0].EncoderPosition = ReadEncoderPosition(1);
timer.Start();
```

#### AxisMonitor — 轴监控控件

WPF `Control` 子类, 需在 `Themes/Generic.xaml` 中定义默认样式。

**依赖属性**:

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `AxesSource` | `IEnumerable` | null | 轴表数据源 (绑定 `ObservableCollection<AxisViewModel>`) |
| `SelectedAxis` | `object` | null | 当前选中轴 (双向绑定) |
| `JogSpeed` | `double` | 10.0 | Jog 运动速度 |
| `MaxSpeed` | `double` | 100.0 | Jog 速度上限 |
| `TargetPosition` | `double` | 0.0 | 绝对定位目标位置 (双向绑定) |
| `RelativeDistance` | `double` | 0.0 | 相对定位距离 (双向绑定) |
| `MoveSpeed` | `double` | 10.0 | 定位运动速度 |

**命令依赖属性** (绑定到 ViewModel 中的 ICommand):

| 属性 | CommandParameter | 说明 |
|------|-----------------|------|
| `ServoOnCommand` | `SelectedAxis` | 切换伺服使能 |
| `EmergencyStopCommand` | `SelectedAxis` | 急停 |
| `AlarmResetCommand` | `SelectedAxis` | 清除报警 |
| `HomeCommand` | `SelectedAxis` | 原点回归 |
| `JogPositiveStartCommand` | `JogSpeed` | Jog+ 按下 (PreviewMouseLeftButtonDown) |
| `JogPositiveStopCommand` | null | Jog+ 松开 (PreviewMouseLeftButtonUp/MouseLeave) |
| `JogNegativeStartCommand` | `JogSpeed` | Jog- 按下 |
| `JogNegativeStopCommand` | null | Jog- 松开 |
| `MoveAbsoluteCommand` | `SelectedAxis` | 绝对定位到 `TargetPosition` |
| `MoveRelativeCommand` | `SelectedAxis` | 相对移动 `RelativeDistance` |

> **Jog 长按机制**: `PART_JogPositiveButton` 通过 `PreviewMouseLeftButtonDown` / `PreviewMouseLeftButtonUp` / `MouseLeave` 事件实现长按连续运动, 松开自动停止。

**模板部件**:

| 部件名称 | 类型 | 说明 |
|----------|------|------|
| `PART_AxesDataGrid` | `DataGrid` | 轴状态表 (SelectionChanged → SelectedAxis) |
| `PART_JogPositiveButton` | `ButtonBase` | Jog+ 按钮 |
| `PART_JogNegativeButton` | `ButtonBase` | Jog- 按钮 |

##### XAML 使用示例：

```xml
<sharpStyle:AxisMonitor
    AxesSource="{Binding Axes}"
    SelectedAxis="{Binding CurrentAxis, Mode=TwoWay}"
    JogSpeed="{Binding JogSpeed}"
    TargetPosition="{Binding AbsTarget, Mode=TwoWay}"
    RelativeDistance="{Binding RelDistance, Mode=TwoWay}"
    ServoOnCommand="{Binding ServoOnCmd}"
    EmergencyStopCommand="{Binding EstopCmd}"
    AlarmResetCommand="{Binding AlarmResetCmd}"
    HomeCommand="{Binding HomeCmd}"
    JogPositiveStartCommand="{Binding JogPosStartCmd}"
    JogPositiveStopCommand="{Binding JogPosStopCmd}"
    JogNegativeStartCommand="{Binding JogNegStartCmd}"
    JogNegativeStopCommand="{Binding JogNegStopCmd}"
    MoveAbsoluteCommand="{Binding MoveAbsCmd}"
    MoveRelativeCommand="{Binding MoveRelCmd}"/>
```

##### ViewModel 命令实现示例：

```csharp
public class MotionDebugViewModel
{
    public ICommand JogPosStartCmd { get; }
    public ICommand JogPosStopCmd { get; }

    public MotionDebugViewModel()
    {
        JogPosStartCmd = new DelegateCommand<double>(speed =>
        {
            // 向 PLC 发送 Jog+ 命令
            plcClient.StartJogPositive(CurrentAxis.AxisNo, speed);
        });

        JogPosStopCmd = new DelegateCommand(() =>
        {
            // 停止 Jog
            plcClient.StopJog(CurrentAxis.AxisNo);
        });
    }
}
```

#### 内置值转换器

| 转换器 | 输入 | 输出 |
|--------|------|------|
| `AxisStatusTextConverter` | `AxisStatus` | 中文: 就绪/运动中/报警/急停/未使能/未知 |
| `AxisStatusColorConverter` | `AxisStatus` | Ready=绿, Moving=蓝, Alarm=红, EStop=橙, Disabled=灰 |
| `ServoOnTextConverter` | `bool` | true="上使能", false="下使能" |
| `ServoOnColorConverter` | `bool` | true=深绿, false=蓝 |
| `PositionFormatConverter` | `double` | 4 位小数格式化 |

---

### II. IO 监控面板 (IOControl)

#### IOPointViewModel — 单个 IO 点数据模型

```csharp
public class IOPointViewModel : INotifyPropertyChanged
{
    int PointNo;         // IO 点编号
    string PointName;    // IO 点名称
    bool IsActive;       // 当前状态 (true=ON, false=OFF)
}
```

#### IOInputMonitor — 输入状态监控控件 (只读)

**依赖属性**:

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `Title` | `string` | "DI — 输入状态" | 卡片标题 |
| `PointsSource` | `IEnumerable` | null | IO 输入点数据源 |

#### IOOutputMonitor — 输出监控与控制控件

**依赖属性**:

| 属性 | 类型 | 默认值 | 说明 |
|------|------|--------|------|
| `Title` | `string` | "DO — 输出控制" | 卡片标题 |
| `PointsSource` | `IEnumerable` | null | IO 输出点数据源 |
| `ToggleOutputCommand` | `ICommand` | null | 切换输出状态命令 (CommandParameter=IOPointViewModel) |
| `IsOperationEnabled` | `bool` | true | 是否允许操作 (false 时所有切换按钮禁用) |

#### 内置值转换器

| 转换器 | 输入 | 输出 |
|--------|------|------|
| `IOActiveColorConverter` | `bool` | ON=绿, OFF=暗灰 |
| `IOActiveTextConverter` | `bool` | true="ON", false="OFF" |
| `IOOutputButtonTextConverter` | `bool` | true="置 OFF", false="置 ON" |
| `IOOutputButtonColorConverter` | `bool` | true=深红, false=深绿 |

##### 使用示例：

```xml
<!-- 在 XAML 中 -->
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition/>
        <ColumnDefinition/>
    </Grid.ColumnDefinitions>

    <!-- 输入监控 -->
    <sharpStyle:IOInputMonitor
        Grid.Column="0"
        Title="传感器输入"
        PointsSource="{Binding DI_Points}"/>

    <!-- 输出控制 -->
    <sharpStyle:IOOutputMonitor
        Grid.Column="1"
        Title="执行器输出"
        PointsSource="{Binding DO_Points}"
        ToggleOutputCommand="{Binding ToggleDOCmd}"
        IsOperationEnabled="{Binding IsOutputEnabled}"/>
</Grid>
```

```csharp
// ViewModel
public class IOMonitorViewModel
{
    public ObservableCollection<IOPointViewModel> DI_Points { get; }
        = new ObservableCollection<IOPointViewModel>
        {
            new IOPointViewModel { PointNo = 1, PointName = "启动按钮", IsActive = false },
            new IOPointViewModel { PointNo = 2, PointName = "停止按钮", IsActive = false },
            new IOPointViewModel { PointNo = 3, PointName = "安全门", IsActive = true },
        };

    public ObservableCollection<IOPointViewModel> DO_Points { get; }
        = new ObservableCollection<IOPointViewModel>
        {
            new IOPointViewModel { PointNo = 1, PointName = "气缸", IsActive = false },
            new IOPointViewModel { PointNo = 2, PointName = "指示灯", IsActive = true },
        };

    public ICommand ToggleDOCmd { get; }

    public IOMonitorViewModel()
    {
        ToggleDOCmd = new DelegateCommand<IOPointViewModel>(point =>
        {
            // 通过 PLC 切换输出状态
            plcClient.WriteCoil(point.PointNo, !point.IsActive);
            point.IsActive = !point.IsActive;  // 更新 UI
        });
    }
}
```

---

### III. 通知系统 (Notification)

#### 架构概览

```
Notification (PubSubEvent)  ──发布→  MainWindowViewModel
                                         ↓
                                  ObservableCollection<NotificationModel>
                                         ↓
                                  GenericNotification (Control)
                                         ↓
                              NotificationTemplateSelector
                              ┌─────────┼─────────┐
                     InfoTemplate  WarningTemplate  ErrorTemplate  FatalTemplate
```

#### NotificationModel 基类及子类

```csharp
public abstract class NotificationModel
{
    int ID;                    // 通知唯一标识
    string Message;            // 通知消息内容
    string MessageTime;        // 消息时间
    DelegateCommand<object> Delete;  // 删除命令
    event RoutedEventHandler AutoRemoveRequested;   // 自动移除事件
    void StopAutoRemoveTimer();                     // 停止自动移除定时器
    protected virtual bool ShouldStartTimer();       // 是否启用自动消失
}

// 子类及其自动消失行为:
NotificationInfoModel    : NotificationModel   // ShouldStartTimer() → true  (5s 后自动消失)
NotificationWarningModel : NotificationModel   // ShouldStartTimer() → true  (5s 后自动消失)
NotificationErrorModel   : NotificationModel   // ShouldStartTimer() → false (需手动关闭)
NotificationFatalModel   : NotificationModel   // ShouldStartTimer() → false (持续显示)
```

#### Notification — Prism 事件定义

```csharp
public class Notification : PubSubEvent<Notification>
{
    enum InfoType { Info, Warning, Error, Fatal }

    InfoType Type;       // 通知级别
    string Message;      // 通知消息
    string MessageTime;  // 时间 (默认当前时间)
}
```

#### GenericNotification — 通知容器控件

```xml
<!-- 已在 MainWindow.xaml 中使用 -->
<sharpStyle:GenericNotification IsNotice="{Binding IsNotice}"/>
```

#### TimedNotification — 带基础属性的通知控件基类

```csharp
public abstract class TimedNotification : Control
{
    int ID;                    // 通知 ID
    string Message;            // 消息内容
    string MessageTime;        // 消息时间
    ICommand CloseCommand;     // 关闭命令
}

// WPF 子类:
Notification_Info    : TimedNotification  // Info 模板
Notification_Warning : TimedNotification  // Warning 模板
Notification_Error   : TimedNotification  // Error 模板
Notification_Fatal   : TimedNotification  // Fatal 模板
```

##### 使用示例：

```csharp
// 在任何 ViewModel 或流程中发布通知
eventAggregator.GetEvent<Notification>().Publish(new Notification
{
    Type = Notification.InfoType.Warning,
    Message = "气压不足，请检查气源！",
    MessageTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
});

eventAggregator.GetEvent<Notification>().Publish(new Notification
{
    Type = Notification.InfoType.Error,
    Message = "伺服驱动器报警 E.30 — 过载",
});

eventAggregator.GetEvent<Notification>().Publish(new Notification
{
    Type = Notification.InfoType.Fatal,
    Message = "紧急停止已触发！",
});
```

`MainWindowViewModel` 中自动订阅 `Notification` 事件 → 根据 `Type` 创建对应的 `*Model` → 插入 `IsNotice` 集合 → `GenericNotification` 模板化渲染：

- **Info / Warning**: 5 秒后通过 `AutoRemoveRequested` 事件自动从集合移除
- **Error**: 不自动消失，绑定 `DeleteCommand` 手动关闭
- **Fatal**: 持续显示，不自动消失

---

### IV. 视觉显示控件 (OpenVision)

#### DisplayVision — WriteableBitmap 图像显示控件

基于 WPF `Control`, 提供高性能 WriteableBitmap 渲染和图形标注功能。

**核心功能**:

| 功能 | 说明 |
|------|------|
| `WriteableBitmap` 渲染 | 高性能相机图像实时显示 |
| 图像缩放 | 鼠标滚轮缩放 |
| 图形绘制 | Rectangle / Line / Circle / Ellipse / Arrow / Polygon |
| 绘制模式 | None — 浏览 / Rectangle — 矩形 ROI / Line / Circle / Ellipse / Arrow / Polygon |
| 图形选择与编辑 | 选中图形高亮, 可拖拽移动/调整尺寸 |
| 坐标转换 | 图像坐标 ↔ 屏幕坐标 自动转换 |
| 图像保存 | `SaveDisplayedImage(string path)` |

**绘制模式枚举**:

```csharp
public enum DrawingMode
{
    None,        // 无绘制模式（普通浏览/选择）
    Rectangle,   // 矩形 ROI
    Line,        // 直线
    Circle,      // 圆形
    Ellipse,     // 椭圆
    Arrow,       // 箭头
    Polygon      // 多边形
}
```

#### RelayCommand — ICommand 实现

```csharp
public class RelayCommand : ICommand
{
    RelayCommand(Action<object> execute);
    RelayCommand(Action<object> execute, Predicate<object> canExecute);
}
```

##### 使用示例：

```xml
<sharpStyle:DisplayVision
    x:Name="VisionDisplay"
    ImageSource="{Binding LiveImage}"
    DrawingMode="{Binding CurrentMode}"
    Shapes="{Binding ShapeCollection}"/>
```

```csharp
// 设置实时图像
var bitmap = new WriteableBitmap(2448, 2048, 96, 96, PixelFormats.Bgr24, null);
// ... 填充图像数据 ...
visionDisplay.ImageSource = bitmap;

// 切换为矩形 ROI 模式
visionDisplay.DrawingMode = DrawingMode.Rectangle;

// 保存带标注的图像
visionDisplay.SaveDisplayedImage(@"D:\Images\capture.png");
```

---

### V. 参数 DataGrid (ParameterDataGrid)

专为 `ParameterBase.Fields` 集合设计的数据表格控件，支持内联编辑。

直接绑定 `ParameterBase.Fields` 即可，列自动绑定到 `ParameterField` 的各属性 (`Name` / `Value` / `DefaultValue` / `MinValue` / `MaxValue` / `Unit` / `IsReadOnly`)。

##### 使用示例：

```xml
<sharpStyle:ParameterDataGrid
    ItemsSource="{Binding SelectedParameter.Fields}"/>
```

---

## 快速开始

### 环境要求

- **操作系统**: Windows 7/10/11 (x64)
- **运行时**: [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- **开发工具**: Visual Studio 2019+ (推荐)
- **外部 SDK**: 海康 MvCameraControl.Net / OPT SciCamera.Net (如需相机功能)

### 构建与运行

```bash
git clone https://github.com/Foreverrrrrr/SharpFrameSmall.git
start SharpFrameSmall.sln
# 或: msbuild SharpFrameSmall.sln /p:Configuration=Release /p:Platform=x64
```

### 依赖

**NuGet 包** (自动还原): `MaterialDesignThemes` 4.8.0 · `Prism.DryIoc` 8.0.0 · `Microsoft.Xaml.Behaviors.Wpf` 1.1.135 · `System.Data.SQLite` 1.0.119

**Lib/ 目录**: `MvCameraControl.Net.dll` · `SciCamera.Net.dll` · `EPPlus.dll` · `log4net.dll` · `Newtonsoft.Json.dll`

---

## 页面导航

| 页面 | Prism 路由 | 区域 | 功能说明 |
|------|-----------|------|----------|
| 主页 | `HomeView` | MainRegion | 设备状态概览、生产计数、CT 显示、流程启停控制 |
| 参数配置 | `ParameterView` | MainRegion | 系统参数/Modbus 参数/配方管理/参数编辑 |
| 运动调试 | `MotionDebugView` | MainRegion | 轴 Jog 控制、绝对/相对定位、伺服使能、状态监控 |
| 数据库 | `DataBaseView` | MainRegion | 生产数据查询与管理 |
| 生产信息 | `ProduceInfoView` | MainRegion | 工单/产品/良率信息 |
| 日志 | `LogView` | MainRegion | 日志查询与导出 |
| 日志控件 | `LogControl` | ToolRegion | 底部实时日志输出 (MainLogOutput 事件订阅) |

---

## 版权声明

> Copyright (c) 2024 Mr. Xu YiFan
>
> 本软件仅用于演示和教育目的，禁止商业用途。未经作者授权，禁止修改、复制或重新分发。
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
