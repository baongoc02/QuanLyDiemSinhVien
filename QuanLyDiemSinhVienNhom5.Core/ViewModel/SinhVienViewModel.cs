using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class SinhVienViewModel
    {
        [DisplayName("MaSinhVien")]
        public string MaSinhVien { get; set; }
        [DisplayName("HoTen")]
        public string HoTen { get; set; }
        [DisplayName("NgaySinh")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("GioiTinh")]
        public string GioiTinh { get; set; }
        [DisplayName("CMND")]
        public string CMND { get; set; }
        [DisplayName("SDT")]
        public string SDT { get; set; }
        [DisplayName("QueQuan")]
        public string QueQuan { get; set; }
        [DisplayName("MaKhoa")]
        public string MaKhoa { get; set; }

        public SinhVienViewModel()
        {

        }

        public SinhVienViewModel(SinhVien sinhVien)
          : this()
        {
          this.MaSinhVien = sinhVien.MaSinhVien;
          this.HoTen = sinhVien.HoTen;
          this.NgaySinh = sinhVien.NgaySinh;
          this.GioiTinh = sinhVien.GioiTinh;
          this.CMND = sinhVien.CMND;
          this.SDT = sinhVien.SDT;
          this.QueQuan = sinhVien.QueQuan;
          this.MaKhoa = sinhVien.MaKhoa;
        }

        public SinhVien ToSinhVien()
        {
          var entity = new SinhVien();
          this.MaSinhVien = this.MaSinhVien;
          this.HoTen = this.HoTen;
          this.NgaySinh = this.NgaySinh;
          this.GioiTinh = this.GioiTinh;
          this.CMND = this.CMND;
          this.SDT = this.SDT;
          this.QueQuan = this.QueQuan;
          this.MaKhoa = this.MaKhoa;
          return entity;
        }
    }
}
