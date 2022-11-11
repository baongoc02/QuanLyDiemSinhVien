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
    public class LopDAO
    {
        public LopDAO()
        {

        }

        public void Create(Lop lop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateLop";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maLop", lop.MaLop));
                command.Parameters.Add(new SqlParameter("@maHocKy", lop.MaHocKy));
                command.Parameters.Add(new SqlParameter("@maMonHoc", lop.MaMonHoc));
                command.Parameters.Add(new SqlParameter("@maGiangVien", lop.MaGiangVien));
                command.Parameters.Add(new SqlParameter("@lichHoc", lop.LichHoc));
                command.Parameters.Add(new SqlParameter("@ngayBatDau", lop.NgayBatDau));
                command.Parameters.Add(new SqlParameter("@ngayKetThuc", lop.NgayKetThuc));
                command.Parameters.Add(new SqlParameter("@gioiHan", lop.GioiHan));

                command.ExecuteNonQuery();
            }
        }

        public void Update(string maLop, Lop lop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateLop";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                command.Parameters.Add(new SqlParameter("@maHocKy", lop.MaHocKy));
                command.Parameters.Add(new SqlParameter("@maMonHoc", lop.MaMonHoc));
                command.Parameters.Add(new SqlParameter("@maGiangVien", lop.MaGiangVien));
                command.Parameters.Add(new SqlParameter("@lichHoc", lop.LichHoc));
                command.Parameters.Add(new SqlParameter("@ngayBatDau", lop.NgayBatDau));
                command.Parameters.Add(new SqlParameter("@ngayKetThuc", lop.NgayKetThuc));
                command.Parameters.Add(new SqlParameter("@gioiHan", lop.GioiHan));

                command.ExecuteNonQuery();
            }
        }

        private List<Lop> ConvertDataTableToListLop(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new Lop()
                        {
                          MaLop = Convert.ToString(u["MaLop"]),
                          MaHocKy = Convert.ToString(u["MaHocKy"]),
                          MaMonHoc = Convert.ToString(u["MaMonHoc"]),
                          MaGiangVien = Convert.ToString(u["MaGiangVien"]),
                          LichHoc = Convert.ToString(u["LichHoc"]),
                          NgayBatDau = Convert.ToDateTime(u["NgayBatDau"]),
                          NgayKetThuc = Convert.ToDateTime(u["NgayKetThuc"]),
                          GioiHan = Convert.ToInt32(u["GioiHan"])
                        });

            return result.ToList();
        }

        public bool CheckLopExistsByPrimaryKey(string maLop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [Lop] WHERE [MaLop] = @maLop";

                command.Parameters.Add(new SqlParameter("@maLop", maLop));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<Lop> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllLop";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListLop(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<Lop> Search(string maLop, string maHocKy, string maMonHoc, string maGiangVien, string lichHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllLop";

                List<string> where = new List<string>();

                where.Add("[MaLop] LIKE CONCAT('%', @maLop, '%')}");
                where.Add("[MaHocKy] = @maHocKy");
                where.Add("[MaMonHoc] = @maMonHoc");
                where.Add("[MaGiangVien] = @maGiangVien");
                where.Add("[LichHoc] LIKE CONCAT('%', @lichHoc, '%')}");

                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));
                command.Parameters.Add(new SqlParameter("@maMonHoc", maMonHoc));
                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));
                command.Parameters.Add(new SqlParameter("@lichHoc", lichHoc));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join("AND", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListLop(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maLop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteLop";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maLop", maLop));

                command.ExecuteNonQuery();
            }
        }
    }
}
