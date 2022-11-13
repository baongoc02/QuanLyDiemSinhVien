using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
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

    public partial class XemHocKy : UserControl
    {
        private readonly HocKyService hocKyService = new HocKyService();
        private readonly NamHocService namHocService = new NamHocService();
        public XemHocKy()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            HocKyInfo hocKyInfo = new HocKyInfo();
            hocKyInfo.hocKyViewModel = null;
            hocKyInfo.ShowDialog();
            LoadGridView();
        }

        public void LoadDSHocKy(IEnumerable<HocKyViewModel> hocKyViewModels)
        {
            HocKy_gridview.Columns.Clear();
            HocKy_gridview.DataSource = hocKyViewModels;

            HocKy_gridview.Columns[nameof(HocKyViewModel.MaHocKy)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HocKy_gridview.Columns[nameof(HocKyViewModel.TenHocKy)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HocKy_gridview.Columns[nameof(HocKyViewModel.NgayBatDau)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HocKy_gridview.Columns[nameof(HocKyViewModel.NgayKetThuc)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            HocKy_gridview.Columns[nameof(HocKyViewModel.MaNamHoc)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void LoadGridView()
        {
            List<HocKyViewModel> hocKyViewModels = new List<HocKyViewModel>();
            hocKyViewModels = hocKyService.ListAll();
            LoadDSHocKy(hocKyViewModels);
        }


        [DesignOnly(true)]
        private void XemHocKy_Load(object sender, EventArgs e)
        {

            NamHocService namHocService = new NamHocService();
            var listNamHoc = namHocService.ListAll();
            listNamHoc.Insert(0, new NamHocViewModel()
            {
                MaNamHoc = null,
                TenNamHoc = "-- Tất cả học kỳ --"
            });
            cbNamHoc.DataSource = listNamHoc;
            cbNamHoc.DisplayMember = nameof(NamHocViewModel.TenNamHoc);
            cbNamHoc.ValueMember = nameof(NamHocViewModel.MaNamHoc);

            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            List<HocKyViewModel> hocKyViewModels = hocKyService.Search(txtHocKy.Text, "", cbNamHoc.SelectedValue.ToString());
            LoadDSHocKy(hocKyViewModels);
        }

        private void HocKy_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (HocKy_gridview.SelectedRows.Count == 1)
            {
                var data = HocKy_gridview.SelectedRows[0].DataBoundItem as HocKyViewModel;
                HocKyInfo hocKyInfo = new HocKyInfo();
                hocKyInfo.hocKyViewModel = data;
                hocKyInfo.ShowDialog();
                LoadGridView();
            }
        }
    }
}
