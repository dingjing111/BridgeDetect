using BridgeDetectSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BridgeDetectSystem.adam
{
    public class AdamHelper2
    {
        #region 字段
        private AdamOperation oper;
        private string value;

        public volatile bool hasData;
        public double readData { get; }
        public Timer readTimer { get; set; }
        public FrontPivot f { get; set; }
        public double v { get; set; }
        #endregion

        #region 单例
        private static volatile AdamHelper2 instance = null;
        private AdamHelper2(AdamOperation oper)
        {
            hasData = false;
            this.oper = oper;
            this.v = 0;
            readTimer = new Timer(_ =>
            {
                ReadRailWay();
            }, null, Timeout.Infinite, Timeout.Infinite);

        }

        /// <summary>
        /// 模块帮手2初始化，调用构造函数
        /// </summary>
        /// <param name="list">模块集合</param>
        /// <param name="readTimerPeriod"></param>
        /// <returns></returns>
        public static AdamHelper2 Initialize(AdamOperation oper)
        {
            if (instance != null)
            {
                throw new AdamHelperException("AdamHelper2数据接收模块重复初始化报错！");
            }
            instance = new AdamHelper2(oper);
            return instance;
        }

        /// <summary>
        /// 定义公有方法，提供一个全局访问点
        /// </summary>
        /// <returns></returns>
        public static AdamHelper2 GetInstance()
        {
            if (instance == null)
            {
                throw new AdamHelperException("AdamHelper2数据接收模块未初始化，实例不存在报错！");
            }
            return instance;
        }
        #endregion

        #region 方法
        private static readonly object obj = new object(); //锁对象


        private void ReadRailWay()
        {
            try
            {
                lock (obj)
                {
                    value = oper.Read(4);//需要改变
                    //读模块2第5个通道的值
                    double x = double.Parse(value);
                    ConvertToRealValue(x);

                    hasData = true;
                }
            }
            catch (Exception ex)
            {
                readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                hasData = false;
                System.Windows.Forms.MessageBox.Show("adamHelper2中数据读取失败！请检查线路" + ex.Message);
            }
        }

        private void ConvertToRealValue(double x)
        {


            //string disData;
            //位移传感器
            Sensor disSensor;
            disSensor = new Sensor(SensorType.displaceSensor, 4, 20, 29.8, 100, 20);

            disSensor.readValue = x;
            f = new FrontPivot(4, disSensor);
            v = f.GetDisplace();
            v = Math.Round(v, 1);
            //转成实际值


        }

        /// <summary>
        /// 取消后台接收线程
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
            readTimer.Change(0, period);
        }

        #endregion
    }
}
