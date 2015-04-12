using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector
{
    public class WeekDataAnalyzer
    {
        public List<WeekData> Analyze(string data)
        {
            string stockID = AnalyzerHelper.GetStockID(data);

            List<WeekData> result = new List<WeekData>();
            int startIndex, endIndex;
            startIndex = data.IndexOf("[[");
            endIndex = data.IndexOf("]]");
            string tempStr = data.Substring(startIndex + 1, endIndex - startIndex);
            var list = tempStr.Split(new string[] { "],[" }, StringSplitOptions.None);
            foreach (var str in list)
            {
                tempStr = str.Trim('[', ']');
                var strs = AnalyzerHelper.Split(tempStr);
                var d = new WeekData();
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

    public class WeekData
    {
        /// <summary>
        /// 日前，按天
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// 开盘价（元）
        /// </summary>
        public double OpenPrice { get; set; }
        /// <summary>
        /// 最高价（元）
        /// </summary>
        public double HighestPrice { get; set; }
        /// <summary>
        /// 最低价（元）
        /// </summary>
        public double LowestPrice { get; set; }
        /// <summary>
        /// 收盘价（元）
        /// </summary>
        public double ClosePrice { get; set; }
        /// <summary>
        /// 涨跌幅（百分比）
        /// </summary>
        public double UpDownPercent { get; set; }
        /// <summary>
        /// 涨跌额（元）
        /// </summary>
        public double UpDownAmount { get; set; }
        /// <summary>
        /// 成交量（手）
        /// </summary>
        public double DealQuantity { get; set; }
        /// <summary>
        /// 成交额（元）
        /// </summary>
        public double DealAmount { get; set; }

        public string StockID { get; set; }
    }
}
