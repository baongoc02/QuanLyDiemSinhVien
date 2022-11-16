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
    public class SinhVienExcelEngine
    {
        public SinhVienExcelEngine()
        {
            
        }

        public void LoadFromFile(string excelFile)
        {
            var conn = SqlServer.SqlServerConnectionSingleon.getInstance();
            using (var transaction = conn.BeginTransaction())
            {
                int i = 0;
                try
                {
                    var workbook = WorkBook.Load(excelFile);
                    var sheet = workbook.WorkSheets[0];
                    for (i = 1; i < sheet.RowCount; ++i)
                    {
                        SinhVien sinhVien = new SinhVien();

                        if (sheet.GetCellAt(i, 0) == null)
                            break;

                        sinhVien.MaSinhVien = string.Format("{0}", sheet.GetCellAt(i, 1));
                        sinhVien.HoTen = string.Format("{0}", sheet.GetCellAt(i, 2));

                        DateTime temp;
                        if (!DateTime.TryParse(string.Format("{0}", sheet.GetCellAt(i, 3)), out temp))
                            throw new Exception(string.Format("Dòng {0} - Ngày tháng năm không đúng định dạng", i + 1));
                        sinhVien.NgaySinh = temp;

                        sinhVien.GioiTinh = string.Format("{0}", sheet.GetCellAt(i, 4));
                        sinhVien.CMND = string.Format("{0}", sheet.GetCellAt(i, 5));
                        sinhVien.SDT = string.Format("{0}", sheet.GetCellAt(i, 6));
                        sinhVien.QueQuan = string.Format("{0}", sheet.GetCellAt(i, 7));

                        //sinhVienMaKhoa
                        string tenKhoa = string.Format("{0}", sheet.GetCellAt(i, 8));

                        using (var command = conn.CreateCommand())
                        {
                            command.CommandText = "Proc_CreateSinhVienWithTenKhoa";
                            command.CommandType = CommandType.StoredProcedure;
                            
                            command.Parameters.Add(new SqlParameter("@maSinhVien", sinhVien.MaSinhVien));
                            command.Parameters.Add(new SqlParameter("@hoTen", sinhVien.HoTen));
                            command.Parameters.Add(new SqlParameter("@ngaySinh", sinhVien.NgaySinh));
                            command.Parameters.Add(new SqlParameter("@gioiTinh", sinhVien.GioiTinh));
                            command.Parameters.Add(new SqlParameter("@cMND", sinhVien.CMND));
                            command.Parameters.Add(new SqlParameter("@sDT", sinhVien.SDT));
                            command.Parameters.Add(new SqlParameter("@queQuan", sinhVien.QueQuan));
                            command.Parameters.Add(new SqlParameter("@tenKhoa", tenKhoa));

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
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
