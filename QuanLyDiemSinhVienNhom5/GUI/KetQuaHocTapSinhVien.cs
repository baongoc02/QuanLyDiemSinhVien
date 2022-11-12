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
    public partial class KetQuaHocTapSinhVien : Form
    {
        private readonly KetQuaHocTapService ketQuaHocTapService;
        private readonly LopService lopService;

        public KetQuaHocTapSinhVien()
        {
            this.ketQuaHocTapService = new KetQuaHocTapService();
            this.lopService = new LopService();

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

        private void LoadTextBox()
        {
            txtMaSinhVien.Text = "";
            cbLop.Text = "";
            txtDiemGiuaKy.Text = "";
            txtDiemCuoiKy.Text = "";
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            KetQuaHocTap ketQuaHocTap = new KetQuaHocTap();
            ketQuaHocTap.MaSinhVien = txtMaSinhVien.Text;
            ketQuaHocTap.MaLop = cbLop.SelectedValue.ToString();

            string message = "Bạn có chắc muốn xóa kết quả học tập này?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.ketQuaHocTapService.Delete(ketQuaHocTap.MaSinhVien, ketQuaHocTap.MaLop);
                this.LoadTextBox();
            }
        }

        [DesignOnly(true)]
        private void KetQuaHocTapSinhVien_Load(object sender, EventArgs e)
        {
            cbLop.DataSource = lopService.ListAll();
            cbLop.DisplayMember = nameof(LopViewModel.MaLop);
            cbLop.ValueMember = nameof(LopViewModel.MaLop);
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            KetQuaHocTap ketQuaHocTap = new KetQuaHocTap();
            ketQuaHocTap.MaSinhVien = txtMaSinhVien.Text;
            ketQuaHocTap.MaLop = cbLop.SelectedValue.ToString();
            ketQuaHocTap.DiemGiuaKy = (float)Convert.ToDouble(txtDiemGiuaKy.Text);
            ketQuaHocTap.DiemCuoiKy = (float)Convert.ToDouble(txtDiemCuoiKy.Text);

            if (this.ketQuaHocTapService.CheckKetQuaHocTapExists(ketQuaHocTap.MaSinhVien, ketQuaHocTap.MaLop))
            {
                this.ketQuaHocTapService.Update(ketQuaHocTap.MaSinhVien, ketQuaHocTap.MaLop, ketQuaHocTap);
                LoadTextBox();
            }
            else
            {
                this.ketQuaHocTapService.Create(ketQuaHocTap);
                LoadTextBox();
            }
        }

        private void Btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
