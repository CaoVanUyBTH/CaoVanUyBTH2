using System.Reflection;
using System.Data;
using OfficeOpenXml;
namespace CaoVanUyBTH2.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //create a list to hold the column names
            List<string> columNames = new List<string>();
            //needed to keep track of emty column headers
            int currentColumn = 1;
            //loop all columns in the sheet and them to the datatable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columName = cell.Text.Trim();
                //check if the previous header was empty and add if it was
                if (cell.Start.Column != currentColumn)
                {
                    columNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                //add the column name to the list to count the duplicates
                columnNames.Add(columName);
                
            }
        }
    }
}