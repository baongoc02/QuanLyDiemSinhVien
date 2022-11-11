using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class KetQuaHocTap
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }
        public float DiemGiuaKy { get; set; }
        public float DiemCuoiKy { get; set; }

        public KetQuaHocTap()
        {

        }
    }
}
