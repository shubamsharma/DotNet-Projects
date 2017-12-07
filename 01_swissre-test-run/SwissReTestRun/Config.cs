using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace SwissReTestRun
{
    /// <summary>
    /// Config File to set the parameters from app.config file
    /// </summary>
    class Config
    {
        public static string filePath = AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["FilePath"];
        public static string fileName = ConfigurationManager.AppSettings["FileName"];
        public static double[] parameter = new double[] { 1, 1, 1, 1, 1 };
        public static double epsg = Convert.ToDouble(ConfigurationManager.AppSettings["EPSG"]);
        public static double epsf = Convert.ToDouble(ConfigurationManager.AppSettings["EPSF"]);
        public static double epsx = Convert.ToDouble(ConfigurationManager.AppSettings["EPSX"]);
        public static double stpmax = Convert.ToDouble(ConfigurationManager.AppSettings["STPMAX"]);
        public static int maxits = Convert.ToInt16(ConfigurationManager.AppSettings["MAXITS"]);
    }
}
