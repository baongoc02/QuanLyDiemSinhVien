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
    public partial class XemMonHoc : UserControl
    {
        public XemMonHoc()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            MonHocInfo monHocInfo = new MonHocInfo();
            monHocInfo.ShowDialog();
            LoadGridView();
        }
        public void LoadDSMonHoc(IEnumerable<MonHocViewModel> monHocViewModels)
        {
            MonHoc_gridview.Columns.Clear();
            MonHoc_gridview.DataSource = monHocViewModels;

            MonHoc_gridview.Columns[nameof(MonHocViewModel.MaMonHoc)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc_gridview.Columns[nameof(MonHocViewModel.TenMonHoc)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc_gridview.Columns[nameof(MonHocViewModel.MoTa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc_gridview.Columns[nameof(MonHocViewModel.STC)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc_gridview.Columns[nameof(MonHocViewModel.LoaiHocPhan)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            MonHoc_gridview.Columns[nameof(MonHocViewModel.MaKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void LoadGridView()
        {
            MonHocService monHocService = new MonHocService();
            List<MonHocViewModel> monHocViewModels = new List<MonHocViewModel>();
            monHocViewModels = monHocService.ListAll();
            LoadDSMonHoc(monHocViewModels);
        }

        [DesignOnly(true)]
        private void XemMonHoc_Load(object sender, EventArgs e)
        {
            KhoaService khoaService = new KhoaService();
            var listKhoa = khoaService.ListAll();
            listKhoa.Insert(0, new KhoaViewModel()
            {
                MaKhoa = null,
                TenKhoa = "-- Tất cả khoa --"
            });
            cbKhoa.DataSource = listKhoa;
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);

            LoadGridView();
        }

        private void MonHoc_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MonHoc_gridview.SelectedRows.Count == 1)
            {
                var data = MonHoc_gridview.SelectedRows[0].DataBoundItem as MonHocViewModel;

                MonHocInfo monHocInfo = new MonHocInfo();
                monHocInfo.monHocViewModel = data;
                monHocInfo.ShowDialog();
                LoadGridView();
            }
        }
    }
}
