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

        [DesignOnly(true)]
        private void XemNamHoc_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        [DesignOnly(true)]
        private void Btn_Them_Click(object sender, EventArgs e)
        {
            NamHocInfo namHocInfo = new NamHocInfo();
            namHocInfo.namHocViewModel = null;
            namHocInfo.ShowDialog();

            LoadGridView();
        }

        private void NamHoc_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (NamHoc_gridview.SelectedRows.Count == 1)
            {
                var data = NamHoc_gridview.SelectedRows[0].DataBoundItem as NamHocViewModel;

                NamHocInfo namHocInfo = new NamHocInfo();
                namHocInfo.namHocViewModel = data;
                namHocInfo.ShowDialog();
                LoadGridView();
            }
        }
    }
}
