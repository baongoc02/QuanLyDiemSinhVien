using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using QuanLyDiemSinhVienNhom5.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVienNhom5
{
    internal static class Program
    {
        private static readonly AppSetting _setting = AppSettingSingleton.getSetting();
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _setting.Login("sa", "123456");

            bool ok = SqlServerConnectionSingleon.testConnection("sa", "123456");
            if (!ok)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu DBMS sai");
            }
            else
            {
                Application.Run(new HomePageAdmin());
            }
        }
    }
}
