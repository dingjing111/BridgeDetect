using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BridgeDetectSystem.service;
using BridgeDetectSystem.util;
using BridgeDetectSystem.adam;

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

            Initialize(args);

            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK)
            {
                login.Close();
                Application.Run(new MainWin());
            }
        }

        private static void Initialize(string[] args)
        {
            bool recreate = false;
            bool isResetDb = false;

            if (args.Length > 0)
            {
                recreate = bool.Parse(args[0]);
                isResetDb = bool.Parse(args[1]);
            }

            //操作日志初始化
            log4net.Config.XmlConfigurator.Configure();

            //数据库初始化
            try
            {
                if (recreate)
                {
                    RecreateRecordManager.InitialDataBase();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化数据库表报错:" + ex.Message);
            }

            //配置初始化
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
                MessageBox.Show("配置初始化错误" + ex.Message);
            }



            var oper2 = new Adam6217Operation("192.168.1.190", 1);
            //浇筑状态接收线程初始化
            List <AdamOperation> list = new List<AdamOperation>
            {
                new Adam6217Operation("192.168.1.3", 0),
               // oper2
            };
          
            try
            {

                AdamHelper.Initialize(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

            //行走状态接收线程初始化
            try
            {
                AdamHelper2.Initialize(oper2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //数据保存类初始化
            //放到主窗体加载那里初始化
           

        }

    }
}
