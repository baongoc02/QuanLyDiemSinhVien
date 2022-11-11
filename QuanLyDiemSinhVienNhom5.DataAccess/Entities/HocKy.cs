using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class HocKy
    {
        public string MaHocKy { get; set; }
        public string TenHocKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MaNamHoc { get; set; }

        public HocKy()
        {

        }
    }
}
