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
        static string minuteUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_1&t=202122";
        static string dayUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_6&t=202122";
        static string weekUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_7&t=202122";
        static string monthUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_8&t=202122"; 
        static void Main(string[] args)
        {

            while (true)
            {
                //Get data of every stock
                string tempMinute, tempDay, tempWeek, tempMonth;
                string parentfolder = Prompt("请输入数据目录（默认当前目录中data）:");
                string stockStr = Prompt("请输入股票编码和名称，形式入000006-某某股票，用分号分割（不输代表全部）：");
                Dictionary<string, string> stocks;
                if (string.IsNullOrEmpty(stockStr))
                {
                    stocks = GetStocks();
                }
                else
                {
                    stocks = new Dictionary<string, string>();
                    var tempStrs = stockStr.Split(';');
                    foreach (string str in tempStrs)
                    {
                        var stock = str.Split('-');
                        if (stock.Length == 2)
                        {
                            stocks.Add(stock[0], stock[1]);
                        }
                    }
                }
                string type = Prompt("请输入数据类型（1-分时,2-日K,3-周K,4-月K），格式如1;2;3;4（不选代表全部）");
                bool minute = false, day = false, week = false, month = false;
                if (string.IsNullOrEmpty(type))
                {
                    minute = true;
                    day = true;
                    week = true;
                    month = true;
                }
                else
                {
                    var strs = type.Split(';');
                    foreach (string str in strs)
                    {
                        switch (str)
                        {
                            case "1":
                                minute = true;
                                break;
                            case "2":
                                day = true;
                                break;
                            case "3":
                                week = true;
                                break;
                            case "4":
                                month = true;
                                break;
                        }
                    }
                }

                DirectoryInfo dir;

                foreach (var stock in stocks)
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

                        if (minute)
                        {
                            DownloadFile(tempMinute, Path.Combine(dir.FullName, "minute.txt"));
                        }
                        if (day)
                        {
                            DownloadFile(tempDay, Path.Combine(dir.FullName, "day.txt"));
                        }
                        if (week)
                        {
                            DownloadFile(tempWeek, Path.Combine(dir.FullName, "week.txt"));
                        }
                        if (month)
                        {
                            DownloadFile(tempMonth, Path.Combine(dir.FullName, "month.txt"));
                        }

                        Console.WriteLine(foldername + "successfully..");
                        System.Threading.Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Log.WriteLog("Error" + ex.Message + "(" + foldername + ")");
                        Console.WriteLine("Error" + ex.Message + "(" + foldername + ")");
                    }
                }

                Log.WriteLog("Downloading over...");
                string answer = Prompt("是否退出");
                if (answer != null && answer.ToLower() == "y")
                {
                    return;
                }
            }
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

        static string Prompt(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
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
