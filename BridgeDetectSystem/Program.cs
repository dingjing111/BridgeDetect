using BridgeDetectSystem.adam;
using BridgeDetectSystem.service;
using BridgeDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Login login = new Login();
            //if (login.ShowDialog() == DialogResult.OK)
            //{
            //    login.Close();

            //    Initialize();

            //    Application.Run(new MainWin());
            //}

            TestForm testform = new TestForm();
            Application.Run(testform);
        }

        static void Initialize()
        {
            List<AdamOperation> list = new List<AdamOperation>
            {
                new Adam6217Operation("192.168.1.3", 0)
            };

            try
            {
                AdamHelper.Initialize(list, 500);
                AdamHelper adamHelper = AdamHelper.GetInstance();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.GetType());
                Environment.Exit(0);
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
                Environment.Exit(0);
            }
        }
    }
}
