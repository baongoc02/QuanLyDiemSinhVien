using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class HocKyViewModel
    {
        [DisplayName("Mã học kỳ")]
        public string MaHocKy { get; set; }

        [DisplayName("Tên học kỳ")]
        public string TenHocKy { get; set; }

        [DisplayName("Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [DisplayName("Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [DisplayName("Mã năm học")]
        public string MaNamHoc { get; set; }

        public HocKyViewModel()
        {

        }

        public HocKyViewModel(HocKy hocKy)
          : this()
        {
          this.MaHocKy = hocKy.MaHocKy;
          this.TenHocKy = hocKy.TenHocKy;
          this.NgayBatDau = hocKy.NgayBatDau;
          this.NgayKetThuc = hocKy.NgayKetThuc;
          this.MaNamHoc = hocKy.MaNamHoc;
        }

        public HocKy ToHocKy()
        {
          var entity = new HocKy();
          this.MaHocKy = this.MaHocKy;
          this.TenHocKy = this.TenHocKy;
          this.NgayBatDau = this.NgayBatDau;
          this.NgayKetThuc = this.NgayKetThuc;
          this.MaNamHoc = this.MaNamHoc;
          return entity;
        }
    }
}
