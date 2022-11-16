using QuanLyDiemSinhVienNhom5.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.ViewModel
{
    public class TinhSTCAndDiemTrungBinhViewModel
    {
        [DisplayName("Tên sinh viên")]
        public string TenSinhVien { get; set; }

        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }

        [DisplayName("Tên môn học")]
        public string TenMonHoc { get; set; }

        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Loại")]
        public string Loai { get; set; }

        public TinhSTCAndDiemTrungBinhViewModel(TinhSTCAndDiemTrungBinh model)
        {
            this.TenSinhVien = model.TenSinhVien;
            this.MaLop = model.MaLop;
            this.TenMonHoc = model.TenMonHoc;
            this.DiemTrungBinh = model.DiemTrungBinh;
            this.Loai = model.Loai;
        }
    }
}
