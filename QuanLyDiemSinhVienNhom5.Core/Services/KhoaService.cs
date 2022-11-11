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
    public class KhoaService
    {
        private readonly KhoaDAO khoaDAO;

        public KhoaService()
        {
          this.khoaDAO = new KhoaDAO();
        }

        public void Create(Khoa khoa)
        {
            this.khoaDAO.Create(khoa);
        }

        public void Update(string maKhoa, Khoa khoa)
        {
            this.khoaDAO.Update(maKhoa, khoa);
        }

        public bool CheckLopExists(string maKhoa)
        {
            return this.khoaDAO.CheckKhoaExistsByPrimaryKey(maKhoa);
        }

        public List<KhoaViewModel> ListAll()
        {
            var result = this.khoaDAO.ListAll();
            return result.Select(u => new KhoaViewModel(u)).ToList();
        }

        public List<KhoaViewModel> Search(string maKhoa, string tenKhoa, string heDaoTao)
        {
            var result = this.khoaDAO.Search(maKhoa, tenKhoa, heDaoTao);
            return result.Select(u => new KhoaViewModel(u)).ToList();
        }

        public void Delete(string maKhoa)
        {
            this.khoaDAO.Delete(maKhoa);
        }
    }
}
