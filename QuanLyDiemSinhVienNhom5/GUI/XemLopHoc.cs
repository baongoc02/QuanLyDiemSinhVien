using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
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
    public partial class XemLopHoc : UserControl
    {
        public XemLopHoc()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            LopHocInfo lopHocInfo = new LopHocInfo();
            lopHocInfo.ShowDialog();
            LoadGridView();
        }

        private void LoadDSLop(IEnumerable<LopViewModel> lopViewModels)
        {
            Lop_gridview.Columns.Clear();
            Lop_gridview.DataSource = lopViewModels;
        }

        private void LoadGridView()
        {
            LopService lopService = new LopService();
            List<LopViewModel> lopViewModels = new List<LopViewModel>();
            lopViewModels = lopService.ListAll();
            LoadDSLop(lopViewModels);
        }

        [DesignOnly(true)]
        private void XemLopHoc_Load(object sender, EventArgs e)
        {
            HocKyService hocKyService = new HocKyService();
            cbHocKy.DataSource = hocKyService.ListAll();
            cbHocKy.DisplayMember = nameof(HocKyViewModel.TenHocKy);
            cbHocKy.ValueMember = nameof(HocKyViewModel.MaHocKy);

            MonHocService monHocService = new MonHocService();
            cbMon.DataSource = monHocService.ListAll();
            cbMon.DisplayMember = nameof(MonHocViewModel.TenMonHoc);
            cbMon.ValueMember = nameof(MonHocViewModel.MaMonHoc);

            GiangVienService giangVienService = new GiangVienService();
            cbGiangVien.DataSource = giangVienService.ListAll();
            cbGiangVien.DisplayMember = nameof(GiangVienViewModel.HoTen);
            cbGiangVien.ValueMember = nameof(GiangVienViewModel.MaGiangVien);

            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            LopService lopService = new LopService();
            List<LopViewModel> lopViewModels = lopService.Search(txtMaLop.Text, cbHocKy.SelectedValue.ToString(), cbMon.SelectedValue.ToString(), cbGiangVien.SelectedValue.ToString(), "");
            LoadDSLop(lopViewModels);
        }
    }
}
