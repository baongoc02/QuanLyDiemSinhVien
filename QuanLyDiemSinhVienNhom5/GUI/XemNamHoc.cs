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
    public partial class XemNamHoc : UserControl
    {
        public XemNamHoc()
        {
            InitializeComponent();
        }

        public void LoadDSNamHoc(IEnumerable<NamHocViewModel> namHocViewModels)
        {
            NamHoc_gridview.Columns.Clear();
            NamHoc_gridview.DataSource = namHocViewModels;
        }

        public void LoadGridView()
        {
            NamHocService namHocService = new NamHocService();
            List<NamHocViewModel> namHocViewModels = new List<NamHocViewModel>();
            namHocViewModels = namHocService.ListAll();
            LoadDSNamHoc(namHocViewModels);
        }

        private void XemNamHoc_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            NamHocInfo namHocInfo = new NamHocInfo();
            namHocInfo.ShowDialog();

            LoadGridView();
        }
    }
}
