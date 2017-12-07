using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SwissReTestRun
{
    class Prepare2DArray
    {
        /// <summary>
        /// Prepare 2D Array for IEnumerable<Decimal> type
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public Decimal[,] ToArray(IEnumerable<Decimal> arr)
        {
            int len = arr.Count();
            Decimal[,] data = new Decimal[len, 1];
            var enumerator = arr.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
            {
                data[i, 0] = enumerator.Current;
                i++;
            }
            return data;
        }

        /// <summary>
        /// prepare 2D array for IEnumerable<DataRow>
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Decimal[,] ToArray(IEnumerable<DataRow> arr, int column)
        {
            int i = 0;
            int count = arr.Count();
            decimal[,] data = new decimal[count, column - 1];
            foreach (DataRow matchRow in arr)
            {
                for (int j = 0; j < matchRow.ItemArray.Length; j++)
                {
                    data[i, j] = Convert.ToDecimal(matchRow[j]);
                }
                i++;
            }
            return data;
        }

        /// <summary>
        /// Prepare 2D array for Decimal[]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public Decimal[,] ToArray(Decimal[] arr)
        {
            int len = arr.Count();
            decimal[,] C = new decimal[len - 1, 1];
            for (int k = 0; k < (len - 1); k++)
            {
                C[k, 0] = arr[k];
                Console.Write(C[k, 0] + " ");
            }
            Console.WriteLine("\n");
            return C;
        }
        /// <summary>
        /// Convert double array to decimal[]
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public Decimal[] ToArray(Double[] arr)
        {
            int len = arr.Count();
            decimal[] C = new decimal[len];
            for (int k = 0; k < len; k++)
            {
                C[k] = Convert.ToDecimal(arr[k]);
            }
            return C;
        }
        
        /// <summary>
        /// Get required column for 2D array
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public decimal[] GetColumn(decimal[,] matrix, int column)
        {
            var rowLength = matrix.GetLength(0);
            var rowVector = new decimal[rowLength];
            for (var i = 0; i < rowLength ; i++)
                rowVector[i] = matrix[i, column];
            return rowVector;
        }
    }
}
