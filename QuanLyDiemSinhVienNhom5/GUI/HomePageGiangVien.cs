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
    public partial class HomePageGiangVien : Form
    {
        public HomePageGiangVien()
        {
            InitializeComponent();
        }

        [DesignOnly(true)]
        private void HomePageGiangVien_Load(object sender, EventArgs e)
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

            NamHocService namHocService = new NamHocService();
            var listNamHoc = namHocService.ListAll();
            listNamHoc.Insert(0, new NamHocViewModel()
            {
                MaNamHoc = "",
                TenNamHoc = "-- Tất cả năm học --"
            });
            cbNamHoc.DataSource = listNamHoc;
            cbNamHoc.DisplayMember = nameof(NamHocViewModel.TenNamHoc);
            cbNamHoc.ValueMember = nameof(NamHocViewModel.MaNamHoc);

            LopService lopService = new LopService();
            var listLop = lopService.ListAll();
            foreach (var lop in listLop)
            {
                lop.TenLop = lop.MaLop;
            }
            listLop.Insert(0, new LopViewModel()
            {
                MaLop = "",
                TenLop = "-- Tất cả các lớp --"
            });
            cbLopHoc.DataSource = listLop;
            cbLopHoc.DisplayMember = nameof(LopViewModel.TenLop);
            cbLopHoc.ValueMember = nameof(LopViewModel.MaLop);

        }


        private void Btn_Them_Click(object sender, EventArgs e)
        {
            KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
            ketQuaHocTapSinhVien.ketQuaHocTapViewModel = null;
            ketQuaHocTapSinhVien.ShowDialog();
            LoadGridView();

        }

        private void HomePageGiangVien_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HomePageGiangVien_gridview.SelectedRows.Count == 1)
            {
                var data = HomePageGiangVien_gridview.SelectedRows[0].DataBoundItem as TimTrongHomePageGiangVienViewModel;
                KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
                ketQuaHocTapSinhVien.mssv = data.MaSinhVien;
                ketQuaHocTapSinhVien.maLop = data.MaLop;
                ketQuaHocTapSinhVien.ShowDialog();
                LoadGridView();
            }
        }

        public void LoadGridView()
        {
            KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            List<TimTrongHomePageGiangVienViewModel> timTrongHomePageGiangVienViewModels = ketQuaHocTapService.GetTimTrongHomePageGiangVien(txtMonHoc.Text, cbLopHoc.SelectedValue.ToString(), cbNamHoc.SelectedValue.ToString(), cbNamHoc.SelectedValue.ToString(), "teacher11");
            LoadDSSV(timTrongHomePageGiangVienViewModels);
        }

        public void LoadDSSV(IEnumerable<TimTrongHomePageGiangVienViewModel> timTrongHomePageGiangVienViewModels)
        {
            HomePageGiangVien_gridview.Columns.Clear();
            HomePageGiangVien_gridview.DataSource = timTrongHomePageGiangVienViewModels;
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }
    }
}
