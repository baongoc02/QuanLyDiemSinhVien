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
    public class NamHocService : BaseService
    {
        private readonly NamHocDAO namHocDAO;

        public NamHocService()
        {
          this.namHocDAO = new NamHocDAO();
        }

        public void Create(NamHoc namHoc)
        {
            try
            {
                if (this.CheckNamHocExists(namHoc.MaNamHoc))
                {
                    this.OnError("Đã tồn tại năm học này trên hệ thống");
                    return;
                }
                this.namHocDAO.Create(namHoc);
                this.OnSuccess("Tạo năm học thành công");
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

        public void Update(string maNamHoc, NamHoc namHoc)
        {
            try
            {
                this.namHocDAO.Update(maNamHoc, namHoc);
                this.OnSuccess("Cập nhật năm học thành công");
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

        public bool CheckNamHocExists(string maNamHoc)
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
            try
            {
                this.namHocDAO.Delete(maNamHoc);
                this.OnSuccess("Xóa năm học thành công");
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch
            {
                this.OnError("Không thể xóa năm học, do có dữ liệu liên quan");
            }
        }
    }
}
