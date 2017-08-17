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
using PSW2AdamTeach;

namespace BridgeDetectSystem
{
    public partial class TestForm : Form
    {
        WarningDialog warning;
        AdamHelper adamHelper;

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
                MessageBox.Show(ex.Message);
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
    }
}
