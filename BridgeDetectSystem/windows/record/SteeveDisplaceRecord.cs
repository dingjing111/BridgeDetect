using BridgeDetectSystem.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem
{
    public partial class SteeveDisplaceRecord : MetroFramework.Forms.MetroForm
    {
        public SteeveDisplaceRecord()
        {
            InitializeComponent();
        }
        string sql = "select * from SteeveDisplacement";
        private void steevedisplacement_Load(object sender, EventArgs e)
        {
            this.initial();
           
            try
            {
                OperateSql.LoadData(sql,dgv);//加载数据
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #region 初始化窗体
        private void initial()
        {
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//窗体与屏幕一样大
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.panel2.Height = this.panel1.Height * 8 / 10;
            this.panel4.Height = this.panel1.Height / 15;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
          
            ExportToExcel.ExportData(sql);
          
        }
    }
}
