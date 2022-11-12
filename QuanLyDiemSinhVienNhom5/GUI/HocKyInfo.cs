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
    public partial class HocKyInfo : Form
    {
        private readonly HocKyService hocKyService;
        private readonly NamHocService namHocService;
        public HocKyInfo()
        {
            this.hocKyService = new HocKyService();
            this.namHocService = new NamHocService();

            this.hocKyService.OnSuccessMessage += HocKyService_OnSuccessMessage;
            this.hocKyService.OnErrorMessage += HocKyService_OnErrorMessage;

            InitializeComponent();
        }

        private void HocKyService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void HocKyService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTextBox()
        {
            txtMaHocKy.Text = "";
            txtTenHocKy.Text = "";
            dtNgayBatDau.Text = "";
            dtNgayKetThuc.Text = "";
            cbNamHoc.Text = "";
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            HocKy hocKy = new HocKy();
            hocKy.MaHocKy = txtMaHocKy.Text;
            hocKy.TenHocKy = txtTenHocKy.Text;
            hocKy.NgayBatDau = dtNgayBatDau.Value;
            hocKy.NgayKetThuc = dtNgayKetThuc.Value;
            hocKy.MaNamHoc = cbNamHoc.SelectedValue.ToString();

            if (this.hocKyService.CheckHocKyExists(hocKy.MaHocKy))
            {
                this.hocKyService.Update(hocKy.MaHocKy, hocKy);
                LoadTextBox();
            }
            else
            {
                this.hocKyService.Create(hocKy);
                LoadTextBox();
            }

        }

        private void Btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            HocKy hocKy = new HocKy();
            hocKy.MaHocKy = txtMaHocKy.Text;

            string message = "Bạn có chắc muốn xóa học kỳ này?";
            string title = "Mesage";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.hocKyService.Delete(hocKy.MaHocKy);
                LoadTextBox();
            }
        }

        private void HocKyInfo_Load(object sender, EventArgs e)
        {
            cbNamHoc.DataSource = namHocService.ListAll();
            cbNamHoc.DisplayMember = nameof(NamHocViewModel.TenNamHoc);
            cbNamHoc.ValueMember = nameof(NamHocViewModel.MaNamHoc);
        }
    }
}
