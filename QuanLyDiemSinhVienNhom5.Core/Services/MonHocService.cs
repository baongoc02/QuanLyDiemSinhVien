using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using QuanLyDiemSinhVienNhom5.DataAccess.ViewModel;

namespace QuanLyDiemSinhVienNhom5.Core.Services
{
    public class MonHocService
    {
        private readonly MonHocDAO monHocDAO;

        public MonHocService()
        {
          this.monHocDAO = new MonHocDAO();
        }

        public void Create(MonHoc monHoc)
        {
            this.monHocDAO.Create(monHoc);
        }

        public void Update(string maMonHoc, MonHoc monHoc)
        {
            this.monHocDAO.Update(maMonHoc, monHoc);
        }

        public bool CheckLopExists(string maMonHoc)
        {
            return this.monHocDAO.CheckMonHocExistsByPrimaryKey(maMonHoc);
        }

        public List<MonHocViewModel> ListAll()
        {
            var result = this.monHocDAO.ListAll();
            return result.Select(u => new MonHocViewModel(u)).ToList();
        }

        public List<MonHocViewModel> Search(string maMonHoc, string tenMonHoc, string moTa, string loaiHocPhan, string maKhoa)
        {
            var result = this.monHocDAO.Search(maMonHoc, tenMonHoc, moTa, loaiHocPhan, maKhoa);
            return result.Select(u => new MonHocViewModel(u)).ToList();
        }

        public void Delete(string maMonHoc)
        {
            this.monHocDAO.Delete(maMonHoc);
        }
    }
}
