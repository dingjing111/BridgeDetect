using BridgeDetectSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.entity
{

    //哪一类报警
    public enum WarningGroup
    {
        steeveForce_warning,

        steeveDis_warning,

        anchorForce_warning,

        frontPivot_warning,

        maintruss_warning,
    }

    //具体报警类型
    public enum WarningType
    {
        //吊杆力
        firstSteeve_forceLarger,
        secondSteeve_forceLarger,
        thirdSteeve_forceLarger,
        forthSteeve_forceLarger,
        firstandsecondSteeve_forceLarger,
        firstandthirdSteeve_forceLarger,
        firstandfourthSteeve_forceLarger,
        secondandthirdSteeve_forceLarger,
        secondandfourthSteeve_forceLarger,
        thirdandfourthSteeve_forceLarger,

        //吊杆位移
        averageSteeve_upDisLarger,
        averageSteeve_downDisLarger,
        firstandsecondSteeve_disLarger,
        firstandthirdSteeve_disLarger,
        firstandfourthSteeve_disLarger,
        secondandthirdSteeve_disLarger,
        secondandfourthSteeve_disLarger,
        thirdandfourthSteeve_disLarger,

        //锚杆力
        firstAnchor_forceLarger,
        secondAnchor_forceLarger,
        thirdAnchor_forceLarger,
        forthAnchor_forceLarger,
        firstandsecondAnchor_forceLarger,
        firstandthirdAnchor_forceLarger,
        firstandfourthAnchor_forceLarger,
        secondandthirdAnchor_forceLarger,
        secondandfourthAnchor_forceLarger,
        thirdandfourthAnchor_forceLarger,


        //前支点
        firstFrontPivot_disLarger,
        secondFrontPivot_disLarger,

        //主桁架
        mainstruss_disLarger,

    }

    public class WarningObject
    {
        private List<WarningObjectItem> warningList;


        public WarningObject()
        {
            warningList = new List<WarningObjectItem>();
        }

        public WarningObject Add(WarningObjectItem item)
        {
            warningList.Add(item);
            return this;
        }

        public List<WarningObjectItem> GetWarningInfo()
        {
            return warningList;
        }
    }

    public class WarningObjectItem
    {
        public WarningType type { get; }
        public string readableName { get; }
        public List<double> values;
        private string name;

        public WarningObjectItem(WarningType type, params double[] values)
        {
            dic.TryGetValue(type, out name);
            this.type = type;
            this.readableName = name;
            this.values = new List<double>();
            this.values.AddRange(values);
        }

        public override string ToString()
        {
            StringBuilder str=new StringBuilder();
            if (values.Count > 0)
            {
                str.Append("值为：");
                foreach (var v in values)
                {
                    str.Append(v + " ; ");
                }
            }

            return readableName +str.ToString();
        }



        static Dictionary<WarningType, string> dic = new Dictionary<WarningType, string>()
        {
            {WarningType.firstSteeve_forceLarger,"1号吊杆力过大" },
            {WarningType.secondSteeve_forceLarger,"2号吊杆力过大" },
            {WarningType.thirdSteeve_forceLarger,"3号吊杆力过大" },
            {WarningType.forthSteeve_forceLarger,"4号吊杆力过大" },
            {WarningType.firstandsecondSteeve_forceLarger,"1，2吊杆力差值过大" },
            {WarningType.firstandthirdSteeve_forceLarger,"1，3吊杆力差值过大" },
            {WarningType.firstandfourthSteeve_forceLarger,"1，4吊杆力差值过大" },
            {WarningType.secondandthirdSteeve_forceLarger,"2,3吊杆力差值过大" },
            {WarningType.secondandfourthSteeve_forceLarger,"2，4吊杆力差值过大" },
            {WarningType.thirdandfourthSteeve_forceLarger,"3，4吊杆力差值过大" },

            {WarningType.averageSteeve_upDisLarger,"挂篮上升位移过大" },
            {WarningType.averageSteeve_downDisLarger,"挂篮下降位移过大" },
            {WarningType.firstandsecondSteeve_disLarger,"1，2吊杆位移差值过大" },
            {WarningType.firstandthirdSteeve_disLarger,"1，3吊杆位移差值过大" },
            {WarningType.firstandfourthSteeve_disLarger,"1，4吊杆位移差值过大" },
            {WarningType.secondandthirdSteeve_disLarger,"2,3吊杆位移差值过大" },
            {WarningType.secondandfourthSteeve_disLarger,"2，4吊杆位移差值过大" },
            {WarningType.thirdandfourthSteeve_disLarger,"3，4吊杆位移差值过大" },

            {WarningType.firstAnchor_forceLarger,"1号锚杆力过大" },
            {WarningType.secondAnchor_forceLarger,"2号锚杆力过大" },
            {WarningType.thirdAnchor_forceLarger,"3号锚杆力过大" },
            {WarningType.forthAnchor_forceLarger,"4号锚杆力过大" },
            {WarningType.firstandsecondAnchor_forceLarger,"1，2锚杆力差值过大" },
            {WarningType.firstandthirdAnchor_forceLarger,"1，3锚杆力差值过大" },
            {WarningType.firstandfourthAnchor_forceLarger,"1，4锚杆力差值过大" },
            {WarningType.secondandthirdAnchor_forceLarger,"2,3锚杆力差值过大" },
            {WarningType.secondandfourthAnchor_forceLarger,"2，4锚杆力差值过大" },
            {WarningType.thirdandfourthAnchor_forceLarger,"3，4锚杆力差值过大" },

            {WarningType.firstFrontPivot_disLarger,"一号前支点位移过大" },
            {WarningType.secondFrontPivot_disLarger,"二号前支点位移过大" },
            {WarningType.mainstruss_disLarger,"桁架移动不同步" },
        };

        //报警信息提示
        static readonly string[] strList = new string[]
        {
            "1号吊杆力过大",
            "2号吊杆力过大",
            "3号吊杆力过大",
            "4号吊杆力过大",
            "1，2吊杆力差值过大",
            "1，3吊杆力差值过大",
            "1，4吊杆力差值过大",
            "2，3吊杆力差值过大",
            "2，4吊杆力差值过大",
            "3，4吊杆力差值过大",


            "挂篮上升位移过大",
            "挂篮下降位移过大",
            "1，2吊杆位移差值过大",
            "1，3吊杆位移差值过大",
            "1，4吊杆位移差值过大",
            "2，3吊杆位移差值过大",
            "2，4吊杆位移差值过大",
            "3，4吊杆位移差值过大",

            "1号锚杆力过大",
            "2号锚杆力过大",
            "3号锚杆力过大",
            "4号锚杆力过大",
            "1，2锚杆力差值过大",
            "1，3锚杆力差值过大",
            "1，4锚杆力差值过大",
            "2，3锚杆力差值过大",
            "2，4锚杆力差值过大",
            "3，4锚杆力差值过大",

            "一号前支点位移过大",
            "二号前支点位移过大",

            "桁架移动不同步！",
        };
    }

}
