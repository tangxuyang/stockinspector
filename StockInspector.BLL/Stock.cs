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
        public static Dictionary<string,string> GetStocks(string html)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            //string path = "../../Stocks.xml";
            XmlDocument doc = new XmlDocument();
            //doc.Load(path);
            doc.LoadXml(html);

            XmlElement root = doc.DocumentElement;
            foreach (XmlNode ul in root.ChildNodes)
            {
                foreach (XmlNode li in ul.ChildNodes)
                {
                    result.Add(li.FirstChild.FirstChild.InnerText,li.LastChild.InnerText);
                }
            }

            return result;
        }
    }
}
