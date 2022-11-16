using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVienNhom5.GUI
{
    public partial class Login : Form
    {
        private static readonly AppSetting _setting = AppSettingSingleton.getSetting();

        public Login()
        {
            InitializeComponent();
            this.txtUserName.Text = "sa";
            this.txtPassword.Text = "123456";
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            string username = this.txtUserName.Text;
            string password = this.txtPassword.Text;

            bool ok = SqlServerConnectionSingleon.testConnection(username, password);
            if (!ok)
            {
                MessageBox.Show(
                    "Tài khoản hoặc mật khẩu DBMS sai",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                UserService userService = new UserService();

                userService.OnSuccessMessage += (s, message) =>
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                };

                userService.OnErrorMessage += (s, message) =>
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };

                _setting.Login(username, password);

                var result = userService.IsAdmin(this.txtUserName.Text);
                if (result < 0)
                    return;

                this.Hide();

                if (result == 1)
                {
                    HomePageAdmin frm = new HomePageAdmin();
                    frm.ShowDialog();
                }
                else
                {
                    HomePageGiangVien frm = new HomePageGiangVien();
                    frm.ShowDialog();
                }

                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
