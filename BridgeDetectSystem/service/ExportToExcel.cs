using BridgeDetectSystem.util;
using PSW2NPOI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace BridgeDetectSystem.service
{
   public class ExportToExcel
    {   /// <summary>
    /// 导出excel文件
    /// </summary>
    /// <param name="sql">sql语句，为查询表的语句</param>
    /// <param name="path">保存excel文件的路径</param>
        public static void ExportData (String sql,string path)
        {
            NPOIHelper NP = new NPOIHelper();
            DBHelper dbhelper = DBHelper.GetInstance();
            DataTable dt = dbhelper.ExecuteSqlDataAdapter(sql, null, 0);
            NP.ConvertTableToExcel(dt);
            FileStream file = new FileStream(path, FileMode.Create);
            NP.WriteToFile(file);
        }
       
    }
}
