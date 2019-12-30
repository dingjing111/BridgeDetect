using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.util;
using BridgeDetectSystem.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BridgeDetectSystem.service
{
    public class WarningManager
    {
        #region 字段

        public volatile bool isStart = false;


        private string name; //得到操作人的名字
        private BackgroundWorker bgWork;
        private ConfigManager config;
        private AdamHelper adamHelper;
        private DBHelper dbhelper;
       
        double steeveDisLimit;
        double steeveDisDiffLimit;
        
        double FrontDisLimit;
        double basketupDisLimit;
        double allowDisDiffLimit;
        private List<string> warningList;
        //同步信号，当报警发生时，暂停当前线程。需要手动重新启动线程，
        //在WarningDialog界面中传入信号到当前类
        private ManualResetEvent manualReset = new ManualResetEvent(true);

        /// <summary>
        /// 单例
        /// </summary>
        private WarningManager()
        {
            name = UserRightManager.user.userName;
            bgWork = new BackgroundWorker();
            config = ConfigManager.GetInstance();
            adamHelper = AdamHelper.GetInstance();
            dbhelper = DBHelper.GetInstance();
        }
        private static volatile WarningManager instance = new WarningManager();
        public static WarningManager GetInstance()
        {
            return instance;
        }
        #endregion

        #region 后台报警线程相关
        /// <summary>
        /// 主界面调用，开始后台报警线程
        /// </summary>
        public void BgStart()
        {
            bgWork.WorkerSupportsCancellation = true;
            bgWork.WorkerReportsProgress = true;
            bgWork.DoWork += new DoWorkEventHandler(BgDoWork);
            bgWork.ProgressChanged += new ProgressChangedEventHandler(BgProgressChanged);
            bgWork.RunWorkerAsync();
            isStart = true;
        }
        /// <summary>
        /// 请求取消后台挂起的操作
        /// </summary>
        public void BgCancel()
        {
            bgWork.CancelAsync();
            isStart = false;
        }


        /// <summary>
        /// 报警界面调用，继续当前报警线程
        /// </summary>
        public void ContinueThread()
        {
            //继续当前线程的工作 
            manualReset.Set();
        }

        /// <summary>
        /// 调用报警界面，显示报警参数
        /// </summary>
        /// <param name="obj"></param>
        delegate void InvokeMethod(object obj);
        private void BgProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //暂停当前线程，发信号给waitOne方法，阻塞
            manualReset.Reset();

            WarningDialog warningform = WarningDialog.GetInstance(this);
            warningform.Show();
            warningform.TopMost = true;
            warningform.Invoke(new InvokeMethod(warningform.DoWork), warningList);
        }

        /// <summary>
        /// 写报警逻辑代码，如果硬件中取到的数据，超过设置的报警值则报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgDoWork(object sender, DoWorkEventArgs e)
        {
            //Thread.CurrentThread.Name = "报警后台线程";
            //写判断逻辑,
            while (true)
            {
                //如果申请取消
                if (bgWork.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                //如果ManualResetEvent的初始化为终止状态（true)，那么该方法将一直工作，
                //直到收到Reset信号。然后，直到收到Set信号,就继续工作。
                manualReset.WaitOne();

                if (adamHelper.hasData)
                {
                    //warningObj = new WarningObject();
                    warningList = new List<string>();

                    CheckSteeveForce();

                    CheckSteeveDis();

                  //CheckAnchorForce();

                    CheckFrontPivotDis();

                    

                    if (warningList.Count > 0)
                    {
                        InsertAlarmRecord(warningList);                      //调方法将记录存入报警记录表

                        bgWork.ReportProgress(0);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        #endregion

        #region 报警的具体逻辑

        ///// <summary>
        ///// 主桁架报警
        ///// </summary>
        //private void CheckMainTruss()
        //{

        //}

        /// <summary>
        /// 前支点位移报警
        /// </summary>
        private void CheckFrontPivotDis()
        {
            var dic = adamHelper.frontPivotDic;
            List<double> disDiffList = new List<double>();

            foreach (var kv in dic)
            {
                disDiffList.Add(kv.Value.GetDisplace());
            }
            double first = Math.Abs(disDiffList[0] - adamHelper.first_frontPivotDisStandard);
            double second = Math.Abs(disDiffList[1] - adamHelper.second_frontPivotDisStandard);
            double three = Math.Abs(disDiffList[2] - adamHelper.three_standard);
            double four = Math.Abs(disDiffList[3] - adamHelper.four_standard);
            FrontDisLimit = config.Get(ConfigManager.ConfigKeys.frontPivot_DisLimit);
            if (first >= FrontDisLimit)
            {
                warningList.Add("1号前支点沉降超过设定值！！！沉降了"+first+"毫米");
            }
            if (second >=FrontDisLimit)
            {
                warningList.Add("2号前支点沉降超过设定值！！！沉降了"+second+"毫米");
            }
            if (three >= FrontDisLimit)
            {
                warningList.Add("3号前支点沉降超过设定值！！！沉降了"+ three+"毫米");

            }
            if (four >= FrontDisLimit)
            {
                warningList.Add("4号前支点沉降超过设定值！！！沉降了"+four+ "毫米");
            }
        }

        /// <summary>
        /// 锚杆力报警
        /// </summary>
        private void CheckAnchorForce()
        {
            CheckForce(adamHelper.anchorDic, "锚杆");
        }

        /// <summary>
        /// 吊杆位移报警
        /// </summary>
        private void CheckSteeveDis()
        {
           // var dic = adamHelper.steeveDic;
            Dictionary<int, Steeve> dicSteeve = adamHelper.steeveDic;
            List<double> disList = new List<double>();//位移集合
            List<double> reallist = new List<double>();
            List<double> standardlist = new List<double>();
            for (int i = 0; i < 4; i++)
            {
                standardlist.Add(adamHelper.standardlist[i]);
            }
           //四个基点标准
            
            for (int i = 0; i < 4; i++)
            {
                reallist.Add(dicSteeve[i].GetDisplace() - standardlist[i]);//带正负，上升为-，下降为正
                disList.Add(Math.Abs(dicSteeve[i].GetDisplace() - standardlist[i]));//绝对值
            }
               
              
            
            basketupDisLimit = config.Get(ConfigManager.ConfigKeys.basket_upDisLimit);//前下横梁上升位移上限。。。平均
            allowDisDiffLimit = config.Get(ConfigManager.ConfigKeys.basket_allowDisDiffLimit);//单根吊杆位移上限
            steeveDisLimit =  allowDisDiffLimit;//吊杆位移上限
            steeveDisDiffLimit = config.Get(ConfigManager.ConfigKeys.steeve_DisDiffLimit);//位移差上限
            for (int i = 0; i < disList.Count; i++)
            {
                if (disList[i] >= steeveDisLimit)
                {
                    int t = i + 1;
                    warningList.Add("第" + t + "号吊杆位移过大,值为：" + disList[i] + "(cm)");
                }
            }
            //基准位移差报警
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (Math.Abs(standardlist[i] - standardlist[j]) >= steeveDisDiffLimit)
                    {
                        warningList.Add("第" + (i+1) + "、" + (j+1) + "号" + "吊杆基准之间位移差值过大。值分别为："
                            + standardlist[i] + "(cm)" + "||" + standardlist[j] + "cm");
                    }
                }
            }
            //吊杆上升位移差
            for (int i = 0; i < 4; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (Math.Abs(disList[i] - disList[j]) >= steeveDisDiffLimit)
                    {
                        warningList.Add("第" + (i+1) + "、" + (j+1) + "号"  + "吊杆之间位移差值过大。值分别为："
                            + disList[i] + "(cm)" + "||" + disList[j] + "cm");
                    }
                }
            }

            double sum = 0;
            foreach (var val in reallist)
            {
                sum += val;
            }

            double average = sum / 4;
            double realDis = average;//- adamHelper.steeveDisStandard;//四根吊杆的平均位移，可当作前下横梁位移
         
            if (realDis < 0)
            {
                if (Math.Abs( realDis )- config.Get(ConfigManager.ConfigKeys.basket_upDisLimit) >= 0)
                {
                    warningList.Add("前下横梁上升位移，超过设定值报警。上升的位移平均值为：" + realDis);
                }
            }
            else
            {
                if (Math.Abs(realDis) - config.Get(ConfigManager.ConfigKeys.basket_downDisLimit) >=0)
                {
                    warningList.Add("前下横梁下降位移，超过设定值报警。下降的位移平均值为：" + Math.Abs(realDis));
                }
            }

        }

        /// <summary>
        /// 吊杆力报警
        /// </summary>
        private void CheckSteeveForce()
        {
            CheckForce(adamHelper.steeveDic, "吊杆");
        }
        double forceLimit;
        double forceDiff;
        private void CheckForce(object obj, string str)
        {


            List<double> forceList = new List<double>();
            if (obj is Dictionary<int, Steeve>)           //吊杆力
            {
                forceLimit = config.Get(ConfigManager.ConfigKeys.steeve_ForceLimit);
                forceDiff = config.Get(ConfigManager.ConfigKeys.steeve_ForceDiffLimit);
                var dic = obj as Dictionary<int, Steeve>;
                var list = dic.ToList();
                foreach (var kv in list)
                {
                    forceList.Add(kv.Value.GetForce());
                }
            }
            else if (obj is Dictionary<int, Anchor>)      //锚杆力
            {
                forceLimit = config.Get(ConfigManager.ConfigKeys.anchor_ForceLimit);
                forceDiff = config.Get(ConfigManager.ConfigKeys.anchor_ForceDiffLimit);
                var dic = obj as Dictionary<int, Anchor>;
                var list = dic.ToList();
                foreach (var kv in list)
                {
                    forceList.Add(kv.Value.GetForce());
                }
            }


            for (int i = 0; i < forceList.Count; i++)
            {
                if (forceList[i] >= forceLimit)
                {
                    warningList.Add("第" + (i+1) + "号" + str + "力过大,值为：" + forceList[i] + "(KN)");
                }
            }
            for (int i = 0; i < forceList.Count; i++)
            {
                for (int j = i + 1; j < forceList.Count; j++)
                {
                    if (Math.Abs(forceList[i] - forceList[j]) >= forceDiff)
                    {
                        warningList.Add("第" + (i+1) + "、" + (j+1) + "号" + str + "之间力差值过大。值分别为："
                            + forceList[i] + "(KN)" + "||" + forceList[j] + "KN");
                    }
                }
            }
        }

        #endregion

        #region 数据库操作，记录报警
        private void InsertAlarmRecord(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string name = UserRightManager.user.userName;//得到操作人的名字
                string insertsql = string.Format("insert into AlarmRecord values(newid(),getdate(),'{0}','{1}')", list[i], name);
                try
                {
                    int r = dbhelper.ExecuteNonQuery(insertsql);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("记录报警发生错误" + ex.Message);
                }
            }
        }


        #endregion
    }
}
