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
    public class HocKyDAO : BaseDAO
    {
        public HocKyDAO()
        {

        }

        public void Create(HocKy hocKy)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_CreateHocKy";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maHocKy", hocKy.MaHocKy));
                command.Parameters.Add(new SqlParameter("@tenHocKy", hocKy.TenHocKy));
                command.Parameters.Add(new SqlParameter("@ngayBatDau", hocKy.NgayBatDau));
                command.Parameters.Add(new SqlParameter("@ngayKetThuc", hocKy.NgayKetThuc));
                command.Parameters.Add(new SqlParameter("@maNamHoc", hocKy.MaNamHoc));

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

        public void Update(string maHocKy, HocKy hocKy)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_UpdateHocKy";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));
                command.Parameters.Add(new SqlParameter("@tenHocKy", hocKy.TenHocKy));
                command.Parameters.Add(new SqlParameter("@ngayBatDau", hocKy.NgayBatDau));
                command.Parameters.Add(new SqlParameter("@ngayKetThuc", hocKy.NgayKetThuc));
                command.Parameters.Add(new SqlParameter("@maNamHoc", hocKy.MaNamHoc));

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

        private List<HocKy> ConvertDataTableToListHocKy(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new HocKy()
                        {
                          MaHocKy = Convert.ToString(u["HocKyMaHocKy"]),
                          TenHocKy = Convert.ToString(u["HocKyTenHocKy"]),
                          NgayBatDau = Convert.ToDateTime(u["HocKyNgayBatDau"]),
                          NgayKetThuc = Convert.ToDateTime(u["HocKyNgayKetThuc"]),
                          MaNamHoc = Convert.ToString(u["HocKyMaNamHoc"])
                        });

            return result.ToList();
        }

        public bool CheckHocKyExistsByPrimaryKey(string maHocKy)
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM [HocKy] WHERE [MaHocKy] = @maHocKy";

                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));

                return (int)command.ExecuteScalar() > 0;
            }
        }

        public List<HocKy> ListAll()
        {
            var conn = SqlServerConnectionSingleon.getInstance();

            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM View_ListAllHocKy";
                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListHocKy(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public List<HocKy> Search(string maHocKy, string tenHocKy, string maNamHoc)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Proc_ListAllHocKy";
                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));
                command.Parameters.Add(new SqlParameter("@tenHocKy", tenHocKy));
                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));

                using (var adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    var result = this.ConvertDataTableToListHocKy(tempTable);
                    tempTable.Dispose();
                    return result;
                }
            }
        }

        public void Delete(string maHocKy)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DeleteHocKy";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));

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
