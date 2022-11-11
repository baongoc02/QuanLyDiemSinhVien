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
    public class KetQuaHocTapDAO
    {
        public KetQuaHocTapDAO()
        {

        }

        public void Create(KetQuaHocTap ketQuaHocTap)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateKetQuaHocTap";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", ketQuaHocTap.MaSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", ketQuaHocTap.MaLop));
                command.Parameters.Add(new SqlParameter("@diemGiuaKy", ketQuaHocTap.DiemGiuaKy));
                command.Parameters.Add(new SqlParameter("@diemCuoiKy", ketQuaHocTap.DiemCuoiKy));

                command.ExecuteNonQuery();
            }
        }

        public void Update(string maSinhVien, string maLop, KetQuaHocTap ketQuaHocTap)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateKetQuaHocTap";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                command.Parameters.Add(new SqlParameter("@diemGiuaKy", ketQuaHocTap.DiemGiuaKy));
                command.Parameters.Add(new SqlParameter("@diemCuoiKy", ketQuaHocTap.DiemCuoiKy));

                command.ExecuteNonQuery();
            }
        }

        private List<KetQuaHocTap> ConvertDataTableToListKetQuaHocTap(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new KetQuaHocTap()
                        {
                          MaSinhVien = Convert.ToString(u["MaSinhVien"]),
                          MaLop = Convert.ToString(u["MaLop"]),
                          DiemGiuaKy = (float)Convert.ToDouble(u["DiemGiuaKy"]),
                          DiemCuoiKy = (float)Convert.ToDouble(u["DiemCuoiKy"])
                        });

            return result.ToList();
        }

        public bool CheckKetQuaHocTapExistsByPrimaryKey(string maSinhVien, string maLop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [KetQuaHocTap] WHERE [MaSinhVien] = @maSinhVien AND [MaLop] = @maLop";

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<KetQuaHocTap> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllKetQuaHocTap";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListKetQuaHocTap(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<KetQuaHocTap> Search(string maSinhVien, string maLop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllKetQuaHocTap";

                List<string> where = new List<string>();

                where.Add("[MaSinhVien] = @maSinhVien");
                where.Add("[MaLop] = @maLop");

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join("AND", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListKetQuaHocTap(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maSinhVien, string maLop)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteKetQuaHocTap";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));

                command.ExecuteNonQuery();
            }
        }
    }
}
