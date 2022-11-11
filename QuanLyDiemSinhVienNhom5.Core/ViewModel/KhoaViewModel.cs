using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class KhoaViewModel
    {
        [DisplayName("MaKhoa")]
        public string MaKhoa { get; set; }
        [DisplayName("TenKhoa")]
        public string TenKhoa { get; set; }
        [DisplayName("HeDaoTao")]
        public string HeDaoTao { get; set; }
        [DisplayName("NgayThanhLap")]
        public DateTime NgayThanhLap { get; set; }

        public KhoaViewModel()
        {

        }

        public KhoaViewModel(Khoa khoa)
          : this()
        {
          this.MaKhoa = khoa.MaKhoa;
          this.TenKhoa = khoa.TenKhoa;
          this.HeDaoTao = khoa.HeDaoTao;
          this.NgayThanhLap = khoa.NgayThanhLap;
        }

        public Khoa ToKhoa()
        {
          var entity = new Khoa();
          this.MaKhoa = this.MaKhoa;
          this.TenKhoa = this.TenKhoa;
          this.HeDaoTao = this.HeDaoTao;
          this.NgayThanhLap = this.NgayThanhLap;
          return entity;
        }
    }
}
