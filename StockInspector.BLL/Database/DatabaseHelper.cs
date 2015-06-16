using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StockInspector.BLL.Entity;

namespace StockInspector.BLL.Database
{
    public class DatabaseHelper
    {
        #region Field
        private static string ConnectionString = "server=.;database=stockinspector;uid=sa;pwd=Password@1";
        private static SqlConnection conn;
        private static SqlConnection Conn
        {
            get
            {
                if(conn == null)
                {
                    conn = new SqlConnection(ConnectionString);
                }

                return conn;
            }
        }

        private static SqlCommand command;
        private static SqlCommand Command
        {
            get
            {
                if(command==null)
                {
                    command = new SqlCommand();
                }

                return command;
            }
        }
        #endregion

        public static void InsertIntoMinuteData(List<MinuteData> data)
        {
            if (data == null || data.Count == 0)
            {
                return;
            }
            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into minutedata(stockid,minute,dealprice,dealquantity,dealamount,updownpercent,updownamount,meanprice,createdate,lastchangedate) values('{0}','{1}',{2},{3},{4},{5},{6},{7},'{8}','{9}');"; 
            foreach(var d in data)
            {
                sql.Append(string.Format(format,d.StockID,d.Date,d.DealPrice,d.DealQuantity,d.DealAmount,d.UpDownPercent,d.UpDownAmount,d.MeanPrice,DateTime.Now,DateTime.Now));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertIntoDayData(List<DayData> data)
        {
            if (data == null || data.Count == 0)
            {
                return;
            }
            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into daydata(stockid,day,openprice,highestprice,lowestprice,closeprice,updownamount,updownpercent,dealquantity,dealamount,exchangepercent,createdate,lastchangedate) values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},'{11}','{12}');";
            foreach (var d in data)
            {
                sql.Append(string.Format(format, d.StockID, d.Date, d.OpenPrice, d.HighestPrice, d.LowestPrice, d.ClosePrice, d.UpDownAmount, d.UpDownPercent,d.DealQuantity,d.DealAmount,d.ExchangePercent, DateTime.Now, DateTime.Now));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertIntoWeekData(List<WeekData> data)
        {
            if (data == null || data.Count == 0)
            {
                return;
            }
            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into weekdata(stockid,week,openprice,highestprice,lowestprice,closeprice,updownamount,updownpercent,dealquantity,dealamount,createdate,lastchangedate) values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},'{10}','{11}');";
            foreach (var d in data)
            {
                sql.Append(string.Format(format, d.StockID, d.Date, d.OpenPrice, d.HighestPrice, d.LowestPrice, d.ClosePrice, d.UpDownAmount, d.UpDownPercent, d.DealQuantity, d.DealAmount, DateTime.Now, DateTime.Now));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertIntoMonthData(List<MonthData> data)
        {
            if(data==null || data.Count==0)
            {
                return;
            }
            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into monthdata(stockid,month,openprice,highestprice,lowestprice,closeprice,updownamount,updownpercent,dealquantity,dealamount,createdate,lastchangedate) values('{0}','{1}',{2},{3},{4},{5},{6},{7},{8},{9},'{10}','{11}');";
            foreach (var d in data)
            {
                sql.Append(string.Format(format, d.StockID, d.Date, d.OpenPrice, d.HighestPrice, d.LowestPrice, d.ClosePrice, d.UpDownAmount, d.UpDownPercent, d.DealQuantity, d.DealAmount, DateTime.Now, DateTime.Now));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertIntoStock(List<StockEntity> data)
        {
            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into stock(stockid,stockname,stocktype) values('{0}','{1}','{2}');";
            foreach (var d in data)
            {
                sql.Append(string.Format(format, d.StockID, d.StockName,d.StockType));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static StockEntity FindByID(string stockID)
        {
            StockEntity entity = null;
            string sql = "select * from stock where stockid = '" + stockID + "'";

            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();

            command.CommandText = sql;

            var reader = command.ExecuteReader();
            if(reader.Read())
            {
                entity = new StockEntity() { 
                    StockID = reader["stockid"].ToString(),
                    StockName = reader["stockname"].ToString()
                };
            }

            conn.Close();

            return entity;
        }

        public static void DeleteStock(StockEntity stock)
        {
            string sql = "delete from stock where stockid = '" + stock.StockID + "'";

            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();

            command.CommandText = sql;

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static void ClearStock()
        {
            string sql = "delete from stock";

            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();

            command.CommandText = sql;

            command.ExecuteNonQuery();
            conn.Close();
        }

        public static List<StockEntity> GetAllStocks()
        {
            List<StockEntity> stocks = new List<StockEntity>();
            string sql = "select * from stock";

            SqlCommand command = Command;
            SqlConnection conn = Conn;
            command.Connection = conn;
            conn.Open();

            command.CommandText = sql;

            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                stocks.Add( new StockEntity()
                {
                    StockID = reader["stockid"].ToString(),
                    StockName = reader["stockname"].ToString(),
                    StockType = reader["stocktype"].ToString()
                });
            }

            conn.Close();

            return stocks;
        }
    }
}
