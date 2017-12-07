using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace SwissReTestRun
{
    class FileAcess
    {
        /// <summary>
        /// Set the No of columns
        /// And Get the data from file as DataTable
        /// </summary>
        public int headerLength;
        public DataTable getDatafromFile(string file)
        {
            var table = new DataTable();
            var fileContents = File.ReadAllLines(file);
            var headerFile = (from f in fileContents select f.Split(',')).First().ToArray();
            headerLength = headerFile.Length;
            var splitFileContents = (from f in fileContents select f.Split(',')).Skip(1).ToArray();
            for (int i = 0; i < headerFile.Length; i++)
            {
                DataColumn column = new DataColumn(headerFile[i]);
                column.DataType = System.Type.GetType("System.Decimal");

                table.Columns.Add(column);
            }
            foreach (var line in splitFileContents)
            {
                DataRow row = table.NewRow();
                row.ItemArray = (object[])line;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
