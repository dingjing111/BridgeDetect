using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BridgeDetectSystem.service
{
    public class WarningManager
    {
        private BackgroundWorker bgWork;
        private static int count = 0;//测试用
        private ConfigManager config;
        private AdamHelper adamHelper;
        private WarningObject warningObj;

        //同步信号，当报警发生时，暂停当前线程。需要手动重新启动线程，
        //在WarningDialog界面中传入信号到当前类
        private ManualResetEvent manualReset = new ManualResetEvent(true); 

        /// <summary>
        /// 单例
        /// </summary>
        private WarningManager()
        {
            bgWork = new BackgroundWorker();
            warningObj = new WarningObject();
            config = ConfigManager.GetInstance();
            adamHelper = AdamHelper.GetInstance();
        }
        private static volatile WarningManager instance = new WarningManager();
        public static WarningManager GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// 主界面调用，开始后台报警线程
        /// </summary>
        public void BgStart()
        {
            bgWork.WorkerReportsProgress = true;
            bgWork.DoWork += new DoWorkEventHandler(BgDoWork);
            bgWork.ProgressChanged += new ProgressChangedEventHandler(BgProgressChanged);
            bgWork.RunWorkerAsync();
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
            warningform.Invoke(new InvokeMethod(warningform.DoWork), count);
        }

        /// <summary>
        /// 写报警逻辑代码，如果硬件中取到的数据，超过设置的报警值则报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgDoWork(object sender, DoWorkEventArgs e)
        {
            Thread.CurrentThread.Name = "报警后台线程";
            //写判断逻辑,
            while (true)
            {

                //如果ManualResetEvent的初始化为终止状态（true)，那么该方法将一直工作，
                //直到收到Reset信号。然后，直到收到Set信号,就继续工作。
                manualReset.WaitOne();

                //if ((count++ % 10) == 0)
                //{
                //    bgWork.ReportProgress(count);
                //}

                CkeckSteeveForce();

                CheckSteeveDis();

                CheckAnchorForce();

                CheckFrontPivotDis();

                CheckMainTruss();


                Thread.Sleep(1000);
            }
        }

        private void CheckMainTruss()
        {
        }

        private void CheckFrontPivotDis()
        {
        }

        private void CheckAnchorForce()
        {
        }

        private void CheckSteeveDis()
        {
        }

        private void CkeckSteeveForce()
        {
            var dic = adamHelper.steeveDic;


            warningObj.Add(new WarningObjectItem(WarningType.firstSteeve_forceLarger));
        }

    }
}
