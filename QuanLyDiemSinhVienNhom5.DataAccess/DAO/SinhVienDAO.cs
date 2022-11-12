using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;

namespace QuanLyDiemSinhVienNhom5.DataAccess.DAO
{
    public class SinhVienDAO : BaseDAO
    {
        public SinhVienDAO()
        {

        }

        public void Create(SinhVien sinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateSinhVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", sinhVien.MaSinhVien));
                command.Parameters.Add(new SqlParameter("@hoTen", sinhVien.HoTen));
                command.Parameters.Add(new SqlParameter("@ngaySinh", sinhVien.NgaySinh));
                command.Parameters.Add(new SqlParameter("@gioiTinh", sinhVien.GioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", sinhVien.CMND));
                command.Parameters.Add(new SqlParameter("@sDT", sinhVien.SDT));
                command.Parameters.Add(new SqlParameter("@queQuan", sinhVien.QueQuan));
                command.Parameters.Add(new SqlParameter("@maKhoa", sinhVien.MaKhoa));

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    base.ProcessSqlException(e);
                }
            }
        }

        public void Update(string maSinhVien, SinhVien sinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateSinhVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@hoTen", sinhVien.HoTen));
                command.Parameters.Add(new SqlParameter("@ngaySinh", sinhVien.NgaySinh));
                command.Parameters.Add(new SqlParameter("@gioiTinh", sinhVien.GioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", sinhVien.CMND));
                command.Parameters.Add(new SqlParameter("@sDT", sinhVien.SDT));
                command.Parameters.Add(new SqlParameter("@queQuan", sinhVien.QueQuan));
                command.Parameters.Add(new SqlParameter("@maKhoa", sinhVien.MaKhoa));

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    base.ProcessSqlException(e);
                }
            }
        }

        private List<SinhVien> ConvertDataTableToListSinhVien(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new SinhVien()
                        {
                          MaSinhVien = Convert.ToString(u["SinhVienMaSinhVien"]),
                          HoTen = Convert.ToString(u["SinhVienHoTen"]),
                          NgaySinh = Convert.ToDateTime(u["SinhVienNgaySinh"]),
                          GioiTinh = Convert.ToString(u["SinhVienGioiTinh"]),
                          CMND = Convert.ToString(u["SinhVienCMND"]),
                          SDT = Convert.ToString(u["SinhVienSDT"]),
                          QueQuan = Convert.ToString(u["SinhVienQueQuan"]),
                          MaKhoa = Convert.ToString(u["SinhVienMaKhoa"])
                        });

            return result.ToList();
        }

        public bool CheckSinhVienExistsByPrimaryKey(string maSinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [SinhVien] WHERE [MaSinhVien] = @maSinhVien";

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<SinhVien> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllSinhVien";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListSinhVien(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<SinhVien> Search(string maSinhVien, string hoTen, string gioiTinh, string cMND, string sDT, string queQuan, string maKhoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllSinhVien";

                List<string> where = new List<string>();

                where.Add("[SinhVienMaSinhVien] LIKE CONCAT('%', @maSinhVien, '%')");
                where.Add("[SinhVienHoTen] LIKE CONCAT('%', @hoTen, '%')");
                where.Add("[SinhVienGioiTinh] LIKE CONCAT('%', @gioiTinh, '%')");
                where.Add("[SinhVienCMND] LIKE CONCAT('%', @cMND, '%')");
                where.Add("[SinhVienSDT] LIKE CONCAT('%', @sDT, '%')");
                where.Add("[SinhVienQueQuan] LIKE CONCAT('%', @queQuan, '%')");
                where.Add("[SinhVienMaKhoa] = @maKhoa");

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@hoTen", hoTen));
                command.Parameters.Add(new SqlParameter("@gioiTinh", gioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", cMND));
                command.Parameters.Add(new SqlParameter("@sDT", sDT));
                command.Parameters.Add(new SqlParameter("@queQuan", queQuan));
                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join("AND", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListSinhVien(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maSinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteSinhVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    base.ProcessSqlException(e);
                }
            }
        }
    }
}
