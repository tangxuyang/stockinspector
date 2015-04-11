using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector
{
    public class MinuteDataAnalyzer
    {
        public List<MinuteData> Analyze(string data)
        {
            string stockID = data.Substring(0, data.IndexOf('=')).Split('_')[2];

            List<MinuteData> result = new List<MinuteData>();
            int startIndex, endIndex;
            startIndex = data.IndexOf("[[");
            endIndex = data.IndexOf("]]");
            string tempStr = data.Substring(startIndex + 1, endIndex - startIndex);
            var list = tempStr.Split(new string[]{"],["},StringSplitOptions.None);
            foreach(var str in list)
            {
                tempStr = str.Trim('[',']');
                var strs = Split(tempStr);
                var d = new MinuteData();
                d.Date = DateTime.Parse(strs[0]);
                d.DealPrice = double.Parse(strs[1]);
                d.DealQuantity = int.Parse(strs[2].Remove(strs[2].Length-1));
                d.DealAmount = double.Parse(strs[3].Remove(strs[3].Length - 2));
                d.UpDownPercent = double.Parse(strs[4].Remove(strs[4].Length-1));
                d.UpDownAmount = double.Parse(strs[5]);
                d.MeanPrice = double.Parse(strs[6]);
                d.StockID = stockID;
                result.Add(d);
            }


            return result;
        }

        private List<string> Split(string str)
        {
            //'2015-4-3 09:30','5.84','54909手','3215.94万元','-1.02%','-0.06','5.86'
            var strs = str.Split(',');
            List<string> result = new List<string>();
            foreach(var s in strs)
            {
                result.Add(s.Trim('\''));
            }

            return result;
        }
    }

    public class MinuteData
    {
        public string StockID { get; set; }
        /// <summary>
        /// 时间,精确到分钟
        /// </summary>
        public DateTime Date{get;set;}
        /// <summary>
        ///成交价（元）
        /// </summary>
        public double DealPrice{get;set;}
        /// <summary>
        /// 成交量（手）
        /// </summary>
        public int DealQuantity{get;set;}
        /// <summary>
        /// 成交额（万元）
        /// </summary>
        public double DealAmount{get;set;}
        /// <summary>
        /// 涨跌幅（百分比）
        /// </summary>
        public double UpDownPercent{get;set;}
        /// <summary>
        /// 涨跌额（元）
        /// </summary>
        public double UpDownAmount{get;set;}
        /// <summary>
        /// 均价（元）
        /// </summary>
        public double MeanPrice{get;set;}
    }


}
