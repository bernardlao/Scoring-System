using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Runtime.InteropServices;
using MyClassCollection;

namespace MyExcelClass
{
    class MyExcel
    {
        MySQLDBUtilities db = new MySQLDBUtilities();
        //User-defined values for printing.
        public enum ShowCommands : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_FORCEMINIMIZE = 11,
            SW_MAX = 11
        }

        [DllImport("shell32.dll")]
        static extern IntPtr ShellExecute(
            IntPtr hwnd,
            string lpOperation,
            string lpFile,
            string lpParameters,
            string lpDirectory,
            ShowCommands nShowCmd);

        public MyExcel()
        {

        }

        public void PrintToExcel(List<ListViewItem> items, string filter, string order)
        {
            Excel.Application oXL;
            Excel.Workbook oWB;
            Excel.Worksheet oSheet;
            Excel.Range oRng;
            object oMissing = Missing.Value;

            try
            {
                //Start Excel and get Application object.
                oXL = new Excel.Application();
                oXL.Visible = true;

                //Get a new workbook.
                oWB = oXL.Workbooks._Open(@Environment.CurrentDirectory + "\\template.xlsx", oMissing, oMissing, oMissing,
                                          oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                          oMissing, oMissing, oMissing);

                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                //oSheet.Cells[row,col] = " data "
                CreateHeader(oSheet);
                oSheet.Cells[3, 10] = DateTime.Now.ToString("MM-dd-yyyy");
                oSheet.Cells[3, 2] = filter;
                oSheet.Cells[3, 6] = order;
                PopulateData(oSheet, items);
                if (!System.IO.Directory.Exists("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Print Files\\"))
                    System.IO.Directory.CreateDirectory("C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Print Files\\");
                string path = "C:\\Users\\" + Environment.UserName + "\\Documents\\Scoring System\\Print Files\\Tally" + DateTime.Now.ToShortDateString().Replace("/", "") + DateTime.Now.ToLongTimeString().Replace(":", "") + ".xlsx";
                
                oWB.SaveAs(path,
                          oMissing, oMissing, oMissing, oMissing,
                          oMissing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                          oMissing, oMissing, oMissing, oMissing, oMissing);
                
                //Print(path);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void CreateHeader(Excel._Worksheet oSheet)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Excel.Range wSRange;

            DataTable dtCriterias = db.SelectTable("SELECT * FROM tblcriteria");

            int col = 3;
            string prefix = "";
            int prefCount = 0;
            oSheet.Cells[5, 1] = "C#";
            wSRange = oSheet.get_Range("A5", "A5");
            wSRange.MergeCells = true;
            wSRange.Borders.Color = System.Drawing.Color.Black;
            oSheet.Cells[5, 2] = "Contestant Name";
            wSRange = oSheet.get_Range("B5", "C5");
            wSRange.MergeCells = true;
            wSRange.Borders.Color = System.Drawing.Color.Black;
            for (int i = 0; i < dtCriterias.Rows.Count; i++)
            {
                if ((col + 1) > 25)
                {
                    prefix = alpha[prefCount].ToString();
                    col -= 26;
                    prefCount++;
                }
                wSRange = oSheet.get_Range(prefix + alpha[col]+"5",prefix + alpha[col+1] + "5");
                wSRange.MergeCells = true;
                wSRange.Borders.Color = System.Drawing.Color.Black;
                DataRow r = dtCriterias.Rows[i];
                oSheet.Cells[5, col + 1] = r["criterianame"].ToString();
                col += 2;
            }
            wSRange = oSheet.get_Range(prefix + alpha[col] + "5", prefix + alpha[col + 1] + "5");
            wSRange.MergeCells = true;
            wSRange.Borders.Color = System.Drawing.Color.Black;
            oSheet.Cells[5, col + 1] = "Total Score";
        }
        private void PopulateData(Excel._Worksheet oSheet,List<ListViewItem> items)
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Excel.Range wSRange;
            int col = 0;
            int row = 6;
            string prefix = "";
            int prefCount = 0;
            for (int i = 0; i < items.Count; i++)
            {
                ListViewItem itm = items[i];
                
                for (int j = 0; j < itm.SubItems.Count; j++)
                {
                    if ((col + 1) > 25)
                    {
                        prefix = alpha[prefCount].ToString();
                        col -= 26;
                        prefCount++;
                    }
                    if (j == 0)
                    {
                        wSRange = oSheet.get_Range("A" + row, "A" + row);
                        wSRange.MergeCells = true;
                        wSRange.Borders.Color = System.Drawing.Color.Black;
                        oSheet.Cells[row, 1] = itm.SubItems[j].Text;
                    }
                    else
                    {
                        wSRange = oSheet.get_Range(alpha[col - 1].ToString() + row,alpha[col].ToString() +row);
                        wSRange.MergeCells = true;
                        wSRange.Borders.Color = System.Drawing.Color.Black;
                        oSheet.Cells[row, col] = itm.SubItems[j].Text;
                    }
                    col += 2;
                }
                col = 0;
                prefCount = 0;
                row++;
            }
        }
        //private void PrintReportToExcel()
        //{
        //    Excel.Application oXL;
        //    Excel.Workbook oWB;
        //    Excel.Worksheet oSheet;
        //    Excel.Range oRng;
        //    object oMissing = Missing.Value;

        //    try
        //    {
        //        //Start Excel and get Application object.
        //        oXL = new Excel.Application();
        //        oXL.Visible = true;

        //        //Get a new workbook.
        //        oWB = oXL.Workbooks._Open(@"C:\reports\report.xlsx", oMissing, oMissing, oMissing,
        //                                  oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
        //                                  oMissing, oMissing, oMissing);

        //        oSheet = (Excel.Worksheet)oWB.ActiveSheet;
        //        //oSheet.Cells[row,col] = " data "
        //        oSheet.Cells[4, 5] = DateTime.Now.ToLongDateString(); //Print Date on excel row 4, column F (6)

        //        int counter = 8;

        //        //foreach (DataRow row in dataTable.Rows)
        //        //{
        //        //    oSheet.Cells[counter, 2] = row["studentno"].ToString();
        //        //    oSheet.Cells[counter, 3] = row["fname"].ToString() + " " + row["lname"].ToString();
        //        //    oSheet.Cells[counter, 6] = row["course"].ToString();
        //        //    counter++;
        //        //    Excel.Range r = oSheet.get_Range("A" + counter, "F" + counter).EntireRow;
        //        //    r.Insert(Excel.XlInsertShiftDirection.xlShiftDown, oMissing);
        //        //}

        //        oWB.SaveAs(@"C:\reports\report_" + DateTime.Now.Second + ".xlsx", oMissing, oMissing, oMissing, oMissing,
        //                  oMissing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
        //                  oMissing, oMissing, oMissing, oMissing, oMissing);

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
        public void Print(string path)
        {
            ShellExecute(IntPtr.Zero, "print", path, "", "", ShowCommands.SW_SHOWNOACTIVATE);
        }
    }
}
