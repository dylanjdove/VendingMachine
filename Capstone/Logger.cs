using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace Capstone
{
    public class Logger
    {
        public Dictionary<string, int> soldItems = new Dictionary<string, int>();

        public void MakeLog(string logLine)
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "Log.txt";

            using (StreamWriter logFile = new StreamWriter(Path.Combine(path, fileName)))
            {
                logFile.WriteLine(logLine);        
            }
        }

        public void MakeSalesReport(Dictionary<string, int> soldItems)
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "SalesReport.txt";

            using (StreamWriter salesReportFile = new StreamWriter(Path.Combine(path, fileName)))
            {
                foreach (KeyValuePair<string, int> item in soldItems)
                {
                    salesReportFile.WriteLine(item.Key + "|" + item.Value);
                }
            }
        }
    }
}
