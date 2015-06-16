using StockInspector.BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StockInspector.BLL
{
    public class Stock
    {
        public static List<StockEntity> GetStocks(string html)
        {
            //Dictionary<string, string> result = new Dictionary<string, string>();
            List<StockEntity> stockes = new List<StockEntity>();
            //string path = "../../Stocks.xml";
            XmlDocument doc = new XmlDocument();
            //doc.Load(path);
            doc.LoadXml(html);

            XmlElement root = doc.DocumentElement;
            foreach (XmlNode ul in root.ChildNodes)
            {
                foreach (XmlNode li in ul.ChildNodes)
                {
                    //result.Add(li.FirstChild.FirstChild.InnerText,li.LastChild.InnerText);
                    stockes.Add(new StockEntity() {
                        StockID = li.FirstChild.FirstChild.InnerText,
                        StockName = li.LastChild.InnerText
                    });
                }
            }

            return stockes;
        }
    }
}
