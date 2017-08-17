using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using BridgeDetectSystem.windows;
using BridgeDetectSystem.service;
using BridgeDetectSystem.util;
using PSW2AdamTeach;
using System.Reflection;

namespace BridgeDetectSystem
{
    public partial class TestForm : Form
    {
        WarningDialog warning;
        AdamHelper adamHelper;
        ConfigManager configManager;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
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

            bool isResetDb = true;
            try
            {
                DBHelper dbHelper = DBHelper.GetInstance();
                if (isResetDb)
                {
                    ConfigManager.Initialize(dbHelper, false);
                    ConfigManager.GetInstance().RecreateDbTable();
                }
                else
                {
                    ConfigManager.Initialize(dbHelper);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"无法初始化配置管理系统，程序将退出。\n错误:\n {ex.Message}\n {ex.StackTrace}",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            warning = WarningDialog.GetInstance();
            warning.Show();
            warning.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            warning.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            WarningDialogManager manager = new WarningDialogManager();
            manager.BgStart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (true)
            {
                var dic = adamHelper.steeveDic;
                StringBuilder sb = new StringBuilder();
                foreach (var d in dic)
                {
                    sb.Append("key: " + d.Key).Append("; value: " + d.Value.GetForce() + "|" + d.Value.GetDisplace());
                    sb.Append("\n");
                }
                MessageBox.Show(sb.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            configManager = ConfigManager.GetInstance();
            configManager.StoreConfigToDb();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetParameter setParam = new SetParameter();
            setParam.Show();

            Type type = MethodBase.GetCurrentMethod().DeclaringType;
            ILog log = LogManager.GetLogger("参数设置");
            string str = "hello";
            log.Info(str);
        }
    }
}
