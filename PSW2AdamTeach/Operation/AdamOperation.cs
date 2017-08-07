using System;
using System.Collections.Generic;
using System.Text;

namespace PSW2AdamTeach
{
    public abstract class AdamOperation
    {
        public abstract void Init();
        public abstract List<string> Read();
        public abstract string Read(int channelIndex);
        public abstract void Disconnect();
    }
}
