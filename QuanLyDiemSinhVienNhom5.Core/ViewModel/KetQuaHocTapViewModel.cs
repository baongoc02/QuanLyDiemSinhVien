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
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }
        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }
        [DisplayName("Điểm giữa kỳ")]
        public float DiemGiuaKy { get; set; }
        [DisplayName("Điểm giữa kỳ")]
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
