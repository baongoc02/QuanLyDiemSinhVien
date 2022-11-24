using QuanLyDiemSinhVienNhom5.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.ViewModel
{
    public class KetQuaHocTapTheoMaLopVaXepLoaiViewModel
    {
        [DisplayName("Mã sinh viên")]
        public string MaSinhVien { get; set; }

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

        public KetQuaHocTapTheoMaLopVaXepLoaiViewModel(KetQuaHocTapTheoMaLopVaXepLoai model)
        {
            this.MaSinhVien = model.MaSinhVien;
            this.TenSinhVien = model.TenSinhVien;
            this.Loai = model.Loai;
            this.TenMonHoc = model.TenMonHoc;
            this.MaLop = model.MaLop;
            this.TenMonHoc = model.TenMonHoc;
            this.DiemTrungBinh = model.DiemTrungBinh;
        }
    }
}
