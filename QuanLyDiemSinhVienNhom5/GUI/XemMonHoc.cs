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
            LoadGridView();
        }
    }
}
