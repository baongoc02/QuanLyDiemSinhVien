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
    public partial class XemKetQuaHocTapPageAdmin : UserControl
    {
        private readonly KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
        private readonly LopService lopService = new LopService();
        public XemKetQuaHocTapPageAdmin()
        {
            InitializeComponent();
        }

        private void Btn_Them_Click(object sender, EventArgs e)
        {
            KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
            ketQuaHocTapSinhVien.ShowDialog();
            LoadGridView();
        }

        private void LoadDSKetQuaHocTap(IEnumerable<KetQuaHocTapViewModel> ketQuaHocTapViewModels)
        {
            KetQuaHocTap_gridview.Columns.Clear();
            KetQuaHocTap_gridview.DataSource = ketQuaHocTapViewModels;
        }

        private void LoadGridView()
        {
            KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            List<KetQuaHocTapViewModel> ketQuaHocTapViewModels = ketQuaHocTapService.ListAll();
            LoadDSKetQuaHocTap(ketQuaHocTapViewModels);
        }

        private void XemKetQuaHocTapPageAdmin_Load(object sender, EventArgs e)
        {
            cbMaLop.DataSource = lopService.ListAll();
            cbMaLop.DisplayMember = nameof(LopViewModel.MaLop);
            cbMaLop.ValueMember = nameof(LopViewModel.MaLop);

            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            List<KetQuaHocTapViewModel> ketQuaHocTapViewModels = ketQuaHocTapService.Search(txtMSSV.Text, cbMaLop.SelectedValue.ToString());
            LoadDSKetQuaHocTap(ketQuaHocTapViewModels);
        }
    }
}
