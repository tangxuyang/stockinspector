using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;

namespace StockInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get all stocks
            var stocks = GetStocks();
            Console.WriteLine("Get stocks successfully..");

            string minuteUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_1&t=202122";
            string dayUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_6&t=202122";
            string weekUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_7&t=202122";
            string monthUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_8&t=202122";

            //Get data of every stock
            string tempMinute,tempDay,tempWeek,tempMonth;
            string parentfolder = "data";
            DirectoryInfo dir;
            foreach(var stock in stocks)
            {
                string stockid = stock.Key;
                string stockname = stock.Value.Replace('*', '#');
                string foldername = stockid + stockname;
                string folderpath = Path.Combine(parentfolder, foldername);
                try
                {

                    if (!Directory.Exists(folderpath))
                    {
                        dir = Directory.CreateDirectory(folderpath);
                    }
                    else
                    {
                        dir = new DirectoryInfo(folderpath);
                    }

                    tempMinute = string.Format(minuteUrl, stockid);
                    tempDay = string.Format(dayUrl, stockid);
                    tempWeek = string.Format(weekUrl, stockid);
                    tempMonth = string.Format(monthUrl, stockid);

                    DownloadFile(tempMinute, Path.Combine(dir.FullName, "minute.txt"));
                    DownloadFile(tempDay, Path.Combine(dir.FullName, "day.txt"));
                    DownloadFile(tempWeek, Path.Combine(dir.FullName, "week.txt"));
                    DownloadFile(tempMonth, Path.Combine(dir.FullName, "month.txt"));

                    Console.WriteLine(foldername+"successfully..");
                    System.Threading.Thread.Sleep(100);
                }
                catch(Exception ex)
                {
                    Log.WriteLog("Error"+ ex.Message+"("+foldername+")");
                    Console.WriteLine("Error" + ex.Message + "(" + foldername + ")");
                }
            }

            Log.WriteLog("Downloading over...");
        }

        static Dictionary<string,string> GetStocks()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string path = "../../Stocks.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

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

        static void DownloadFile(string url,string file)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            FileStream fs = new FileStream(file,FileMode.Create);
            Stream stream = request.GetResponse().GetResponseStream();
            byte[] buffer = new byte[102400];

            int n = 0;
            while((n = stream.Read(buffer,0,buffer.Length))>0)
            {
                fs.Write(buffer, 0, n);
            }

            stream.Close();
            fs.Close();

            Log.WriteLog("Downlaod " + file + " from " + url);
        }


    }

    public class Log
    {
        private static StreamWriter sw;
        static Log()
        {
            string filename = "log"+DateTime.Now.Ticks.ToString()+".txt";
            sw = new StreamWriter(filename);
        }

        public static void WriteLog(string str)
        {
            sw.WriteLine(str + "[" + DateTime.Now.ToString() + "]");
            sw.Flush();
        }
    }
}
