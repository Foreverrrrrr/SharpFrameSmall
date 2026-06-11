using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpFrameSmall.LogsFolder
{
    /// <summary>
    /// 批头结构体
    /// </summary>
    public class ScrewdriverJson
    {
        /// <summary>
        /// 产品参数-扭力 [L1=目标值,L2实际值]
        /// </summary>
        public Torque TORQUE { get; set; } = new Torque();

        /// <summary>
        /// 产品参数-设定圈数
        /// </summary>
        public Laps LAPS { get; set; } = new Laps();

        /// <summary>
        /// 产品参数-压力 
        /// </summary>
        public Pressure PRESSURE { get; set; } = new Pressure();

        /// <summary>
        /// 产品参数-重量
        /// </summary>
        public Weight WEIGHT { get; set; } = new Weight();

        /// <summary>
        /// 产品参数-体积
        /// </summary>
        public Volume VOLUME { get; set; } = new Volume();

        /// <summary>
        /// 产品参数-面积
        /// </summary>
        public Square SQUARE { get; set; } = new Square();

        /// <summary>
        /// 产品参数-距离
        /// </summary>
        public Distance DISTANCE { get; set; } = new Distance();

        /// <summary>
        /// 产品参数-角度
        /// </summary>
        public Angle ANGLE { get; set; } = new Angle();
    }

    // 产品参数-扭力
    public class Torque
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-设定圈数
    public class Laps
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-压力
    public class Pressure
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-重量
    public class Weight
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-体积
    public class Volume
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-面积
    public class Square
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-距离
    public class Distance
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }

    // 产品参数-角度
    public class Angle
    {
        public List<string> L1 { get; set; } = new List<string>();
        public List<string> L2 { get; set; } = new List<string>();
    }
}
