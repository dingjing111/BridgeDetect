using BridgeDetectSystem.adam;
using BridgeDetectSystem.entity;
using BridgeDetectSystem.service;
using BridgeDetectSystem.windows.work;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class PouringState : MetroFramework.Forms.MetroForm
    {
        AdamHelper adamHelper;
        DataStoreManager dataStoreManager;
        WarningManager warningManager;
        ConfigManager config;
        double steeveForceLimit;
        double steeveForceDiffLimit;
        double steeveDisLimit;
        double steeveDisDiffLimit;
        double anchorForceLimit;
        double anchorForceDiffLimit;
        double FrontDisLimit;
        double basketupDisLimit;
        double allowDisDiffLimit;
        double firstStandard;
        double secondStanard;
        double threeStandard;
        double fourStandard;
        public PouringState()
        {
            InitializeComponent();
            adamHelper = AdamHelper.GetInstance();//数据接收线程
            dataStoreManager = DataStoreManager.GetInstance();//数据保存线程
            warningManager = WarningManager.GetInstance();//报警线程
            config = ConfigManager.GetInstance();//配置项
            //timer1.Enabled = false;
        }

        private void PourState_Load(object sender, EventArgs e)
        {
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
            this.panel2.Width = this.panel1.Width / 2;
            this.panel4.Height = (this.panel1.Height - menuStrip1.Height) / 2;
            this.panel6.Height = (this.panel1.Height - menuStrip1.Height) / 2;
            //this.panel8.Width = this.panel7.Width / 2;


            //得到配置项的值
            steeveForceLimit = config.Get(ConfigManager.ConfigKeys.steeve_ForceLimit);
            steeveForceDiffLimit = config.Get(ConfigManager.ConfigKeys.steeve_ForceDiffLimit);
            basketupDisLimit = config.Get(ConfigManager.ConfigKeys.basket_upDisLimit);
            allowDisDiffLimit = config.Get(ConfigManager.ConfigKeys.basket_allowDisDiffLimit);
            steeveDisLimit = basketupDisLimit + allowDisDiffLimit;
            steeveDisDiffLimit = config.Get(ConfigManager.ConfigKeys.steeve_DisDiffLimit);
            anchorForceLimit = config.Get(ConfigManager.ConfigKeys.anchor_ForceLimit);
            anchorForceDiffLimit = config.Get(ConfigManager.ConfigKeys.anchor_ForceDiffLimit);
            FrontDisLimit = config.Get(ConfigManager.ConfigKeys.frontPivot_DisLimit);
            // 开始接收数据
            timer1.Enabled = true;
            adamHelper.StartTimer(250);
            dataStoreManager.StartTimer(500, 1000);
            warningManager.BgStart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            RefreshSteeveText();
            // RefreshAnchorText();
            RefreshFrontPivotText();

        }
        /// <summary>
        /// 关闭窗体时关闭线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PouringState_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataStoreManager != null)
            {
                dataStoreManager.StopTimer();
            }
            if (adamHelper != null)
            {
                adamHelper.StopTimer();
            }
            if (warningManager != null && warningManager.isStart)
            {
                warningManager.BgCancel();
            }
        }

        #region 数据显示和重置按钮
        /// <summary>
        /// 给吊杆力和吊杆位移文本框赋值
        /// </summary>
        private void RefreshSteeveText()
        {
            try
            {  //自己加吊杆锚杆互换
                Dictionary<int, Steeve> dicSteeve = adamHelper.steeveDic;//得到吊杆的字典集合，用方法得到力和位移


                double[] steeveForce = new double[dicSteeve.Count];//吊杆力数组，元素为double
                double[] steeveDis = new double[dicSteeve.Count];//吊杆位移数组，元素为double
                double[] realSteeveDis = new double[4];


                for (int i = 0; i < 4; i++)
                {
                    steeveForce[i] = dicSteeve[i].GetForce();//为吊杆力数组赋值值
                    realSteeveDis[i] = Math.Round(dicSteeve[i].GetDisplace(), 1);//真实距离
                    steeveDis[i] = dicSteeve[i].GetDisplace() - adamHelper.standardlist[i];//升降位移
                    steeveDis[i] = Math.Round(steeveDis[i], 1);  //保留一位小数

                }
                double sum = 0;
                for (int i = 0; i < 4; i++)
                {
                    sum += steeveDis[i];//求上升位移和
                }
                double AverageOfFour = Math.Round(sum / 4, 1);

                //平均上升位移
                SetTextValueManager.SetValueToText(steeveForce, ref txtSteeveF1, ref txtSteeveF2, ref txtSteeveF3, ref txtSteeveF4, ref txtMaxSteeveForce, ref txtMaxSteeveForceDiff);
                txtSteeveForceLimit.Text = steeveForceLimit.ToString();
                txtSteeveForceDiffLimit.Text = steeveForceDiffLimit.ToString();

                SetTextValueManager.SetValueToText(steeveDis, ref txtSteeveDis1, ref txtSteeveDis2, ref txtSteeveDis3, ref txtSteeveDis4, ref txtMaxSteeveDis, ref txtMaxSteeveDisDiff);

                txtSteeveDisLimit.Text = steeveDisLimit.ToString();//吊杆位移上限
                txtSteeveDisDiffLimit.Text = steeveDisDiffLimit.ToString();//吊杆位移差上限
                //
                txtSteeveDis9.Text = realSteeveDis[0].ToString();//真实距离和平均位移赋值
                txtSteeveDis10.Text = realSteeveDis[1].ToString();
                txtSteeveDis11.Text = realSteeveDis[2].ToString();
                txtSteeveDis12.Text = realSteeveDis[3].ToString();
                txtAver.Text = AverageOfFour.ToString();
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("采集吊杆力，位移数据失败，请检查硬件后重启软件。" + ex.Message);
            }
        }

        /// <summary>
        /// 给锚杆力文本框赋值
        /// </summary>
        private void RefreshAnchorText()
        {
            // Dictionary<int, Anchor> dicAnchor = adamHelper.anchorDic;
            try
            {

                Dictionary<int, Anchor> dicAnchor = adamHelper.anchorDic;
                double[] anchorForce = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    anchorForce[i] = dicAnchor[i].GetForce();
                }
                SetTextValueManager.SetValueToText(anchorForce, ref txtAnchorF1, ref txtAnchorF2, ref txtAnchorF3, ref txtAnchorF4, ref txtMaxAnchorForce, ref txtMaxAnchorForceDiff);
                txtAnchorForceLimit.Text = anchorForceLimit.ToString();
                txtAnchorForceDiffLimit.Text = anchorForceDiffLimit.ToString();
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("采集锚杆力数据失败，请检查硬件后重启软件。" + ex.Message);
            }
        }

        /// <summary>
        /// 给前支点位移文本框赋值
        /// </summary>
        private void RefreshFrontPivotText()
        {
            try
            {
                firstStandard = adamHelper.first_frontPivotDisStandard;
                secondStanard = adamHelper.second_frontPivotDisStandard;
                threeStandard = adamHelper.three_standard;
                fourStandard = adamHelper.four_standard;
                Dictionary<int, FrontPivot> dicFrontPivot = adamHelper.frontPivotDic;
                double[] frontPivotDis = new double[4];//前支点沉降位移

                double[] realFront = new double[4];//真实距离
                for (int i = 0; i < 4; i++)
                {
                    realFront[i] = dicFrontPivot[i].GetDisplace();
                    realFront[i] = Math.Round(realFront[i], 1);

                }
                frontPivotDis[0] = Math.Round(firstStandard - dicFrontPivot[0].GetDisplace(), 1);
                frontPivotDis[1] = Math.Round(secondStanard - dicFrontPivot[1].GetDisplace(), 1);
                frontPivotDis[2] = Math.Round(threeStandard - dicFrontPivot[2].GetDisplace(), 1);
                frontPivotDis[3] = Math.Round(fourStandard - dicFrontPivot[3].GetDisplace(), 1);
                for (int k = 0; k < 4; k++)
                {
                    frontPivotDis[k] = Math.Abs(frontPivotDis[k]);
                }

                double maxfront = frontPivotDis.Max();
                txtFrontPivotDis1.Text = frontPivotDis[0].ToString();
                txtFrontPivotDis2.Text = frontPivotDis[1].ToString();
                txtFrontPivotDis3.Text = frontPivotDis[2].ToString();
                txtFrontPivotDis4.Text = frontPivotDis[3].ToString();
                SetTextValueManager.set4(realFront, ref txtReal1, ref txtReal2, ref txtReal3, ref txtReal4);
                txtMaxFrontDis.Text = maxfront.ToString();
                txtFrontDisLimit.Text = FrontDisLimit.ToString();


            }

            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show("采集前支点位移数据失败，请检查硬件后重启软件。" + ex.Message);
            }
        }



        #endregion

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
        private void btnFront_Click(object sender, EventArgs e)
        {
            FrontDisWin win = new FrontDisWin();
            win.Show();
        }

        private void btnSteeveForce_Click(object sender, EventArgs e)
        {
            SteeveForceWin f = new SteeveForceWin();
            f.Show();

        }

        /// <summary>
        /// 重置吊杆基准点，清空SteeveStandard表，重新读取位移基准
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReSetSteeveStandard_Click_1(object sender, EventArgs e)
        {
            string sqlstr = "delete from SteeveStandard";
            ResetRead(sqlstr);
            
        }
        /// <summary>
        /// 重置前支架基准点位移，删FrontStandard。重新读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetFrontStandard_Click(object sender, EventArgs e)
        {
            string sql = "delete from FrontStandard";
            ResetRead(sql);
        }
        /// <summary>
        /// 删基准表，重置
        /// </summary>
        /// <param name="sql"></param>
        private void ResetRead(string sql)
        {
            if (dataStoreManager != null)
            {
                dataStoreManager.StopTimer();
            }
            if (adamHelper != null)
            {
                adamHelper.StopTimer();
            }

            Thread.Sleep(200);

            try
            {
                OperateSql.deleteTable(sql);
                adamHelper.StartTimer(250);//重新开始读取
                dataStoreManager.StartTimer(500, 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("重置发生错误" + ex.Message);
            }
        }
    }
    #endregion
}
