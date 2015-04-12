using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector
{
    public class AnalyzerHelper
    {
        public static List<string> Split(string str)
        {
            //'2015-4-3 09:30','5.84','54909手','3215.94万元','-1.02%','-0.06','5.86'
            var strs = str.Split(',');
            List<string> result = new List<string>();
            foreach (var s in strs)
            {
                result.Add(s.Trim('\''));
            }

            return result;
        }

        public static string GetStockID(string data)
        {
            return data.Substring(0, data.IndexOf('=')).Split('_')[2];
        }
    }
}
