using BridgeDetectSystem.util;
using PSW2NPOI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BridgeDetectSystem.service
{
    public class ExportToExcel
    {
        /// <summary>
        /// 导出excel文件
        /// </summary>
        /// <param name="sql">sql语句，为查询表的语句</param>
        /// <param name="path">保存excel文件的路径</param>
        public static void ExportData(DataTable dt)
        {
            NPOIHelper npoi = new NPOIHelper();
          
            try
            {
                npoi.ConvertTableToExcel(dt);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel文件|*.xls";
                saveFileDialog.FileName = ConvertToString(DateTime.Now);
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    npoi.WriteToFile(fs);
                    AutoClosingMessageBox.Show("表" + dt.TableName + "生成成功", 1500);
                    LoggerHelper.Log("导出界面", dt.TableName + "导出为Excel");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private static string ConvertToString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH-mm-ss ");
        }
    }
}
