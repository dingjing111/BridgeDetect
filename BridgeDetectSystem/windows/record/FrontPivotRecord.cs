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
            this.panel2.Height = this.panel1.Height * 1/ 15;
        }
        string sql = "select * from FrontPivotDis";
       // RecreateRecordManager rrm = new RecreateRecordManager();
        private void FrontPivotRecord_Load(object sender, EventArgs e)
        {
            this.initial();
           
            try
            {
               // rrm.RecreateFrontPivotDis();
                OperateSql.LoadData(sql, dgv);


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

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            ExportToExcel.ExportData(sql);
           

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
