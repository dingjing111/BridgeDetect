using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.Util;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;

namespace PSW2NPOI
{
    public class NPOIHelper
    {
        static HSSFWorkbook workBook;

        public NPOIHelper()
        {
            workBook = new HSSFWorkbook();
        }

        /// <summary>
        /// 转换datatable数据为Excel表格
        /// </summary>
        /// <param name="dt"></param>
        public void ConvertTableToExcel(DataTable dt,string tableName=null)
        {
            HSSFSheet sheet;

            if (!string.IsNullOrEmpty(tableName))
            {
                sheet = (HSSFSheet)workBook.CreateSheet(tableName);
            }
            else if (!string.IsNullOrEmpty(dt.TableName))
            {
                sheet = (HSSFSheet)workBook.CreateSheet(dt.TableName);
            }
            else
            {
                sheet = (HSSFSheet)workBook.CreateSheet(DateTime.Now.ToString("t"));
            }

            //标题行
            HSSFRow title = (HSSFRow)sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                title.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
            }

            //正文内容
            for (int i = 1; i < dt.Rows.Count; i++)
            {
                HSSFRow row = (HSSFRow)sheet.CreateRow(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    row.CreateCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }
        }

        /// <summary>
        /// 转换DataSet中每张datatable数据为Excel表格
        /// </summary>
        /// <param name="ds"></param>
        public void ConvertTableToExcel(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                ConvertTableToExcel(dt);
            }
        }

        /// <summary>
        /// 生成Excel文件
        /// </summary>
        /// <param name="filePath"></param>
        public void WriteToFile(FileStream fileStream)
        {
            workBook.Write(fileStream);
            fileStream.Close();
        }

    }
}
