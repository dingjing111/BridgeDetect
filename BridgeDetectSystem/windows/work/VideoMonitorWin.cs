using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class VideoMonitorWin : MetroFramework.Forms.MetroForm
    {
        public VideoMonitorWin()
        {
            InitializeComponent();
        }

        private void VideoMonitor_Load(object sender, EventArgs e)
        {
            this.initial();
        }
        public void initial()
        {
            this.panel2.Height = this.panel1.Height / 2;
            this.panel4.Width = this.panel2.Width / 2;
            this.panel6.Width = this.panel3.Width / 2;
        }
        

    }
}
