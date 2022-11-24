using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Model
{
    public class KetQuaHocTapTheoMaLopVaXepLoai
    {
        public string MaSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string MaLop { get; set; }
        public string TenMonHoc { get; set; }
        public double DiemTrungBinh { get; set; }
        public string Loai { get; set; }
    }
}
