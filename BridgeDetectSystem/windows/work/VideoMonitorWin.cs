using System;
using System.Windows.Forms;
using BridgeDetectSystem.video;
using BridgeDetectSystem.service;
using BridgeDetectSystem.adam;
using System.Threading;

namespace BridgeDetectSystem
{
    public partial class VideoMonitorWin : MetroFramework.Forms.MetroForm
    {

        VideoPlayer player = null;
        AdamHelper2 adamHelper2 = null;
        WarningManager2 warningManager2 = null;

        public VideoMonitorWin()
        {
            InitializeComponent();
///////
            warningManager2 = WarningManager2.GetInstance();
          
        }

        private void VideoMonitor_Load(object sender, EventArgs e)
        {
            this.initial();
            adamHelper2.StartTimer(250);
            warningManager2.BgStart();//开始后台报警
            #region 初始化视频监控

            string ip = "192.168.1.100";


            string userName = "admin";
            string password = "admin123456";

            VideoPlayer.initClass(ip, userName, password);
            player = VideoPlayer.GetInstance();
           
            try
            {
                player.Initial();
                player.Login();
            }
            catch (VideoPlayerException ex)
            {
                MessageBox.Show("登陆录像成功，请点击全部显示按钮查看实时视频监控。");
                
                //MessageBox.Show("视频预览初始化出错! " + ex.Message);
                return;
            }

            #endregion


            ShowPreview();
          

            

        }

        private void initial()
        {
            #region 窗体初始化

            this.panel2.Height = this.panel1.Height / 2;
            this.panel4.Width = this.panel2.Width / 2;
            this.panel6.Width = this.panel3.Width / 2;

            #endregion
        }

        private void ShowPreview()
        {
            for (int i = 0; i < 4; i++)
            {
                Control[] ctr = this.panel1.Controls.Find("picBox" + (i + 1), true);
                if (ctr.Length > 0)
                {
                    PictureBox picbox = (PictureBox)ctr[0];
                    try
                    {
                        player.Preview(picbox, i);
                    }
                    catch (VideoPlayerException ex)
                    {
                        MessageBox.Show("第" + (i + 1) + "路摄像头出现问题：" + ex.Message);
                    }
                }
            }
        }

        private void StopPreview()
        {
            for (int i = 0; i < 4; i++)
            {
                Control[] ctr = this.panel1.Controls.Find("picBox" + (i + 1), true);
                if (ctr.Length > 0)
                {
                    PictureBox picbox = (PictureBox)ctr[0];
                    try
                    {
                        player.StopPreview(picbox, i);
                    }
                    catch (VideoPlayerException ex)
                    {
                        MessageBox.Show("第" + (i + 1) + "路摄像头出现问题：" + ex.Message);
                    }
                }

            }
        }
        /// <summary>
        /// 关闭--退出视频，结束数据接收，报警
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoMonitorWin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            player.CleanUp();

            if (warningManager2.isStart)
            {
                warningManager2.BgCancel();
            }

            adamHelper2.StopTimer();
        }

        private void RemoveAllPanelAndPictureBox()
        {
            foreach (Control ctr in Controls)
            {
                if (ctr is Panel || ctr is PictureBox)
                {
                    Controls.Remove(ctr);
                }
            }
        }

        private void AddPictureBox()
        {
            PictureBox picbox = new PictureBox();
            picbox.Name = "picBox1";
            picbox.Dock = DockStyle.Fill;
            picbox.Visible = true;
            Controls.Add(picbox);
            picbox.BringToFront();
        }

        private void ShowSinglePreview(int index)
        {
            PictureBox picbox = (PictureBox)Controls["picBox1"];
            try
            {
                player.Preview(picbox, index, 0);
            }
            catch (VideoPlayerException ex)
            {
                MessageBox.Show("第" + (index + 1) + "路摄像头出现问题：" + ex.Message);
            }
        }

        private void CreateSinglePreview(int index)
        {
            StopPreview();
            RemoveAllPanelAndPictureBox();
            AddPictureBox();
            ShowSinglePreview(index);
        }

        private void btnVideo1_Click(object sender, EventArgs e)
        {
            CreateSinglePreview(0);
        }

        private void btnVideo2_Click(object sender, EventArgs e)
        {
            CreateSinglePreview(1);
        }

        private void btnVideo3_Click(object sender, EventArgs e)
        {
            CreateSinglePreview(2);
        }

        private void btnVideo4_Click(object sender, EventArgs e)
        {
            CreateSinglePreview(3);
        }

        private void btnAllVideo_Click(object sender, EventArgs e)
        {
            //增加停掉。
            if (warningManager2.isStart==true)
            {
                warningManager2.BgCancel();
            }
            adamHelper2.StopTimer();
            this.Close();

            VideoMonitorWin win = new VideoMonitorWin();
            win.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double y = Math.Round(adamHelper2.v, 1);
            txtRailway.Text = y.ToString();

        }
    }

}
