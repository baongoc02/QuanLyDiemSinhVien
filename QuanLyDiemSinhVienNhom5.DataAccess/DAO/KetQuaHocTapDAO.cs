using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using QuanLyDiemSinhVienNhom5.DataAccess.Model;

namespace QuanLyDiemSinhVienNhom5.DataAccess.DAO
{
    public class KetQuaHocTapDAO : BaseDAO
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

        public List<KetQuaHocTapTheoSinhVien> GetKetQuaHocTapTheoSinhVien(string maSinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_KetQuaHocTapTheoSinhVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    return tempTable.AsEnumerable()
                        .Select(u => new KetQuaHocTapTheoSinhVien()
                        {
                            MaSinhVien = Convert.ToString(u["MaSinhVien"]),
                            TenSinhVien = Convert.ToString(u["TenSinhVien"]),
                            MaLop = Convert.ToString(u["MaLop"]),
                            DiemTrungBinh = Convert.ToDouble(u["DiemTrungBinh"]),
                            Loai = Convert.ToString(u["Loai"]),
                            TenMonHoc = Convert.ToString(u["TenMonHoc"])
                        }).ToList();
                }
            }
        }

        public List<TinhSTCAndDiemTrungBinh> GetTinhSTCAndDiemTrungBinh(string maSinhVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "proc_TinhSTCAndDiemTrungBinh";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));


                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    return tempTable.AsEnumerable()
                        .Select(u => new TinhSTCAndDiemTrungBinh()
                        {
                            TenSinhVien = Convert.ToString(u["TenSinhVien"]),
                            MaLop = Convert.ToString(u["MaLop"]),
                            DiemTrungBinh = Convert.ToDouble(u["DiemTrungBinh"]),
                            Loai = Convert.ToString(u["Loai"]),
                            TenMonHoc = Convert.ToString(u["TenMonHoc"])
                        }).ToList();
                }
            }
        }

        public List<KetQuaHocTapTheoMaLopVaXepLoai> GetKetQuaHocTapTheoMaLopVaXepLoai(string maLop, string tenLoai)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_KetQuaHocTapTheoMaLopVaXepLoai";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                command.Parameters.Add(new SqlParameter("@tenLoai", tenLoai));

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    return tempTable.AsEnumerable()
                        .Select(u => new KetQuaHocTapTheoMaLopVaXepLoai()
                        {
                            TenSinhVien = Convert.ToString(u["TenSinhVien"]),
                            MaLop = Convert.ToString(u["MaLop"]),
                            TenMonHoc = Convert.ToString(u["TenMonHoc"]),
                            DiemTrungBinh = Convert.ToDouble(u["DiemTrungBinh"]),
                            Loai = Convert.ToString(u["Loai"])
                        }).ToList();
                }
            }
        }

        public List<DSSVKhongDatMonHoc> GetDSSVKhongDatMonHoc(string maMon, string maHocKy)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_DSSVKhongDatMonHoc";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@maMonHoc", maMon));
                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    return tempTable.AsEnumerable()
                        .Select(u => new DSSVKhongDatMonHoc()
                        {
                            DiemTrungBinh = Convert.ToDouble(u["DiemTrungBinh"]),
                            MaSinhVien = Convert.ToString(u["MaSinhVien"]),
                            HoTen = Convert.ToString(u["HoTen"]),
                            Khoa = Convert.ToString(u["Khoa"])
                        }).ToList();
                }
            }
        }

        public List<TimTrongHomePageGiangVien> GetTimTrongHomePageGiangVien(string maMon, string maLop, string maHocKy, string maNamHoc, string maGiangVien)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                command.CommandText = "Proc_TimTrongHomePageGiangVien";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@monHoc", maMon));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));
                command.Parameters.Add(new SqlParameter("@maHocKy", maHocKy));
                command.Parameters.Add(new SqlParameter("@maNamHoc", maNamHoc));
                command.Parameters.Add(new SqlParameter("@maGiangVien", maGiangVien));

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable tempTable = new DataTable();
                    adapter.Fill(tempTable);
                    return tempTable.AsEnumerable()
                        .Select(u => new TimTrongHomePageGiangVien()
                        {
                            DiemTrungBinh = Convert.ToDouble(u["DiemTrungBinh"]),
                            MaSinhVien = Convert.ToString(u["MaSinhVien"]),
                            MaLop = Convert.ToString(u["MaLop"]),
                            TenHocKy = Convert.ToString(u["TenHocKy"]),
                            TenMon = Convert.ToString(u["TenMonHoc"]),
                            TenNamHoc = Convert.ToString(u["TenNamHoc"])
                        }).ToList();
                }
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

        private List<KetQuaHocTap> ConvertDataTableToListKetQuaHocTap(DataTable dTable)
        {
            var result = dTable.AsEnumerable()
                        .Select(u => new KetQuaHocTap()
                        {
                          MaSinhVien = Convert.ToString(u["KetQuaHocTapMaSinhVien"]),
                          MaLop = Convert.ToString(u["KetQuaHocTapMaLop"]),
                          DiemGiuaKy = (float)Convert.ToDouble(u["KetQuaHocTapDiemGiuaKy"]),
                          DiemCuoiKy = (float)Convert.ToDouble(u["KetQuaHocTapDiemCuoiKy"])
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
                command.CommandText = "Proc_ListAllKetQuaHocTap";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@maSinhVien", maSinhVien));
                command.Parameters.Add(new SqlParameter("@maLop", maLop));

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
