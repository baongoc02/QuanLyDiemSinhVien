using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemSinhVienNhom5.GUI.Components
{
    public class MagicalDataGridView : DataGridView
    {
        public MagicalDataGridView()
        {
            this.Init();
            this.EnableDoubleBuffered();
            this.DataBindingComplete += OnDataBindingComplete;
        }

        private void EnableDoubleBuffered()
        {
            typeof(DataGridView).InvokeMember(
               "DoubleBuffered",
               BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
               null,
               this,
               new object[] { true });
        }

        private void OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in this.Columns)
            {
                if (column.Name.Contains("Ten"))
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                else if (new string[] { "TenGiangVien", "TenSinhVien", "TenKhoa", "HoTen" }.Contains(column.Name))
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                else
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void Init()
        {
            this.ReadOnly = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToOrderColumns = false;
            this.AllowUserToDeleteRows = false;

            this.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12.0f);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.DefaultCellStyle.Font = new Font("Arial", 12.0f);
        }
    }
}
