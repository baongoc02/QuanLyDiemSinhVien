using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.DataAccess.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVienNhom5.GUI
{
    public partial class XemSinhVien : UserControl
    {
        public XemSinhVien()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            SinhVienInfo sinhVienInfo = new SinhVienInfo();
            sinhVienInfo.ShowDialog();
            LoadGridView();
        }

        public void LoadDSSinhVien(IEnumerable<SinhVienViewModel> sinhVienViewModels)
        {
            SinhVien_gridview.Columns.Clear();
            SinhVien_gridview.DataSource = sinhVienViewModels;


        }

        public void LoadGridView()
        {
            SinhVienService sinhVienService = new SinhVienService();
            List<SinhVienViewModel> sinhVienViewModels = new List<SinhVienViewModel>();
            sinhVienViewModels = sinhVienService.ListAll();
            LoadDSSinhVien(sinhVienViewModels);
        }

        [DesignOnly(true)]
        private void XemSinhVien_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }
    }
}
