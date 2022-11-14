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
    public partial class LopHocInfo : Form
    {
        private readonly LopService lopService;
        private readonly HocKyService hocKyService;
        private readonly MonHocService monHocService;
        private readonly GiangVienService giangVienService;
        public LopViewModel lopViewModel;

        public LopHocInfo()
        {
            this.lopService = new LopService();
            this.hocKyService = new HocKyService();
            this.monHocService = new MonHocService();
            this.giangVienService = new GiangVienService();

            this.lopService.OnSuccessMessage += LopService_OnSuccessMessage;
            this.lopService.OnErrorMessage += LopService_OnErrorMessage;

            InitializeComponent();
        }

        private void LopService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LopService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTextBox()
        {
            txtMaLop.Text = "";
            cbHocKy.Text = "";
            cbMonHoc.Text = "";
            cbGiangVien.Text = "";
            txtLichHoc.Text = "";
            dtNgayBatDau.Text = "";
            dtNgayKetThuc.Text = "";
            txtGioiHan.Text = "";
        }

        [DesignOnly(true)]
        private void LopHocInfo_Load(object sender, EventArgs e)
        {
            cbGiangVien.DataSource = giangVienService.ListAll();
            cbGiangVien.DisplayMember = nameof(GiangVienViewModel.HoTen);
            cbGiangVien.ValueMember = nameof(GiangVienViewModel.MaGiangVien);

            cbHocKy.DataSource = hocKyService.ListAll();
            cbHocKy.DisplayMember = nameof(HocKyViewModel.TenHocKy);
            cbHocKy.ValueMember = nameof(HocKyViewModel.MaHocKy);

            cbMonHoc.DataSource = monHocService.ListAll();
            cbMonHoc.DisplayMember = nameof(MonHocViewModel.TenMonHoc);
            cbMonHoc.ValueMember = nameof(MonHocViewModel.MaMonHoc);

            //HocKyViewModel hocKyViewModel = hocKyService.Search(lopViewModel.MaHocKy, "", "").First();
            //MonHocViewModel monHocViewModel = monHocService.Search(lopViewModel.MaMonHoc, "", "", "", "").First();
            //GiangVienViewModel giangVienViewModel = giangVienService.Search(lopViewModel.MaGiangVien, "", "", "", "", "", "", "", "").First();
            if (this.lopViewModel != null)
            {
                txtMaLop.Text = this.lopViewModel.MaLop;
                cbHocKy.Text = this.lopViewModel.MaHocKy;
                cbMonHoc.Text = this.lopViewModel.MaMonHoc;
                cbGiangVien.Text = this.lopViewModel.MaGiangVien;
                txtLichHoc.Text = this.lopViewModel.LichHoc;
                dtNgayBatDau.Value = this.lopViewModel.NgayBatDau;
                dtNgayKetThuc.Value = this.lopViewModel.NgayKetThuc;
                txtGioiHan.Text = this.lopViewModel.GioiHan.ToString();
            }
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            lop.MaLop = txtMaLop.Text;
            lop.MaMonHoc = cbMonHoc.SelectedValue.ToString();
            lop.MaGiangVien = cbGiangVien.SelectedValue.ToString();
            lop.MaHocKy = cbHocKy.SelectedValue.ToString();
            lop.LichHoc = txtLichHoc.Text;
            lop.NgayBatDau = dtNgayBatDau.Value;
            lop.NgayKetThuc = dtNgayKetThuc.Value;
            lop.GioiHan = Convert.ToInt32(txtGioiHan.Text);

            if (this.lopService.CheckLopExists(lop.MaLop))
            {
                this.lopService.Update(lop.MaLop, lop);
                this.LoadTextBox();
            }
            else
            {
                this.lopService.Create(lop);
                this.LoadTextBox();
            }
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            Lop lop = new Lop();
            lop.MaLop = txtMaLop.Text;

            string message = "Bạn có chắc muốn xóa lớp này?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.lopService.Delete(lop.MaLop);
                this.LoadTextBox();
            }
        }

        private void Btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
