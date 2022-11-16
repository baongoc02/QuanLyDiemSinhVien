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
    public enum DialogState
    {
        Create = 0,
        Update = 1
    }

    public partial class GiangVienInfo : Form
    {
        private readonly GiangVienService giangVienService;
        private readonly KhoaService khoaService;
        public GiangVienViewModel giangVienViewModel;

        public GiangVienInfo(DialogState state)
        {
            this.giangVienService = new GiangVienService();
            this.khoaService = new KhoaService();

            this.giangVienService.OnSuccessMessage += GiangVienService_OnSuccessMessage;
            this.giangVienService.OnErrorMessage += GiangVienService_OnErrorMessage;

            InitializeComponent();

            if (state == DialogState.Update)
                this.txtMatKhau.Enabled = false;
        }

        private void GiangVienService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GiangVienService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTextBox()
        {
            txtMaGiangVien.Text = "";
            txtHoTen.Text = "";
            dtNgaySinh.Text = "";
            txtSoDienThoai.Text = "";
            txtQueQuan.Text = "";
            txtSoDienThoai.Text = "";
            txtGioiTinh.Text = "";
            txtCMND.Text = "";
            txtHocHam.Text = "";
            txtHocVi.Text = "";
            cbKhoa.Text = "";
        }

        private void Btn_Sua_Click(object sender, EventArgs e)
        {
            GiangVien giangVien = new GiangVien();
            giangVien.MaGiangVien = txtMaGiangVien.Text;
            giangVien.HoTen = txtHoTen.Text;
            giangVien.NgaySinh = dtNgaySinh.Value;
            giangVien.SDT = txtSoDienThoai.Text;
            giangVien.QueQuan = txtQueQuan.Text;
            giangVien.GioiTinh = txtGioiTinh.Text;
            giangVien.CMND = txtCMND.Text;
            giangVien.HocHam = txtHocHam.Text;  
            giangVien.HocVi = txtHocVi.Text;    
            giangVien.MaKhoa = cbKhoa.SelectedValue.ToString();

            if (this.giangVienService.CheckGiangVienExists(giangVien.MaGiangVien))
            {
                this.giangVienService.Update(giangVien.MaGiangVien, giangVien); 
            }
            else
            {
                giangVien.Password = txtMatKhau.Text;
                this.giangVienService.CreateWithPassword(giangVien);
            }
        }

        private void Btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            GiangVien giangVien = new GiangVien();
            giangVien.MaGiangVien = txtMaGiangVien.Text;

            string message = "Bạn có chắc muốn xóa giảng viên này?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.giangVienService.Delete(giangVien.MaGiangVien);
                this.LoadTextBox();
            }
        }

        [DesignOnly(true)]
        private void GiangVienInfo_Load(object sender, EventArgs e)
        {
            cbKhoa.DataSource = this.khoaService.ListAll();
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);
            if (this.giangVienViewModel != null)
            {
                txtMaGiangVien.Text = this.giangVienViewModel.MaGiangVien;
                txtHoTen.Text = this.giangVienViewModel.HoTen;
                dtNgaySinh.Value = this.giangVienViewModel.NgaySinh;
                txtSoDienThoai.Text = this.giangVienViewModel.SDT;
                txtGioiTinh.Text = this.giangVienViewModel.GioiTinh;
                txtQueQuan.Text = this.giangVienViewModel.QueQuan;
                txtCMND.Text = this.giangVienViewModel.CMND;
                txtHocHam.Text = this.giangVienViewModel.HocHam;
                txtHocVi.Text = this.giangVienViewModel.HocVi;

                KhoaViewModel khoaViewModels = khoaService.Search(this.giangVienViewModel.MaKhoa, "", "").FirstOrDefault();
                cbKhoa.Text = khoaViewModels.TenKhoa;
            }
        }
    }
}
