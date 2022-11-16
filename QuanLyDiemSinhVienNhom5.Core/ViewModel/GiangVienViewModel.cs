using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class GiangVienViewModel
    {
        [DisplayName("Mã giảng viên")]
        public string MaGiangVien { get; set; }

        [DisplayName("Họ tên")]
        public string HoTen { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
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

        [DisplayName("Mã khoa")]
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
