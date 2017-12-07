using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SwissReTestRun
{
    class ParameterOptimization
    {
        /// <summary>
        /// Object Declaration
        /// </summary>
        Prepare2DArray pc = null;
        MatrixMultiplication mc = null;

        /// <summary>
        /// Do Gradient free parameter optimization
        /// </summary>
        public ParameterOptimization()
        {
            pc = new Prepare2DArray();
            mc = new MatrixMultiplication();
        }

        public double gradientFreePO(Double[] var, decimal[,] x, decimal[,] y)
        {
            decimal[] theta = pc.ToArray(var);
            decimal[,] beta = pc.ToArray(theta);
            decimal sigma2 = theta.First();
            if (sigma2 <= 0)
                return 0;

            int n = x.Length;
            decimal[,] e = mc.subtractMatrix(y, mc.multiplyMatrix(x, beta));
            decimal val1 = (mc.multiplyMatrix(mc.transposeMatrix(e), e))[0, 0];
            decimal val2 = val1 / (2 * sigma2);
            double logl = (((-1 * n) / 2) * Math.Log(2 * Math.PI)) - ((n / 2) * Math.Log(Convert.ToDouble(sigma2))) - Convert.ToDouble(val2);
            return -1 * logl;
        }

        /// <summary>
        /// Do Gradient based parameter optimization
        /// </summary>
        /// <param name="theta"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double[] gradientPO(double[] var, decimal[,] x, decimal[,] y)
        {
            decimal[] theta = pc.ToArray(var);
            decimal[,] beta = pc.ToArray(theta);
            decimal sigma2 = theta.First();
            decimal[,] e = mc.subtractMatrix(y, mc.multiplyMatrix(x, beta));
            int n = x.Length;

            double[] g = new double[theta.Length];
            decimal val1 = (mc.multiplyMatrix(mc.transposeMatrix(e), e))[0, 0];
            g[0] = -1 * (Convert.ToDouble((-n /(2 * sigma2))) + (Convert.ToDouble(val1)/Convert.ToDouble((2*sigma2*sigma2))));
            decimal[] dump = pc.GetColumn((mc.multiplyMatrix(mc.transposeMatrix(x), e)),0);
            int j=1;
            for (int i = 0; i < dump.Length; i++)
            {
                g[j] = -1 * Convert.ToDouble(dump[i]);
                j++;
            }
            return g;
        }
        /// <summary>
        /// Convert DataTable to 2D Array
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Decimal[,] getYValue(DataTable table)
        {
            IEnumerable<Decimal> Yvar = from dt in table.AsEnumerable()
                                        select dt.Field<Decimal>("Y");
            Decimal[,] Y = pc.ToArray(Yvar);
            return Y;
        }

        /// <summary>
        /// Convert DataTable to 2D Array for  Predictor Variable
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public Decimal[,] getXValue(DataTable table, int length)
        {
            DataTable Predictor = table;
            Predictor.Columns.RemoveAt(0);
            IEnumerable<DataRow> Xvar = from dt in Predictor.AsEnumerable()
                                        select dt;
            Decimal[,] X = pc.ToArray(Xvar, length);
            return X;
        }
    }
}
