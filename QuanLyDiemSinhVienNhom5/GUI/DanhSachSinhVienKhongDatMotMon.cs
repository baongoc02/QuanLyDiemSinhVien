using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.Core.ViewModel;
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
        public DanhSachSinhVienKhongDatMotMon()
        {
            InitializeComponent();
        }


        public void LoadDSSVKhongDatMotMon(IEnumerable<DSSVKhongDatMonHocViewModel> dSSVKhongDatMonHocViewModels)
        {
            DSSV_gridview.Columns.Clear();
            DSSV_gridview.DataSource = dSSVKhongDatMonHocViewModels;


            txtSoLuong.Text =  DSSV_gridview.RowCount.ToString();

        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            List<DSSVKhongDatMonHocViewModel> dSSVKhongDatMonHocViewModels = ketQuaHocTapService.GetDSSVKhongDatMonHoc(cbMon.SelectedValue.ToString(), cbHocKy.SelectedValue.ToString());
            LoadDSSVKhongDatMotMon(dSSVKhongDatMonHocViewModels);
        }

        [DesignOnly(true)]
        private void DanhSachSinhVienKhongDatMotMon_Load(object sender, EventArgs e)
        {
            MonHocService monHocService = new MonHocService();
            var listMonHoc = monHocService.ListAll();
            listMonHoc.Insert(0, new MonHocViewModel()
            {
                MaMonHoc = "",
                TenMonHoc = "-- Tất cả môn học --"
            });
            cbMon.DataSource = listMonHoc;
            cbMon.DisplayMember = nameof(MonHocViewModel.TenMonHoc);
            cbMon.ValueMember = nameof(MonHocViewModel.MaMonHoc);

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
