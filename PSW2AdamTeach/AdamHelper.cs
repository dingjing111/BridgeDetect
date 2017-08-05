using System;
using Advantech.Adam;
using System.Net.Sockets;

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
     *  封装初始化等过程(Initalize-->Connect-->GetChannelRange-->GetChannelEnabled)-->OnReady();
     *  封装读取全部通道数据过程：（GetAllChannelValue）-->Read()
     *  封装读取特定通道的数据：（GetChannelSingleValue）-->Read(int channelIndex)
     *  
     *******************************************************************************/
    public class AdamHelper
    {
        #region  字段
        //标志：modbus通信是否已经开始
        public bool modbusStart { get; set; }
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

        /// <summary>
        /// 根据参数，构造modbus,生成adamSocket实例
        /// </summary>
        /// <param name="ip">从站ip</param>
        /// <param name="series">研华板卡的系列</param>
        /// <param name="type">研华板卡的具体型号</param>
        /// <param name="port">modbus通信端口，默认为502</param>
        public AdamHelper(string ip, AdamType series,
            Adam6000Type type, int port = 502)
        {
            adamModbus = new AdamSocket();
            slaveIp = ip;
            modbusPort = port;
            //adamSeries = Advantech.Adam.AdamType.Adam6200;

            adamSeries = (Advantech.Adam.AdamType)series;
            adamType = (Advantech.Adam.Adam6000Type)type;
        }

        /// <summary>
        /// 初始化modbus配置
        /// </summary>
        public void Initalize() 
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
        public void SetTimeOut(int connectTimeOut = 1000,
            int sendTimeout = 1000,
            int receTimeout = 1000)
        {
            adamModbus.SetTimeout(connectTimeOut, sendTimeout, receTimeout);
        }

        /// <summary>
        /// 返回所有通道的数据，格式处理在这里设置
        /// </summary>
        /// <returns></returns>
        public string[] GetAllChannelValue()
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
            return values;
        }

        /// <summary>
        /// 返回特定通道的数据字符串，数据格式在这里设置
        /// </summary>
        /// <param name="channelIndex">通道的索引0-7</param>
        /// <returns></returns>
        public string GetChannelSingleValue(int channelIndex)
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
            return value;
        }

        /// <summary>
        /// 返回从startIndex到endIndex范围内所有通道中数据表示范围
        /// </summary>
        /// <param name="startIndex">第一个通道索引，默认为0</param>
        /// <param name="endIndex">最后一个通道索引，默认为7</param>
        /// <returns></returns>
        public ushort[] GetChannelRange(int startIndex = 0, int endIndex = 7)
        {
            ushort range;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (adamModbus.AnalogInput().GetInputRange(i, out range))
                {
                    channelRange[i] = range;
                }

            }
            return channelRange;
        }

        /// <summary>
        /// 返回能用的通道
        /// </summary>
        /// <returns></returns>
        public bool[] GetChannelEnabled()
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
        public bool Connect()
        {
            if (!modbusStart)
            {
                if (adamModbus.Connect(slaveIp, ProtocolType.Tcp, modbusPort))
                {
                    modbusStart = adamModbus.Connected;
                }
            }

            return modbusStart;
        }

        /// <summary>
        /// 关闭modbus连接
        /// </summary>
        public bool Disconnect()
        {
            if (modbusStart)
            {
                adamModbus.Disconnect();
                modbusStart = false;
            }
            return modbusStart;
        }

        /// <summary>
        /// 封装读取全部通道数据过程
        /// </summary>
        /// <returns>返回全部通道字符串数据</returns>
        public string[] Read()
        {
            return GetAllChannelValue();
        }

        /// <summary>
        /// 封装读取特定通道数据过程
        /// </summary>
        /// <param name="channelIndex"></param>
        /// <returns></returns>
        public string Read(int channelIndex)
        {
            return GetChannelSingleValue(channelIndex);
        }

        /// <summary>
        /// 封装初始化，连接，得到通道参数等过程
        /// </summary>
        /// <returns>返回是否连接成功</returns>
        public bool OnReady()
        {
            Initalize();
            if (Connect())
            {
                GetChannelRange();
                GetChannelEnabled();
            }

            return modbusStart;
        }

    }


    #region enum 研华板卡型号

    /// <summary>
    /// 6000系列具体型号
    /// </summary>
    public enum Adam6000Type
    {
        Adam6015 = 0x177f,
        Adam6017 = 0x1781,
        Adam6018 = 0x1782,
        Adam6022 = 0x1786,
        Adam6024 = 0x1788,
        Adam6050 = 0x17a2,
        Adam6050W = 0x65c2,
        Adam6051 = 0x17a3,
        Adam6051W = 0x65c3,
        Adam6052 = 0x17a4,
        Adam6055 = 0x17a7,
        Adam6060 = 0x17ac,
        Adam6060W = 0x65cc,
        Adam6066 = 0x17b2,
        Adam6117 = 0x17e5,
        Adam6118 = 0x17e6,
        Adam6122 = 0x17ea,
        Adam6124 = 0x17ec,
        Adam6150 = 0x1806,
        Adam6151 = 0x1807,
        Adam6156 = 0x180c,
        Adam6160 = 0x1810,
        Adam6166 = 0x1816,
        Adam6217 = 0x1849,
        Adam6218 = 0x184a,
        Adam6222 = 0x184e,
        Adam6224 = 0x1850,
        Adam6250 = 0x186a,
        Adam6251 = 0x186b,
        Adam6256 = 0x1870,
        Adam6260 = 0x1874,
        Adam6265AMAT = 0x1879,
        Adam6266 = 0x187a,
        Non = 0
    }


    /// <summary>
    /// 研华系列的总型号
    /// </summary>
    public enum AdamType
    {
        Adam2000 = 0x7d0,
        Adam3600 = 0x3520,
        Adam4000 = 0xfa0,
        Adam5000 = 0x1388,
        Adam5000Tcp = 0x3a98,
        Adam5550 = 0x15ae,
        Adam6000 = 0x1770,
        Adam6100 = 0x65f4,
        Adam6200 = 0x6658,
        Apax5000 = 0x61a8,
        Apax5070 = 0x61ee,
        Apax5071 = 0x61ef,
        Apax5072 = 0x61f0,
        Apax5073 = 0x61f1,
        Non = 0,
        Wise4000 = 0x5dc0,
        Wise4000E = 0x84d0,
        Wise4000L = 0x36b0
    }

    #endregion


}
