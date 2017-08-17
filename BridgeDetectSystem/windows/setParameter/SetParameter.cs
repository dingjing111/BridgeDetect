using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.service;

namespace BridgeDetectSystem
{
    public partial class SetParameter : MetroFramework.Forms.MetroForm
    {
        ConfigManager configManager;

        public SetParameter()
        {
            InitializeComponent();
            configManager = ConfigManager.GetInstance();
        }

        private void initial()
        {
            this.panel2.Width = this.panel1.Width / 2;
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);

            #region label显示设置

            lblUpDis.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.basket_upDisLimit);
            lblDownDis.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.basket_downDisLimit);
            lblAllowDisDiffLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.basket_allowDisDiffLimit);

            lblSteeveDisDiffLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.steeve_DisDiffLimit);
            lblSteeveForceLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.steeve_ForceLimit);
            lblSteeveForceDiffLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.steeve_ForceDiffLimit);

            lblAnchorForceLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.anchor_ForceLimit);
            lblAnchorForceDiffLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.anchor_ForceDiffLimit);

            lblFrontPivotDisLimit.Text = configManager.GetReadableName(ConfigManager.ConfigKeys.frontPivot_DisLimit);

            #endregion

            #region 设置的数值显示
            txtBasketUpDisLimit.Text = configManager.Get(ConfigManager.ConfigKeys.basket_upDisLimit).ToString("0.0");
            txtBasketDownDisLimit.Text = configManager.Get(ConfigManager.ConfigKeys.basket_downDisLimit).ToString("0.0");
            txtBasketAllowDisDiffLimit.Text = configManager.Get(ConfigManager.ConfigKeys.basket_allowDisDiffLimit).ToString("0.0");

            txtSteeveDisDiffLimit.Text = configManager.Get(ConfigManager.ConfigKeys.steeve_DisDiffLimit).ToString("0.0");
            txtSteeveForceUpLimit.Text = configManager.Get(ConfigManager.ConfigKeys.steeve_ForceLimit).ToString("0.0");
            txtSteeveForceDiffLimit.Text = configManager.Get(ConfigManager.ConfigKeys.steeve_ForceDiffLimit).ToString("0.0");

            txtAnchorForceLimit.Text = configManager.Get(ConfigManager.ConfigKeys.anchor_ForceLimit).ToString("0.0");
            txtAnchorForceDiffLimit.Text = configManager.Get(ConfigManager.ConfigKeys.anchor_ForceDiffLimit).ToString("0.0");

            txtFrontPivotDisLimit.Text = configManager.Get(ConfigManager.ConfigKeys.frontPivot_DisLimit).ToString("0.0");
            #endregion
        }

        private void SteeveParaSet_Load(object sender, EventArgs e)
        {
            this.initial();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetConfigValue();
                configManager.StoreConfigToDb();
                MessageBox.Show("报警设置保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetConfigValue()
        {
            double v1=0;
            try
            {
              v1 = double.Parse(txtBasketUpDisLimit.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Source); 
            }
            configManager.Set(ConfigManager.ConfigKeys.basket_upDisLimit,v1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
