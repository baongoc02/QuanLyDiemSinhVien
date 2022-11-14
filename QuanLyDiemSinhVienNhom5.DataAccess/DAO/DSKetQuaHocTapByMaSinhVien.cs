using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.DAO
{
    public class DSKetQuaHocTapByMaSinhVien
    {
        public string TenSinhVien { get; set; }
        public string MaLop { get; set; }
        public string TenMonHoc { get; set; }
        public float DiemTrungBinh { get; set; }
        public string Loai {get; set; }

        public DSKetQuaHocTapByMaSinhVien()
        {

        }
    }
}
