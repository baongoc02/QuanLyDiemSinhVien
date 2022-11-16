using QuanLyDiemSinhVienNhom5.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.DataAccess.DAO
{
    public class UserDAO : BaseDAO
    {
        public bool CheckRole(string username, string roleName)
        {
            var conn = SqlServerConnectionSingleon.getInstance();
            using (var command = conn.CreateCommand())
            {
                try
                {
                    command.CommandText = "SELECT dbo.Func_Check_Role(@userName, @roleName)";
                    command.Parameters.Add(new SqlParameter("@userName", username));
                    command.Parameters.Add(new SqlParameter("@roleName", roleName));
                    return Convert.ToInt32(command.ExecuteScalar()) == 1;
                }
                catch (Exception e)
                {
                    base.ProcessSqlException(e);
                    return false;
                }
            }
        }
    }
}
