using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class GiangVien
    {
        public string MaGiangVien { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string QueQuan { get; set; }
        public string HocHam { get; set; }
        public string HocVi { get; set; }
        public string MaKhoa { get; set; }

        public GiangVien()
        {

        }
    }
}
