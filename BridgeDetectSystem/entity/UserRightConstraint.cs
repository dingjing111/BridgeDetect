using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{
    static class UserRightConstraint
    {

        // 记录查看与导出
        public const int RecordCheckAndExportLeastLevel = 1;

        // 报警参数设置
        public const int RingParameterSetLeastLevel = 2;

        // 系统设置
        public const int SystemSetLeastLevel = 3;

        public static readonly String[] UserLevelKindString = { "0", "操作员", "组长", "系统管理员" };

        public static readonly Dictionary<String, int> UserLevelStringToInt = new Dictionary<string, int>
        {
            {UserLevelKindString[1],1},
            {UserLevelKindString[2],2},
            {UserLevelKindString[3],3},
        };
    }
}
