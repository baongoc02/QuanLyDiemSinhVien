namespace QuanLyDiemSinhVienNhom5.GUI
{
    partial class XemGiangVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbKhoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaGiangVien = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoGiangVien_gridview = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.Btn_Tim = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Them = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGiangVien_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.79814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.20186F));
            this.tableLayoutPanel1.Controls.Add(this.cbKhoa, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMaGiangVien, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtHoTen, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(54, 85);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(862, 137);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // cbKhoa
            // 
            this.cbKhoa.BackColor = System.Drawing.Color.Honeydew;
            this.cbKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.cbKhoa.FormattingEnabled = true;
            this.cbKhoa.Location = new System.Drawing.Point(233, 95);
            this.cbKhoa.Name = "cbKhoa";
            this.cbKhoa.Size = new System.Drawing.Size(612, 39);
            this.cbKhoa.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label2.ForeColor = System.Drawing.Color.Indigo;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 46);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mã giảng viên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label4.ForeColor = System.Drawing.Color.Indigo;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 45);
            this.label4.TabIndex = 17;
            this.label4.Text = "Khoa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 12F);
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(3, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 46);
            this.label3.TabIndex = 16;
            this.label3.Text = "Họ tên:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaGiangVien
            // 
            this.txtMaGiangVien.BackColor = System.Drawing.Color.Honeydew;
            this.txtMaGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGiangVien.Location = new System.Drawing.Point(233, 3);
            this.txtMaGiangVien.Name = "txtMaGiangVien";
            this.txtMaGiangVien.Size = new System.Drawing.Size(612, 38);
            this.txtMaGiangVien.TabIndex = 10;
            // 
            // txtHoTen
            // 
            this.txtHoTen.BackColor = System.Drawing.Color.Honeydew;
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(233, 49);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(612, 38);
            this.txtHoTen.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 36);
            this.label1.TabIndex = 30;
            this.label1.Text = "Danh sách giảng viên";
            // 
            // InfoGiangVien_gridview
            // 
            this.InfoGiangVien_gridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InfoGiangVien_gridview.BackgroundColor = System.Drawing.Color.SeaShell;
            this.InfoGiangVien_gridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoGiangVien_gridview.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InfoGiangVien_gridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.InfoGiangVien_gridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoGiangVien_gridview.Location = new System.Drawing.Point(54, 243);
            this.InfoGiangVien_gridview.Name = "InfoGiangVien_gridview";
            this.InfoGiangVien_gridview.RowHeadersVisible = false;
            this.InfoGiangVien_gridview.RowHeadersWidth = 51;
            this.InfoGiangVien_gridview.RowTemplate.Height = 24;
            this.InfoGiangVien_gridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InfoGiangVien_gridview.Size = new System.Drawing.Size(1029, 482);
            this.InfoGiangVien_gridview.TabIndex = 29;
            this.InfoGiangVien_gridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InfoGiangVien_gridview_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Indigo;
            this.label6.Location = new System.Drawing.Point(990, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 24);
            this.label6.TabIndex = 35;
            this.label6.Text = "Tìm";
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
            this.Btn_Tim.Location = new System.Drawing.Point(945, 88);
            this.Btn_Tim.Name = "Btn_Tim";
            this.Btn_Tim.Size = new System.Drawing.Size(40, 40);
            this.Btn_Tim.TabIndex = 34;
            this.Btn_Tim.UseVisualStyleBackColor = false;
            this.Btn_Tim.Click += new System.EventHandler(this.Btn_Tim_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(988, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 24);
            this.label5.TabIndex = 45;
            this.label5.Text = "Thêm";
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
            this.Btn_Them.Location = new System.Drawing.Point(945, 134);
            this.Btn_Them.Name = "Btn_Them";
            this.Btn_Them.Size = new System.Drawing.Size(40, 40);
            this.Btn_Them.TabIndex = 44;
            this.Btn_Them.UseVisualStyleBackColor = false;
            this.Btn_Them.Click += new System.EventHandler(this.Btn_Them_Click);
            // 
            // XemGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_Them);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Btn_Tim);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InfoGiangVien_gridview);
            this.Name = "XemGiangVien";
            this.Size = new System.Drawing.Size(1130, 750);
            this.Load += new System.EventHandler(this.XemGiangVien_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoGiangVien_gridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaGiangVien;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView InfoGiangVien_gridview;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Btn_Tim;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Them;
        private System.Windows.Forms.ComboBox cbKhoa;
    }
}
