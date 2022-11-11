using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string HeDaoTao { get; set; }
        public DateTime NgayThanhLap { get; set; }

        public Khoa()
        {

        }
    }
}
