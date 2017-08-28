using BridgeDetectSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BridgeDetectSystem.adam
{
  public  class AdamHelper2
    {
        #region 字段
        private AdamOperation oper;
        public Timer readTimer { get; set; }
        //public Dictionary<int, RailWay> railWayDic;
        public string value;
        #endregion
        #region 单例
        private static volatile AdamHelper2 instance = null;
        private AdamHelper2(AdamOperation oper)
        {
            this.oper = oper;
            //this.railWayDic = new Dictionary<int, RailWay>();
            try
            {   //初始化每个研华模块
                   oper.Init();
            }
            catch (AdamException ex)
            {
                throw ex;
            }
            ReadRailWay();

         }
       
        /// <summary>
        /// 模块帮手2初始化
        /// </summary>
        /// <param name="oper">模块</param>
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
                throw new AdamHelperException2("Trying to get AdamHelper2 instance before initialization.");
            }
            return instance;
        }
        #endregion
        #region 方法
        public void ReadRailWay()
        {
            //后台每隔一段时间读取一次数据
            this.readTimer = new Timer(_ =>
            {
                try
                {
                    ReadRailWayValues();
                }
                catch (Exception ex)
                {
                    readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    throw ex;
                }
            }, null, Timeout.Infinite, Timeout.Infinite);
        }
       
        private static readonly object obj = new object(); //锁对象
        /// <summary>
        /// 读特定通道数据--第七个通道，编号6，行走时主桁同步性
        /// </summary>
        private void ReadRailWayValues()
        {
            lock (obj)
            {
               value = oper.Read(6);         //读第7个通道的值
               ConvertToRealValue();
            }
        }
        private void ConvertToRealValue()
        {
            //转成实际值
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
    }
    #endregion
    public class AdamHelperException2 : AdamException
    {
        public AdamHelperException2(string message) : base(message) { }
        public AdamHelperException2(string message, Exception innerException) : base(message, innerException) { }
    }
}
