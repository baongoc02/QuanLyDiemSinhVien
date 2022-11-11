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
    public class HocKyService : BaseService
    {
        private readonly HocKyDAO hocKyDAO;

        public HocKyService()
        {
          this.hocKyDAO = new HocKyDAO();
        }

        public void Create(HocKy hocKy)
        {
            try
            {
                if (this.CheckHocKyExists(hocKy.MaHocKy))
                {
                    this.OnError("Đã tồn tại học kỳ này trên hệ thống");
                    return;
                }
                this.hocKyDAO.Create(hocKy);
                this.OnSuccess("Tạo học kỳ thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public void Update(string maHocKy, HocKy hocKy)
        {
            try
            {
                this.hocKyDAO.Update(maHocKy, hocKy);
                this.OnSuccess("Cập nhật học kỳ thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public bool CheckHocKyExists(string maHocKy)
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
            try
            {
                this.hocKyDAO.Delete(maHocKy);
                this.OnSuccess("Xóa học kỳ thành công");
            }
            catch
            {
                this.OnError("Không thể xóa học kỳ, do có dữ liệu liên quan");
            }
        }
    }
}
