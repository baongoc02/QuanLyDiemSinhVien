using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVienNhom5.GUI
{
    public partial class KhoaInfo : Form
    {
        private readonly KhoaService khoaService;
        public KhoaViewModel khoaViewModel;

        public KhoaInfo()
        {
            this.khoaService = new KhoaService();
            this.khoaService.OnSuccessMessage += KhoaService_OnSuccessMessage;
            this.khoaService.OnErrorMessage += KhoaService_OnErrorMessage;

            InitializeComponent();
        }

        private void KhoaService_OnErrorMessage(object sender, string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void KhoaService_OnSuccessMessage(object sender, string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadTextBox()
        {
            this.txtMaKhoa.Text = "";
            this.txtTenKhoa.Text = "";
            this.txtHeDaotao.Text = "";
            this.dtNgayThanhLapInfor.Text = "";
        }

        private bool CheckTextBox()
        {
            if (txtTenKhoa.Text == null)
            {
                MessageBox.Show("Tên khoa không được trống!");
                return false;
            }
            else if (txtHeDaotao.Text == null)
            {
                MessageBox.Show("Hệ đào tạo không được trống!");
                return false;
            } else if (dtNgayThanhLapInfor.Value == null)
            {
                MessageBox.Show("Ngày thành lập không được trống!");
                return false;
            }
            return true;
        }

        private void Btn_XacNhan_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            khoa.MaKhoa = txtMaKhoa.Text;
            khoa.TenKhoa = txtTenKhoa.Text;
            khoa.HeDaoTao = txtHeDaotao.Text;
            khoa.NgayThanhLap = dtNgayThanhLapInfor.Value;

            if (khoaService.CheckKhoaExists(khoa.MaKhoa))
            {
                bool checktxt = CheckTextBox();
                if (checktxt)
                {
                    this.khoaService.Update(khoa.MaKhoa, khoa);
                    this.loadTextBox();
                }
            }
            else
            {
                bool checktxt = CheckTextBox();
                if (checktxt)
                {
                    this.khoaService.Create(khoa);
                    this.loadTextBox();
                }
            }

        }

        private void Btn_Xoa_Click(object sender, EventArgs e)
        {
            Khoa khoa = new Khoa();
            khoa.MaKhoa = txtMaKhoa.Text;

            string message = "Bạn có chắc muốn xóa khoa này?";
            string title = "Message";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.khoaService.Delete(khoa.MaKhoa);
                this.loadTextBox();
            }    
        }

        private void Btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoaInfo_Load(object sender, EventArgs e)
        {
            txtMaKhoa.Text = this.khoaViewModel.MaKhoa;
            txtTenKhoa.Text = this.khoaViewModel.TenKhoa;
            txtHeDaotao.Text = this.khoaViewModel.HeDaoTao;
            dtNgayThanhLapInfor.Value = this.khoaViewModel.NgayThanhLap;
        }
    }
}
