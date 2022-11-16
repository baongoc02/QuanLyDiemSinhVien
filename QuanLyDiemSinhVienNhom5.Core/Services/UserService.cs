using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.Services
{
    public class UserService : BaseService
    {
        private readonly UserDAO userDAO;

        public UserService()
        {
            this.userDAO = new UserDAO();
        }

        public int IsAdmin(string userName)
        {
            try
            {
                bool result = this.userDAO.CheckRole(userName, "sysadmin");
                if (result == true) return 1;
                else return 2;
            }
            catch (DataAccessException e)
            {
                this.OnError(e.Message);
                return -1;
            }
            catch (Exception e)
            {
                this.OnError("Lỗi hệ thống");
                this.OnError(e.Message);
                return -1;
            }
        }
    }
}
