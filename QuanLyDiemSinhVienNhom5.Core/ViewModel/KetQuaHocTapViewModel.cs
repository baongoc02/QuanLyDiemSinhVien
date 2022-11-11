using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class KetQuaHocTapViewModel
    {
        [DisplayName("MaSinhVien")]
        public string MaSinhVien { get; set; }
        [DisplayName("MaLop")]
        public string MaLop { get; set; }
        [DisplayName("DiemGiuaKy")]
        public float DiemGiuaKy { get; set; }
        [DisplayName("DiemCuoiKy")]
        public float DiemCuoiKy { get; set; }

        public KetQuaHocTapViewModel()
        {

        }

        public KetQuaHocTapViewModel(KetQuaHocTap ketQuaHocTap)
          : this()
        {
          this.MaSinhVien = ketQuaHocTap.MaSinhVien;
          this.MaLop = ketQuaHocTap.MaLop;
          this.DiemGiuaKy = ketQuaHocTap.DiemGiuaKy;
          this.DiemCuoiKy = ketQuaHocTap.DiemCuoiKy;
        }

        public KetQuaHocTap ToKetQuaHocTap()
        {
          var entity = new KetQuaHocTap();
          this.MaSinhVien = this.MaSinhVien;
          this.MaLop = this.MaLop;
          this.DiemGiuaKy = this.DiemGiuaKy;
          this.DiemCuoiKy = this.DiemCuoiKy;
          return entity;
        }
    }
}
