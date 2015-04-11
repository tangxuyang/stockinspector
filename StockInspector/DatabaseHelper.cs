using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace StockInspector
{
    public class DatabaseHelper
    {
        private static string ConnectionString = "server=.;database=stockinspector;uid=sa;pwd=Password@1";
        public static void InsertIntoMinuteData(List<MinuteData> data)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = conn;
            conn.Open();
            StringBuilder sql = new StringBuilder();
            string format = "insert into minutedata values('{0}',{1},{2},{3},{4},{5},{6},'{7}','{8}');";
            foreach(var d in data)
            {
                sql.Append(string.Format(format,d.Date,d.DealPrice,d.DealQuantity,d.DealAmount,d.UpDownPercent,d.UpDownAmount,d.MeanPrice,DateTime.Now,DateTime.Now));
            }

            command.CommandText = sql.ToString();

            command.ExecuteNonQuery();
        }
    }
}
