using StockInspector.BLL;
using StockInspector.BLL.Database;
using StockInspector.BLL.Entity;
using StockInspector.BLL.Log;
using StockInspector.BLL.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockInspectorGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> stocks;

        private void btn_DownladStock_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string url = tb_StockIndex.Text;
            string str = NetHelper.DownloadFile(url);

            int startIndex = str.IndexOf("<ul class=\"seo_pageList\" id=\"index_data_0\">");
            int endIndex = str.IndexOf("</ul>", startIndex);

            string shA = str.Substring(startIndex, endIndex - startIndex + 5);

            startIndex = str.IndexOf("<ul class=\"seo_pageList\"",endIndex);
            endIndex = str.IndexOf("</ul>", startIndex);
            string shB = str.Substring(startIndex, endIndex - startIndex + 5);

            startIndex = str.IndexOf("<ul class=\"seo_pageList\"", endIndex);
            endIndex = str.IndexOf("</ul>", startIndex);
            string szA = str.Substring(startIndex, endIndex - startIndex + 5);


            startIndex = str.IndexOf("<ul class=\"seo_pageList\"", endIndex);
            endIndex = str.IndexOf("</ul>", startIndex);
            string szB = str.Substring(startIndex, endIndex - startIndex + 5);

            stocks = StockInspector.BLL.Stock.GetStocks("<root>" + shA + shB + szA + szB + "</root>");

            foreach(var v in stocks)
            {
                dataGridView1.Rows.Add(v.Key, v.Value);
            }
        }

        private void btn_InportToDatabase_Click(object sender, EventArgs e)
        {
            if (stocks != null)
            {
                List<StockInspector.BLL.Entity.StockEntity> sts = new List<StockInspector.BLL.Entity.StockEntity>();
                foreach(var v in stocks)
                {
                    sts.Add(new StockInspector.BLL.Entity.StockEntity() {
                        StockID = v.Key,
                        StockName = v.Value
                    });
                }
                StockInspector.BLL.Database.DatabaseHelper.ClearStock();
                StockInspector.BLL.Database.DatabaseHelper.InsertIntoStock(sts);
            }
        }

        private void btn_ImportFromDatabase_Click(object sender, EventArgs e)
        {
            var stocks = StockInspector.BLL.Database.DatabaseHelper.GetAllStocks();
            foreach(var stock in stocks)
            {
                dgv_Stocks.Rows.Add(false,stock.StockID, stock.StockName);
            }
        }

        private void btn_All_Click(object sender, EventArgs e)
        {
            lb_Stocks.Items.Clear();
            lb_Stocks.Items.Add("All");
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            lb_Stocks.Items.Clear();
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            var selectedItem = lb_Stocks.SelectedIndices;
            for(int i = selectedItem.Count-1;i>=0;i--)
            {
                lb_Stocks.Items.RemoveAt(i);
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            lb_Stocks.Items.Clear();
            foreach(DataGridViewRow item in dgv_Stocks.Rows)
            {
                var checkBox = item.Cells[0] as DataGridViewCheckBoxCell;
                if(checkBox.Value!=null&&bool.Parse(checkBox.Value.ToString()))
                {
                    lb_Stocks.Items.Add(item.Cells[1].Value.ToString()+"-"+item.Cells[2].Value.ToString());
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lb_Stocks.Items.Count>0)
            {
                List<StockEntity> stocks = null;
                string type = cb_Type.Text;
                if(lb_Stocks.Items[0].ToString()=="All")
                {
                    stocks = DatabaseHelper.GetAllStocks();
                        
                }
                else
                {
                    stocks = new List<StockEntity>();
                    foreach(var item in lb_Stocks.Items)
                    {
                        string str = item.ToString();
                        string[] strs = str.Split('-');
                        stocks.Add(new StockEntity() { 
                            StockID = strs[0],
                            StockName = strs[1]
                        });
                    }
                }
                pb_Download.Value = 0;
                pb_Download.Minimum = 0;
                pb_Download.Maximum = stocks.Count;
                lb_Download.Text = "";

                System.Threading.Thread thread = new System.Threading.Thread(DownadAndImportWrap);
                object[] objs = new object[]{stocks,type};
                thread.Start(objs);

                //DownloadAndInport(stocks,type);
                //MessageBox.Show("成功!");
            }
        }

        private void DownadAndImportWrap(object obj)
        {
            object[] objects = obj as object[];
            List<StockEntity> stocks = objects[0] as List<StockEntity>;
            string type = objects[1] as string;

            DownloadAndImport(stocks, type);
            MessageBox.Show("成功!");
        }

        private void DownloadAndImport(List<StockEntity> stocks,string type="All")
        {
            if(stocks.Count>0)
            {
                string str = null;
                List<MinuteData> minuteData = null;
                List<DayData> dayData = null;
                List<WeekData> weekData = null;
                List<MonthData> monthData = null;
                MinuteDataAnalyzer mda = new MinuteDataAnalyzer();
                DayDataAnalyzer dda = new DayDataAnalyzer();
                WeekDataAnalyzer wda = new WeekDataAnalyzer();
                MonthDataAnalyzer mmda = new MonthDataAnalyzer();
                int i = 0;
                switch(type)
                {
                    case "All":
                        
                        foreach(var stock in stocks)
                        {
                            try
                            {
                                i++;
                                SetProgress(i, stocks.Count);
                                str = NetHelper.DownloadFile(string.Format(NetHelper.minuteUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                minuteData = mda.Analyze(str);
                                DatabaseHelper.InsertIntoMinuteData(minuteData);
                                Sleep(400);

                                str = NetHelper.DownloadFile(string.Format(NetHelper.dayUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                dayData = dda.Analyze(str);
                                DatabaseHelper.InsertIntoDayData(dayData);
                                Sleep(400);

                                str = NetHelper.DownloadFile(string.Format(NetHelper.weekUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                weekData = wda.Analyze(str);
                                DatabaseHelper.InsertIntoWeekData(weekData);
                                Sleep(400);

                                str = NetHelper.DownloadFile(string.Format(NetHelper.monthUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                monthData = mmda.Analyze(str);
                                DatabaseHelper.InsertIntoMonthData(monthData);
                                Sleep(400);

                                pb_Download.Value = i;
                                lb_Download.Text = i.ToString() + "/" + stocks.Count;
                            }
                            catch(Exception ex)
                            {
                                Logger.WriteLog(ex.Message + "---" + ex.StackTrace);
                            }
                        }
                        //DatabaseHelper.InsertIntoMinuteData(minuteData);
                        //str = NetHelper.DownloadFile(NetHelper.)
                        break;
                    case "Minute":
                        foreach (var stock in stocks)
                        {
                            try
                            {
                                i++;
                                SetProgress(i, stocks.Count);
                                str = NetHelper.DownloadFile(string.Format(NetHelper.minuteUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                minuteData = mda.Analyze(str);
                                DatabaseHelper.InsertIntoMinuteData(minuteData);
                                Sleep(400);
                            }
                            catch(Exception ex)
                            {
                                Logger.WriteLog(ex.Message + "---" + ex.StackTrace);
                            }
                            
                        }
                        break;
                    case "Day":
                        foreach (var stock in stocks)
                        {
                            try
                            {
                                i++;
                                SetProgress(i, stocks.Count);
                                str = NetHelper.DownloadFile(string.Format(NetHelper.dayUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                dayData = dda.Analyze(str);
                                DatabaseHelper.InsertIntoDayData(dayData);
                                Sleep(400);
                            }
                            catch(Exception ex)
                            {
                                Logger.WriteLog(ex.Message + "---" + ex.StackTrace);
                            }
                            
                        }
                        break;
                    case "Week":
                        foreach (var stock in stocks)
                        {
                            try
                            {
                                i++;
                                SetProgress(i, stocks.Count);
                                str = NetHelper.DownloadFile(string.Format(NetHelper.weekUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                weekData = wda.Analyze(str);
                                DatabaseHelper.InsertIntoWeekData(weekData);
                                Sleep(400);
                            }
                            catch(Exception ex)
                            {
                                Logger.WriteLog(ex.Message + "---" + ex.StackTrace);
                            }
                            
                        }
                        break;
                    case "Month":
                        foreach (var stock in stocks)
                        {
                            try
                            {
                                i++;
                                SetProgress(i, stocks.Count);
                                str = NetHelper.DownloadFile(string.Format(NetHelper.monthUrl, stock.StockID));
                                if (string.IsNullOrEmpty(str))
                                {
                                    continue;
                                }
                                monthData = mmda.Analyze(str);
                                DatabaseHelper.InsertIntoMonthData(monthData);
                                Sleep(400);
                            }
                            catch(Exception ex)
                            {
                                Logger.WriteLog(ex.Message + "---" + ex.StackTrace);
                            }
                        }
                        break;
                }
            }
        }

        private void Sleep(int millsecond)
        {
            System.Threading.Thread.Sleep(millsecond);
        }

        private void SetProgress(int n, int total)
        {
            if(pb_Download.InvokeRequired)
            {
                DSetProgress dsp = SetProgress;
                //dsp.Invoke(n, total);
                this.Invoke(dsp, n, total);
            }
            else
            {
                pb_Download.Value = n;
                lb_Download.Text = n.ToString() + "/" + total.ToString();
            }
        }

        
    }

    delegate void DSetProgress(int n, int total);
}
