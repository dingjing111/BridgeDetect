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

        #region 单列

        private static object obj = new object();
        private static WarningDialog instance;

        public static WarningDialog GetInstance()
        {
            if (instance == null)
            {
                lock (obj)
                {
                    if (instance == null)
                    {
                        instance = new WarningDialog();
                    }
                }
            }

            return instance;
        }

        #endregion

        public WarningDialog()
        {
            InitializeComponent();
        }

        private void WarningWin_Load(object sender, EventArgs e)
        {
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            sp.Stop();
            sp.Dispose();
            this.Close();
        }

        private void WarningDialog_Activated(object sender, EventArgs e)
        {
            sp.SoundLocation = GetPath();
            sp.PlayLooping();
        }

        private void WarningDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        internal void DoWork(object obj)
        {
            this.lblWarningText.Text = obj.ToString();

        }

        private static string GetPath()
        {
            string Path = @"../../warningwave\WarningVoice.wav";
            return Path;
        }
    }
}
