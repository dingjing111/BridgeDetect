using System;
using System.Collections.Generic;
using System.Text;

namespace PSW2AdamTeach
{
    public interface IAdamFactory
    {
        AdamOperation CreateOperation(string ip);
    }
}
