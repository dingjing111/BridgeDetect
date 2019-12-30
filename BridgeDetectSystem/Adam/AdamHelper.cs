using BridgeDetectSystem.service;
using System;
using System.Collections.Generic;
using System.Threading;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.util;
using System.Data;

namespace BridgeDetectSystem.adam
{
    public class AdamHelper
    {
        #region  字段
        public DBHelper dbhelper;
        private List<AdamOperation> adamList;
        private Dictionary<int, Dictionary<int, string>> allDataDic;

        public volatile bool hasData;
        public System.Threading.Timer readTimer { get; set; }
        //吊杆力和位移
        public Dictionary<int, Steeve> steeveDic { get; }
        public Dictionary<int, Steeve> steeveCopy { get; set; }
        //锚杆力
        public Dictionary<int, Anchor> anchorDic { get; set; }
        //前支点位移
        public Dictionary<int, FrontPivot> frontPivotDic { get; }

        //吊杆基准点
        public List<double> standardlist { get; set; }//四个基准点

        public double steeveDisStandard { get; set; }
        //前支架基准点
        public double first_frontPivotDisStandard { get; set; }
        public double second_frontPivotDisStandard { get; set; }
        public double three_standard { get; set; }
        public double four_standard { get; set; }
        public double steevedisdifflimit;
        #endregion

