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
    public class LopService : BaseService
    {
        private readonly LopDAO lopDAO;

        public LopService()
        {
          this.lopDAO = new LopDAO();
        }

        public void Create(Lop lop)
        {
            try
            {
                if (this.CheckLopExists(lop.MaLop))
                {
                    this.OnError("Đã tồn tại lớp này trên hệ thống");
                    return;
                }
                this.lopDAO.Create(lop);
                this.OnSuccess("Tạo lớp thành công");
            }
            catch
            {
                this.OnError("Lỗi hệ thống");
            }
        }

        public void Update(string maLop, Lop lop)
        {
            try
            {
                this.lopDAO.Update(maLop, lop);
                this.OnSuccess("Cập nhật lớp thành công");
            }
            catch
            {
                this.OnError("Lỗi hệ thống");
            }
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
            try
            {
                this.lopDAO.Delete(maLop);
                this.OnSuccess("Xóa lớp thành công");
            }
            catch
            {
                this.OnError("Không thể xóa lớp, do có dữ liệu liên quan");
            }
        }
    }
}
