using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL.Log
{
    public class Logger
    {
        private static StreamWriter sw;
        static Logger()
        {
            string filename = "log" + DateTime.Now.Ticks.ToString() + ".txt";
            sw = new StreamWriter(filename);
        }

        public static void WriteLog(string str)
        {
            sw.WriteLine(str + "[" + DateTime.Now.ToString() + "]");
            sw.Flush();
        }
    }
}
