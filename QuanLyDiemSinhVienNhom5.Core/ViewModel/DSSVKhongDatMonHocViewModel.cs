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

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Tên khoa")]
        public string Khoa { get; set; }

        public DSSVKhongDatMonHocViewModel(DSSVKhongDatMonHoc model)
        {
            this.MaSinhVien = model.MaSinhVien;
            this.DiemTrungBinh = model.DiemTrungBinh;
            this.Khoa = model.Khoa;
            this.HoTen = model.HoTen;
        }
    }
}
