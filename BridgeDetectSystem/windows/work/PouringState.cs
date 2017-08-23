using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.adam;

namespace BridgeDetectSystem
{
    public partial class PouringState : MetroFramework.Forms.MetroForm
    {
        AdamHelper adamHelper = AdamHelper.GetInstance(); 
    
        public PouringState()
        {
            InitializeComponent();
        }
        private void initial()
        {
           
        }
        private void SteeveForceAndDisplacement16_Load(object sender, EventArgs e)
        {
            #region 界面 panel 相关
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = (this.panel1.Height - menuStrip1.Height) / 2;
            this.panel6.Height = (this.panel1.Height - menuStrip1.Height) / 2;
            this.panel8.Width = this.panel7.Width / 2;
            #endregion 

            this.initial();
        }

        #region 菜单栏按钮功能方法

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

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            SetParameter win = new SetParameter();
            win.Show();
        }

        #endregion

        private void btnResetSteeve_Click(object sender, EventArgs e)
        {

        }

        private void btnResetFrontPivot_Click(object sender, EventArgs e)
        {

        }
    }
}
