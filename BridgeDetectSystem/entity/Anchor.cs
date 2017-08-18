using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    public class Anchor
    {
        public int id { get; set; }
        private double force;
        private Sensor forceSensor;

        public Anchor(int id, Sensor forceSensor)
        {
            this.id = id;
            this.forceSensor = forceSensor;
        }

        public double GetForce()
        {
            if (forceSensor == null)
            {
                throw new Exception("没有实例化Anchor力传感器！");
            }
            force = forceSensor.GetRealValue();
            return force;
        }
    }
}
