using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockInspector.BLL.Log;
using System.Net;
using System.IO;

namespace StockInspector.BLL.Net
{
    public class NetHelper
    {
        public static string minuteUrl_SH = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_1&t=202122";
        public static string dayUrl_SH = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_6&t=202122";
        public static string weekUrl_SH = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_7&t=202122";
        public static string monthUrl_SH = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_1_8&t=202122";

        public static string minuteUrl_SZ = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_1&t=202122";
        public static string dayUrl_SZ = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_6&t=202122";
        public static string weekUrl_SZ = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_7&t=202122";
        public static string monthUrl_SZ = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_8&t=202122";

        public static string minuteUrl_SZC = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_1&t=202122";
        public static string dayUrl_SZC = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_6&t=202122";
        public static string weekUrl_SZC = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_7&t=202122";
        public static string monthUrl_SZC = "http://cq.ssajax.cn/interact/getTradedata.ashx?pic=qmpic_{0}_2_8&t=202122";

        public static void DownloadFile(string url, string file)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            FileStream fs = new FileStream(file, FileMode.Create);
            Stream stream = request.GetResponse().GetResponseStream();
            //StreamWriter sw = new StreamWriter(fs);
            //StreamReader sr = new StreamReader(stream);
            //sw.Write(sr.ReadToEnd());
            //byte[] buffer = new byte[102400];
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            int n = 0;
            while ((n = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, n);
            }
            //sr.Close();
            stream.Close();
            //sw.Close();
            fs.Close();


            Logger.WriteLog("Downlaod " + file + " from " + url);
        }

        public static string DownloadFile(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            Stream stream = request.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(stream,Encoding.Default);

            string result = sr.ReadToEnd();
            Logger.WriteLog("Downlaod from " + url);

            return result;
        }
    }
}
