using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.ViewModel;
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
    public partial class DanhSachSinhVienKhongDatMotMon : UserControl
    {
        //TODO: DSSV không đạt một môn theo học kỳ
        public DanhSachSinhVienKhongDatMotMon()
        {
            InitializeComponent();
        }


        private void DSSV_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {

        }

        [DesignOnly(true)]
        private void DanhSachSinhVienKhongDatMotMon_Load(object sender, EventArgs e)
        {
            HocKyService hocKyService = new HocKyService();
            var listHocKy = hocKyService.ListAll();
            listHocKy.Insert(0, new HocKyViewModel()
            {
                MaHocKy = "",
                TenHocKy = "-- Tất cả học kỳ --"
            });
            cbHocKy.DataSource = listHocKy;
            cbHocKy.DisplayMember = nameof(HocKyViewModel.TenHocKy);
            cbHocKy.ValueMember = nameof(HocKyViewModel.MaHocKy);
        }
    }
}
