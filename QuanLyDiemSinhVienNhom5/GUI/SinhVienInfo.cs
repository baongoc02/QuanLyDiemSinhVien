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
    public partial class SinhVienInfo : Form
    {
        private readonly SinhVienService sinhVienService;
        private readonly KhoaService khoaService;
        public SinhVienViewModel sinhVienViewModel;

        public SinhVienInfo()
        {
            this.sinhVienService = new SinhVienService();
            this.khoaService = new KhoaService();

            this.sinhVienService.OnSuccessMessage += SinhVienService_OnSuccessMessage;
            this.sinhVienService.OnErrorMessage += SinhVienService_OnErrorMessage;

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

        private void LoadTextBox()
        {
            txtMaSoSinhVien.Text = "";
            txtHoTen.Text = "";
            dtNgaySinh.Text = "";
            txtGioiTinh.Text = "";
            txtQueQuan.Text = "";
            txtCMND.Text = "";
            txtSoDienThoai.Text = "";
            cbKhoa.Text = "";
        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            SinhVien sinhVien = new SinhVien();
            sinhVien.MaSinhVien = txtMaSoSinhVien.Text;
            sinhVien.HoTen = txtHoTen.Text;
            sinhVien.NgaySinh = dtNgaySinh.Value;
            sinhVien.GioiTinh = txtGioiTinh.Text;
            sinhVien.QueQuan = txtQueQuan.Text;
            sinhVien.CMND = txtCMND.Text;
            sinhVien.SDT = txtSoDienThoai.Text;
            sinhVien.MaKhoa = cbKhoa.SelectedValue.ToString();

            if (this.sinhVienService.CheckSinhVienExists(sinhVien.MaSinhVien))
            {
                this.sinhVienService.Update(sinhVien.MaSinhVien, sinhVien);
            }
            else
            {
                this.sinhVienService.Create(sinhVien);
            }
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            SinhVien sinhVien = new SinhVien();
            sinhVien.MaSinhVien = txtMaSoSinhVien.Text;

            string message = "Bạn có chắc muốn xóa giảng viên này?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.sinhVienService.Delete(sinhVien.MaSinhVien);
                this.LoadTextBox();
            }
        }

        private void Btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DesignOnly(true)]
        private void SinhVienInfo_Load(object sender, EventArgs e)
        {
            cbKhoa.DataSource = khoaService.ListAll();
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);
            if (this.sinhVienViewModel != null)
            {
                txtMaSoSinhVien.Text = this.sinhVienViewModel.MaSinhVien;
                txtHoTen.Text = this.sinhVienViewModel.HoTen;
                dtNgaySinh.Value = this.sinhVienViewModel.NgaySinh;
                txtGioiTinh.Text = this.sinhVienViewModel.GioiTinh;
                txtCMND.Text = this.sinhVienViewModel.CMND;
                txtSoDienThoai.Text = this.sinhVienViewModel.SDT;
                txtQueQuan.Text = this.sinhVienViewModel.QueQuan;

                KhoaViewModel khoaViewModel = khoaService.Search(sinhVienViewModel.MaKhoa, "", "").FirstOrDefault();
                cbKhoa.Text = khoaViewModel.TenKhoa;
            }
        }
    }
}
