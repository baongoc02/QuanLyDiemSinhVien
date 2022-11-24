using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Base
{
    public class AppSetting
    {
        public string SqlServerDatabaseUsername { get; private set; } = "sa";
        public string SqlServerDatabasePassword { get; private set; } = "123456";

        public void Login(string username, string password)
        {
            SqlServerDatabaseUsername = username;
            SqlServerDatabasePassword = password;
        }

        public void Logout()
        {
            SqlServerDatabaseUsername = null;
            SqlServerDatabasePassword = null;
        }

        public AppSetting()
        {

        }
    }

    public class AppSettingSingleton
    {
        private static AppSetting setting = new AppSetting();

        public static AppSetting getSetting() => setting;
    }
}
