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
    public class SinhVienService
    {
        private readonly SinhVienDAO sinhVienDAO;

        public SinhVienService()
        {
          this.sinhVienDAO = new SinhVienDAO();
        }

        public void Create(SinhVien sinhVien)
        {
            this.sinhVienDAO.Create(sinhVien);
        }

        public void Update(string maSinhVien, SinhVien sinhVien)
        {
            this.sinhVienDAO.Update(maSinhVien, sinhVien);
        }

        public bool CheckLopExists(string maSinhVien)
        {
            return this.sinhVienDAO.CheckSinhVienExistsByPrimaryKey(maSinhVien);
        }

        public List<SinhVienViewModel> ListAll()
        {
            var result = this.sinhVienDAO.ListAll();
            return result.Select(u => new SinhVienViewModel(u)).ToList();
        }

        public List<SinhVienViewModel> Search(string maSinhVien, string hoTen, string gioiTinh, string cMND, string sDT, string queQuan, string maKhoa)
        {
            var result = this.sinhVienDAO.Search(maSinhVien, hoTen, gioiTinh, cMND, sDT, queQuan, maKhoa);
            return result.Select(u => new SinhVienViewModel(u)).ToList();
        }

        public void Delete(string maSinhVien)
        {
            this.sinhVienDAO.Delete(maSinhVien);
        }
    }
}
