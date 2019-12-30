﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using MetroFramework.Forms;
using BridgeDetectSystem.service;
using BridgeDetectSystem.util;

namespace BridgeDetectSystem
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        #region 初始化窗体方法

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.initial();
        }

        private void initial()
        {

            this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//窗体与屏幕一样大
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;

            this.panel1.Height = this.Height / 3;//登陆框面板
            this.pictureBox1.Width = this.Width;
            this.panel1.Width = this.Width;//图片框面板
            this.panel3.Width = this.panel1.Width;
            this.panel2.Height = this.pictureBox1.Height / 20;
            panel2.Parent = pictureBox1;//字透明，在图片框上
            panel2.BackColor = Color.Transparent;
            label1.Parent = panel2;
            label1.BackColor = Color.Transparent;
            this.panel2.Width = this.panel3.Width;
            this.panel2.Height = this.panel3.Height / 2;
            this.label1.Location = new System.Drawing.Point(this.panel2.Width / 7, this.panel2.Height / 4);
            this.btnConfirm.Width = 60;
            this.btnConfirm.Height = 30;
            this.btnCancel.Width = 60;
            this.btnCancel.Height = 30;
            this.metroLabel1.Width = 40;
            this.metroLabel1.Height = 30;
            this.metroLabel2.Width = 40;
            this.metroLabel2.Height = 30;
            this.txtUserName.Width = 120;
            this.txtUserName.Height = 30;
            this.txtPassword.Width = 120;
            this.txtPassword.Height = 30;

            this.metroLabel1.Location = new System.Drawing.Point(this.panel1.Width * 15 / 80, this.panel1.Height / 10);
            this.txtUserName.Location = new System.Drawing.Point(this.panel1.Width * 20 / 80, this.panel1.Height / 10);
            this.metroLabel2.Location = new System.Drawing.Point(this.panel1.Width * 35 / 80, this.panel1.Height / 10);
            this.txtPassword.Location = new System.Drawing.Point(this.panel1.Width * 40 / 80, this.panel1.Height / 10);
            this.btnConfirm.Location = new System.Drawing.Point(this.panel1.Width * 55 / 80, this.panel1.Height / 10);
            this.btnCancel.Location = new System.Drawing.Point(this.panel1.Width * 62 / 80, this.panel1.Height / 10);
        }

        #endregion

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            string userName = this.txtUserName.Text;
            string password = this.txtPassword.Text;

            UserRightManager.Initial(userName, password);
            UserRightManager manager = UserRightManager.GetInstance();
            
            try
            {
                if (manager.Check())
                {
                    this.DialogResult = DialogResult.OK;
                    LoggerHelper.Log("登入", userName + "成功登入");
                }
                else
                {
                    MessageBox.Show("账号或密码错误，请重新输入");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
          

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            testform222 f = new testform222();
            f.Show();
        }
    }
}
