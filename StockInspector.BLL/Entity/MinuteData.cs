using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL.Entity
{
    public class MinuteData
    {
        public string StockID { get; set; }
        /// <summary>
        /// 时间,精确到分钟
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        ///成交价（元）
        /// </summary>
        public double DealPrice { get; set; }
        /// <summary>
        /// 成交量（手）
        /// </summary>
        public int DealQuantity { get; set; }
        /// <summary>
        /// 成交额（元）
        /// </summary>
        public double DealAmount { get; set; }
        /// <summary>
        /// 涨跌幅（百分比）
        /// </summary>
        public double UpDownPercent { get; set; }
        /// <summary>
        /// 涨跌额（元）
        /// </summary>
        public double UpDownAmount { get; set; }
        /// <summary>
        /// 均价（元）
        /// </summary>
        public double MeanPrice { get; set; }
    }
}
