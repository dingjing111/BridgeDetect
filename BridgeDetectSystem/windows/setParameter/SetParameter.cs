using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.service;
using BridgeDetectSystem.util;

namespace BridgeDetectSystem
{
    public partial class SetParameter : MetroFramework.Forms.MetroForm
    {
        ConfigManager configManager;
        List<NumericUpDown> numericList;
        List<ConfigManager.ConfigKeys> configKeysList;

        public SetParameter()
        {
            InitializeComponent();
            configManager = ConfigManager.GetInstance();

            numericList = new List<NumericUpDown>()
            {
                txtBasketUpDisLimit,
                txtBasketDownDisLimit,
                txtBasketAllowDisDiffLimit,

                txtSteeveDisDiffLimit,
                txtSteeveForceUpLimit,
                txtSteeveForceDiffLimit,

                txtAnchorForceLimit,
                txtAnchorForceDiffLimit,
                txtFrontPivotDisLimit,
            };

            configKeysList = new List<ConfigManager.ConfigKeys>()
            {
                ConfigManager.ConfigKeys.basket_upDisLimit,
                ConfigManager.ConfigKeys.basket_downDisLimit,
                ConfigManager.ConfigKeys.basket_allowDisDiffLimit,

                ConfigManager.ConfigKeys.steeve_DisDiffLimit,
                ConfigManager.ConfigKeys.steeve_ForceLimit,
                ConfigManager.ConfigKeys.steeve_ForceDiffLimit,

                ConfigManager.ConfigKeys.anchor_ForceLimit,
                ConfigManager.ConfigKeys.anchor_ForceDiffLimit,
                ConfigManager.ConfigKeys.frontPivot_DisLimit,
            };
            SetNumericValue(numericList, configKeysList);
        }

        private void initial()
        {
            this.panel2.Width = this.panel1.Width / 2;
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);


           
        }

        private void SetNumericValue(List<NumericUpDown> numericList, List<ConfigManager.ConfigKeys> configKeysList)
        {
            for (int i = 0; i < numericList.Count; i++)
            {
                numericList[i].Maximum = Convert.ToDecimal(configManager.GetMaxValue(configKeysList[i]));
                numericList[i].Minimum = Convert.ToDecimal(configManager.GetMinValue(configKeysList[i]));
                numericList[i].Value = Convert.ToDecimal(configManager.Get(configKeysList[i]));
            }
        }


        private void SteeveParaSet_Load(object sender, EventArgs e)
        {
            initial();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SetConfigValue();
                configManager.StoreConfigToDb();
                AutoClosingMessageBox.Show("报警设置保存成功！", "提示", 1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetConfigValue()
        {
            for(int i = 0; i < numericList.Count; i++)
            {
                configManager.Set(configKeysList[i], Convert.ToDouble(numericList[i].Value));
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
