using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Logger
    {
        public Dictionary<string, IVendable> soldItems = new Dictionary<string, IVendable>();
        public List<string> salesActions = new List<string>();

        public void MakeLog(string logLine)
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";

            using (StreamWriter logFile = new StreamWriter(Path.Combine(path, fileName)))
            {
                logFile.WriteLine(logLine);        
            }
        }

        public void MakeSalesReport(Dictionary<string, IVendable> soldItems)
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "SalesReport.txt";

            using (StreamWriter salesReportFile = new StreamWriter(Path.Combine(path, fileName)))
            {
                foreach (KeyValuePair<string, IVendable> item in soldItems)
                {

                }
            }
        }
    }
}
