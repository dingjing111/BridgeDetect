using BridgeDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.entity;
using MetroForm = MetroFramework.Forms.MetroForm;

namespace BridgeDetectSystem
{
    public partial class MainWin : MetroForm
    {
        private UserRightManager rightManager = UserRightManager.GetInstance();

        public MainWin()
        {
            InitializeComponent();
        }

        #region 查看记录按钮
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
        #endregion

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUserSet_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.SystemSetLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                UserRightWin win = new UserRightWin();
                win.Show();
            }
        }

        /// <summary>
        /// 查看报警记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlarmRecord_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.RecordCheckAndExportLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                AlarmRecord win = new AlarmRecord();
                win.Show();
            }

        }

        /// <summary>
        /// 设置报警参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetParameter_Click(object sender, EventArgs e)
        {
            if (!rightManager.CanDoThis(UserRightConstraint.RingParameterSetLeastLevel))
            {
                new UserPrivilegeException();
            }
            else
            {
                SetParameter win = new SetParameter();
                win.Show();
            }
        }

        /// <summary>
        /// 查看浇筑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPouring_Click(object sender, EventArgs e)
        {
            PouringState win = new PouringState();
            win.Show();
        }

        /// <summary>
        /// 查看行走状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWalking_Click(object sender, EventArgs e)
        {
            VideoMonitorWin win = VideoMonitorWin.GetInstance();
            win.Show();
        }

        /// <summary>
        /// 处理关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出程序吗？", "提示",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
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

    }
}
