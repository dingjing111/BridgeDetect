using BridgeDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem.windows
{
    public partial class WarningDialog2 : MetroFramework.Forms.MetroForm
    {
        SoundPlayer sp = new SoundPlayer();

        #region 单例
        private WarningManager2 manager;
        private static object obj = new object();
        private static WarningDialog2 instance;

        public static WarningDialog2 GetInstance(WarningManager2 manager)
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new WarningDialog2(manager);
                    }
                }
            }

            return instance;
        }

        #endregion

        public WarningDialog2(WarningManager2 manager)
        {
            InitializeComponent();
            this.manager = manager;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            StopSound();

            manager.ContinueThread();

            this.Close();
        }

        private void WarningDialog2_Activated(object sender, EventArgs e)
        {
            PlaySound();
        }

      

        private void PlaySound()
        {
            string Path = @"../../warningwave\WarningVoice.wav";
            sp.SoundLocation = Path;
            sp.PlayLooping();
        }

        private void StopSound()
        {
            sp.Stop();
            sp.Dispose();
        }

        //由报警管理类WarningDialog2Manager调用，传入参数为报警信息
        public void DoWork(object obj)
        {
            var list = obj as List<string>;

            foreach(string str in list)
            {
                listBoxWarning.Items.Add(str);
            }

        }

        private void WarningDialog2_Load(object sender, EventArgs e)
        {

        }
    }
}
