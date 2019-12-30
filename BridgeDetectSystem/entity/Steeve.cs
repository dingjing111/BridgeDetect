                                                                                                                                                                                                                                                                                                                                                                 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    public class Steeve
    {
        public  int id; //吊杆编号：0,1,2,3
        private double force; //吊杆力 ：KN
        private double displace; //位移：cm;
        private Sensor disSensor;
        private Sensor forceSensor;

        public Steeve(int id,Sensor forceSensor, Sensor disSensor)
        {
            this.id = id;
            this.disSensor = disSensor;
            this.forceSensor = forceSensor;
        }

        public double GetForce()         
        {
            if (forceSensor == null)
            {
                throw new Exception("没有实例化Steeve力传感器！");
            }
            force = forceSensor.GetRealValue();
            return force;
        }

        public double GetDisplace()
        {
            if (disSensor == null)
            {
                throw new Exception("没有实例化Steeve位移传感器！");
            }
            displace = disSensor.GetRealValue();
            return displace;
        }

    }
}
