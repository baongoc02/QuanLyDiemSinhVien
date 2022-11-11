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
    public class KetQuaHocTapService : BaseService
    {
        private readonly KetQuaHocTapDAO ketQuaHocTapDAO;

        public KetQuaHocTapService()
        {
          this.ketQuaHocTapDAO = new KetQuaHocTapDAO();
        }

        public void Create(KetQuaHocTap ketQuaHocTap)
        {
            try
            {
                if (this.CheckKetQuaHocTapExists(ketQuaHocTap.MaSinhVien, ketQuaHocTap.MaLop))
                {
                    this.OnError("Đã tồn tại kết quả học tập này trên hệ thống");
                    return;
                }
                this.ketQuaHocTapDAO.Create(ketQuaHocTap);
                this.OnSuccess("Tạo kết quả học tập thành công");
            }
            catch
            {
                this.OnError("Lỗi hệ thống");
            }
        }

        public void Update(string maSinhVien, string maLop, KetQuaHocTap ketQuaHocTap)
        {
            try
            {
                this.ketQuaHocTapDAO.Update(maSinhVien, maLop, ketQuaHocTap);
                this.OnSuccess("Cập nhật kết quả học tập thành công");
            }
            catch
            {
                this.OnError("Lỗi hệ thống");
            }
        }

        public bool CheckKetQuaHocTapExists(string maSinhVien, string maLop)
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
            try
            {
                this.ketQuaHocTapDAO.Delete(maSinhVien, maLop);
                this.OnSuccess("Xóa kết quả học tập thành công");
            }
            catch
            {
                this.OnError("Không thể xóa kết quả học tập, do có dữ liệu liên quan");
            }
        }
    }
}
