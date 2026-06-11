using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    public class LogsProductJson
    {
        public string data_type { get; set; } = "PCS";// 資料類型，STATUS/PCS
        public string timestamp { get; set; } = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();// 資料上拋時間，13位時間戳記
        public Data data { get; set; } = new Data(); // 資料json物件
    }

    public class Data
    {
        /// <summary>
        /// 設備基礎信息-廠區
        /// </summary>
        public string SITE_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-廠別
        /// </summary>
        public string PLANT_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-車間
        /// </summary>
        public string WORKSHOP { get; set; }
        /// <summary>
        /// 設備基礎信息-線別
        /// </summary>
        public string LINE_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-工站
        /// </summary>
        public string STATION_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-設備名稱
        /// </summary>
        public string MACHINE_NAME { get; set; }
        /// <summary>
        /// 設備基礎信息-設備編號
        /// </summary>
        public string MACHINE_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-設備財編
        /// </summary>
        public string EQUIPMENT_ID { get; set; }
        /// <summary>
        /// 設備基礎資訊-IP位址
        /// </summary>
        public string IP_ADDRESS { get; set; }
        /// <summary>
        /// 設備基礎信息-品牌
        /// </summary>
        public string BRAND { get; set; }
        /// <summary>
        /// 設備基礎信息-型號
        /// </summary>
        public string MODEL { get; set; }
        /// <summary>
        /// 設備基礎信息-机种
        /// </summary>
        public string MODEL_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-程序名稱
        /// </summary>
        public string PROGRAM_ID { get; set; }
        /// <summary>
        /// 設備基礎信息-机台类型
        /// </summary>
        public string MACHINE_TYPE { get; set; }
        /// <summary>
        /// 產品信息-USN
        /// </summary>
        public string USN_ID { get; set; }
        /// <summary>
        /// 產品信息-載具 sn
        /// </summary>
        public string VEHICLE_ID { get; set; }

        /// <summary>
        /// 產品資訊-作業CT---預設秒，不加單位
        /// </summary>
        public string CT_OPERATION { get; set; }

        /// <summary>
        /// 產品資訊-等待CT---預設秒，不加單位
        /// </summary>
        public string CT_WAITING { get; set; }

        /// <summary>
        /// 產品資訊-總CT 作業ct+等待ct---預設秒，不加單位
        /// </summary>
        public string CT_TOTAL { get; set; }
        /// <summary>
        /// 进出板CT
        /// </summary>
        public string CT_IN_OUT { get; set; }

        /// <summary>
        /// 產品信息-產品結果---0/1,0是OK，1是NG
        /// </summary>
        public string RESULT { get; set; }

        /// <summary>
        ///  產品資訊-點位元---L1,L2 代表點位元，X/Y/Z/RX/RY/RZ要按順序給sample：{"L1":[X,Y,Z,RX,RY,RZ],"L2":[X,Y,Z,RX,RY,RZ]}
        /// </summary>
        public Dictionary<string, List<string>> WAYPOINTS { get; set; } = new Dictionary<string, List<string>>();// 點位元，按順序給 [ ]
        /// <summary>
        /// 產品報警-報警描述---{"Fail_Check_route": "0", "Fail_Vision_dimension": "0", "Fail_Fasten": "0", ...}，0正常，1報警
        /// </summary>
        public ProductError PRODUCT_ERROR { get; set; } = new ProductError();

        /// <summary>
        /// 產品參數-扭力---L1,L2 第幾顆螺絲，[目標值，實際值]
        /// </summary>
        public Dictionary<string, List<string>> TORQUE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-設定圈數---L1,L2 第幾顆螺絲，[目標值，實際值]
        /// </summary>
        public Dictionary<string, List<string>> LAPS { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        ///  產品參數-壓力---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> PRESSURE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-重量---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> WEIGHT { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-體積---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> VOLUME { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-面積---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> SQUARE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-距離---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> DISTANCE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-角度---類比上面鎖螺絲格式，同理
        /// </summary>
        public Dictionary<string, List<string>> ANGLE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        /// 產品參數-圖片---IP/路徑/圖片名字
        /// </summary>
        public Dictionary<string, List<string>> PICTURE { get; set; } = new Dictionary<string, List<string>>();

        /// <summary>
        ///  資料生成時間戳--- "1234567890123"
        /// </summary>
        public string UTIME { get; set; }
    }

    /// <summary>
    /// 產品報警-報警描述
    /// </summary>
    public class ProductError
    {
        public string Fail_Check_route { get; set; } = string.Empty;
        public string Fail_Vision_dimension { get; set; } = string.Empty;
        public string Fail_Fasten { get; set; } = string.Empty;
        public string Fail_Paste { get; set; } = string.Empty;
        public string Fail_Assembly { get; set; } = string.Empty;
        public string Fail_Force { get; set; } = string.Empty;
        public string Fail_Square_Volume_Weight { get; set; } = string.Empty;
        public string Fail_Pick_mark { get; set; } = string.Empty;
        public string Fail_Dispensing_glue { get; set; } = string.Empty;
        public string Fail_Film_tearing { get; set; } = string.Empty;
    }

    public static class ProductParamConverter
    {
        /// <summary>
        /// L1, L2自动配对 Dictionary(L1, L2, L3...) 格式
        /// </summary>
        public static Dictionary<string, List<string>> ConvertToDictionary(
            List<string> list1, List<string> list2)
        {
            if (list1 == null || list2 == null)
                throw new ArgumentNullException("list1 或 list2 不能为空");
            var result = new Dictionary<string, List<string>>();
            int pairCount = Math.Min(list1.Count, list2.Count);

            for (int i = 0; i < pairCount; i++)
            {
                string key = $"L{i + 1}";
                result[key] = new List<string> { list1[i], list2[i] };
            }
            return result;
        }
    }
}
