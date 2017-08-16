using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    public class Sensor
    {
        public SensorType kind { get; } //传感器种类
        private int outputStart; //输出信号下限
        private int outputEnd; //输出信号上限
        private int range; //传感器量程

        private double _readValue;

        public double readValue
        {
            //get
            //{
            //    return _readValue;
            //}
            //set
            //{
            //    if (value < outputStart || value > outputEnd)
            //    {
            //        throw new SensorException("传感器读取的数据有误！");
            //    }
            //    _readValue = value;
            //}
            get;set;
        }

        public Sensor(SensorType kind, int outputStart, int outputEnd, int range)
        {
            this.kind = kind;
            this.outputStart = outputStart;
            this.outputEnd = outputEnd;
            this.range = range;
            this._readValue = outputStart;
        }

        /// <summary>
        /// 将传感器的值，转换为实际的值
        /// </summary>
        /// <returns></returns>
        public double GetRealValue()
        {
            return range * (readValue - 4) / (outputEnd - outputStart);
        }
   
    }

    public enum SensorType
    {
        forceSensor,
        displaceSensor,
    }

    class SensorException : Exception
    {
        public SensorException(string message) : base(message) { }
        public SensorException(string message, Exception innerException) : base(message, innerException) { }
    }
}
