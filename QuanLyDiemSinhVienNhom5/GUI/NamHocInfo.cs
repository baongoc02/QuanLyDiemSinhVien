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
    public partial class NamHocInfo : Form
    {
        private readonly NamHocService namHocService;
        public NamHocViewModel namHocViewModel;

        public NamHocInfo()
        {
            this.namHocService = new NamHocService();
            this.namHocService.OnSuccessMessage += NamHocService_OnSuccessMessage;
            this.namHocService.OnErrorMessage += NamHocService_OnErrorMessage;

            InitializeComponent();
        }

        private void NamHocService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NamHocService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadTextBox()
        {
            this.txtMaNamHoc.Text = "";
            this.txtTenNamHoc.Text = "";
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            NamHoc namHoc = new NamHoc();
            namHoc.MaNamHoc = txtMaNamHoc.Text;
            namHoc.TenNamHoc = txtTenNamHoc.Text;

            if (this.namHocService.CheckNamHocExists(namHoc.MaNamHoc))
            {
                this.namHocService.Update(namHoc.MaNamHoc, namHoc);
            }
            else
            {
                this.namHocService.Create(namHoc);
            }
        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            NamHoc namHoc = new NamHoc();
            namHoc.MaNamHoc = txtMaNamHoc.Text;

            string message = "Bạn có chắc muốn xóa năm học này không?";
            string title = "Message";
            MessageBoxButtons button = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show(message, title, button, MessageBoxIcon.Question);

            if ( result == DialogResult.Yes)
            {
                this.namHocService.Delete(namHoc.MaNamHoc);
                LoadTextBox();
            }

        }

        private void Btn_Dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [DesignOnly(true)]
        private void NamHocInfo_Load(object sender, EventArgs e)
        {
            if (namHocViewModel != null)
            {
                txtMaNamHoc.Text = this.namHocViewModel.MaNamHoc;
                txtTenNamHoc.Text = this.namHocViewModel.TenNamHoc;
            }
        }
    }
}
