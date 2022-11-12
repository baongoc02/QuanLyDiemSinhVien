using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.DAO
{
    public class BaseDAO
    {
        public BaseDAO()
        {

        }

        public void ProcessSqlException(Exception e)
        {
            if (e is SqlException)
            {
                var ex = (SqlException)e;
                throw new DataAccessException(ex.Errors[0].Message);
            }
            else
            {
                throw new DataAccessException($"Lỗi hệ thống: {e.Message}");
            }
            
        }
    }
}
