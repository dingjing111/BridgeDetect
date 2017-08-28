using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.service;
using MetroFramework.Controls;
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
        AdamHelper adamHelper;
        public PouringState()
        {
            InitializeComponent();
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
            this.initialAdamHelper();
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshSteeveText();
            RefreshAnchorText();
            RefreshFrontPivotText();
        }
        /// <summary>
        /// 连接的模块
        /// </summary>
        private void initialAdamHelper()
        {
            List<AdamOperation> list = new List<AdamOperation>
            {
                new Adam6217Operation("192.168.1.3", 0)
            };

            try
            {
                AdamHelper.Initialize(list, 500);
                adamHelper = AdamHelper.GetInstance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.GetType());
            }

        }
      
       /// <summary>
       /// 给吊杆力和吊杆位移文本框赋值
       /// </summary>
        private void RefreshSteeveText()
        {
            Dictionary<int, Steeve> dicSteeve = adamHelper.steeveDic;//得到吊杆的字典集合，用方法得到力和位移
            double[] steeveForce = new double[dicSteeve.Count];//吊杆力数组，元素为double
            double[] steeveDis = new double[dicSteeve.Count];//吊杆位移数组，元素为double
           for (int i = 0; i < 4; i++)
            {
                steeveForce[i] = dicSteeve[i].GetForce();//为吊杆力数组赋值值
                steeveDis[i] = dicSteeve[i].GetDisplace();//为吊杆力位移数组赋值
            }          
            SetTextValueManager.SetValueToText(steeveForce, ref txtSteeveF1, ref txtSteeveF2, ref txtSteeveF3, ref txtSteeveF4, ref txtMaxSteeveForce, ref txtMaxSteeveForceDiff);
            SetTextValueManager.SetValueToText(steeveDis, ref txtSteeveDis1, ref txtSteeveDis2, ref txtSteeveDis3, ref txtSteeveDis4, ref txtMaxSteeveDis, ref txtMaxSteeveDisDiff);
         }
        /// <summary>
        /// 给锚杆力文本框赋值
        /// </summary>
        private void RefreshAnchorText()
        {
            Dictionary<int, Anchor> dicAnchor = adamHelper.anchorDic;
            double[] anchorForce = new double[dicAnchor.Count];
            for (int i = 0; i < 4; i++)
            {
                anchorForce[i] = dicAnchor[i].GetForce();
            }
           SetTextValueManager.SetValueToText(anchorForce, ref txtAnchorF1, ref txtAnchorF2, ref txtAnchorF3, ref txtAnchorF4, ref txtMaxAnchorForce, ref txtMaxAnchorForceDiff);
         

        }
        /// <summary>
        /// 给前支点位移文本框赋值
        /// </summary>
        private void RefreshFrontPivotText()
        {
            Dictionary<int, FrontPivot> dicFrontPivot = adamHelper.frontPivotDic;
            double[] frontPivotDis = new double[dicFrontPivot.Count];
            for (int i = 0; i < 2; i++)
            {
                frontPivotDis[i] = dicFrontPivot[i].GetDisplace();//数组存位移
            }
            txtFrontPivotDis1.Text = frontPivotDis[0].ToString();
            txtFrontPivotDis2.Text = frontPivotDis[1].ToString();
        }
        /// <summary>
        /// 行走后重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {

        }
        
        #region 将接收的数据存入数据库


        #endregion
    }
}
