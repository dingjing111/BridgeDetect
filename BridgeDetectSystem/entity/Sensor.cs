using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    public class Sensor
    {
        private int b;//截距
        public SensorType kind { get; } //传感器种类
        private double outputStart; //输出信号下限。。。指电流下限。4mA
        private double outputEnd; //输出信号上限。。。指电流上限.20mA
        private double range; //传感器量程，位移或力量程
        private double coefficient;// 单位转换，需要乘的系数
        private double _readValue; //读取到的实时数据，需要转换为实际值
        private int digits; //小数点后保留几位
        public double readValue
        {
            get;set;
        }

        public Sensor(SensorType kind, double outputStart, double outputEnd, double range,double coefficient,int y,int digits=3)
        {
            this.kind = kind;
            this.outputStart = outputStart;
            this.outputEnd = outputEnd;
            this.range = range;
            this.coefficient = coefficient;
            this._readValue = outputStart;
            this.digits = digits;
            this.b = y;
        }

        /// <summary>
        /// 将传感器的电流值，转换为实际的值
        /// </summary>
        /// <returns></returns>
        public double GetRealValue()
        {
            double val= Math.Round(range * (readValue - outputStart) *coefficient/ (outputEnd - outputStart)+b,digits);
            if (val < 0)
                return 0;
            return val;
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
