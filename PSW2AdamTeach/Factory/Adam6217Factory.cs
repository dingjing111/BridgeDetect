using System;
using System.Collections.Generic;
using System.Text;

namespace PSW2AdamTeach
{
    public class Adam6217Factory : IAdamFactory
    {
        public AdamOperation CreateOperation()
        {
            return new Adam6217Operation();
        }
    }
}
