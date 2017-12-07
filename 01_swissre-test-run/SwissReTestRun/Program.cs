using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Data;
using System.Collections;

namespace SwissReTestRun
{
    /// <summary>
    /// Entry pont of the program
    /// It will get the file path either from the config file or command line parameters
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            string file = string.Empty;

            if (args.Length == 0)
            {
                Console.WriteLine("Fetching file path dn file name from app.config file");
                file = Config.filePath + Config.fileName;
                Console.WriteLine("\nFile used for analysis is : " + file);
            }
            else
            {
                Console.WriteLine("Fetching file path with name from command line");
                file = args[0].ToString();
            }

            if (File.Exists(file))
            {
                Logic logic = new Logic();
                bool status = logic.doProcessing(file);
                Console.WriteLine("\nFile used for analysis is : " + file);
            }
            else
            {
                Console.WriteLine("\nNo file available for analysis");
            }
            Console.Read();
        }
    }
}
