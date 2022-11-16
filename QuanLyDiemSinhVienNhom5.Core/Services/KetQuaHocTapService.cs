using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDiemSinhVienNhom5.Core.ViewModel;
using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.Model;
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

        public List<KetQuaHocTapTheoSinhVienViewModel> GetKetQuaHocTapTheoSinhVien(string maSinhVien)
        {
            var result = this.ketQuaHocTapDAO.GetKetQuaHocTapTheoSinhVien(maSinhVien);
            return result.Select(u => new KetQuaHocTapTheoSinhVienViewModel(u)).ToList();
        }

        public List<TinhSTCAndDiemTrungBinhViewModel> GetTinhSTCAndDiemTrungBinh(string maSinhVien)
        {
            var result = this.ketQuaHocTapDAO.GetTinhSTCAndDiemTrungBinh(maSinhVien);
            return result.Select(u => new TinhSTCAndDiemTrungBinhViewModel(u)).ToList();
        }

        public List<KetQuaHocTapTheoMaLopVaXepLoaiViewModel> GetKetQuaHocTapTheoMaLopVaXepLoai(string maLop, string tenLoai)
        {
            var result = this.ketQuaHocTapDAO.GetKetQuaHocTapTheoMaLopVaXepLoai(maLop, tenLoai);
            return result.Select(u => new KetQuaHocTapTheoMaLopVaXepLoaiViewModel(u)).ToList();
        }

        public List<DSSVKhongDatMonHocViewModel> GetDSSVKhongDatMonHoc(string maMon, string maHocKy)
        {
            var result = this.ketQuaHocTapDAO.GetDSSVKhongDatMonHoc(maMon, maHocKy);
            return result.Select(u => new DSSVKhongDatMonHocViewModel(u)).ToList();
        }

        public void Update(string maSinhVien, string maLop, KetQuaHocTap ketQuaHocTap)
        {
            try
            {
                this.ketQuaHocTapDAO.Update(maSinhVien, maLop, ketQuaHocTap);
                this.OnSuccess("Cập nhật kết quả học tập thành công");
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
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
            }
            catch
            {
                this.OnError("Không thể xóa kết quả học tập, do có dữ liệu liên quan");
            }
        }
    }
}
