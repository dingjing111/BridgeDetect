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
        DataTable dt;
        string sql;

        private void steevedisplacement_Load(object sender, EventArgs e)
        {
            this.initial();
            sql = "select * from SteeveDisplacement";
            try
            {
                dt = OperateSql.LoadData(sql, dgv);//加载数据
                dt.TableName = "吊杆位移记录表";
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
            dt.Columns[0].ColumnName = "全局唯一标识符";
            dt.Columns[1].ColumnName = "时间";
            dt.Columns[2].ColumnName = "操作人";
            dt.Columns[3].ColumnName = "位置1";
            dt.Columns[4].ColumnName = "位置2";
            dt.Columns[5].ColumnName = "位置3";
            dt.Columns[6].ColumnName = "位置4";
            ExportToExcel.ExportData(dt);

        }
    }
}
