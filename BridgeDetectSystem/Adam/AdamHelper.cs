using PSW2AdamTeach;
using System;
using System.Collections.Generic;
using System.Threading;
using BridgeDetectSystem.entity;
namespace BridgeDetectSystem.service
{
    public class AdamHelper
    {
        #region  字段

        private List<AdamOperation> list;
        private Timer readTimer;
        private Dictionary<int, Dictionary<int, string>> allDataDic;
        

        public Dictionary<int, Steeve> steeveDic { get; }
        public Dictionary<int, Anchor> anchorDic { get; }
        public Dictionary<int, FrontPivot> frontPivotDic { get; }
        public Dictionary<int, RailWay> railWayDic { get; }

        #endregion

        private static volatile AdamHelper instance = null;

        private AdamHelper(List<AdamOperation> list, int readTimerPeriod)
        {
            this.list = list;
            this.allDataDic = new Dictionary<int, Dictionary<int, string>>();
            this.steeveDic = new Dictionary<int, Steeve>();
            this.anchorDic = new Dictionary<int, Anchor>();
            this.frontPivotDic = new Dictionary<int, FrontPivot>();
            this.railWayDic = new Dictionary<int, RailWay>();

            try
            {
                foreach (AdamOperation oper in list)
                {
                    oper.Init();
                }
            }
            catch (AdamException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            this.readTimer = new Timer(_ =>
            {
                try
                {
                    ReadAllReadableValues();
                }
                catch (Exception ex)
                {
                    readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }, null, 0, readTimerPeriod);
        }

        public static AdamHelper Initialize(List<AdamOperation> list, int readTimerPeriod)
        {
            if (instance != null)
            {
                throw new AdamHelperException("Trying to initialize AdamHelper while its instance already exists.");
            }
            instance = new AdamHelper(list, readTimerPeriod);
            return instance;
        }

        public static AdamHelper GetInstance()
        {
            if (instance == null)
            {
                throw new AdamHelperException("Trying to get AdamHelper instance before initialization.");
            }
            return instance;
        }


        #region 方法
        private static readonly object obj = new object(); //锁对象
        private void ReadAllReadableValues()
        {
            lock (obj)
            {
                foreach (AdamOperation oper in list)
                {
                    allDataDic[oper.id]= oper.Read();
                }

                ConvertToRealValue();
            }
        }

        private void ConvertToRealValue()
        {
            Dictionary<int, string> tempDic;
            string forceData;
            string disData;
            Sensor forceSensor;
            Sensor disSensor;

            for (int i = 0; i < list.Count; i++)
            {
                allDataDic.TryGetValue(list[i].id, out tempDic);

                if (i == 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 60);
                        tempDic.TryGetValue(j, out forceData);
                        forceSensor.readValue = double.Parse(forceData);

                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 30);
                        tempDic.TryGetValue(j + 4, out disData);
                        disSensor.readValue = double.Parse(disData);

                        Steeve steeve = new Steeve(j, forceSensor, disSensor);
                        steeveDic[steeve.id] = steeve; 
                    }
                }
                else if (i == 1)
                {
                    int j = 0;
                    int count = 0;
                    for (j = 0; j < 4; j++)
                    {
                        forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 60);
                        tempDic.TryGetValue(j, out forceData);
                        forceSensor.readValue = double.Parse(forceData);

                        Anchor anchor = new Anchor(j, forceSensor);
                        anchorDic[anchor.id] = anchor;
                    }
                    for (j = 4; j < 6; j++)
                    {
                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 5);
                        tempDic.TryGetValue(j, out disData);
                        disSensor.readValue = double.Parse(disData);

                        FrontPivot pivot = new FrontPivot(count++, disSensor);
                        frontPivotDic[pivot.id] = pivot;
                    }
                    count = 0;
                    if (j == 6)
                    {
                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 30);
                        tempDic.TryGetValue(j, out disData);
                        disSensor.readValue = double.Parse(disData);

                        RailWay railway = new RailWay(count++, disSensor);
                        railWayDic[railway.id] = railway;
                    }
                }
            }
        }


        #endregion

        public class AdamHelperException : AdamException
        {
            public AdamHelperException(string message) : base(message) { }
            public AdamHelperException(string message, Exception innerException) : base(message, innerException) { }
        }


    }


}
