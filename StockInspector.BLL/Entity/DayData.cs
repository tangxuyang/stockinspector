using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL.Entity
{
    public class DayData
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
        /// <summary>
        /// 换手率（百分比）
        /// </summary>
        public double ExchangePercent { get; set; }

        public string StockID { get; set; }
    }
}
