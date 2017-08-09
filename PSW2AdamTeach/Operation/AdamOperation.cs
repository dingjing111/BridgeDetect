using System;
using System.Collections.Generic;
using System.Text;

namespace PSW2AdamTeach
{
    public abstract class AdamOperation 
    {
        /// <summary>
        /// 初始化模块配置，并建立连接
        /// </summary>
        public abstract void Init();
        /// <summary>
        /// 读模块所有通道数据
        /// </summary>
        /// <returns></returns>
        public abstract List<string> Read();
        /// <summary>
        /// 读模块指定通道数据
        /// </summary>
        /// <param name="channelIndex"></param>
        /// <returns></returns>
        public abstract string Read(int channelIndex);
        /// <summary>
        /// 关闭modbus连接
        /// </summary>
        public abstract void Disconnect();
        /// <summary>
        /// 返回通信的状态
        /// </summary>
        /// <returns></returns>
        public abstract bool OnReady();
      
    }

    public class AdamException : Exception
    {
        public AdamException(string message) : base(message) { }
        public AdamException(string message, Exception innerException) : base(message, innerException) { }
    }

}
