using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class Lop
    {
        public string MaLop { get; set; }
        public string MaHocKy { get; set; }
        public string MaMonHoc { get; set; }
        public string MaGiangVien { get; set; }
        public string LichHoc { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int GioiHan { get; set; }

        public Lop()
        {

        }
    }
}
