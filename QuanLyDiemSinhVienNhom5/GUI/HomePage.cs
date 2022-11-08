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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Btn_SinhVien_Click(object sender, EventArgs e)
        {
            xemSinhVien1.Visible = true;
            xemSinhVien1.BringToFront();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            xemGiangVien1.Visible = false;
            xemSinhVien1.Visible = false;
            xemMonHoc1.Visible = false;
            xemLopHoc1.Visible = false;
            xemKetQuaHocTap1.Visible = false;
            thongKeDiem1.Visible = false;

        }

        private void Btn_GiangVien_Click(object sender, EventArgs e)
        {
            xemGiangVien1.Visible = true;
            xemGiangVien1.BringToFront();
        }

        private void Btn_MonHoc_Click(object sender, EventArgs e)
        {
            xemMonHoc1.Visible = true;
            xemMonHoc1.BringToFront();
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
    }
}
