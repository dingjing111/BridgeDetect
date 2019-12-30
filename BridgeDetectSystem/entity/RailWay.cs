using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    public class RailWay
    {
        public int id;
        private double displace;
        private Sensor disSensor;

        public RailWay(int id, Sensor disSensor)
        {
            this.id = id;
            this.disSensor = disSensor;
        }
        public double GetDisplace()
        {
            if (disSensor == null)
            {
                throw new Exception("没有实例化" + "RailWay" + "位移传感器！");
            }
            displace = disSensor.GetRealValue();
            return displace;
        }
    }
}
