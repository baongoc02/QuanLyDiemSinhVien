using QuanLyDiemSinhVienNhom5.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.ViewModel
{
    public class TimTrongHomePageGiangVienViewModel
    {
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [DisplayName("Tên môn")]
        public string TenMon { get; set; }

        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Tên học ky")]
        public string TenHocKy { get; set; }

        [DisplayName("Tên môn học")]
        public string TenNamHoc { get; set; }

        public TimTrongHomePageGiangVienViewModel(TimTrongHomePageGiangVien model)
        {
            this.MaSinhVien = model.MaSinhVien;
            this.MaLop = model.MaLop;
            this.TenMon = model.TenMon;
            this.DiemTrungBinh = model.DiemTrungBinh;
            this.TenHocKy = model.TenHocKy;
            this.TenNamHoc = model.TenNamHoc;
        }
    }
}
