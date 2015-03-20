using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInspector
{
    public class TradeData<T> where T:AbstractData
    {
        public string type { get; set; }
        public int picWidth { get; set; }
        public int left { get; set; }
        public int right { get; set; }
        public int top { get; set; }
        public int bottom { get; set; }
        public double mainHeight { get; set; }
        public int count { get; set; }
        public bool IsIndex { get; set; }
        public List<T> data { get; set; }
    }
}
