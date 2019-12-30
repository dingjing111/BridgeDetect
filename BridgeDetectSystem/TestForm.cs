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
using System.Reflection;
using BridgeDetectSystem.adam;
using System.Threading;

namespace BridgeDetectSystem
{
    public partial class TestForm : Form
    {
        WarningDialog warningDialog;
        AdamHelper adamHelper;
        ConfigManager configManager;
        WarningManager warningManager;
        DBHelper dbhelper = DBHelper.GetInstance();
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
                AdamHelper.Initialize(list);
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

            try
            {
                warningManager = WarningManager.GetInstance();
                warningDialog = WarningDialog.GetInstance(warningManager);
                configManager = ConfigManager.GetInstance();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            warningDialog.Show();
            warningDialog.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            warningDialog.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            warningManager.BgStart();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
             { 
                 int count = 1;
                 while (count++ <= 10)
                 {
                     var dic = adamHelper.steeveDic;
                     StringBuilder sb = new StringBuilder();
                     foreach (var d in dic)
                     {
                         sb.Append("key: " + d.Key).Append("; value: " + d.Value.GetForce() + "|" + d.Value.GetDisplace());
                         sb.Append("\n");
                     }
                     MessageBox.Show(sb.ToString());
                     Thread.Sleep(200);
                 }
             });
            th.IsBackground = true;
            th.Start();
        }

        private void button5_Click(object sender, EventArgs e)
        {
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            PouringState ps = new PouringState();
            ps.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AlarmRecord win = new AlarmRecord();
            win.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
