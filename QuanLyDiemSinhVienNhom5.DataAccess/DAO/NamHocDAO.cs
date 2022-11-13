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
    public class NamHocDAO : BaseDAO
    {
        public NamHocDAO()
        {

        }

        public void Create(NamHoc namHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateNamHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maNamHoc", namHoc.MaNamHoc));
                command.Parameters.Add(new SqlParameter("@tenNamHoc", namHoc.TenNamHoc));

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

        public void Update(string maNamHoc, NamHoc namHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateNamHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));
                command.Parameters.Add(new SqlParameter("@tenNamHoc", namHoc.TenNamHoc));

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

        private List<NamHoc> ConvertDataTableToListNamHoc(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new NamHoc()
                        {
                          MaNamHoc = Convert.ToString(u["NamHocMaNamHoc"]),
                          TenNamHoc = Convert.ToString(u["NamHocTenNamHoc"])
                        });

            return result.ToList();
        }

        public bool CheckNamHocExistsByPrimaryKey(string maNamHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [NamHoc] WHERE [MaNamHoc] = @maNamHoc";

                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<NamHoc> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllNamHoc";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListNamHoc(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<NamHoc> Search(string maNamHoc, string tenNamHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllNamHoc";

                List<string> where = new List<string>();

                where.Add("[NamHocMaNamHoc] LIKE CONCAT('%', @maNamHoc, '%')");
                where.Add("[NamHocTenNamHoc] LIKE CONCAT('%', @tenNamHoc, '%')");

                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));
                command.Parameters.Add(new SqlParameter("@tenNamHoc", tenNamHoc));
                
                if (where.Count > 0)
                {
                    command.CommandText += " WHERE " + string.Join(" AND ", where);
                }

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListNamHoc(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maNamHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteNamHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));

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
