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
    public partial class WarningWin : MetroFramework.Forms.MetroForm
    {
        public WarningWin()
        {
            InitializeComponent();
        }

        private void WarningWin_Load(object sender, EventArgs e)
        {
            sp.SoundLocation = GetPath();
            sp.PlayLooping();
        }
        SoundPlayer sp = new SoundPlayer();
       

        private void button1_Click(object sender, EventArgs e)
        {
            sp.Stop();
            sp.Dispose();
            this.Close();
        }
        private static string GetPath()
        {
            string Path = @"../../warningwave\WarningVoice.wav";
            return Path;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
