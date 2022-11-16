using QuanLyDiemSinhVienNhom5.GUI.Components;

namespace QuanLyDiemSinhVienNhom5.GUI
{
    partial class DanhSachSinhVienKhongDatMotMon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DSSV_gridview = new MagicalDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Tim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DSSV_gridview)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Enabled = false;
            this.txtSoLuong.Font = new System.Drawing.Font("Bahnschrift", 10.2F);
            this.txtSoLuong.Location = new System.Drawing.Point(182, 107);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 28);
            this.txtSoLuong.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(72, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 54;
            this.label1.Text = "Số lượng:";
            // 
            // DSSV_gridview
            // 
            this.DSSV_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DSSV_gridview.BackgroundColor = System.Drawing.Color.SeaShell;
            this.DSSV_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DSSV_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DSSV_gridview.Location = new System.Drawing.Point(3, 147);
            this.DSSV_gridview.Name = "DSSV_gridview";
            this.DSSV_gridview.RowHeadersWidth = 51;
            this.DSSV_gridview.RowTemplate.Height = 24;
            this.DSSV_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DSSV_gridview.Size = new System.Drawing.Size(1024, 380);
            this.DSSV_gridview.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(744, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 24);
            this.label5.TabIndex = 52;
            this.label5.Text = "Tìm";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.79814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.20186F));
            this.tableLayoutPanel1.Controls.Add(this.cbMon, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbHocKy, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(660, 92);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // cbMon
            // 
            this.cbMon.BackColor = System.Drawing.Color.Honeydew;
            this.cbMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(179, 3);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(478, 39);
            this.cbMon.TabIndex = 56;
            // 
            // cbHocKy
            // 
            this.cbHocKy.BackColor = System.Drawing.Color.Honeydew;
            this.cbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(179, 49);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(478, 39);
            this.cbHocKy.TabIndex = 44;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 46);
            this.label2.TabIndex = 15;
            this.label2.Text = "Môn:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 46);
            this.label3.TabIndex = 16;
            this.label3.Text = "Học kỳ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Btn_Tim
            // 
            this.Btn_Tim.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Tim.BackgroundImage = global::QuanLyDiemSinhVienNhom5.Properties.Resources.find_icon;
            this.Btn_Tim.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Tim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Tim.FlatAppearance.BorderSize = 0;
            this.Btn_Tim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Tim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Tim.Location = new System.Drawing.Point(696, 7);
            this.Btn_Tim.Name = "Btn_Tim";
            this.Btn_Tim.Size = new System.Drawing.Size(42, 42);
            this.Btn_Tim.TabIndex = 50;
            this.Btn_Tim.UseVisualStyleBackColor = false;
            this.Btn_Tim.Click += new System.EventHandler(this.Btn_Tim_Click);
            // 
            // DanhSachSinhVienKhongDatMotMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DSSV_gridview);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Btn_Tim);
            this.Name = "DanhSachSinhVienKhongDatMotMon";
            this.Size = new System.Drawing.Size(1030, 530);
            this.Load += new System.EventHandler(this.DanhSachSinhVienKhongDatMotMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSSV_gridview)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label1;
        private MagicalDataGridView DSSV_gridview;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Tim;
        private System.Windows.Forms.ComboBox cbMon;
    }
}
