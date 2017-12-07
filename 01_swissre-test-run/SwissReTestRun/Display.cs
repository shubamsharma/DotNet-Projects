using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SwissReTestRun
{
    class Display
    {
        /// <summary>
        /// To print content in DataTable
        /// </summary>
        /// <param name="Table"></param>
        public void printDataTable(DataTable Table)
        {
            foreach (DataRow dataRow in Table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// To print Matrix
        /// </summary>
        /// <param name="arr"></param>
        public void printMatrix(decimal[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
        }
        
        /// <summary>
        /// To print Array
        /// </summary>
        /// <param name="ar"></param>
        public void printArrray(decimal[] ar)
        {
            Console.WriteLine(" Beta Values are ");
            for (int i = 0; i < ar.Length; i++)
            {
                Console.WriteLine(ar[i]);
            }
        }
    }
}
