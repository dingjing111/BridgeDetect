using Advantech.Adam;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;

namespace PSW2AdamTeach
{
    public class Adam6217Operation : AdamOperation
    {
        #region  字段

        //标志：modbus通信是否已经开始
        private bool modbusStart;
        //接收的数据数量
        public int recCount { get; set; }
        //AdamSocker类型变量
        private AdamSocket adamModbus;
        //从站IP地址
        private string slaveIp;
        //modbus通信端口，默认：502
        private int modbusPort;
        //通道总数，一块板块有0-15通道
        private int channelTotal;
        //每个通道是否可用
        private bool[] channelEnabled;
        //每个通道中数据表示的范围
        private ushort[] channelRange;
        //研华6000系列具体型号
        private Advantech.Adam.Adam6000Type adamType;
        //研华系列总型号
        private Advantech.Adam.AdamType adamSeries;

        #endregion

        #region 构造函数
        public Adam6217Operation(string ip)
        {
            adamModbus = new AdamSocket();
            slaveIp = ip;
            modbusPort = 502;
            adamSeries = Advantech.Adam.AdamType.Adam6200;
            adamType = Advantech.Adam.Adam6000Type.Adam6217;
        }

        #endregion

        #region 方法
        public override void Disconnect()
        {
            if (modbusStart)
            {
                adamModbus.Disconnect();
                modbusStart = false;
            }
            else
            {
                throw new Adam6217OperationException("ip为：" + slaveIp + "，研华adam6217模块未连接，无法关闭。");
            }
        }

        /// <summary>
        /// 初始化模块配置，并建立连接
        /// </summary>
        public override void Init()
        {
            Initalize();
            if (Connect())
            {
                GetChannelRange();
                GetChannelEnabled();
            }
            else
            {
                throw new Adam6217OperationException("ip为："+slaveIp+"，研华adam6217模块初始化失败");
            }
        }

        /// <summary>
        /// 读取全部通道数据过程
        /// </summary>
        /// <returns>返回全部通道字符串数据</returns>
        public override List<string> Read()
        {
            string[] strs = GetAllChannelValue();
            return new List<string>(strs);
        }

        /// <summary>
        /// 读取特定通道数据过程
        /// </summary>
        /// <param name="channelIndex"></param>
        /// <returns></returns>
        public override string Read(int channelIndex)
        {
            return GetChannelSingleValue(channelIndex);
        }

        /// <summary>
        /// 返回通信的状态
        /// </summary>
        /// <returns></returns>
        public override bool OnReady()
        {
            return modbusStart;
        }

        #region 私有方法
        /// <summary>
        /// 初始化modbus配置
        /// </summary>
        private void Initalize()
        {
            modbusStart = false;
            recCount = 0;
            adamModbus.AdamSeriesType = adamSeries;
            channelTotal = AnalogInput.GetChannelTotal(adamType);
            channelEnabled = new bool[channelTotal];
            channelRange = new ushort[channelTotal];
            SetTimeOut();
        }

        /// <summary>
        /// 设置通信超时时间，会在Initalize自动设置，也可手动设置
        /// </summary>
        /// <param name="connectTimeOut">连接超时，默认为1000ms</param>
        /// <param name="sendTimeout">发送超时，默认为1000ms</param>
        /// <param name="receTimeout">接收超时，默认为1000ms</param>
        private void SetTimeOut(int connectTimeOut = 1000,
            int sendTimeout = 1000,
            int receTimeout = 1000)
        {
            adamModbus.SetTimeout(connectTimeOut, sendTimeout, receTimeout);
        }

        /// <summary>
        /// 返回所有通道的数据，格式处理在这里设置
        /// </summary>
        /// <returns></returns>
        private string[] GetAllChannelValue()
        {
            string[] values = new string[channelTotal];
            int startIndex = 1;
            int[] data;
            float[] fValue = new float[channelTotal];

            if (adamModbus.Modbus().ReadInputRegs(startIndex, channelTotal, out data))
            {
                for (int i = 0; i < channelTotal; i++)
                {
                    fValue[i] = AnalogInput.GetScaledValue(adamType, channelRange[i], (ushort)data[i]);
                    if (channelEnabled[i])
                    {
                        string valueFormat = AnalogInput.GetFloatFormat(adamType, channelRange[i]);
                        values[i] = fValue[i].ToString(valueFormat) + " " + AnalogInput.GetUnitName(adamType, channelRange[i]);
                    }
                }
            }
            else
            {
                throw new Adam6217OperationException("ip为：" + slaveIp + "，研华adam6217模块读取输入通道数据失败。");
            }
            return values;
        }

        /// <summary>
        /// 返回特定通道的数据字符串，数据格式在这里设置
        /// </summary>
        /// <param name="channelIndex">通道的索引0-7</param>
        /// <returns></returns>
        private string GetChannelSingleValue(int channelIndex)
        {
            string value = string.Empty;
            int[] data;
            float fValue;
            int index = channelIndex;
            if (adamModbus.Modbus().ReadInputRegs(channelIndex + 1, 1, out data))
            {
                fValue = AnalogInput.GetScaledValue(adamType, channelRange[index], (ushort)data[0]);
                if (channelEnabled[index])
                {
                    string valueFormat = AnalogInput.GetFloatFormat(adamType, channelRange[index]);
                    value = fValue.ToString(valueFormat) + " " + AnalogInput.GetUnitName(adamType, channelRange[index]);
                }
            }
            else
            {
                throw new Adam6217OperationException("ip为：" + slaveIp + "，研华adam6217模块读取输入通道数据失败。");
            }
            return value;
        }

        /// <summary>
        /// 返回从startIndex到endIndex范围内所有通道中数据表示范围
        /// </summary>
        /// <param name="startIndex">第一个通道索引，默认为0</param>
        /// <param name="endIndex">最后一个通道索引，默认为7</param>
        /// <returns></returns>
        private ushort[] GetChannelRange(int startIndex = 0, int endIndex = 7)
        {
            ushort range;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (adamModbus.AnalogInput().GetInputRange(i, out range))
                {
                    channelRange[i] = range;
                }
                else
                {
                    throw new Adam6217OperationException("ip为：" + slaveIp + "，研华adam6217模块读取通道数据范围失败。");
                }

            }
            return channelRange;
        }

        /// <summary>
        /// 返回能用的通道
        /// </summary>
        /// <returns></returns>
        private bool[] GetChannelEnabled()
        {
            bool[] bEnabled;
            if (adamModbus.AnalogInput().GetChannelEnabled(channelTotal, out bEnabled))
            {
                Array.Copy(bEnabled, 0, channelEnabled, 0, channelTotal);
            }
            return channelEnabled;
        }

        /// <summary>
        /// 建立modbus连接
        /// </summary>
        /// <returns>返回是否连接</returns>
        private bool Connect()
        {
            if (!modbusStart)
            {
                if (adamModbus.Connect(slaveIp, ProtocolType.Tcp, modbusPort))
                {
                    modbusStart = adamModbus.Connected;
                }
                else
                {
                    throw new Adam6217OperationException("ip为：" + slaveIp + "，研华adam6217模块连接失败。");
                }
            }

            return modbusStart;
        }
        #endregion

        #endregion

        #region 异常类

        public class Adam6217OperationException : AdamException
        {
            public Adam6217OperationException(string message) : base(message) { }
            public Adam6217OperationException(string message, Exception innerException) : base(message, innerException) { }
        }

        #endregion

    }

}
