using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BridgeDetectSystem.video
{
    /// @author : psw
    /// @date : 2017/8/11
    /// 
    /// dll调用顺序：
    /// 1.初始化SDK(NET_DVR_Init)->2.用户注册设备(NET_DVR_Login_V30)->3.视频预览模块->4.注销设备(NET_DVR_Logout)
    /// 
   
    public class VideoPlayerException : Exception
    {
        public VideoPlayerException(string message) : base(message) { }
        public VideoPlayerException(string message, Exception inner) : base(message, inner) { }
    }

    class VideoPlayer
    {
        #region 字段
        private bool m_bInitSDK = false;
        private uint iLastErr = 0;
        private int m_lUserID = -1;
        private int[] m_lRealHandle = new int[64];
        private int i = 0;
        private string str;
        private uint dwAChanTotalNum = 0;
        private uint dwDChanTotalNum = 0;
        private int[] iIPDevID = new int[96];
        private int[] iChannelNum = new int[96];

        private CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo;
        private CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40;
        private CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo;
        private CHCNetSDK.NET_DVR_IPCHANINFO_V40 m_struChanInfoV40;

        /// <summary>
        /// DVR登入信息
        /// </summary>
        string DVRIPAddress; //设备IP地址或者域名 Device IP
        Int16 DVRPortNumber;//设备服务端口号 Device Port
        string DVRUserName;//设备登录用户名 User name to login
        string DVRPassword;//设备登录密码 Password to login

        #endregion

        private static VideoPlayer instance = null;
        public static VideoPlayer GetInstance()
        {
            if (instance == null)
            {
                throw new VideoPlayerException("未初始化视频播放类");
            }
            return instance;
        }

        public static void initClass(string DVRIPAddress, string DVRUserName, string DVRPassword, Int16 DVRPortNumber = 8000)
        {
            if (instance != null)
            {
                return;
            }
            instance = new VideoPlayer(DVRIPAddress, DVRUserName, DVRPassword,DVRPortNumber);
        }

        private VideoPlayer(string DVRIPAddress, string DVRUserName, string DVRPassword, Int16 DVRPortNumber = 8000)
        {
            this.DVRIPAddress = DVRIPAddress;
            this.DVRPortNumber = DVRPortNumber;
            this.DVRUserName = DVRUserName;
            this.DVRPassword = DVRPassword;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initial()
        {
            m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                throw new VideoPlayerException("NET_DVR_Init error!");
            }
            else
            {
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, "D:\\SdkLog\\", true);
                for (int i = 0; i < 64; i++)
                {
                    iIPDevID[i] = -1;
                    iChannelNum[i] = -1;
                    m_lRealHandle[i] = -1;
                }
            }
        }

        /// <summary>
        /// 登入NVR录像机
        /// </summary>
        public void Login()
        {
            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(DVRIPAddress, DVRPortNumber, DVRUserName, DVRPassword, ref DeviceInfo);
            if (m_lUserID < 0)
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_Login_V30 failed, error code= " + iLastErr; //登录失败，输出错误号 Failed to login and output the error code
                throw new VideoPlayerException(str);
            }
            else
            {
                //登录成功
                dwDChanTotalNum = (uint)DeviceInfo.byIPChanNum + 256 * (uint)DeviceInfo.byHighDChanNum;
                if (dwDChanTotalNum > 0)
                {
                    InfoIPChannel();
                }
                else
                {
                    throw new VideoPlayerException("没有数字摄像头输入！");
                }
            }

        }

        /// <summary>
        /// 获取通道信息
        /// </summary>
        private void InfoIPChannel()
        {
            uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);

            IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
            Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);

            uint dwReturn = 0;
            int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取

            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                throw new VideoPlayerException(str);
            }
            else
            {
                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));

                byte byStreamType = 0;
                uint iDChanNum = 64;

                if (dwDChanTotalNum < 64)
                {
                    iDChanNum = dwDChanTotalNum; //如果设备IP通道小于64路，按实际路数获取
                }

                for (i = 0; i < iDChanNum; i++)
                {
                    iChannelNum[i + dwAChanTotalNum] = i + (int)m_struIpParaCfgV40.dwStartDChan;
                    byStreamType = m_struIpParaCfgV40.struStreamMode[i].byGetStreamType;

                    dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[i].uGetStream);
                    switch (byStreamType)
                    {
                        //目前NVR仅支持直接从设备取流 NVR supports only the mode: get stream from device directly
                        case 0:
                            IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[i].uGetStream, ptrChanInfo, false);
                            m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                            iIPDevID[i] = m_struChanInfo.byIPID + m_struChanInfo.byIPIDHigh * 256 - iGroupNo * 64 - 1;

                            Marshal.FreeHGlobal(ptrChanInfo);
                            break;
                        case 6:
                            IntPtr ptrChanInfoV40 = Marshal.AllocHGlobal((Int32)dwSize);
                            Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[i].uGetStream, ptrChanInfoV40, false);
                            m_struChanInfoV40 = (CHCNetSDK.NET_DVR_IPCHANINFO_V40)Marshal.PtrToStructure(ptrChanInfoV40, typeof(CHCNetSDK.NET_DVR_IPCHANINFO_V40));
                            iIPDevID[i] = m_struChanInfoV40.wIPID - iGroupNo * 64 - 1;

                            Marshal.FreeHGlobal(ptrChanInfoV40);
                            break;
                        default:
                            break;
                    }
                }
            }
            Marshal.FreeHGlobal(ptrIpParaCfgV40);

        }

        /// <summary>
        /// 实时预览
        /// </summary>
        /// <param name="RealPlayWnd">窗口PictureBox控件</param>
        /// <param name="index">预览的设备通道</param>
        /// <param name="StreamType">码流类型，默认为子码流1，主码流的代码为0</param>
        public void Preview(System.Windows.Forms.PictureBox RealPlayWnd, int index,uint StreamType=1)
        {
            if (m_lUserID < 0)
            {
                throw new VideoPlayerException("Please login the device firstly!");
            }
            if (m_lRealHandle[index] < 0)
            {
                CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//预览窗口 live view window
                lpPreviewInfo.lChannel = iChannelNum[index];//预览的设备通道 the device channel number
                lpPreviewInfo.dwStreamType = StreamType;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库显示缓冲区最大帧数

                IntPtr pUser = IntPtr.Zero;//用户数据 user data 

                //打开预览 Start live view 
                m_lRealHandle[index] = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);

                if (m_lRealHandle[index] < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号 failed to start live view, and output the error code.
                    throw new VideoPlayerException(str);
                }
                else
                {
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_ANA_INTEL_DATA, false);
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_MD, false);
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_FIRE_DETCET, false);
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_ADD_PIC, false);
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_TEM, false);
                    PlayCtrl.PlayM4_RenderPrivateData(CHCNetSDK.NET_DVR_GetRealPlayerIndex(m_lRealHandle[index]), (int)PlayCtrl.PLAYM4_PRIDATA_RENDER.PLAYM4_RENDER_ADD_POS, false);

                }

            }
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="RealPlayWnd"></param>
        /// <param name="index"></param>
        public void StopPreview(System.Windows.Forms.PictureBox RealPlayWnd, int index)
        {
            //停止预览 Stop live view 
            if (m_lRealHandle[index] != -1)
            {
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle[index]))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                    throw new VideoPlayerException(str);
                }
            }
            m_lRealHandle[index] = -1;
            RealPlayWnd.Invalidate();//刷新窗体
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void CleanUp()
        {
            foreach (var handle in m_lRealHandle)
            {
                if (handle >= 0)
                {
                    CHCNetSDK.NET_DVR_StopRealPlay(handle);
                }
            }
            //注销登录
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }
            CHCNetSDK.NET_DVR_Cleanup();
        }
    }
}
