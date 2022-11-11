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
    public class HocKyService
    {
        private readonly HocKyDAO hocKyDAO;

        public HocKyService()
        {
          this.hocKyDAO = new HocKyDAO();
        }

        public void Create(HocKy hocKy)
        {
            this.hocKyDAO.Create(hocKy);
        }

        public void Update(string maHocKy, HocKy hocKy)
        {
            this.hocKyDAO.Update(maHocKy, hocKy);
        }

        public bool CheckLopExists(string maHocKy)
        {
            return this.hocKyDAO.CheckHocKyExistsByPrimaryKey(maHocKy);
        }

        public List<HocKyViewModel> ListAll()
        {
            var result = this.hocKyDAO.ListAll();
            return result.Select(u => new HocKyViewModel(u)).ToList();
        }

        public List<HocKyViewModel> Search(string maHocKy, string tenHocKy, string maNamHoc)
        {
            var result = this.hocKyDAO.Search(maHocKy, tenHocKy, maNamHoc);
            return result.Select(u => new HocKyViewModel(u)).ToList();
        }

        public void Delete(string maHocKy)
        {
            this.hocKyDAO.Delete(maHocKy);
        }
    }
}
