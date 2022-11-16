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
        //private static readonly AppSetting _setting;
        public HomePageAdmin()
        {
            //_setting.Login("sa", "123456");
            InitializeComponent();
        }

        [DesignOnly(true)]
        private void HomePage_Load(object sender, EventArgs e)
        {
            xemGiangVien1.Visible = false;
            xemSinhVien1.Visible = false;
            xemMonHoc1.Visible = false;
            xemLopHoc1.Visible = false;
            xemKetQuaHocTap1.Visible = false;
            thongKeDiem1.Visible = false;
            xemDanhSachKhoa1.Visible = false;
            xemNamHoc1.Visible = false;
            xemHocKy1.Visible = false;
        }

        private void Btn_LopHoc_Click(object sender, EventArgs e)
        {
            xemLopHoc1.Visible = true;
            xemLopHoc1.BringToFront();
        }

        private void Btn_KetQuaHocTap_Click(object sender, EventArgs e)
        {
            xemKetQuaHocTap1.Visible = true;
            xemKetQuaHocTap1.BringToFront();
        }

        private void Btn_ThongKeDiem_Click(object sender, EventArgs e)
        {
            thongKeDiem1.Visible = true;
            thongKeDiem1.BringToFront();
        }

        private void Btn_DSKhoa_Click(object sender, EventArgs e)
        {
            xemDanhSachKhoa1.Visible = true;
            xemDanhSachKhoa1.BringToFront();
        }

        private void Btn_DSGiangVien_Click(object sender, EventArgs e)
        {
            xemGiangVien1.Visible = true;
            xemGiangVien1.BringToFront();
        }

        private void Btn_DSMonHoc_Click(object sender, EventArgs e)
        {
            xemMonHoc1.Visible = true;
            xemMonHoc1.BringToFront();
        }

        private void Btn_DSSinhVien_Click(object sender, EventArgs e)
        {
            xemSinhVien1.Visible = true;
            xemSinhVien1.BringToFront();
        }

        private void Btn_XemNamHoc_Click(object sender, EventArgs e)
        {
            xemNamHoc1.Visible = true;
            xemNamHoc1.BringToFront();
        }

        private void Btn_XemHocKy_Click(object sender, EventArgs e)
        {
            xemHocKy1.Visible = true;
            xemHocKy1.BringToFront();
        }

        private void MenuStrip_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
