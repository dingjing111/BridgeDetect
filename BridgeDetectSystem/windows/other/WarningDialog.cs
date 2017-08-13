using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class WarningDialog : Form
    {
        public WarningDialog()
        {
            InitializeComponent();
        }

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

        SoundPlayer sp = new SoundPlayer();
        private void WarningDialog_Load(object sender, EventArgs e)
        {
            
            sp.SoundLocation = @"C:\Users\dingjing\Desktop\warningsound\2.wav";
            sp.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sp.Stop();
            sp.Dispose();
            this.Close();
        }

        internal static void DoWork(object obj)
        {
            throw new NotImplementedException();
        }

        private void WarningDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
