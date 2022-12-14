using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.Core.ViewModel;
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
    public partial class XemKetQuaHocTapPageAdmin : UserControl
    {
        private readonly KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
        private readonly LopService lopService = new LopService();
        public XemKetQuaHocTapPageAdmin()
        {
            this.ketQuaHocTapService.OnSuccessMessage += KetQuaHocTapService_OnSuccessMessage;
            this.ketQuaHocTapService.OnErrorMessage += KetQuaHocTapService_OnErrorMessage;
            InitializeComponent();
        }

        private void KetQuaHocTapService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void KetQuaHocTapService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
            ketQuaHocTapSinhVien.ShowDialog();
        }

        private void LoadDSKetQuaHocTap(IEnumerable<KetQuaHocTapTheoSinhVienViewModel> ketQuaHocTapTheoSinhVienViewModels)
        {
            KetQuaHocTap_gridview.Columns.Clear();
            KetQuaHocTap_gridview.DataSource = ketQuaHocTapTheoSinhVienViewModels;
        }

        [DesignOnly(true)]
        private void XemKetQuaHocTapPageAdmin_Load(object sender, EventArgs e)
        {
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            List<KetQuaHocTapTheoSinhVienViewModel> ketQuaHocTapTheoSinhVienViewModels = ketQuaHocTapService.GetKetQuaHocTapTheoSinhVien(txtMSSV.Text);
            LoadDSKetQuaHocTap(ketQuaHocTapTheoSinhVienViewModels);

            TinhSTCAndDiemTrungBinhViewModel tinhSTCAndDiemTrungBinhViewModel = ketQuaHocTapService.GetTinhSTCAndDiemTrungBinh(txtMSSV.Text).FirstOrDefault();
            if (tinhSTCAndDiemTrungBinhViewModel != null)
            {
                txtDTBTichLuy.Text = tinhSTCAndDiemTrungBinhViewModel.DiemTrungBinh.ToString();
                txtSTCTichLuy.Text = tinhSTCAndDiemTrungBinhViewModel.STC.ToString();
                txtXepLoai.Text = tinhSTCAndDiemTrungBinhViewModel.Loai.ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên này", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KetQuaHocTap_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (KetQuaHocTap_gridview.SelectedRows.Count == 1)
            {
                var data = KetQuaHocTap_gridview.SelectedRows[0].DataBoundItem as KetQuaHocTapTheoSinhVienViewModel;
                KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
                ketQuaHocTapSinhVien.mssv = data.MaSinhVien;
                ketQuaHocTapSinhVien.maLop = data.MaLop;
                ketQuaHocTapSinhVien.ShowDialog();
            }
        }

    }
}
