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
    public class SinhVienService : BaseService
    {
        private readonly SinhVienDAO sinhVienDAO;

        public SinhVienService()
        {
          this.sinhVienDAO = new SinhVienDAO();
        }

        public void Create(SinhVien sinhVien)
        {
            try
            {
                if (this.CheckSinhVienExists(sinhVien.MaSinhVien))
                {
                    this.OnError("Đã tồn tại sinh viên này trên hệ thống");
                    return;
                }
                this.sinhVienDAO.Create(sinhVien);
                this.OnSuccess("Tạo sinh viên thành công");
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

        public void Update(string maSinhVien, SinhVien sinhVien)
        {
            try
            {
                this.sinhVienDAO.Update(maSinhVien, sinhVien);
                this.OnSuccess("Cập nhật sinh viên thành công");
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

        public bool CheckSinhVienExists(string maSinhVien)
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
            try
            {
                this.sinhVienDAO.Delete(maSinhVien);
                this.OnSuccess("Xóa sinh viên thành công");
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch
            {
                this.OnError("Không thể xóa sinh viên, do có dữ liệu liên quan");
            }
        }
    }
}
