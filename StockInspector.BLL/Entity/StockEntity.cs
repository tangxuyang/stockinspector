using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector.BLL.Entity
{
    public class StockEntity
    {
        public string StockID { get; set; }
        public string StockName { get; set; }
        /// <summary>
        /// 上海-SH 
        /// 深证-SZ
        /// 创业板-SZC
        /// </summary>
        public string StockType { get; set; }
    }
}
