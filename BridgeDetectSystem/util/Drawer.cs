using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.util
{
   public class Drawer
    {
        string constr = "Data Source=LAPTOP-O0S1M374;Initial Catalog=Userrights;Integrated Security=True";
      public  DataTable CreatData(string sqlQ)
        {
            DataTable dt = new DataTable();
            //实例化SqlConnection对象
            SqlConnection sqlCon = new SqlConnection();
            //实例化SqlConnection对象连接数据库的字符串
            sqlCon.ConnectionString = constr;
            //定义SQL语句
            //sql公用部分
            dt = GetDataTable(sqlQ);

            return dt;
        }
        public DataTable GetDataTable(string Sqlstr)
        {
            DataTable dt;
            SqlDataAdapter sda;
            SqlConnection sqlCon = new SqlConnection();
            //实例化SqlConnection对象连接数据库的字符串
            sqlCon.ConnectionString = constr;
            sqlCon.Open();
            sda = new SqlDataAdapter(Sqlstr, constr);
            //sda.SelectCommand.CommandTimeout = 120;
            dt = new DataTable();
            sda.Fill(dt);
            sqlCon.Close();
            return dt;
        }
    }
}
