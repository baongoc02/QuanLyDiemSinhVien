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
    public partial class HomePageAdmin : Form
    {
        private static readonly AppSetting _setting = AppSettingSingleton.getSetting();

        public HomePageAdmin()
        {
            InitializeComponent();
            this.tbLoginedUsername.Text = _setting.SqlServerDatabaseUsername;
        }

        [DesignOnly(true)]
        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void AddViewToPanelMain(UserControl control)
        {
            if (this.pnMain.Controls.Count > 0)
            {
                var temp = this.pnMain.Controls[0];
                this.pnMain.Controls.Clear();
                temp.Dispose();
            }
            control.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(control);
        }

        private void Btn_LopHoc_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemLopHoc());
        }

        private void Btn_KetQuaHocTap_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemKetQuaHocTapPageAdmin());
        }

        private void Btn_ThongKeDiem_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new ThongKeDiem());
        }

        private void Btn_DSKhoa_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemDanhSachKhoa());
        }

        private void Btn_DSGiangVien_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemGiangVien());
        }

        private void Btn_DSMonHoc_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemMonHoc());
        }

        private void Btn_DSSinhVien_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemSinhVien());
        }

        private void Btn_XemNamHoc_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemNamHoc());
        }

        private void Btn_XemHocKy_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new XemHocKy());
        }

        private void MenuStrip_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
