using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class GiangVienViewModel
    {
        [DisplayName("MaGiangVien")]
        public string MaGiangVien { get; set; }
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
        [DisplayName("HocHam")]
        public string HocHam { get; set; }
        [DisplayName("HocVi")]
        public string HocVi { get; set; }
        [DisplayName("MaKhoa")]
        public string MaKhoa { get; set; }

        public GiangVienViewModel()
        {

        }

        public GiangVienViewModel(GiangVien giangVien)
          : this()
        {
          this.MaGiangVien = giangVien.MaGiangVien;
          this.HoTen = giangVien.HoTen;
          this.NgaySinh = giangVien.NgaySinh;
          this.GioiTinh = giangVien.GioiTinh;
          this.CMND = giangVien.CMND;
          this.SDT = giangVien.SDT;
          this.QueQuan = giangVien.QueQuan;
          this.HocHam = giangVien.HocHam;
          this.HocVi = giangVien.HocVi;
          this.MaKhoa = giangVien.MaKhoa;
        }

        public GiangVien ToGiangVien()
        {
          var entity = new GiangVien();
          this.MaGiangVien = this.MaGiangVien;
          this.HoTen = this.HoTen;
          this.NgaySinh = this.NgaySinh;
          this.GioiTinh = this.GioiTinh;
          this.CMND = this.CMND;
          this.SDT = this.SDT;
          this.QueQuan = this.QueQuan;
          this.HocHam = this.HocHam;
          this.HocVi = this.HocVi;
          this.MaKhoa = this.MaKhoa;
          return entity;
        }
    }
}
