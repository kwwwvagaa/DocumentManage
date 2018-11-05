using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.T4
{
    public class SqlHelper
    {
        public static string sqlConnectionStr = "Server=.;Initial Catalog=DocumentManage;User ID=sa;Password=123456";
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] paramList)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(paramList);
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] paramList)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(paramList);
                    return command.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] paramList)
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionStr))
            {
                conn.Open();
                using (SqlCommand command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(paramList);
                    return command.ExecuteScalar();
                }
            }
        }
    }

}
