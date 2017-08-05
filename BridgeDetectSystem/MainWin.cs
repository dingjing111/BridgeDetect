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
    public partial class MainWin : MetroFramework.Forms.MetroForm
    {
        public MainWin()
        {
            InitializeComponent();
        }

        private void MainWin_Load(object sender, EventArgs e)
        {

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
            else
            {

            }
        }


        private void btnSteeveForce_Click(object sender, EventArgs e)
        {
            SteeveForceRecord win = new SteeveForceRecord();
            win.Show();
        }

        private void btnSteeveDis_Click(object sender, EventArgs e)
        {
            SteeveDisplaceRecord win = new SteeveDisplaceRecord();
            win.Show();
        }

        private void btnAnchorForce_Click(object sender, EventArgs e)
        {
            AnchorForceRecord win = new AnchorForceRecord();
            win.Show();
        }

        private void btnFrontPivot_Click(object sender, EventArgs e)
        {
            FrontPivotRecord win = new FrontPivotRecord();
            win.Show();
        }

        private void btnUserSet_Click(object sender, EventArgs e)
        {
            UserRightWin win = new UserRightWin();
            win.Show();
        }

        private void btnAlarmRecord_Click(object sender, EventArgs e)
        {
            AlarmRecord win = new AlarmRecord();
            win.Show();
        }

        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            SetParameter win = new SetParameter();
            win.Show();
            
        }

       

        private void btnPouring_Click(object sender, EventArgs e)
        {
            PouringState win = new PouringState();
            win.Show();
        }

        private void btnWalking_Click(object sender, EventArgs e)
        {

        }
    }
}
