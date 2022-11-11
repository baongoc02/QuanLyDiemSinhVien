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
    public class GiangVienService : BaseService
    {
        private readonly GiangVienDAO giangVienDAO;

        public GiangVienService()
        {
          this.giangVienDAO = new GiangVienDAO();
        }

        public void Create(GiangVien giangVien)
        {
            try
            {
                if (this.CheckGiangVienExists(giangVien.MaGiangVien))
                {
                    this.OnError("Đã tồn tại giảng viên này trên hệ thống");
                    return;
                }
                this.giangVienDAO.Create(giangVien);
                this.OnSuccess("Tạo giảng viên thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public void Update(string maGiangVien, GiangVien giangVien)
        {
            try
            {
                this.giangVienDAO.Update(maGiangVien, giangVien);
                this.OnSuccess("Cập nhật giảng viên thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public bool CheckGiangVienExists(string maGiangVien)
        {
            return this.giangVienDAO.CheckGiangVienExistsByPrimaryKey(maGiangVien);
        }

        public List<GiangVienViewModel> ListAll()
        {
            var result = this.giangVienDAO.ListAll();
            return result.Select(u => new GiangVienViewModel(u)).ToList();
        }

        public List<GiangVienViewModel> Search(string maGiangVien, string hoTen, string gioiTinh, string cMND, string sDT, string queQuan, string hocHam, string hocVi, string maKhoa)
        {
            var result = this.giangVienDAO.Search(maGiangVien, hoTen, gioiTinh, cMND, sDT, queQuan, hocHam, hocVi, maKhoa);
            return result.Select(u => new GiangVienViewModel(u)).ToList();
        }

        public void Delete(string maGiangVien)
        {
            try
            {
                this.giangVienDAO.Delete(maGiangVien);
                this.OnSuccess("Xóa giảng viên thành công");
            }
            catch
            {
                this.OnError("Không thể xóa giảng viên, do có dữ liệu liên quan");
            }
        }
    }
}
