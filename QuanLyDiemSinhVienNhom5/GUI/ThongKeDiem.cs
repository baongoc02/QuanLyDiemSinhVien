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
    public partial class ThongKeDiem : UserControl
    {
        public ThongKeDiem()
        {
            InitializeComponent();
        }

        [DesignOnly(true)]
        private void ThongKeDiem_Load(object sender, EventArgs e)
        {
            dssvTheoLop_XepLoai1.Visible = false;
            danhSachSinhVienKhongDatMotMon1.Visible = false;
        }

        private void Btn_DSSVTheoMonVaXepLoai_Click(object sender, EventArgs e)
        {
            dssvTheoLop_XepLoai1.Visible = true;
            dssvTheoLop_XepLoai1.BringToFront();
        }

        private void Btn_DSSVKhongDat_Click(object sender, EventArgs e)
        {
            danhSachSinhVienKhongDatMotMon1.Visible = true;
            danhSachSinhVienKhongDatMotMon1.BringToFront();
        }
    }
}
