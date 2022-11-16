using QuanLyDiemSinhVienNhom5.Core.Services;
using QuanLyDiemSinhVienNhom5.Core.ViewModel;
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
    public partial class DSSVTheoLop_XepLoai : UserControl
    {
        public DSSVTheoLop_XepLoai()
        {
            InitializeComponent();
        }

        public void LoadDSSinhVien(IEnumerable<KetQuaHocTapTheoMaLopVaXepLoaiViewModel> ketQuaHocTapTheoMaLopVaXepLoaiViewModels)
        {
            DSSV_gridview.Columns.Clear();
            DSSV_gridview.DataSource = ketQuaHocTapTheoMaLopVaXepLoaiViewModels;

            txtSoLuong.Text = DSSV_gridview.RowCount.ToString();
        }

        private void Btn_Tim_Click(object sender, EventArgs e)
        {
            KetQuaHocTapService ketQuaHocTapService = new KetQuaHocTapService();
            List<KetQuaHocTapTheoMaLopVaXepLoaiViewModel> ketQuaHocTapTheoMaLopVaXepLoaiViewModels = ketQuaHocTapService.GetKetQuaHocTapTheoMaLopVaXepLoai(cbLop.SelectedValue.ToString(), cbXepLoai.SelectedItem.ToString());
            LoadDSSinhVien(ketQuaHocTapTheoMaLopVaXepLoaiViewModels);
        }

        [DesignOnly(true)]
        private void DSSVTheoLop_XepLoai_Load(object sender, EventArgs e)
        {
            string[] xepLoais = new string[] { "Xuất sắc", "Giỏi", "Khá", "Trung bình", "Yếu", "Kém" };
            cbXepLoai.Items.AddRange(xepLoais);

            LopService lopService = new LopService();
            var listLop = lopService.ListAll();
            foreach (var lop in listLop)
            {
                lop.TenLop = lop.MaLop;
            }
            listLop.Insert(0, new LopViewModel()
            {
                MaLop = "",
                TenLop = "-- Tất cả các lớp --"
            });
            cbLop.DataSource = listLop;
            cbLop.DisplayMember = nameof(LopViewModel.TenLop);
            cbLop.ValueMember = nameof(LopViewModel.MaLop);
        }

        private void DSSV_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
