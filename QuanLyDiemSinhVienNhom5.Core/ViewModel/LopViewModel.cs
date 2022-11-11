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
        [DisplayName("MaLop")]
        public string MaLop { get; set; }
        [DisplayName("MaHocKy")]
        public string MaHocKy { get; set; }
        [DisplayName("MaMonHoc")]
        public string MaMonHoc { get; set; }
        [DisplayName("MaGiangVien")]
        public string MaGiangVien { get; set; }
        [DisplayName("LichHoc")]
        public string LichHoc { get; set; }
        [DisplayName("NgayBatDau")]
        public DateTime NgayBatDau { get; set; }
        [DisplayName("NgayKetThuc")]
        public DateTime NgayKetThuc { get; set; }
        [DisplayName("GioiHan")]
        public int GioiHan { get; set; }

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
