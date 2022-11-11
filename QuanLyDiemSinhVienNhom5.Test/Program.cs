using QuanLyDiemSinhVienNhom5.DataAccess.Base;
using QuanLyDiemSinhVienNhom5.DataAccess.DAO;
using QuanLyDiemSinhVienNhom5.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDiemSinhVienNhom5.Test
{
    public class Program
    {
        private static readonly AppSetting _setting = AppSettingSingleton.getSetting();
        private static readonly HocKyDAO hocKyDAO = new HocKyDAO();

        public static void Main(string[] args)
        {
            _setting.Login("sa", ((int)(1231 + 3)).ToString());
            Console.OutputEncoding = Encoding.UTF8;

            //hocKyDAO.Create(new HocKy()
            //{
            //    MaHocKy = "HK_01_2022",
            //    MaNamHoc = "Y_2022_2023",
            //    NgayBatDau = DateTime.Now,
            //    NgayKetThuc = DateTime.Now.AddDays(365 / 2),
            //    TenHocKy = "Học kỳ 1 năm 2022-2023"
            //});

            hocKyDAO.Update("Y_2022_2023_K01", new HocKy()
            {
                TenHocKy = "sss-01",
                NgayBatDau = new DateTime(2011, 10, 10),
                NgayKetThuc = new DateTime(2049, 11, 11),
                MaNamHoc = "Y_2022_2023"
            });

            hocKyDAO.Delete("Y_2022_2023_K01");

            List<HocKy> dsHocKy = hocKyDAO.ListAll();

            foreach (HocKy hocKy in dsHocKy)
            {
                Console.WriteLine($"{hocKy.MaHocKy} {hocKy.TenHocKy}");
            }

            _setting.Logout();

            Console.WriteLine("OKKKK");
            Console.ReadLine();
        }
    }
}
