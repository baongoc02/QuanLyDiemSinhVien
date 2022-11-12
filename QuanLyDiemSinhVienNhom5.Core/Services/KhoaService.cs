using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using QuanLyDiemSinhVienNhom5.DataAccess.ViewModel;

namespace QuanLyDiemSinhVienNhom5.Core.Services
{
    public class KhoaService : BaseService
    {
        private readonly KhoaDAO khoaDAO;

        public KhoaService()
        {
          this.khoaDAO = new KhoaDAO();
        }

        public void Create(Khoa khoa)
        {
            try
            {
                if (this.CheckKhoaExists(khoa.MaKhoa))
                {
                    this.OnError("Đã tồn tại khoa này trên hệ thống");
                    return;
                }
                this.khoaDAO.Create(khoa);
                this.OnSuccess("Tạo khoa thành công");
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public void Update(string maKhoa, Khoa khoa)
        {
            try
            {
                this.khoaDAO.Update(maKhoa, khoa);
                this.OnSuccess("Cập nhật khoa thành công");
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public bool CheckKhoaExists(string maKhoa)
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
            try
            {
                this.khoaDAO.Delete(maKhoa);
                this.OnSuccess("Xóa khoa thành công");
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch
            {
                this.OnError("Không thể xóa khoa, do có dữ liệu liên quan");
            }
        }
    }
}
