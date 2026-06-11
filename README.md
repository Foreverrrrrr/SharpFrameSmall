# SharpFrameSmall

<div align="center">

**面向工业自动化产线的 WPF 上位机框架**

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/UI-WPF-purple.svg)](https://github.com/dotnet/wpf)
[![Prism](https://img.shields.io/badge/MVVM-Prism%208.0-orange.svg)](https://prismlibrary.com/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE.txt)

</div>

---

## 项目简介

SharpFrameSmall 是一个面向工业自动化生产线的 WPF 桌面应用程序框架，整合了机器视觉、PLC 通信、MES 对接、流程编排、参数管理和日志追溯等核心功能。框架采用 **Prism MVVM** 架构，内置了一套基于反射的轻量级流程引擎，可快速搭建从设备层到业务层的全栈工业控制上位机。

### 典型应用场景

> 工控机通过本软件连接 **PLC（Modbus TCP）**、**工业相机（海康/OPT）**、**MES 系统（SFCS）**，利用 OpenCV 进行视觉检测，基于自定义流程图引擎驱动自动化生产流程，配合参数配方管理、多级日志追溯和用户权限管控完成完整的产线自动化。

---

## 技术栈

| 类别 | 技术 |
|------|------|
| **运行时** | .NET Framework 4.8 (x64) |
| **UI 框架** | WPF + [MaterialDesignThemes](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) 4.8 |
| **MVVM** | [Prism 8.0](https://github.com/PrismLibrary/Prism) (DryIoc IoC) |
| **行为绑定** | Microsoft.Xaml.Behaviors.Wpf 1.1 |
| **机器视觉** | [OpenCVSharp](https://github.com/shimat/opencvsharp) + MvCameraControl.Net (海康 SDK) + SciCamera.Net (OPT SDK) |
| **工业通信** | Modbus TCP · 异步 TCP/IP · HTTP |
| **数据库** | SQL Server · SQLite · Excel (EPPlus) |
| **日志** | [log4net](https://logging.apache.org/log4net/) + 自定义结构化 JSON 日志 |
| **序列化** | [Newtonsoft.Json](https://www.newtonsoft.com/json) 13.0 |
| **自动更新** | 在线版本检查 + 热更新模块 |

---

## 项目结构

```
SharpFrameSmall/
├── Common/                          # 通用工具库
│   ├── Camera/
│   │   ├── Haikang.cs               # 海康相机 SDK 封装 (GIGE)
│   │   └── OPT.cs                    # OPT 相机 SDK 封装
│   ├── Commumication/
│   │   ├── AsyncSharpTcpClient.cs    # 异步 TCP 客户端
│   │   ├── AsyncSharpTcpServer.cs    # 异步 TCP 服务器
│   │   └── Http_Client.cs            # HTTP 请求客户端
│   ├── ModbusTCP/
│   │   ├── ModbusTCPClientPlus.cs    # Modbus TCP 客户端 (含触发器引擎)
│   │   ├── PLC_ModbusTCP.cs          # PLC Modbus TCP 通信
│   │   └── Package.cs                # Modbus 数据包封装
│   ├── SFCS/
│   │   └── SFCSClient.cs             # MES/SFCS WebService 客户端
│   ├── SQL/
│   │   ├── SQL_Server.cs             # SQL Server 操作封装
│   │   └── SQL_Sqlite.cs             # SQLite 操作封装
│   ├── OpencvHandle.cs               # OpenCV 视觉处理 (相机标定/畸变矫正)
│   ├── ExcelTool.cs                  # Excel 读写工具
│   ├── Geometry.cs                   # 几何计算工具
│   ├── ProductionInformation.cs      # 生产信息管理 (班次/工单)
│   ├── UserManagement.cs             # 用户账户管理 (SQLite)
│   └── AutoStartHelper.cs            # 开机自启动
├── Logic/                            # 业务逻辑层
│   ├── Base/
│   │   ├── ProcessBase.cs            # ★ 流程引擎核心基类
│   │   ├── ProductionThreadBase.cs   # 流程线程标记特性与运行时信息
│   │   ├── DataConfigurationBase.cs  # 数据配置基类
│   │   └── Exchange.cs              # 状态信号交换层
│   └── AutoMain/
│       └── Auto.cs                   # 自动流程示例
├── FlowExecution/                    # 流程图执行引擎
│   ├── FlowNode.cs                   # 有向图节点定义
│   ├── FlowGraphPath.cs             # 图路径分析
│   ├── ComboBoxNodeViewModel.cs      # 节点选择 ViewModel
│   └── RoutingNodeViewModel.cs       # 路由节点 ViewModel
├── Structure/                        # 数据结构层
│   └── Parameter/
│       ├── Parameter Structure/      # 参数框架 (IParameter -> ParameterBase -> ValueParameter)
│       ├── SystemParameter.cs        # 系统参数
│       ├── ModbusParameter.cs        # Modbus 参数绑定
│       ├── LabelParameter.cs         # 标签参数
│       ├── AttdefParameter.cs        # 属性定义参数
│       ├── ParameterConfig.cs        # 参数配置管理
│       ├── ParameterJsonTool.cs      # JSON 配方管理
│       └── ParameterStore.cs         # 参数持久化存储
├── ViewModels/                       # 视图模型 (MVVM)
│   ├── MainWindowViewModel.cs        # 主窗口 ViewModel (启动/暂停/停止/复位/急停)
│   ├── HomeViewModel.cs              # 主页状态显示
│   ├── ParameterViewModel.cs         # 参数管理
│   ├── MotionDebugViewModel.cs       # 运动控制调试
│   ├── DataBaseViewModel.cs          # 数据库视图
│   └── ParameterDialog/              # 弹窗 ViewModel (登录/用户/配方/错误码)
├── Views/                            # WPF 视图
│   ├── MainWindow.xaml               # 主窗口 (左侧导航 + 区域容器)
│   ├── HomeView.xaml                 # 主页 (状态监控)
│   ├── ParameterView.xaml            # 参数配置页
│   ├── MotionDebugView.xaml          # 运动调试页
│   ├── DataBaseView.xaml             # 数据库管理页
│   ├── LogControl.xaml               # 日志输出控件
│   ├── ParameterDialog/              # 弹窗视图 (登录/用户/配方/错误码)
│   └── SharpStyle/                   # ★ 自定义 UI 组件库
│       ├── AxisControl/              # 轴控制/监控面板
│       ├── IOControl/                 # IO 信号监控面板
│       ├── Notification/             # 多级通知系统 (Info/Warning/Error/Fatal)
│       ├── OpenVision/               # 视觉图像显示控件
│       └── ParameterDataGrid/        # 参数 DataGrid 控件
├── LogsFolder/                       # 日志系统
│   ├── LogsManage.cs                 # 日志管理器 (异步写盘 + 过期清理)
│   ├── LogsEventJson.cs              # 事件日志结构
│   ├── LogsProductJson.cs            # 产品日志结构
│   ├── LogsRecipeJson.cs             # 配方变更日志结构
│   ├── LogsResultJson.cs             # 生产结果日志结构
│   ├── ScrewdriverJson.cs            # 螺丝刀扭矩数据日志
│   ├── PLC_ModbusTCP.cs              # PLC 通信日志
│   └── ErrorCode.cs                  # 错误码定义
├── Log4Net/                          # log4net 日志配置
├── language/                         # 多语言资源
│   ├── LocalizationService.cs        # 语言切换服务
│   ├── zh-CN.xaml                    # 简体中文
│   ├── zh-TW.xaml                    # 繁体中文
│   ├── en-US.xaml                    # 英文
│   └── vi-VN.xaml                    # 越南语
├── Update/                           # 自动更新服务
│   ├── CheckUpdate.cs                # 版本检查
│   └── UpdateServer.cs               # 更新服务器
├── Themes/Generic.xaml               # WPF 全局样式
├── app.config                        # 应用程序配置
└── ExportNuGet.ps1                   # NuGet 包导出脚本
```

---

## 核心特性

### 1. 流程引擎 (ProcessBase)

框架最核心的模块，提供了一套基于反射的工业流程控制框架：

- **全局状态机** — 基于枚举的类型安全信号系统，使用 65535 容量的布尔数组作为数据池，支持 `SetEnum` / `AwaitEnum` / `GetEnumValue` 方法
- **自动线程管理** — 通过 `[ProductionThread]` 特性标记流程方法，框架自动扫描子类并启动后台线程，支持暂停/恢复/销毁
- **共享参数系统** — `ConcurrentDictionary<Type, object>` 实现类型安全的跨流程、跨线程参数共享
- **异常自恢复** — 线程 `ThreadAbortException` 时自动重启实例，保证产线不中断

```csharp
public class Auto : ProcessBase
{
    public enum MyEnum { One, Two }

    protected override void Main(ProcessBase thread)
    {
        // 设置状态机信号
        SetEnum(MyEnum.One, true);

        // 等待其他流程的信号
        AwaitEnum(MyEnum.Two, true, token: ThreadToken, time: 5000);

        // 获取共享参数
        var aggregator = GetShared<IEventAggregator>();
    }
}
```

### 2. 工业相机集成

- **海康 GIGE 相机** — 完整封装 MvCameraControl.Net SDK
  - 在线设备枚举、批量打开/关闭
  - 连续采集 / 单帧触发 / 软触发 / 硬触发 (Line0)
  - 多像素格式转换：Mono8 / BGR8 / RGB8 / BayerRG8 -> `WriteableBitmap`
  - 图像回调直接渲染到 WPF 控件句柄
- **OPT 相机** — SciCamera.Net SDK 封装

### 3. OpenCV 视觉处理

- WPF 兼容的图像格式转换 (`Bitmap` <-> `Mat` <-> `ImageSource`)
- 相机棋盘格标定（角点检测 -> 亚像素精炼 -> 内参矩阵 -> 畸变矫正）
- 像素/mm 尺寸标定

### 4. Modbus TCP 通信

- 支持所有常用功能码：`0x01`~`0x06`, `0x0F`, `0x10`
- 多字节序支持：ABCD / BADC / CDAB / DCBA
- 内置触发器引擎：值变化监控（Equal, NotEqual, GreaterThan, Changed 等），支持 Bit / Bool / Int16~64 / Float / Double / String 类型

### 5. 参数配方管理

层次化参数框架，支持 JSON 持久化、公式计算、属性定义和 Modbus 地址绑定。

### 6. 用户权限系统

基于 SQLite 的用户账户管理，支持多级权限（Admin / Engineer / Supervisor / Operator），默认至少保留一个管理员账户。

### 7. 多语言支持

简体中文 · 繁体中文 · English · Tieng Viet，可通过 UI 下拉框实时切换。

### 8. 结构化日志

- **事件日志** — CSV 格式，按天归档
- **产品日志** — JSON 格式，含 USN_ID 追溯
- **生产结果** — JSON 格式，按 Pass/Fail 分类
- **配方变更** — JSON 格式，记录每次修改
- 自动过期清理（默认 120 天）

### 9. 自定义 UI 组件

- **轴控制面板** — 支持点动/绝对定位/状态监控
- **IO 监控面板** — 实时信号状态监视
- **通知系统** — 四级通知（Info / Warning / Error / Fatal），支持定时自动消失
- **视觉显示控件** — 基于 WriteableBitmap 的高性能图像渲染

### 10. 运动控制调试

独立的运动控制调试页面，支持轴的 Jog 操作和参数设置。

---

## 快速开始

### 环境要求

- Windows 7/10/11 (x64)
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)
- Visual Studio 2019+ (推荐)

### 构建与运行

```bash
# 克隆仓库
git clone https://github.com/Foreverrrrrr/SharpFrameSmall.git

# 使用 Visual Studio 打开解决方案
start SharpFrameSmall.sln

# 或使用 MSBuild 命令行构建
msbuild SharpFrameSmall.sln /p:Configuration=Release /p:Platform=x64
```

### 外部依赖

项目 `Lib/` 目录下的 DLL：
- `MvCameraControl.Net.dll` — 海康相机 SDK
- `SciCamera.Net.dll` — OPT 相机 SDK
- `EPPlus.dll` — Excel 读写
- `log4net.dll` — 日志框架
- `Newtonsoft.Json.dll` — JSON 序列化

NuGet 包：
- `MaterialDesignThemes` 4.8.0
- `Prism.DryIoc` 8.0.0
- `Microsoft.Xaml.Behaviors.Wpf` 1.1.135
- `System.Data.SQLite` 1.0.119

---

## 页面导航

| 页面 | 路由名称 | 说明 |
|------|----------|------|
| 主页 | `HomeView` | 设备状态概览、生产计数 |
| 参数配置 | `ParameterView` | 配方/参数/Modbus 配置 |
| 运动调试 | `MotionDebugView` | 轴控制与调试 |
| 数据库 | `DataBaseView` | 数据查询与管理 |
| 生产信息 | `ProduceInfoView` | 工单/产品信息 |
| 日志 | `LogView` | 日志查询与导出 |

---

## 版权声明

> Copyright (c) 2024 Mr. Xu YiFan
>
> 本软件仅用于演示和教育目的，禁止商业用途。未经作者授权，禁止修改、复制或重新分发。
> 如有问题或建议，请联系：awalkingonthecloud@gmail.com

---

## 致谢

- [Prism Library](https://prismlibrary.com/) — MVVM 框架
- [Material Design In XAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit) — UI 主题
- [OpenCVSharp](https://github.com/shimat/opencvsharp) — .NET 版 OpenCV
- [log4net](https://logging.apache.org/log4net/) — 日志框架
- [EPPlus](https://github.com/EPPlusSoftware/EPPlus) — Excel 读写库
