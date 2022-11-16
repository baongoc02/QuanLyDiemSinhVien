using QuanLyDiemSinhVienNhom5.GUI.Components;

namespace QuanLyDiemSinhVienNhom5.GUI
{
    partial class XemLopHoc
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
            this.label1 = new System.Windows.Forms.Label();
            this.Lop_gridview = new MagicalDataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cbMon = new System.Windows.Forms.ComboBox();
            this.cbGiangVien = new System.Windows.Forms.ComboBox();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Them = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Btn_Tim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Lop_gridview)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 36);
            this.label1.TabIndex = 40;
            this.label1.Text = "Danh sách lớp học";
            // 
            // Lop_gridview
            // 
            this.Lop_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lop_gridview.BackgroundColor = System.Drawing.Color.SeaShell;
            this.Lop_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Lop_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Lop_gridview.Location = new System.Drawing.Point(54, 243);
            this.Lop_gridview.Name = "Lop_gridview";
            this.Lop_gridview.RowHeadersVisible = false;
            this.Lop_gridview.RowHeadersWidth = 51;
            this.Lop_gridview.RowTemplate.Height = 24;
            this.Lop_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Lop_gridview.Size = new System.Drawing.Size(1029, 482);
            this.Lop_gridview.TabIndex = 39;
            this.Lop_gridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Lop_gridview_CellClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.79814F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.20186F));
            this.tableLayoutPanel2.Controls.Add(this.cbMon, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbGiangVien, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.cbHocKy, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtMaLop, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(54, 64);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(862, 176);
            this.tableLayoutPanel2.TabIndex = 44;
            // 
            // cbMon
            // 
            this.cbMon.BackColor = System.Drawing.Color.Honeydew;
            this.cbMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbMon.FormattingEnabled = true;
            this.cbMon.Location = new System.Drawing.Point(233, 91);
            this.cbMon.Name = "cbMon";
            this.cbMon.Size = new System.Drawing.Size(612, 39);
            this.cbMon.TabIndex = 3;
            // 
            // cbGiangVien
            // 
            this.cbGiangVien.BackColor = System.Drawing.Color.Honeydew;
            this.cbGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbGiangVien.FormattingEnabled = true;
            this.cbGiangVien.Location = new System.Drawing.Point(233, 135);
            this.cbGiangVien.Name = "cbGiangVien";
            this.cbGiangVien.Size = new System.Drawing.Size(612, 39);
            this.cbGiangVien.TabIndex = 4;
            // 
            // cbHocKy
            // 
            this.cbHocKy.BackColor = System.Drawing.Color.Honeydew;
            this.cbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(233, 47);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(612, 39);
            this.cbHocKy.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Location = new System.Drawing.Point(3, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(224, 44);
            this.label6.TabIndex = 27;
            this.label6.Text = "Giảng viên:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 44);
            this.label7.TabIndex = 15;
            this.label7.Text = "Mã lớp:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label8.ForeColor = System.Drawing.Color.Indigo;
            this.label8.Location = new System.Drawing.Point(3, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(224, 44);
            this.label8.TabIndex = 17;
            this.label8.Text = "Môn:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label9.ForeColor = System.Drawing.Color.Indigo;
            this.label9.Location = new System.Drawing.Point(3, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(224, 44);
            this.label9.TabIndex = 16;
            this.label9.Text = "Học kỳ:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaLop
            // 
            this.txtMaLop.BackColor = System.Drawing.Color.Honeydew;
            this.txtMaLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLop.Location = new System.Drawing.Point(233, 3);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.Size = new System.Drawing.Size(612, 38);
            this.txtMaLop.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(985, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 24);
            this.label2.TabIndex = 49;
            this.label2.Text = "Thêm";
            // 
            // Btn_Them
            // 
            this.Btn_Them.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Them.BackgroundImage = global::QuanLyDiemSinhVienNhom5.Properties.Resources.Button_Add_icon;
            this.Btn_Them.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btn_Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Them.FlatAppearance.BorderSize = 0;
            this.Btn_Them.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Them.Location = new System.Drawing.Point(942, 110);
            this.Btn_Them.Name = "Btn_Them";
            this.Btn_Them.Size = new System.Drawing.Size(40, 40);
            this.Btn_Them.TabIndex = 48;
            this.Btn_Them.UseVisualStyleBackColor = false;
            this.Btn_Them.Click += new System.EventHandler(this.Btn_Them_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(987, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tìm";
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
            this.Btn_Tim.Location = new System.Drawing.Point(942, 64);
            this.Btn_Tim.Name = "Btn_Tim";
            this.Btn_Tim.Size = new System.Drawing.Size(40, 40);
            this.Btn_Tim.TabIndex = 46;
            this.Btn_Tim.UseVisualStyleBackColor = false;
            this.Btn_Tim.Click += new System.EventHandler(this.Btn_Tim_Click);
            // 
            // XemLopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Btn_Them);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Btn_Tim);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Lop_gridview);
            this.Name = "XemLopHoc";
            this.Size = new System.Drawing.Size(1130, 750);
            this.Load += new System.EventHandler(this.XemLopHoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Lop_gridview)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private MagicalDataGridView Lop_gridview;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.ComboBox cbHocKy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Them;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Tim;
        private System.Windows.Forms.ComboBox cbMon;
        private System.Windows.Forms.ComboBox cbGiangVien;
    }
}
