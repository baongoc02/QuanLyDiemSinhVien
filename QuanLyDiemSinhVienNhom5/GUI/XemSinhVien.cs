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
    public partial class XemSinhVien : UserControl
    {
        private readonly SinhVienService sinhVienService = new SinhVienService();

        public XemSinhVien()
        {
            sinhVienService.OnSuccessMessage += SinhVienService_OnSuccessMessage;
            sinhVienService.OnErrorMessage += SinhVienService_OnErrorMessage;

            InitializeComponent();
        }

        private void SinhVienService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void SinhVienService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            SinhVienInfo sinhVienInfo = new SinhVienInfo();
            sinhVienInfo.sinhVienViewModel = null;
            sinhVienInfo.ShowDialog();
            LoadGridView();
        }

        public void LoadDSSinhVien(IEnumerable<SinhVienViewModel> sinhVienViewModels)
        {
            SinhVien_gridview.Columns.Clear();
            SinhVien_gridview.DataSource = sinhVienViewModels;
        }

        public void LoadGridView()
        {
            List<SinhVienViewModel> sinhVienViewModels = new List<SinhVienViewModel>();
            sinhVienViewModels = sinhVienService.ListAll();
            LoadDSSinhVien(sinhVienViewModels);
        }

        [DesignOnly(true)]
        private void XemSinhVien_Load(object sender, EventArgs e)
        {
            KhoaService khoaService = new KhoaService();
            var listKhoa = khoaService.ListAll();
            listKhoa.Insert(0, new KhoaViewModel()
            {
                MaKhoa = "",
                TenKhoa = "-- Tất cả khoa --"
            });
            cbKhoa.DataSource = listKhoa;
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);

            LoadGridView();
        }

        private void SinhVien_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SinhVien_gridview.SelectedRows.Count == 1)
            {
                var data = SinhVien_gridview.SelectedRows[0].DataBoundItem as SinhVienViewModel;

                SinhVienInfo sinhVienInfo = new SinhVienInfo();
                sinhVienInfo.sinhVienViewModel = data;
                sinhVienInfo.ShowDialog();

                LoadGridView();
            }
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            List<SinhVienViewModel> sinhVienViewModels = sinhVienService.Search(txtMSSV.Text, txtHoTen.Text, "", "", "", "", cbKhoa.SelectedValue.ToString());
            LoadDSSinhVien(sinhVienViewModels);
        }

        private void Btn_Import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Excel file (*.xls)|*.xls";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.sinhVienService.ImportSinhVienFromFile(dialog.FileName);
                    this.Btn_Tim_Click(null, null);
                }
            }
        }
    }
}
