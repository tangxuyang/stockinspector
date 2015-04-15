using StockInspector.BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL
{
    public class MinuteDataAnalyzer
    {
        public List<MinuteData> Analyze(string data)
        {
            string stockID = AnalyzerHelper.GetStockID(data);

            List<MinuteData> result = new List<MinuteData>();
            int startIndex, endIndex;
            startIndex = data.IndexOf("[[");
            endIndex = data.IndexOf("]]");
            string tempStr = data.Substring(startIndex + 1, endIndex - startIndex);
            var list = tempStr.Split(new string[]{"],["},StringSplitOptions.None);
            foreach(var str in list)
            {
                tempStr = str.Trim('[',']');
                var strs = AnalyzerHelper.Split(tempStr);
                var d = new MinuteData();
                d.Date = DateTime.Parse(strs[0]);
                d.DealPrice = double.Parse(strs[1]);
                d.DealQuantity = int.Parse(strs[2].Remove(strs[2].Length-1));
                d.DealAmount = double.Parse(strs[3].Remove(strs[3].Length - 2))*10000;
                d.UpDownPercent = double.Parse(strs[4].Remove(strs[4].Length-1));
                d.UpDownAmount = double.Parse(strs[5]);
                d.MeanPrice = double.Parse(strs[6]);
                d.StockID = stockID;
                result.Add(d);
            }


            return result;
        }
    }
}
