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
    public class NamHocService
    {
        private readonly NamHocDAO namHocDAO;

        public NamHocService()
        {
          this.namHocDAO = new NamHocDAO();
        }

        public void Create(NamHoc namHoc)
        {
            this.namHocDAO.Create(namHoc);
        }

        public void Update(string maNamHoc, NamHoc namHoc)
        {
            this.namHocDAO.Update(maNamHoc, namHoc);
        }

        public bool CheckLopExists(string maNamHoc)
        {
            return this.namHocDAO.CheckNamHocExistsByPrimaryKey(maNamHoc);
        }

        public List<NamHocViewModel> ListAll()
        {
            var result = this.namHocDAO.ListAll();
            return result.Select(u => new NamHocViewModel(u)).ToList();
        }

        public List<NamHocViewModel> Search(string maNamHoc, string tenNamHoc)
        {
            var result = this.namHocDAO.Search(maNamHoc, tenNamHoc);
            return result.Select(u => new NamHocViewModel(u)).ToList();
        }

        public void Delete(string maNamHoc)
        {
            this.namHocDAO.Delete(maNamHoc);
        }
    }
}
