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
    public partial class MonHocInfo : Form
    {
        private readonly MonHocService monHocService;
        private readonly KhoaService khoaService;
        public MonHocInfo()
        {
            this.monHocService = new MonHocService();
            this.khoaService = new KhoaService();

            this.monHocService.OnSuccessMessage += MonHocService_OnSuccessMessage;
            this.monHocService.OnErrorMessage += MonHocService_OnErrorMessage;

            InitializeComponent();
        }

        private void MonHocService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MonHocService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTextBox()
        {

        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            MonHoc monHoc = new MonHoc();
            monHoc.MaMonHoc = txtMaMonHoc.Text;
            monHoc.TenMonHoc = txtTenMonHoc.Text;
            monHoc.MoTa = txtMoTa.Text;
            monHoc.STC = Convert.ToInt32(txtSoTinChi.Text);
            monHoc.LoaiHocPhan = txtLoaiHocPhan.Text;
            monHoc.MaKhoa = cbKhoa.SelectedValue.ToString();

            if (this.monHocService.CheckMonHocExists(monHoc.MaMonHoc))
            {
                this.monHocService.Update(monHoc.MaMonHoc, monHoc);
                LoadTextBox();
            }
            else
            {
                this.monHocService.Create(monHoc);
                LoadTextBox();
            }
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            MonHoc monHoc = new MonHoc() { MaMonHoc = txtMaMonHoc.Text };

            string message = "Bạn có chắc muốn xóa môn học này không?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.monHocService.Delete(monHoc.MaMonHoc);
                LoadTextBox();
            }
        }

        private void btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void MonHocInfo_Load(object sender, EventArgs e)
        {
            cbKhoa.DataSource = this.khoaService.ListAll();
            cbKhoa.DisplayMember = nameof(KhoaViewModel.TenKhoa);
            cbKhoa.ValueMember = nameof(KhoaViewModel.MaKhoa);
        }
    }
}
