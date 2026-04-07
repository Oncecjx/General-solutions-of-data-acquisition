using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralFrameSystem
{
    public class NPOIHelper
    {
        #region DataTable转成Excel并保存 SheetName表名称 txtPath路径
        /// <summary>
        /// DataTable转成Excel并保存 txtPath路径
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="SheetName"></param>
        /// <param name="txtPath"></param>
        /// <returns></returns>
        public static bool DataTableToExcel(DataTable dt, string SheetName, string txtPath)
        {
            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;
            try
            {
                //if (dt != null && dt.Rows.Count > 0)
                if (dt != null)
                {
                    workbook = new HSSFWorkbook();
                    sheet = workbook.CreateSheet(SheetName);//创建一个名称为Sheet0的表
                    int rowCount = dt.Rows.Count;//行数
                    int columnCount = dt.Columns.Count;//列数

                    //设置列头
                    row = sheet.CreateRow(0);//excel第一行设为列头
                    for (int c = 0; c < columnCount; c++)
                    {
                        cell = row.CreateCell(c);
                        cell.SetCellValue(dt.Columns[c].ColumnName);
                    }

                    //设置每行每列的单元格,
                    for (int i = 0; i < rowCount; i++)
                    {
                        row = sheet.CreateRow(i + 1);
                        for (int j = 0; j < columnCount; j++)
                        {
                            cell = row.CreateCell(j);//excel第二行开始写入数据
                            cell.SetCellValue(dt.Rows[i][j].ToString());
                        }
                    }
                    using (fs = File.OpenWrite(txtPath))
                    {
                        workbook.Write(fs);//向打开的这个xls文件中写入数据
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                return false;
            }

        }
        #endregion

    }
}
