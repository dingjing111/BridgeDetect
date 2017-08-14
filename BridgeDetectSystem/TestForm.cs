using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.windows;
using BridgeDetectSystem.service;

namespace BridgeDetectSystem
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        WarningDialog warning;
        private void button1_Click(object sender, EventArgs e)
        {
            warning = WarningDialog.GetInstance();
            warning.Show();
            warning.TopMost = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            warning.Show();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            WarningDialogManager manager = new WarningDialogManager();
            manager.BgStart();
        }
    }
}
