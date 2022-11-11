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
    public class MonHocService : BaseService
    {
        private readonly MonHocDAO monHocDAO;

        public MonHocService()
        {
          this.monHocDAO = new MonHocDAO();
        }

        public void Create(MonHoc monHoc)
        {
            try
            {
                if (this.CheckMonHocExists(monHoc.MaMonHoc))
                {
                    this.OnError("Đã tồn tại môn học này trên hệ thống");
                    return;
                }
                this.monHocDAO.Create(monHoc);
                this.OnSuccess("Tạo môn học thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public void Update(string maMonHoc, MonHoc monHoc)
        {
            try
            {
                this.monHocDAO.Update(maMonHoc, monHoc);
                this.OnSuccess("Cập nhật môn học thành công");
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
            }
        }

        public bool CheckMonHocExists(string maMonHoc)
        {
            return this.monHocDAO.CheckMonHocExistsByPrimaryKey(maMonHoc);
        }

        public List<MonHocViewModel> ListAll()
        {
            var result = this.monHocDAO.ListAll();
            return result.Select(u => new MonHocViewModel(u)).ToList();
        }

        public List<MonHocViewModel> Search(string maMonHoc, string tenMonHoc, string moTa, string loaiHocPhan, string maKhoa)
        {
            var result = this.monHocDAO.Search(maMonHoc, tenMonHoc, moTa, loaiHocPhan, maKhoa);
            return result.Select(u => new MonHocViewModel(u)).ToList();
        }

        public void Delete(string maMonHoc)
        {
            try
            {
                this.monHocDAO.Delete(maMonHoc);
                this.OnSuccess("Xóa môn học thành công");
            }
            catch
            {
                this.OnError("Không thể xóa môn học, do có dữ liệu liên quan");
            }
        }
    }
}
