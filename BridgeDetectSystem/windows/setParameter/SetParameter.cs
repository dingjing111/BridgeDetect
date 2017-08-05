using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class SetParameter : MetroFramework.Forms.MetroForm
    {
        public SetParameter()
        {
            InitializeComponent();
        }
        private void initial()
        {
            this.panel2.Width = this.panel1.Width / 2;
            this.panel1.BackColor = Color.FromArgb(255, 50, 161, 206);
        }
        private void SteeveParaSet_Load(object sender, EventArgs e)
        {
            this.initial();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定退出吗？ ",
                                    " 提示",
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }

     
        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
