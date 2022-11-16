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
    public partial class ThongKeDiem : UserControl
    {
        public ThongKeDiem()
        {
            InitializeComponent();
        }

        [DesignOnly(true)]
        private void ThongKeDiem_Load(object sender, EventArgs e)
        {
        }

        private void AddViewToPanelMain(UserControl control)
        {
            if (this.pnMain.Controls.Count > 0)
            {
                var temp = this.pnMain.Controls[0];
                this.pnMain.Controls.Clear();
                temp.Dispose();
            }
            control.Dock = DockStyle.Fill;
            this.pnMain.Controls.Add(control);
        }

        private void Btn_DSSVTheoMonVaXepLoai_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new DSSVTheoLop_XepLoai());
        }

        private void Btn_DSSVKhongDat_Click(object sender, EventArgs e)
        {
            this.AddViewToPanelMain(new DanhSachSinhVienKhongDatMotMon());
        }
    }
}
