using BridgeDetectSystem.adam;
using BridgeDetectSystem.windows;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace BridgeDetectSystem.service
{
    public class WarningManager2
    {
        #region 字段
        public volatile bool isStart = false;

        private BackgroundWorker bgWork;
        private AdamHelper2 adamHelper2;
        private List<string> warningList;
        //同步信号，当报警发生时，暂停当前线程。需要手动重新启动线程，
        //在WarningDialog界面中传入信号到当前类
        private ManualResetEvent manualReset = new ManualResetEvent(true);
        /// <summary>
        /// 单例
        /// </summary>
        private WarningManager2()
        {
            bgWork = new BackgroundWorker();
            adamHelper2 = AdamHelper2.GetInstance();
        }
        private static volatile WarningManager2 instance = new WarningManager2();
        public static WarningManager2 GetInstance()
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
            if (bgWork.IsBusy) { return; } //。。。
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

            WarningDialog2 warningform = WarningDialog2.GetInstance(this);
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
           // Thread.CurrentThread.Name = "报警后台线程";
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

                if (adamHelper2.hasData)
                {
                    warningList = new List<string>();

                    CheckMainTruss();

                    if (warningList.Count > 0)
                    {
                        bgWork.ReportProgress(0);
                    }
                }

                Thread.Sleep(1000);
            }
        }

        #endregion

        #region 报警的具体逻辑

        /// <summary>
        /// 主桁架报警逻辑
        /// </summary>
        private void CheckMainTruss()
        {
            double d = adamHelper2.v;
            if (Math.Abs(d-784) > 10) {
                warningList.Add("主桁行走不同步，请注意调整！！！");
            }
        }

        #endregion
    }
}
