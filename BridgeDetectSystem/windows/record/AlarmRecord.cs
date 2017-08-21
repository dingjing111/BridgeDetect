using BridgeDetectSystem.service;
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
    public partial class AlarmRecord : MetroFramework.Forms.MetroForm
    {
        public AlarmRecord()
        {
            InitializeComponent();
        }
        string sql = "select * from AlarmRecord";
        private void warn_Load(object sender, EventArgs e)
        {
            this.initial();
            
            try
            {
                OperateSql.LoadData(sql, dgv);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        #region 初始化窗体
        private void initial()
        {
           // this.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;//窗体与屏幕一样大
            //this.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            this.panel2.Height = this.panel1.Height * 8 / 10;
            this.panel4.Height = this.panel1.Height / 15;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //string path = @"D:\excelFile\报警记录.xls";
            ExportToExcel.ExportData(sql);
            
        }
    }
}
