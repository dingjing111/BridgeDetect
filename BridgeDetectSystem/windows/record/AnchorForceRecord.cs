using BridgeDetectSystem.service;
using BridgeDetectSystem.util;
using PSW2NPOI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace BridgeDetectSystem
{
    public partial class AnchorForceRecord : MetroFramework.Forms.MetroForm
    {
        public AnchorForceRecord()
        {
            InitializeComponent();
        }
        string sql = "select * from AnchorForce";
      
        private void AnchorForceWindow_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
             OperateSql.InsertData(); //插入数据 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            OperateSql.LoadData(sql, dgv);


        }
       
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                OperateSql.DeleteData();//删除数据
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                OperateSql.LoadData(sql,dgv);//加载数据
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            
            ExportToExcel.ExportData(sql);
           
        }

       

        
    }
}
