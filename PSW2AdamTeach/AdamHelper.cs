using System;
using Advantech.Adam;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace PSW2AdamTeach
{
    /*******************************************************************************
     * @Author : PSW
     * @Date : 2017/7/2
     * @Remark: 封装研华官网下载的类库，方便之后调用
     * 
     * 构造函数：Adamteach();
     * 方法:# Initalize(); //初始化参数
     *      # Connect(); //建立连接
     *      # Disconnect(); //关闭连接
     *      # GetChannelRange(); //得到端口的输入数字范围
     *      # GetChannelEnabled(); //得到有效的端口
     *      # GetSingleChannel(); //得到单个端口的值
     *      # GetAllChannel(); //得到所有端口的值
     *      # SetTimeOut(); //设置通信超时时间
     *      
     *  读取数据过程如下：   
     *  Initalize-->Connect-->GetChannelRange-->GetChannelEnabled-->GetAllChannelValue
     *  
     *  封装初始化等过程(Initalize-->Connect-->GetChannelRange-->GetChannelEnabled)-->Init();
     *  封装读取全部通道数据过程：（GetAllChannelValue）-->Read()
     *  封装读取特定通道的数据：（GetChannelSingleValue）-->Read(int channelIndex)
     *  
     *  使用：(1) new AdamHelper (2)Init() (3)Read()/Read(int channelIndex) (4)Disconnect()
     *******************************************************************************/

    public class AdamHelper
    {
        #region  字段

        List<AdamOperation> list;
        Timer readTimer;

        #endregion

        private static volatile AdamHelper instance = null;

        private AdamHelper(List<AdamOperation> list, int readTimerPeriod)
        {
            this.list = list;
            foreach (AdamOperation oper in list)
            {
                oper.Init();
            }
            this.readTimer = new Timer(_ =>
            {
                try
                {
                    ReadAllReadableValues();
                }
                catch (AdamException ex)
                {
                    readTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    throw ex;
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

        private void ReadAllReadableValues()
        {
            throw new NotImplementedException();
        }



        #endregion


        public class AdamHelperException : AdamException
        {
            public AdamHelperException(string message) : base(message) { }
            public AdamHelperException(string message, Exception innerException) : base(message, innerException) { }
        }


    }


}
