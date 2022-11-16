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
        [DisplayName("Điểm trung bình")]
        public double DiemTrungBinh { get; set; }

        [DisplayName("Tổng số tín chỉ")]
        public int STC { get; set; }

        [DisplayName("Loại")]
        public string Loai { get; set; }

        public TinhSTCAndDiemTrungBinhViewModel(TinhSTCAndDiemTrungBinh model)
        {
            this.DiemTrungBinh = model.DiemTrungBinh;
            this.STC = model.STC;
            this.Loai = model.Loai;
        }
    }
}
