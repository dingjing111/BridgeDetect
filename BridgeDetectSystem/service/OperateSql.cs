using BridgeDetectSystem.util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem.service
{
   public class OperateSql
    {
       
       
        private static volatile OperateSql instance;
        public static OperateSql GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("实例未初始化。");
            }
            return instance;
        }
        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="dgv">控件datagridview</param>
        public static void LoadData(string sql ,DataGridView dgv)
        {
            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            dgv.DataSource = dt;
            OperateSql.RemoveNULL(dgv);
            dgv.AutoGenerateColumns = false;
            dgv.Invalidate();
        }     
        /// <summary>
        /// 空列视为不可见
        /// </summary>
        /// <param name="dgv"></param>
        public static void RemoveNULL(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Rows[0].Cells[i].Value == System.DBNull.Value)
                {
                    dgv.Columns[i].Visible = false;
                }
            }
        }
        /// <summary>
        /// 插入一万条数据
        /// </summary>
        public static void InsertData()
        {
            int n = 10000;
            int r = -1;
            string insertSql = "insert into AnchorForce values(newid(),1.01,2.22,3.033,4.0,5,6,7,8.8,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'操作员',getdate())";
            DBHelper dbheler = DBHelper.GetInstance();
            while (n > 0)
            {
                r = dbheler.ExecuteNonQuery(insertSql, null);
                n = n - 1;
            }
            if (r > 0)
            {
                MessageBox.Show("插入一万条数据成功");
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public static void DeleteData()
        {
            string sql = "delete  from AnchorForce";
            DBHelper dbheler = DBHelper.GetInstance();
            int r = dbheler.ExecuteNonQuery(sql, null);
            if (r > 0)
            {
                MessageBox.Show("删除成功");
            }
        }
        
        

    }
}
