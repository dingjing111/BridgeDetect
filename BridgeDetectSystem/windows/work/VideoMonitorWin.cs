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

            ShowVideo();
        }

        public void initial()
        {
            this.panel2.Height = this.panel1.Height / 2;
            this.panel4.Width = this.panel2.Width / 2;
            this.panel6.Width = this.panel3.Width / 2;
        }


        public void ShowVideo()
        {
            string ip = "192.168.1.100";
            string userName = "admin";
            string password = "admin123456";

            player = new VideoPlayer(ip, userName, password);
            try
            {
                player.Initial();
                player.Login();
            }
            catch (VideoPlayerException ex)
            {
                MessageBox.Show("视频预览出错! " + ex.Message);
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                PictureBox picbox = (PictureBox)this.Controls.Find("pictureBox" + (i + 1), true)[0];
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

        private void VideoMonitorWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.CleanUp();
            instance = null;
        }
    }
}
