using IronXL;
using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.ExcelEngine
{
    public class NhapDiemSinhVienExcelEngine
    {
        public int LoadFromFile(string excelFile)
        {
            var conn = SqlServer.SqlServerConnectionSingleon.getInstance();
            using (var transaction = conn.BeginTransaction())
            {
                int i = 0;
                int counter = 0;
                try
                {
                    var workbook = WorkBook.Load(excelFile);
                    var sheet = workbook.WorkSheets[0];
                    for (i = 1; i < sheet.RowCount; ++i)
                    {
                        KetQuaHocTap ketQuaHocTap = new KetQuaHocTap();

                        if (sheet.GetCellAt(i, 0) == null)
                            break;

                        ketQuaHocTap.MaSinhVien = $"{sheet.GetCellAt(i, 0)}";
                        ketQuaHocTap.MaLop = $"{sheet.GetCellAt(i, 1)}";

                        if (!float.TryParse($"{sheet.GetCellAt(i, 2)}", out float dGiuaKy))
                        {
                            throw new DataAccessException($"Dòng {i + 1} lỗi: điểm giữa kì không hợp lệ");
                        }

                        if (!float.TryParse($"{sheet.GetCellAt(i, 3)}", out float dCuoiKi))
                        {
                            throw new DataAccessException($"Dòng {i + 1} lỗi: điểm cuối kì không hợp lệ");
                        }

                        ketQuaHocTap.DiemGiuaKy = dGiuaKy;
                        ketQuaHocTap.DiemCuoiKy = dCuoiKi;

                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = "Proc_ImportKetQuaHocTap";
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.Add(new SqlParameter("@maSinhVien", ketQuaHocTap.MaSinhVien));
                            command.Parameters.Add(new SqlParameter("@maLop", ketQuaHocTap.MaLop));
                            command.Parameters.Add(new SqlParameter("@diemGiuaKy", ketQuaHocTap.DiemGiuaKy));
                            command.Parameters.Add(new SqlParameter("@diemCuoiKy", ketQuaHocTap.DiemCuoiKy));

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            counter++;
                        }
                    }

                    transaction.Commit();

                    return counter;
                }
                catch (DataAccessException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    if (e is SqlException)
                    {
                        var ex = (SqlException)e;
                        throw new DataAccessException(string.Format("Dòng {0}: {1}", i + 1, ex.Errors[0].Message));
                    }
                    else
                    {
                        throw new DataAccessException($"Lỗi hệ thống: {e.Message}");
                    }
                }
            }
        }
    }
}
