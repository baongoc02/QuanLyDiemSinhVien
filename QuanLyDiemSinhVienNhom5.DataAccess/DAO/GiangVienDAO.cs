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
    public class GiangVienDAO : BaseDAO
    {
        public GiangVienDAO()
        {

        }

        public void Create(GiangVien giangVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateGiangVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maGiangVien", giangVien.MaGiangVien));
                command.Parameters.Add(new SqlParameter("@hoTen", giangVien.HoTen));
                command.Parameters.Add(new SqlParameter("@ngaySinh", giangVien.NgaySinh));
                command.Parameters.Add(new SqlParameter("@gioiTinh", giangVien.GioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", giangVien.CMND));
                command.Parameters.Add(new SqlParameter("@sDT", giangVien.SDT));
                command.Parameters.Add(new SqlParameter("@queQuan", giangVien.QueQuan));
                command.Parameters.Add(new SqlParameter("@hocHam", giangVien.HocHam));
                command.Parameters.Add(new SqlParameter("@hocVi", giangVien.HocVi));
                command.Parameters.Add(new SqlParameter("@maKhoa", giangVien.MaKhoa));

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

        public void Update(string maGiangVien, GiangVien giangVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateGiangVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));
                command.Parameters.Add(new SqlParameter("@hoTen", giangVien.HoTen));
                command.Parameters.Add(new SqlParameter("@ngaySinh", giangVien.NgaySinh));
                command.Parameters.Add(new SqlParameter("@gioiTinh", giangVien.GioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", giangVien.CMND));
                command.Parameters.Add(new SqlParameter("@sDT", giangVien.SDT));
                command.Parameters.Add(new SqlParameter("@queQuan", giangVien.QueQuan));
                command.Parameters.Add(new SqlParameter("@hocHam", giangVien.HocHam));
                command.Parameters.Add(new SqlParameter("@hocVi", giangVien.HocVi));
                command.Parameters.Add(new SqlParameter("@maKhoa", giangVien.MaKhoa));

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

        private List<GiangVien> ConvertDataTableToListGiangVien(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new GiangVien()
                        {
                          MaGiangVien = Convert.ToString(u["GiangVienMaGiangVien"]),
                          HoTen = Convert.ToString(u["GiangVienHoTen"]),
                          NgaySinh = Convert.ToDateTime(u["GiangVienNgaySinh"]),
                          GioiTinh = Convert.ToString(u["GiangVienGioiTinh"]),
                          CMND = Convert.ToString(u["GiangVienCMND"]),
                          SDT = Convert.ToString(u["GiangVienSDT"]),
                          QueQuan = Convert.ToString(u["GiangVienQueQuan"]),
                          HocHam = Convert.ToString(u["GiangVienHocHam"]),
                          HocVi = Convert.ToString(u["GiangVienHocVi"]),
                          MaKhoa = Convert.ToString(u["GiangVienMaKhoa"])
                        });

            return result.ToList();
        }

        public bool CheckGiangVienExistsByPrimaryKey(string maGiangVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [GiangVien] WHERE [MaGiangVien] = @maGiangVien";

                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<GiangVien> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllGiangVien";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListGiangVien(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<GiangVien> Search(string maGiangVien, string hoTen, string gioiTinh, string cMND, string sDT, string queQuan, string hocHam, string hocVi, string maKhoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllGiangVien";

                List<string> where = new List<string>();

                where.Add("[MaGiangVien] LIKE CONCAT('%', @maGiangVien, '%')}");
                where.Add("[HoTen] LIKE CONCAT('%', @hoTen, '%')}");
                where.Add("[GioiTinh] LIKE CONCAT('%', @gioiTinh, '%')}");
                where.Add("[CMND] LIKE CONCAT('%', @cMND, '%')}");
                where.Add("[SDT] LIKE CONCAT('%', @sDT, '%')}");
                where.Add("[QueQuan] LIKE CONCAT('%', @queQuan, '%')}");
                where.Add("[HocHam] LIKE CONCAT('%', @hocHam, '%')}");
                where.Add("[HocVi] LIKE CONCAT('%', @hocVi, '%')}");
                where.Add("[MaKhoa] = @maKhoa");

                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));
                command.Parameters.Add(new SqlParameter("@hoTen", hoTen));
                command.Parameters.Add(new SqlParameter("@gioiTinh", gioiTinh));
                command.Parameters.Add(new SqlParameter("@cMND", cMND));
                command.Parameters.Add(new SqlParameter("@sDT", sDT));
                command.Parameters.Add(new SqlParameter("@queQuan", queQuan));
                command.Parameters.Add(new SqlParameter("@hocHam", hocHam));
                command.Parameters.Add(new SqlParameter("@hocVi", hocVi));
                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join("AND", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListGiangVien(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maGiangVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteGiangVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));

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
