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

        public double readData { get; }
        public Timer readTimer { get; set; }
        #endregion

        #region 单例
        private static volatile AdamHelper2 instance = null;
        private AdamHelper2(AdamOperation oper)
        {
            this.oper = oper;
            //try
            //{   //初始化研华模块
            //    oper.Init();
            //}
            //catch (AdamException ex)
            //{
            //    throw ex;
            //}
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
                throw new AdamHelperException("Trying to initialize AdamHelper2 while its instance already exists.");
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
                throw new AdamHelperException("Trying to get AdamHelper2 instance before initialization.");
            }
            return instance;
        }
        #endregion

        #region 方法
        private static readonly object obj = new object(); //锁对象
        public void ReadRailWay()
        {
            try
            {
                lock (obj)
                {
                    value = oper.Read(6);         //读第7个通道的值

                    ConvertToRealValue();
                }
            }
            catch (Exception ex)
            {
                readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                throw ex;
            }
        }

        private void ConvertToRealValue()
        {
            //转成实际值

            //readData=??
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
}
