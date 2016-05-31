using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace Repositories.cs.Helpers
{
    public class DataHelper
    {
        #region Vars
        private Excel.Application excelApp;
        private Excel.Workbook book;
        private Excel._Worksheet sheet;
        private Excel.Range range;
        private const string folder = @"C:\TestData\";
        private const string excelName = "ConsolidatedDataExcel.xlsx";
        #endregion

        #region Columns
        public List<string> columns = new List<string>
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "AA",
            "AB",
            "AC",
            "AD",
            "AE",
            "AF",
            "AG",
            "AH",
            "AI",
            "AJ",
            "AK",
            "AL",
            "AM",
            "AN",
            "AO",
            "AP",
            "AQ",
            "AR",
            "AS",
            "AT",
            "AU",
            "AV",
            "AW",
            "AX",
            "AY",
            "AZ",
            "BA",
            "BB",
            "BC",
            "BD",
            "BE",
            "BF",
            "BG",
            "BH",
            "BI",
            "BJ",
            "BK",
            "BL",
            "BM",
            "BN",
            "BO",
            "BP",
            "BQ",
            "BR",
            "BS",
            "BT",
            "BU",
            "BV",
            "BW",
            "BX",
            "BY",
            "BZ"
        };

        #endregion

        /// <summary>
        /// Opens the DataExcel in "folder".
        /// </summary>
        public void Open()
        {
            if ((excelApp == null) || (!excelApp.Visible))
            {
                excelApp = new Excel.Application();
                excelApp.Visible = true;
                book = excelApp.Workbooks.Open(folder + excelName, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", true, false, 0, true, 1, 0);
                sheet = (Excel._Worksheet)book.Sheets[1];
                range = sheet.UsedRange;
            }
        }

        public void Save()
        {
            book.Save();
        }

        /// <summary>
        /// Selects wanted sheet in Excel file. 
        /// </summary>
        /// <param name="sheet"></param>
        public void SelectSheet(int sheet)
        {
            ((Excel.Worksheet)this.excelApp.ActiveWorkbook.Sheets[sheet]).Select();
        }

        /// <summary>
        /// Selects wanted sheet in Excel file by name. 
        /// </summary>
        /// <param name="name"></param>
        public void SelectSheetByName(string name)
        {
            sheet = (Excel.Worksheet)book.Sheets[name];
            sheet.Select();
            range = sheet.UsedRange;
        }

        /// <summary>
        /// Closes the Excel app.
        /// </summary>
        public void Close()
        {
            excelApp.Quit();
        }

        /// <summary>
        /// Writes the "data" in "cell"
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="data"></param>
        public void Write(string cell, string data)
        {
                this.excelApp.Range[cell.ToUpper()].Value = data;
        }

        /// <summary>
        ///Reads "cell"
        ///For example, B11, W34, LU89, etc..
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public string Read(string cell)
        {
            return Convert.ToString(this.excelApp.Range[cell.ToUpper()].Text);
        }

        /// <summary>
        /// Reads DropDown values in "cell" 
        ///For example, B11, W34, LU89, etc..
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public string Read_DropDown(string cell)
        {
            return Convert.ToString(this.excelApp.Range[cell.ToUpper()].Validation.Formula1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentColumn"></param>
        /// <returns></returns>
        public string NextColumn(string currentColumn)
        {
            int nextIndex = this.columns.IndexOf(currentColumn) + 1;
            return this.columns[nextIndex];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int GetRowCondition(string s)
        {
            for (var i = 1; i <= range.Rows.Count; i++)
            {
                if (s.Equals(Read("A" + i))) return i;
            }
            throw new Exception("Row " + s + " Not founded in CSV");
        }

        public List<int> GetRowsByColumnAndValue(string keyColumnName, string keyValue)
        {
            List<int> rowsIndex = new List<int>();

            for (var i = 1; i <= range.Rows.Count; i++)
            {
                if (keyValue.Equals(Read(GetColumnbyName(keyColumnName) + i))) rowsIndex.Add(i);
            }

            return rowsIndex;
        }

        public int GetActualSheetRowsCount()
        {
            return range.Rows.Count;
        }

        public List<string> GetFirstRowNamesList()
        {
            List<string> names = new List<string>();
            for (var i = 1; i <= range.Columns.Count; i++)
            {
                names.Add(sheet.Cells[1, i].Value);
            }
            return names;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string GetColumnbyName(string columnName)
        {
            foreach (var column in columns)
            {
                if (columnName.Equals(Read(column + "1"))) return column;
            }
            throw new Exception("Column " + columnName + " Not founded in CSV");
        }
    }
}
