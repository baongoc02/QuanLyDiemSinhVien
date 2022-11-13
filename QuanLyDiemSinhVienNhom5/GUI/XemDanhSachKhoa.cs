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
            khoaInfo.khoaViewModel = null;
            khoaInfo.ShowDialog();
            LoadGridView();
        }

        private void LoadDSKhoa(IEnumerable<KhoaViewModel> khoaViewModels)
        {
            this.InfoKhoa_gridview.SelectionChanged -= this.InfoKhoa_gridview_SelectionChanged;
            InfoKhoa_gridview.Columns.Clear();
            InfoKhoa_gridview.DataSource = khoaViewModels;

            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.MaKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.TenKhoa)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.HeDaoTao)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            InfoKhoa_gridview.Columns[nameof(KhoaViewModel.NgayThanhLap)].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            InfoKhoa_gridview.AllowUserToResizeColumns = true;
            //this.InfoKhoa_gridview.SelectionChanged += this.InfoKhoa_gridview_SelectionChanged;
        }

        private void LoadGridView()
        {
            KhoaService khoaService = new KhoaService();
            List<KhoaViewModel> khoaViewModels = khoaService.ListAll();
            LoadDSKhoa(khoaViewModels);
        }

        [DesignOnly(true)]
        private void XemDanhSachKhoa_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            KhoaService khoaService = new KhoaService();
            List<KhoaViewModel> khoaViewModels = khoaService.Search(txtMaKhoa.Text, txtTenKhoa.Text, txtHeDaoTao.Text);
            LoadDSKhoa(khoaViewModels);
        }

        private void InfoKhoa_gridview_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void InfoKhoa_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InfoKhoa_gridview.SelectedRows.Count == 1)
            {
                var data = (InfoKhoa_gridview.SelectedRows[0].DataBoundItem as KhoaViewModel);
                KhoaInfo khoaInfo = new KhoaInfo();
                khoaInfo.khoaViewModel = data;
                khoaInfo.ShowDialog();
                LoadGridView();
            }
        }
    }
}
