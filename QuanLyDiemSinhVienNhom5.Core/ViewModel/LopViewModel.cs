using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class LopViewModel
    {
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [DisplayName("Mã học kỳ")]
        public string MaHocKy { get; set; }

        [DisplayName("Mã môn học")]
        public string MaMonHoc { get; set; }

        [DisplayName("mã giảng viên")]
        public string MaGiangVien { get; set; }

        [DisplayName("Lịch học")]
        public string LichHoc { get; set; }

        [DisplayName("Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [DisplayName("Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [DisplayName("Giới hạn")]
        public int GioiHan { get; set; }

        [DisplayName("Tên lớp")]
        public string TenLop { get; set; }

        public LopViewModel()
        {

        }

        public LopViewModel(Lop lop)
          : this()
        {
          this.MaLop = lop.MaLop;
          this.MaHocKy = lop.MaHocKy;
          this.MaMonHoc = lop.MaMonHoc;
          this.MaGiangVien = lop.MaGiangVien;
          this.LichHoc = lop.LichHoc;
          this.NgayBatDau = lop.NgayBatDau;
          this.NgayKetThuc = lop.NgayKetThuc;
          this.GioiHan = lop.GioiHan;
        }

        public Lop ToLop()
        {
          var entity = new Lop();
          this.MaLop = this.MaLop;
          this.MaHocKy = this.MaHocKy;
          this.MaMonHoc = this.MaMonHoc;
          this.MaGiangVien = this.MaGiangVien;
          this.LichHoc = this.LichHoc;
          this.NgayBatDau = this.NgayBatDau;
          this.NgayKetThuc = this.NgayKetThuc;
          this.GioiHan = this.GioiHan;
          return entity;
        }
    }
}
