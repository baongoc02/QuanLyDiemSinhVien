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
            //TODO: sau khi cập nhật DAO fix chỗ này
            KetQuaHocTap_gridview.Columns.Clear();
            KetQuaHocTap_gridview.DataSource = ketQuaHocTapViewModels;
        }

        private void LoadGridView()
        {
            //TODO: sau khi cập nhật DAO fix chỗ này
            //KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            //List<KetQuaHocTapViewModel> ketQuaHocTapViewModels = ketQuaHocTapService.ListAll();
            //LoadDSKetQuaHocTap(ketQuaHocTapViewModels);
        }

        [DesignOnly(true)]
        private void XemKetQuaHocTapPageAdmin_Load(object sender, EventArgs e)
        {

            //TODO: sau khi cập nhật DAO fix chỗ này
            LoadGridView();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            //TODO: sau khi cập nhật DAO sửa chỗ này thêm hiện lên số tín chỉ tích lũy, điểm trung bình tích lũy, xếp loại của sinh viên
            //List<KetQuaHocTapViewModel> ketQuaHocTapViewModels = ketQuaHocTapService.Search(txtMSSV.Text);
            //LoadDSKetQuaHocTap(ketQuaHocTapViewModels);
        }

        private void KetQuaHocTap_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (KetQuaHocTap_gridview.SelectedRows.Count == 1)
            {
                var data = KetQuaHocTap_gridview.SelectedRows[0].DataBoundItem as KetQuaHocTapViewModel;
                KetQuaHocTapSinhVien ketQuaHocTapSinhVien = new KetQuaHocTapSinhVien();
                ketQuaHocTapSinhVien.ketQuaHocTapViewModel = data;
                ketQuaHocTapSinhVien.ShowDialog();
                LoadGridView();
            }
        }
    }
}
