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
    public class LopService
    {
        private readonly LopDAO lopDAO;

        public LopService()
        {
          this.lopDAO = new LopDAO();
        }

        public void Create(Lop lop)
        {
            this.lopDAO.Create(lop);
        }

        public void Update(string maLop, Lop lop)
        {
            this.lopDAO.Update(maLop, lop);
        }

        public bool CheckLopExists(string maLop)
        {
            return this.lopDAO.CheckLopExistsByPrimaryKey(maLop);
        }

        public List<LopViewModel> ListAll()
        {
            var result = this.lopDAO.ListAll();
            return result.Select(u => new LopViewModel(u)).ToList();
        }

        public List<LopViewModel> Search(string maLop, string maHocKy, string maMonHoc, string maGiangVien, string lichHoc)
        {
            var result = this.lopDAO.Search(maLop, maHocKy, maMonHoc, maGiangVien, lichHoc);
            return result.Select(u => new LopViewModel(u)).ToList();
        }

        public void Delete(string maLop)
        {
            this.lopDAO.Delete(maLop);
        }
    }
}
