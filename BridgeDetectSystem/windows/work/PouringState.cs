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
    public partial class PouringState : MetroFramework.Forms.MetroForm
    {
        public PouringState()
        {
            InitializeComponent();
        }
        private void initial()
        {
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = this.panel2.Height / 2;
            this.panel6.Height = this.panel3.Height / 2;
        }
        private void SteeveForceAndDisplacement16_Load(object sender, EventArgs e)
        {
            this.initial();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出吗？ ",
                                   " 提示",
                                  MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            SetParameter win = new SetParameter();
            win.Show();
        }
    }
}
