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
    public class MonHocDAO : BaseDAO
    {
        public MonHocDAO()
        {

        }

        public void Create(MonHoc monHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateMonHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maMonHoc", monHoc.MaMonHoc));
                command.Parameters.Add(new SqlParameter("@tenMonHoc", monHoc.TenMonHoc));
                command.Parameters.Add(new SqlParameter("@moTa", monHoc.MoTa));
                command.Parameters.Add(new SqlParameter("@sTC", monHoc.STC));
                command.Parameters.Add(new SqlParameter("@loaiHocPhan", monHoc.LoaiHocPhan));
                command.Parameters.Add(new SqlParameter("@maKhoa", monHoc.MaKhoa));

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

        public void Update(string maMonHoc, MonHoc monHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateMonHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maMonHoc", maMonHoc));
                command.Parameters.Add(new SqlParameter("@tenMonHoc", monHoc.TenMonHoc));
                command.Parameters.Add(new SqlParameter("@moTa", monHoc.MoTa));
                command.Parameters.Add(new SqlParameter("@sTC", monHoc.STC));
                command.Parameters.Add(new SqlParameter("@loaiHocPhan", monHoc.LoaiHocPhan));
                command.Parameters.Add(new SqlParameter("@maKhoa", monHoc.MaKhoa));

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

        private List<MonHoc> ConvertDataTableToListMonHoc(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new MonHoc()
                        {
                          MaMonHoc = Convert.ToString(u["MonHocMaMonHoc"]),
                          TenMonHoc = Convert.ToString(u["MonHocTenMonHoc"]),
                          MoTa = Convert.ToString(u["MonHocMoTa"]),
                          STC = Convert.ToInt32(u["MonHocSTC"]),
                          LoaiHocPhan = Convert.ToString(u["MonHocLoaiHocPhan"]),
                          MaKhoa = Convert.ToString(u["MonHocMaKhoa"])
                        });

            return result.ToList();
        }

        public bool CheckMonHocExistsByPrimaryKey(string maMonHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [MonHoc] WHERE [MaMonHoc] = @maMonHoc";

                command.Parameters.Add(new SqlParameter("@maMonHoc", maMonHoc));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<MonHoc> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllMonHoc";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListMonHoc(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<MonHoc> Search(string maMonHoc, string tenMonHoc, string moTa, string loaiHocPhan, string maKhoa)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllMonHoc";
                command.Parameters.Add(new SqlParameter("@maMonHoc", maMonHoc));
                command.Parameters.Add(new SqlParameter("@tenMonHoc", tenMonHoc));
                command.Parameters.Add(new SqlParameter("@moTa", moTa));
                command.Parameters.Add(new SqlParameter("@loaiHocPhan", loaiHocPhan));
                command.Parameters.Add(new SqlParameter("@maKhoa", maKhoa));

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListMonHoc(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maMonHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteMonHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maMonHoc", maMonHoc));

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
