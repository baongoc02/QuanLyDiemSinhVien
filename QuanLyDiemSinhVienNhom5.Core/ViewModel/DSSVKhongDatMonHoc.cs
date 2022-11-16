using QuanLyDiemSinhVienNhom5.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.ViewModel
{
    public class DSSVKhongDatMonHocViewModel
    {
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [DisplayName("Tên môn")]
        public string TenMon { get; set; }

        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Tên học kỳ")]
        public string TenHocKy { get; set; }

        [DisplayName("Tên năm học")]
        public string TenNamHoc { get; set; }

        public DSSVKhongDatMonHocViewModel(DSSVKhongDatMonHoc model)
        {
            this.MaLop = model.MaLop;
            this.MaSinhVien = model.MaSinhVien;
            this.TenMon = model.TenMon;
            this.DiemTrungBinh = model.DiemTrungBinh;
            this.TenHocKy = model.TenHocKy;
            this.TenNamHoc = model.TenNamHoc;
        }
    }
}
