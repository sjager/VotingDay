using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace VotingDay
{
    class Exporter
    {
        public DataGridView dataGridView;
        public Exporter (DataGridView dg)
        {
            this.dataGridView = dg;
        }

        public string ExportToExcel(string filename, int rowToHighlight)
        {
            Excel.Application xlApp ;
            Excel.Workbook xlWorkBook ;
            Excel.Worksheet xlWorkSheet ;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            int i = 0;
            int j = 0; 

            for (i = 0; i <= dataGridView.RowCount  - 1; i++)
            {
                for (j = 0; j <= dataGridView.ColumnCount  - 1; j++)
                {
                    DataGridViewCell cell = dataGridView[j, i];
                    xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
                }
            }


            Range cellRange = (Range)xlWorkSheet.Cells[rowToHighlight, 1];
            cellRange.Interior.Color = ConvertColour(Color.Yellow);

            cellRange = (Range)xlWorkSheet.Cells[rowToHighlight, 2];
            cellRange.Interior.Color = ConvertColour(Color.Yellow);

            cellRange = (Range)xlWorkSheet.Cells[rowToHighlight, 3];
            cellRange.Interior.Color = ConvertColour(Color.Yellow);



            xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);

            string absfilepath = xlApp.DefaultFilePath.ToString() +"\\" + filename;
            
            
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created");

            return absfilepath;
        }

        public static int ConvertColour(Color colour)
        {
            int r = colour.R;
            int g = colour.G * 256;
            int b = colour.B * 65536;

            return r + g + b;
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

    }
}
