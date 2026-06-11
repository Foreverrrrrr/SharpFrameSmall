using System;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SharpFrameSmall.Common.SFCS
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://localhost/Tester.WebService/WebService", ConfigurationName="ServiceReference.WebServiceSoap")]
    public interface WebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLinkUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetLinkUSNResponse GetLinkUSN(SharpFrameSmall.Common.SFCS.GetLinkUSNRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLinkUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLinkUSNResponse> GetLinkUSNAsync(SharpFrameSmall.Common.SFCS.GetLinkUSNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BarcodeValidationWithGivenCategory", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string BarcodeValidationWithGivenCategory(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, string CheckUsedCategory, string Line, string Workstation, string UserID, string ValidateCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BarcodeValidationWithGivenCategory", ReplyAction="*")]
        System.Threading.Tasks.Task<string> BarcodeValidationWithGivenCategoryAsync(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, string CheckUsedCategory, string Line, string Workstation, string UserID, string ValidateCategory);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SetMoOnLine", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SetMoOnLine(string MO, string Line, string UserID, bool CheckDipCpnFlag, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SetMoOnLine", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SetMoOnLineAsync(string MO, string Line, string UserID, bool CheckDipCpnFlag, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkWorkingPalletCSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LinkWorkingPalletCSN(string MO, string WorkingPalletID, string ComponentSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkWorkingPalletCSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LinkWorkingPalletCSNAsync(string MO, string WorkingPalletID, string ComponentSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapPalletIDUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SwapPalletIDUSN(string WorkingPalletID, string UnitSerialNumber, string UserID, string WorkStation, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapPalletIDUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SwapPalletIDUSNAsync(string WorkingPalletID, string UnitSerialNumber, string UserID, string WorkStation, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapWorkingPallet", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SwapWorkingPallet(string WorkingPalletID1, string WorkingPalletID2, string StageCode, string UserID, string WorkStation, bool CheckMOFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapWorkingPallet", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SwapWorkingPalletAsync(string WorkingPalletID1, string WorkingPalletID2, string StageCode, string UserID, string WorkStation, bool CheckMOFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UnlinkWorkingPallet", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UnlinkWorkingPallet(string WorkingPalletID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UnlinkWorkingPallet", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UnlinkWorkingPalletAsync(string WorkingPalletID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RequestLabelPrint", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string RequestLabelPrint(string UnitSerialNumber, int LabelType, int LabelCount, int CartonLevel, string StageCode, string PrintWorkStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RequestLabelPrint", ReplyAction="*")]
        System.Threading.Tasks.Task<string> RequestLabelPrintAsync(string UnitSerialNumber, int LabelType, int LabelCount, int CartonLevel, string StageCode, string PrintWorkStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IsCPNComplete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string IsCPNComplete(string UnitSerialNumber, string StageCode, bool SequenceControl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IsCPNComplete", ReplyAction="*")]
        System.Threading.Tasks.Task<string> IsCPNCompleteAsync(string UnitSerialNumber, string StageCode, bool SequenceControl);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AssignUserGroupCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string AssignUserGroupCode(string UnitSerialNumber, string StageCode, string CTSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AssignUserGroupCode", ReplyAction="*")]
        System.Threading.Tasks.Task<string> AssignUserGroupCodeAsync(string UnitSerialNumber, string StageCode, string CTSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAndProcessKtlOutEvent", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventResponse GetAndProcessKtlOutEvent(SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAndProcessKtlOutEvent", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventResponse> GetAndProcessKtlOutEventAsync(SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetScrapQualify", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetScrapQualify(string FixtureID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetScrapQualify", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetScrapQualifyAsync(string FixtureID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateFixtureStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateFixtureStatus(string FixtureID, int Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateFixtureStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateFixtureStatusAsync(string FixtureID, int Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IACSReturnPrepareMaterialStatusToSF" +
            "CS", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string IACSReturnPrepareMaterialStatusToSFCS(string Plant, string SequenceID, string Status, string ActualCPN, string ActualQty, string ActualStorageLoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IACSReturnPrepareMaterialStatusToSF" +
            "CS", ReplyAction="*")]
        System.Threading.Tasks.Task<string> IACSReturnPrepareMaterialStatusToSFCSAsync(string Plant, string SequenceID, string Status, string ActualCPN, string ActualQty, string ActualStorageLoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLogFileInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTestLogFileInfo(string UnitSerialNumber, string Stage, string FileFolder, string FileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLogFileInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTestLogFileInfoAsync(string UnitSerialNumber, string Stage, string FileFolder, string FileName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/InsertHoldByUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string InsertHoldByUSN(string UnitSerialNumber, string StageCode, string HoldStage, string UserID, string HoldReason);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/InsertHoldByUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> InsertHoldByUSNAsync(string UnitSerialNumber, string StageCode, string HoldStage, string UserID, string HoldReason);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RaiseMTDLRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsRaiseMTDLRequest[] RaiseMTDLRequest(string USN, string Stage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RaiseMTDLRequest", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsRaiseMTDLRequest[]> RaiseMTDLRequestAsync(string USN, string Stage);
        
        // CODEGEN: 参数“TestItem”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMTDLResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse UploadMTDLResult(SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMTDLResult", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse> UploadMTDLResultAsync(SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorPowerConsumption", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadMonitorPowerConsumption(string USN, string Line, string PowerConsumption, string Stagecode, string Workststion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorPowerConsumption", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadMonitorPowerConsumptionAsync(string USN, string Line, string PowerConsumption, string Stagecode, string Workststion);
        
        // CODEGEN: 参数“DynamicParameters”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/DynamicDBFunction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse DynamicDBFunction(SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/DynamicDBFunction", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse> DynamicDBFunctionAsync(SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetWebServiceInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsWSInfo GetWebServiceInfo();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetWebServiceInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsWSInfo> GetWebServiceInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetWebServiceConfig", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsWSConfig[] GetWebServiceConfig();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetWebServiceConfig", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsWSConfig[]> GetWebServiceConfigAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetNextStage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetNextStage(string UnitSerialNumber, string StageCode, string PIAStageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetNextStage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetNextStageAsync(string UnitSerialNumber, string StageCode, string PIAStageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoGenealogy", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsMO GetMoGenealogy(string ManufactureOrder, string StageCode, SharpFrameSmall.Common.SFCS.clsMOCheckFlag MOCheckFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoGenealogy", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMO> GetMoGenealogyAsync(string ManufactureOrder, string StageCode, SharpFrameSmall.Common.SFCS.clsMOCheckFlag MOCheckFlag);
        
        // CODEGEN: 消息 CheckInByUser 的包装名称(CheckInByUser)以后生成的消息协定与默认值(CheckIn)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckInByUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CheckInByUser1 CheckIn(SharpFrameSmall.Common.SFCS.CheckInByUser request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckInByUser", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckInByUser1> CheckInAsync(SharpFrameSmall.Common.SFCS.CheckInByUser request);
        
        // CODEGEN: 消息 CheckOutByUser 的包装名称(CheckOutByUser)以后生成的消息协定与默认值(CheckOut)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckOutByUser", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CheckOutByUser1 CheckOut(SharpFrameSmall.Common.SFCS.CheckOutByUser request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckOutByUser", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckOutByUser1> CheckOutAsync(SharpFrameSmall.Common.SFCS.CheckOutByUser request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNGenealogyBasic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsUSN GetUSNGenealogyBasic(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNGenealogyBasic", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsUSN> GetUSNGenealogyBasicAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadATEData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadATEData(string UnitSerialNumber, string Result, string Line, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadATEData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadATEDataAsync(string UnitSerialNumber, string Result, string Line, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadATEDataForTRI", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadATEDataForTRI(string UnitSerialNumber, string Result, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadATEDataForTRI", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadATEDataForTRIAsync(string UnitSerialNumber, string Result, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckAutoPickUpRoute", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.stcD2PickUpReturn CheckAutoPickUpRoute(string PPID, string WorkstationID, string Line);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckAutoPickUpRoute", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcD2PickUpReturn> CheckAutoPickUpRouteAsync(string PPID, string WorkstationID, string Line);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/DeductCPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.stcDeductCPN DeductCPN(string PPID, string WorkstationID, string Line, string PartNumber, string LocationID, string PositionX, string PositionY);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/DeductCPN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcDeductCPN> DeductCPNAsync(string PPID, string WorkstationID, string Line, string PartNumber, string LocationID, string PositionX, string PositionY);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLocInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.stcGetLocInfo GetLocInfo(string LocationID, string PartNumber, string Line);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLocInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcGetLocInfo> GetLocInfoAsync(string LocationID, string PartNumber, string Line);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTrnStartDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTrnStartDate(string UnitSerialNumber, string StageCode, string UserID, string WorkStation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTrnStartDate", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTrnStartDateAsync(string UnitSerialNumber, string StageCode, string UserID, string WorkStation);
        
        // CODEGEN: 消息 UploadTrnStartDatewithTrnStartDate 的包装名称(UploadTrnStartDatewithTrnStartDate)以后生成的消息协定与默认值(UploadTrnStartDate1)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTrnStartDatewithTrnStartDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1 UploadTrnStartDate1(SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTrnStartDatewithTrnStartDate", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1> UploadTrnStartDate1Async(SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate request);
        
        // CODEGEN: 参数“InfoNameValue”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BatchUploadUSNInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse BatchUploadUSNInfo(SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BatchUploadUSNInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse> BatchUploadUSNInfoAsync(SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Compare", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompareResponse Compare(SharpFrameSmall.Common.SFCS.CompareRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Compare", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompareResponse> CompareAsync(SharpFrameSmall.Common.SFCS.CompareRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SFCAddNewUnit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SFCAddNewUnit(string UnitSerialNumber, string MO, string StageCode, string Workstation, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SFCAddNewUnit", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SFCAddNewUnitAsync(string UnitSerialNumber, string MO, string StageCode, string Workstation, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCompareItemsByUsn", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsKeyItem[] GetCompareItemsByUsn(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCompareItemsByUsn", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsKeyItem[]> GetCompareItemsByUsnAsync(string UnitSerialNumber, string StageCode);
        
        // CODEGEN: 参数“TestEquipments”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestEquipments", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse UploadTestEquipments(SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestEquipments", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse> UploadTestEquipmentsAsync(SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest request);
        
        // CODEGEN: 参数“TestData”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadTestDataResponse UploadTestData(SharpFrameSmall.Common.SFCS.UploadTestDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestData", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestDataResponse> UploadTestDataAsync(SharpFrameSmall.Common.SFCS.UploadTestDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestEquipmentsWithString", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTestEquipmentsWithString(string StageCode, string TestEquipments, string Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestEquipmentsWithString", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTestEquipmentsWithStringAsync(string StageCode, string TestEquipments, string Model);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestDataWithString", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTestDataWithString(string StageCode, string UnitSerialNumber, string TestDataType, string TestData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestDataWithString", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTestDataWithStringAsync(string StageCode, string UnitSerialNumber, string TestDataType, string TestData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFGCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadFGCode(string ProductCode, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFGCode", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadFGCodeAsync(string ProductCode, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPreparedMOList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetPreparedMOListResponse GetPreparedMOList(SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPreparedMOList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPreparedMOListResponse> GetPreparedMOListAsync(SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNlistByRange", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNlistByRangeResponse GetUSNlistByRange(SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNlistByRange", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNlistByRangeResponse> GetUSNlistByRangeAsync(SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackUnitState", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRuninRackUnitState(string UnitSerialNumber, string StageCode, int State, int TimeOutMinutes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackUnitState", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRuninRackUnitStateAsync(string UnitSerialNumber, string StageCode, int State, int TimeOutMinutes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFixtureUsedTimes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadFixtureUsedTimes(string UnitSerialNumber, string StageCode, string ECID, int UsedTimes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFixtureUsedTimes", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadFixtureUsedTimesAsync(string UnitSerialNumber, string StageCode, string ECID, int UsedTimes);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckSFCDLSkill", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckSFCDLSkill(string EmployeeID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckSFCDLSkill", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckSFCDLSkillAsync(string EmployeeID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadSonyIDData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadSonyIDData(string UnitSerialNumber, string StageCode, string Workstation, string IDCode, string IDData, string IDTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadSonyIDData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadSonyIDDataAsync(string UnitSerialNumber, string StageCode, string Workstation, string IDCode, string IDData, string IDTag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadSonyIDDatas", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadSonyIDDatas(string UnitSerialNumber, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsSonyIDData[] SonyIDDatas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadSonyIDDatas", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadSonyIDDatasAsync(string UnitSerialNumber, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsSonyIDData[] SonyIDDatas);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateSonyKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.AllocateSonyKeyResponse AllocateSonyKey(SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateSonyKey", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateSonyKeyResponse> AllocateSonyKeyAsync(SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateSonyKeys", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.AllocateSonyKeysResponse AllocateSonyKeys(SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateSonyKeys", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateSonyKeysResponse> AllocateSonyKeysAsync(SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BindingUSNRIPalletID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDResponse BindingUSNRIPalletID(SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BindingUSNRIPalletID", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDResponse> BindingUSNRIPalletIDAsync(SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkUSNRIPalletID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LinkUSNRIPalletID(string StageCode, string RIPalletID, string UnitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkUSNRIPalletID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LinkUSNRIPalletIDAsync(string StageCode, string RIPalletID, string UnitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDcsChassisInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetDcsChassisInfoResponse GetDcsChassisInfo(SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDcsChassisInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetDcsChassisInfoResponse> GetDcsChassisInfoAsync(SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiNewSiList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCfiNewSiList(string NeedRecordQty);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiNewSiList", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetCfiNewSiListAsync(string NeedRecordQty);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiSiInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsSINumberInfo GetCfiSiInfo(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiSiInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsSINumberInfo> GetCfiSiInfoAsync(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateCfiSiStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateCfiSiStatus(string SINumber, string SISyncStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateCfiSiStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateCfiSiStatusAsync(string SINumber, string SISyncStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsUnitCfiData GetCfiData(string UnitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCfiData", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsUnitCfiData> GetCfiDataAsync(string UnitSerialNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCfiHwInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadCfiHwInfo(SharpFrameSmall.Common.SFCS.clsUnitCfiHwInfo UnitCfiHwInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCfiHwInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadCfiHwInfoAsync(SharpFrameSmall.Common.SFCS.clsUnitCfiHwInfo UnitCfiHwInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadBurnInRoomTemperature", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadBurnInRoomTemperature(string BurnInRoomID, string Temperature);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadBurnInRoomTemperature", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadBurnInRoomTemperatureAsync(string BurnInRoomID, string Temperature);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IPCUSNPositionLinkage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string IPCUSNPositionLinkage(string USN, string PositionID, string Command, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/IPCUSNPositionLinkage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> IPCUSNPositionLinkageAsync(string USN, string PositionID, string Command, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckInOutIPCBurnInRoom", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckInOutIPCBurnInRoom(string CartID, string LocationID, string Command, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckInOutIPCBurnInRoom", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckInOutIPCBurnInRoomAsync(string CartID, string LocationID, string Command, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/TransferIPCBurnInLocation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string TransferIPCBurnInLocation(string OriginalLocID, string NewLocID, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/TransferIPCBurnInLocation", ReplyAction="*")]
        System.Threading.Tasks.Task<string> TransferIPCBurnInLocationAsync(string OriginalLocID, string NewLocID, string UserID);
        
        // CODEGEN: 参数“UnitSerialNumbers”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkMultiBoardUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse LinkMultiBoardUSN(SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkMultiBoardUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse> LinkMultiBoardUSNAsync(SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest request);
        
        // CODEGEN: 参数“UnitSerialNumbers”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RequstJDMD3FileJob", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse RequstJDMD3FileJob(SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RequstJDMD3FileJob", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse> RequstJDMD3FileJobAsync(SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetJDMD3FileJobInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsJDMD3FileJobInfo[] GetJDMD3FileJobInfo(string RequestPlantCode, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetJDMD3FileJobInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsJDMD3FileJobInfo[]> GetJDMD3FileJobInfoAsync(string RequestPlantCode, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateJDMD3FileJobStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateJDMD3FileJobStatus(string RequstID, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateJDMD3FileJobStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateJDMD3FileJobStatusAsync(string RequstID, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAISImageFileName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAISImageFileName(string UnitSerialNumber, string Category, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAISImageFileName", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetAISImageFileNameAsync(string UnitSerialNumber, string Category, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAISImageFileNameSplit", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAISImageFileNameSplit(string UnitSerialNumber, string Category, string StageCode, string FileNameSplitter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAISImageFileNameSplit", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetAISImageFileNameSplitAsync(string UnitSerialNumber, string Category, string StageCode, string FileNameSplitter);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetIDValueByMO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsMOIDValue GetIDValueByMO(string MO, string StageCode, int IDType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetIDValueByMO", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMOIDValue> GetIDValueByMOAsync(string MO, string StageCode, int IDType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetICPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetICPN(string UnitSerialNumber, string StageCode, string Location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetICPN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetICPNAsync(string UnitSerialNumber, string StageCode, string Location);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEngravingInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsEngravingInfo GetEngravingInfo(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEngravingInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsEngravingInfo> GetEngravingInfoAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMacSecurityKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetMacSecurityKey(string MAC, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMacSecurityKey", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetMacSecurityKeyAsync(string MAC, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRendyResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRendyResult(string UnitSerialNumber, string StageCode, string Workstation, string Name, string SubName, string MinValue, string MaxValue, string MeasuredValue, string Unit, string UserID, bool Pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRendyResult", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRendyResultAsync(string UnitSerialNumber, string StageCode, string Workstation, string Name, string SubName, string MinValue, string MaxValue, string MeasuredValue, string Unit, string UserID, bool Pass);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRendyAntiTheftCCID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRendyAntiTheftCCID(string UnitSerialNumber, string StageCode, string Workstation, string ProductSerialNumber, string AntiTheftCode, string CCID, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRendyAntiTheftCCID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRendyAntiTheftCCIDAsync(string UnitSerialNumber, string StageCode, string Workstation, string ProductSerialNumber, string AntiTheftCode, string CCID, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTpsUpnInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTpsUpnInfo(string UnitPartNumber, string StageCode, string InfoName, string InfoValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTpsUpnInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTpsUpnInfoAsync(string UnitPartNumber, string StageCode, string InfoName, string InfoValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTeNotReadyMoList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListResponse GetTeNotReadyMoList(SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTeNotReadyMoList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListResponse> GetTeNotReadyMoListAsync(SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateTeReadyFlagByMo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateTeReadyFlagByMo(string MO, string StageCode, string TeProgramFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateTeReadyFlagByMo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateTeReadyFlagByMoAsync(string MO, string StageCode, string TeProgramFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoInfoByMo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetMoInfoByMo(string MO, string StageCode, string InfoName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoInfoByMo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetMoInfoByMoAsync(string MO, string StageCode, string InfoName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOItemByMo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetMOItemByMoResponse GetMOItemByMo(SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOItemByMo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMOItemByMoResponse> GetMOItemByMoAsync(SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTVKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetTVKeyResponse GetTVKey(SharpFrameSmall.Common.SFCS.GetTVKeyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTVKey", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTVKeyResponse> GetTVKeyAsync(SharpFrameSmall.Common.SFCS.GetTVKeyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVKey(string UnitSerialNumber, string StageCode, string WorkStation, SharpFrameSmall.Common.SFCS.clsTVKeyItem[] TVKeyItems, bool UniqueCheckFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVKey", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVKeyAsync(string UnitSerialNumber, string StageCode, string WorkStation, SharpFrameSmall.Common.SFCS.clsTVKeyItem[] TVKeyItems, bool UniqueCheckFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDefectUsnList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetDefectUsnListResponse GetDefectUsnList(SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDefectUsnList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetDefectUsnListResponse> GetDefectUsnListAsync(SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnDefect", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUsnDefectResponse GetUsnDefect(SharpFrameSmall.Common.SFCS.GetUsnDefectRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnDefect", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnDefectResponse> GetUsnDefectAsync(SharpFrameSmall.Common.SFCS.GetUsnDefectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RosaHddMoLinkCRUD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string RosaHddMoLinkCRUD(string MO, string HDDPPID, string CRUDType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RosaHddMoLinkCRUD", ReplyAction="*")]
        System.Threading.Tasks.Task<string> RosaHddMoLinkCRUDAsync(string MO, string HDDPPID, string CRUDType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastTransactionData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetLastTransactionDataResponse GetLastTransactionData(SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastTransactionData", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLastTransactionDataResponse> GetLastTransactionDataAsync(SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastFixtureId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetLastFixtureIdResponse GetLastFixtureId(SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastFixtureId", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLastFixtureIdResponse> GetLastFixtureIdAsync(SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnRepair", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUsnRepairResponse GetUsnRepair(SharpFrameSmall.Common.SFCS.GetUsnRepairRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnRepair", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnRepairResponse> GetUsnRepairAsync(SharpFrameSmall.Common.SFCS.GetUsnRepairRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnInfoAtStage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageResponse GetUsnInfoAtStage(SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnInfoAtStage", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageResponse> GetUsnInfoAtStageAsync(SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRfEquTestTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRfEquTestTime(string PlantCode, string UnitSerialNumber, string StageCode, string EquipmentId, string TestStage, string TestStartTime, string TestEndTime, bool TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRfEquTestTime", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRfEquTestTimeAsync(string PlantCode, string UnitSerialNumber, string StageCode, string EquipmentId, string TestStage, string TestStartTime, string TestEndTime, bool TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAutoStickLabelPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNResponse GetAutoStickLabelPN(SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAutoStickLabelPN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNResponse> GetAutoStickLabelPNAsync(SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RosaSwPoNackRuleCheck", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckResponse RosaSwPoNackRuleCheck(SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RosaSwPoNackRuleCheck", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckResponse> RosaSwPoNackRuleCheckAsync(SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateEDI860Signal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UpdateEDI860SignalResponse UpdateEDI860Signal(SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateEDI860Signal", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UpdateEDI860SignalResponse> UpdateEDI860SignalAsync(SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnById", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUsnByIdResponse GetUsnById(SharpFrameSmall.Common.SFCS.GetUsnByIdRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnById", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnByIdResponse> GetUsnByIdAsync(SharpFrameSmall.Common.SFCS.GetUsnByIdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotResponse UploadPcbLot(SharpFrameSmall.Common.SFCS.UploadPcbLotRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotResponse> UploadPcbLotAsync(SharpFrameSmall.Common.SFCS.UploadPcbLotRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot With PCB 2D Barcode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode1 UploadPcbLot1(SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot With PCB 2D Barcode", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode1> UploadPcbLot1Async(SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot With 2D Barcode(includ" +
            "e UnsealDate)", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate1 UploadPcbLotBy2DBarcode(SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadPcbLot With 2D Barcode(includ" +
            "e UnsealDate)", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate1> UploadPcbLotBy2DBarcodeAsync(SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadEngravingResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadEngravingResult(string UnitSerialNumber, string StageCode, string UserID, string EngravingResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadEngravingResult", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadEngravingResultAsync(string UnitSerialNumber, string StageCode, string UserID, string EngravingResult);
        
        // CODEGEN: 参数“InfoNameValues”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadAstroMoInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse UploadAstroMoInfo(SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadAstroMoInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse> UploadAstroMoInfoAsync(SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUpnInfoFromView", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewResponse GetUpnInfoFromView(SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUpnInfoFromView", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewResponse> GetUpnInfoFromViewAsync(SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetKeyInfoFromView", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewResponse GetKeyInfoFromView(SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetKeyInfoFromView", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewResponse> GetKeyInfoFromViewAsync(SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRuninRackStatus(string MAC, string StageCode, string RuninRackID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRuninRackStatusAsync(string MAC, string StageCode, string RuninRackID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAndroidKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.AllocateAndroidKeyResponse AllocateAndroidKey(SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAndroidKey", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAndroidKeyResponse> AllocateAndroidKeyAsync(SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckEngravingBoradBarcLotNo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckEngravingBoradBarcLotNo(string StageCode, string Barcode, string LotNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckEngravingBoradBarcLotNo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckEngravingBoradBarcLotNoAsync(string StageCode, string Barcode, string LotNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAwaitingUnitSnList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListResponse AllocateAwaitingUnitSnList(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAwaitingUnitSnList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListResponse> AllocateAwaitingUnitSnListAsync(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAwaitingUnitSnListForExtend" +
            "Code/Zack", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack1 AllocateAwaitingUnitSnListForExtendCode(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/AllocateAwaitingUnitSnListForExtend" +
            "Code/Zack", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack1> AllocateAwaitingUnitSnListForExtendCodeAsync(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCompleteEngravingUnitSn", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadCompleteEngravingUnitSn(string UnitSerialNumberList, string StageCode, string MachineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCompleteEngravingUnitSn", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadCompleteEngravingUnitSnAsync(string UnitSerialNumberList, string StageCode, string MachineID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoAndBoardInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoResponse GetMoAndBoardInfo(SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMoAndBoardInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoResponse> GetMoAndBoardInfoAsync(SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Get2SLabelInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.Get2SLabelInfoResponse Get2SLabelInfo(SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Get2SLabelInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.Get2SLabelInfoResponse> Get2SLabelInfoAsync(SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest request);
        
        // CODEGEN: 参数“Item2DBarcode”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Upload2SLabelInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse Upload2SLabelInfo(SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Upload2SLabelInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse> Upload2SLabelInfoAsync(SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnInformationList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUsnInformationListResponse GetUsnInformationList(SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnInformationList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnInformationListResponse> GetUsnInformationListAsync(SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTvDacDataList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetTvDacDataListResponse GetTvDacDataList(SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTvDacDataList", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTvDacDataListResponse> GetTvDacDataListAsync(SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SwapUSN(string UnitSerialNumber, string StageCode, string ViceUnitSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SwapUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SwapUSNAsync(string UnitSerialNumber, string StageCode, string ViceUnitSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEllaRackLoction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetEllaRackLoctionResponse GetEllaRackLoction(SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEllaRackLoction", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetEllaRackLoctionResponse> GetEllaRackLoctionAsync(SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadOCRInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadOCRInfo(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadOCRInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadOCRInfoAsync(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID);
        
        // CODEGEN: 消息 UploadOCRInfo_x0020_With_x0020_PCB_x0020_2D_x0020_Barcode 的包装名称(UploadOCRInfo_x0020_With_x0020_PCB_x0020_2D_x0020_Barcode)以后生成的消息协定与默认值(UploadOCRInfo1)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadOCRInfo With PCB 2D Barcode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1 UploadOCRInfo1(SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadOCRInfo With PCB 2D Barcode", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1> UploadOCRInfo1Async(SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetBomPnDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsBomPnDescription[] GetBomPnDescription(string TopPN, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetBomPnDescription", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsBomPnDescription[]> GetBomPnDescriptionAsync(string TopPN, string Level);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadBomTransferUPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadBomTransferUPN(string UnitPartNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadBomTransferUPN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadBomTransferUPNAsync(string UnitPartNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RecordLogMessage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string RecordLogMessage(string ProcessID, string FileName, string DocumentNumber, string Status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RecordLogMessage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> RecordLogMessageAsync(string ProcessID, string FileName, string DocumentNumber, string Status);
        
        // CODEGEN: 参数“MappingRelation”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RecordESOPInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse RecordESOPInfo(SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/RecordESOPInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse> RecordESOPInfoAsync(SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkUsnWorkingPalletId", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string LinkUsnWorkingPalletId(string UnitSerialNumber, string WorkingPalletID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/LinkUsnWorkingPalletId", ReplyAction="*")]
        System.Threading.Tasks.Task<string> LinkUsnWorkingPalletIdAsync(string UnitSerialNumber, string WorkingPalletID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDynamicData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetDynamicData(string DynQueryID, string CriteriaName, string CriteriaValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetDynamicData", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetDynamicDataAsync(string DynQueryID, string CriteriaName, string CriteriaValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckRoute", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckRoute(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckRoute", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckRouteAsync(string UnitSerialNumber, string StageCode);
        
        // CODEGEN: 参数“TrnDatas”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Complete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompleteResponse Complete(SharpFrameSmall.Common.SFCS.CompleteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/Complete", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteResponse> CompleteAsync(SharpFrameSmall.Common.SFCS.CompleteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BatchComplete", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string BatchComplete(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BatchComplete", ReplyAction="*")]
        System.Threading.Tasks.Task<string> BatchCompleteAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithSingleTrnData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CompleteWithSingleTrnData(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string TrnData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithSingleTrnData", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CompleteWithSingleTrnDataAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string TrnData);
        
        // CODEGEN: 参数“TrnDatas”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse CompleteWithDefectRemark(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse> CompleteWithDefectRemarkAsync(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest request);
        
        // CODEGEN: 消息 CompleteWithDefectRemark_x002F_Bios_x002F_Diag 的包装名称(CompleteWithDefectRemark_x002F_Bios_x002F_Diag)以后生成的消息协定与默认值(CompleteWithDefectRemark1)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark/Bios/Diag", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1 CompleteWithDefectRemark1(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark/Bios/Diag", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1> CompleteWithDefectRemark1Async(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag request);
        
        // CODEGEN: 消息 CompleteWithDefectRemark_x002F_Json 的包装名称(CompleteWithDefectRemark_x002F_Json)以后生成的消息协定与默认值(CompleteWithDefectRemark2)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark/Json", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1 CompleteWithDefectRemark2(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithDefectRemark/Json", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1> CompleteWithDefectRemark2Async(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson request);
        
        // CODEGEN: 参数“TrnDatas”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlArrayItemAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithErrorDescription", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse CompleteWithErrorDescription(SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CompleteWithErrorDescription", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse> CompleteWithErrorDescriptionAsync(SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVADC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVADC(string SerialNo, string Line, string StageCode, string Workstation, int Type1, int Type2, int ValueR, int ValueG, int ValueB);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVADC", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVADCAsync(string SerialNo, string Line, string StageCode, string Workstation, int Type1, int Type2, int ValueR, int ValueG, int ValueB);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVDAC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVDAC(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int RCut, int GCut, int BCut, int RGain, int GGain, int BGain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVDAC", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVDACAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int RCut, int GCut, int BCut, int RGain, int GGain, int BGain);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVQC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVQC(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVQC", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVQCAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVQCwithWhiteBalanceFlag", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVQCwithWhiteBalanceFlag(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVQCwithWhiteBalanceFlag", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVQCwithWhiteBalanceFlagAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorWhiteBalance", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadMonitorWhiteBalance(string UnitSerialNumber, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance, decimal Dark, int Contrast);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorWhiteBalance", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadMonitorWhiteBalanceAsync(string UnitSerialNumber, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance, decimal Dark, int Contrast);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVPowerRange", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVPowerRange(string OPID, string SerialNo, string Line, string Stage, string Workstation, int Type, int SubType, string TestItem, string Voltage, string Current, string PowerWatt, string PowerFactor, string Result, int TestItemIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVPowerRange", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVPowerRangeAsync(string OPID, string SerialNo, string Line, string Stage, string Workstation, int Type, int SubType, string TestItem, string Voltage, string Current, string PowerWatt, string PowerFactor, string Result, int TestItemIndex);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVHDCPKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVHDCPKey(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsHDCPKey[] HDCPKeys);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVHDCPKey", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVHDCPKeyAsync(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsHDCPKey[] HDCPKeys);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetHDCPKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetHDCPKeyResponse GetHDCPKey(SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetHDCPKey", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetHDCPKeyResponse> GetHDCPKeyAsync(SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVCIPlusKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTVCIPlusKey(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsCIPlusKey[] CIPlusKeys);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTVCIPlusKey", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTVCIPlusKeyAsync(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsCIPlusKey[] CIPlusKeys);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCIPlusKey", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetCIPlusKeyResponse GetCIPlusKey(SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCIPlusKey", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetCIPlusKeyResponse> GetCIPlusKeyAsync(SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNItem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetUSNItem(string UnitSerialNumber, string StageCode, string Category, string Sequence);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNItem", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetUSNItemAsync(string UnitSerialNumber, string StageCode, string Category, string Sequence);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNItem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadUSNItem(string UnitSerialNumber, string StageCode, string Category, string ComponentSerialNumber, int Sequence, int CheckUsed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNItem", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadUSNItemAsync(string UnitSerialNumber, string StageCode, string Category, string ComponentSerialNumber, int Sequence, int CheckUsed);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNItemWithBarcodeValidation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadUSNItemWithBarcodeValidation(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, bool Assembly, string CheckUsedCategory, string Line, string Workstation, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNItemWithBarcodeValidation", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadUSNItemWithBarcodeValidationAsync(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, bool Assembly, string CheckUsedCategory, string Line, string Workstation, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetUsnID(string UnitSerialNumber, string StageCode, int IDType, int Sequence);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetUsnIDAsync(string UnitSerialNumber, string StageCode, int IDType, int Sequence);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnIdWithoutCombine", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string[] GetUsnIdWithoutCombine(string UnitSerialNumber, string StageCode, string Category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnIdWithoutCombine", ReplyAction="*")]
        System.Threading.Tasks.Task<string[]> GetUsnIdWithoutCombineAsync(string UnitSerialNumber, string StageCode, string Category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetHDCPFileName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetHDCPFileName(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetHDCPFileName", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetHDCPFileNameAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFixtureID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.UploadFixtureIDResponse UploadFixtureID(SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadFixtureID", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadFixtureIDResponse> UploadFixtureIDAsync(SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckFixtureID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckFixtureID(string StageCode, string FixtureID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckFixtureID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckFixtureIDAsync(string StageCode, string FixtureID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateFixtureIDPasscount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        void UpdateFixtureIDPasscount(string UnitSerialNumber, string StageCode, string FixtureIDSeq);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateFixtureIDPasscount", ReplyAction="*")]
        System.Threading.Tasks.Task UpdateFixtureIDPasscountAsync(string UnitSerialNumber, string StageCode, string FixtureIDSeq);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadVolTage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadVolTage(string UnitSerialNumber, string StageCode, string TestData, string TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadVolTage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadVolTageAsync(string UnitSerialNumber, string StageCode, string TestData, string TestResult);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSKeyValue", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTPSKeyValue(string SerialNo, string Stage, string TestType, string Key, string KeyVal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSKeyValue", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTPSKeyValueAsync(string SerialNo, string Stage, string TestType, string Key, string KeyVal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSLog", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTPSLog(string SerialNo, string Stage, string ErrorID, string ErrorMsg, string TesterID, string StationID, string Model, string SWConfigRev, string TestSWConfigRev, string TestHostConfig, string TestHostSWConfigVer, string FWVer, string CPUID, string FROMSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSLog", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTPSLogAsync(string SerialNo, string Stage, string ErrorID, string ErrorMsg, string TesterID, string StationID, string Model, string SWConfigRev, string TestSWConfigRev, string TestHostConfig, string TestHostSWConfigVer, string FWVer, string CPUID, string FROMSize);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSRetest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTPSRetest(string SerialNo, string Stage, string TestType, string Item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTPSRetest", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTPSRetestAsync(string SerialNo, string Stage, string TestType, string Item);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckOPID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool CheckOPID(string OperationID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckOPID", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> CheckOPIDAsync(string OperationID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnGenealogy", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsMO1 GetUsnGenealogy(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUsnGenealogy", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMO1> GetUsnGenealogyAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEDIDFilename", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEDIDFilename(string ProductCode, string PortType, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEDIDFilename", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEDIDFilenameAsync(string ProductCode, string PortType, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadEDIDResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadEDIDResult(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadEDIDResult", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadEDIDResultAsync(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorEDID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadMonitorEDID(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version, string EDID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorEDID", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadMonitorEDIDAsync(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version, string EDID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLog", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTestLog(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLog", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTestLogAsync(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLogWithChildUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadTestLogWithChildUSN(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark, string ChildUSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadTestLogWithChildUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadTestLogWithChildUSNAsync(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark, string ChildUSN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackUnitStartDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadRuninRackUnitStartDate(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadRuninRackUnitStartDate", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadRuninRackUnitStartDateAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckTestFixture", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckTestFixture(string FixtureGroupID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckTestFixture", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckTestFixtureAsync(string FixtureGroupID, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadUSNInfo(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadUSNInfoAsync(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNInfoWithUniqueCheckFlag", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadUSNInfoWithUniqueCheckFlag(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue, bool UniqueCheck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadUSNInfoWithUniqueCheckFlag", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadUSNInfoWithUniqueCheckFlagAsync(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue, bool UniqueCheck);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetMOInfo(string UnitSerialNumber, string StageCode, string InfoName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetMOInfoAsync(string UnitSerialNumber, string StageCode, string InfoName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTransactionTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetTransactionTime(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTransactionTime", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetTransactionTimeAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SetReflowStage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string SetReflowStage(string UnitSerialNumber, string StageCode, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/SetReflowStage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> SetReflowStageAsync(string UnitSerialNumber, string StageCode, string UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSetCA210OffsetTable", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsCA210OffsetResult[] GetSetCA210OffsetTable(int Type, string Model, string ProbeSN, string StageCode, SharpFrameSmall.Common.SFCS.clsCA210OffsetCheckFlag CA210OffsetCheckFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSetCA210OffsetTable", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsCA210OffsetResult[]> GetSetCA210OffsetTableAsync(int Type, string Model, string ProbeSN, string StageCode, SharpFrameSmall.Common.SFCS.clsCA210OffsetCheckFlag CA210OffsetCheckFlag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTestSuiteInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult GetTestSuiteInfo(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTestSuiteInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult> GetTestSuiteInfoAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTestSuiteInfoWithDataSearchType", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult GetTestSuiteInfoWithDataSearchType(string UnitSerialNumber, string StageCode, string DataSerachType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTestSuiteInfoWithDataSearchType", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult> GetTestSuiteInfoWithDataSearchTypeAsync(string UnitSerialNumber, string StageCode, string DataSerachType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsGetUSNInfoResult GetUSNInfo(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetUSNInfoResult> GetUSNInfoAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOItem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsMOItem1[] GetMOItem(string UnitSerialNumber, string StageCode, string Category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMOItem", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMOItem1[]> GetMOItemAsync(string UnitSerialNumber, string StageCode, string Category);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorLpByUsn", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadMonitorLpByUsn(string Line, string Stage, string Workstation, string UnitSerialNumber, string V5, string V12, string V22, string SEMIFASN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorLpByUsn", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadMonitorLpByUsnAsync(string Line, string Stage, string Workstation, string UnitSerialNumber, string V5, string V12, string V22, string SEMIFASN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorLP", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadMonitorLP(string Line, string Stage, string Workstation, string ManufactureOrder, string V5, string V12, string V22, string SEMIFASN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadMonitorLP", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadMonitorLPAsync(string Line, string Stage, string Workstation, string ManufactureOrder, string V5, string V12, string V22, string SEMIFASN);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckErrorCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool CheckErrorCode(string ErrorCode, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckErrorCode", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> CheckErrorCodeAsync(string ErrorCode, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetRIRackPositionByUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNResponse GetRIRackPositionByUSN(SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetRIRackPositionByUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNResponse> GetRIRackPositionByUSNAsync(SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByRIRackPosition", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionResponse GetUSNByRIRackPosition(SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByRIRackPosition", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionResponse> GetUSNByRIRackPositionAsync(SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadDownTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadDownTime(string UnitSerialNumber, string StageCode, int TestTime, bool Result, string DownTimeCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadDownTime", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadDownTimeAsync(string UnitSerialNumber, string StageCode, int TestTime, bool Result, string DownTimeCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInformation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNInformationResponse GetUSNInformation(SharpFrameSmall.Common.SFCS.GetUSNInformationRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInformation", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNInformationResponse> GetUSNInformationAsync(SharpFrameSmall.Common.SFCS.GetUSNInformationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByUSNInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoResponse GetUSNByUSNInfo(SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByUSNInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoResponse> GetUSNByUSNInfoAsync(SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest request);
        
        // CODEGEN: 参数“Parameter”需要其他方案信息，使用参数模式无法捕获这些信息。特定特性为“System.Xml.Serialization.XmlElementAttribute”。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMessage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetMessageResponse GetMessage(SharpFrameSmall.Common.SFCS.GetMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMessage", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMessageResponse> GetMessageAsync(SharpFrameSmall.Common.SFCS.GetMessageRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSPCConfig", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsSPCConfig GetSPCConfig(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsSPCConfig clsSPCConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSPCConfig", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsSPCConfig> GetSPCConfigAsync(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsSPCConfig clsSPCConfig);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUPNInformation", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUPNInformationResponse GetUPNInformation(SharpFrameSmall.Common.SFCS.GetUPNInformationRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUPNInformation", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUPNInformationResponse> GetUPNInformationAsync(SharpFrameSmall.Common.SFCS.GetUPNInformationRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPanelParameter", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetPanelParameterResponse GetPanelParameter(SharpFrameSmall.Common.SFCS.GetPanelParameterRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPanelParameter", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPanelParameterResponse> GetPanelParameterAsync(SharpFrameSmall.Common.SFCS.GetPanelParameterRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPanelParameterWithDataSearchType" +
            "", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeResponse GetPanelParameterWithDataSearchType(SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetPanelParameterWithDataSearchType" +
            "", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeResponse> GetPanelParameterWithDataSearchTypeAsync(SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUUTData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.clsRequestData GetUUTData(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsRequestData RequestData, int RequestDataType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUUTData", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsRequestData> GetUUTDataAsync(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsRequestData RequestData, int RequestDataType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByCSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetUSNByCSN(string ComponentSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByCSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetUSNByCSNAsync(string ComponentSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCertifyPO", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UploadCertifyPO(string StageCode, string PO, string TieGroup, string ImageID, string SDRCheckSum, string UploadType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UploadCertifyPO", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UploadCertifyPOAsync(string StageCode, string PO, string TieGroup, string ImageID, string SDRCheckSum, string UploadType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSWCPNForUPN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetSWCPNForUPNResponse GetSWCPNForUPN(SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSWCPNForUPN", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetSWCPNForUPNResponse> GetSWCPNForUPNAsync(SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInfoByMAC", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNInfoByMACResponse GetUSNInfoByMAC(SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNInfoByMAC", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNInfoByMACResponse> GetUSNInfoByMACAsync(SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateSyncStatus", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateSyncStatus(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateSyncStatus", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateSyncStatusAsync(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEarliestSIList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetEarliestSIList(string NeedRecordQty, string OverThanDays);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetEarliestSIList", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetEarliestSIListAsync(string NeedRecordQty, string OverThanDays);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateDeleteSIInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string UpdateDeleteSIInfo(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/UpdateDeleteSIInfo", ReplyAction="*")]
        System.Threading.Tasks.Task<string> UpdateDeleteSIInfoAsync(string SINumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAvailableGradeList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetAvailableGradeList(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetAvailableGradeList", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetAvailableGradeListAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastGrade", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetLastGrade(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetLastGrade", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetLastGradeAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckSampling", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string CheckSampling(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/CheckSampling", ReplyAction="*")]
        System.Threading.Tasks.Task<string> CheckSamplingAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSkuBomData", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetSkuBomDataResponse GetSkuBomData(SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetSkuBomData", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetSkuBomDataResponse> GetSkuBomDataAsync(SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCurrentDBSysdate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetCurrentDBSysdate(string StageCode, string DateTimeFormat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetCurrentDBSysdate", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetCurrentDBSysdateAsync(string StageCode, string DateTimeFormat);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByRIPalletID", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDResponse GetUSNByRIPalletID(SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetUSNByRIPalletID", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDResponse> GetUSNByRIPalletIDAsync(SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BreakUpUSNRIPalletByUSN", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string BreakUpUSNRIPalletByUSN(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/BreakUpUSNRIPalletByUSN", ReplyAction="*")]
        System.Threading.Tasks.Task<string> BreakUpUSNRIPalletByUSNAsync(string UnitSerialNumber, string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMO53PNItem", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetMO53PNItemResponse GetMO53PNItem(SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMO53PNItem", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMO53PNItemResponse> GetMO53PNItemAsync(SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTEModelName", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        SharpFrameSmall.Common.SFCS.GetTEModelNameResponse GetTEModelName(SharpFrameSmall.Common.SFCS.GetTEModelNameRequest request);
        
        // CODEGEN: 正在生成消息协定，应为该操作具有多个返回值。
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetTEModelName", ReplyAction="*")]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTEModelNameResponse> GetTEModelNameAsync(SharpFrameSmall.Common.SFCS.GetTEModelNameRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMFGTypeByStage", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string GetMFGTypeByStage(string StageCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://localhost/Tester.WebService/WebService/GetMFGTypeByStage", ReplyAction="*")]
        System.Threading.Tasks.Task<string> GetMFGTypeByStageAsync(string StageCode);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLinkUSN", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLinkUSNRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string ResultMessage;
        
        public GetLinkUSNRequest() {
        }
        
        public GetLinkUSNRequest(string UnitSerialNumber, string ResultMessage) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.ResultMessage = ResultMessage;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLinkUSNResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLinkUSNResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string[] GetLinkUSNResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string ResultMessage;
        
        public GetLinkUSNResponse() {
        }
        
        public GetLinkUSNResponse(string[] GetLinkUSNResult, string ResultMessage) {
            this.GetLinkUSNResult = GetLinkUSNResult;
            this.ResultMessage = ResultMessage;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsKtlOutEvent : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uSNField;
        
        private string lineField;
        
        private string workstationField;
        
        private string locationField;
        
        private string ipField;
        
        private string portField;
        
        private string hardwareNodeIdField;
        
        private string commandField;
        
        private string dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Workstation {
            get {
                return this.workstationField;
            }
            set {
                this.workstationField = value;
                this.RaisePropertyChanged("Workstation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("Location");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Ip {
            get {
                return this.ipField;
            }
            set {
                this.ipField = value;
                this.RaisePropertyChanged("Ip");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Port {
            get {
                return this.portField;
            }
            set {
                this.portField = value;
                this.RaisePropertyChanged("Port");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string HardwareNodeId {
            get {
                return this.hardwareNodeIdField;
            }
            set {
                this.hardwareNodeIdField = value;
                this.RaisePropertyChanged("HardwareNodeId");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Command {
            get {
                return this.commandField;
            }
            set {
                this.commandField = value;
                this.RaisePropertyChanged("Command");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("Data");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSkuBomData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string skuPNField;
        
        private string categoryField;
        
        private string cPNField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SkuPN {
            get {
                return this.skuPNField;
            }
            set {
                this.skuPNField = value;
                this.RaisePropertyChanged("SkuPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
                this.RaisePropertyChanged("Category");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSWCPN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cPNField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsRequestItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string itemField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsRequestData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private string modelField;
        
        private string uPNField;
        
        private string modelFamilyField;
        
        private string poField;
        
        private string resultField;
        
        private clsRequestItem[] requestItemField;
        
        private string customerUPNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ModelFamily {
            get {
                return this.modelFamilyField;
            }
            set {
                this.modelFamilyField = value;
                this.RaisePropertyChanged("ModelFamily");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string PO {
            get {
                return this.poField;
            }
            set {
                this.poField = value;
                this.RaisePropertyChanged("PO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=6)]
        public clsRequestItem[] RequestItem {
            get {
                return this.requestItemField;
            }
            set {
                this.requestItemField = value;
                this.RaisePropertyChanged("RequestItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CustomerUPN {
            get {
                return this.customerUPNField;
            }
            set {
                this.customerUPNField = value;
                this.RaisePropertyChanged("CustomerUPN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSPCConfigItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sPCTypeField;
        
        private string sPCItemField;
        
        private string sPCSUBITEMField;
        
        private string upperLimitField;
        
        private string lowerLimitField;
        
        private int enableField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SPCType {
            get {
                return this.sPCTypeField;
            }
            set {
                this.sPCTypeField = value;
                this.RaisePropertyChanged("SPCType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SPCItem {
            get {
                return this.sPCItemField;
            }
            set {
                this.sPCItemField = value;
                this.RaisePropertyChanged("SPCItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SPCSUBITEM {
            get {
                return this.sPCSUBITEMField;
            }
            set {
                this.sPCSUBITEMField = value;
                this.RaisePropertyChanged("SPCSUBITEM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string UpperLimit {
            get {
                return this.upperLimitField;
            }
            set {
                this.upperLimitField = value;
                this.RaisePropertyChanged("UpperLimit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string LowerLimit {
            get {
                return this.lowerLimitField;
            }
            set {
                this.lowerLimitField = value;
                this.RaisePropertyChanged("LowerLimit");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Enable {
            get {
                return this.enableField;
            }
            set {
                this.enableField = value;
                this.RaisePropertyChanged("Enable");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSPCConfig : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private string modelField;
        
        private string uPNField;
        
        private string modelFamilyField;
        
        private clsSPCConfigItem[] sPCConfigItemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ModelFamily {
            get {
                return this.modelFamilyField;
            }
            set {
                this.modelFamilyField = value;
                this.RaisePropertyChanged("ModelFamily");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=4)]
        public clsSPCConfigItem[] SPCConfigItems {
            get {
                return this.sPCConfigItemsField;
            }
            set {
                this.sPCConfigItemsField = value;
                this.RaisePropertyChanged("SPCConfigItems");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsMessage : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string idField;
        
        private string messageField;
        
        private string languageField;
        
        private string moduleNameField;
        
        private string typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("Message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Language {
            get {
                return this.languageField;
            }
            set {
                this.languageField = value;
                this.RaisePropertyChanged("Language");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ModuleName {
            get {
                return this.moduleNameField;
            }
            set {
                this.moduleNameField = value;
                this.RaisePropertyChanged("ModuleName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsGetUSNInfoResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string uSNField;
        
        private string modelField;
        
        private string productCodeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ProductCode {
            get {
                return this.productCodeField;
            }
            set {
                this.productCodeField = value;
                this.RaisePropertyChanged("ProductCode");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsGetTestSuiteInfoResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string uSNField;
        
        private string stageCodeField;
        
        private string modelField;
        
        private string workStationField;
        
        private string programVersionField;
        
        private string flowVersionField;
        
        private string fileNameField;
        
        private string filePathField;
        
        private string checkSumField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string StageCode {
            get {
                return this.stageCodeField;
            }
            set {
                this.stageCodeField = value;
                this.RaisePropertyChanged("StageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WorkStation {
            get {
                return this.workStationField;
            }
            set {
                this.workStationField = value;
                this.RaisePropertyChanged("WorkStation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ProgramVersion {
            get {
                return this.programVersionField;
            }
            set {
                this.programVersionField = value;
                this.RaisePropertyChanged("ProgramVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string FlowVersion {
            get {
                return this.flowVersionField;
            }
            set {
                this.flowVersionField = value;
                this.RaisePropertyChanged("FlowVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("FileName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string FilePath {
            get {
                return this.filePathField;
            }
            set {
                this.filePathField = value;
                this.RaisePropertyChanged("FilePath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string CheckSum {
            get {
                return this.checkSumField;
            }
            set {
                this.checkSumField = value;
                this.RaisePropertyChanged("CheckSum");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsCA210OffsetResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string cA210SNField;
        
        private string modelField;
        
        private string probeSNField;
        
        private string sourceField;
        
        private string colorTemperatureField;
        
        private string lineField;
        
        private string workStationField;
        
        private string targetGainAField;
        
        private string targetGainBField;
        
        private string targetGainLVField;
        
        private string targetOffsetAField;
        
        private string targetOffsetBField;
        
        private string targetOffsetLVField;
        
        private string target100IreAField;
        
        private string target100IreBField;
        
        private string target100IreLVField;
        
        private string offsetGainAField;
        
        private string offsetGainBField;
        
        private string offsetGainLVField;
        
        private string offsetOffsetAField;
        
        private string offsetOffsetBField;
        
        private string offsetOffsetLVField;
        
        private string offset100IreAField;
        
        private string offset100IreBField;
        
        private string offset100IreLVField;
        
        private string recordTimeField;
        
        private string userIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CA210SN {
            get {
                return this.cA210SNField;
            }
            set {
                this.cA210SNField = value;
                this.RaisePropertyChanged("CA210SN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string ProbeSN {
            get {
                return this.probeSNField;
            }
            set {
                this.probeSNField = value;
                this.RaisePropertyChanged("ProbeSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
                this.RaisePropertyChanged("Source");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string ColorTemperature {
            get {
                return this.colorTemperatureField;
            }
            set {
                this.colorTemperatureField = value;
                this.RaisePropertyChanged("ColorTemperature");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string WorkStation {
            get {
                return this.workStationField;
            }
            set {
                this.workStationField = value;
                this.RaisePropertyChanged("WorkStation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string TargetGainA {
            get {
                return this.targetGainAField;
            }
            set {
                this.targetGainAField = value;
                this.RaisePropertyChanged("TargetGainA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string TargetGainB {
            get {
                return this.targetGainBField;
            }
            set {
                this.targetGainBField = value;
                this.RaisePropertyChanged("TargetGainB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string TargetGainLV {
            get {
                return this.targetGainLVField;
            }
            set {
                this.targetGainLVField = value;
                this.RaisePropertyChanged("TargetGainLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string TargetOffsetA {
            get {
                return this.targetOffsetAField;
            }
            set {
                this.targetOffsetAField = value;
                this.RaisePropertyChanged("TargetOffsetA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string TargetOffsetB {
            get {
                return this.targetOffsetBField;
            }
            set {
                this.targetOffsetBField = value;
                this.RaisePropertyChanged("TargetOffsetB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string TargetOffsetLV {
            get {
                return this.targetOffsetLVField;
            }
            set {
                this.targetOffsetLVField = value;
                this.RaisePropertyChanged("TargetOffsetLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string Target100IreA {
            get {
                return this.target100IreAField;
            }
            set {
                this.target100IreAField = value;
                this.RaisePropertyChanged("Target100IreA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Target100IreB {
            get {
                return this.target100IreBField;
            }
            set {
                this.target100IreBField = value;
                this.RaisePropertyChanged("Target100IreB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string Target100IreLV {
            get {
                return this.target100IreLVField;
            }
            set {
                this.target100IreLVField = value;
                this.RaisePropertyChanged("Target100IreLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string OffsetGainA {
            get {
                return this.offsetGainAField;
            }
            set {
                this.offsetGainAField = value;
                this.RaisePropertyChanged("OffsetGainA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string OffsetGainB {
            get {
                return this.offsetGainBField;
            }
            set {
                this.offsetGainBField = value;
                this.RaisePropertyChanged("OffsetGainB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string OffsetGainLV {
            get {
                return this.offsetGainLVField;
            }
            set {
                this.offsetGainLVField = value;
                this.RaisePropertyChanged("OffsetGainLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string OffsetOffsetA {
            get {
                return this.offsetOffsetAField;
            }
            set {
                this.offsetOffsetAField = value;
                this.RaisePropertyChanged("OffsetOffsetA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string OffsetOffsetB {
            get {
                return this.offsetOffsetBField;
            }
            set {
                this.offsetOffsetBField = value;
                this.RaisePropertyChanged("OffsetOffsetB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string OffsetOffsetLV {
            get {
                return this.offsetOffsetLVField;
            }
            set {
                this.offsetOffsetLVField = value;
                this.RaisePropertyChanged("OffsetOffsetLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string Offset100IreA {
            get {
                return this.offset100IreAField;
            }
            set {
                this.offset100IreAField = value;
                this.RaisePropertyChanged("Offset100IreA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public string Offset100IreB {
            get {
                return this.offset100IreBField;
            }
            set {
                this.offset100IreBField = value;
                this.RaisePropertyChanged("Offset100IreB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string Offset100IreLV {
            get {
                return this.offset100IreLVField;
            }
            set {
                this.offset100IreLVField = value;
                this.RaisePropertyChanged("Offset100IreLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string RecordTime {
            get {
                return this.recordTimeField;
            }
            set {
                this.recordTimeField = value;
                this.RaisePropertyChanged("RecordTime");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string UserID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
                this.RaisePropertyChanged("UserID");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsCA210OffsetCheckFlag : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cA210SNField;
        
        private string sourceField;
        
        private string colorTemperatureField;
        
        private string lineField;
        
        private string workStationField;
        
        private string targetGainAField;
        
        private string targetGainBField;
        
        private string targetGainLVField;
        
        private string targetOffsetAField;
        
        private string targetOffsetBField;
        
        private string targetOffsetLVField;
        
        private string target100IreAField;
        
        private string target100IreBField;
        
        private string target100IreLVField;
        
        private string offsetGainAField;
        
        private string offsetGainBField;
        
        private string offsetGainLVField;
        
        private string offsetOffsetAField;
        
        private string offsetOffsetBField;
        
        private string offsetOffsetLVField;
        
        private string offset100IreAField;
        
        private string offset100IreBField;
        
        private string offset100IreLVField;
        
        private string userIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CA210SN {
            get {
                return this.cA210SNField;
            }
            set {
                this.cA210SNField = value;
                this.RaisePropertyChanged("CA210SN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
                this.RaisePropertyChanged("Source");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ColorTemperature {
            get {
                return this.colorTemperatureField;
            }
            set {
                this.colorTemperatureField = value;
                this.RaisePropertyChanged("ColorTemperature");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WorkStation {
            get {
                return this.workStationField;
            }
            set {
                this.workStationField = value;
                this.RaisePropertyChanged("WorkStation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string TargetGainA {
            get {
                return this.targetGainAField;
            }
            set {
                this.targetGainAField = value;
                this.RaisePropertyChanged("TargetGainA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string TargetGainB {
            get {
                return this.targetGainBField;
            }
            set {
                this.targetGainBField = value;
                this.RaisePropertyChanged("TargetGainB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string TargetGainLV {
            get {
                return this.targetGainLVField;
            }
            set {
                this.targetGainLVField = value;
                this.RaisePropertyChanged("TargetGainLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string TargetOffsetA {
            get {
                return this.targetOffsetAField;
            }
            set {
                this.targetOffsetAField = value;
                this.RaisePropertyChanged("TargetOffsetA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string TargetOffsetB {
            get {
                return this.targetOffsetBField;
            }
            set {
                this.targetOffsetBField = value;
                this.RaisePropertyChanged("TargetOffsetB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string TargetOffsetLV {
            get {
                return this.targetOffsetLVField;
            }
            set {
                this.targetOffsetLVField = value;
                this.RaisePropertyChanged("TargetOffsetLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string Target100IreA {
            get {
                return this.target100IreAField;
            }
            set {
                this.target100IreAField = value;
                this.RaisePropertyChanged("Target100IreA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string Target100IreB {
            get {
                return this.target100IreBField;
            }
            set {
                this.target100IreBField = value;
                this.RaisePropertyChanged("Target100IreB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string Target100IreLV {
            get {
                return this.target100IreLVField;
            }
            set {
                this.target100IreLVField = value;
                this.RaisePropertyChanged("Target100IreLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string OffsetGainA {
            get {
                return this.offsetGainAField;
            }
            set {
                this.offsetGainAField = value;
                this.RaisePropertyChanged("OffsetGainA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string OffsetGainB {
            get {
                return this.offsetGainBField;
            }
            set {
                this.offsetGainBField = value;
                this.RaisePropertyChanged("OffsetGainB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string OffsetGainLV {
            get {
                return this.offsetGainLVField;
            }
            set {
                this.offsetGainLVField = value;
                this.RaisePropertyChanged("OffsetGainLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string OffsetOffsetA {
            get {
                return this.offsetOffsetAField;
            }
            set {
                this.offsetOffsetAField = value;
                this.RaisePropertyChanged("OffsetOffsetA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string OffsetOffsetB {
            get {
                return this.offsetOffsetBField;
            }
            set {
                this.offsetOffsetBField = value;
                this.RaisePropertyChanged("OffsetOffsetB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string OffsetOffsetLV {
            get {
                return this.offsetOffsetLVField;
            }
            set {
                this.offsetOffsetLVField = value;
                this.RaisePropertyChanged("OffsetOffsetLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string Offset100IreA {
            get {
                return this.offset100IreAField;
            }
            set {
                this.offset100IreAField = value;
                this.RaisePropertyChanged("Offset100IreA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string Offset100IreB {
            get {
                return this.offset100IreBField;
            }
            set {
                this.offset100IreBField = value;
                this.RaisePropertyChanged("Offset100IreB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string Offset100IreLV {
            get {
                return this.offset100IreLVField;
            }
            set {
                this.offset100IreLVField = value;
                this.RaisePropertyChanged("Offset100IreLV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string UserID {
            get {
                return this.userIDField;
            }
            set {
                this.userIDField = value;
                this.RaisePropertyChanged("UserID");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="clsMO", Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsMO1 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private string planDateField;
        
        private string createDateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string PlanDate {
            get {
                return this.planDateField;
            }
            set {
                this.planDateField = value;
                this.RaisePropertyChanged("PlanDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsCIPlusKey : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cIPlusKeyField;
        
        private string stageCodeField;
        
        private string codeTypeField;
        
        private string codeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CIPlusKey {
            get {
                return this.cIPlusKeyField;
            }
            set {
                this.cIPlusKeyField = value;
                this.RaisePropertyChanged("CIPlusKey");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string StageCode {
            get {
                return this.stageCodeField;
            }
            set {
                this.stageCodeField = value;
                this.RaisePropertyChanged("StageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CodeType {
            get {
                return this.codeTypeField;
            }
            set {
                this.codeTypeField = value;
                this.RaisePropertyChanged("CodeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsHDCPKey : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string bKSVField;
        
        private string stageCodeField;
        
        private string codeTypeField;
        
        private string codeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string BKSV {
            get {
                return this.bKSVField;
            }
            set {
                this.bKSVField = value;
                this.RaisePropertyChanged("BKSV");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string StageCode {
            get {
                return this.stageCodeField;
            }
            set {
                this.stageCodeField = value;
                this.RaisePropertyChanged("StageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CodeType {
            get {
                return this.codeTypeField;
            }
            set {
                this.codeTypeField = value;
                this.RaisePropertyChanged("CodeType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Code {
            get {
                return this.codeField;
            }
            set {
                this.codeField = value;
                this.RaisePropertyChanged("Code");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsBomPnDescription : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string parentPNField;
        
        private string pnField;
        
        private string descriptionField;
        
        private string levelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ParentPN {
            get {
                return this.parentPNField;
            }
            set {
                this.parentPNField = value;
                this.RaisePropertyChanged("ParentPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string PN {
            get {
                return this.pnField;
            }
            set {
                this.pnField = value;
                this.RaisePropertyChanged("PN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
                this.RaisePropertyChanged("Level");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsTvDacData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uSNField;
        
        private string lineField;
        
        private string stageCodeField;
        
        private string workstationField;
        
        private int colorTypeField;
        
        private int rCutField;
        
        private int gCutField;
        
        private int bCutField;
        
        private int rGainField;
        
        private int gGainField;
        
        private int bGainField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string StageCode {
            get {
                return this.stageCodeField;
            }
            set {
                this.stageCodeField = value;
                this.RaisePropertyChanged("StageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Workstation {
            get {
                return this.workstationField;
            }
            set {
                this.workstationField = value;
                this.RaisePropertyChanged("Workstation");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int ColorType {
            get {
                return this.colorTypeField;
            }
            set {
                this.colorTypeField = value;
                this.RaisePropertyChanged("ColorType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int RCut {
            get {
                return this.rCutField;
            }
            set {
                this.rCutField = value;
                this.RaisePropertyChanged("RCut");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int GCut {
            get {
                return this.gCutField;
            }
            set {
                this.gCutField = value;
                this.RaisePropertyChanged("GCut");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int BCut {
            get {
                return this.bCutField;
            }
            set {
                this.bCutField = value;
                this.RaisePropertyChanged("BCut");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int RGain {
            get {
                return this.rGainField;
            }
            set {
                this.rGainField = value;
                this.RaisePropertyChanged("RGain");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int GGain {
            get {
                return this.gGainField;
            }
            set {
                this.gGainField = value;
                this.RaisePropertyChanged("GGain");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int BGain {
            get {
                return this.bGainField;
            }
            set {
                this.bGainField = value;
                this.RaisePropertyChanged("BGain");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class cls2SLabelInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool exist2SLabelField;
        
        private string s2SLabelField;
        
        private string[] arrBrandField;
        
        private string partNumberField;
        
        private string traceIDField;
        
        private int packageQtyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Exist2SLabel {
            get {
                return this.exist2SLabelField;
            }
            set {
                this.exist2SLabelField = value;
                this.RaisePropertyChanged("Exist2SLabel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string s2SLabel {
            get {
                return this.s2SLabelField;
            }
            set {
                this.s2SLabelField = value;
                this.RaisePropertyChanged("s2SLabel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        public string[] arrBrand {
            get {
                return this.arrBrandField;
            }
            set {
                this.arrBrandField = value;
                this.RaisePropertyChanged("arrBrand");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string PartNumber {
            get {
                return this.partNumberField;
            }
            set {
                this.partNumberField = value;
                this.RaisePropertyChanged("PartNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string TraceID {
            get {
                return this.traceIDField;
            }
            set {
                this.traceIDField = value;
                this.RaisePropertyChanged("TraceID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int PackageQty {
            get {
                return this.packageQtyField;
            }
            set {
                this.packageQtyField = value;
                this.RaisePropertyChanged("PackageQty");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsLog : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wOPKIDField;
        
        private int stepSNField;
        
        private int seqNoField;
        
        private int typeField;
        
        private string okField;
        
        private string ngField;
        
        private int errorCodeField;
        
        private string descriptionField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int StepSN {
            get {
                return this.stepSNField;
            }
            set {
                this.stepSNField = value;
                this.RaisePropertyChanged("StepSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int SeqNo {
            get {
                return this.seqNoField;
            }
            set {
                this.seqNoField = value;
                this.RaisePropertyChanged("SeqNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string OK {
            get {
                return this.okField;
            }
            set {
                this.okField = value;
                this.RaisePropertyChanged("OK");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string NG {
            get {
                return this.ngField;
            }
            set {
                this.ngField = value;
                this.RaisePropertyChanged("NG");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ErrorCode {
            get {
                return this.errorCodeField;
            }
            set {
                this.errorCodeField = value;
                this.RaisePropertyChanged("ErrorCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsStep : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string wOPKIDField;
        
        private int stepSNField;
        
        private int fUNCField;
        
        private int sideField;
        
        private string sheetNoField;
        
        private string feederField;
        
        private string zoneField;
        
        private string pKZoneField;
        
        private string rLCNField;
        
        private int qanaField;
        
        private int doneField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int StepSN {
            get {
                return this.stepSNField;
            }
            set {
                this.stepSNField = value;
                this.RaisePropertyChanged("StepSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int FUNC {
            get {
                return this.fUNCField;
            }
            set {
                this.fUNCField = value;
                this.RaisePropertyChanged("FUNC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Side {
            get {
                return this.sideField;
            }
            set {
                this.sideField = value;
                this.RaisePropertyChanged("Side");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Feeder {
            get {
                return this.feederField;
            }
            set {
                this.feederField = value;
                this.RaisePropertyChanged("Feeder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Zone {
            get {
                return this.zoneField;
            }
            set {
                this.zoneField = value;
                this.RaisePropertyChanged("Zone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string PKZone {
            get {
                return this.pKZoneField;
            }
            set {
                this.pKZoneField = value;
                this.RaisePropertyChanged("PKZone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string RLCN {
            get {
                return this.rLCNField;
            }
            set {
                this.rLCNField = value;
                this.RaisePropertyChanged("RLCN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Qana {
            get {
                return this.qanaField;
            }
            set {
                this.qanaField = value;
                this.RaisePropertyChanged("Qana");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int Done {
            get {
                return this.doneField;
            }
            set {
                this.doneField = value;
                this.RaisePropertyChanged("Done");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsZone : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string lineField;
        
        private int mcnoField;
        
        private string zoneField;
        
        private int trayField;
        
        private int sideField;
        
        private string pKZoneField;
        
        private string feederField;
        
        private int qanaField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Mcno {
            get {
                return this.mcnoField;
            }
            set {
                this.mcnoField = value;
                this.RaisePropertyChanged("Mcno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Zone {
            get {
                return this.zoneField;
            }
            set {
                this.zoneField = value;
                this.RaisePropertyChanged("Zone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int Tray {
            get {
                return this.trayField;
            }
            set {
                this.trayField = value;
                this.RaisePropertyChanged("Tray");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int Side {
            get {
                return this.sideField;
            }
            set {
                this.sideField = value;
                this.RaisePropertyChanged("Side");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string PKZone {
            get {
                return this.pKZoneField;
            }
            set {
                this.pKZoneField = value;
                this.RaisePropertyChanged("PKZone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Feeder {
            get {
                return this.feederField;
            }
            set {
                this.feederField = value;
                this.RaisePropertyChanged("Feeder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Qana {
            get {
                return this.qanaField;
            }
            set {
                this.qanaField = value;
                this.RaisePropertyChanged("Qana");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsFeeder : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string feederField;
        
        private string sheetNoField;
        
        private int lastCountField;
        
        private int repairCountField;
        
        private int usedCountField;
        
        private int failCountField;
        
        private string rLCNField;
        
        private int ngField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Feeder {
            get {
                return this.feederField;
            }
            set {
                this.feederField = value;
                this.RaisePropertyChanged("Feeder");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int LastCount {
            get {
                return this.lastCountField;
            }
            set {
                this.lastCountField = value;
                this.RaisePropertyChanged("LastCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int RepairCount {
            get {
                return this.repairCountField;
            }
            set {
                this.repairCountField = value;
                this.RaisePropertyChanged("RepairCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int UsedCount {
            get {
                return this.usedCountField;
            }
            set {
                this.usedCountField = value;
                this.RaisePropertyChanged("UsedCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int FailCount {
            get {
                return this.failCountField;
            }
            set {
                this.failCountField = value;
                this.RaisePropertyChanged("FailCount");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string RLCN {
            get {
                return this.rLCNField;
            }
            set {
                this.rLCNField = value;
                this.RaisePropertyChanged("RLCN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int NG {
            get {
                return this.ngField;
            }
            set {
                this.ngField = value;
                this.RaisePropertyChanged("NG");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsRLC : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string rLCNField;
        
        private string itemField;
        
        private string barcField;
        
        private string lotNField;
        
        private string brandField;
        
        private string bodyMarkField;
        
        private int qORIField;
        
        private string rLC_SheetnoField;
        
        private int rLCField;
        
        private int qANAField;
        
        private string polarityField;
        
        private bool checkLabelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string RLCN {
            get {
                return this.rLCNField;
            }
            set {
                this.rLCNField = value;
                this.RaisePropertyChanged("RLCN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Barc {
            get {
                return this.barcField;
            }
            set {
                this.barcField = value;
                this.RaisePropertyChanged("Barc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string LotN {
            get {
                return this.lotNField;
            }
            set {
                this.lotNField = value;
                this.RaisePropertyChanged("LotN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Brand {
            get {
                return this.brandField;
            }
            set {
                this.brandField = value;
                this.RaisePropertyChanged("Brand");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string BodyMark {
            get {
                return this.bodyMarkField;
            }
            set {
                this.bodyMarkField = value;
                this.RaisePropertyChanged("BodyMark");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int QORI {
            get {
                return this.qORIField;
            }
            set {
                this.qORIField = value;
                this.RaisePropertyChanged("QORI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string RLC_Sheetno {
            get {
                return this.rLC_SheetnoField;
            }
            set {
                this.rLC_SheetnoField = value;
                this.RaisePropertyChanged("RLC_Sheetno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int RLC {
            get {
                return this.rLCField;
            }
            set {
                this.rLCField = value;
                this.RaisePropertyChanged("RLC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int QANA {
            get {
                return this.qANAField;
            }
            set {
                this.qANAField = value;
                this.RaisePropertyChanged("QANA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Polarity {
            get {
                return this.polarityField;
            }
            set {
                this.polarityField = value;
                this.RaisePropertyChanged("Polarity");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public bool CheckLabel {
            get {
                return this.checkLabelField;
            }
            set {
                this.checkLabelField = value;
                this.RaisePropertyChanged("CheckLabel");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsReel : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsRLC rLCsField;
        
        private clsFeeder feedersField;
        
        private clsZone zonesField;
        
        private string sheetnoField;
        
        private string wOPKIDField;
        
        private int pickSNField;
        
        private int putIn_QtyField;
        
        private int tray_QtyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public clsRLC RLCs {
            get {
                return this.rLCsField;
            }
            set {
                this.rLCsField = value;
                this.RaisePropertyChanged("RLCs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public clsFeeder Feeders {
            get {
                return this.feedersField;
            }
            set {
                this.feedersField = value;
                this.RaisePropertyChanged("Feeders");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public clsZone Zones {
            get {
                return this.zonesField;
            }
            set {
                this.zonesField = value;
                this.RaisePropertyChanged("Zones");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Sheetno {
            get {
                return this.sheetnoField;
            }
            set {
                this.sheetnoField = value;
                this.RaisePropertyChanged("Sheetno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int PickSN {
            get {
                return this.pickSNField;
            }
            set {
                this.pickSNField = value;
                this.RaisePropertyChanged("PickSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int PutIn_Qty {
            get {
                return this.putIn_QtyField;
            }
            set {
                this.putIn_QtyField = value;
                this.RaisePropertyChanged("PutIn_Qty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Tray_Qty {
            get {
                return this.tray_QtyField;
            }
            set {
                this.tray_QtyField = value;
                this.RaisePropertyChanged("Tray_Qty");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsPKList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string zoneField;
        
        private string itemField;
        
        private int qtyPerField;
        
        private string mZoneField;
        
        private string feedField;
        
        private bool readyField;
        
        private string polarityField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Zone {
            get {
                return this.zoneField;
            }
            set {
                this.zoneField = value;
                this.RaisePropertyChanged("Zone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
                this.RaisePropertyChanged("Item");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int QtyPer {
            get {
                return this.qtyPerField;
            }
            set {
                this.qtyPerField = value;
                this.RaisePropertyChanged("QtyPer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string MZone {
            get {
                return this.mZoneField;
            }
            set {
                this.mZoneField = value;
                this.RaisePropertyChanged("MZone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Feed {
            get {
                return this.feedField;
            }
            set {
                this.feedField = value;
                this.RaisePropertyChanged("Feed");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public bool Ready {
            get {
                return this.readyField;
            }
            set {
                this.readyField = value;
                this.RaisePropertyChanged("Ready");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string Polarity {
            get {
                return this.polarityField;
            }
            set {
                this.polarityField = value;
                this.RaisePropertyChanged("Polarity");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsSheet : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string sheetNoField;
        
        private string wOPKIDField;
        
        private int pICKSNField;
        
        private int oP_ModeField;
        
        private string moField;
        
        private string locaField;
        
        private int combineField;
        
        private string sPNField;
        
        private string lineField;
        
        private int mcnoField;
        
        private int faceField;
        
        private int statField;
        
        private int stepSNField;
        
        private int zonesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int PICKSN {
            get {
                return this.pICKSNField;
            }
            set {
                this.pICKSNField = value;
                this.RaisePropertyChanged("PICKSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int OP_Mode {
            get {
                return this.oP_ModeField;
            }
            set {
                this.oP_ModeField = value;
                this.RaisePropertyChanged("OP_Mode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Loca {
            get {
                return this.locaField;
            }
            set {
                this.locaField = value;
                this.RaisePropertyChanged("Loca");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Combine {
            get {
                return this.combineField;
            }
            set {
                this.combineField = value;
                this.RaisePropertyChanged("Combine");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SPN {
            get {
                return this.sPNField;
            }
            set {
                this.sPNField = value;
                this.RaisePropertyChanged("SPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Mcno {
            get {
                return this.mcnoField;
            }
            set {
                this.mcnoField = value;
                this.RaisePropertyChanged("Mcno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public int Face {
            get {
                return this.faceField;
            }
            set {
                this.faceField = value;
                this.RaisePropertyChanged("Face");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int Stat {
            get {
                return this.statField;
            }
            set {
                this.statField = value;
                this.RaisePropertyChanged("Stat");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int StepSN {
            get {
                return this.stepSNField;
            }
            set {
                this.stepSNField = value;
                this.RaisePropertyChanged("StepSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int Zones {
            get {
                return this.zonesField;
            }
            set {
                this.zonesField = value;
                this.RaisePropertyChanged("Zones");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsPKMC : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string lineField;
        
        private int mcnoField;
        
        private int sideField;
        
        private int cTRL_PortField;
        
        private int cTRL_CodeField;
        
        private string sheetNoField;
        
        private int readyField;
        
        private int verifyField;
        
        private int activeField;
        
        private int lastPOSField;
        
        private string wOPKIDField;
        
        private int pickSNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Mcno {
            get {
                return this.mcnoField;
            }
            set {
                this.mcnoField = value;
                this.RaisePropertyChanged("Mcno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Side {
            get {
                return this.sideField;
            }
            set {
                this.sideField = value;
                this.RaisePropertyChanged("Side");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int CTRL_Port {
            get {
                return this.cTRL_PortField;
            }
            set {
                this.cTRL_PortField = value;
                this.RaisePropertyChanged("CTRL_Port");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int CTRL_Code {
            get {
                return this.cTRL_CodeField;
            }
            set {
                this.cTRL_CodeField = value;
                this.RaisePropertyChanged("CTRL_Code");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int Ready {
            get {
                return this.readyField;
            }
            set {
                this.readyField = value;
                this.RaisePropertyChanged("Ready");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Verify {
            get {
                return this.verifyField;
            }
            set {
                this.verifyField = value;
                this.RaisePropertyChanged("Verify");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
                this.RaisePropertyChanged("Active");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int LastPOS {
            get {
                return this.lastPOSField;
            }
            set {
                this.lastPOSField = value;
                this.RaisePropertyChanged("LastPOS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int PickSN {
            get {
                return this.pickSNField;
            }
            set {
                this.pickSNField = value;
                this.RaisePropertyChanged("PickSN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsMC : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string lineField;
        
        private int mcnoField;
        
        private int typeField;
        
        private int mCTypeField;
        
        private string descriptionField;
        
        private int zone_OFSField;
        
        private string sheetNoField;
        
        private int sideField;
        
        private int oP_ModeField;
        
        private int activeField;
        
        private string wOPKIDField;
        
        private int pickSNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Mcno {
            get {
                return this.mcnoField;
            }
            set {
                this.mcnoField = value;
                this.RaisePropertyChanged("Mcno");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
                this.RaisePropertyChanged("Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int MCType {
            get {
                return this.mCTypeField;
            }
            set {
                this.mCTypeField = value;
                this.RaisePropertyChanged("MCType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("Description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Zone_OFS {
            get {
                return this.zone_OFSField;
            }
            set {
                this.zone_OFSField = value;
                this.RaisePropertyChanged("Zone_OFS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Side {
            get {
                return this.sideField;
            }
            set {
                this.sideField = value;
                this.RaisePropertyChanged("Side");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int OP_Mode {
            get {
                return this.oP_ModeField;
            }
            set {
                this.oP_ModeField = value;
                this.RaisePropertyChanged("OP_Mode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Active {
            get {
                return this.activeField;
            }
            set {
                this.activeField = value;
                this.RaisePropertyChanged("Active");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string WOPKID {
            get {
                return this.wOPKIDField;
            }
            set {
                this.wOPKIDField = value;
                this.RaisePropertyChanged("WOPKID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int PickSN {
            get {
                return this.pickSNField;
            }
            set {
                this.pickSNField = value;
                this.RaisePropertyChanged("PickSN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class clsPL : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsMC mcField;
        
        private clsPKMC[] pKMCsField;
        
        private clsSheet sheetField;
        
        private clsPKList[] pKListsField;
        
        private clsReel reelField;
        
        private clsStep pickingStepField;
        
        private clsLog logField;
        
        private int sideField;
        
        private int oP_ModeField;
        
        private int funcField;
        
        private string zoneField;
        
        private bool newStepField;
        
        private int logSNField;
        
        private string oKBarcodeField;
        
        private string inputBarcodeField;
        
        private string pLEventField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public clsMC MC {
            get {
                return this.mcField;
            }
            set {
                this.mcField = value;
                this.RaisePropertyChanged("MC");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public clsPKMC[] PKMCs {
            get {
                return this.pKMCsField;
            }
            set {
                this.pKMCsField = value;
                this.RaisePropertyChanged("PKMCs");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public clsSheet Sheet {
            get {
                return this.sheetField;
            }
            set {
                this.sheetField = value;
                this.RaisePropertyChanged("Sheet");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public clsPKList[] PKLists {
            get {
                return this.pKListsField;
            }
            set {
                this.pKListsField = value;
                this.RaisePropertyChanged("PKLists");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public clsReel Reel {
            get {
                return this.reelField;
            }
            set {
                this.reelField = value;
                this.RaisePropertyChanged("Reel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public clsStep PickingStep {
            get {
                return this.pickingStepField;
            }
            set {
                this.pickingStepField = value;
                this.RaisePropertyChanged("PickingStep");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public clsLog Log {
            get {
                return this.logField;
            }
            set {
                this.logField = value;
                this.RaisePropertyChanged("Log");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int Side {
            get {
                return this.sideField;
            }
            set {
                this.sideField = value;
                this.RaisePropertyChanged("Side");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int OP_Mode {
            get {
                return this.oP_ModeField;
            }
            set {
                this.oP_ModeField = value;
                this.RaisePropertyChanged("OP_Mode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Func {
            get {
                return this.funcField;
            }
            set {
                this.funcField = value;
                this.RaisePropertyChanged("Func");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Zone {
            get {
                return this.zoneField;
            }
            set {
                this.zoneField = value;
                this.RaisePropertyChanged("Zone");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public bool NewStep {
            get {
                return this.newStepField;
            }
            set {
                this.newStepField = value;
                this.RaisePropertyChanged("NewStep");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int LogSN {
            get {
                return this.logSNField;
            }
            set {
                this.logSNField = value;
                this.RaisePropertyChanged("LogSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string OKBarcode {
            get {
                return this.oKBarcodeField;
            }
            set {
                this.oKBarcodeField = value;
                this.RaisePropertyChanged("OKBarcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string InputBarcode {
            get {
                return this.inputBarcodeField;
            }
            set {
                this.inputBarcodeField = value;
                this.RaisePropertyChanged("InputBarcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string PLEvent {
            get {
                return this.pLEventField;
            }
            set {
                this.pLEventField = value;
                this.RaisePropertyChanged("PLEvent");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsMOAndBoardInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsPL clsPLField;
        
        private string moField;
        
        private string sPNField;
        
        private string uPNField;
        
        private string unitPerPCBField;
        
        private string sheetNoField;
        
        private int inputQtyField;
        
        private int mOLotField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public clsPL clsPL {
            get {
                return this.clsPLField;
            }
            set {
                this.clsPLField = value;
                this.RaisePropertyChanged("clsPL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SPN {
            get {
                return this.sPNField;
            }
            set {
                this.sPNField = value;
                this.RaisePropertyChanged("SPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string UnitPerPCB {
            get {
                return this.unitPerPCBField;
            }
            set {
                this.unitPerPCBField = value;
                this.RaisePropertyChanged("UnitPerPCB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string SheetNo {
            get {
                return this.sheetNoField;
            }
            set {
                this.sheetNoField = value;
                this.RaisePropertyChanged("SheetNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int InputQty {
            get {
                return this.inputQtyField;
            }
            set {
                this.inputQtyField = value;
                this.RaisePropertyChanged("InputQty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public int MOLot {
            get {
                return this.mOLotField;
            }
            set {
                this.mOLotField = value;
                this.RaisePropertyChanged("MOLot");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsAutoStickLabelPN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string modelFamilyField;
        
        private string cPNField;
        
        private string cPNTypeField;
        
        private string locationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ModelFamily {
            get {
                return this.modelFamilyField;
            }
            set {
                this.modelFamilyField = value;
                this.RaisePropertyChanged("ModelFamily");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CPNType {
            get {
                return this.cPNTypeField;
            }
            set {
                this.cPNTypeField = value;
                this.RaisePropertyChanged("CPNType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("Location");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsKeyValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("Key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsTVKeyItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string keyTypeField;
        
        private string keyValueField;
        
        private string keyValue2Field;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string KeyType {
            get {
                return this.keyTypeField;
            }
            set {
                this.keyTypeField = value;
                this.RaisePropertyChanged("KeyType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string KeyValue {
            get {
                return this.keyValueField;
            }
            set {
                this.keyValueField = value;
                this.RaisePropertyChanged("KeyValue");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string KeyValue2 {
            get {
                return this.keyValue2Field;
            }
            set {
                this.keyValue2Field = value;
                this.RaisePropertyChanged("KeyValue2");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsTVKeyData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private clsTVKeyItem[] tVKeyItemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=0)]
        public clsTVKeyItem[] TVKeyItems {
            get {
                return this.tVKeyItemsField;
            }
            set {
                this.tVKeyItemsField = value;
                this.RaisePropertyChanged("TVKeyItems");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="clsMOItem", Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsMOItem1 : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string cPNField;
        
        private string categoryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
                this.RaisePropertyChanged("Category");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsEngravingInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string uSNField;
        
        private string nextStageField;
        
        private string uPNField;
        
        private string snField;
        
        private string moField;
        
        private string createDateField;
        
        private string cPNField;
        
        private string wLANCPNField;
        
        private string rATINGCPNField;
        
        private string eNGRAVINGFLAGField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string NextStage {
            get {
                return this.nextStageField;
            }
            set {
                this.nextStageField = value;
                this.RaisePropertyChanged("NextStage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string SN {
            get {
                return this.snField;
            }
            set {
                this.snField = value;
                this.RaisePropertyChanged("SN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string WLANCPN {
            get {
                return this.wLANCPNField;
            }
            set {
                this.wLANCPNField = value;
                this.RaisePropertyChanged("WLANCPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string RATINGCPN {
            get {
                return this.rATINGCPNField;
            }
            set {
                this.rATINGCPNField = value;
                this.RaisePropertyChanged("RATINGCPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ENGRAVINGFLAG {
            get {
                return this.eNGRAVINGFLAGField;
            }
            set {
                this.eNGRAVINGFLAGField = value;
                this.RaisePropertyChanged("ENGRAVINGFLAG");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsUSNIDValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uSNField;
        
        private string iDValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string IDValue {
            get {
                return this.iDValueField;
            }
            set {
                this.iDValueField = value;
                this.RaisePropertyChanged("IDValue");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsMOIDValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private clsUSNIDValue[] uSNIDValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public clsUSNIDValue[] USNIDValue {
            get {
                return this.uSNIDValueField;
            }
            set {
                this.uSNIDValueField = value;
                this.RaisePropertyChanged("USNIDValue");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsJDMD3FileJobInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string requestIDField;
        
        private string plantField;
        
        private string requestDateField;
        
        private string statusField;
        
        private string requestTypeField;
        
        private string fileNameField;
        
        private string localFilePathField;
        
        private string errorMessageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string RequestID {
            get {
                return this.requestIDField;
            }
            set {
                this.requestIDField = value;
                this.RaisePropertyChanged("RequestID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Plant {
            get {
                return this.plantField;
            }
            set {
                this.plantField = value;
                this.RaisePropertyChanged("Plant");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string RequestDate {
            get {
                return this.requestDateField;
            }
            set {
                this.requestDateField = value;
                this.RaisePropertyChanged("RequestDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string RequestType {
            get {
                return this.requestTypeField;
            }
            set {
                this.requestTypeField = value;
                this.RaisePropertyChanged("RequestType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
                this.RaisePropertyChanged("FileName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string LocalFilePath {
            get {
                return this.localFilePathField;
            }
            set {
                this.localFilePathField = value;
                this.RaisePropertyChanged("LocalFilePath");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string ErrorMessage {
            get {
                return this.errorMessageField;
            }
            set {
                this.errorMessageField = value;
                this.RaisePropertyChanged("ErrorMessage");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsUnitCfiHwInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string unitSerialNumberField;
        
        private string soundCardField;
        
        private string vIDMemoryField;
        
        private string cDTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string UnitSerialNumber {
            get {
                return this.unitSerialNumberField;
            }
            set {
                this.unitSerialNumberField = value;
                this.RaisePropertyChanged("UnitSerialNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SoundCard {
            get {
                return this.soundCardField;
            }
            set {
                this.soundCardField = value;
                this.RaisePropertyChanged("SoundCard");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string VIDMemory {
            get {
                return this.vIDMemoryField;
            }
            set {
                this.vIDMemoryField = value;
                this.RaisePropertyChanged("VIDMemory");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CDType {
            get {
                return this.cDTypeField;
            }
            set {
                this.cDTypeField = value;
                this.RaisePropertyChanged("CDType");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsUnitCfiData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string unitSerialNumberField;
        
        private string sINumberField;
        
        private string isCFIField;
        
        private string isK661HField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string UnitSerialNumber {
            get {
                return this.unitSerialNumberField;
            }
            set {
                this.unitSerialNumberField = value;
                this.RaisePropertyChanged("UnitSerialNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string SINumber {
            get {
                return this.sINumberField;
            }
            set {
                this.sINumberField = value;
                this.RaisePropertyChanged("SINumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string IsCFI {
            get {
                return this.isCFIField;
            }
            set {
                this.isCFIField = value;
                this.RaisePropertyChanged("IsCFI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string IsK661H {
            get {
                return this.isK661HField;
            }
            set {
                this.isK661HField = value;
                this.RaisePropertyChanged("IsK661H");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSINumberInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string resultField;
        
        private string sINumberField;
        
        private string revisionField;
        
        private string sISyncStatusField;
        
        private string lastUseTimeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
                this.RaisePropertyChanged("Result");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string SINumber {
            get {
                return this.sINumberField;
            }
            set {
                this.sINumberField = value;
                this.RaisePropertyChanged("SINumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Revision {
            get {
                return this.revisionField;
            }
            set {
                this.revisionField = value;
                this.RaisePropertyChanged("Revision");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string SISyncStatus {
            get {
                return this.sISyncStatusField;
            }
            set {
                this.sISyncStatusField = value;
                this.RaisePropertyChanged("SISyncStatus");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string LastUseTime {
            get {
                return this.lastUseTimeField;
            }
            set {
                this.lastUseTimeField = value;
                this.RaisePropertyChanged("LastUseTime");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsComponent : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string componentPNField;
        
        private string componentSNField;
        
        private string componentCategoryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string ComponentPN {
            get {
                return this.componentPNField;
            }
            set {
                this.componentPNField = value;
                this.RaisePropertyChanged("ComponentPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ComponentSN {
            get {
                return this.componentSNField;
            }
            set {
                this.componentSNField = value;
                this.RaisePropertyChanged("ComponentSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string ComponentCategory {
            get {
                return this.componentCategoryField;
            }
            set {
                this.componentCategoryField = value;
                this.RaisePropertyChanged("ComponentCategory");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsNodeData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int nodeSeqField;
        
        private string nodeSerialNumberField;
        
        private string nodeServiceTagField;
        
        private clsComponent[] componentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int NodeSeq {
            get {
                return this.nodeSeqField;
            }
            set {
                this.nodeSeqField = value;
                this.RaisePropertyChanged("NodeSeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string NodeSerialNumber {
            get {
                return this.nodeSerialNumberField;
            }
            set {
                this.nodeSerialNumberField = value;
                this.RaisePropertyChanged("NodeSerialNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string NodeServiceTag {
            get {
                return this.nodeServiceTagField;
            }
            set {
                this.nodeServiceTagField = value;
                this.RaisePropertyChanged("NodeServiceTag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public clsComponent[] Components {
            get {
                return this.componentsField;
            }
            set {
                this.componentsField = value;
                this.RaisePropertyChanged("Components");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsDcsChassisInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cRDNumberField;
        
        private clsNodeData[] nodesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CRDNumber {
            get {
                return this.cRDNumberField;
            }
            set {
                this.cRDNumberField = value;
                this.RaisePropertyChanged("CRDNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public clsNodeData[] Nodes {
            get {
                return this.nodesField;
            }
            set {
                this.nodesField = value;
                this.RaisePropertyChanged("Nodes");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsSonyIDData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string iDCodeField;
        
        private string iDDataField;
        
        private string iDTagField;
        
        private short scrapFlagField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string IDCode {
            get {
                return this.iDCodeField;
            }
            set {
                this.iDCodeField = value;
                this.RaisePropertyChanged("IDCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string IDData {
            get {
                return this.iDDataField;
            }
            set {
                this.iDDataField = value;
                this.RaisePropertyChanged("IDData");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string IDTag {
            get {
                return this.iDTagField;
            }
            set {
                this.iDTagField = value;
                this.RaisePropertyChanged("IDTag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public short ScrapFlag {
            get {
                return this.scrapFlagField;
            }
            set {
                this.scrapFlagField = value;
                this.RaisePropertyChanged("ScrapFlag");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsPreparedMO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private short minSeqField;
        
        private short maxSeqField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public short MinSeq {
            get {
                return this.minSeqField;
            }
            set {
                this.minSeqField = value;
                this.RaisePropertyChanged("MinSeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public short MaxSeq {
            get {
                return this.maxSeqField;
            }
            set {
                this.maxSeqField = value;
                this.RaisePropertyChanged("MaxSeq");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsTestData : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uSNField;
        
        private TestDataType dataTypeField;
        
        private string patternField;
        
        private int patternSeqField;
        
        private double valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public TestDataType DataType {
            get {
                return this.dataTypeField;
            }
            set {
                this.dataTypeField = value;
                this.RaisePropertyChanged("DataType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Pattern {
            get {
                return this.patternField;
            }
            set {
                this.patternField = value;
                this.RaisePropertyChanged("Pattern");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public int PatternSeq {
            get {
                return this.patternSeqField;
            }
            set {
                this.patternSeqField = value;
                this.RaisePropertyChanged("PatternSeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public double Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public enum TestDataType {
        
        /// <remarks/>
        ReservedType0,
        
        /// <remarks/>
        sRGB,
        
        /// <remarks/>
        AdobeRGB,
        
        /// <remarks/>
        GrayTracking,
        
        /// <remarks/>
        Gamma,
        
        /// <remarks/>
        Color,
        
        /// <remarks/>
        Brightness,
        
        /// <remarks/>
        sRGB_X,
        
        /// <remarks/>
        sRGB_Y,
        
        /// <remarks/>
        Adobe_X,
        
        /// <remarks/>
        Adobe_Y,
        
        /// <remarks/>
        NativeRGB,
        
        /// <remarks/>
        ReservedType1,
        
        /// <remarks/>
        ReservedType2,
        
        /// <remarks/>
        ReservedType3,
        
        /// <remarks/>
        ReservedType4,
        
        /// <remarks/>
        ReservedType5,
        
        /// <remarks/>
        ReservedType6,
        
        /// <remarks/>
        ReservedType7,
        
        /// <remarks/>
        ReservedType8,
        
        /// <remarks/>
        ReservedType9,
        
        /// <remarks/>
        ReservedType10,
        
        /// <remarks/>
        ReservedType11,
        
        /// <remarks/>
        ReservedType12,
        
        /// <remarks/>
        ReservedType13,
        
        /// <remarks/>
        ReservedType14,
        
        /// <remarks/>
        ReservedType15,
        
        /// <remarks/>
        ReservedType16,
        
        /// <remarks/>
        ReservedType17,
        
        /// <remarks/>
        ReservedType18,
        
        /// <remarks/>
        ReservedType19,
        
        /// <remarks/>
        ReservedType20,
        
        /// <remarks/>
        ReservedType21,
        
        /// <remarks/>
        ReservedType22,
        
        /// <remarks/>
        ReservedType23,
        
        /// <remarks/>
        ReservedType24,
        
        /// <remarks/>
        ReservedType25,
        
        /// <remarks/>
        ReservedType26,
        
        /// <remarks/>
        ReservedType27,
        
        /// <remarks/>
        ReservedType28,
        
        /// <remarks/>
        ReservedType29,
        
        /// <remarks/>
        ReservedType30,
        
        /// <remarks/>
        ReservedType31,
        
        /// <remarks/>
        ReservedType32,
        
        /// <remarks/>
        ReservedType33,
        
        /// <remarks/>
        ReservedType34,
        
        /// <remarks/>
        ReservedType35,
        
        /// <remarks/>
        ReservedType36,
        
        /// <remarks/>
        ReservedType37,
        
        /// <remarks/>
        ReservedType38,
        
        /// <remarks/>
        ReservedType39,
        
        /// <remarks/>
        ReservedType40,
        
        /// <remarks/>
        ReservedType41,
        
        /// <remarks/>
        ReservedType42,
        
        /// <remarks/>
        ReservedType43,
        
        /// <remarks/>
        ReservedType44,
        
        /// <remarks/>
        ReservedType45,
        
        /// <remarks/>
        ReservedType46,
        
        /// <remarks/>
        ReservedType47,
        
        /// <remarks/>
        ReservedType48,
        
        /// <remarks/>
        ReservedType49,
        
        /// <remarks/>
        ReservedType50,
        
        /// <remarks/>
        ReservedType51,
        
        /// <remarks/>
        ReservedType52,
        
        /// <remarks/>
        ReservedType53,
        
        /// <remarks/>
        ReservedType54,
        
        /// <remarks/>
        ReservedType55,
        
        /// <remarks/>
        ReservedType56,
        
        /// <remarks/>
        ReservedType57,
        
        /// <remarks/>
        ReservedType58,
        
        /// <remarks/>
        ReservedType59,
        
        /// <remarks/>
        ReservedType60,
        
        /// <remarks/>
        ReservedType61,
        
        /// <remarks/>
        ReservedType62,
        
        /// <remarks/>
        ReservedType63,
        
        /// <remarks/>
        ReservedType64,
        
        /// <remarks/>
        ReservedType65,
        
        /// <remarks/>
        ReservedType66,
        
        /// <remarks/>
        ReservedType67,
        
        /// <remarks/>
        ReservedType68,
        
        /// <remarks/>
        ReservedType69,
        
        /// <remarks/>
        ReservedType70,
        
        /// <remarks/>
        ReservedType71,
        
        /// <remarks/>
        ReservedType72,
        
        /// <remarks/>
        ReservedType73,
        
        /// <remarks/>
        ReservedType74,
        
        /// <remarks/>
        ReservedType75,
        
        /// <remarks/>
        ReservedType76,
        
        /// <remarks/>
        ReservedType77,
        
        /// <remarks/>
        ReservedType78,
        
        /// <remarks/>
        ReservedType79,
        
        /// <remarks/>
        ReservedType80,
        
        /// <remarks/>
        ReservedType81,
        
        /// <remarks/>
        ReservedType82,
        
        /// <remarks/>
        ReservedType83,
        
        /// <remarks/>
        ReservedType84,
        
        /// <remarks/>
        ReservedType85,
        
        /// <remarks/>
        ReservedType86,
        
        /// <remarks/>
        ReservedType87,
        
        /// <remarks/>
        ReservedType88,
        
        /// <remarks/>
        ReservedType89,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsKeyItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int keyTypeField;
        
        private string keyField;
        
        private string valueField;
        
        private bool checkField;
        
        private bool returnCPNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int KeyType {
            get {
                return this.keyTypeField;
            }
            set {
                this.keyTypeField = value;
                this.RaisePropertyChanged("KeyType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("Key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool Check {
            get {
                return this.checkField;
            }
            set {
                this.checkField = value;
                this.RaisePropertyChanged("Check");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public bool ReturnCPN {
            get {
                return this.returnCPNField;
            }
            set {
                this.returnCPNField = value;
                this.RaisePropertyChanged("ReturnCPN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsCompareItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string compareItemField;
        
        private bool compareResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string CompareItem {
            get {
                return this.compareItemField;
            }
            set {
                this.compareItemField = value;
                this.RaisePropertyChanged("CompareItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool CompareResult {
            get {
                return this.compareResultField;
            }
            set {
                this.compareResultField = value;
                this.RaisePropertyChanged("CompareResult");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsInfoNameValue : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string infoNameField;
        
        private string infoValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string InfoName {
            get {
                return this.infoNameField;
            }
            set {
                this.infoNameField = value;
                this.RaisePropertyChanged("InfoName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string InfoValue {
            get {
                return this.infoValueField;
            }
            set {
                this.infoValueField = value;
                this.RaisePropertyChanged("InfoValue");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class stcGetLocInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int retcodeField;
        
        private string messageField;
        
        private System.Data.DataSet dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int retcode {
            get {
                return this.retcodeField;
            }
            set {
                this.retcodeField = value;
                this.RaisePropertyChanged("retcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.Data.DataSet data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("data");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class stcDeductCPN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int retcodeField;
        
        private string messageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int retcode {
            get {
                return this.retcodeField;
            }
            set {
                this.retcodeField = value;
                this.RaisePropertyChanged("retcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class stcD2PickUpReturn : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int retcodeField;
        
        private string messageField;
        
        private System.Data.DataSet dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int retcode {
            get {
                return this.retcodeField;
            }
            set {
                this.retcodeField = value;
                this.RaisePropertyChanged("retcode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
                this.RaisePropertyChanged("message");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public System.Data.DataSet data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
                this.RaisePropertyChanged("data");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsUSNItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int positionField;
        
        private string moField;
        
        private string cSNField;
        
        private string cPNField;
        
        private string cATEGORYField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
                this.RaisePropertyChanged("Position");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CSN {
            get {
                return this.cSNField;
            }
            set {
                this.cSNField = value;
                this.RaisePropertyChanged("CSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string CATEGORY {
            get {
                return this.cATEGORYField;
            }
            set {
                this.cATEGORYField = value;
                this.RaisePropertyChanged("CATEGORY");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsUSN : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string uSNField;
        
        private string uPNField;
        
        private string moField;
        
        private string cATEGORYField;
        
        private string lineField;
        
        private string stageField;
        
        private string nextStageField;
        
        private string tourField;
        
        private string statusField;
        
        private string oldUSNField;
        
        private System.DateTime createDateField;
        
        private System.DateTime updateDateField;
        
        private int eSOPCPNSeqField;
        
        private string routeNameField;
        
        private string startFromStageField;
        
        private string routeTourField;
        
        private string erpPalletIDField;
        
        private string lotNoField;
        
        private int groupSeqField;
        
        private bool needInsertSFCUSNINPROCESSField;
        
        private clsUSNItem[] uSNItemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string USN {
            get {
                return this.uSNField;
            }
            set {
                this.uSNField = value;
                this.RaisePropertyChanged("USN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CATEGORY {
            get {
                return this.cATEGORYField;
            }
            set {
                this.cATEGORYField = value;
                this.RaisePropertyChanged("CATEGORY");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string Stage {
            get {
                return this.stageField;
            }
            set {
                this.stageField = value;
                this.RaisePropertyChanged("Stage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string NextStage {
            get {
                return this.nextStageField;
            }
            set {
                this.nextStageField = value;
                this.RaisePropertyChanged("NextStage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string Tour {
            get {
                return this.tourField;
            }
            set {
                this.tourField = value;
                this.RaisePropertyChanged("Tour");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string OldUSN {
            get {
                return this.oldUSNField;
            }
            set {
                this.oldUSNField = value;
                this.RaisePropertyChanged("OldUSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public System.DateTime UpdateDate {
            get {
                return this.updateDateField;
            }
            set {
                this.updateDateField = value;
                this.RaisePropertyChanged("UpdateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int ESOPCPNSeq {
            get {
                return this.eSOPCPNSeqField;
            }
            set {
                this.eSOPCPNSeqField = value;
                this.RaisePropertyChanged("ESOPCPNSeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string RouteName {
            get {
                return this.routeNameField;
            }
            set {
                this.routeNameField = value;
                this.RaisePropertyChanged("RouteName");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string StartFromStage {
            get {
                return this.startFromStageField;
            }
            set {
                this.startFromStageField = value;
                this.RaisePropertyChanged("StartFromStage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string RouteTour {
            get {
                return this.routeTourField;
            }
            set {
                this.routeTourField = value;
                this.RaisePropertyChanged("RouteTour");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string ErpPalletID {
            get {
                return this.erpPalletIDField;
            }
            set {
                this.erpPalletIDField = value;
                this.RaisePropertyChanged("ErpPalletID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string LotNo {
            get {
                return this.lotNoField;
            }
            set {
                this.lotNoField = value;
                this.RaisePropertyChanged("LotNo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public int GroupSeq {
            get {
                return this.groupSeqField;
            }
            set {
                this.groupSeqField = value;
                this.RaisePropertyChanged("GroupSeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public bool NeedInsertSFCUSNINPROCESS {
            get {
                return this.needInsertSFCUSNINPROCESSField;
            }
            set {
                this.needInsertSFCUSNINPROCESSField = value;
                this.RaisePropertyChanged("NeedInsertSFCUSNINPROCESS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=20)]
        public clsUSNItem[] USNItems {
            get {
                return this.uSNItemsField;
            }
            set {
                this.uSNItemsField = value;
                this.RaisePropertyChanged("USNItems");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsMOItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int positionField;
        
        private string cPNField;
        
        private string cSNRuleField;
        
        private string categoryField;
        
        private int categorySeqField;
        
        private int sequenceField;
        
        private int eSOPStepField;
        
        private string stageCodeField;
        
        private int dayNField;
        
        private string aLTCPNField;
        
        private string aLTCSNRuleField;
        
        private int groupSeqField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
                this.RaisePropertyChanged("Position");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string CPN {
            get {
                return this.cPNField;
            }
            set {
                this.cPNField = value;
                this.RaisePropertyChanged("CPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string CSNRule {
            get {
                return this.cSNRuleField;
            }
            set {
                this.cSNRuleField = value;
                this.RaisePropertyChanged("CSNRule");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
                this.RaisePropertyChanged("Category");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public int CategorySeq {
            get {
                return this.categorySeqField;
            }
            set {
                this.categorySeqField = value;
                this.RaisePropertyChanged("CategorySeq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int Sequence {
            get {
                return this.sequenceField;
            }
            set {
                this.sequenceField = value;
                this.RaisePropertyChanged("Sequence");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public int ESOPStep {
            get {
                return this.eSOPStepField;
            }
            set {
                this.eSOPStepField = value;
                this.RaisePropertyChanged("ESOPStep");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string StageCode {
            get {
                return this.stageCodeField;
            }
            set {
                this.stageCodeField = value;
                this.RaisePropertyChanged("StageCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int DayN {
            get {
                return this.dayNField;
            }
            set {
                this.dayNField = value;
                this.RaisePropertyChanged("DayN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string ALTCPN {
            get {
                return this.aLTCPNField;
            }
            set {
                this.aLTCPNField = value;
                this.RaisePropertyChanged("ALTCPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string ALTCSNRule {
            get {
                return this.aLTCSNRuleField;
            }
            set {
                this.aLTCSNRuleField = value;
                this.RaisePropertyChanged("ALTCSNRule");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int GroupSeq {
            get {
                return this.groupSeqField;
            }
            set {
                this.groupSeqField = value;
                this.RaisePropertyChanged("GroupSeq");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsMoInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int x3CField;
        
        private string productGroupField;
        
        private int k3TypeField;
        
        private string countryCodeField;
        
        private string pCIDField;
        
        private int bSaMField;
        
        private string specSheetVerField;
        
        private string specLabelVerField;
        
        private string crdModelField;
        
        private string softloadPNField;
        
        private string crdNumberField;
        
        private int is220VField;
        
        private int potomacField;
        
        private int cFIField;
        
        private int picassoField;
        
        private string hardwareField;
        
        private string versionField;
        
        private int urgentMoField;
        
        private string fwField;
        
        private string vintageField;
        
        private string biosField;
        
        private string headCodeField;
        
        private string mBSNFRUField;
        
        private string mBSNECNumberField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int X3C {
            get {
                return this.x3CField;
            }
            set {
                this.x3CField = value;
                this.RaisePropertyChanged("X3C");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string ProductGroup {
            get {
                return this.productGroupField;
            }
            set {
                this.productGroupField = value;
                this.RaisePropertyChanged("ProductGroup");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public int K3Type {
            get {
                return this.k3TypeField;
            }
            set {
                this.k3TypeField = value;
                this.RaisePropertyChanged("K3Type");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CountryCode {
            get {
                return this.countryCodeField;
            }
            set {
                this.countryCodeField = value;
                this.RaisePropertyChanged("CountryCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string PCID {
            get {
                return this.pCIDField;
            }
            set {
                this.pCIDField = value;
                this.RaisePropertyChanged("PCID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public int BSaM {
            get {
                return this.bSaMField;
            }
            set {
                this.bSaMField = value;
                this.RaisePropertyChanged("BSaM");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string SpecSheetVer {
            get {
                return this.specSheetVerField;
            }
            set {
                this.specSheetVerField = value;
                this.RaisePropertyChanged("SpecSheetVer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string SpecLabelVer {
            get {
                return this.specLabelVerField;
            }
            set {
                this.specLabelVerField = value;
                this.RaisePropertyChanged("SpecLabelVer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string CrdModel {
            get {
                return this.crdModelField;
            }
            set {
                this.crdModelField = value;
                this.RaisePropertyChanged("CrdModel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string SoftloadPN {
            get {
                return this.softloadPNField;
            }
            set {
                this.softloadPNField = value;
                this.RaisePropertyChanged("SoftloadPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string CrdNumber {
            get {
                return this.crdNumberField;
            }
            set {
                this.crdNumberField = value;
                this.RaisePropertyChanged("CrdNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public int Is220V {
            get {
                return this.is220VField;
            }
            set {
                this.is220VField = value;
                this.RaisePropertyChanged("Is220V");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public int Potomac {
            get {
                return this.potomacField;
            }
            set {
                this.potomacField = value;
                this.RaisePropertyChanged("Potomac");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public int CFI {
            get {
                return this.cFIField;
            }
            set {
                this.cFIField = value;
                this.RaisePropertyChanged("CFI");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public int Picasso {
            get {
                return this.picassoField;
            }
            set {
                this.picassoField = value;
                this.RaisePropertyChanged("Picasso");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public string Hardware {
            get {
                return this.hardwareField;
            }
            set {
                this.hardwareField = value;
                this.RaisePropertyChanged("Hardware");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string Version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
                this.RaisePropertyChanged("Version");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public int UrgentMo {
            get {
                return this.urgentMoField;
            }
            set {
                this.urgentMoField = value;
                this.RaisePropertyChanged("UrgentMo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string FW {
            get {
                return this.fwField;
            }
            set {
                this.fwField = value;
                this.RaisePropertyChanged("FW");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string Vintage {
            get {
                return this.vintageField;
            }
            set {
                this.vintageField = value;
                this.RaisePropertyChanged("Vintage");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string Bios {
            get {
                return this.biosField;
            }
            set {
                this.biosField = value;
                this.RaisePropertyChanged("Bios");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string HeadCode {
            get {
                return this.headCodeField;
            }
            set {
                this.headCodeField = value;
                this.RaisePropertyChanged("HeadCode");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string MBSNFRU {
            get {
                return this.mBSNFRUField;
            }
            set {
                this.mBSNFRUField = value;
                this.RaisePropertyChanged("MBSNFRU");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string MBSNECNumber {
            get {
                return this.mBSNECNumberField;
            }
            set {
                this.mBSNECNumberField = value;
                this.RaisePropertyChanged("MBSNECNumber");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsMOReady : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool tPSFlagField;
        
        private bool labelFlagField;
        
        private bool uSNFlagField;
        
        private bool eSOPFlagField;
        
        private bool readyFlagField;
        
        private bool pTLFlagField;
        
        private bool lCFlagField;
        
        private bool cISFlagField;
        
        private bool rFIDFlagField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool TPSFlag {
            get {
                return this.tPSFlagField;
            }
            set {
                this.tPSFlagField = value;
                this.RaisePropertyChanged("TPSFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool LabelFlag {
            get {
                return this.labelFlagField;
            }
            set {
                this.labelFlagField = value;
                this.RaisePropertyChanged("LabelFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool USNFlag {
            get {
                return this.uSNFlagField;
            }
            set {
                this.uSNFlagField = value;
                this.RaisePropertyChanged("USNFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public bool ESOPFlag {
            get {
                return this.eSOPFlagField;
            }
            set {
                this.eSOPFlagField = value;
                this.RaisePropertyChanged("ESOPFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public bool ReadyFlag {
            get {
                return this.readyFlagField;
            }
            set {
                this.readyFlagField = value;
                this.RaisePropertyChanged("ReadyFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public bool PTLFlag {
            get {
                return this.pTLFlagField;
            }
            set {
                this.pTLFlagField = value;
                this.RaisePropertyChanged("PTLFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public bool LCFlag {
            get {
                return this.lCFlagField;
            }
            set {
                this.lCFlagField = value;
                this.RaisePropertyChanged("LCFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public bool CISFlag {
            get {
                return this.cISFlagField;
            }
            set {
                this.cISFlagField = value;
                this.RaisePropertyChanged("CISFlag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public bool RFIDFlag {
            get {
                return this.rFIDFlagField;
            }
            set {
                this.rFIDFlagField = value;
                this.RaisePropertyChanged("RFIDFlag");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsMO : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string moField;
        
        private int lotField;
        
        private string uPNField;
        
        private string customerPNField;
        
        private string lineField;
        
        private System.DateTime planDateField;
        
        private System.DateTime createDateField;
        
        private System.DateTime updateDateField;
        
        private int inputField;
        
        private int outputField;
        
        private string statusField;
        
        private string soField;
        
        private string sOLineField;
        
        private string bIOSVerField;
        
        private string prodTypeField;
        
        private int shippingTypeField;
        
        private string routeField;
        
        private string uSNRuleField;
        
        private string prodBrandField;
        
        private string mFGTypeField;
        
        private string customNumField;
        
        private string customPOField;
        
        private string endCustomPOField;
        
        private string mBVersionField;
        
        private int mOTypeField;
        
        private string modelField;
        
        private string modelFamilyField;
        
        private string eCNumberField;
        
        private int unitPerPCBField;
        
        private string fRUField;
        
        private string cPNOField;
        
        private string mBSNCPNField;
        
        private string mBSNVERField;
        
        private string storageLocField;
        
        private clsMOReady moReadyField;
        
        private clsMoInfo moInfoField;
        
        private clsMOItem[] moItemsField;
        
        private int moConfigIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string MO {
            get {
                return this.moField;
            }
            set {
                this.moField = value;
                this.RaisePropertyChanged("MO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public int Lot {
            get {
                return this.lotField;
            }
            set {
                this.lotField = value;
                this.RaisePropertyChanged("Lot");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string UPN {
            get {
                return this.uPNField;
            }
            set {
                this.uPNField = value;
                this.RaisePropertyChanged("UPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string CustomerPN {
            get {
                return this.customerPNField;
            }
            set {
                this.customerPNField = value;
                this.RaisePropertyChanged("CustomerPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string Line {
            get {
                return this.lineField;
            }
            set {
                this.lineField = value;
                this.RaisePropertyChanged("Line");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public System.DateTime PlanDate {
            get {
                return this.planDateField;
            }
            set {
                this.planDateField = value;
                this.RaisePropertyChanged("PlanDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
                this.RaisePropertyChanged("CreateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public System.DateTime UpdateDate {
            get {
                return this.updateDateField;
            }
            set {
                this.updateDateField = value;
                this.RaisePropertyChanged("UpdateDate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public int Input {
            get {
                return this.inputField;
            }
            set {
                this.inputField = value;
                this.RaisePropertyChanged("Input");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public int Output {
            get {
                return this.outputField;
            }
            set {
                this.outputField = value;
                this.RaisePropertyChanged("Output");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
                this.RaisePropertyChanged("Status");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string SO {
            get {
                return this.soField;
            }
            set {
                this.soField = value;
                this.RaisePropertyChanged("SO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string SOLine {
            get {
                return this.sOLineField;
            }
            set {
                this.sOLineField = value;
                this.RaisePropertyChanged("SOLine");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string BIOSVer {
            get {
                return this.bIOSVerField;
            }
            set {
                this.bIOSVerField = value;
                this.RaisePropertyChanged("BIOSVer");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=14)]
        public string ProdType {
            get {
                return this.prodTypeField;
            }
            set {
                this.prodTypeField = value;
                this.RaisePropertyChanged("ProdType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=15)]
        public int ShippingType {
            get {
                return this.shippingTypeField;
            }
            set {
                this.shippingTypeField = value;
                this.RaisePropertyChanged("ShippingType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=16)]
        public string Route {
            get {
                return this.routeField;
            }
            set {
                this.routeField = value;
                this.RaisePropertyChanged("Route");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=17)]
        public string USNRule {
            get {
                return this.uSNRuleField;
            }
            set {
                this.uSNRuleField = value;
                this.RaisePropertyChanged("USNRule");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=18)]
        public string ProdBrand {
            get {
                return this.prodBrandField;
            }
            set {
                this.prodBrandField = value;
                this.RaisePropertyChanged("ProdBrand");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=19)]
        public string MFGType {
            get {
                return this.mFGTypeField;
            }
            set {
                this.mFGTypeField = value;
                this.RaisePropertyChanged("MFGType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=20)]
        public string CustomNum {
            get {
                return this.customNumField;
            }
            set {
                this.customNumField = value;
                this.RaisePropertyChanged("CustomNum");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=21)]
        public string CustomPO {
            get {
                return this.customPOField;
            }
            set {
                this.customPOField = value;
                this.RaisePropertyChanged("CustomPO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=22)]
        public string EndCustomPO {
            get {
                return this.endCustomPOField;
            }
            set {
                this.endCustomPOField = value;
                this.RaisePropertyChanged("EndCustomPO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=23)]
        public string MBVersion {
            get {
                return this.mBVersionField;
            }
            set {
                this.mBVersionField = value;
                this.RaisePropertyChanged("MBVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=24)]
        public int MOType {
            get {
                return this.mOTypeField;
            }
            set {
                this.mOTypeField = value;
                this.RaisePropertyChanged("MOType");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=25)]
        public string Model {
            get {
                return this.modelField;
            }
            set {
                this.modelField = value;
                this.RaisePropertyChanged("Model");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=26)]
        public string ModelFamily {
            get {
                return this.modelFamilyField;
            }
            set {
                this.modelFamilyField = value;
                this.RaisePropertyChanged("ModelFamily");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=27)]
        public string ECNumber {
            get {
                return this.eCNumberField;
            }
            set {
                this.eCNumberField = value;
                this.RaisePropertyChanged("ECNumber");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=28)]
        public int UnitPerPCB {
            get {
                return this.unitPerPCBField;
            }
            set {
                this.unitPerPCBField = value;
                this.RaisePropertyChanged("UnitPerPCB");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=29)]
        public string FRU {
            get {
                return this.fRUField;
            }
            set {
                this.fRUField = value;
                this.RaisePropertyChanged("FRU");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=30)]
        public string CPNO {
            get {
                return this.cPNOField;
            }
            set {
                this.cPNOField = value;
                this.RaisePropertyChanged("CPNO");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=31)]
        public string MBSNCPN {
            get {
                return this.mBSNCPNField;
            }
            set {
                this.mBSNCPNField = value;
                this.RaisePropertyChanged("MBSNCPN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=32)]
        public string MBSNVER {
            get {
                return this.mBSNVERField;
            }
            set {
                this.mBSNVERField = value;
                this.RaisePropertyChanged("MBSNVER");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=33)]
        public string StorageLoc {
            get {
                return this.storageLocField;
            }
            set {
                this.storageLocField = value;
                this.RaisePropertyChanged("StorageLoc");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=34)]
        public clsMOReady MoReady {
            get {
                return this.moReadyField;
            }
            set {
                this.moReadyField = value;
                this.RaisePropertyChanged("MoReady");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=35)]
        public clsMoInfo MoInfo {
            get {
                return this.moInfoField;
            }
            set {
                this.moInfoField = value;
                this.RaisePropertyChanged("MoInfo");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=36)]
        public clsMOItem[] MoItems {
            get {
                return this.moItemsField;
            }
            set {
                this.moItemsField = value;
                this.RaisePropertyChanged("MoItems");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=37)]
        public int MoConfigID {
            get {
                return this.moConfigIDField;
            }
            set {
                this.moConfigIDField = value;
                this.RaisePropertyChanged("MoConfigID");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Basic.WebService/WebService")]
    public partial class clsMOCheckFlag : object, System.ComponentModel.INotifyPropertyChanged {
        
        private bool sequenceField;
        
        private bool eSOPField;
        
        private bool includeAltCPNField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public bool Sequence {
            get {
                return this.sequenceField;
            }
            set {
                this.sequenceField = value;
                this.RaisePropertyChanged("Sequence");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool ESOP {
            get {
                return this.eSOPField;
            }
            set {
                this.eSOPField = value;
                this.RaisePropertyChanged("ESOP");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public bool IncludeAltCPN {
            get {
                return this.includeAltCPNField;
            }
            set {
                this.includeAltCPNField = value;
                this.RaisePropertyChanged("IncludeAltCPN");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsWSConfig : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int seqField;
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int Seq {
            get {
                return this.seqField;
            }
            set {
                this.seqField = value;
                this.RaisePropertyChanged("Seq");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
                this.RaisePropertyChanged("Key");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
                this.RaisePropertyChanged("Value");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsWSInfo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string assemblyTitleField;
        
        private string assemblyDescriptionField;
        
        private string assemblyCompanyField;
        
        private string assemblyProductField;
        
        private string assemblyCopyrightField;
        
        private string assemblyTrademarkField;
        
        private string assemblyVersionField;
        
        private string cLSCompliantField;
        
        private string debuggableField;
        
        private string guidField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string AssemblyTitle {
            get {
                return this.assemblyTitleField;
            }
            set {
                this.assemblyTitleField = value;
                this.RaisePropertyChanged("AssemblyTitle");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string AssemblyDescription {
            get {
                return this.assemblyDescriptionField;
            }
            set {
                this.assemblyDescriptionField = value;
                this.RaisePropertyChanged("AssemblyDescription");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string AssemblyCompany {
            get {
                return this.assemblyCompanyField;
            }
            set {
                this.assemblyCompanyField = value;
                this.RaisePropertyChanged("AssemblyCompany");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string AssemblyProduct {
            get {
                return this.assemblyProductField;
            }
            set {
                this.assemblyProductField = value;
                this.RaisePropertyChanged("AssemblyProduct");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string AssemblyCopyright {
            get {
                return this.assemblyCopyrightField;
            }
            set {
                this.assemblyCopyrightField = value;
                this.RaisePropertyChanged("AssemblyCopyright");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string AssemblyTrademark {
            get {
                return this.assemblyTrademarkField;
            }
            set {
                this.assemblyTrademarkField = value;
                this.RaisePropertyChanged("AssemblyTrademark");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string AssemblyVersion {
            get {
                return this.assemblyVersionField;
            }
            set {
                this.assemblyVersionField = value;
                this.RaisePropertyChanged("AssemblyVersion");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string CLSCompliant {
            get {
                return this.cLSCompliantField;
            }
            set {
                this.cLSCompliantField = value;
                this.RaisePropertyChanged("CLSCompliant");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string Debuggable {
            get {
                return this.debuggableField;
            }
            set {
                this.debuggableField = value;
                this.RaisePropertyChanged("Debuggable");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string Guid {
            get {
                return this.guidField;
            }
            set {
                this.guidField = value;
                this.RaisePropertyChanged("Guid");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsDynamicParameter : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string strParamField;
        
        private string strValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string strParam {
            get {
                return this.strParamField;
            }
            set {
                this.strParamField = value;
                this.RaisePropertyChanged("strParam");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string strValue {
            get {
                return this.strValueField;
            }
            set {
                this.strValueField = value;
                this.RaisePropertyChanged("strValue");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsTestItemResult : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string strTestItemField;
        
        private string strFaiLagField;
        
        private string strTestResultField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string strTestItem {
            get {
                return this.strTestItemField;
            }
            set {
                this.strTestItemField = value;
                this.RaisePropertyChanged("strTestItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string strFaiLag {
            get {
                return this.strFaiLagField;
            }
            set {
                this.strFaiLagField = value;
                this.RaisePropertyChanged("strFaiLag");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string strTestResult {
            get {
                return this.strTestResultField;
            }
            set {
                this.strTestResultField = value;
                this.RaisePropertyChanged("strTestResult");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://localhost/Tester.WebService/WebService")]
    public partial class clsRaiseMTDLRequest : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string strModelFamilyField;
        
        private string strTestLevelField;
        
        private string strSampleRateField;
        
        private string strTestItemField;
        
        private string strTestItemYRField;
        
        private string strAccumuLateQtyField;
        
        private string strQtyField;
        
        private string strFaiFinishField;
        
        private string strFailQtyField;
        
        private string strFailCheckBaseField;
        
        private string strNormalizationField;
        
        private string strDailyFaiBaseField;
        
        private string strUSNField;
        
        private string strStageField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string strModelFamily {
            get {
                return this.strModelFamilyField;
            }
            set {
                this.strModelFamilyField = value;
                this.RaisePropertyChanged("strModelFamily");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string strTestLevel {
            get {
                return this.strTestLevelField;
            }
            set {
                this.strTestLevelField = value;
                this.RaisePropertyChanged("strTestLevel");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string strSampleRate {
            get {
                return this.strSampleRateField;
            }
            set {
                this.strSampleRateField = value;
                this.RaisePropertyChanged("strSampleRate");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string strTestItem {
            get {
                return this.strTestItemField;
            }
            set {
                this.strTestItemField = value;
                this.RaisePropertyChanged("strTestItem");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string strTestItemYR {
            get {
                return this.strTestItemYRField;
            }
            set {
                this.strTestItemYRField = value;
                this.RaisePropertyChanged("strTestItemYR");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=5)]
        public string strAccumuLateQty {
            get {
                return this.strAccumuLateQtyField;
            }
            set {
                this.strAccumuLateQtyField = value;
                this.RaisePropertyChanged("strAccumuLateQty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=6)]
        public string strQty {
            get {
                return this.strQtyField;
            }
            set {
                this.strQtyField = value;
                this.RaisePropertyChanged("strQty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=7)]
        public string strFaiFinish {
            get {
                return this.strFaiFinishField;
            }
            set {
                this.strFaiFinishField = value;
                this.RaisePropertyChanged("strFaiFinish");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=8)]
        public string strFailQty {
            get {
                return this.strFailQtyField;
            }
            set {
                this.strFailQtyField = value;
                this.RaisePropertyChanged("strFailQty");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=9)]
        public string strFailCheckBase {
            get {
                return this.strFailCheckBaseField;
            }
            set {
                this.strFailCheckBaseField = value;
                this.RaisePropertyChanged("strFailCheckBase");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=10)]
        public string strNormalization {
            get {
                return this.strNormalizationField;
            }
            set {
                this.strNormalizationField = value;
                this.RaisePropertyChanged("strNormalization");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=11)]
        public string strDailyFaiBase {
            get {
                return this.strDailyFaiBaseField;
            }
            set {
                this.strDailyFaiBaseField = value;
                this.RaisePropertyChanged("strDailyFaiBase");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=12)]
        public string strUSN {
            get {
                return this.strUSNField;
            }
            set {
                this.strUSNField = value;
                this.RaisePropertyChanged("strUSN");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=13)]
        public string strStage {
            get {
                return this.strStageField;
            }
            set {
                this.strStageField = value;
                this.RaisePropertyChanged("strStage");
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAndProcessKtlOutEvent", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetAndProcessKtlOutEventRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string IP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("ReturnKtlOutEvent")]
        public SharpFrameSmall.Common.SFCS.clsKtlOutEvent[] ReturnKtlOutEvent;
        
        public GetAndProcessKtlOutEventRequest() {
        }
        
        public GetAndProcessKtlOutEventRequest(string IP, SharpFrameSmall.Common.SFCS.clsKtlOutEvent[] ReturnKtlOutEvent) {
            this.IP = IP;
            this.ReturnKtlOutEvent = ReturnKtlOutEvent;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAndProcessKtlOutEventResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetAndProcessKtlOutEventResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetAndProcessKtlOutEventResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("ReturnKtlOutEvent")]
        public SharpFrameSmall.Common.SFCS.clsKtlOutEvent[] ReturnKtlOutEvent;
        
        public GetAndProcessKtlOutEventResponse() {
        }
        
        public GetAndProcessKtlOutEventResponse(string GetAndProcessKtlOutEventResult, SharpFrameSmall.Common.SFCS.clsKtlOutEvent[] ReturnKtlOutEvent) {
            this.GetAndProcessKtlOutEventResult = GetAndProcessKtlOutEventResult;
            this.ReturnKtlOutEvent = ReturnKtlOutEvent;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadMTDLResult", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadMTDLResultRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string USN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Stage;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("TestItem")]
        public SharpFrameSmall.Common.SFCS.clsTestItemResult[] TestItem;
        
        public UploadMTDLResultRequest() {
        }
        
        public UploadMTDLResultRequest(string USN, string Stage, SharpFrameSmall.Common.SFCS.clsTestItemResult[] TestItem) {
            this.USN = USN;
            this.Stage = Stage;
            this.TestItem = TestItem;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadMTDLResultResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadMTDLResultResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadMTDLResultResult;
        
        public UploadMTDLResultResponse() {
        }
        
        public UploadMTDLResultResponse(string UploadMTDLResultResult) {
            this.UploadMTDLResultResult = UploadMTDLResultResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DynamicDBFunction", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class DynamicDBFunctionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string FunctionName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Stage;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("DynamicParameter")]
        public SharpFrameSmall.Common.SFCS.clsDynamicParameter[] DynamicParameters;
        
        public DynamicDBFunctionRequest() {
        }
        
        public DynamicDBFunctionRequest(string FunctionName, string Stage, SharpFrameSmall.Common.SFCS.clsDynamicParameter[] DynamicParameters) {
            this.FunctionName = FunctionName;
            this.Stage = Stage;
            this.DynamicParameters = DynamicParameters;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DynamicDBFunctionResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class DynamicDBFunctionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string DynamicDBFunctionResult;
        
        public DynamicDBFunctionResponse() {
        }
        
        public DynamicDBFunctionResponse(string DynamicDBFunctionResult) {
            this.DynamicDBFunctionResult = DynamicDBFunctionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckInByUser", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CheckInByUser {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UserID;
        
        public CheckInByUser() {
        }
        
        public CheckInByUser(string UnitSerialNumber, string StageCode, string UserID) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.UserID = UserID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckInByUserResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CheckInByUser1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public bool CheckInByUserResult;
        
        public CheckInByUser1() {
        }
        
        public CheckInByUser1(bool CheckInByUserResult) {
            this.CheckInByUserResult = CheckInByUserResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckOutByUser", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CheckOutByUser {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UserID;
        
        public CheckOutByUser() {
        }
        
        public CheckOutByUser(string UnitSerialNumber, string StageCode, string UserID) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.UserID = UserID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CheckOutByUserResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CheckOutByUser1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public bool CheckOutByUserResult;
        
        public CheckOutByUser1() {
        }
        
        public CheckOutByUser1(bool CheckOutByUserResult) {
            this.CheckOutByUserResult = CheckOutByUserResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTrnStartDatewithTrnStartDate", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTrnStartDatewithTrnStartDate {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UserID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string WorkStation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string TrnStartDate;
        
        public UploadTrnStartDatewithTrnStartDate() {
        }
        
        public UploadTrnStartDatewithTrnStartDate(string UnitSerialNumber, string StageCode, string UserID, string WorkStation, string TrnStartDate) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.UserID = UserID;
            this.WorkStation = WorkStation;
            this.TrnStartDate = TrnStartDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTrnStartDatewithTrnStartDateResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTrnStartDatewithTrnStartDate1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadTrnStartDatewithTrnStartDateResult;
        
        public UploadTrnStartDatewithTrnStartDate1() {
        }
        
        public UploadTrnStartDatewithTrnStartDate1(string UploadTrnStartDatewithTrnStartDateResult) {
            this.UploadTrnStartDatewithTrnStartDateResult = UploadTrnStartDatewithTrnStartDateResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BatchUploadUSNInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class BatchUploadUSNInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValue;
        
        public BatchUploadUSNInfoRequest() {
        }
        
        public BatchUploadUSNInfoRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValue) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.InfoNameValue = InfoNameValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BatchUploadUSNInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class BatchUploadUSNInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string BatchUploadUSNInfoResult;
        
        public BatchUploadUSNInfoResponse() {
        }
        
        public BatchUploadUSNInfoResponse(string BatchUploadUSNInfoResult) {
            this.BatchUploadUSNInfoResult = BatchUploadUSNInfoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Compare", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompareRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CompareItem")]
        public SharpFrameSmall.Common.SFCS.clsCompareItem[] CompareItems;
        
        public CompareRequest() {
        }
        
        public CompareRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsCompareItem[] CompareItems) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.CompareItems = CompareItems;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompareResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompareResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string CompareResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("CompareItem")]
        public SharpFrameSmall.Common.SFCS.clsCompareItem[] CompareItems;
        
        public CompareResponse() {
        }
        
        public CompareResponse(string CompareResult, SharpFrameSmall.Common.SFCS.clsCompareItem[] CompareItems) {
            this.CompareResult = CompareResult;
            this.CompareItems = CompareItems;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTestEquipments", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTestEquipmentsRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("TestEquipments")]
        public string[] TestEquipments;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Model;
        
        public UploadTestEquipmentsRequest() {
        }
        
        public UploadTestEquipmentsRequest(string StageCode, string[] TestEquipments, string Model) {
            this.StageCode = StageCode;
            this.TestEquipments = TestEquipments;
            this.Model = Model;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTestEquipmentsResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTestEquipmentsResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadTestEquipmentsResult;
        
        public UploadTestEquipmentsResponse() {
        }
        
        public UploadTestEquipmentsResponse(string UploadTestEquipmentsResult) {
            this.UploadTestEquipmentsResult = UploadTestEquipmentsResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTestData", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTestDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("TestData")]
        public SharpFrameSmall.Common.SFCS.clsTestData[] TestData;
        
        public UploadTestDataRequest() {
        }
        
        public UploadTestDataRequest(string StageCode, SharpFrameSmall.Common.SFCS.clsTestData[] TestData) {
            this.StageCode = StageCode;
            this.TestData = TestData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadTestDataResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadTestDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadTestDataResult;
        
        public UploadTestDataResponse() {
        }
        
        public UploadTestDataResponse(string UploadTestDataResult) {
            this.UploadTestDataResult = UploadTestDataResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPreparedMOList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPreparedMOListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string GetResult;
        
        public GetPreparedMOListRequest() {
        }
        
        public GetPreparedMOListRequest(string StageCode, string GetResult) {
            this.StageCode = StageCode;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPreparedMOListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPreparedMOListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public SharpFrameSmall.Common.SFCS.clsPreparedMO[] GetPreparedMOListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string GetResult;
        
        public GetPreparedMOListResponse() {
        }
        
        public GetPreparedMOListResponse(SharpFrameSmall.Common.SFCS.clsPreparedMO[] GetPreparedMOListResult, string GetResult) {
            this.GetPreparedMOListResult = GetPreparedMOListResult;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNlistByRange", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNlistByRangeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public short MinSeq;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public short MaxSeq;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string GetResult;
        
        public GetUSNlistByRangeRequest() {
        }
        
        public GetUSNlistByRangeRequest(string MO, short MinSeq, short MaxSeq, string StageCode, string GetResult) {
            this.MO = MO;
            this.MinSeq = MinSeq;
            this.MaxSeq = MaxSeq;
            this.StageCode = StageCode;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNlistByRangeResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNlistByRangeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string[] GetUSNlistByRangeResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string GetResult;
        
        public GetUSNlistByRangeResponse() {
        }
        
        public GetUSNlistByRangeResponse(string[] GetUSNlistByRangeResult, string GetResult) {
            this.GetUSNlistByRangeResult = GetUSNlistByRangeResult;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateSonyKey", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateSonyKeyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string IDCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string IDData;
        
        public AllocateSonyKeyRequest() {
        }
        
        public AllocateSonyKeyRequest(string UnitSerialNumber, string StageCode, string IDCode, string IDData) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.IDCode = IDCode;
            this.IDData = IDData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateSonyKeyResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateSonyKeyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string AllocateSonyKeyResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string IDData;
        
        public AllocateSonyKeyResponse() {
        }
        
        public AllocateSonyKeyResponse(string AllocateSonyKeyResult, string IDData) {
            this.AllocateSonyKeyResult = AllocateSonyKeyResult;
            this.IDData = IDData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateSonyKeys", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateSonyKeysRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string IDCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string KeyQuantity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute("IDDatas")]
        public string[] IDDatas;
        
        public AllocateSonyKeysRequest() {
        }
        
        public AllocateSonyKeysRequest(string UnitSerialNumber, string StageCode, string IDCode, string KeyQuantity, string[] IDDatas) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.IDCode = IDCode;
            this.KeyQuantity = KeyQuantity;
            this.IDDatas = IDDatas;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateSonyKeysResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateSonyKeysResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string AllocateSonyKeysResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string KeyQuantity;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("IDDatas")]
        public string[] IDDatas;
        
        public AllocateSonyKeysResponse() {
        }
        
        public AllocateSonyKeysResponse(string AllocateSonyKeysResult, string KeyQuantity, string[] IDDatas) {
            this.AllocateSonyKeysResult = AllocateSonyKeysResult;
            this.KeyQuantity = KeyQuantity;
            this.IDDatas = IDDatas;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BindingUSNRIPalletID", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class BindingUSNRIPalletIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public short Type;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string RIPalletID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitSerialNumber;
        
        public BindingUSNRIPalletIDRequest() {
        }
        
        public BindingUSNRIPalletIDRequest(short Type, string StageCode, string RIPalletID, string UnitSerialNumber) {
            this.Type = Type;
            this.StageCode = StageCode;
            this.RIPalletID = RIPalletID;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="BindingUSNRIPalletIDResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class BindingUSNRIPalletIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string BindingUSNRIPalletIDResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string RIPalletID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UnitSerialNumber;
        
        public BindingUSNRIPalletIDResponse() {
        }
        
        public BindingUSNRIPalletIDResponse(string BindingUSNRIPalletIDResult, string RIPalletID, string UnitSerialNumber) {
            this.BindingUSNRIPalletIDResult = BindingUSNRIPalletIDResult;
            this.RIPalletID = RIPalletID;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDcsChassisInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetDcsChassisInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string ComponentCategory;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string GetResult;
        
        public GetDcsChassisInfoRequest() {
        }
        
        public GetDcsChassisInfoRequest(string UnitSerialNumber, string StageCode, string ComponentCategory, string GetResult) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.ComponentCategory = ComponentCategory;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDcsChassisInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetDcsChassisInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public SharpFrameSmall.Common.SFCS.clsDcsChassisInfo GetDcsChassisInfoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string GetResult;
        
        public GetDcsChassisInfoResponse() {
        }
        
        public GetDcsChassisInfoResponse(SharpFrameSmall.Common.SFCS.clsDcsChassisInfo GetDcsChassisInfoResult, string GetResult) {
            this.GetDcsChassisInfoResult = GetDcsChassisInfoResult;
            this.GetResult = GetResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LinkMultiBoardUSN", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class LinkMultiBoardUSNRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UnitSerialNumber")]
        public string[] UnitSerialNumbers;
        
        public LinkMultiBoardUSNRequest() {
        }
        
        public LinkMultiBoardUSNRequest(string StageCode, string[] UnitSerialNumbers) {
            this.StageCode = StageCode;
            this.UnitSerialNumbers = UnitSerialNumbers;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LinkMultiBoardUSNResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class LinkMultiBoardUSNResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string LinkMultiBoardUSNResult;
        
        public LinkMultiBoardUSNResponse() {
        }
        
        public LinkMultiBoardUSNResponse(string LinkMultiBoardUSNResult) {
            this.LinkMultiBoardUSNResult = LinkMultiBoardUSNResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RequstJDMD3FileJob", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RequstJDMD3FileJobRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string RequestPlantCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string RequestType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string RequestDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UnitSerialNumber")]
        public string[] UnitSerialNumbers;
        
        public RequstJDMD3FileJobRequest() {
        }
        
        public RequstJDMD3FileJobRequest(string RequestPlantCode, string RequestType, string RequestDate, string[] UnitSerialNumbers) {
            this.RequestPlantCode = RequestPlantCode;
            this.RequestType = RequestType;
            this.RequestDate = RequestDate;
            this.UnitSerialNumbers = UnitSerialNumbers;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RequstJDMD3FileJobResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RequstJDMD3FileJobResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string RequstJDMD3FileJobResult;
        
        public RequstJDMD3FileJobResponse() {
        }
        
        public RequstJDMD3FileJobResponse(string RequstJDMD3FileJobResult) {
            this.RequstJDMD3FileJobResult = RequstJDMD3FileJobResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTeNotReadyMoList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTeNotReadyMoListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MO")]
        public string[] MOs;
        
        public GetTeNotReadyMoListRequest() {
        }
        
        public GetTeNotReadyMoListRequest(string StageCode, string[] MOs) {
            this.StageCode = StageCode;
            this.MOs = MOs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTeNotReadyMoListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTeNotReadyMoListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetTeNotReadyMoListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MO")]
        public string[] MOs;
        
        public GetTeNotReadyMoListResponse() {
        }
        
        public GetTeNotReadyMoListResponse(string GetTeNotReadyMoListResult, string[] MOs) {
            this.GetTeNotReadyMoListResult = GetTeNotReadyMoListResult;
            this.MOs = MOs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMOItemByMo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMOItemByMoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Category;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MOItem")]
        public SharpFrameSmall.Common.SFCS.clsMOItem1[] MOItems;
        
        public GetMOItemByMoRequest() {
        }
        
        public GetMOItemByMoRequest(string MO, string StageCode, string Category, SharpFrameSmall.Common.SFCS.clsMOItem1[] MOItems) {
            this.MO = MO;
            this.StageCode = StageCode;
            this.Category = Category;
            this.MOItems = MOItems;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMOItemByMoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMOItemByMoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetMOItemByMoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("MOItem")]
        public SharpFrameSmall.Common.SFCS.clsMOItem1[] MOItems;
        
        public GetMOItemByMoResponse() {
        }
        
        public GetMOItemByMoResponse(string GetMOItemByMoResult, SharpFrameSmall.Common.SFCS.clsMOItem1[] MOItems) {
            this.GetMOItemByMoResult = GetMOItemByMoResult;
            this.MOItems = MOItems;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTVKey", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTVKeyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public SharpFrameSmall.Common.SFCS.clsTVKeyData clsTVKeyData;
        
        public GetTVKeyRequest() {
        }
        
        public GetTVKeyRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsTVKeyData clsTVKeyData) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.clsTVKeyData = clsTVKeyData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTVKeyResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTVKeyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetTVKeyResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.clsTVKeyData clsTVKeyData;
        
        public GetTVKeyResponse() {
        }
        
        public GetTVKeyResponse(string GetTVKeyResult, SharpFrameSmall.Common.SFCS.clsTVKeyData clsTVKeyData) {
            this.GetTVKeyResult = GetTVKeyResult;
            this.clsTVKeyData = clsTVKeyData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDefectUsnList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetDefectUsnListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public System.DateTime DefectDateFrom;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public System.DateTime DefectDateTo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UnitSerialNumber")]
        public string[] UnitSerialNumbers;
        
        public GetDefectUsnListRequest() {
        }
        
        public GetDefectUsnListRequest(string StageCode, System.DateTime DefectDateFrom, System.DateTime DefectDateTo, string[] UnitSerialNumbers) {
            this.StageCode = StageCode;
            this.DefectDateFrom = DefectDateFrom;
            this.DefectDateTo = DefectDateTo;
            this.UnitSerialNumbers = UnitSerialNumbers;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetDefectUsnListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetDefectUsnListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetDefectUsnListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("UnitSerialNumber")]
        public string[] UnitSerialNumbers;
        
        public GetDefectUsnListResponse() {
        }
        
        public GetDefectUsnListResponse(string GetDefectUsnListResult, string[] UnitSerialNumbers) {
            this.GetDefectUsnListResult = GetDefectUsnListResult;
            this.UnitSerialNumbers = UnitSerialNumbers;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnDefect", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnDefectRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public System.Data.DataSet DataTable;
        
        public GetUsnDefectRequest() {
        }
        
        public GetUsnDefectRequest(string UnitSerialNumber, string StageCode, System.Data.DataSet DataTable) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.DataTable = DataTable;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnDefectResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnDefectResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUsnDefectResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public System.Data.DataSet DataTable;
        
        public GetUsnDefectResponse() {
        }
        
        public GetUsnDefectResponse(string GetUsnDefectResult, System.Data.DataSet DataTable) {
            this.GetUsnDefectResult = GetUsnDefectResult;
            this.DataTable = DataTable;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLastTransactionData", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLastTransactionDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Workstation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string TransactionDate;
        
        public GetLastTransactionDataRequest() {
        }
        
        public GetLastTransactionDataRequest(string UnitSerialNumber, string StageCode, string Workstation, string TransactionDate) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Workstation = Workstation;
            this.TransactionDate = TransactionDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLastTransactionDataResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLastTransactionDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetLastTransactionDataResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Workstation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string TransactionDate;
        
        public GetLastTransactionDataResponse() {
        }
        
        public GetLastTransactionDataResponse(string GetLastTransactionDataResult, string Workstation, string TransactionDate) {
            this.GetLastTransactionDataResult = GetLastTransactionDataResult;
            this.Workstation = Workstation;
            this.TransactionDate = TransactionDate;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLastFixtureId", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLastFixtureIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string FixtureId;
        
        public GetLastFixtureIdRequest() {
        }
        
        public GetLastFixtureIdRequest(string UnitSerialNumber, string StageCode, string FixtureId) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.FixtureId = FixtureId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetLastFixtureIdResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetLastFixtureIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetLastFixtureIdResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string FixtureId;
        
        public GetLastFixtureIdResponse() {
        }
        
        public GetLastFixtureIdResponse(string GetLastFixtureIdResult, string FixtureId) {
            this.GetLastFixtureIdResult = GetLastFixtureIdResult;
            this.FixtureId = FixtureId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnRepair", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnRepairRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public System.Data.DataSet DataTable;
        
        public GetUsnRepairRequest() {
        }
        
        public GetUsnRepairRequest(string UnitSerialNumber, string StageCode, System.Data.DataSet DataTable) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.DataTable = DataTable;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnRepairResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnRepairResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUsnRepairResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public System.Data.DataSet DataTable;
        
        public GetUsnRepairResponse() {
        }
        
        public GetUsnRepairResponse(string GetUsnRepairResult, System.Data.DataSet DataTable) {
            this.GetUsnRepairResult = GetUsnRepairResult;
            this.DataTable = DataTable;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnInfoAtStage", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnInfoAtStageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("KeyValue")]
        public SharpFrameSmall.Common.SFCS.clsKeyValue[] KeyValues;
        
        public GetUsnInfoAtStageRequest() {
        }
        
        public GetUsnInfoAtStageRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsKeyValue[] KeyValues) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.KeyValues = KeyValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnInfoAtStageResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnInfoAtStageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUsnInfoAtStageResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("KeyValue")]
        public SharpFrameSmall.Common.SFCS.clsKeyValue[] KeyValues;
        
        public GetUsnInfoAtStageResponse() {
        }
        
        public GetUsnInfoAtStageResponse(string GetUsnInfoAtStageResult, SharpFrameSmall.Common.SFCS.clsKeyValue[] KeyValues) {
            this.GetUsnInfoAtStageResult = GetUsnInfoAtStageResult;
            this.KeyValues = KeyValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAutoStickLabelPN", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetAutoStickLabelPNRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AutoStickLabelPN")]
        public SharpFrameSmall.Common.SFCS.clsAutoStickLabelPN[] AutoStickLabelPNs;
        
        public GetAutoStickLabelPNRequest() {
        }
        
        public GetAutoStickLabelPNRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsAutoStickLabelPN[] AutoStickLabelPNs) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.AutoStickLabelPNs = AutoStickLabelPNs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAutoStickLabelPNResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetAutoStickLabelPNResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetAutoStickLabelPNResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("AutoStickLabelPN")]
        public SharpFrameSmall.Common.SFCS.clsAutoStickLabelPN[] AutoStickLabelPNs;
        
        public GetAutoStickLabelPNResponse() {
        }
        
        public GetAutoStickLabelPNResponse(string GetAutoStickLabelPNResult, SharpFrameSmall.Common.SFCS.clsAutoStickLabelPN[] AutoStickLabelPNs) {
            this.GetAutoStickLabelPNResult = GetAutoStickLabelPNResult;
            this.AutoStickLabelPNs = AutoStickLabelPNs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RosaSwPoNackRuleCheck", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RosaSwPoNackRuleCheckRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string CustomerPO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string CustomerPOLine;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UsingInType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string Message;
        
        public RosaSwPoNackRuleCheckRequest() {
        }
        
        public RosaSwPoNackRuleCheckRequest(string CustomerPO, string CustomerPOLine, string UsingInType, string Message) {
            this.CustomerPO = CustomerPO;
            this.CustomerPOLine = CustomerPOLine;
            this.UsingInType = UsingInType;
            this.Message = Message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RosaSwPoNackRuleCheckResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RosaSwPoNackRuleCheckResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public int RosaSwPoNackRuleCheckResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Message;
        
        public RosaSwPoNackRuleCheckResponse() {
        }
        
        public RosaSwPoNackRuleCheckResponse(int RosaSwPoNackRuleCheckResult, string Message) {
            this.RosaSwPoNackRuleCheckResult = RosaSwPoNackRuleCheckResult;
            this.Message = Message;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UpdateEDI860Signal", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UpdateEDI860SignalRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string WOMSCHANGENO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string WOMSNO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string PLANT;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string CUSTOMERPO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string TIEGROUP;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string SIGNAL;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        public string MESSAGE;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string CUSTOMERSO;
        
        public UpdateEDI860SignalRequest() {
        }
        
        public UpdateEDI860SignalRequest(string WOMSCHANGENO, string WOMSNO, string PLANT, string CUSTOMERPO, string TIEGROUP, string SIGNAL, string MESSAGE, string CUSTOMERSO) {
            this.WOMSCHANGENO = WOMSCHANGENO;
            this.WOMSNO = WOMSNO;
            this.PLANT = PLANT;
            this.CUSTOMERPO = CUSTOMERPO;
            this.TIEGROUP = TIEGROUP;
            this.SIGNAL = SIGNAL;
            this.MESSAGE = MESSAGE;
            this.CUSTOMERSO = CUSTOMERSO;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UpdateEDI860SignalResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UpdateEDI860SignalResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UpdateEDI860SignalResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string MESSAGE;
        
        public UpdateEDI860SignalResponse() {
        }
        
        public UpdateEDI860SignalResponse(string UpdateEDI860SignalResult, string MESSAGE) {
            this.UpdateEDI860SignalResult = UpdateEDI860SignalResult;
            this.MESSAGE = MESSAGE;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnById", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnByIdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string ID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public int IDType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitSerialNumber;
        
        public GetUsnByIdRequest() {
        }
        
        public GetUsnByIdRequest(string ID, string StageCode, int IDType, string UnitSerialNumber) {
            this.ID = ID;
            this.StageCode = StageCode;
            this.IDType = IDType;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnByIdResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnByIdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUsnByIdResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public GetUsnByIdResponse() {
        }
        
        public GetUsnByIdResponse(string GetUsnByIdResult, string UnitSerialNumber) {
            this.GetUsnByIdResult = GetUsnByIdResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLot", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Barcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string LotNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string UserID;
        
        public UploadPcbLotRequest() {
        }
        
        public UploadPcbLotRequest(string UnitSerialNumber, string StageCode, string Barcode, string LotNo, string UserID) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Barcode = Barcode;
            this.LotNo = LotNo;
            this.UserID = UserID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLotResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadPcbLotResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public UploadPcbLotResponse() {
        }
        
        public UploadPcbLotResponse(string UploadPcbLotResult, string UnitSerialNumber) {
            this.UploadPcbLotResult = UploadPcbLotResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLot With PCB 2D Barcode", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotWithPCB2DBarcode {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Barcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string LotNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string UserID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string PCB2DBarcode;
        
        public UploadPcbLotWithPCB2DBarcode() {
        }
        
        public UploadPcbLotWithPCB2DBarcode(string UnitSerialNumber, string StageCode, string Barcode, string LotNo, string UserID, string PCB2DBarcode) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Barcode = Barcode;
            this.LotNo = LotNo;
            this.UserID = UserID;
            this.PCB2DBarcode = PCB2DBarcode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLot With PCB 2D BarcodeResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotWithPCB2DBarcode1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("UploadPcbLot With PCB 2D BarcodeResult")]
        public string UploadPcbLotWithPCB2DBarcodeResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public UploadPcbLotWithPCB2DBarcode1() {
        }
        
        public UploadPcbLotWithPCB2DBarcode1(string UploadPcbLotWithPCB2DBarcodeResult, string UnitSerialNumber) {
            this.UploadPcbLotWithPCB2DBarcodeResult = UploadPcbLotWithPCB2DBarcodeResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLot With 2D Barcode(include UnsealDate)", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotWith2DBarcodeincludeUnsealDate {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("2DBarcode")]
        public string Item2DBarcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnsealDate;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string UserID;
        
        public UploadPcbLotWith2DBarcodeincludeUnsealDate() {
        }
        
        public UploadPcbLotWith2DBarcodeincludeUnsealDate(string UnitSerialNumber, string StageCode, string Item2DBarcode, string UnsealDate, string UserID) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Item2DBarcode = Item2DBarcode;
            this.UnsealDate = UnsealDate;
            this.UserID = UserID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadPcbLot With 2D Barcode(include UnsealDate)Response", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadPcbLotWith2DBarcodeincludeUnsealDate1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("UploadPcbLot With 2D Barcode(include UnsealDate)Result")]
        public string UploadPcbLotWith2DBarcodeincludeUnsealDateResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public UploadPcbLotWith2DBarcodeincludeUnsealDate1() {
        }
        
        public UploadPcbLotWith2DBarcodeincludeUnsealDate1(string UploadPcbLotWith2DBarcodeincludeUnsealDateResult, string UnitSerialNumber) {
            this.UploadPcbLotWith2DBarcodeincludeUnsealDateResult = UploadPcbLotWith2DBarcodeincludeUnsealDateResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadAstroMoInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadAstroMoInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public UploadAstroMoInfoRequest() {
        }
        
        public UploadAstroMoInfoRequest(string MO, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.MO = MO;
            this.StageCode = StageCode;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadAstroMoInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadAstroMoInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadAstroMoInfoResult;
        
        public UploadAstroMoInfoResponse() {
        }
        
        public UploadAstroMoInfoResponse(string UploadAstroMoInfoResult) {
            this.UploadAstroMoInfoResult = UploadAstroMoInfoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUpnInfoFromView", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUpnInfoFromViewRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitPartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UpnInfoType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetUpnInfoFromViewRequest() {
        }
        
        public GetUpnInfoFromViewRequest(string UnitPartNumber, string StageCode, string UpnInfoType, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.UnitPartNumber = UnitPartNumber;
            this.StageCode = StageCode;
            this.UpnInfoType = UpnInfoType;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUpnInfoFromViewResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUpnInfoFromViewResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUpnInfoFromViewResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetUpnInfoFromViewResponse() {
        }
        
        public GetUpnInfoFromViewResponse(string GetUpnInfoFromViewResult, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.GetUpnInfoFromViewResult = GetUpnInfoFromViewResult;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetKeyInfoFromView", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetKeyInfoFromViewRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string Key;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string KeyInfoType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetKeyInfoFromViewRequest() {
        }
        
        public GetKeyInfoFromViewRequest(string Key, string StageCode, string KeyInfoType, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.Key = Key;
            this.StageCode = StageCode;
            this.KeyInfoType = KeyInfoType;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetKeyInfoFromViewResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetKeyInfoFromViewResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetKeyInfoFromViewResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("InfoNameValue")]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetKeyInfoFromViewResponse() {
        }
        
        public GetKeyInfoFromViewResponse(string GetKeyInfoFromViewResult, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.GetKeyInfoFromViewResult = GetKeyInfoFromViewResult;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAndroidKey", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAndroidKeyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Workstation;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string ActionType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string ReturnField;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string ResultValue;
        
        public AllocateAndroidKeyRequest() {
        }
        
        public AllocateAndroidKeyRequest(string UnitSerialNumber, string StageCode, string Workstation, string ActionType, string ReturnField, string ResultValue) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Workstation = Workstation;
            this.ActionType = ActionType;
            this.ReturnField = ReturnField;
            this.ResultValue = ResultValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAndroidKeyResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAndroidKeyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string AllocateAndroidKeyResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string ResultValue;
        
        public AllocateAndroidKeyResponse() {
        }
        
        public AllocateAndroidKeyResponse(string AllocateAndroidKeyResult, string ResultValue) {
            this.AllocateAndroidKeyResult = AllocateAndroidKeyResult;
            this.ResultValue = ResultValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAwaitingUnitSnList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAwaitingUnitSnListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string MachineID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitSerialNumberList;
        
        public AllocateAwaitingUnitSnListRequest() {
        }
        
        public AllocateAwaitingUnitSnListRequest(string MO, string StageCode, string MachineID, string UnitSerialNumberList) {
            this.MO = MO;
            this.StageCode = StageCode;
            this.MachineID = MachineID;
            this.UnitSerialNumberList = UnitSerialNumberList;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAwaitingUnitSnListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAwaitingUnitSnListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string AllocateAwaitingUnitSnListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumberList;
        
        public AllocateAwaitingUnitSnListResponse() {
        }
        
        public AllocateAwaitingUnitSnListResponse(string AllocateAwaitingUnitSnListResult, string UnitSerialNumberList) {
            this.AllocateAwaitingUnitSnListResult = AllocateAwaitingUnitSnListResult;
            this.UnitSerialNumberList = UnitSerialNumberList;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAwaitingUnitSnListForExtendCode/Zack", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAwaitingUnitSnListForExtendCodeZack {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string MachineID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitSerialNumberList;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string ExtendCode;
        
        public AllocateAwaitingUnitSnListForExtendCodeZack() {
        }
        
        public AllocateAwaitingUnitSnListForExtendCodeZack(string MO, string StageCode, string MachineID, string UnitSerialNumberList, string ExtendCode) {
            this.MO = MO;
            this.StageCode = StageCode;
            this.MachineID = MachineID;
            this.UnitSerialNumberList = UnitSerialNumberList;
            this.ExtendCode = ExtendCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AllocateAwaitingUnitSnListForExtendCode/ZackResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class AllocateAwaitingUnitSnListForExtendCodeZack1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("AllocateAwaitingUnitSnListForExtendCode/ZackResult")]
        public string AllocateAwaitingUnitSnListForExtendCodeZackResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumberList;
        
        public AllocateAwaitingUnitSnListForExtendCodeZack1() {
        }
        
        public AllocateAwaitingUnitSnListForExtendCodeZack1(string AllocateAwaitingUnitSnListForExtendCodeZackResult, string UnitSerialNumberList) {
            this.AllocateAwaitingUnitSnListForExtendCodeZackResult = AllocateAwaitingUnitSnListForExtendCodeZackResult;
            this.UnitSerialNumberList = UnitSerialNumberList;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMoAndBoardInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMoAndBoardInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string SheetNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.clsMOAndBoardInfo ClassMOAndBoardInfo;
        
        public GetMoAndBoardInfoRequest() {
        }
        
        public GetMoAndBoardInfoRequest(string SheetNo, SharpFrameSmall.Common.SFCS.clsMOAndBoardInfo ClassMOAndBoardInfo) {
            this.SheetNo = SheetNo;
            this.ClassMOAndBoardInfo = ClassMOAndBoardInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMoAndBoardInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMoAndBoardInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetMoAndBoardInfoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.clsMOAndBoardInfo ClassMOAndBoardInfo;
        
        public GetMoAndBoardInfoResponse() {
        }
        
        public GetMoAndBoardInfoResponse(string GetMoAndBoardInfoResult, SharpFrameSmall.Common.SFCS.clsMOAndBoardInfo ClassMOAndBoardInfo) {
            this.GetMoAndBoardInfoResult = GetMoAndBoardInfoResult;
            this.ClassMOAndBoardInfo = ClassMOAndBoardInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Get2SLabelInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class Get2SLabelInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string SheetNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("2DBarcode")]
        public string Item2DBarcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public SharpFrameSmall.Common.SFCS.cls2SLabelInfo Class2SLabelInfo;
        
        public Get2SLabelInfoRequest() {
        }
        
        public Get2SLabelInfoRequest(string SheetNo, string Item2DBarcode, SharpFrameSmall.Common.SFCS.cls2SLabelInfo Class2SLabelInfo) {
            this.SheetNo = SheetNo;
            this.Item2DBarcode = Item2DBarcode;
            this.Class2SLabelInfo = Class2SLabelInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Get2SLabelInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class Get2SLabelInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string Get2SLabelInfoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.cls2SLabelInfo Class2SLabelInfo;
        
        public Get2SLabelInfoResponse() {
        }
        
        public Get2SLabelInfoResponse(string Get2SLabelInfoResult, SharpFrameSmall.Common.SFCS.cls2SLabelInfo Class2SLabelInfo) {
            this.Get2SLabelInfoResult = Get2SLabelInfoResult;
            this.Class2SLabelInfo = Class2SLabelInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Upload2SLabelInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class Upload2SLabelInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string SheetNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("2DBarcode")]
        public string Item2DBarcode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Brand;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UserID;
        
        public Upload2SLabelInfoRequest() {
        }
        
        public Upload2SLabelInfoRequest(string SheetNo, string Item2DBarcode, string Brand, string UserID) {
            this.SheetNo = SheetNo;
            this.Item2DBarcode = Item2DBarcode;
            this.Brand = Brand;
            this.UserID = UserID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Upload2SLabelInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class Upload2SLabelInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string Upload2SLabelInfoResult;
        
        public Upload2SLabelInfoResponse() {
        }
        
        public Upload2SLabelInfoResponse(string Upload2SLabelInfoResult) {
            this.Upload2SLabelInfoResult = Upload2SLabelInfoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnInformationList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnInformationListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetUsnInformationListRequest() {
        }
        
        public GetUsnInformationListRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUsnInformationListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUsnInformationListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUsnInformationListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetUsnInformationListResponse() {
        }
        
        public GetUsnInformationListResponse(string GetUsnInformationListResult, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.GetUsnInformationListResult = GetUsnInformationListResult;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTvDacDataList", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTvDacDataListRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TvDacDataItem")]
        public SharpFrameSmall.Common.SFCS.clsTvDacData[] TvDacDataArray;
        
        public GetTvDacDataListRequest() {
        }
        
        public GetTvDacDataListRequest(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsTvDacData[] TvDacDataArray) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.TvDacDataArray = TvDacDataArray;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTvDacDataListResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTvDacDataListResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetTvDacDataListResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TvDacDataItem")]
        public SharpFrameSmall.Common.SFCS.clsTvDacData[] TvDacDataArray;
        
        public GetTvDacDataListResponse() {
        }
        
        public GetTvDacDataListResponse(string GetTvDacDataListResult, SharpFrameSmall.Common.SFCS.clsTvDacData[] TvDacDataArray) {
            this.GetTvDacDataListResult = GetTvDacDataListResult;
            this.TvDacDataArray = TvDacDataArray;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetEllaRackLoction", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetEllaRackLoctionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetEllaRackLoctionRequest() {
        }
        
        public GetEllaRackLoctionRequest(string UnitSerialNumber, string Line, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetEllaRackLoctionResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetEllaRackLoctionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetEllaRackLoctionResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues;
        
        public GetEllaRackLoctionResponse() {
        }
        
        public GetEllaRackLoctionResponse(string GetEllaRackLoctionResult, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            this.GetEllaRackLoctionResult = GetEllaRackLoctionResult;
            this.InfoNameValues = InfoNameValues;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadOCRInfo With PCB 2D Barcode", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadOCRInfoWithPCB2DBarcode {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string CustomerPN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string LotNo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string VendorCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string UserID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        public string PCB2DBarcode;
        
        public UploadOCRInfoWithPCB2DBarcode() {
        }
        
        public UploadOCRInfoWithPCB2DBarcode(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID, string PCB2DBarcode) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.CustomerPN = CustomerPN;
            this.LotNo = LotNo;
            this.VendorCode = VendorCode;
            this.UserID = UserID;
            this.PCB2DBarcode = PCB2DBarcode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadOCRInfo With PCB 2D BarcodeResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadOCRInfoWithPCB2DBarcode1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("UploadOCRInfo With PCB 2D BarcodeResult")]
        public string UploadOCRInfoWithPCB2DBarcodeResult;
        
        public UploadOCRInfoWithPCB2DBarcode1() {
        }
        
        public UploadOCRInfoWithPCB2DBarcode1(string UploadOCRInfoWithPCB2DBarcodeResult) {
            this.UploadOCRInfoWithPCB2DBarcodeResult = UploadOCRInfoWithPCB2DBarcodeResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RecordESOPInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RecordESOPInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string ProcessID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string DocumentNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string Model;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string Stage;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute("MappingRelation")]
        public string[] MappingRelation;
        
        public RecordESOPInfoRequest() {
        }
        
        public RecordESOPInfoRequest(string ProcessID, string FileName, string DocumentNumber, string Model, string Stage, string[] MappingRelation) {
            this.ProcessID = ProcessID;
            this.FileName = FileName;
            this.DocumentNumber = DocumentNumber;
            this.Model = Model;
            this.Stage = Stage;
            this.MappingRelation = MappingRelation;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="RecordESOPInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class RecordESOPInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string RecordESOPInfoResult;
        
        public RecordESOPInfoResponse() {
        }
        
        public RecordESOPInfoResponse(string RecordESOPInfoResult) {
            this.RecordESOPInfoResult = RecordESOPInfoResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Complete", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StationName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string EmployeeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public bool Pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TrnData")]
        public string[] TrnDatas;
        
        public CompleteRequest() {
        }
        
        public CompleteRequest(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.StationName = StationName;
            this.EmployeeID = EmployeeID;
            this.Pass = Pass;
            this.TrnDatas = TrnDatas;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string CompleteResult;
        
        public CompleteResponse() {
        }
        
        public CompleteResponse(string CompleteResult) {
            this.CompleteResult = CompleteResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemark", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StationName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string EmployeeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public bool Pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TrnData")]
        public string[] TrnDatas;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string DefectRmark;
        
        public CompleteWithDefectRemarkRequest() {
        }
        
        public CompleteWithDefectRemarkRequest(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.StationName = StationName;
            this.EmployeeID = EmployeeID;
            this.Pass = Pass;
            this.TrnDatas = TrnDatas;
            this.DefectRmark = DefectRmark;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemarkResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string CompleteWithDefectRemarkResult;
        
        public CompleteWithDefectRemarkResponse() {
        }
        
        public CompleteWithDefectRemarkResponse(string CompleteWithDefectRemarkResult) {
            this.CompleteWithDefectRemarkResult = CompleteWithDefectRemarkResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemark/Bios/Diag", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkBiosDiag {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StationName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string EmployeeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public bool Pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TrnData")]
        public string[] TrnDatas;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string DefectRmark;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=8)]
        public string Diag;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=9)]
        public string Bios;
        
        public CompleteWithDefectRemarkBiosDiag() {
        }
        
        public CompleteWithDefectRemarkBiosDiag(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string Diag, string Bios) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.StationName = StationName;
            this.EmployeeID = EmployeeID;
            this.Pass = Pass;
            this.TrnDatas = TrnDatas;
            this.DefectRmark = DefectRmark;
            this.Diag = Diag;
            this.Bios = Bios;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemark/Bios/DiagResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkBiosDiag1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("CompleteWithDefectRemark/Bios/DiagResult")]
        public string CompleteWithDefectRemarkBiosDiagResult;
        
        public CompleteWithDefectRemarkBiosDiag1() {
        }
        
        public CompleteWithDefectRemarkBiosDiag1(string CompleteWithDefectRemarkBiosDiagResult) {
            this.CompleteWithDefectRemarkBiosDiagResult = CompleteWithDefectRemarkBiosDiagResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemark/Json", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkJson {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StationName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string EmployeeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public bool Pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TrnData")]
        public string[] TrnDatas;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string DefectRmark;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=8)]
        public string ExtendTransInfo;
        
        public CompleteWithDefectRemarkJson() {
        }
        
        public CompleteWithDefectRemarkJson(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string ExtendTransInfo) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.StationName = StationName;
            this.EmployeeID = EmployeeID;
            this.Pass = Pass;
            this.TrnDatas = TrnDatas;
            this.DefectRmark = DefectRmark;
            this.ExtendTransInfo = ExtendTransInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithDefectRemark/JsonResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithDefectRemarkJson1 {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("CompleteWithDefectRemark/JsonResult")]
        public string CompleteWithDefectRemarkJsonResult;
        
        public CompleteWithDefectRemarkJson1() {
        }
        
        public CompleteWithDefectRemarkJson1(string CompleteWithDefectRemarkJsonResult) {
            this.CompleteWithDefectRemarkJsonResult = CompleteWithDefectRemarkJsonResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithErrorDescription", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithErrorDescriptionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Line;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string StationName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string EmployeeID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public bool Pass;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlArrayItemAttribute("TrnData")]
        public string[] TrnDatas;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string ErrorDescription;
        
        public CompleteWithErrorDescriptionRequest() {
        }
        
        public CompleteWithErrorDescriptionRequest(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string ErrorDescription) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.Line = Line;
            this.StageCode = StageCode;
            this.StationName = StationName;
            this.EmployeeID = EmployeeID;
            this.Pass = Pass;
            this.TrnDatas = TrnDatas;
            this.ErrorDescription = ErrorDescription;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="CompleteWithErrorDescriptionResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class CompleteWithErrorDescriptionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string CompleteWithErrorDescriptionResult;
        
        public CompleteWithErrorDescriptionResponse() {
        }
        
        public CompleteWithErrorDescriptionResponse(string CompleteWithErrorDescriptionResult) {
            this.CompleteWithErrorDescriptionResult = CompleteWithErrorDescriptionResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetHDCPKey", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetHDCPKeyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string HDCPKey;
        
        public GetHDCPKeyRequest() {
        }
        
        public GetHDCPKeyRequest(string UnitSerialNumber, string StageCode, string HDCPKey) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.HDCPKey = HDCPKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetHDCPKeyResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetHDCPKeyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetHDCPKeyResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string HDCPKey;
        
        public GetHDCPKeyResponse() {
        }
        
        public GetHDCPKeyResponse(string GetHDCPKeyResult, string HDCPKey) {
            this.GetHDCPKeyResult = GetHDCPKeyResult;
            this.HDCPKey = HDCPKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCIPlusKey", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetCIPlusKeyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string CIPlusKey;
        
        public GetCIPlusKeyRequest() {
        }
        
        public GetCIPlusKeyRequest(string UnitSerialNumber, string StageCode, string CIPlusKey) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.CIPlusKey = CIPlusKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetCIPlusKeyResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetCIPlusKeyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetCIPlusKeyResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string CIPlusKey;
        
        public GetCIPlusKeyResponse() {
        }
        
        public GetCIPlusKeyResponse(string GetCIPlusKeyResult, string CIPlusKey) {
            this.GetCIPlusKeyResult = GetCIPlusKeyResult;
            this.CIPlusKey = CIPlusKey;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadFixtureID", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadFixtureIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string FixtureID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string FixtureIDSeq;
        
        public UploadFixtureIDRequest() {
        }
        
        public UploadFixtureIDRequest(string UnitSerialNumber, string StageCode, string FixtureID, string FixtureIDSeq) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.FixtureID = FixtureID;
            this.FixtureIDSeq = FixtureIDSeq;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UploadFixtureIDResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class UploadFixtureIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UploadFixtureIDResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string FixtureIDSeq;
        
        public UploadFixtureIDResponse() {
        }
        
        public UploadFixtureIDResponse(string UploadFixtureIDResult, string FixtureIDSeq) {
            this.UploadFixtureIDResult = UploadFixtureIDResult;
            this.FixtureIDSeq = FixtureIDSeq;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRIRackPositionByUSN", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetRIRackPositionByUSNRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string RIRackPosition;
        
        public GetRIRackPositionByUSNRequest() {
        }
        
        public GetRIRackPositionByUSNRequest(string UnitSerialNumber, string StageCode, string RIRackPosition) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.RIRackPosition = RIRackPosition;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRIRackPositionByUSNResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetRIRackPositionByUSNResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetRIRackPositionByUSNResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string RIRackPosition;
        
        public GetRIRackPositionByUSNResponse() {
        }
        
        public GetRIRackPositionByUSNResponse(string GetRIRackPositionByUSNResult, string RIRackPosition) {
            this.GetRIRackPositionByUSNResult = GetRIRackPositionByUSNResult;
            this.RIRackPosition = RIRackPosition;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByRIRackPosition", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByRIRackPositionRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string RIRackPosition;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UnitSerialNumber;
        
        public GetUSNByRIRackPositionRequest() {
        }
        
        public GetUSNByRIRackPositionRequest(string RIRackPosition, string StageCode, string UnitSerialNumber) {
            this.RIRackPosition = RIRackPosition;
            this.StageCode = StageCode;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByRIRackPositionResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByRIRackPositionResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUSNByRIRackPositionResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public GetUSNByRIRackPositionResponse() {
        }
        
        public GetUSNByRIRackPositionResponse(string GetUSNByRIRackPositionResult, string UnitSerialNumber) {
            this.GetUSNByRIRackPositionResult = GetUSNByRIRackPositionResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNInformation", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNInformationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string InfoName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string InfoValue;
        
        public GetUSNInformationRequest() {
        }
        
        public GetUSNInformationRequest(string StageCode, string UnitSerialNumber, string InfoName, string InfoValue) {
            this.StageCode = StageCode;
            this.UnitSerialNumber = UnitSerialNumber;
            this.InfoName = InfoName;
            this.InfoValue = InfoValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNInformationResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNInformationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUSNInformationResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string InfoValue;
        
        public GetUSNInformationResponse() {
        }
        
        public GetUSNInformationResponse(string GetUSNInformationResult, string InfoValue) {
            this.GetUSNInformationResult = GetUSNInformationResult;
            this.InfoValue = InfoValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByUSNInfo", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByUSNInfoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string InfoName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string InfoValue;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitSerialNumber;
        
        public GetUSNByUSNInfoRequest() {
        }
        
        public GetUSNByUSNInfoRequest(string StageCode, string InfoName, string InfoValue, string UnitSerialNumber) {
            this.StageCode = StageCode;
            this.InfoName = InfoName;
            this.InfoValue = InfoValue;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByUSNInfoResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByUSNInfoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUSNByUSNInfoResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public GetUSNByUSNInfoResponse() {
        }
        
        public GetUSNByUSNInfoResponse(string GetUSNByUSNInfoResult, string UnitSerialNumber) {
            this.GetUSNByUSNInfoResult = GetUSNByUSNInfoResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMessage", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMessageRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MessageID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Language;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("Parameter")]
        public string[] Parameter;
        
        public GetMessageRequest() {
        }
        
        public GetMessageRequest(string MessageID, string Language, string[] Parameter) {
            this.MessageID = MessageID;
            this.Language = Language;
            this.Parameter = Parameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMessageResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMessageResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public SharpFrameSmall.Common.SFCS.clsMessage GetMessageResult;
        
        public GetMessageResponse() {
        }
        
        public GetMessageResponse(SharpFrameSmall.Common.SFCS.clsMessage GetMessageResult) {
            this.GetMessageResult = GetMessageResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUPNInformation", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUPNInformationRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string InfoName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string InfoValue;
        
        public GetUPNInformationRequest() {
        }
        
        public GetUPNInformationRequest(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.InfoName = InfoName;
            this.InfoValue = InfoValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUPNInformationResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUPNInformationResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUPNInformationResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string InfoValue;
        
        public GetUPNInformationResponse() {
        }
        
        public GetUPNInformationResponse(string GetUPNInformationResult, string InfoValue) {
            this.GetUPNInformationResult = GetUPNInformationResult;
            this.InfoValue = InfoValue;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPanelParameter", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPanelParameterRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string PanelParameter;
        
        public GetPanelParameterRequest() {
        }
        
        public GetPanelParameterRequest(string UnitSerialNumber, string StageCode, string PanelParameter) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.PanelParameter = PanelParameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPanelParameterResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPanelParameterResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetPanelParameterResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string PanelParameter;
        
        public GetPanelParameterResponse() {
        }
        
        public GetPanelParameterResponse(string GetPanelParameterResult, string PanelParameter) {
            this.GetPanelParameterResult = GetPanelParameterResult;
            this.PanelParameter = PanelParameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPanelParameterWithDataSearchType", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPanelParameterWithDataSearchTypeRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string DataSerachType;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string PanelParameter;
        
        public GetPanelParameterWithDataSearchTypeRequest() {
        }
        
        public GetPanelParameterWithDataSearchTypeRequest(string UnitSerialNumber, string StageCode, string DataSerachType, string PanelParameter) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.DataSerachType = DataSerachType;
            this.PanelParameter = PanelParameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetPanelParameterWithDataSearchTypeResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetPanelParameterWithDataSearchTypeResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetPanelParameterWithDataSearchTypeResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string PanelParameter;
        
        public GetPanelParameterWithDataSearchTypeResponse() {
        }
        
        public GetPanelParameterWithDataSearchTypeResponse(string GetPanelParameterWithDataSearchTypeResult, string PanelParameter) {
            this.GetPanelParameterWithDataSearchTypeResult = GetPanelParameterWithDataSearchTypeResult;
            this.PanelParameter = PanelParameter;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSWCPNForUPN", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetSWCPNForUPNRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitPartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SWCPNItem")]
        public SharpFrameSmall.Common.SFCS.clsSWCPN[] SWCPNs;
        
        public GetSWCPNForUPNRequest() {
        }
        
        public GetSWCPNForUPNRequest(string UnitPartNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsSWCPN[] SWCPNs) {
            this.UnitPartNumber = UnitPartNumber;
            this.StageCode = StageCode;
            this.SWCPNs = SWCPNs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSWCPNForUPNResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetSWCPNForUPNResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetSWCPNForUPNResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SWCPNItem")]
        public SharpFrameSmall.Common.SFCS.clsSWCPN[] SWCPNs;
        
        public GetSWCPNForUPNResponse() {
        }
        
        public GetSWCPNForUPNResponse(string GetSWCPNForUPNResult, SharpFrameSmall.Common.SFCS.clsSWCPN[] SWCPNs) {
            this.GetSWCPNForUPNResult = GetSWCPNForUPNResult;
            this.SWCPNs = SWCPNs;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNInfoByMAC", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNInfoByMACRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string MAC;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string ModelFamily;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string Model;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string UnitPartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute("AllMAC")]
        public string[] AllMAC;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=8)]
        public string ImagePartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=9)]
        public string CheckRouteResult;
        
        public GetUSNInfoByMACRequest() {
        }
        
        public GetUSNInfoByMACRequest(string MAC, string StageCode, string ModelFamily, string Model, string UnitPartNumber, string MO, string UnitSerialNumber, string[] AllMAC, string ImagePartNumber, string CheckRouteResult) {
            this.MAC = MAC;
            this.StageCode = StageCode;
            this.ModelFamily = ModelFamily;
            this.Model = Model;
            this.UnitPartNumber = UnitPartNumber;
            this.MO = MO;
            this.UnitSerialNumber = UnitSerialNumber;
            this.AllMAC = AllMAC;
            this.ImagePartNumber = ImagePartNumber;
            this.CheckRouteResult = CheckRouteResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNInfoByMACResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNInfoByMACResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUSNInfoByMACResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string ModelFamily;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string Model;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=3)]
        public string UnitPartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=4)]
        public string MO;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=5)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute("AllMAC")]
        public string[] AllMAC;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=7)]
        public string ImagePartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=8)]
        public string CheckRouteResult;
        
        public GetUSNInfoByMACResponse() {
        }
        
        public GetUSNInfoByMACResponse(string GetUSNInfoByMACResult, string ModelFamily, string Model, string UnitPartNumber, string MO, string UnitSerialNumber, string[] AllMAC, string ImagePartNumber, string CheckRouteResult) {
            this.GetUSNInfoByMACResult = GetUSNInfoByMACResult;
            this.ModelFamily = ModelFamily;
            this.Model = Model;
            this.UnitPartNumber = UnitPartNumber;
            this.MO = MO;
            this.UnitSerialNumber = UnitSerialNumber;
            this.AllMAC = AllMAC;
            this.ImagePartNumber = ImagePartNumber;
            this.CheckRouteResult = CheckRouteResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSkuBomData", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetSkuBomDataRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string SkuPartNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string Category;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SkuBomDatas")]
        public SharpFrameSmall.Common.SFCS.clsSkuBomData[] SkuBomData;
        
        public GetSkuBomDataRequest() {
        }
        
        public GetSkuBomDataRequest(string SkuPartNumber, string Category, SharpFrameSmall.Common.SFCS.clsSkuBomData[] SkuBomData) {
            this.SkuPartNumber = SkuPartNumber;
            this.Category = Category;
            this.SkuBomData = SkuBomData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetSkuBomDataResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetSkuBomDataResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetSkuBomDataResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlArrayItemAttribute("SkuBomDatas")]
        public SharpFrameSmall.Common.SFCS.clsSkuBomData[] SkuBomData;
        
        public GetSkuBomDataResponse() {
        }
        
        public GetSkuBomDataResponse(string GetSkuBomDataResult, SharpFrameSmall.Common.SFCS.clsSkuBomData[] SkuBomData) {
            this.GetSkuBomDataResult = GetSkuBomDataResult;
            this.SkuBomData = SkuBomData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByRIPalletID", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByRIPalletIDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string RIPalletID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string UnitSerialNumber;
        
        public GetUSNByRIPalletIDRequest() {
        }
        
        public GetUSNByRIPalletIDRequest(string RIPalletID, string StageCode, string UnitSerialNumber) {
            this.RIPalletID = RIPalletID;
            this.StageCode = StageCode;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUSNByRIPalletIDResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetUSNByRIPalletIDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetUSNByRIPalletIDResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string UnitSerialNumber;
        
        public GetUSNByRIPalletIDResponse() {
        }
        
        public GetUSNByRIPalletIDResponse(string GetUSNByRIPalletIDResult, string UnitSerialNumber) {
            this.GetUSNByRIPalletIDResult = GetUSNByRIPalletIDResult;
            this.UnitSerialNumber = UnitSerialNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMO53PNItem", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMO53PNItemRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute("53PNDesc")]
        public string Item53PNDesc;
        
        public GetMO53PNItemRequest() {
        }
        
        public GetMO53PNItemRequest(string UnitSerialNumber, string StageCode, string Item53PNDesc) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.Item53PNDesc = Item53PNDesc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMO53PNItemResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetMO53PNItemResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetMO53PNItemResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute("53PNDesc")]
        public string Item53PNDesc;
        
        public GetMO53PNItemResponse() {
        }
        
        public GetMO53PNItemResponse(string GetMO53PNItemResult, string Item53PNDesc) {
            this.GetMO53PNItemResult = GetMO53PNItemResult;
            this.Item53PNDesc = Item53PNDesc;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTEModelName", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTEModelNameRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string UnitSerialNumber;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string StageCode;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=2)]
        public string TEModelName;
        
        public GetTEModelNameRequest() {
        }
        
        public GetTEModelNameRequest(string UnitSerialNumber, string StageCode, string TEModelName) {
            this.UnitSerialNumber = UnitSerialNumber;
            this.StageCode = StageCode;
            this.TEModelName = TEModelName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetTEModelNameResponse", WrapperNamespace="http://localhost/Tester.WebService/WebService", IsWrapped=true)]
    public partial class GetTEModelNameResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=0)]
        public string GetTEModelNameResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://localhost/Tester.WebService/WebService", Order=1)]
        public string TEModelName;
        
        public GetTEModelNameResponse() {
        }
        
        public GetTEModelNameResponse(string GetTEModelNameResult, string TEModelName) {
            this.GetTEModelNameResult = GetTEModelNameResult;
            this.TEModelName = TEModelName;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface SFCSClientChannel : SharpFrameSmall.Common.SFCS.WebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SFCSClient : System.ServiceModel.ClientBase<SharpFrameSmall.Common.SFCS.WebServiceSoap>, SharpFrameSmall.Common.SFCS.WebServiceSoap {
        
        public SFCSClient() {
        }
        
        //public SFCSClient(string endpointConfigurationName) : 
        //        base(endpointConfigurationName) {
        //}
        
        public SFCSClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SFCSClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SFCSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }

        public SFCSClient(string serviceUrl)
    : base(CreateBinding(), new EndpointAddress(serviceUrl))
        {
        }

        private static Binding CreateBinding()
        {
            var binding = new BasicHttpBinding();
            binding.MaxReceivedMessageSize = 2147483647;
            binding.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
            binding.SendTimeout = TimeSpan.FromSeconds(30);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(5);
            return binding;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetLinkUSNResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetLinkUSN(SharpFrameSmall.Common.SFCS.GetLinkUSNRequest request) {
            return base.Channel.GetLinkUSN(request);
        }
        
        public string[] GetLinkUSN(string UnitSerialNumber, ref string ResultMessage) {
            SharpFrameSmall.Common.SFCS.GetLinkUSNRequest inValue = new SharpFrameSmall.Common.SFCS.GetLinkUSNRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.ResultMessage = ResultMessage;
            SharpFrameSmall.Common.SFCS.GetLinkUSNResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetLinkUSN(inValue);
            ResultMessage = retVal.ResultMessage;
            return retVal.GetLinkUSNResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLinkUSNResponse> GetLinkUSNAsync(SharpFrameSmall.Common.SFCS.GetLinkUSNRequest request) {
            return base.Channel.GetLinkUSNAsync(request);
        }
        
        public string BarcodeValidationWithGivenCategory(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, string CheckUsedCategory, string Line, string Workstation, string UserID, string ValidateCategory) {
            return base.Channel.BarcodeValidationWithGivenCategory(UnitSerialNumber, StageCode, ComponentSerialNumber, CheckUsedCategory, Line, Workstation, UserID, ValidateCategory);
        }
        
        public System.Threading.Tasks.Task<string> BarcodeValidationWithGivenCategoryAsync(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, string CheckUsedCategory, string Line, string Workstation, string UserID, string ValidateCategory) {
            return base.Channel.BarcodeValidationWithGivenCategoryAsync(UnitSerialNumber, StageCode, ComponentSerialNumber, CheckUsedCategory, Line, Workstation, UserID, ValidateCategory);
        }
        
        public string SetMoOnLine(string MO, string Line, string UserID, bool CheckDipCpnFlag, string StageCode) {
            return base.Channel.SetMoOnLine(MO, Line, UserID, CheckDipCpnFlag, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> SetMoOnLineAsync(string MO, string Line, string UserID, bool CheckDipCpnFlag, string StageCode) {
            return base.Channel.SetMoOnLineAsync(MO, Line, UserID, CheckDipCpnFlag, StageCode);
        }
        
        public string LinkWorkingPalletCSN(string MO, string WorkingPalletID, string ComponentSerialNumber, string StageCode) {
            return base.Channel.LinkWorkingPalletCSN(MO, WorkingPalletID, ComponentSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> LinkWorkingPalletCSNAsync(string MO, string WorkingPalletID, string ComponentSerialNumber, string StageCode) {
            return base.Channel.LinkWorkingPalletCSNAsync(MO, WorkingPalletID, ComponentSerialNumber, StageCode);
        }
        
        public string SwapPalletIDUSN(string WorkingPalletID, string UnitSerialNumber, string UserID, string WorkStation, string StageCode) {
            return base.Channel.SwapPalletIDUSN(WorkingPalletID, UnitSerialNumber, UserID, WorkStation, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> SwapPalletIDUSNAsync(string WorkingPalletID, string UnitSerialNumber, string UserID, string WorkStation, string StageCode) {
            return base.Channel.SwapPalletIDUSNAsync(WorkingPalletID, UnitSerialNumber, UserID, WorkStation, StageCode);
        }
        
        public string SwapWorkingPallet(string WorkingPalletID1, string WorkingPalletID2, string StageCode, string UserID, string WorkStation, bool CheckMOFlag) {
            return base.Channel.SwapWorkingPallet(WorkingPalletID1, WorkingPalletID2, StageCode, UserID, WorkStation, CheckMOFlag);
        }
        
        public System.Threading.Tasks.Task<string> SwapWorkingPalletAsync(string WorkingPalletID1, string WorkingPalletID2, string StageCode, string UserID, string WorkStation, bool CheckMOFlag) {
            return base.Channel.SwapWorkingPalletAsync(WorkingPalletID1, WorkingPalletID2, StageCode, UserID, WorkStation, CheckMOFlag);
        }
        
        public string UnlinkWorkingPallet(string WorkingPalletID, string StageCode) {
            return base.Channel.UnlinkWorkingPallet(WorkingPalletID, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> UnlinkWorkingPalletAsync(string WorkingPalletID, string StageCode) {
            return base.Channel.UnlinkWorkingPalletAsync(WorkingPalletID, StageCode);
        }
        
        public string RequestLabelPrint(string UnitSerialNumber, int LabelType, int LabelCount, int CartonLevel, string StageCode, string PrintWorkStation) {
            return base.Channel.RequestLabelPrint(UnitSerialNumber, LabelType, LabelCount, CartonLevel, StageCode, PrintWorkStation);
        }
        
        public System.Threading.Tasks.Task<string> RequestLabelPrintAsync(string UnitSerialNumber, int LabelType, int LabelCount, int CartonLevel, string StageCode, string PrintWorkStation) {
            return base.Channel.RequestLabelPrintAsync(UnitSerialNumber, LabelType, LabelCount, CartonLevel, StageCode, PrintWorkStation);
        }
        
        public string IsCPNComplete(string UnitSerialNumber, string StageCode, bool SequenceControl) {
            return base.Channel.IsCPNComplete(UnitSerialNumber, StageCode, SequenceControl);
        }
        
        public System.Threading.Tasks.Task<string> IsCPNCompleteAsync(string UnitSerialNumber, string StageCode, bool SequenceControl) {
            return base.Channel.IsCPNCompleteAsync(UnitSerialNumber, StageCode, SequenceControl);
        }
        
        public string AssignUserGroupCode(string UnitSerialNumber, string StageCode, string CTSN) {
            return base.Channel.AssignUserGroupCode(UnitSerialNumber, StageCode, CTSN);
        }
        
        public System.Threading.Tasks.Task<string> AssignUserGroupCodeAsync(string UnitSerialNumber, string StageCode, string CTSN) {
            return base.Channel.AssignUserGroupCodeAsync(UnitSerialNumber, StageCode, CTSN);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetAndProcessKtlOutEvent(SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest request) {
            return base.Channel.GetAndProcessKtlOutEvent(request);
        }
        
        public string GetAndProcessKtlOutEvent(string IP, ref SharpFrameSmall.Common.SFCS.clsKtlOutEvent[] ReturnKtlOutEvent) {
            SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest inValue = new SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest();
            inValue.IP = IP;
            inValue.ReturnKtlOutEvent = ReturnKtlOutEvent;
            SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetAndProcessKtlOutEvent(inValue);
            ReturnKtlOutEvent = retVal.ReturnKtlOutEvent;
            return retVal.GetAndProcessKtlOutEventResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventResponse> GetAndProcessKtlOutEventAsync(SharpFrameSmall.Common.SFCS.GetAndProcessKtlOutEventRequest request) {
            return base.Channel.GetAndProcessKtlOutEventAsync(request);
        }
        
        public string GetScrapQualify(string FixtureID) {
            return base.Channel.GetScrapQualify(FixtureID);
        }
        
        public System.Threading.Tasks.Task<string> GetScrapQualifyAsync(string FixtureID) {
            return base.Channel.GetScrapQualifyAsync(FixtureID);
        }
        
        public string UpdateFixtureStatus(string FixtureID, int Status) {
            return base.Channel.UpdateFixtureStatus(FixtureID, Status);
        }
        
        public System.Threading.Tasks.Task<string> UpdateFixtureStatusAsync(string FixtureID, int Status) {
            return base.Channel.UpdateFixtureStatusAsync(FixtureID, Status);
        }
        
        public string IACSReturnPrepareMaterialStatusToSFCS(string Plant, string SequenceID, string Status, string ActualCPN, string ActualQty, string ActualStorageLoc) {
            return base.Channel.IACSReturnPrepareMaterialStatusToSFCS(Plant, SequenceID, Status, ActualCPN, ActualQty, ActualStorageLoc);
        }
        
        public System.Threading.Tasks.Task<string> IACSReturnPrepareMaterialStatusToSFCSAsync(string Plant, string SequenceID, string Status, string ActualCPN, string ActualQty, string ActualStorageLoc) {
            return base.Channel.IACSReturnPrepareMaterialStatusToSFCSAsync(Plant, SequenceID, Status, ActualCPN, ActualQty, ActualStorageLoc);
        }
        
        public string UploadTestLogFileInfo(string UnitSerialNumber, string Stage, string FileFolder, string FileName) {
            return base.Channel.UploadTestLogFileInfo(UnitSerialNumber, Stage, FileFolder, FileName);
        }
        
        public System.Threading.Tasks.Task<string> UploadTestLogFileInfoAsync(string UnitSerialNumber, string Stage, string FileFolder, string FileName) {
            return base.Channel.UploadTestLogFileInfoAsync(UnitSerialNumber, Stage, FileFolder, FileName);
        }
        
        public string InsertHoldByUSN(string UnitSerialNumber, string StageCode, string HoldStage, string UserID, string HoldReason) {
            return base.Channel.InsertHoldByUSN(UnitSerialNumber, StageCode, HoldStage, UserID, HoldReason);
        }
        
        public System.Threading.Tasks.Task<string> InsertHoldByUSNAsync(string UnitSerialNumber, string StageCode, string HoldStage, string UserID, string HoldReason) {
            return base.Channel.InsertHoldByUSNAsync(UnitSerialNumber, StageCode, HoldStage, UserID, HoldReason);
        }
        
        public SharpFrameSmall.Common.SFCS.clsRaiseMTDLRequest[] RaiseMTDLRequest(string USN, string Stage) {
            return base.Channel.RaiseMTDLRequest(USN, Stage);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsRaiseMTDLRequest[]> RaiseMTDLRequestAsync(string USN, string Stage) {
            return base.Channel.RaiseMTDLRequestAsync(USN, Stage);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadMTDLResult(SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest request) {
            return base.Channel.UploadMTDLResult(request);
        }
        
        public string UploadMTDLResult(string USN, string Stage, SharpFrameSmall.Common.SFCS.clsTestItemResult[] TestItem) {
            SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest inValue = new SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest();
            inValue.USN = USN;
            inValue.Stage = Stage;
            inValue.TestItem = TestItem;
            SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadMTDLResult(inValue);
            return retVal.UploadMTDLResultResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadMTDLResultAsync(SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest request) {
            return base.Channel.UploadMTDLResultAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadMTDLResultResponse> UploadMTDLResultAsync(string USN, string Stage, SharpFrameSmall.Common.SFCS.clsTestItemResult[] TestItem) {
            SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest inValue = new SharpFrameSmall.Common.SFCS.UploadMTDLResultRequest();
            inValue.USN = USN;
            inValue.Stage = Stage;
            inValue.TestItem = TestItem;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadMTDLResultAsync(inValue);
        }
        
        public string UploadMonitorPowerConsumption(string USN, string Line, string PowerConsumption, string Stagecode, string Workststion) {
            return base.Channel.UploadMonitorPowerConsumption(USN, Line, PowerConsumption, Stagecode, Workststion);
        }
        
        public System.Threading.Tasks.Task<string> UploadMonitorPowerConsumptionAsync(string USN, string Line, string PowerConsumption, string Stagecode, string Workststion) {
            return base.Channel.UploadMonitorPowerConsumptionAsync(USN, Line, PowerConsumption, Stagecode, Workststion);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.DynamicDBFunction(SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest request) {
            return base.Channel.DynamicDBFunction(request);
        }
        
        public string DynamicDBFunction(string FunctionName, string Stage, SharpFrameSmall.Common.SFCS.clsDynamicParameter[] DynamicParameters) {
            SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest inValue = new SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest();
            inValue.FunctionName = FunctionName;
            inValue.Stage = Stage;
            inValue.DynamicParameters = DynamicParameters;
            SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).DynamicDBFunction(inValue);
            return retVal.DynamicDBFunctionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.DynamicDBFunctionAsync(SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest request) {
            return base.Channel.DynamicDBFunctionAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.DynamicDBFunctionResponse> DynamicDBFunctionAsync(string FunctionName, string Stage, SharpFrameSmall.Common.SFCS.clsDynamicParameter[] DynamicParameters) {
            SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest inValue = new SharpFrameSmall.Common.SFCS.DynamicDBFunctionRequest();
            inValue.FunctionName = FunctionName;
            inValue.Stage = Stage;
            inValue.DynamicParameters = DynamicParameters;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).DynamicDBFunctionAsync(inValue);
        }
        
        public SharpFrameSmall.Common.SFCS.clsWSInfo GetWebServiceInfo() {
            return base.Channel.GetWebServiceInfo();
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsWSInfo> GetWebServiceInfoAsync() {
            return base.Channel.GetWebServiceInfoAsync();
        }
        
        public SharpFrameSmall.Common.SFCS.clsWSConfig[] GetWebServiceConfig() {
            return base.Channel.GetWebServiceConfig();
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsWSConfig[]> GetWebServiceConfigAsync() {
            return base.Channel.GetWebServiceConfigAsync();
        }
        
        public string GetNextStage(string UnitSerialNumber, string StageCode, string PIAStageCode) {
            return base.Channel.GetNextStage(UnitSerialNumber, StageCode, PIAStageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetNextStageAsync(string UnitSerialNumber, string StageCode, string PIAStageCode) {
            return base.Channel.GetNextStageAsync(UnitSerialNumber, StageCode, PIAStageCode);
        }
        
        public SharpFrameSmall.Common.SFCS.clsMO GetMoGenealogy(string ManufactureOrder, string StageCode, SharpFrameSmall.Common.SFCS.clsMOCheckFlag MOCheckFlag) {
            return base.Channel.GetMoGenealogy(ManufactureOrder, StageCode, MOCheckFlag);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMO> GetMoGenealogyAsync(string ManufactureOrder, string StageCode, SharpFrameSmall.Common.SFCS.clsMOCheckFlag MOCheckFlag) {
            return base.Channel.GetMoGenealogyAsync(ManufactureOrder, StageCode, MOCheckFlag);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CheckInByUser1 SharpFrameSmall.Common.SFCS.WebServiceSoap.CheckIn(SharpFrameSmall.Common.SFCS.CheckInByUser request) {
            return base.Channel.CheckIn(request);
        }
        
        public bool CheckIn(string UnitSerialNumber, string StageCode, string UserID) {
            SharpFrameSmall.Common.SFCS.CheckInByUser inValue = new SharpFrameSmall.Common.SFCS.CheckInByUser();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            SharpFrameSmall.Common.SFCS.CheckInByUser1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CheckIn(inValue);
            return retVal.CheckInByUserResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckInByUser1> SharpFrameSmall.Common.SFCS.WebServiceSoap.CheckInAsync(SharpFrameSmall.Common.SFCS.CheckInByUser request) {
            return base.Channel.CheckInAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckInByUser1> CheckInAsync(string UnitSerialNumber, string StageCode, string UserID) {
            SharpFrameSmall.Common.SFCS.CheckInByUser inValue = new SharpFrameSmall.Common.SFCS.CheckInByUser();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CheckInAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CheckOutByUser1 SharpFrameSmall.Common.SFCS.WebServiceSoap.CheckOut(SharpFrameSmall.Common.SFCS.CheckOutByUser request) {
            return base.Channel.CheckOut(request);
        }
        
        public bool CheckOut(string UnitSerialNumber, string StageCode, string UserID) {
            SharpFrameSmall.Common.SFCS.CheckOutByUser inValue = new SharpFrameSmall.Common.SFCS.CheckOutByUser();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            SharpFrameSmall.Common.SFCS.CheckOutByUser1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CheckOut(inValue);
            return retVal.CheckOutByUserResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckOutByUser1> SharpFrameSmall.Common.SFCS.WebServiceSoap.CheckOutAsync(SharpFrameSmall.Common.SFCS.CheckOutByUser request) {
            return base.Channel.CheckOutAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CheckOutByUser1> CheckOutAsync(string UnitSerialNumber, string StageCode, string UserID) {
            SharpFrameSmall.Common.SFCS.CheckOutByUser inValue = new SharpFrameSmall.Common.SFCS.CheckOutByUser();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CheckOutAsync(inValue);
        }
        
        public SharpFrameSmall.Common.SFCS.clsUSN GetUSNGenealogyBasic(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUSNGenealogyBasic(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsUSN> GetUSNGenealogyBasicAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUSNGenealogyBasicAsync(UnitSerialNumber, StageCode);
        }
        
        public string UploadATEData(string UnitSerialNumber, string Result, string Line, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo) {
            return base.Channel.UploadATEData(UnitSerialNumber, Result, Line, StageCode, StationName, EmployeeID, FixtureID, PCBVersion, ErrorCode, ErrorLocation, ErrorDescription, ExtendInfo);
        }
        
        public System.Threading.Tasks.Task<string> UploadATEDataAsync(string UnitSerialNumber, string Result, string Line, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo) {
            return base.Channel.UploadATEDataAsync(UnitSerialNumber, Result, Line, StageCode, StationName, EmployeeID, FixtureID, PCBVersion, ErrorCode, ErrorLocation, ErrorDescription, ExtendInfo);
        }
        
        public string UploadATEDataForTRI(string UnitSerialNumber, string Result, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo) {
            return base.Channel.UploadATEDataForTRI(UnitSerialNumber, Result, StageCode, StationName, EmployeeID, FixtureID, PCBVersion, ErrorCode, ErrorLocation, ErrorDescription, ExtendInfo);
        }
        
        public System.Threading.Tasks.Task<string> UploadATEDataForTRIAsync(string UnitSerialNumber, string Result, string StageCode, string StationName, string EmployeeID, string FixtureID, string PCBVersion, string ErrorCode, string ErrorLocation, string ErrorDescription, string ExtendInfo) {
            return base.Channel.UploadATEDataForTRIAsync(UnitSerialNumber, Result, StageCode, StationName, EmployeeID, FixtureID, PCBVersion, ErrorCode, ErrorLocation, ErrorDescription, ExtendInfo);
        }
        
        public SharpFrameSmall.Common.SFCS.stcD2PickUpReturn CheckAutoPickUpRoute(string PPID, string WorkstationID, string Line) {
            return base.Channel.CheckAutoPickUpRoute(PPID, WorkstationID, Line);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcD2PickUpReturn> CheckAutoPickUpRouteAsync(string PPID, string WorkstationID, string Line) {
            return base.Channel.CheckAutoPickUpRouteAsync(PPID, WorkstationID, Line);
        }
        
        public SharpFrameSmall.Common.SFCS.stcDeductCPN DeductCPN(string PPID, string WorkstationID, string Line, string PartNumber, string LocationID, string PositionX, string PositionY) {
            return base.Channel.DeductCPN(PPID, WorkstationID, Line, PartNumber, LocationID, PositionX, PositionY);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcDeductCPN> DeductCPNAsync(string PPID, string WorkstationID, string Line, string PartNumber, string LocationID, string PositionX, string PositionY) {
            return base.Channel.DeductCPNAsync(PPID, WorkstationID, Line, PartNumber, LocationID, PositionX, PositionY);
        }
        
        public SharpFrameSmall.Common.SFCS.stcGetLocInfo GetLocInfo(string LocationID, string PartNumber, string Line) {
            return base.Channel.GetLocInfo(LocationID, PartNumber, Line);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.stcGetLocInfo> GetLocInfoAsync(string LocationID, string PartNumber, string Line) {
            return base.Channel.GetLocInfoAsync(LocationID, PartNumber, Line);
        }
        
        public string UploadTrnStartDate(string UnitSerialNumber, string StageCode, string UserID, string WorkStation) {
            return base.Channel.UploadTrnStartDate(UnitSerialNumber, StageCode, UserID, WorkStation);
        }
        
        public System.Threading.Tasks.Task<string> UploadTrnStartDateAsync(string UnitSerialNumber, string StageCode, string UserID, string WorkStation) {
            return base.Channel.UploadTrnStartDateAsync(UnitSerialNumber, StageCode, UserID, WorkStation);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1 SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTrnStartDate1(SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate request) {
            return base.Channel.UploadTrnStartDate1(request);
        }
        
        public string UploadTrnStartDate1(string UnitSerialNumber, string StageCode, string UserID, string WorkStation, string TrnStartDate) {
            SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate inValue = new SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            inValue.WorkStation = WorkStation;
            inValue.TrnStartDate = TrnStartDate;
            SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTrnStartDate1(inValue);
            return retVal.UploadTrnStartDatewithTrnStartDateResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTrnStartDate1Async(SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate request) {
            return base.Channel.UploadTrnStartDate1Async(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate1> UploadTrnStartDate1Async(string UnitSerialNumber, string StageCode, string UserID, string WorkStation, string TrnStartDate) {
            SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate inValue = new SharpFrameSmall.Common.SFCS.UploadTrnStartDatewithTrnStartDate();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.UserID = UserID;
            inValue.WorkStation = WorkStation;
            inValue.TrnStartDate = TrnStartDate;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTrnStartDate1Async(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.BatchUploadUSNInfo(SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest request) {
            return base.Channel.BatchUploadUSNInfo(request);
        }
        
        public string BatchUploadUSNInfo(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValue) {
            SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest inValue = new SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.InfoNameValue = InfoNameValue;
            SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).BatchUploadUSNInfo(inValue);
            return retVal.BatchUploadUSNInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.BatchUploadUSNInfoAsync(SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest request) {
            return base.Channel.BatchUploadUSNInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoResponse> BatchUploadUSNInfoAsync(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValue) {
            SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest inValue = new SharpFrameSmall.Common.SFCS.BatchUploadUSNInfoRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.InfoNameValue = InfoNameValue;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).BatchUploadUSNInfoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompareResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.Compare(SharpFrameSmall.Common.SFCS.CompareRequest request) {
            return base.Channel.Compare(request);
        }
        
        public string Compare(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsCompareItem[] CompareItems) {
            SharpFrameSmall.Common.SFCS.CompareRequest inValue = new SharpFrameSmall.Common.SFCS.CompareRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.CompareItems = CompareItems;
            SharpFrameSmall.Common.SFCS.CompareResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).Compare(inValue);
            CompareItems = retVal.CompareItems;
            return retVal.CompareResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompareResponse> CompareAsync(SharpFrameSmall.Common.SFCS.CompareRequest request) {
            return base.Channel.CompareAsync(request);
        }
        
        public string SFCAddNewUnit(string UnitSerialNumber, string MO, string StageCode, string Workstation, string UserID) {
            return base.Channel.SFCAddNewUnit(UnitSerialNumber, MO, StageCode, Workstation, UserID);
        }
        
        public System.Threading.Tasks.Task<string> SFCAddNewUnitAsync(string UnitSerialNumber, string MO, string StageCode, string Workstation, string UserID) {
            return base.Channel.SFCAddNewUnitAsync(UnitSerialNumber, MO, StageCode, Workstation, UserID);
        }
        
        public SharpFrameSmall.Common.SFCS.clsKeyItem[] GetCompareItemsByUsn(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetCompareItemsByUsn(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsKeyItem[]> GetCompareItemsByUsnAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetCompareItemsByUsnAsync(UnitSerialNumber, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTestEquipments(SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest request) {
            return base.Channel.UploadTestEquipments(request);
        }
        
        public string UploadTestEquipments(string StageCode, string[] TestEquipments, string Model) {
            SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest inValue = new SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest();
            inValue.StageCode = StageCode;
            inValue.TestEquipments = TestEquipments;
            inValue.Model = Model;
            SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTestEquipments(inValue);
            return retVal.UploadTestEquipmentsResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTestEquipmentsAsync(SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest request) {
            return base.Channel.UploadTestEquipmentsAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestEquipmentsResponse> UploadTestEquipmentsAsync(string StageCode, string[] TestEquipments, string Model) {
            SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest inValue = new SharpFrameSmall.Common.SFCS.UploadTestEquipmentsRequest();
            inValue.StageCode = StageCode;
            inValue.TestEquipments = TestEquipments;
            inValue.Model = Model;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTestEquipmentsAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadTestDataResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTestData(SharpFrameSmall.Common.SFCS.UploadTestDataRequest request) {
            return base.Channel.UploadTestData(request);
        }
        
        public string UploadTestData(string StageCode, SharpFrameSmall.Common.SFCS.clsTestData[] TestData) {
            SharpFrameSmall.Common.SFCS.UploadTestDataRequest inValue = new SharpFrameSmall.Common.SFCS.UploadTestDataRequest();
            inValue.StageCode = StageCode;
            inValue.TestData = TestData;
            SharpFrameSmall.Common.SFCS.UploadTestDataResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTestData(inValue);
            return retVal.UploadTestDataResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestDataResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadTestDataAsync(SharpFrameSmall.Common.SFCS.UploadTestDataRequest request) {
            return base.Channel.UploadTestDataAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadTestDataResponse> UploadTestDataAsync(string StageCode, SharpFrameSmall.Common.SFCS.clsTestData[] TestData) {
            SharpFrameSmall.Common.SFCS.UploadTestDataRequest inValue = new SharpFrameSmall.Common.SFCS.UploadTestDataRequest();
            inValue.StageCode = StageCode;
            inValue.TestData = TestData;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadTestDataAsync(inValue);
        }
        
        public string UploadTestEquipmentsWithString(string StageCode, string TestEquipments, string Model) {
            return base.Channel.UploadTestEquipmentsWithString(StageCode, TestEquipments, Model);
        }
        
        public System.Threading.Tasks.Task<string> UploadTestEquipmentsWithStringAsync(string StageCode, string TestEquipments, string Model) {
            return base.Channel.UploadTestEquipmentsWithStringAsync(StageCode, TestEquipments, Model);
        }
        
        public string UploadTestDataWithString(string StageCode, string UnitSerialNumber, string TestDataType, string TestData) {
            return base.Channel.UploadTestDataWithString(StageCode, UnitSerialNumber, TestDataType, TestData);
        }
        
        public System.Threading.Tasks.Task<string> UploadTestDataWithStringAsync(string StageCode, string UnitSerialNumber, string TestDataType, string TestData) {
            return base.Channel.UploadTestDataWithStringAsync(StageCode, UnitSerialNumber, TestDataType, TestData);
        }
        
        public string UploadFGCode(string ProductCode, string Status) {
            return base.Channel.UploadFGCode(ProductCode, Status);
        }
        
        public System.Threading.Tasks.Task<string> UploadFGCodeAsync(string ProductCode, string Status) {
            return base.Channel.UploadFGCodeAsync(ProductCode, Status);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetPreparedMOListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetPreparedMOList(SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest request) {
            return base.Channel.GetPreparedMOList(request);
        }
        
        public SharpFrameSmall.Common.SFCS.clsPreparedMO[] GetPreparedMOList(string StageCode, ref string GetResult) {
            SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest inValue = new SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest();
            inValue.StageCode = StageCode;
            inValue.GetResult = GetResult;
            SharpFrameSmall.Common.SFCS.GetPreparedMOListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetPreparedMOList(inValue);
            GetResult = retVal.GetResult;
            return retVal.GetPreparedMOListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPreparedMOListResponse> GetPreparedMOListAsync(SharpFrameSmall.Common.SFCS.GetPreparedMOListRequest request) {
            return base.Channel.GetPreparedMOListAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNlistByRangeResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNlistByRange(SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest request) {
            return base.Channel.GetUSNlistByRange(request);
        }
        
        public string[] GetUSNlistByRange(string MO, short MinSeq, short MaxSeq, string StageCode, ref string GetResult) {
            SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest();
            inValue.MO = MO;
            inValue.MinSeq = MinSeq;
            inValue.MaxSeq = MaxSeq;
            inValue.StageCode = StageCode;
            inValue.GetResult = GetResult;
            SharpFrameSmall.Common.SFCS.GetUSNlistByRangeResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNlistByRange(inValue);
            GetResult = retVal.GetResult;
            return retVal.GetUSNlistByRangeResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNlistByRangeResponse> GetUSNlistByRangeAsync(SharpFrameSmall.Common.SFCS.GetUSNlistByRangeRequest request) {
            return base.Channel.GetUSNlistByRangeAsync(request);
        }
        
        public string UploadRuninRackUnitState(string UnitSerialNumber, string StageCode, int State, int TimeOutMinutes) {
            return base.Channel.UploadRuninRackUnitState(UnitSerialNumber, StageCode, State, TimeOutMinutes);
        }
        
        public System.Threading.Tasks.Task<string> UploadRuninRackUnitStateAsync(string UnitSerialNumber, string StageCode, int State, int TimeOutMinutes) {
            return base.Channel.UploadRuninRackUnitStateAsync(UnitSerialNumber, StageCode, State, TimeOutMinutes);
        }
        
        public string UploadFixtureUsedTimes(string UnitSerialNumber, string StageCode, string ECID, int UsedTimes) {
            return base.Channel.UploadFixtureUsedTimes(UnitSerialNumber, StageCode, ECID, UsedTimes);
        }
        
        public System.Threading.Tasks.Task<string> UploadFixtureUsedTimesAsync(string UnitSerialNumber, string StageCode, string ECID, int UsedTimes) {
            return base.Channel.UploadFixtureUsedTimesAsync(UnitSerialNumber, StageCode, ECID, UsedTimes);
        }
        
        public string CheckSFCDLSkill(string EmployeeID, string StageCode) {
            return base.Channel.CheckSFCDLSkill(EmployeeID, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> CheckSFCDLSkillAsync(string EmployeeID, string StageCode) {
            return base.Channel.CheckSFCDLSkillAsync(EmployeeID, StageCode);
        }
        
        public string UploadSonyIDData(string UnitSerialNumber, string StageCode, string Workstation, string IDCode, string IDData, string IDTag) {
            return base.Channel.UploadSonyIDData(UnitSerialNumber, StageCode, Workstation, IDCode, IDData, IDTag);
        }
        
        public System.Threading.Tasks.Task<string> UploadSonyIDDataAsync(string UnitSerialNumber, string StageCode, string Workstation, string IDCode, string IDData, string IDTag) {
            return base.Channel.UploadSonyIDDataAsync(UnitSerialNumber, StageCode, Workstation, IDCode, IDData, IDTag);
        }
        
        public string UploadSonyIDDatas(string UnitSerialNumber, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsSonyIDData[] SonyIDDatas) {
            return base.Channel.UploadSonyIDDatas(UnitSerialNumber, StageCode, Workstation, SonyIDDatas);
        }
        
        public System.Threading.Tasks.Task<string> UploadSonyIDDatasAsync(string UnitSerialNumber, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsSonyIDData[] SonyIDDatas) {
            return base.Channel.UploadSonyIDDatasAsync(UnitSerialNumber, StageCode, Workstation, SonyIDDatas);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.AllocateSonyKeyResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.AllocateSonyKey(SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest request) {
            return base.Channel.AllocateSonyKey(request);
        }
        
        public string AllocateSonyKey(string UnitSerialNumber, string StageCode, string IDCode, ref string IDData) {
            SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest inValue = new SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.IDCode = IDCode;
            inValue.IDData = IDData;
            SharpFrameSmall.Common.SFCS.AllocateSonyKeyResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).AllocateSonyKey(inValue);
            IDData = retVal.IDData;
            return retVal.AllocateSonyKeyResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateSonyKeyResponse> AllocateSonyKeyAsync(SharpFrameSmall.Common.SFCS.AllocateSonyKeyRequest request) {
            return base.Channel.AllocateSonyKeyAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.AllocateSonyKeysResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.AllocateSonyKeys(SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest request) {
            return base.Channel.AllocateSonyKeys(request);
        }
        
        public string AllocateSonyKeys(string UnitSerialNumber, string StageCode, string IDCode, ref string KeyQuantity, ref string[] IDDatas) {
            SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest inValue = new SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.IDCode = IDCode;
            inValue.KeyQuantity = KeyQuantity;
            inValue.IDDatas = IDDatas;
            SharpFrameSmall.Common.SFCS.AllocateSonyKeysResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).AllocateSonyKeys(inValue);
            KeyQuantity = retVal.KeyQuantity;
            IDDatas = retVal.IDDatas;
            return retVal.AllocateSonyKeysResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateSonyKeysResponse> AllocateSonyKeysAsync(SharpFrameSmall.Common.SFCS.AllocateSonyKeysRequest request) {
            return base.Channel.AllocateSonyKeysAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.BindingUSNRIPalletID(SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest request) {
            return base.Channel.BindingUSNRIPalletID(request);
        }
        
        public string BindingUSNRIPalletID(short Type, string StageCode, ref string RIPalletID, ref string UnitSerialNumber) {
            SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest inValue = new SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest();
            inValue.Type = Type;
            inValue.StageCode = StageCode;
            inValue.RIPalletID = RIPalletID;
            inValue.UnitSerialNumber = UnitSerialNumber;
            SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).BindingUSNRIPalletID(inValue);
            RIPalletID = retVal.RIPalletID;
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.BindingUSNRIPalletIDResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDResponse> BindingUSNRIPalletIDAsync(SharpFrameSmall.Common.SFCS.BindingUSNRIPalletIDRequest request) {
            return base.Channel.BindingUSNRIPalletIDAsync(request);
        }
        
        public string LinkUSNRIPalletID(string StageCode, string RIPalletID, string UnitSerialNumber) {
            return base.Channel.LinkUSNRIPalletID(StageCode, RIPalletID, UnitSerialNumber);
        }
        
        public System.Threading.Tasks.Task<string> LinkUSNRIPalletIDAsync(string StageCode, string RIPalletID, string UnitSerialNumber) {
            return base.Channel.LinkUSNRIPalletIDAsync(StageCode, RIPalletID, UnitSerialNumber);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetDcsChassisInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetDcsChassisInfo(SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest request) {
            return base.Channel.GetDcsChassisInfo(request);
        }
        
        public SharpFrameSmall.Common.SFCS.clsDcsChassisInfo GetDcsChassisInfo(string UnitSerialNumber, string StageCode, string ComponentCategory, ref string GetResult) {
            SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest inValue = new SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.ComponentCategory = ComponentCategory;
            inValue.GetResult = GetResult;
            SharpFrameSmall.Common.SFCS.GetDcsChassisInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetDcsChassisInfo(inValue);
            GetResult = retVal.GetResult;
            return retVal.GetDcsChassisInfoResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetDcsChassisInfoResponse> GetDcsChassisInfoAsync(SharpFrameSmall.Common.SFCS.GetDcsChassisInfoRequest request) {
            return base.Channel.GetDcsChassisInfoAsync(request);
        }
        
        public string GetCfiNewSiList(string NeedRecordQty) {
            return base.Channel.GetCfiNewSiList(NeedRecordQty);
        }
        
        public System.Threading.Tasks.Task<string> GetCfiNewSiListAsync(string NeedRecordQty) {
            return base.Channel.GetCfiNewSiListAsync(NeedRecordQty);
        }
        
        public SharpFrameSmall.Common.SFCS.clsSINumberInfo GetCfiSiInfo(string SINumber) {
            return base.Channel.GetCfiSiInfo(SINumber);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsSINumberInfo> GetCfiSiInfoAsync(string SINumber) {
            return base.Channel.GetCfiSiInfoAsync(SINumber);
        }
        
        public string UpdateCfiSiStatus(string SINumber, string SISyncStatus) {
            return base.Channel.UpdateCfiSiStatus(SINumber, SISyncStatus);
        }
        
        public System.Threading.Tasks.Task<string> UpdateCfiSiStatusAsync(string SINumber, string SISyncStatus) {
            return base.Channel.UpdateCfiSiStatusAsync(SINumber, SISyncStatus);
        }
        
        public SharpFrameSmall.Common.SFCS.clsUnitCfiData GetCfiData(string UnitSerialNumber) {
            return base.Channel.GetCfiData(UnitSerialNumber);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsUnitCfiData> GetCfiDataAsync(string UnitSerialNumber) {
            return base.Channel.GetCfiDataAsync(UnitSerialNumber);
        }
        
        public string UploadCfiHwInfo(SharpFrameSmall.Common.SFCS.clsUnitCfiHwInfo UnitCfiHwInfo) {
            return base.Channel.UploadCfiHwInfo(UnitCfiHwInfo);
        }
        
        public System.Threading.Tasks.Task<string> UploadCfiHwInfoAsync(SharpFrameSmall.Common.SFCS.clsUnitCfiHwInfo UnitCfiHwInfo) {
            return base.Channel.UploadCfiHwInfoAsync(UnitCfiHwInfo);
        }
        
        public string UploadBurnInRoomTemperature(string BurnInRoomID, string Temperature) {
            return base.Channel.UploadBurnInRoomTemperature(BurnInRoomID, Temperature);
        }
        
        public System.Threading.Tasks.Task<string> UploadBurnInRoomTemperatureAsync(string BurnInRoomID, string Temperature) {
            return base.Channel.UploadBurnInRoomTemperatureAsync(BurnInRoomID, Temperature);
        }
        
        public string IPCUSNPositionLinkage(string USN, string PositionID, string Command, string UserID) {
            return base.Channel.IPCUSNPositionLinkage(USN, PositionID, Command, UserID);
        }
        
        public System.Threading.Tasks.Task<string> IPCUSNPositionLinkageAsync(string USN, string PositionID, string Command, string UserID) {
            return base.Channel.IPCUSNPositionLinkageAsync(USN, PositionID, Command, UserID);
        }
        
        public string CheckInOutIPCBurnInRoom(string CartID, string LocationID, string Command, string UserID) {
            return base.Channel.CheckInOutIPCBurnInRoom(CartID, LocationID, Command, UserID);
        }
        
        public System.Threading.Tasks.Task<string> CheckInOutIPCBurnInRoomAsync(string CartID, string LocationID, string Command, string UserID) {
            return base.Channel.CheckInOutIPCBurnInRoomAsync(CartID, LocationID, Command, UserID);
        }
        
        public string TransferIPCBurnInLocation(string OriginalLocID, string NewLocID, string UserID) {
            return base.Channel.TransferIPCBurnInLocation(OriginalLocID, NewLocID, UserID);
        }
        
        public System.Threading.Tasks.Task<string> TransferIPCBurnInLocationAsync(string OriginalLocID, string NewLocID, string UserID) {
            return base.Channel.TransferIPCBurnInLocationAsync(OriginalLocID, NewLocID, UserID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.LinkMultiBoardUSN(SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest request) {
            return base.Channel.LinkMultiBoardUSN(request);
        }
        
        public string LinkMultiBoardUSN(string StageCode, string[] UnitSerialNumbers) {
            SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest inValue = new SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest();
            inValue.StageCode = StageCode;
            inValue.UnitSerialNumbers = UnitSerialNumbers;
            SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).LinkMultiBoardUSN(inValue);
            return retVal.LinkMultiBoardUSNResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.LinkMultiBoardUSNAsync(SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest request) {
            return base.Channel.LinkMultiBoardUSNAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNResponse> LinkMultiBoardUSNAsync(string StageCode, string[] UnitSerialNumbers) {
            SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest inValue = new SharpFrameSmall.Common.SFCS.LinkMultiBoardUSNRequest();
            inValue.StageCode = StageCode;
            inValue.UnitSerialNumbers = UnitSerialNumbers;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).LinkMultiBoardUSNAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.RequstJDMD3FileJob(SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest request) {
            return base.Channel.RequstJDMD3FileJob(request);
        }
        
        public string RequstJDMD3FileJob(string RequestPlantCode, string RequestType, string RequestDate, string[] UnitSerialNumbers) {
            SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest inValue = new SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest();
            inValue.RequestPlantCode = RequestPlantCode;
            inValue.RequestType = RequestType;
            inValue.RequestDate = RequestDate;
            inValue.UnitSerialNumbers = UnitSerialNumbers;
            SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).RequstJDMD3FileJob(inValue);
            return retVal.RequstJDMD3FileJobResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.RequstJDMD3FileJobAsync(SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest request) {
            return base.Channel.RequstJDMD3FileJobAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobResponse> RequstJDMD3FileJobAsync(string RequestPlantCode, string RequestType, string RequestDate, string[] UnitSerialNumbers) {
            SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest inValue = new SharpFrameSmall.Common.SFCS.RequstJDMD3FileJobRequest();
            inValue.RequestPlantCode = RequestPlantCode;
            inValue.RequestType = RequestType;
            inValue.RequestDate = RequestDate;
            inValue.UnitSerialNumbers = UnitSerialNumbers;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).RequstJDMD3FileJobAsync(inValue);
        }
        
        public SharpFrameSmall.Common.SFCS.clsJDMD3FileJobInfo[] GetJDMD3FileJobInfo(string RequestPlantCode, string Status) {
            return base.Channel.GetJDMD3FileJobInfo(RequestPlantCode, Status);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsJDMD3FileJobInfo[]> GetJDMD3FileJobInfoAsync(string RequestPlantCode, string Status) {
            return base.Channel.GetJDMD3FileJobInfoAsync(RequestPlantCode, Status);
        }
        
        public string UpdateJDMD3FileJobStatus(string RequstID, string Status) {
            return base.Channel.UpdateJDMD3FileJobStatus(RequstID, Status);
        }
        
        public System.Threading.Tasks.Task<string> UpdateJDMD3FileJobStatusAsync(string RequstID, string Status) {
            return base.Channel.UpdateJDMD3FileJobStatusAsync(RequstID, Status);
        }
        
        public string GetAISImageFileName(string UnitSerialNumber, string Category, string StageCode) {
            return base.Channel.GetAISImageFileName(UnitSerialNumber, Category, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetAISImageFileNameAsync(string UnitSerialNumber, string Category, string StageCode) {
            return base.Channel.GetAISImageFileNameAsync(UnitSerialNumber, Category, StageCode);
        }
        
        public string GetAISImageFileNameSplit(string UnitSerialNumber, string Category, string StageCode, string FileNameSplitter) {
            return base.Channel.GetAISImageFileNameSplit(UnitSerialNumber, Category, StageCode, FileNameSplitter);
        }
        
        public System.Threading.Tasks.Task<string> GetAISImageFileNameSplitAsync(string UnitSerialNumber, string Category, string StageCode, string FileNameSplitter) {
            return base.Channel.GetAISImageFileNameSplitAsync(UnitSerialNumber, Category, StageCode, FileNameSplitter);
        }
        
        public SharpFrameSmall.Common.SFCS.clsMOIDValue GetIDValueByMO(string MO, string StageCode, int IDType) {
            return base.Channel.GetIDValueByMO(MO, StageCode, IDType);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMOIDValue> GetIDValueByMOAsync(string MO, string StageCode, int IDType) {
            return base.Channel.GetIDValueByMOAsync(MO, StageCode, IDType);
        }
        
        public string GetICPN(string UnitSerialNumber, string StageCode, string Location) {
            return base.Channel.GetICPN(UnitSerialNumber, StageCode, Location);
        }
        
        public System.Threading.Tasks.Task<string> GetICPNAsync(string UnitSerialNumber, string StageCode, string Location) {
            return base.Channel.GetICPNAsync(UnitSerialNumber, StageCode, Location);
        }
        
        public SharpFrameSmall.Common.SFCS.clsEngravingInfo GetEngravingInfo(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetEngravingInfo(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsEngravingInfo> GetEngravingInfoAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetEngravingInfoAsync(UnitSerialNumber, StageCode);
        }
        
        public string GetMacSecurityKey(string MAC, string StageCode) {
            return base.Channel.GetMacSecurityKey(MAC, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetMacSecurityKeyAsync(string MAC, string StageCode) {
            return base.Channel.GetMacSecurityKeyAsync(MAC, StageCode);
        }
        
        public string UploadRendyResult(string UnitSerialNumber, string StageCode, string Workstation, string Name, string SubName, string MinValue, string MaxValue, string MeasuredValue, string Unit, string UserID, bool Pass) {
            return base.Channel.UploadRendyResult(UnitSerialNumber, StageCode, Workstation, Name, SubName, MinValue, MaxValue, MeasuredValue, Unit, UserID, Pass);
        }
        
        public System.Threading.Tasks.Task<string> UploadRendyResultAsync(string UnitSerialNumber, string StageCode, string Workstation, string Name, string SubName, string MinValue, string MaxValue, string MeasuredValue, string Unit, string UserID, bool Pass) {
            return base.Channel.UploadRendyResultAsync(UnitSerialNumber, StageCode, Workstation, Name, SubName, MinValue, MaxValue, MeasuredValue, Unit, UserID, Pass);
        }
        
        public string UploadRendyAntiTheftCCID(string UnitSerialNumber, string StageCode, string Workstation, string ProductSerialNumber, string AntiTheftCode, string CCID, string UserID) {
            return base.Channel.UploadRendyAntiTheftCCID(UnitSerialNumber, StageCode, Workstation, ProductSerialNumber, AntiTheftCode, CCID, UserID);
        }
        
        public System.Threading.Tasks.Task<string> UploadRendyAntiTheftCCIDAsync(string UnitSerialNumber, string StageCode, string Workstation, string ProductSerialNumber, string AntiTheftCode, string CCID, string UserID) {
            return base.Channel.UploadRendyAntiTheftCCIDAsync(UnitSerialNumber, StageCode, Workstation, ProductSerialNumber, AntiTheftCode, CCID, UserID);
        }
        
        public string UploadTpsUpnInfo(string UnitPartNumber, string StageCode, string InfoName, string InfoValue) {
            return base.Channel.UploadTpsUpnInfo(UnitPartNumber, StageCode, InfoName, InfoValue);
        }
        
        public System.Threading.Tasks.Task<string> UploadTpsUpnInfoAsync(string UnitPartNumber, string StageCode, string InfoName, string InfoValue) {
            return base.Channel.UploadTpsUpnInfoAsync(UnitPartNumber, StageCode, InfoName, InfoValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetTeNotReadyMoList(SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest request) {
            return base.Channel.GetTeNotReadyMoList(request);
        }
        
        public string GetTeNotReadyMoList(string StageCode, ref string[] MOs) {
            SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest inValue = new SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest();
            inValue.StageCode = StageCode;
            inValue.MOs = MOs;
            SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetTeNotReadyMoList(inValue);
            MOs = retVal.MOs;
            return retVal.GetTeNotReadyMoListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListResponse> GetTeNotReadyMoListAsync(SharpFrameSmall.Common.SFCS.GetTeNotReadyMoListRequest request) {
            return base.Channel.GetTeNotReadyMoListAsync(request);
        }
        
        public string UpdateTeReadyFlagByMo(string MO, string StageCode, string TeProgramFlag) {
            return base.Channel.UpdateTeReadyFlagByMo(MO, StageCode, TeProgramFlag);
        }
        
        public System.Threading.Tasks.Task<string> UpdateTeReadyFlagByMoAsync(string MO, string StageCode, string TeProgramFlag) {
            return base.Channel.UpdateTeReadyFlagByMoAsync(MO, StageCode, TeProgramFlag);
        }
        
        public string GetMoInfoByMo(string MO, string StageCode, string InfoName) {
            return base.Channel.GetMoInfoByMo(MO, StageCode, InfoName);
        }
        
        public System.Threading.Tasks.Task<string> GetMoInfoByMoAsync(string MO, string StageCode, string InfoName) {
            return base.Channel.GetMoInfoByMoAsync(MO, StageCode, InfoName);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetMOItemByMoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetMOItemByMo(SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest request) {
            return base.Channel.GetMOItemByMo(request);
        }
        
        public string GetMOItemByMo(string MO, string StageCode, string Category, ref SharpFrameSmall.Common.SFCS.clsMOItem1[] MOItems) {
            SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest inValue = new SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest();
            inValue.MO = MO;
            inValue.StageCode = StageCode;
            inValue.Category = Category;
            inValue.MOItems = MOItems;
            SharpFrameSmall.Common.SFCS.GetMOItemByMoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetMOItemByMo(inValue);
            MOItems = retVal.MOItems;
            return retVal.GetMOItemByMoResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMOItemByMoResponse> GetMOItemByMoAsync(SharpFrameSmall.Common.SFCS.GetMOItemByMoRequest request) {
            return base.Channel.GetMOItemByMoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetTVKeyResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetTVKey(SharpFrameSmall.Common.SFCS.GetTVKeyRequest request) {
            return base.Channel.GetTVKey(request);
        }
        
        public string GetTVKey(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsTVKeyData clsTVKeyData) {
            SharpFrameSmall.Common.SFCS.GetTVKeyRequest inValue = new SharpFrameSmall.Common.SFCS.GetTVKeyRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.clsTVKeyData = clsTVKeyData;
            SharpFrameSmall.Common.SFCS.GetTVKeyResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetTVKey(inValue);
            clsTVKeyData = retVal.clsTVKeyData;
            return retVal.GetTVKeyResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTVKeyResponse> GetTVKeyAsync(SharpFrameSmall.Common.SFCS.GetTVKeyRequest request) {
            return base.Channel.GetTVKeyAsync(request);
        }
        
        public string UploadTVKey(string UnitSerialNumber, string StageCode, string WorkStation, SharpFrameSmall.Common.SFCS.clsTVKeyItem[] TVKeyItems, bool UniqueCheckFlag) {
            return base.Channel.UploadTVKey(UnitSerialNumber, StageCode, WorkStation, TVKeyItems, UniqueCheckFlag);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVKeyAsync(string UnitSerialNumber, string StageCode, string WorkStation, SharpFrameSmall.Common.SFCS.clsTVKeyItem[] TVKeyItems, bool UniqueCheckFlag) {
            return base.Channel.UploadTVKeyAsync(UnitSerialNumber, StageCode, WorkStation, TVKeyItems, UniqueCheckFlag);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetDefectUsnListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetDefectUsnList(SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest request) {
            return base.Channel.GetDefectUsnList(request);
        }
        
        public string GetDefectUsnList(string StageCode, System.DateTime DefectDateFrom, System.DateTime DefectDateTo, ref string[] UnitSerialNumbers) {
            SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest inValue = new SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest();
            inValue.StageCode = StageCode;
            inValue.DefectDateFrom = DefectDateFrom;
            inValue.DefectDateTo = DefectDateTo;
            inValue.UnitSerialNumbers = UnitSerialNumbers;
            SharpFrameSmall.Common.SFCS.GetDefectUsnListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetDefectUsnList(inValue);
            UnitSerialNumbers = retVal.UnitSerialNumbers;
            return retVal.GetDefectUsnListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetDefectUsnListResponse> GetDefectUsnListAsync(SharpFrameSmall.Common.SFCS.GetDefectUsnListRequest request) {
            return base.Channel.GetDefectUsnListAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUsnDefectResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUsnDefect(SharpFrameSmall.Common.SFCS.GetUsnDefectRequest request) {
            return base.Channel.GetUsnDefect(request);
        }
        
        public string GetUsnDefect(string UnitSerialNumber, string StageCode, ref System.Data.DataSet DataTable) {
            SharpFrameSmall.Common.SFCS.GetUsnDefectRequest inValue = new SharpFrameSmall.Common.SFCS.GetUsnDefectRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.DataTable = DataTable;
            SharpFrameSmall.Common.SFCS.GetUsnDefectResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUsnDefect(inValue);
            DataTable = retVal.DataTable;
            return retVal.GetUsnDefectResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnDefectResponse> GetUsnDefectAsync(SharpFrameSmall.Common.SFCS.GetUsnDefectRequest request) {
            return base.Channel.GetUsnDefectAsync(request);
        }
        
        public string RosaHddMoLinkCRUD(string MO, string HDDPPID, string CRUDType) {
            return base.Channel.RosaHddMoLinkCRUD(MO, HDDPPID, CRUDType);
        }
        
        public System.Threading.Tasks.Task<string> RosaHddMoLinkCRUDAsync(string MO, string HDDPPID, string CRUDType) {
            return base.Channel.RosaHddMoLinkCRUDAsync(MO, HDDPPID, CRUDType);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetLastTransactionDataResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetLastTransactionData(SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest request) {
            return base.Channel.GetLastTransactionData(request);
        }
        
        public string GetLastTransactionData(string UnitSerialNumber, string StageCode, ref string Workstation, ref string TransactionDate) {
            SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest inValue = new SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Workstation = Workstation;
            inValue.TransactionDate = TransactionDate;
            SharpFrameSmall.Common.SFCS.GetLastTransactionDataResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetLastTransactionData(inValue);
            Workstation = retVal.Workstation;
            TransactionDate = retVal.TransactionDate;
            return retVal.GetLastTransactionDataResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLastTransactionDataResponse> GetLastTransactionDataAsync(SharpFrameSmall.Common.SFCS.GetLastTransactionDataRequest request) {
            return base.Channel.GetLastTransactionDataAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetLastFixtureIdResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetLastFixtureId(SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest request) {
            return base.Channel.GetLastFixtureId(request);
        }
        
        public string GetLastFixtureId(string UnitSerialNumber, string StageCode, ref string FixtureId) {
            SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest inValue = new SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.FixtureId = FixtureId;
            SharpFrameSmall.Common.SFCS.GetLastFixtureIdResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetLastFixtureId(inValue);
            FixtureId = retVal.FixtureId;
            return retVal.GetLastFixtureIdResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetLastFixtureIdResponse> GetLastFixtureIdAsync(SharpFrameSmall.Common.SFCS.GetLastFixtureIdRequest request) {
            return base.Channel.GetLastFixtureIdAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUsnRepairResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUsnRepair(SharpFrameSmall.Common.SFCS.GetUsnRepairRequest request) {
            return base.Channel.GetUsnRepair(request);
        }
        
        public string GetUsnRepair(string UnitSerialNumber, string StageCode, ref System.Data.DataSet DataTable) {
            SharpFrameSmall.Common.SFCS.GetUsnRepairRequest inValue = new SharpFrameSmall.Common.SFCS.GetUsnRepairRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.DataTable = DataTable;
            SharpFrameSmall.Common.SFCS.GetUsnRepairResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUsnRepair(inValue);
            DataTable = retVal.DataTable;
            return retVal.GetUsnRepairResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnRepairResponse> GetUsnRepairAsync(SharpFrameSmall.Common.SFCS.GetUsnRepairRequest request) {
            return base.Channel.GetUsnRepairAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUsnInfoAtStage(SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest request) {
            return base.Channel.GetUsnInfoAtStage(request);
        }
        
        public string GetUsnInfoAtStage(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsKeyValue[] KeyValues) {
            SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest inValue = new SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.KeyValues = KeyValues;
            SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUsnInfoAtStage(inValue);
            KeyValues = retVal.KeyValues;
            return retVal.GetUsnInfoAtStageResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageResponse> GetUsnInfoAtStageAsync(SharpFrameSmall.Common.SFCS.GetUsnInfoAtStageRequest request) {
            return base.Channel.GetUsnInfoAtStageAsync(request);
        }
        
        public string UploadRfEquTestTime(string PlantCode, string UnitSerialNumber, string StageCode, string EquipmentId, string TestStage, string TestStartTime, string TestEndTime, bool TestResult) {
            return base.Channel.UploadRfEquTestTime(PlantCode, UnitSerialNumber, StageCode, EquipmentId, TestStage, TestStartTime, TestEndTime, TestResult);
        }
        
        public System.Threading.Tasks.Task<string> UploadRfEquTestTimeAsync(string PlantCode, string UnitSerialNumber, string StageCode, string EquipmentId, string TestStage, string TestStartTime, string TestEndTime, bool TestResult) {
            return base.Channel.UploadRfEquTestTimeAsync(PlantCode, UnitSerialNumber, StageCode, EquipmentId, TestStage, TestStartTime, TestEndTime, TestResult);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetAutoStickLabelPN(SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest request) {
            return base.Channel.GetAutoStickLabelPN(request);
        }
        
        public string GetAutoStickLabelPN(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsAutoStickLabelPN[] AutoStickLabelPNs) {
            SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest inValue = new SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.AutoStickLabelPNs = AutoStickLabelPNs;
            SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetAutoStickLabelPN(inValue);
            AutoStickLabelPNs = retVal.AutoStickLabelPNs;
            return retVal.GetAutoStickLabelPNResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNResponse> GetAutoStickLabelPNAsync(SharpFrameSmall.Common.SFCS.GetAutoStickLabelPNRequest request) {
            return base.Channel.GetAutoStickLabelPNAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.RosaSwPoNackRuleCheck(SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest request) {
            return base.Channel.RosaSwPoNackRuleCheck(request);
        }
        
        public int RosaSwPoNackRuleCheck(string CustomerPO, string CustomerPOLine, string UsingInType, ref string Message) {
            SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest inValue = new SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest();
            inValue.CustomerPO = CustomerPO;
            inValue.CustomerPOLine = CustomerPOLine;
            inValue.UsingInType = UsingInType;
            inValue.Message = Message;
            SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).RosaSwPoNackRuleCheck(inValue);
            Message = retVal.Message;
            return retVal.RosaSwPoNackRuleCheckResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckResponse> RosaSwPoNackRuleCheckAsync(SharpFrameSmall.Common.SFCS.RosaSwPoNackRuleCheckRequest request) {
            return base.Channel.RosaSwPoNackRuleCheckAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UpdateEDI860SignalResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UpdateEDI860Signal(SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest request) {
            return base.Channel.UpdateEDI860Signal(request);
        }
        
        public string UpdateEDI860Signal(string WOMSCHANGENO, string WOMSNO, string PLANT, string CUSTOMERPO, string TIEGROUP, string SIGNAL, ref string MESSAGE, string CUSTOMERSO) {
            SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest inValue = new SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest();
            inValue.WOMSCHANGENO = WOMSCHANGENO;
            inValue.WOMSNO = WOMSNO;
            inValue.PLANT = PLANT;
            inValue.CUSTOMERPO = CUSTOMERPO;
            inValue.TIEGROUP = TIEGROUP;
            inValue.SIGNAL = SIGNAL;
            inValue.MESSAGE = MESSAGE;
            inValue.CUSTOMERSO = CUSTOMERSO;
            SharpFrameSmall.Common.SFCS.UpdateEDI860SignalResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UpdateEDI860Signal(inValue);
            MESSAGE = retVal.MESSAGE;
            return retVal.UpdateEDI860SignalResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UpdateEDI860SignalResponse> UpdateEDI860SignalAsync(SharpFrameSmall.Common.SFCS.UpdateEDI860SignalRequest request) {
            return base.Channel.UpdateEDI860SignalAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUsnByIdResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUsnById(SharpFrameSmall.Common.SFCS.GetUsnByIdRequest request) {
            return base.Channel.GetUsnById(request);
        }
        
        public string GetUsnById(string ID, string StageCode, int IDType, ref string UnitSerialNumber) {
            SharpFrameSmall.Common.SFCS.GetUsnByIdRequest inValue = new SharpFrameSmall.Common.SFCS.GetUsnByIdRequest();
            inValue.ID = ID;
            inValue.StageCode = StageCode;
            inValue.IDType = IDType;
            inValue.UnitSerialNumber = UnitSerialNumber;
            SharpFrameSmall.Common.SFCS.GetUsnByIdResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUsnById(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.GetUsnByIdResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnByIdResponse> GetUsnByIdAsync(SharpFrameSmall.Common.SFCS.GetUsnByIdRequest request) {
            return base.Channel.GetUsnByIdAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadPcbLot(SharpFrameSmall.Common.SFCS.UploadPcbLotRequest request) {
            return base.Channel.UploadPcbLot(request);
        }
        
        public string UploadPcbLot(ref string UnitSerialNumber, string StageCode, string Barcode, string LotNo, string UserID) {
            SharpFrameSmall.Common.SFCS.UploadPcbLotRequest inValue = new SharpFrameSmall.Common.SFCS.UploadPcbLotRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Barcode = Barcode;
            inValue.LotNo = LotNo;
            inValue.UserID = UserID;
            SharpFrameSmall.Common.SFCS.UploadPcbLotResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadPcbLot(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.UploadPcbLotResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotResponse> UploadPcbLotAsync(SharpFrameSmall.Common.SFCS.UploadPcbLotRequest request) {
            return base.Channel.UploadPcbLotAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode1 SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadPcbLot1(SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode request) {
            return base.Channel.UploadPcbLot1(request);
        }
        
        public string UploadPcbLot1(ref string UnitSerialNumber, string StageCode, string Barcode, string LotNo, string UserID, string PCB2DBarcode) {
            SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode inValue = new SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Barcode = Barcode;
            inValue.LotNo = LotNo;
            inValue.UserID = UserID;
            inValue.PCB2DBarcode = PCB2DBarcode;
            SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadPcbLot1(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.UploadPcbLotWithPCB2DBarcodeResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode1> UploadPcbLot1Async(SharpFrameSmall.Common.SFCS.UploadPcbLotWithPCB2DBarcode request) {
            return base.Channel.UploadPcbLot1Async(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate1 SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadPcbLotBy2DBarcode(SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate request) {
            return base.Channel.UploadPcbLotBy2DBarcode(request);
        }
        
        public string UploadPcbLotBy2DBarcode(ref string UnitSerialNumber, string StageCode, string Item2DBarcode, string UnsealDate, string UserID) {
            SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate inValue = new SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Item2DBarcode = Item2DBarcode;
            inValue.UnsealDate = UnsealDate;
            inValue.UserID = UserID;
            SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadPcbLotBy2DBarcode(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.UploadPcbLotWith2DBarcodeincludeUnsealDateResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate1> UploadPcbLotBy2DBarcodeAsync(SharpFrameSmall.Common.SFCS.UploadPcbLotWith2DBarcodeincludeUnsealDate request) {
            return base.Channel.UploadPcbLotBy2DBarcodeAsync(request);
        }
        
        public string UploadEngravingResult(string UnitSerialNumber, string StageCode, string UserID, string EngravingResult) {
            return base.Channel.UploadEngravingResult(UnitSerialNumber, StageCode, UserID, EngravingResult);
        }
        
        public System.Threading.Tasks.Task<string> UploadEngravingResultAsync(string UnitSerialNumber, string StageCode, string UserID, string EngravingResult) {
            return base.Channel.UploadEngravingResultAsync(UnitSerialNumber, StageCode, UserID, EngravingResult);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadAstroMoInfo(SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest request) {
            return base.Channel.UploadAstroMoInfo(request);
        }
        
        public string UploadAstroMoInfo(string MO, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest inValue = new SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest();
            inValue.MO = MO;
            inValue.StageCode = StageCode;
            inValue.InfoNameValues = InfoNameValues;
            SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadAstroMoInfo(inValue);
            return retVal.UploadAstroMoInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadAstroMoInfoAsync(SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest request) {
            return base.Channel.UploadAstroMoInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadAstroMoInfoResponse> UploadAstroMoInfoAsync(string MO, string StageCode, SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest inValue = new SharpFrameSmall.Common.SFCS.UploadAstroMoInfoRequest();
            inValue.MO = MO;
            inValue.StageCode = StageCode;
            inValue.InfoNameValues = InfoNameValues;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadAstroMoInfoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUpnInfoFromView(SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest request) {
            return base.Channel.GetUpnInfoFromView(request);
        }
        
        public string GetUpnInfoFromView(string UnitPartNumber, string StageCode, string UpnInfoType, ref SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest inValue = new SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest();
            inValue.UnitPartNumber = UnitPartNumber;
            inValue.StageCode = StageCode;
            inValue.UpnInfoType = UpnInfoType;
            inValue.InfoNameValues = InfoNameValues;
            SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUpnInfoFromView(inValue);
            InfoNameValues = retVal.InfoNameValues;
            return retVal.GetUpnInfoFromViewResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewResponse> GetUpnInfoFromViewAsync(SharpFrameSmall.Common.SFCS.GetUpnInfoFromViewRequest request) {
            return base.Channel.GetUpnInfoFromViewAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetKeyInfoFromView(SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest request) {
            return base.Channel.GetKeyInfoFromView(request);
        }
        
        public string GetKeyInfoFromView(string Key, string StageCode, string KeyInfoType, ref SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest inValue = new SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest();
            inValue.Key = Key;
            inValue.StageCode = StageCode;
            inValue.KeyInfoType = KeyInfoType;
            inValue.InfoNameValues = InfoNameValues;
            SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetKeyInfoFromView(inValue);
            InfoNameValues = retVal.InfoNameValues;
            return retVal.GetKeyInfoFromViewResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewResponse> GetKeyInfoFromViewAsync(SharpFrameSmall.Common.SFCS.GetKeyInfoFromViewRequest request) {
            return base.Channel.GetKeyInfoFromViewAsync(request);
        }
        
        public string UploadRuninRackStatus(string MAC, string StageCode, string RuninRackID) {
            return base.Channel.UploadRuninRackStatus(MAC, StageCode, RuninRackID);
        }
        
        public System.Threading.Tasks.Task<string> UploadRuninRackStatusAsync(string MAC, string StageCode, string RuninRackID) {
            return base.Channel.UploadRuninRackStatusAsync(MAC, StageCode, RuninRackID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.AllocateAndroidKeyResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.AllocateAndroidKey(SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest request) {
            return base.Channel.AllocateAndroidKey(request);
        }
        
        public string AllocateAndroidKey(string UnitSerialNumber, string StageCode, string Workstation, string ActionType, string ReturnField, ref string ResultValue) {
            SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest inValue = new SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Workstation = Workstation;
            inValue.ActionType = ActionType;
            inValue.ReturnField = ReturnField;
            inValue.ResultValue = ResultValue;
            SharpFrameSmall.Common.SFCS.AllocateAndroidKeyResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).AllocateAndroidKey(inValue);
            ResultValue = retVal.ResultValue;
            return retVal.AllocateAndroidKeyResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAndroidKeyResponse> AllocateAndroidKeyAsync(SharpFrameSmall.Common.SFCS.AllocateAndroidKeyRequest request) {
            return base.Channel.AllocateAndroidKeyAsync(request);
        }
        
        public string CheckEngravingBoradBarcLotNo(string StageCode, string Barcode, string LotNo) {
            return base.Channel.CheckEngravingBoradBarcLotNo(StageCode, Barcode, LotNo);
        }
        
        public System.Threading.Tasks.Task<string> CheckEngravingBoradBarcLotNoAsync(string StageCode, string Barcode, string LotNo) {
            return base.Channel.CheckEngravingBoradBarcLotNoAsync(StageCode, Barcode, LotNo);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.AllocateAwaitingUnitSnList(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest request) {
            return base.Channel.AllocateAwaitingUnitSnList(request);
        }
        
        public string AllocateAwaitingUnitSnList(string MO, string StageCode, string MachineID, ref string UnitSerialNumberList) {
            SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest inValue = new SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest();
            inValue.MO = MO;
            inValue.StageCode = StageCode;
            inValue.MachineID = MachineID;
            inValue.UnitSerialNumberList = UnitSerialNumberList;
            SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).AllocateAwaitingUnitSnList(inValue);
            UnitSerialNumberList = retVal.UnitSerialNumberList;
            return retVal.AllocateAwaitingUnitSnListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListResponse> AllocateAwaitingUnitSnListAsync(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListRequest request) {
            return base.Channel.AllocateAwaitingUnitSnListAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack1 SharpFrameSmall.Common.SFCS.WebServiceSoap.AllocateAwaitingUnitSnListForExtendCode(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack request) {
            return base.Channel.AllocateAwaitingUnitSnListForExtendCode(request);
        }
        
        public string AllocateAwaitingUnitSnListForExtendCode(string MO, string StageCode, string MachineID, ref string UnitSerialNumberList, string ExtendCode) {
            SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack inValue = new SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack();
            inValue.MO = MO;
            inValue.StageCode = StageCode;
            inValue.MachineID = MachineID;
            inValue.UnitSerialNumberList = UnitSerialNumberList;
            inValue.ExtendCode = ExtendCode;
            SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).AllocateAwaitingUnitSnListForExtendCode(inValue);
            UnitSerialNumberList = retVal.UnitSerialNumberList;
            return retVal.AllocateAwaitingUnitSnListForExtendCodeZackResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack1> AllocateAwaitingUnitSnListForExtendCodeAsync(SharpFrameSmall.Common.SFCS.AllocateAwaitingUnitSnListForExtendCodeZack request) {
            return base.Channel.AllocateAwaitingUnitSnListForExtendCodeAsync(request);
        }
        
        public string UploadCompleteEngravingUnitSn(string UnitSerialNumberList, string StageCode, string MachineID) {
            return base.Channel.UploadCompleteEngravingUnitSn(UnitSerialNumberList, StageCode, MachineID);
        }
        
        public System.Threading.Tasks.Task<string> UploadCompleteEngravingUnitSnAsync(string UnitSerialNumberList, string StageCode, string MachineID) {
            return base.Channel.UploadCompleteEngravingUnitSnAsync(UnitSerialNumberList, StageCode, MachineID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetMoAndBoardInfo(SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest request) {
            return base.Channel.GetMoAndBoardInfo(request);
        }
        
        public string GetMoAndBoardInfo(string SheetNo, ref SharpFrameSmall.Common.SFCS.clsMOAndBoardInfo ClassMOAndBoardInfo) {
            SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest inValue = new SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest();
            inValue.SheetNo = SheetNo;
            inValue.ClassMOAndBoardInfo = ClassMOAndBoardInfo;
            SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetMoAndBoardInfo(inValue);
            ClassMOAndBoardInfo = retVal.ClassMOAndBoardInfo;
            return retVal.GetMoAndBoardInfoResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoResponse> GetMoAndBoardInfoAsync(SharpFrameSmall.Common.SFCS.GetMoAndBoardInfoRequest request) {
            return base.Channel.GetMoAndBoardInfoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.Get2SLabelInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.Get2SLabelInfo(SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest request) {
            return base.Channel.Get2SLabelInfo(request);
        }
        
        public string Get2SLabelInfo(string SheetNo, string Item2DBarcode, ref SharpFrameSmall.Common.SFCS.cls2SLabelInfo Class2SLabelInfo) {
            SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest inValue = new SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest();
            inValue.SheetNo = SheetNo;
            inValue.Item2DBarcode = Item2DBarcode;
            inValue.Class2SLabelInfo = Class2SLabelInfo;
            SharpFrameSmall.Common.SFCS.Get2SLabelInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).Get2SLabelInfo(inValue);
            Class2SLabelInfo = retVal.Class2SLabelInfo;
            return retVal.Get2SLabelInfoResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.Get2SLabelInfoResponse> Get2SLabelInfoAsync(SharpFrameSmall.Common.SFCS.Get2SLabelInfoRequest request) {
            return base.Channel.Get2SLabelInfoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.Upload2SLabelInfo(SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest request) {
            return base.Channel.Upload2SLabelInfo(request);
        }
        
        public string Upload2SLabelInfo(string SheetNo, string Item2DBarcode, string Brand, string UserID) {
            SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest inValue = new SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest();
            inValue.SheetNo = SheetNo;
            inValue.Item2DBarcode = Item2DBarcode;
            inValue.Brand = Brand;
            inValue.UserID = UserID;
            SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).Upload2SLabelInfo(inValue);
            return retVal.Upload2SLabelInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.Upload2SLabelInfoAsync(SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest request) {
            return base.Channel.Upload2SLabelInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.Upload2SLabelInfoResponse> Upload2SLabelInfoAsync(string SheetNo, string Item2DBarcode, string Brand, string UserID) {
            SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest inValue = new SharpFrameSmall.Common.SFCS.Upload2SLabelInfoRequest();
            inValue.SheetNo = SheetNo;
            inValue.Item2DBarcode = Item2DBarcode;
            inValue.Brand = Brand;
            inValue.UserID = UserID;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).Upload2SLabelInfoAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUsnInformationListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUsnInformationList(SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest request) {
            return base.Channel.GetUsnInformationList(request);
        }
        
        public string GetUsnInformationList(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest inValue = new SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.InfoNameValues = InfoNameValues;
            SharpFrameSmall.Common.SFCS.GetUsnInformationListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUsnInformationList(inValue);
            InfoNameValues = retVal.InfoNameValues;
            return retVal.GetUsnInformationListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUsnInformationListResponse> GetUsnInformationListAsync(SharpFrameSmall.Common.SFCS.GetUsnInformationListRequest request) {
            return base.Channel.GetUsnInformationListAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetTvDacDataListResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetTvDacDataList(SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest request) {
            return base.Channel.GetTvDacDataList(request);
        }
        
        public string GetTvDacDataList(string UnitSerialNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsTvDacData[] TvDacDataArray) {
            SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest inValue = new SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.TvDacDataArray = TvDacDataArray;
            SharpFrameSmall.Common.SFCS.GetTvDacDataListResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetTvDacDataList(inValue);
            TvDacDataArray = retVal.TvDacDataArray;
            return retVal.GetTvDacDataListResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTvDacDataListResponse> GetTvDacDataListAsync(SharpFrameSmall.Common.SFCS.GetTvDacDataListRequest request) {
            return base.Channel.GetTvDacDataListAsync(request);
        }
        
        public string SwapUSN(string UnitSerialNumber, string StageCode, string ViceUnitSN) {
            return base.Channel.SwapUSN(UnitSerialNumber, StageCode, ViceUnitSN);
        }
        
        public System.Threading.Tasks.Task<string> SwapUSNAsync(string UnitSerialNumber, string StageCode, string ViceUnitSN) {
            return base.Channel.SwapUSNAsync(UnitSerialNumber, StageCode, ViceUnitSN);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetEllaRackLoctionResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetEllaRackLoction(SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest request) {
            return base.Channel.GetEllaRackLoction(request);
        }
        
        public string GetEllaRackLoction(string UnitSerialNumber, string Line, string StageCode, ref SharpFrameSmall.Common.SFCS.clsInfoNameValue[] InfoNameValues) {
            SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest inValue = new SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.InfoNameValues = InfoNameValues;
            SharpFrameSmall.Common.SFCS.GetEllaRackLoctionResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetEllaRackLoction(inValue);
            InfoNameValues = retVal.InfoNameValues;
            return retVal.GetEllaRackLoctionResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetEllaRackLoctionResponse> GetEllaRackLoctionAsync(SharpFrameSmall.Common.SFCS.GetEllaRackLoctionRequest request) {
            return base.Channel.GetEllaRackLoctionAsync(request);
        }
        
        public string UploadOCRInfo(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID) {
            return base.Channel.UploadOCRInfo(UnitSerialNumber, StageCode, CustomerPN, LotNo, VendorCode, UserID);
        }
        
        public System.Threading.Tasks.Task<string> UploadOCRInfoAsync(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID) {
            return base.Channel.UploadOCRInfoAsync(UnitSerialNumber, StageCode, CustomerPN, LotNo, VendorCode, UserID);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1 SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadOCRInfo1(SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode request) {
            return base.Channel.UploadOCRInfo1(request);
        }
        
        public string UploadOCRInfo1(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID, string PCB2DBarcode) {
            SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode inValue = new SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.CustomerPN = CustomerPN;
            inValue.LotNo = LotNo;
            inValue.VendorCode = VendorCode;
            inValue.UserID = UserID;
            inValue.PCB2DBarcode = PCB2DBarcode;
            SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadOCRInfo1(inValue);
            return retVal.UploadOCRInfoWithPCB2DBarcodeResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1> SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadOCRInfo1Async(SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode request) {
            return base.Channel.UploadOCRInfo1Async(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode1> UploadOCRInfo1Async(string UnitSerialNumber, string StageCode, string CustomerPN, string LotNo, string VendorCode, string UserID, string PCB2DBarcode) {
            SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode inValue = new SharpFrameSmall.Common.SFCS.UploadOCRInfoWithPCB2DBarcode();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.CustomerPN = CustomerPN;
            inValue.LotNo = LotNo;
            inValue.VendorCode = VendorCode;
            inValue.UserID = UserID;
            inValue.PCB2DBarcode = PCB2DBarcode;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadOCRInfo1Async(inValue);
        }
        
        public SharpFrameSmall.Common.SFCS.clsBomPnDescription[] GetBomPnDescription(string TopPN, string Level) {
            return base.Channel.GetBomPnDescription(TopPN, Level);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsBomPnDescription[]> GetBomPnDescriptionAsync(string TopPN, string Level) {
            return base.Channel.GetBomPnDescriptionAsync(TopPN, Level);
        }
        
        public string UploadBomTransferUPN(string UnitPartNumber) {
            return base.Channel.UploadBomTransferUPN(UnitPartNumber);
        }
        
        public System.Threading.Tasks.Task<string> UploadBomTransferUPNAsync(string UnitPartNumber) {
            return base.Channel.UploadBomTransferUPNAsync(UnitPartNumber);
        }
        
        public string RecordLogMessage(string ProcessID, string FileName, string DocumentNumber, string Status) {
            return base.Channel.RecordLogMessage(ProcessID, FileName, DocumentNumber, Status);
        }
        
        public System.Threading.Tasks.Task<string> RecordLogMessageAsync(string ProcessID, string FileName, string DocumentNumber, string Status) {
            return base.Channel.RecordLogMessageAsync(ProcessID, FileName, DocumentNumber, Status);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.RecordESOPInfo(SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest request) {
            return base.Channel.RecordESOPInfo(request);
        }
        
        public string RecordESOPInfo(string ProcessID, string FileName, string DocumentNumber, string Model, string Stage, string[] MappingRelation) {
            SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest inValue = new SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest();
            inValue.ProcessID = ProcessID;
            inValue.FileName = FileName;
            inValue.DocumentNumber = DocumentNumber;
            inValue.Model = Model;
            inValue.Stage = Stage;
            inValue.MappingRelation = MappingRelation;
            SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).RecordESOPInfo(inValue);
            return retVal.RecordESOPInfoResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.RecordESOPInfoAsync(SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest request) {
            return base.Channel.RecordESOPInfoAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.RecordESOPInfoResponse> RecordESOPInfoAsync(string ProcessID, string FileName, string DocumentNumber, string Model, string Stage, string[] MappingRelation) {
            SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest inValue = new SharpFrameSmall.Common.SFCS.RecordESOPInfoRequest();
            inValue.ProcessID = ProcessID;
            inValue.FileName = FileName;
            inValue.DocumentNumber = DocumentNumber;
            inValue.Model = Model;
            inValue.Stage = Stage;
            inValue.MappingRelation = MappingRelation;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).RecordESOPInfoAsync(inValue);
        }
        
        public string LinkUsnWorkingPalletId(string UnitSerialNumber, string WorkingPalletID, string StageCode) {
            return base.Channel.LinkUsnWorkingPalletId(UnitSerialNumber, WorkingPalletID, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> LinkUsnWorkingPalletIdAsync(string UnitSerialNumber, string WorkingPalletID, string StageCode) {
            return base.Channel.LinkUsnWorkingPalletIdAsync(UnitSerialNumber, WorkingPalletID, StageCode);
        }
        
        public System.Data.DataSet GetDynamicData(string DynQueryID, string CriteriaName, string CriteriaValue) {
            return base.Channel.GetDynamicData(DynQueryID, CriteriaName, CriteriaValue);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetDynamicDataAsync(string DynQueryID, string CriteriaName, string CriteriaValue) {
            return base.Channel.GetDynamicDataAsync(DynQueryID, CriteriaName, CriteriaValue);
        }
        
        public string CheckRoute(string UnitSerialNumber, string StageCode) {
            return base.Channel.CheckRoute(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> CheckRouteAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.CheckRouteAsync(UnitSerialNumber, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompleteResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.Complete(SharpFrameSmall.Common.SFCS.CompleteRequest request) {
            return base.Channel.Complete(request);
        }
        
        public string Complete(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas) {
            SharpFrameSmall.Common.SFCS.CompleteRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            SharpFrameSmall.Common.SFCS.CompleteResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).Complete(inValue);
            return retVal.CompleteResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteAsync(SharpFrameSmall.Common.SFCS.CompleteRequest request) {
            return base.Channel.CompleteAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteResponse> CompleteAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas) {
            SharpFrameSmall.Common.SFCS.CompleteRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteAsync(inValue);
        }
        
        public string BatchComplete(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID) {
            return base.Channel.BatchComplete(UnitSerialNumber, Line, StageCode, StationName, EmployeeID);
        }
        
        public System.Threading.Tasks.Task<string> BatchCompleteAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID) {
            return base.Channel.BatchCompleteAsync(UnitSerialNumber, Line, StageCode, StationName, EmployeeID);
        }
        
        public string CompleteWithSingleTrnData(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string TrnData) {
            return base.Channel.CompleteWithSingleTrnData(UnitSerialNumber, Line, StageCode, StationName, EmployeeID, Pass, TrnData);
        }
        
        public System.Threading.Tasks.Task<string> CompleteWithSingleTrnDataAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string TrnData) {
            return base.Channel.CompleteWithSingleTrnDataAsync(UnitSerialNumber, Line, StageCode, StationName, EmployeeID, Pass, TrnData);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemark(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest request) {
            return base.Channel.CompleteWithDefectRemark(request);
        }
        
        public string CompleteWithDefectRemark(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemark(inValue);
            return retVal.CompleteWithDefectRemarkResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemarkAsync(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest request) {
            return base.Channel.CompleteWithDefectRemarkAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkResponse> CompleteWithDefectRemarkAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemarkAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1 SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemark1(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag request) {
            return base.Channel.CompleteWithDefectRemark1(request);
        }
        
        public string CompleteWithDefectRemark1(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string Diag, string Bios) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            inValue.Diag = Diag;
            inValue.Bios = Bios;
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemark1(inValue);
            return retVal.CompleteWithDefectRemarkBiosDiagResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1> SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemark1Async(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag request) {
            return base.Channel.CompleteWithDefectRemark1Async(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag1> CompleteWithDefectRemark1Async(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string Diag, string Bios) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkBiosDiag();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            inValue.Diag = Diag;
            inValue.Bios = Bios;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemark1Async(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1 SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemark2(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson request) {
            return base.Channel.CompleteWithDefectRemark2(request);
        }
        
        public string CompleteWithDefectRemark2(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string ExtendTransInfo) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            inValue.ExtendTransInfo = ExtendTransInfo;
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1 retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemark2(inValue);
            return retVal.CompleteWithDefectRemarkJsonResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1> SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithDefectRemark2Async(SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson request) {
            return base.Channel.CompleteWithDefectRemark2Async(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson1> CompleteWithDefectRemark2Async(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string DefectRmark, string ExtendTransInfo) {
            SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson inValue = new SharpFrameSmall.Common.SFCS.CompleteWithDefectRemarkJson();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.DefectRmark = DefectRmark;
            inValue.ExtendTransInfo = ExtendTransInfo;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithDefectRemark2Async(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithErrorDescription(SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest request) {
            return base.Channel.CompleteWithErrorDescription(request);
        }
        
        public string CompleteWithErrorDescription(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string ErrorDescription) {
            SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.ErrorDescription = ErrorDescription;
            SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithErrorDescription(inValue);
            return retVal.CompleteWithErrorDescriptionResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.CompleteWithErrorDescriptionAsync(SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest request) {
            return base.Channel.CompleteWithErrorDescriptionAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionResponse> CompleteWithErrorDescriptionAsync(string UnitSerialNumber, string Line, string StageCode, string StationName, string EmployeeID, bool Pass, string[] TrnDatas, string ErrorDescription) {
            SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest inValue = new SharpFrameSmall.Common.SFCS.CompleteWithErrorDescriptionRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.Line = Line;
            inValue.StageCode = StageCode;
            inValue.StationName = StationName;
            inValue.EmployeeID = EmployeeID;
            inValue.Pass = Pass;
            inValue.TrnDatas = TrnDatas;
            inValue.ErrorDescription = ErrorDescription;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).CompleteWithErrorDescriptionAsync(inValue);
        }
        
        public string UploadTVADC(string SerialNo, string Line, string StageCode, string Workstation, int Type1, int Type2, int ValueR, int ValueG, int ValueB) {
            return base.Channel.UploadTVADC(SerialNo, Line, StageCode, Workstation, Type1, Type2, ValueR, ValueG, ValueB);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVADCAsync(string SerialNo, string Line, string StageCode, string Workstation, int Type1, int Type2, int ValueR, int ValueG, int ValueB) {
            return base.Channel.UploadTVADCAsync(SerialNo, Line, StageCode, Workstation, Type1, Type2, ValueR, ValueG, ValueB);
        }
        
        public string UploadTVDAC(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int RCut, int GCut, int BCut, int RGain, int GGain, int BGain) {
            return base.Channel.UploadTVDAC(SerialNo, Line, StageCode, Workstation, ColorType, RCut, GCut, BCut, RGain, GGain, BGain);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVDACAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int RCut, int GCut, int BCut, int RGain, int GGain, int BGain) {
            return base.Channel.UploadTVDACAsync(SerialNo, Line, StageCode, Workstation, ColorType, RCut, GCut, BCut, RGain, GGain, BGain);
        }
        
        public string UploadTVQC(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue) {
            return base.Channel.UploadTVQC(SerialNo, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVQCAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue) {
            return base.Channel.UploadTVQCAsync(SerialNo, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue);
        }
        
        public string UploadTVQCwithWhiteBalanceFlag(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance) {
            return base.Channel.UploadTVQCwithWhiteBalanceFlag(SerialNo, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue, IsWhiteBalance);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVQCwithWhiteBalanceFlagAsync(string SerialNo, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance) {
            return base.Channel.UploadTVQCwithWhiteBalanceFlagAsync(SerialNo, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue, IsWhiteBalance);
        }
        
        public string UploadMonitorWhiteBalance(string UnitSerialNumber, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance, decimal Dark, int Contrast) {
            return base.Channel.UploadMonitorWhiteBalance(UnitSerialNumber, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue, IsWhiteBalance, Dark, Contrast);
        }
        
        public System.Threading.Tasks.Task<string> UploadMonitorWhiteBalanceAsync(string UnitSerialNumber, string Line, string StageCode, string Workstation, int ColorType, int IRE, int XCoordinate, int YCoordinate, decimal LuminanceValue, bool IsWhiteBalance, decimal Dark, int Contrast) {
            return base.Channel.UploadMonitorWhiteBalanceAsync(UnitSerialNumber, Line, StageCode, Workstation, ColorType, IRE, XCoordinate, YCoordinate, LuminanceValue, IsWhiteBalance, Dark, Contrast);
        }
        
        public string UploadTVPowerRange(string OPID, string SerialNo, string Line, string Stage, string Workstation, int Type, int SubType, string TestItem, string Voltage, string Current, string PowerWatt, string PowerFactor, string Result, int TestItemIndex) {
            return base.Channel.UploadTVPowerRange(OPID, SerialNo, Line, Stage, Workstation, Type, SubType, TestItem, Voltage, Current, PowerWatt, PowerFactor, Result, TestItemIndex);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVPowerRangeAsync(string OPID, string SerialNo, string Line, string Stage, string Workstation, int Type, int SubType, string TestItem, string Voltage, string Current, string PowerWatt, string PowerFactor, string Result, int TestItemIndex) {
            return base.Channel.UploadTVPowerRangeAsync(OPID, SerialNo, Line, Stage, Workstation, Type, SubType, TestItem, Voltage, Current, PowerWatt, PowerFactor, Result, TestItemIndex);
        }
        
        public string UploadTVHDCPKey(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsHDCPKey[] HDCPKeys) {
            return base.Channel.UploadTVHDCPKey(SerialNo, Line, StageCode, Workstation, HDCPKeys);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVHDCPKeyAsync(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsHDCPKey[] HDCPKeys) {
            return base.Channel.UploadTVHDCPKeyAsync(SerialNo, Line, StageCode, Workstation, HDCPKeys);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetHDCPKeyResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetHDCPKey(SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest request) {
            return base.Channel.GetHDCPKey(request);
        }
        
        public string GetHDCPKey(string UnitSerialNumber, string StageCode, ref string HDCPKey) {
            SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest inValue = new SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.HDCPKey = HDCPKey;
            SharpFrameSmall.Common.SFCS.GetHDCPKeyResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetHDCPKey(inValue);
            HDCPKey = retVal.HDCPKey;
            return retVal.GetHDCPKeyResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetHDCPKeyResponse> GetHDCPKeyAsync(SharpFrameSmall.Common.SFCS.GetHDCPKeyRequest request) {
            return base.Channel.GetHDCPKeyAsync(request);
        }
        
        public string UploadTVCIPlusKey(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsCIPlusKey[] CIPlusKeys) {
            return base.Channel.UploadTVCIPlusKey(SerialNo, Line, StageCode, Workstation, CIPlusKeys);
        }
        
        public System.Threading.Tasks.Task<string> UploadTVCIPlusKeyAsync(string SerialNo, string Line, string StageCode, string Workstation, SharpFrameSmall.Common.SFCS.clsCIPlusKey[] CIPlusKeys) {
            return base.Channel.UploadTVCIPlusKeyAsync(SerialNo, Line, StageCode, Workstation, CIPlusKeys);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetCIPlusKeyResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetCIPlusKey(SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest request) {
            return base.Channel.GetCIPlusKey(request);
        }
        
        public string GetCIPlusKey(string UnitSerialNumber, string StageCode, ref string CIPlusKey) {
            SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest inValue = new SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.CIPlusKey = CIPlusKey;
            SharpFrameSmall.Common.SFCS.GetCIPlusKeyResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetCIPlusKey(inValue);
            CIPlusKey = retVal.CIPlusKey;
            return retVal.GetCIPlusKeyResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetCIPlusKeyResponse> GetCIPlusKeyAsync(SharpFrameSmall.Common.SFCS.GetCIPlusKeyRequest request) {
            return base.Channel.GetCIPlusKeyAsync(request);
        }
        
        public string GetUSNItem(string UnitSerialNumber, string StageCode, string Category, string Sequence) {
            return base.Channel.GetUSNItem(UnitSerialNumber, StageCode, Category, Sequence);
        }
        
        public System.Threading.Tasks.Task<string> GetUSNItemAsync(string UnitSerialNumber, string StageCode, string Category, string Sequence) {
            return base.Channel.GetUSNItemAsync(UnitSerialNumber, StageCode, Category, Sequence);
        }
        
        public string UploadUSNItem(string UnitSerialNumber, string StageCode, string Category, string ComponentSerialNumber, int Sequence, int CheckUsed) {
            return base.Channel.UploadUSNItem(UnitSerialNumber, StageCode, Category, ComponentSerialNumber, Sequence, CheckUsed);
        }
        
        public System.Threading.Tasks.Task<string> UploadUSNItemAsync(string UnitSerialNumber, string StageCode, string Category, string ComponentSerialNumber, int Sequence, int CheckUsed) {
            return base.Channel.UploadUSNItemAsync(UnitSerialNumber, StageCode, Category, ComponentSerialNumber, Sequence, CheckUsed);
        }
        
        public string UploadUSNItemWithBarcodeValidation(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, bool Assembly, string CheckUsedCategory, string Line, string Workstation, string UserID) {
            return base.Channel.UploadUSNItemWithBarcodeValidation(UnitSerialNumber, StageCode, ComponentSerialNumber, Assembly, CheckUsedCategory, Line, Workstation, UserID);
        }
        
        public System.Threading.Tasks.Task<string> UploadUSNItemWithBarcodeValidationAsync(string UnitSerialNumber, string StageCode, string ComponentSerialNumber, bool Assembly, string CheckUsedCategory, string Line, string Workstation, string UserID) {
            return base.Channel.UploadUSNItemWithBarcodeValidationAsync(UnitSerialNumber, StageCode, ComponentSerialNumber, Assembly, CheckUsedCategory, Line, Workstation, UserID);
        }
        
        public string GetUsnID(string UnitSerialNumber, string StageCode, int IDType, int Sequence) {
            return base.Channel.GetUsnID(UnitSerialNumber, StageCode, IDType, Sequence);
        }
        
        public System.Threading.Tasks.Task<string> GetUsnIDAsync(string UnitSerialNumber, string StageCode, int IDType, int Sequence) {
            return base.Channel.GetUsnIDAsync(UnitSerialNumber, StageCode, IDType, Sequence);
        }
        
        public string[] GetUsnIdWithoutCombine(string UnitSerialNumber, string StageCode, string Category) {
            return base.Channel.GetUsnIdWithoutCombine(UnitSerialNumber, StageCode, Category);
        }
        
        public System.Threading.Tasks.Task<string[]> GetUsnIdWithoutCombineAsync(string UnitSerialNumber, string StageCode, string Category) {
            return base.Channel.GetUsnIdWithoutCombineAsync(UnitSerialNumber, StageCode, Category);
        }
        
        public string GetHDCPFileName(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetHDCPFileName(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetHDCPFileNameAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetHDCPFileNameAsync(UnitSerialNumber, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.UploadFixtureIDResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.UploadFixtureID(SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest request) {
            return base.Channel.UploadFixtureID(request);
        }
        
        public string UploadFixtureID(string UnitSerialNumber, string StageCode, string FixtureID, ref string FixtureIDSeq) {
            SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest inValue = new SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.FixtureID = FixtureID;
            inValue.FixtureIDSeq = FixtureIDSeq;
            SharpFrameSmall.Common.SFCS.UploadFixtureIDResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).UploadFixtureID(inValue);
            FixtureIDSeq = retVal.FixtureIDSeq;
            return retVal.UploadFixtureIDResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.UploadFixtureIDResponse> UploadFixtureIDAsync(SharpFrameSmall.Common.SFCS.UploadFixtureIDRequest request) {
            return base.Channel.UploadFixtureIDAsync(request);
        }
        
        public string CheckFixtureID(string StageCode, string FixtureID) {
            return base.Channel.CheckFixtureID(StageCode, FixtureID);
        }
        
        public System.Threading.Tasks.Task<string> CheckFixtureIDAsync(string StageCode, string FixtureID) {
            return base.Channel.CheckFixtureIDAsync(StageCode, FixtureID);
        }
        
        public void UpdateFixtureIDPasscount(string UnitSerialNumber, string StageCode, string FixtureIDSeq) {
            base.Channel.UpdateFixtureIDPasscount(UnitSerialNumber, StageCode, FixtureIDSeq);
        }
        
        public System.Threading.Tasks.Task UpdateFixtureIDPasscountAsync(string UnitSerialNumber, string StageCode, string FixtureIDSeq) {
            return base.Channel.UpdateFixtureIDPasscountAsync(UnitSerialNumber, StageCode, FixtureIDSeq);
        }
        
        public string UploadVolTage(string UnitSerialNumber, string StageCode, string TestData, string TestResult) {
            return base.Channel.UploadVolTage(UnitSerialNumber, StageCode, TestData, TestResult);
        }
        
        public System.Threading.Tasks.Task<string> UploadVolTageAsync(string UnitSerialNumber, string StageCode, string TestData, string TestResult) {
            return base.Channel.UploadVolTageAsync(UnitSerialNumber, StageCode, TestData, TestResult);
        }
        
        public string UploadTPSKeyValue(string SerialNo, string Stage, string TestType, string Key, string KeyVal) {
            return base.Channel.UploadTPSKeyValue(SerialNo, Stage, TestType, Key, KeyVal);
        }
        
        public System.Threading.Tasks.Task<string> UploadTPSKeyValueAsync(string SerialNo, string Stage, string TestType, string Key, string KeyVal) {
            return base.Channel.UploadTPSKeyValueAsync(SerialNo, Stage, TestType, Key, KeyVal);
        }
        
        public string UploadTPSLog(string SerialNo, string Stage, string ErrorID, string ErrorMsg, string TesterID, string StationID, string Model, string SWConfigRev, string TestSWConfigRev, string TestHostConfig, string TestHostSWConfigVer, string FWVer, string CPUID, string FROMSize) {
            return base.Channel.UploadTPSLog(SerialNo, Stage, ErrorID, ErrorMsg, TesterID, StationID, Model, SWConfigRev, TestSWConfigRev, TestHostConfig, TestHostSWConfigVer, FWVer, CPUID, FROMSize);
        }
        
        public System.Threading.Tasks.Task<string> UploadTPSLogAsync(string SerialNo, string Stage, string ErrorID, string ErrorMsg, string TesterID, string StationID, string Model, string SWConfigRev, string TestSWConfigRev, string TestHostConfig, string TestHostSWConfigVer, string FWVer, string CPUID, string FROMSize) {
            return base.Channel.UploadTPSLogAsync(SerialNo, Stage, ErrorID, ErrorMsg, TesterID, StationID, Model, SWConfigRev, TestSWConfigRev, TestHostConfig, TestHostSWConfigVer, FWVer, CPUID, FROMSize);
        }
        
        public string UploadTPSRetest(string SerialNo, string Stage, string TestType, string Item) {
            return base.Channel.UploadTPSRetest(SerialNo, Stage, TestType, Item);
        }
        
        public System.Threading.Tasks.Task<string> UploadTPSRetestAsync(string SerialNo, string Stage, string TestType, string Item) {
            return base.Channel.UploadTPSRetestAsync(SerialNo, Stage, TestType, Item);
        }
        
        public bool CheckOPID(string OperationID) {
            return base.Channel.CheckOPID(OperationID);
        }
        
        public System.Threading.Tasks.Task<bool> CheckOPIDAsync(string OperationID) {
            return base.Channel.CheckOPIDAsync(OperationID);
        }
        
        public SharpFrameSmall.Common.SFCS.clsMO1 GetUsnGenealogy(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUsnGenealogy(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMO1> GetUsnGenealogyAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUsnGenealogyAsync(UnitSerialNumber, StageCode);
        }
        
        public string GetEDIDFilename(string ProductCode, string PortType, string StageCode) {
            return base.Channel.GetEDIDFilename(ProductCode, PortType, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetEDIDFilenameAsync(string ProductCode, string PortType, string StageCode) {
            return base.Channel.GetEDIDFilenameAsync(ProductCode, PortType, StageCode);
        }
        
        public string UploadEDIDResult(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version) {
            return base.Channel.UploadEDIDResult(UnitSerialNumber, OPID, StageCode, Line, Workstation, PortType, Pass, EverWrite, Checksum, Version);
        }
        
        public System.Threading.Tasks.Task<string> UploadEDIDResultAsync(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version) {
            return base.Channel.UploadEDIDResultAsync(UnitSerialNumber, OPID, StageCode, Line, Workstation, PortType, Pass, EverWrite, Checksum, Version);
        }
        
        public string UploadMonitorEDID(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version, string EDID) {
            return base.Channel.UploadMonitorEDID(UnitSerialNumber, OPID, StageCode, Line, Workstation, PortType, Pass, EverWrite, Checksum, Version, EDID);
        }
        
        public System.Threading.Tasks.Task<string> UploadMonitorEDIDAsync(string UnitSerialNumber, string OPID, string StageCode, string Line, string Workstation, string PortType, bool Pass, bool EverWrite, string Checksum, string Version, string EDID) {
            return base.Channel.UploadMonitorEDIDAsync(UnitSerialNumber, OPID, StageCode, Line, Workstation, PortType, Pass, EverWrite, Checksum, Version, EDID);
        }
        
        public string UploadTestLog(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark) {
            return base.Channel.UploadTestLog(UnitSerialNumber, StageCode, Workstation, Line, OPID, Pass, ErrorCode, Remark);
        }
        
        public System.Threading.Tasks.Task<string> UploadTestLogAsync(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark) {
            return base.Channel.UploadTestLogAsync(UnitSerialNumber, StageCode, Workstation, Line, OPID, Pass, ErrorCode, Remark);
        }
        
        public string UploadTestLogWithChildUSN(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark, string ChildUSN) {
            return base.Channel.UploadTestLogWithChildUSN(UnitSerialNumber, StageCode, Workstation, Line, OPID, Pass, ErrorCode, Remark, ChildUSN);
        }
        
        public System.Threading.Tasks.Task<string> UploadTestLogWithChildUSNAsync(string UnitSerialNumber, string StageCode, string Workstation, string Line, string OPID, bool Pass, string ErrorCode, string Remark, string ChildUSN) {
            return base.Channel.UploadTestLogWithChildUSNAsync(UnitSerialNumber, StageCode, Workstation, Line, OPID, Pass, ErrorCode, Remark, ChildUSN);
        }
        
        public string UploadRuninRackUnitStartDate(string UnitSerialNumber, string StageCode) {
            return base.Channel.UploadRuninRackUnitStartDate(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> UploadRuninRackUnitStartDateAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.UploadRuninRackUnitStartDateAsync(UnitSerialNumber, StageCode);
        }
        
        public string CheckTestFixture(string FixtureGroupID, string StageCode) {
            return base.Channel.CheckTestFixture(FixtureGroupID, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> CheckTestFixtureAsync(string FixtureGroupID, string StageCode) {
            return base.Channel.CheckTestFixtureAsync(FixtureGroupID, StageCode);
        }
        
        public string UploadUSNInfo(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue) {
            return base.Channel.UploadUSNInfo(UnitSerialNumber, StageCode, InfoName, InfoValue);
        }
        
        public System.Threading.Tasks.Task<string> UploadUSNInfoAsync(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue) {
            return base.Channel.UploadUSNInfoAsync(UnitSerialNumber, StageCode, InfoName, InfoValue);
        }
        
        public string UploadUSNInfoWithUniqueCheckFlag(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue, bool UniqueCheck) {
            return base.Channel.UploadUSNInfoWithUniqueCheckFlag(UnitSerialNumber, StageCode, InfoName, InfoValue, UniqueCheck);
        }
        
        public System.Threading.Tasks.Task<string> UploadUSNInfoWithUniqueCheckFlagAsync(string UnitSerialNumber, string StageCode, string InfoName, string InfoValue, bool UniqueCheck) {
            return base.Channel.UploadUSNInfoWithUniqueCheckFlagAsync(UnitSerialNumber, StageCode, InfoName, InfoValue, UniqueCheck);
        }
        
        public string GetMOInfo(string UnitSerialNumber, string StageCode, string InfoName) {
            return base.Channel.GetMOInfo(UnitSerialNumber, StageCode, InfoName);
        }
        
        public System.Threading.Tasks.Task<string> GetMOInfoAsync(string UnitSerialNumber, string StageCode, string InfoName) {
            return base.Channel.GetMOInfoAsync(UnitSerialNumber, StageCode, InfoName);
        }
        
        public string GetTransactionTime(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetTransactionTime(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetTransactionTimeAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetTransactionTimeAsync(UnitSerialNumber, StageCode);
        }
        
        public string SetReflowStage(string UnitSerialNumber, string StageCode, string UserID) {
            return base.Channel.SetReflowStage(UnitSerialNumber, StageCode, UserID);
        }
        
        public System.Threading.Tasks.Task<string> SetReflowStageAsync(string UnitSerialNumber, string StageCode, string UserID) {
            return base.Channel.SetReflowStageAsync(UnitSerialNumber, StageCode, UserID);
        }
        
        public SharpFrameSmall.Common.SFCS.clsCA210OffsetResult[] GetSetCA210OffsetTable(int Type, string Model, string ProbeSN, string StageCode, SharpFrameSmall.Common.SFCS.clsCA210OffsetCheckFlag CA210OffsetCheckFlag) {
            return base.Channel.GetSetCA210OffsetTable(Type, Model, ProbeSN, StageCode, CA210OffsetCheckFlag);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsCA210OffsetResult[]> GetSetCA210OffsetTableAsync(int Type, string Model, string ProbeSN, string StageCode, SharpFrameSmall.Common.SFCS.clsCA210OffsetCheckFlag CA210OffsetCheckFlag) {
            return base.Channel.GetSetCA210OffsetTableAsync(Type, Model, ProbeSN, StageCode, CA210OffsetCheckFlag);
        }
        
        public SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult GetTestSuiteInfo(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetTestSuiteInfo(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult> GetTestSuiteInfoAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetTestSuiteInfoAsync(UnitSerialNumber, StageCode);
        }
        
        public SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult GetTestSuiteInfoWithDataSearchType(string UnitSerialNumber, string StageCode, string DataSerachType) {
            return base.Channel.GetTestSuiteInfoWithDataSearchType(UnitSerialNumber, StageCode, DataSerachType);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetTestSuiteInfoResult> GetTestSuiteInfoWithDataSearchTypeAsync(string UnitSerialNumber, string StageCode, string DataSerachType) {
            return base.Channel.GetTestSuiteInfoWithDataSearchTypeAsync(UnitSerialNumber, StageCode, DataSerachType);
        }
        
        public SharpFrameSmall.Common.SFCS.clsGetUSNInfoResult GetUSNInfo(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUSNInfo(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsGetUSNInfoResult> GetUSNInfoAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetUSNInfoAsync(UnitSerialNumber, StageCode);
        }
        
        public SharpFrameSmall.Common.SFCS.clsMOItem1[] GetMOItem(string UnitSerialNumber, string StageCode, string Category) {
            return base.Channel.GetMOItem(UnitSerialNumber, StageCode, Category);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsMOItem1[]> GetMOItemAsync(string UnitSerialNumber, string StageCode, string Category) {
            return base.Channel.GetMOItemAsync(UnitSerialNumber, StageCode, Category);
        }
        
        public string UploadMonitorLpByUsn(string Line, string Stage, string Workstation, string UnitSerialNumber, string V5, string V12, string V22, string SEMIFASN) {
            return base.Channel.UploadMonitorLpByUsn(Line, Stage, Workstation, UnitSerialNumber, V5, V12, V22, SEMIFASN);
        }
        
        public System.Threading.Tasks.Task<string> UploadMonitorLpByUsnAsync(string Line, string Stage, string Workstation, string UnitSerialNumber, string V5, string V12, string V22, string SEMIFASN) {
            return base.Channel.UploadMonitorLpByUsnAsync(Line, Stage, Workstation, UnitSerialNumber, V5, V12, V22, SEMIFASN);
        }
        
        public string UploadMonitorLP(string Line, string Stage, string Workstation, string ManufactureOrder, string V5, string V12, string V22, string SEMIFASN) {
            return base.Channel.UploadMonitorLP(Line, Stage, Workstation, ManufactureOrder, V5, V12, V22, SEMIFASN);
        }
        
        public System.Threading.Tasks.Task<string> UploadMonitorLPAsync(string Line, string Stage, string Workstation, string ManufactureOrder, string V5, string V12, string V22, string SEMIFASN) {
            return base.Channel.UploadMonitorLPAsync(Line, Stage, Workstation, ManufactureOrder, V5, V12, V22, SEMIFASN);
        }
        
        public bool CheckErrorCode(string ErrorCode, string StageCode) {
            return base.Channel.CheckErrorCode(ErrorCode, StageCode);
        }
        
        public System.Threading.Tasks.Task<bool> CheckErrorCodeAsync(string ErrorCode, string StageCode) {
            return base.Channel.CheckErrorCodeAsync(ErrorCode, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetRIRackPositionByUSN(SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest request) {
            return base.Channel.GetRIRackPositionByUSN(request);
        }
        
        public string GetRIRackPositionByUSN(string UnitSerialNumber, string StageCode, ref string RIRackPosition) {
            SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest inValue = new SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.RIRackPosition = RIRackPosition;
            SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetRIRackPositionByUSN(inValue);
            RIRackPosition = retVal.RIRackPosition;
            return retVal.GetRIRackPositionByUSNResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNResponse> GetRIRackPositionByUSNAsync(SharpFrameSmall.Common.SFCS.GetRIRackPositionByUSNRequest request) {
            return base.Channel.GetRIRackPositionByUSNAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNByRIRackPosition(SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest request) {
            return base.Channel.GetUSNByRIRackPosition(request);
        }
        
        public string GetUSNByRIRackPosition(string RIRackPosition, string StageCode, ref string UnitSerialNumber) {
            SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest();
            inValue.RIRackPosition = RIRackPosition;
            inValue.StageCode = StageCode;
            inValue.UnitSerialNumber = UnitSerialNumber;
            SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNByRIRackPosition(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.GetUSNByRIRackPositionResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionResponse> GetUSNByRIRackPositionAsync(SharpFrameSmall.Common.SFCS.GetUSNByRIRackPositionRequest request) {
            return base.Channel.GetUSNByRIRackPositionAsync(request);
        }
        
        public string UploadDownTime(string UnitSerialNumber, string StageCode, int TestTime, bool Result, string DownTimeCode) {
            return base.Channel.UploadDownTime(UnitSerialNumber, StageCode, TestTime, Result, DownTimeCode);
        }
        
        public System.Threading.Tasks.Task<string> UploadDownTimeAsync(string UnitSerialNumber, string StageCode, int TestTime, bool Result, string DownTimeCode) {
            return base.Channel.UploadDownTimeAsync(UnitSerialNumber, StageCode, TestTime, Result, DownTimeCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNInformationResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNInformation(SharpFrameSmall.Common.SFCS.GetUSNInformationRequest request) {
            return base.Channel.GetUSNInformation(request);
        }
        
        public string GetUSNInformation(string StageCode, string UnitSerialNumber, string InfoName, ref string InfoValue) {
            SharpFrameSmall.Common.SFCS.GetUSNInformationRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNInformationRequest();
            inValue.StageCode = StageCode;
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.InfoName = InfoName;
            inValue.InfoValue = InfoValue;
            SharpFrameSmall.Common.SFCS.GetUSNInformationResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNInformation(inValue);
            InfoValue = retVal.InfoValue;
            return retVal.GetUSNInformationResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNInformationResponse> GetUSNInformationAsync(SharpFrameSmall.Common.SFCS.GetUSNInformationRequest request) {
            return base.Channel.GetUSNInformationAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNByUSNInfo(SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest request) {
            return base.Channel.GetUSNByUSNInfo(request);
        }
        
        public string GetUSNByUSNInfo(string StageCode, string InfoName, string InfoValue, ref string UnitSerialNumber) {
            SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest();
            inValue.StageCode = StageCode;
            inValue.InfoName = InfoName;
            inValue.InfoValue = InfoValue;
            inValue.UnitSerialNumber = UnitSerialNumber;
            SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNByUSNInfo(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.GetUSNByUSNInfoResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoResponse> GetUSNByUSNInfoAsync(SharpFrameSmall.Common.SFCS.GetUSNByUSNInfoRequest request) {
            return base.Channel.GetUSNByUSNInfoAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetMessageResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetMessage(SharpFrameSmall.Common.SFCS.GetMessageRequest request) {
            return base.Channel.GetMessage(request);
        }
        
        public SharpFrameSmall.Common.SFCS.clsMessage GetMessage(string MessageID, string Language, string[] Parameter) {
            SharpFrameSmall.Common.SFCS.GetMessageRequest inValue = new SharpFrameSmall.Common.SFCS.GetMessageRequest();
            inValue.MessageID = MessageID;
            inValue.Language = Language;
            inValue.Parameter = Parameter;
            SharpFrameSmall.Common.SFCS.GetMessageResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetMessage(inValue);
            return retVal.GetMessageResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMessageResponse> SharpFrameSmall.Common.SFCS.WebServiceSoap.GetMessageAsync(SharpFrameSmall.Common.SFCS.GetMessageRequest request) {
            return base.Channel.GetMessageAsync(request);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMessageResponse> GetMessageAsync(string MessageID, string Language, string[] Parameter) {
            SharpFrameSmall.Common.SFCS.GetMessageRequest inValue = new SharpFrameSmall.Common.SFCS.GetMessageRequest();
            inValue.MessageID = MessageID;
            inValue.Language = Language;
            inValue.Parameter = Parameter;
            return ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetMessageAsync(inValue);
        }
        
        public SharpFrameSmall.Common.SFCS.clsSPCConfig GetSPCConfig(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsSPCConfig clsSPCConfig) {
            return base.Channel.GetSPCConfig(UnitSerialNumber, StageCode, clsSPCConfig);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsSPCConfig> GetSPCConfigAsync(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsSPCConfig clsSPCConfig) {
            return base.Channel.GetSPCConfigAsync(UnitSerialNumber, StageCode, clsSPCConfig);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUPNInformationResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUPNInformation(SharpFrameSmall.Common.SFCS.GetUPNInformationRequest request) {
            return base.Channel.GetUPNInformation(request);
        }
        
        public string GetUPNInformation(string UnitSerialNumber, string StageCode, string InfoName, ref string InfoValue) {
            SharpFrameSmall.Common.SFCS.GetUPNInformationRequest inValue = new SharpFrameSmall.Common.SFCS.GetUPNInformationRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.InfoName = InfoName;
            inValue.InfoValue = InfoValue;
            SharpFrameSmall.Common.SFCS.GetUPNInformationResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUPNInformation(inValue);
            InfoValue = retVal.InfoValue;
            return retVal.GetUPNInformationResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUPNInformationResponse> GetUPNInformationAsync(SharpFrameSmall.Common.SFCS.GetUPNInformationRequest request) {
            return base.Channel.GetUPNInformationAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetPanelParameterResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetPanelParameter(SharpFrameSmall.Common.SFCS.GetPanelParameterRequest request) {
            return base.Channel.GetPanelParameter(request);
        }
        
        public string GetPanelParameter(string UnitSerialNumber, string StageCode, ref string PanelParameter) {
            SharpFrameSmall.Common.SFCS.GetPanelParameterRequest inValue = new SharpFrameSmall.Common.SFCS.GetPanelParameterRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.PanelParameter = PanelParameter;
            SharpFrameSmall.Common.SFCS.GetPanelParameterResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetPanelParameter(inValue);
            PanelParameter = retVal.PanelParameter;
            return retVal.GetPanelParameterResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPanelParameterResponse> GetPanelParameterAsync(SharpFrameSmall.Common.SFCS.GetPanelParameterRequest request) {
            return base.Channel.GetPanelParameterAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetPanelParameterWithDataSearchType(SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest request) {
            return base.Channel.GetPanelParameterWithDataSearchType(request);
        }
        
        public string GetPanelParameterWithDataSearchType(string UnitSerialNumber, string StageCode, string DataSerachType, ref string PanelParameter) {
            SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest inValue = new SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.DataSerachType = DataSerachType;
            inValue.PanelParameter = PanelParameter;
            SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetPanelParameterWithDataSearchType(inValue);
            PanelParameter = retVal.PanelParameter;
            return retVal.GetPanelParameterWithDataSearchTypeResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeResponse> GetPanelParameterWithDataSearchTypeAsync(SharpFrameSmall.Common.SFCS.GetPanelParameterWithDataSearchTypeRequest request) {
            return base.Channel.GetPanelParameterWithDataSearchTypeAsync(request);
        }
        
        public SharpFrameSmall.Common.SFCS.clsRequestData GetUUTData(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsRequestData RequestData, int RequestDataType) {
            return base.Channel.GetUUTData(UnitSerialNumber, StageCode, RequestData, RequestDataType);
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.clsRequestData> GetUUTDataAsync(string UnitSerialNumber, string StageCode, SharpFrameSmall.Common.SFCS.clsRequestData RequestData, int RequestDataType) {
            return base.Channel.GetUUTDataAsync(UnitSerialNumber, StageCode, RequestData, RequestDataType);
        }
        
        public string GetUSNByCSN(string ComponentSerialNumber, string StageCode) {
            return base.Channel.GetUSNByCSN(ComponentSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetUSNByCSNAsync(string ComponentSerialNumber, string StageCode) {
            return base.Channel.GetUSNByCSNAsync(ComponentSerialNumber, StageCode);
        }
        
        public string UploadCertifyPO(string StageCode, string PO, string TieGroup, string ImageID, string SDRCheckSum, string UploadType) {
            return base.Channel.UploadCertifyPO(StageCode, PO, TieGroup, ImageID, SDRCheckSum, UploadType);
        }
        
        public System.Threading.Tasks.Task<string> UploadCertifyPOAsync(string StageCode, string PO, string TieGroup, string ImageID, string SDRCheckSum, string UploadType) {
            return base.Channel.UploadCertifyPOAsync(StageCode, PO, TieGroup, ImageID, SDRCheckSum, UploadType);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetSWCPNForUPNResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetSWCPNForUPN(SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest request) {
            return base.Channel.GetSWCPNForUPN(request);
        }
        
        public string GetSWCPNForUPN(string UnitPartNumber, string StageCode, ref SharpFrameSmall.Common.SFCS.clsSWCPN[] SWCPNs) {
            SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest inValue = new SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest();
            inValue.UnitPartNumber = UnitPartNumber;
            inValue.StageCode = StageCode;
            inValue.SWCPNs = SWCPNs;
            SharpFrameSmall.Common.SFCS.GetSWCPNForUPNResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetSWCPNForUPN(inValue);
            SWCPNs = retVal.SWCPNs;
            return retVal.GetSWCPNForUPNResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetSWCPNForUPNResponse> GetSWCPNForUPNAsync(SharpFrameSmall.Common.SFCS.GetSWCPNForUPNRequest request) {
            return base.Channel.GetSWCPNForUPNAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNInfoByMACResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNInfoByMAC(SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest request) {
            return base.Channel.GetUSNInfoByMAC(request);
        }
        
        public string GetUSNInfoByMAC(string MAC, string StageCode, ref string ModelFamily, ref string Model, ref string UnitPartNumber, ref string MO, ref string UnitSerialNumber, ref string[] AllMAC, ref string ImagePartNumber, ref string CheckRouteResult) {
            SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest();
            inValue.MAC = MAC;
            inValue.StageCode = StageCode;
            inValue.ModelFamily = ModelFamily;
            inValue.Model = Model;
            inValue.UnitPartNumber = UnitPartNumber;
            inValue.MO = MO;
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.AllMAC = AllMAC;
            inValue.ImagePartNumber = ImagePartNumber;
            inValue.CheckRouteResult = CheckRouteResult;
            SharpFrameSmall.Common.SFCS.GetUSNInfoByMACResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNInfoByMAC(inValue);
            ModelFamily = retVal.ModelFamily;
            Model = retVal.Model;
            UnitPartNumber = retVal.UnitPartNumber;
            MO = retVal.MO;
            UnitSerialNumber = retVal.UnitSerialNumber;
            AllMAC = retVal.AllMAC;
            ImagePartNumber = retVal.ImagePartNumber;
            CheckRouteResult = retVal.CheckRouteResult;
            return retVal.GetUSNInfoByMACResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNInfoByMACResponse> GetUSNInfoByMACAsync(SharpFrameSmall.Common.SFCS.GetUSNInfoByMACRequest request) {
            return base.Channel.GetUSNInfoByMACAsync(request);
        }
        
        public string UpdateSyncStatus(string SINumber) {
            return base.Channel.UpdateSyncStatus(SINumber);
        }
        
        public System.Threading.Tasks.Task<string> UpdateSyncStatusAsync(string SINumber) {
            return base.Channel.UpdateSyncStatusAsync(SINumber);
        }
        
        public string GetEarliestSIList(string NeedRecordQty, string OverThanDays) {
            return base.Channel.GetEarliestSIList(NeedRecordQty, OverThanDays);
        }
        
        public System.Threading.Tasks.Task<string> GetEarliestSIListAsync(string NeedRecordQty, string OverThanDays) {
            return base.Channel.GetEarliestSIListAsync(NeedRecordQty, OverThanDays);
        }
        
        public string UpdateDeleteSIInfo(string SINumber) {
            return base.Channel.UpdateDeleteSIInfo(SINumber);
        }
        
        public System.Threading.Tasks.Task<string> UpdateDeleteSIInfoAsync(string SINumber) {
            return base.Channel.UpdateDeleteSIInfoAsync(SINumber);
        }
        
        public string GetAvailableGradeList(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetAvailableGradeList(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetAvailableGradeListAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetAvailableGradeListAsync(UnitSerialNumber, StageCode);
        }
        
        public string GetLastGrade(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetLastGrade(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetLastGradeAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.GetLastGradeAsync(UnitSerialNumber, StageCode);
        }
        
        public string CheckSampling(string UnitSerialNumber, string StageCode) {
            return base.Channel.CheckSampling(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> CheckSamplingAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.CheckSamplingAsync(UnitSerialNumber, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetSkuBomDataResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetSkuBomData(SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest request) {
            return base.Channel.GetSkuBomData(request);
        }
        
        public string GetSkuBomData(string SkuPartNumber, string Category, ref SharpFrameSmall.Common.SFCS.clsSkuBomData[] SkuBomData) {
            SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest inValue = new SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest();
            inValue.SkuPartNumber = SkuPartNumber;
            inValue.Category = Category;
            inValue.SkuBomData = SkuBomData;
            SharpFrameSmall.Common.SFCS.GetSkuBomDataResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetSkuBomData(inValue);
            SkuBomData = retVal.SkuBomData;
            return retVal.GetSkuBomDataResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetSkuBomDataResponse> GetSkuBomDataAsync(SharpFrameSmall.Common.SFCS.GetSkuBomDataRequest request) {
            return base.Channel.GetSkuBomDataAsync(request);
        }
        
        public string GetCurrentDBSysdate(string StageCode, string DateTimeFormat) {
            return base.Channel.GetCurrentDBSysdate(StageCode, DateTimeFormat);
        }
        
        public System.Threading.Tasks.Task<string> GetCurrentDBSysdateAsync(string StageCode, string DateTimeFormat) {
            return base.Channel.GetCurrentDBSysdateAsync(StageCode, DateTimeFormat);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetUSNByRIPalletID(SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest request) {
            return base.Channel.GetUSNByRIPalletID(request);
        }
        
        public string GetUSNByRIPalletID(string RIPalletID, string StageCode, ref string UnitSerialNumber) {
            SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest inValue = new SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest();
            inValue.RIPalletID = RIPalletID;
            inValue.StageCode = StageCode;
            inValue.UnitSerialNumber = UnitSerialNumber;
            SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetUSNByRIPalletID(inValue);
            UnitSerialNumber = retVal.UnitSerialNumber;
            return retVal.GetUSNByRIPalletIDResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDResponse> GetUSNByRIPalletIDAsync(SharpFrameSmall.Common.SFCS.GetUSNByRIPalletIDRequest request) {
            return base.Channel.GetUSNByRIPalletIDAsync(request);
        }
        
        public string BreakUpUSNRIPalletByUSN(string UnitSerialNumber, string StageCode) {
            return base.Channel.BreakUpUSNRIPalletByUSN(UnitSerialNumber, StageCode);
        }
        
        public System.Threading.Tasks.Task<string> BreakUpUSNRIPalletByUSNAsync(string UnitSerialNumber, string StageCode) {
            return base.Channel.BreakUpUSNRIPalletByUSNAsync(UnitSerialNumber, StageCode);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetMO53PNItemResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetMO53PNItem(SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest request) {
            return base.Channel.GetMO53PNItem(request);
        }
        
        public string GetMO53PNItem(string UnitSerialNumber, string StageCode, ref string Item53PNDesc) {
            SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest inValue = new SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.Item53PNDesc = Item53PNDesc;
            SharpFrameSmall.Common.SFCS.GetMO53PNItemResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetMO53PNItem(inValue);
            Item53PNDesc = retVal.Item53PNDesc;
            return retVal.GetMO53PNItemResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetMO53PNItemResponse> GetMO53PNItemAsync(SharpFrameSmall.Common.SFCS.GetMO53PNItemRequest request) {
            return base.Channel.GetMO53PNItemAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        SharpFrameSmall.Common.SFCS.GetTEModelNameResponse SharpFrameSmall.Common.SFCS.WebServiceSoap.GetTEModelName(SharpFrameSmall.Common.SFCS.GetTEModelNameRequest request) {
            return base.Channel.GetTEModelName(request);
        }
        
        public string GetTEModelName(string UnitSerialNumber, string StageCode, ref string TEModelName) {
            SharpFrameSmall.Common.SFCS.GetTEModelNameRequest inValue = new SharpFrameSmall.Common.SFCS.GetTEModelNameRequest();
            inValue.UnitSerialNumber = UnitSerialNumber;
            inValue.StageCode = StageCode;
            inValue.TEModelName = TEModelName;
            SharpFrameSmall.Common.SFCS.GetTEModelNameResponse retVal = ((SharpFrameSmall.Common.SFCS.WebServiceSoap)(this)).GetTEModelName(inValue);
            TEModelName = retVal.TEModelName;
            return retVal.GetTEModelNameResult;
        }
        
        public System.Threading.Tasks.Task<SharpFrameSmall.Common.SFCS.GetTEModelNameResponse> GetTEModelNameAsync(SharpFrameSmall.Common.SFCS.GetTEModelNameRequest request) {
            return base.Channel.GetTEModelNameAsync(request);
        }
        
        public string GetMFGTypeByStage(string StageCode) {
            return base.Channel.GetMFGTypeByStage(StageCode);
        }
        
        public System.Threading.Tasks.Task<string> GetMFGTypeByStageAsync(string StageCode) {
            return base.Channel.GetMFGTypeByStageAsync(StageCode);
        }
    }
}