        #region 单例
        private static volatile AdamHelper instance = null;
        private AdamHelper(List<AdamOperation> list)
        {
            this.dbhelper = DBHelper.GetInstance();
            this.adamList = list;
            this.allDataDic = new Dictionary<int, Dictionary<int, string>>();
            this.steeveDic = new Dictionary<int, Steeve>();
            this.anchorDic = new Dictionary<int, Anchor>();
            this.frontPivotDic = new Dictionary<int, FrontPivot>();
            this.standardlist = new List<double>();
            this.hasData = false;
            try
            {
                //初始化每个研华模块
                foreach (AdamOperation oper in list)
                {
                    oper.Init();
                }
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
                    hasData = false;
                    //throw ex;
                    System.Windows.Forms.MessageBox.Show("研华模块掉线，请检查硬件连接，确保连接完全正确，重新启动软件");
                }
            }, null, Timeout.Infinite, Timeout.Infinite);
        }


        public static AdamHelper Initialize(List<AdamOperation> list)
        {
            if (instance != null)
            {
                throw new AdamHelperException("AdamHelper数据接收模块重复初始化报错");
            }
            instance = new AdamHelper(list);//
            return instance;
        }

        public static AdamHelper GetInstance()
        {
            if (instance == null)
            {
                throw new AdamHelperException("AdamHelper数据接收模块未初始化，实例不存在报错！");
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
                    allDataDic[oper.id] = oper.Read();//读取所有电流值
                    
                }

                ConvertToRealValue();
                hasData = true;
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
                    ////读取模块192.168.1.3数据，吊杆位移0，1，2，3与吊杆力4，5，6，7通道                  
                    //若更换 ？。；j=0 标号 17080383 空载 4.026mA 
                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(4, out forceData);
                    forceSensor.readValue = double.Parse(forceData);
                    disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);
                    tempDic.TryGetValue(0, out disData);
                    disSensor.readValue = double.Parse(disData);
                    Steeve steeve0 = new Steeve(0, forceSensor, disSensor);
                    steeveDic[steeve0.id] = steeve0;
                    //j=1标号17110130空载3.992mA
                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(5, out forceData);
                    forceSensor.readValue = double.Parse(forceData);
                    disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);
                    tempDic.TryGetValue(1, out disData);
                    disSensor.readValue = double.Parse(disData);
                    Steeve steeve1 = new Steeve(1, forceSensor, disSensor);
                    steeveDic[steeve1.id] = steeve1;
                    //j=2 17080285 空载 4.012mA
                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(6, out forceData);
                    forceSensor.readValue = double.Parse(forceData);
                    disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);
                    tempDic.TryGetValue(2, out disData);
                    disSensor.readValue = double.Parse(disData);
                    Steeve steeve2 = new Steeve(2, forceSensor, disSensor);
                    steeveDic[steeve2.id] = steeve2;
                    //j=3 17080386 空载4.014mA
                    forceSensor = new Sensor(SensorType.forceSensor, 3.96, 20, 300, 1, 0);
                    tempDic.TryGetValue(7, out forceData);
                    forceSensor.readValue = double.Parse(forceData);
                    disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);
                    tempDic.TryGetValue(3, out disData);
                    disSensor.readValue = double.Parse(disData);
                    Steeve steeve3 = new Steeve(3, forceSensor, disSensor);
                    steeveDic[steeve3.id] = steeve3;

                }


                else if (i == 1)
                {
                    int j = 0;
                    // int count = 0;

                    for (j = 0; j < 3; j++)//前支架位移电流
                    {
                        disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000,0);
                        tempDic.TryGetValue(j, out disData);
                        disSensor.readValue = double.Parse(disData);
                        FrontPivot pivot = new FrontPivot(j, disSensor);
                        frontPivotDic[pivot.id] = pivot;
                    }
                    disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000, 0);
                    tempDic.TryGetValue(3, out disData);
                    disSensor.readValue = double.Parse(disData);
                    FrontPivot pivot1 = new FrontPivot(3, disSensor);
                    frontPivotDic[pivot1.id] = pivot1;

                    #region 锚杆力，接收但不显示，不保存，不后台报警
                    //  for (j = 4; j < 8; j++)//锚杆力

                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(4, out forceData);
                    forceSensor.readValue = double.Parse(forceData);

                    Anchor anchor0 = new Anchor(0, forceSensor);
                    anchorDic[anchor0.id] = anchor0;

                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(5, out forceData);
                    forceSensor.readValue = double.Parse(forceData);

                    Anchor anchor1 = new Anchor(1, forceSensor);
                    anchorDic[anchor1.id] = anchor1;

                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(6, out forceData);
                    forceSensor.readValue = double.Parse(forceData);
                    Anchor anchor2 = new Anchor(2, forceSensor);
                    anchorDic[anchor2.id] = anchor2;

                    forceSensor = new Sensor(SensorType.forceSensor, 4, 20, 300, 1, 0);
                    tempDic.TryGetValue(7, out forceData);
                    forceSensor.readValue = double.Parse(forceData);

                    Anchor anchor3 = new Anchor(3, forceSensor);
                    anchorDic[anchor3.id] = anchor3;
                    #endregion                
                }
            }
        }

        /// <summary>
        /// 若表为空，则第一次读基准存入数据库，否则从吊杆位移基准数据表中读取基准，赋予standardlist。
        /// </summary>
        public void ReadStandardValue()
        {
            // List<double> disList = new List<double>();
            standardlist = new List<double>();
            string sql = "select * from SteeveStandard";
            try
            {
                if (OperateSql.IsTableNull(sql))
                {


                    Sensor sensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);

                    for (int i = 0; i < 4; i++)
                    {
                        sensor.readValue = double.Parse(adamList[0].Read(i));//???位移加+4？？
                        standardlist.Add(sensor.GetRealValue());  //每个吊杆的基准值
                        //disList.Add(sensor.GetRealValue());
                    }
                    string sqlstr = string.Format("insert into SteeveStandard values({0},{1},{2},{3})", standardlist[0], standardlist[1], standardlist[2], standardlist[3]);
                    int r = dbhelper.ExecuteNonQuery(sqlstr);//空表插入基准值
                }
                else
                {   //否则读取数据库中基准值

                    DataTable dt = OperateSql.ReadStandard(sql);
                    for (int i = 0; i < 4; i++)
                    {
                        standardlist.Add(double.Parse(dt.Rows[0][i].ToString()));

                    }


                }

            }
            catch (Exception e)
            {
                throw e;
            }


            double sum = 0;
            foreach (double val in standardlist)
            {
                sum += val;
            }

            //平均值作基准值
            steeveDisStandard = Math.Round(sum / 4, 3);



        }
        /// <summary>
        /// 读前支点位移基准。。拉绳式传感器。1.2m量程。
        /// </summary>
        public void ReadFrontStandard()
        {
            //前支点基准值
            string sql = "select * from FrontStandard";
            try
            {
                if (OperateSql.IsTableNull(sql))
                {
                    Sensor sensor1 = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000, 0);
                    sensor1.readValue = double.Parse(adamList[1].Read(0));
                    first_frontPivotDisStandard = sensor1.GetRealValue();

                    Sensor sensor2 = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000, 0);
                    sensor2.readValue = double.Parse(adamList[1].Read(1));
                    second_frontPivotDisStandard = sensor2.GetRealValue();

                    Sensor sensor3 = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000, 0);
                    sensor3.readValue = double.Parse(adamList[1].Read(2));
                    three_standard = sensor3.GetRealValue();

                    Sensor sensor4 = new Sensor(SensorType.displaceSensor, 4, 20, 1.2, 1000, 0);
                    sensor4.readValue = double.Parse(adamList[1].Read(3));
                    four_standard = sensor4.GetRealValue();
                    string sqlstr = string.Format("insert into FrontStandard values({0},{1},{2},{3})", first_frontPivotDisStandard, second_frontPivotDisStandard, three_standard, four_standard);
                    int r = dbhelper.ExecuteNonQuery(sqlstr);//空表插入基准值
                }
                else
                {
                    DataTable dt = OperateSql.ReadStandard(sql);
                    first_frontPivotDisStandard = double.Parse(dt.Rows[0][0].ToString());
                    second_frontPivotDisStandard = double.Parse(dt.Rows[0][1].ToString());
                    three_standard = double.Parse(dt.Rows[0][2].ToString());
                    four_standard = double.Parse(dt.Rows[0][3].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 取消后台数据接收线程
        /// </summary>
        public void StopTimer()
        {
            readTimer.Change(Timeout.Infinite, Timeout.Infinite);
            hasData = false;
        }
        /// <summary>
        /// 开始后台接收数据线程
        /// </summary>
        /// <param name="period"></param>
        public void StartTimer(int period)
        {
            //读取初始的值一次，并记录在字段steeveDisStandard、frontPivotDisStandard中
            //之后作为报警的基准

            ReadStandardValue();
            ReadFrontStandard();
            readTimer.Change(0, period);//读数据
        }


        #endregion
    }
    public class AdamHelperException : AdamException
    {
        public AdamHelperException(string message) : base(message) { }
        public AdamHelperException(string message, Exception innerException) : base(message, innerException) { }
    }


}
