using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class MonHocViewModel
    {
        [DisplayName("MaMonHoc")]
        public string MaMonHoc { get; set; }
        [DisplayName("TenMonHoc")]
        public string TenMonHoc { get; set; }
        [DisplayName("MoTa")]
        public string MoTa { get; set; }
        [DisplayName("STC")]
        public int STC { get; set; }
        [DisplayName("LoaiHocPhan")]
        public string LoaiHocPhan { get; set; }
        [DisplayName("MaKhoa")]
        public string MaKhoa { get; set; }

        public MonHocViewModel()
        {

        }

        public MonHocViewModel(MonHoc monHoc)
          : this()
        {
          this.MaMonHoc = monHoc.MaMonHoc;
          this.TenMonHoc = monHoc.TenMonHoc;
          this.MoTa = monHoc.MoTa;
          this.STC = monHoc.STC;
          this.LoaiHocPhan = monHoc.LoaiHocPhan;
          this.MaKhoa = monHoc.MaKhoa;
        }

        public MonHoc ToMonHoc()
        {
          var entity = new MonHoc();
          this.MaMonHoc = this.MaMonHoc;
          this.TenMonHoc = this.TenMonHoc;
          this.MoTa = this.MoTa;
          this.STC = this.STC;
          this.LoaiHocPhan = this.LoaiHocPhan;
          this.MaKhoa = this.MaKhoa;
          return entity;
        }
    }
}
