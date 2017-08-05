using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace BridgeDetectSystem
{
    public partial class UserRightWin : MetroFramework.Forms.MetroForm
    {
        public UserRightWin()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            this.initial();
        }

        #region 初始化窗体
        private void initial()
        {
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//窗体与屏幕一样大
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.panel2.Height = this.panel1.Height * 8 / 10;
            this.panel4.Height = this.panel1.Height / 15;
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewUserWin win = new AddNewUserWin();
            win.Show();
        }
    }
}
