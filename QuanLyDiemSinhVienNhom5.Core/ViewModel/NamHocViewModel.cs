using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ViewModel
{
    public class NamHocViewModel
    {
        [DisplayName("MaNamHoc")]
        public string MaNamHoc { get; set; }
        [DisplayName("TenNamHoc")]
        public string TenNamHoc { get; set; }

        public NamHocViewModel()
        {

        }

        public NamHocViewModel(NamHoc namHoc)
          : this()
        {
          this.MaNamHoc = namHoc.MaNamHoc;
          this.TenNamHoc = namHoc.TenNamHoc;
        }

        public NamHoc ToNamHoc()
        {
          var entity = new NamHoc();
          this.MaNamHoc = this.MaNamHoc;
          this.TenNamHoc = this.TenNamHoc;
          return entity;
        }
    }
}
