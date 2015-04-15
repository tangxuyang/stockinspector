using StockInspector.BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL
{
    public class MonthDataAnalyzer
    {
        public List<MonthData> Analyze(string data)
        {
            string stockID = AnalyzerHelper.GetStockID(data);

            List<MonthData> result = new List<MonthData>();
            int startIndex, endIndex;
            startIndex = data.IndexOf("[[");
            endIndex = data.IndexOf("]]");
            if(startIndex==-1||endIndex==-1)
            {
                return result;
            }
            string tempStr = data.Substring(startIndex + 1, endIndex - startIndex);
            var list = tempStr.Split(new string[] { "],[" }, StringSplitOptions.None);
            foreach (var str in list)
            {
                tempStr = str.Trim('[', ']');
                var strs = AnalyzerHelper.Split(tempStr);
                var d = new MonthData();
                d.Date = DateTime.Parse(strs[0]);
                d.OpenPrice = double.Parse(strs[1]);
                d.HighestPrice = double.Parse(strs[2]);
                d.LowestPrice = double.Parse(strs[3]);
                d.ClosePrice = double.Parse(strs[4]);
                d.UpDownAmount = double.Parse(strs[5]);
                d.UpDownPercent = double.Parse(strs[6].Remove(strs[6].Length - 1));
                d.DealQuantity = double.Parse(strs[7].Remove(strs[7].Length - 2)) * 10000;
                d.DealAmount = double.Parse(strs[8].Remove(strs[8].Length - 2)) * 100000000;
                d.StockID = stockID;
                result.Add(d);
            }


            return result;
        }
    }

    
}
