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
    class WarningDialogManager
    {
        private BackgroundWorker bgWork;
        private static int count = 0;//测试用

        public WarningDialogManager()
        {
            bgWork = new BackgroundWorker();
        }

        /// <summary>
        /// 写报警逻辑代码，如果硬件中取到的数据，超过设置的报警值则报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgDoWork(object sender,DoWorkEventArgs e)
        {
            Thread.CurrentThread.Name = "报警后台线程";
            //写判断逻辑,
            while (true)
            {
                if((count++ % 10) == 0)
                {
                    bgWork.ReportProgress(count);
                }
                Thread.Sleep(500);
            }
        }

        public void BgStart()
        {
            bgWork.WorkerReportsProgress = true;
            bgWork.DoWork += new DoWorkEventHandler(BgDoWork);
            bgWork.ProgressChanged += new ProgressChangedEventHandler(BgProgressChanged);
            bgWork.RunWorkerAsync();
        }

        delegate void InvokeMethod(object obj);
        private void BgProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WarningDialog warningform = WarningDialog.GetInstance();
            warningform.Show();
            warningform.TopMost = true;
            warningform.Invoke(new InvokeMethod(warningform.DoWork), count);
        }
    }
}
