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
using BridgeDetectSystem.adam;
using BridgeDetectSystem.util;

namespace BridgeDetectSystem
{
    public partial class MainWin : MetroForm
    {
        private UserRightManager rightManager ;
        private string userName;
       // private AdamHelper adamhelper;
        public MainWin()
        {
            InitializeComponent();

            rightManager = UserRightManager.GetInstance();
            userName = UserRightManager.user.userName;
            //adamhelper = AdamHelper.GetInstance();
        }

        #region 查看记录按钮
        private void btnSteeveForce_Click(object sender, EventArgs e)
        {
            SteeveForceRecord win = new SteeveForceRecord();
            win.Show();
            log("查看了吊杆力的记录");
        }

        private void btnSteeveDis_Click(object sender, EventArgs e)
        {
            SteeveDisplaceRecord win = new SteeveDisplaceRecord();
            win.Show();
            log("查看了吊杆位移的记录");
        }

        private void btnAnchorForce_Click(object sender, EventArgs e)
        {
            AnchorForceRecord win = new AnchorForceRecord();
            win.Show();
            log("查看了锚杆力的记录");
        }

        private void btnFrontPivot_Click(object sender, EventArgs e)
        {
            FrontPivotRecord win = new FrontPivotRecord();
            win.Show();
            log("查看了前支点位移的记录");
        }

        private void log(string message)
        {
            LoggerHelper.Log("主界面", userName + message);
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
                log("点击了系统设置按钮");
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
                log("查看了报警记录");
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
                log("点击了报警参数设置按钮");
            }
        }

        /// <summary>
        /// 查看浇筑状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPouring_Click(object sender, EventArgs e)
        {
            
            
            
                PouringState win = null;
                try
                {
                    win = new PouringState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (win != null)
                {
                    win.Show();
                    log("点击了浇注状态按钮");
                }
            
        }

        /// <summary>
        /// 查看行走状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWalking_Click(object sender, EventArgs e)
        {
            VideoMonitorWin win=null;
            try
            {
                win = new VideoMonitorWin();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (win != null)
            {
                win.Show();
                log("点击了行走状态按钮");
            }
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
            log("点击了关闭程序");
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出吗？ ",
                                    " 提示",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                log("点击了关闭程序");
                System.Environment.Exit(0);
            }
        }

        private void MainWin_Load(object sender, EventArgs e)
        {
            //数据保存类初始化
            try
            {
                DataStoreManager.Initialize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HistoryDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
