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
        private List<AdamOperation> adamList;
        public Timer readTimer { get; set; }
        //public Dictionary<int, RailWay> railWayDic;
        public string value;
        #endregion
        #region 单例
        private static volatile AdamHelper2 instance = null;
        private AdamHelper2(List<AdamOperation> list)
        {
            this.adamList = list;
            //this.railWayDic = new Dictionary<int, RailWay>();
            try
            {   //初始化每个研华模块
                foreach (AdamOperation oper in list)
                {
                    oper.Init();
                }                              
            }
            catch (AdamException ex)
            {
                throw ex;
            }
            ReadRailWay();

         }
        #endregion
        /// <summary>
        /// 模块帮手2初始化，调用构造函数
        /// </summary>
        /// <param name="list">模块集合</param>
        /// <param name="readTimerPeriod"></param>
        /// <returns></returns>
        public static AdamHelper2 Initialize(List<AdamOperation> list, int readTimerPeriod)
        {
            if (instance != null)
            {
                throw new AdamHelperException("Trying to initialize AdamHelper while its instance already exists.");
            }
            instance = new AdamHelper2(list);
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
                throw new AdamHelperException2("Trying to get AdamHelper instance before initialization.");
            }
            return instance;
        }

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
                foreach (AdamOperation oper in adamList)
                {
                    value = oper.Read(6);         //读第7个通道的值
                }

                ConvertToRealValue();
            }
        }

        private void ConvertToRealValue()
        {
            //转成实际值
        }
    }
  public class AdamHelperException2 : AdamException
    {
        public AdamHelperException2(string message) : base(message) { }
        public AdamHelperException2(string message, Exception innerException) : base(message, innerException) { }
    }
}
