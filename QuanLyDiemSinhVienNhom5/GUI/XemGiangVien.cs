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
        public XemGiangVien()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            GiangVienInfo giangVienInfo = new GiangVienInfo();
            giangVienInfo.ShowDialog();

            try
            {
                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            GiangVienService giangVienService = new GiangVienService();
            List<GiangVienViewModel> giangVienViewModels = new List<GiangVienViewModel>();
            giangVienViewModels = giangVienService.ListAll();
            LoadDSGiangVien(giangVienViewModels);
        }


        private void XemGiangVien_Load(object sender, EventArgs e)
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
