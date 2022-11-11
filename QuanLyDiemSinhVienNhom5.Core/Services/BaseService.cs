using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Core.Services
{
    public abstract class BaseService
    {
        public delegate void ServiceMessageHandler(object sender, string message);
        public virtual event ServiceMessageHandler OnErrorMessage, OnSuccessMessage;

        public BaseService()
        {

        }

        public void OnError(string message)
        {
            this.OnErrorMessage?.Invoke(this, message);
        }

        public void OnSuccess(string message)
        {
            this.OnSuccessMessage?.Invoke(this, message);
        }
    }
}
