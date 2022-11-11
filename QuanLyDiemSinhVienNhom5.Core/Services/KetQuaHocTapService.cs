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
    public class KetQuaHocTapService
    {
        private readonly KetQuaHocTapDAO ketQuaHocTapDAO;

        public KetQuaHocTapService()
        {
          this.ketQuaHocTapDAO = new KetQuaHocTapDAO();
        }

        public void Create(KetQuaHocTap ketQuaHocTap)
        {
            this.ketQuaHocTapDAO.Create(ketQuaHocTap);
        }

        public void Update(string maSinhVien, string maLop, KetQuaHocTap ketQuaHocTap)
        {
            this.ketQuaHocTapDAO.Update(maSinhVien, maLop, ketQuaHocTap);
        }

        public bool CheckLopExists(string maSinhVien, string maLop)
        {
            return this.ketQuaHocTapDAO.CheckKetQuaHocTapExistsByPrimaryKey(maSinhVien, maLop);
        }

        public List<KetQuaHocTapViewModel> ListAll()
        {
            var result = this.ketQuaHocTapDAO.ListAll();
            return result.Select(u => new KetQuaHocTapViewModel(u)).ToList();
        }

        public List<KetQuaHocTapViewModel> Search(string maSinhVien, string maLop)
        {
            var result = this.ketQuaHocTapDAO.Search(maSinhVien, maLop);
            return result.Select(u => new KetQuaHocTapViewModel(u)).ToList();
        }

        public void Delete(string maSinhVien, string maLop)
        {
            this.ketQuaHocTapDAO.Delete(maSinhVien, maLop);
        }
    }
}
