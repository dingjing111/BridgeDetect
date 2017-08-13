using BridgeDetectSystem.dao;
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
    public partial class AnchorForceRecord : MetroFramework.Forms.MetroForm
    {
        public AnchorForceRecord()
        {
            InitializeComponent();
        }

        private void AnchorForceWindow_Load(object sender, EventArgs e)
        {
            this.initial();
            loaddata();


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
        /// <summary>
        /// 插入一万条数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int n = 10000;
            int r = -1;
            string insertSql = "insert into test2 values(newid(),1.01,2.0,3,4,5,6,7,8,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'操作员',getdate())";
            DBHelper dbheler = DBHelper.GetInstance();
            while (n > 0)
            {


                 r = dbheler.ExecuteNonQuery(insertSql, null);
                n = n - 1;
            }
            if (r > 0) { MessageBox.Show("插入一万条数据成功"); }
            loaddata();
              
           
        }
        private void loaddata()                 //加载数据
        {
            DBHelper dbheler = DBHelper.GetInstance();
            string sql = "select * from test2";
            DataTable dt = dbheler.ExecuteSqlDataAdapter(sql, null, 0);
            dgv.DataSource = dt;
            dgv.AutoGenerateColumns = false;
            dgv.Invalidate();
        }

        private void btnDel_Click(object sender, EventArgs e)//删除数据
        {
            string sql = "delete  from test2";
            DBHelper dbheler = DBHelper.GetInstance();
            int r = dbheler.ExecuteNonQuery(sql, null);
            if (r > 0)
            {
                MessageBox.Show("删除成功");
            }
            loaddata();
        }

        private void dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
