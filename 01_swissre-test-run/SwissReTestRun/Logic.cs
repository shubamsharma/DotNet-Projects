using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SwissReTestRun
{
    class Logic
    {
        /// <summary>
        /// Object Declaration
        /// </summary>
        FileAcess access = null;
        ParameterOptimization po = null;
        decimal[,] response = null;
        decimal[,] predictor = null;

        /// <summary>
        /// Constructor Method
        /// </summary>
        public Logic()
        {
            access = new FileAcess();
            po = new ParameterOptimization();
        }

        /// <summary>
        /// Do all the processing releated to file and return the status.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool doProcessing(string file)
        {
            try
            {
                DataTable table = access.getDatafromFile(file);
                response = po.getYValue(table);
                predictor = po.getXValue(table,access.headerLength);
                //For List of parameters go to http://www.alglib.net/translator/man/manual.csharp.html#sub_minlbfgscreatef
                double[] x = new double[] { 1, 1, 1, 1, 1 };
                double epsg = Config.epsg;
                double epsf = Config.epsf;
                double epsx = Config.epsx;
                double stpmax = Config.stpmax;
                int maxits = Config.maxits;
                alglib.minlbfgsstate state;
                alglib.minlbfgsreport rep;

                // first run
                alglib.minlbfgscreate(1, x, out state);
                alglib.minlbfgssetcond(state, epsg, epsf, epsx, maxits);
                alglib.minlbfgssetstpmax(state, stpmax);
                alglib.minlbfgsoptimize(state, function_grad, null, null);
                alglib.minlbfgsresults(state, out x, out rep);
                Console.Write("Final parameters are : ");
                System.Console.WriteLine("{0}", alglib.ap.format(x, 2)); // EXPECTED: [-3,3]
            }
            catch (Exception e)
            {
                Console.WriteLine("Got Error " + e.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gradient Function to optimize parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="func"></param>
        /// <param name="grad"></param>
        /// <param name="obj"></param>
        public void function_grad(double[] x, ref double func, double[] grad, object obj)
        {   
            // This callback calculates the Gradient-free constrained optimisation \n")
            // and its derivatives 
            func = po.gradientFreePO(x, predictor, response);
            double[] g = po.gradientPO(x, predictor, response);
            grad[0] = g[0];
            grad[1] = g[1];
            grad[2] = g[2];
            grad[3] = g[3];
            grad[4] = g[4];
        }
    }
}
