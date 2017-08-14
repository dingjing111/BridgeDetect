using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.video;
using System.Threading;

namespace BridgeDetectSystem
{
    public partial class VideoMonitorWin : MetroFramework.Forms.MetroForm
    {
        VideoPlayer player = null;

        public VideoMonitorWin()
        {
            InitializeComponent();
            instance = this;
        }

        private static volatile VideoMonitorWin instance = null;
        private static object obj = new object();
        public static VideoMonitorWin GetInstance()
        {
            lock (obj)
            {
                if (instance == null)
                {
                    new VideoMonitorWin();
                }
            }
            return instance;
        }

        private void VideoMonitor_Load(object sender, EventArgs e)
        {
            this.initial();

            ShowPreview();
        }

        private void initial()
        {
            #region 窗体初始化

            this.panel2.Height = this.panel1.Height / 2;
            this.panel4.Width = this.panel2.Width / 2;
            this.panel6.Width = this.panel3.Width / 2;

            #endregion

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
                MessageBox.Show("视频预览初始化出错! " + ex.Message);
                return;
            }

            #endregion
        }

        private void ShowPreview()
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox picbox = (PictureBox)this.panel1.Controls.Find("picBox" + (i + 1), true)[0];
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



        private void VideoMonitorWin_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            player.CleanUp();
            instance = null;
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
                player.Preview(picbox, index);
            }
            catch (VideoPlayerException ex)
            {
                MessageBox.Show("第" + index + "路摄像头出现问题：" + ex.Message);
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
            this.Close();
            VideoMonitorWin win = VideoMonitorWin.GetInstance();
            win.Show();
        }


    }
}
