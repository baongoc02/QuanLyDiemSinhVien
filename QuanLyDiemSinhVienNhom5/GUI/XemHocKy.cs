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
    public partial class XemHocKy : UserControl
    {
        public XemHocKy()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            HocKyInfo hocKyInfo = new HocKyInfo();
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
            HocKyService hocKyService = new HocKyService();
            List<HocKyViewModel> hocKyViewModels = new List<HocKyViewModel>();
            hocKyViewModels = hocKyService.ListAll();
            LoadDSHocKy(hocKyViewModels);   
        }

        private void XemHocKy_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
