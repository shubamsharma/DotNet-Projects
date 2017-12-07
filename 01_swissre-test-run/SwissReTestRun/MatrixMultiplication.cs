using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwissReTestRun
{
    class MatrixMultiplication
    {
        /// <summary>
        /// Perform Matrix Multiplication
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public decimal[,] multiplyMatrix(decimal[,] A, decimal[,] B)
        {
            decimal[,] C = new decimal[A.GetLength(0), B.GetLength(1)];
            int N = B.Length;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }
            return C;
        }

        /// <summary>
        /// Perform Matric Subtraction
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public decimal[,] subtractMatrix(decimal[,] A, decimal[,] B)
        {
            decimal[,] C = new decimal[B.GetLength(0), B.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[i,j] = A[i,j] - B[i,j];
                }
            }
            return C;
        }

        /// <summary>
        /// Perform Matrix Transpose
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public decimal[,] transposeMatrix(decimal[,] A)
        {
            decimal[,] C = new decimal[A.GetLength(1), A.GetLength(0)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    C[j, i] = A[i, j];
                }
            }
            return C;
        }
    }
}