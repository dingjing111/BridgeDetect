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
    public partial class WarningDialog : MetroFramework.Forms.MetroForm
    {
        SoundPlayer sp = new SoundPlayer();

        #region 单例
        private WarningManager manager;
        private static object obj = new object();
        private static WarningDialog instance;

        public static WarningDialog GetInstance(WarningManager manager)
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new WarningDialog(manager);
                    }
                }
            }

            return instance;
        }

        #endregion

        public WarningDialog(WarningManager manager)
        {
            InitializeComponent();
            this.manager = manager;
           // this.pictureBox1.Image = i;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            StopSound();

            manager.ContinueThread();

            this.Close();
        }

        private void WarningDialog_Activated(object sender, EventArgs e)
        {
            PlaySound();
        }

        private void WarningDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
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

        //由报警管理类WarningDialogManager调用，传入参数为报警信息
        public void DoWork(object obj)
        {
            var list = obj as List<string>;
            
            listBoxWarning.Items.Clear();
            foreach (string str in list)
            {
                listBoxWarning.Items.Add(str);
            }

        }

        private void WarningDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
