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
    public partial class XemGiangVien : UserControl
    {

        private readonly GiangVienService giangVienService = new GiangVienService();
        private readonly KhoaService khoaService = new KhoaService();

        public XemGiangVien()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            GiangVienInfo giangVienInfo = new GiangVienInfo();
            giangVienInfo.ShowDialog();

            LoadGridView();
        }
        private void LoadDSGiangVien(IEnumerable<GiangVienViewModel> giangVienViewModels)
        {
            InfoGiangVien_gridview.Columns.Clear();
            InfoGiangVien_gridview.DataSource = giangVienViewModels;

            InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.FullName)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.NgaySinh)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.GioiTinh)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.SDT)].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.QueQuan)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoGiangVien_gridview.Columns[nameof(GiangVienViewModel.MaKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            InfoGiangVien_gridview.AllowUserToResizeColumns = true;
        }

        private void LoadGridView()
        {
            List<GiangVienViewModel> giangVienViewModels = new List<GiangVienViewModel>();
            giangVienViewModels = giangVienService.ListAll();
            LoadDSGiangVien(giangVienViewModels);
        }

        [DesignOnly(true)]
        private void XemGiangVien_Load(object sender, EventArgs e)
        {
            cbKhoa.DataSource = khoaService.ListAll();
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);

            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            List<GiangVienViewModel> giangVienViewModels = giangVienService.Search(txtMaGiangVien.Text, txtHoTen.Text, "", "", "", "", "", "", cbKhoa.SelectedValue.ToString());
            LoadDSGiangVien(giangVienViewModels);
        }
    }
}
