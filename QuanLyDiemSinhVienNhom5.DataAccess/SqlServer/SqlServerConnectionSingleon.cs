using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.SqlServer
{
    public class SqlServerConnectionSingleon
    {
        private static SqlConnection instance = null;
        private static readonly AppSetting _setting = AppSettingSingleton.getSetting();

        public SqlServerConnectionSingleon()
        {

        }

        private static string BuildConnectionString(string server, string database, string userId, string password)
        {
            return $"Server={server};Database={database};User Id={userId};Password={password}";
        }

        private static string BuildDefaultConnectionString(string userId, string password)
        {
            return BuildConnectionString(".", "QuanLyDiemSinhVien", userId, password);
        }

        public static SqlConnection getInstance()
        {
            if (instance == null)
            {
                var connString = BuildDefaultConnectionString(_setting.SqlServerDatabaseUsername, _setting.SqlServerDatabasePassword);
                instance = new SqlConnection(connString);
                instance.Open();
            }
            return instance;
        }

        public static bool testConnection(string username, string password)
        {
            try
            {
                var connString = BuildDefaultConnectionString(username, password);
                using (var connection = new SqlConnection(connString))
                {
                    var query = "SELECT 1";
                    var command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteScalar();
                    connection.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool closeInstance()
        {
            if (instance != null)
            {
                instance.Close();
                instance.Dispose();
                instance = null;
                return true;
            }
            return false;
        }
    }
}
