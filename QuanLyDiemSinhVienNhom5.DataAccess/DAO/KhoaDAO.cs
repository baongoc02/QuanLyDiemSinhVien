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
    public class KhoaDAO : BaseDAO
    {
        public KhoaDAO()
        {

        }

        public void Create(Khoa khoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateKhoa";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maKhoa", khoa.MaKhoa));
                command.Parameters.Add(new SqlParameter("@tenKhoa", khoa.TenKhoa));
                command.Parameters.Add(new SqlParameter("@heDaoTao", khoa.HeDaoTao));
                command.Parameters.Add(new SqlParameter("@ngayThanhLap", khoa.NgayThanhLap));

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

        public void Update(string maKhoa, Khoa khoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateKhoa";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));
                command.Parameters.Add(new SqlParameter("@tenKhoa", khoa.TenKhoa));
                command.Parameters.Add(new SqlParameter("@heDaoTao", khoa.HeDaoTao));
                command.Parameters.Add(new SqlParameter("@ngayThanhLap", khoa.NgayThanhLap));

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

        private List<Khoa> ConvertDataTableToListKhoa(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new Khoa()
                        {
                          MaKhoa = Convert.ToString(u["KhoaMaKhoa"]),
                          TenKhoa = Convert.ToString(u["KhoaTenKhoa"]),
                          HeDaoTao = Convert.ToString(u["KhoaHeDaoTao"]),
                          NgayThanhLap = Convert.ToDateTime(u["KhoaNgayThanhLap"])
                        });

            return result.ToList();
        }

        public bool CheckKhoaExistsByPrimaryKey(string maKhoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [Khoa] WHERE [MaKhoa] = @maKhoa";

                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<Khoa> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllKhoa";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListKhoa(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<Khoa> Search(string maKhoa, string tenKhoa, string heDaoTao)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllKhoa";

                List<string> where = new List<string>();

                where.Add("[MaKhoa] LIKE CONCAT('%', @maKhoa, '%')}");
                where.Add("[TenKhoa] LIKE CONCAT('%', @tenKhoa, '%')}");
                where.Add("[HeDaoTao] LIKE CONCAT('%', @heDaoTao, '%')}");

                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));
                command.Parameters.Add(new SqlParameter("@tenKhoa", tenKhoa));
                command.Parameters.Add(new SqlParameter("@heDaoTao", heDaoTao));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join("AND", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListKhoa(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maKhoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteKhoa";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));

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
