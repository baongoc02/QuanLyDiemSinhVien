using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.Entities
{
    public class MonHoc
    {
        public string MaMonHoc { get; set; }
        public string TenMonHoc { get; set; }
        public string MoTa { get; set; }
        public int STC { get; set; }
        public string LoaiHocPhan { get; set; }
        public string MaKhoa { get; set; }

        public MonHoc()
        {

        }
    }
}
