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
        [Browsable(false)]
        public string MaGiangVien { get; set; }
        [DisplayName("H? và tên")]
        public string FullName => $"{this.HocHam}. {this.HocVi}. {this.HoTen}";
        [Browsable(false)]
        public string HoTen { get; set; }
        [DisplayName("NgaySinh")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("GioiTinh")]
        public string GioiTinh { get; set; }
        [Browsable(false)]
        public string CMND { get; set; }
        [Browsable(false)]
        public string SDT { get; set; }
        [Browsable(false)]
        public string QueQuan { get; set; }
        [Browsable(false)]
        public string HocHam { get; set; }
        [Browsable(false)]
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
