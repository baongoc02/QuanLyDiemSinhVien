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
    public partial class XemDanhSachKhoa : UserControl
    {
        public XemDanhSachKhoa()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            KhoaInfo khoaInfo = new KhoaInfo();
            khoaInfo.ShowDialog();
            try
            {
                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDSKhoa(IEnumerable<KhoaViewModel> khoaViewModels)
        {
            InfoKhoa_gridview.Columns.Clear();
            InfoKhoa_gridview.DataSource = khoaViewModels;

            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.MaKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.TenKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.HeDaoTao)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.NgayThanhLap)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            InfoKhoa_gridview.AllowUserToResizeColumns = true;
        }

        private void LoadGridView()
        {
            KhoaService khoaService = new KhoaService();
            List<KhoaViewModel> khoaViewModels  = new List<KhoaViewModel>();
            khoaViewModels = khoaService.ListAll();
            LoadDSKhoa(khoaViewModels);
        }

        private void XemDanhSachKhoa_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridView();
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
