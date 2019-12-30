using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BridgeDetectSystem.service;

namespace BridgeDetectSystem
{
    public partial class FrontPivotRecord : MetroFramework.Forms.MetroForm
    {
        public FrontPivotRecord()
        {
            InitializeComponent();
        }
        private void initial()
        {
            this.panel2.Height = this.panel1.Height * 1 / 15;
        }
        DataTable dt;
        string sql = "select * from FrontPivotDis";

        private void FrontPivotRecord_Load(object sender, EventArgs e)
        {
            this.initial();

            try
            {
                dt = OperateSql.LoadData(sql, dgv);
                dt.TableName = "前支点数据记录表";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
