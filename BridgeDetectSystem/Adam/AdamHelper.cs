using BridgeDetectSystem.service;
using System;
using System.Collections.Generic;
using System.Threading;
using BridgeDetectSystem.entity;

namespace BridgeDetectSystem.adam
{
    public class AdamHelper
    {
        #region  字段

        private List<AdamOperation> adamList;
        private Dictionary<int, Dictionary<int, string>> allDataDic;


        public Timer readTimer { get; set; }
        public Dictionary<int, Steeve> steeveDic { get; }
        public Dictionary<int, Anchor> anchorDic { get; }
        public Dictionary<int, FrontPivot> frontPivotDic { get; }
       // public Dictionary<int, RailWay> railWayDic { get; }

        public double steeveDisStandard { get; set; }
        public double first_frontPivotDisStandard { get; set; }
        public double second_frontPivotDisStandard { get; set; }
        #endregion

        #region 单例
        private static volatile AdamHelper instance = null;

        private AdamHelper(List<AdamOperation> list)
        {
            this.adamList = list;
            this.allDataDic = new Dictionary<int, Dictionary<int, string>>();
            this.steeveDic = new Dictionary<int, Steeve>();
            this.anchorDic = new Dictionary<int, Anchor>();
            this.frontPivotDic = new Dictionary<int, FrontPivot>();
          //  this.railWayDic = new Dictionary<int, RailWay>();

            try
            {
                //初始化每个研华模块
                foreach (AdamOperation oper in list)
                {
                    oper.Init();
                }

                //读取初始的值一次，并记录在字段steeveDisStandard、frontPivotDisStandard中
                //之后作为报警的基准
                ReadStandardValue();
            }
            catch (AdamException ex)
            {
                throw ex;
            }

            //后台每隔一段时间读取一次数据
            this.readTimer = new Timer(_ =>
            {
                try
                {
                    ReadAllReadableValues();
                }
                catch (Exception ex)
                {
                    readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    throw ex;
                }
            }, null, Timeout.Infinite,Timeout.Infinite);
        }


        public static AdamHelper Initialize(List<AdamOperation> list, int readTimerPeriod)
        {
            if (instance != null)
            {
                throw new AdamHelperException("Trying to initialize AdamHelper while its instance already exists.");
            }
            instance = new AdamHelper(list);//
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

        #endregion

        #region 方法
        private static readonly object obj = new object(); //锁对象
        private void ReadAllReadableValues()
        {
            lock (obj)
            {
                foreach (AdamOperation oper in adamList)
                {
                    allDataDic[oper.id] = oper.Read();
                }

                ConvertToRealValue();
            }
        }

        /// <summary>
        /// 增加模块，只需要改变这个方法中的算法就行了。
        /// </summary>
        private void ConvertToRealValue()
        {
            Dictionary<int, string> tempDic;
            string forceData;
            string disData;
            Sensor forceSensor;
            Sensor disSensor;

            for (int i = 0; i < adamList.Count; i++)
            {
                allDataDic.TryGetValue(adamList[i].id, out tempDic);

                if (i == 0)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        forceSensor = new Sensor(SensorType.forceSensor, 3.987, 20, 60, 10);
                        tempDic.TryGetValue(j, out forceData);
                        forceSensor.readValue = double.Parse(forceData);

                        disSensor = new Sensor(SensorType.displaceSensor, 4.035, 20,70, 100);
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
                        forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 60, 10);
                        tempDic.TryGetValue(j, out forceData);
                        forceSensor.readValue = double.Parse(forceData);

                        Anchor anchor = new Anchor(j, forceSensor);
                        anchorDic[anchor.id] = anchor;
                    }
                    for (j = 4; j < 6; j++)
                    {
                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 5, 100);
                        tempDic.TryGetValue(j, out disData);
                        disSensor.readValue = double.Parse(disData);

                        FrontPivot pivot = new FrontPivot(count++, disSensor);
                        frontPivotDic[pivot.id] = pivot;
                    }
                    count = 0;
                    if (j == 6)
                    {
                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 30, 100);
                        tempDic.TryGetValue(j, out disData);
                        disSensor.readValue = double.Parse(disData);

                        RailWay railway = new RailWay(count++, disSensor);
                        //railWayDic[railway.id] = railway;
                    }
                }
            }
        }

        /// <summary>
        /// 读取初始数值作为基准，只读一次
        /// </summary>
        private void ReadStandardValue()
        {
            List<double> disList = new List<double>();
            Sensor sensor = new Sensor(SensorType.displaceSensor, 4, 20, 70, 100);

            for (int i = 0; i < 4; i++)
            {
                sensor.readValue = double.Parse(adamList[0].Read(i));
                   
                disList.Add(sensor.GetRealValue());
            }

            double sum = 0;
            foreach (double val in disList)
            {
                sum += val;
            }
            steeveDisStandard = Math.Round(sum / 4, 3);

            //first_frontPivotDisStandard = Math.Round(double.Parse(adamList[1].Read(4)));
            //second_frontPivotDisStandard = Math.Round(double.Parse(adamList[1].Read(5)));
        }

        /// <summary>
        /// 取消后台接收线程
        /// </summary>
        public void InfiniteTimer()
        {
            readTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
        /// <summary>
        /// 开始后台接收数据线程
        /// </summary>
        /// <param name="period"></param>
        public void StartTimer(int period)
        {
            readTimer.Change(0, period);
        }

        #endregion
    }
    public class AdamHelperException : AdamException
    {
        public AdamHelperException(string message) : base(message) { }
        public AdamHelperException(string message, Exception innerException) : base(message, innerException) { }
    }


}
