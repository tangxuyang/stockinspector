using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;
using StockInspector.BLL;
using StockInspector.BLL.Entity;
using StockInspector.BLL.Net;
using StockInspector.BLL.Log;

namespace StockInspector
{
    class Program
    {
        static string minuteUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_1&t=202122";
        static string dayUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_6&t=202122";
        static string weekUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_7&t=202122";
        static string monthUrl = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_8&t=202122"; 
        static void Main(string[] args)
        {

            //DownlaodData();
            //Analyze();
            InitialStock();
        }

        static void InitialStock()
        {
            var stocks = GetStocks();
            List<StockEntity> sts = new List<StockEntity>();
            foreach(var k in stocks)
            {
                sts.Add(new StockEntity() { 
                    StockID = k.Key,
                    StockName = k.Value
                });
            }

            DatabaseHelper.InsertIntoStock(sts);
        }

        static Dictionary<string,string> GetStocks()
        {
            string path = "../../Stocks.xml";
            StreamReader sr = new StreamReader(path);
            var stocks = Stock.GetStocks(sr.ReadToEnd());

            return stocks;
        }

        static void Analyze()
        {
            string minuteFileName= "minute.txt";
            string dayFileName = "day.txt";
            string weekFileName = "week.txt";
            string monthFileName = "month.txt";

            //MinuteData
            FileStream fs = new FileStream(minuteFileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.Default);

            string str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            MinuteDataAnalyzer mda = new MinuteDataAnalyzer();
            var minuteData = mda.Analyze(str);

            //DayData
            fs = new FileStream(dayFileName, FileMode.Open);
            sr = new StreamReader(fs, Encoding.Default);

            str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            DayDataAnalyzer dda = new DayDataAnalyzer();
            var dayData = dda.Analyze(str);

            //WeekData
            fs = new FileStream(weekFileName, FileMode.Open);
            sr = new StreamReader(fs, Encoding.Default);

            str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            WeekDataAnalyzer wda = new WeekDataAnalyzer();
            var weekData = wda.Analyze(str);


            //MonthData
            fs = new FileStream(monthFileName, FileMode.Open);
            sr = new StreamReader(fs, Encoding.Default);

            str = sr.ReadToEnd();
            sr.Close();
            fs.Close();
            MonthDataAnalyzer mmda = new MonthDataAnalyzer();
            var monthData = mmda.Analyze(str);

            DatabaseHelper.InsertIntoMinuteData(minuteData);
            DatabaseHelper.InsertIntoDayData(dayData);
            DatabaseHelper.InsertIntoWeekData(weekData);
            DatabaseHelper.InsertIntoMonthData(monthData);

            Console.WriteLine("analyze...");
        }

        static void DownlaodData()
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
                            NetHelper.DownloadFile(tempMinute, Path.Combine(dir.FullName, "minute.txt"));
                        }
                        if (day)
                        {
                            NetHelper.DownloadFile(tempDay, Path.Combine(dir.FullName, "day.txt"));
                        }
                        if (week)
                        {
                            NetHelper.DownloadFile(tempWeek, Path.Combine(dir.FullName, "week.txt"));
                        }
                        if (month)
                        {
                            NetHelper.DownloadFile(tempMonth, Path.Combine(dir.FullName, "month.txt"));
                        }

                        Console.WriteLine(foldername + "successfully..");
                        System.Threading.Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog("Error" + ex.Message + "(" + foldername + ")");
                        Console.WriteLine("Error" + ex.Message + "(" + foldername + ")");
                    }
                }

                Logger.WriteLog("Downloading over...");
                string answer = Prompt("是否退出");
                if (answer != null && answer.ToLower() == "y")
                {
                    return;
                }
            }
        } 

        static string Prompt(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
    }
}
