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
    public partial class XemMonHoc : UserControl
    {
        public XemMonHoc()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            MonHocInfo monHocInfo = new MonHocInfo();
            monHocInfo.ShowDialog();

        }
        public void LoadDSMonHoc(IEnumerable<MonHocViewModel> monHocViewModels)
        {

        }

        public void LoadGridView()
        {
            MonHocService monHocService = new MonHocService();

        }

        private void XemMonHoc_Load(object sender, EventArgs e)
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
    }
}
