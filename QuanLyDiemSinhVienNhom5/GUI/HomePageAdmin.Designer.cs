namespace QuanLyDiemSinhVienNhom5.GUI
{
    partial class HomePageAdmin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip_Thoat = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DSKhoa = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DSGiangVien = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DSMonHoc = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn_DSSinhVien = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbLoginedUsername = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_XemNamHoc = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.Btn_XemHocKy = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.Btn_ThongKeDiem = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.Btn_KetQuaHocTap = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.Btn_LopHoc = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.pnMain = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.danhMụcToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1332, 32);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuStrip_Thoat});
            this.hệThốngToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(93, 28);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // MenuStrip_Thoat
            // 
            this.MenuStrip_Thoat.Name = "MenuStrip_Thoat";
            this.MenuStrip_Thoat.Size = new System.Drawing.Size(224, 28);
            this.MenuStrip_Thoat.Text = "Thoát";
            this.MenuStrip_Thoat.Click += new System.EventHandler(this.MenuStrip_Thoat_Click);
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Btn_DSKhoa,
            this.Btn_DSGiangVien,
            this.Btn_DSMonHoc,
            this.Btn_DSSinhVien});
            this.danhMụcToolStripMenuItem.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(103, 28);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // Btn_DSKhoa
            // 
            this.Btn_DSKhoa.Name = "Btn_DSKhoa";
            this.Btn_DSKhoa.Size = new System.Drawing.Size(264, 28);
            this.Btn_DSKhoa.Text = "Danh sách khoa";
            this.Btn_DSKhoa.Click += new System.EventHandler(this.Btn_DSKhoa_Click);
            // 
            // Btn_DSGiangVien
            // 
            this.Btn_DSGiangVien.Name = "Btn_DSGiangVien";
            this.Btn_DSGiangVien.Size = new System.Drawing.Size(264, 28);
            this.Btn_DSGiangVien.Text = "Danh sách giảng viên ";
            this.Btn_DSGiangVien.Click += new System.EventHandler(this.Btn_DSGiangVien_Click);
            // 
            // Btn_DSMonHoc
            // 
            this.Btn_DSMonHoc.Name = "Btn_DSMonHoc";
            this.Btn_DSMonHoc.Size = new System.Drawing.Size(264, 28);
            this.Btn_DSMonHoc.Text = "Danh sách môn học";
            this.Btn_DSMonHoc.Click += new System.EventHandler(this.Btn_DSMonHoc_Click);
            // 
            // Btn_DSSinhVien
            // 
            this.Btn_DSSinhVien.Name = "Btn_DSSinhVien";
            this.Btn_DSSinhVien.Size = new System.Drawing.Size(264, 28);
            this.Btn_DSSinhVien.Text = "Danh sách sinh viên";
            this.Btn_DSSinhVien.Click += new System.EventHandler(this.Btn_DSSinhVien_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbLoginedUsername});
            this.statusStrip1.Location = new System.Drawing.Point(0, 786);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1332, 27);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbLoginedUsername
            // 
            this.tbLoginedUsername.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLoginedUsername.Name = "tbLoginedUsername";
            this.tbLoginedUsername.Size = new System.Drawing.Size(93, 21);
            this.tbLoginedUsername.Text = "<Unknown>";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Btn_XemNamHoc);
            this.panel1.Controls.Add(this.Btn_XemHocKy);
            this.panel1.Controls.Add(this.Btn_ThongKeDiem);
            this.panel1.Controls.Add(this.Btn_KetQuaHocTap);
            this.panel1.Controls.Add(this.Btn_LopHoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 754);
            this.panel1.TabIndex = 7;
            // 
            // Btn_XemNamHoc
            // 
            this.Btn_XemNamHoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_XemNamHoc.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_XemNamHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_XemNamHoc.FlatAppearance.BorderSize = 0;
            this.Btn_XemNamHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_XemNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_XemNamHoc.ForeColor = System.Drawing.Color.White;
            this.Btn_XemNamHoc.Location = new System.Drawing.Point(21, 224);
            this.Btn_XemNamHoc.Name = "Btn_XemNamHoc";
            this.Btn_XemNamHoc.Size = new System.Drawing.Size(154, 58);
            this.Btn_XemNamHoc.TabIndex = 8;
            this.Btn_XemNamHoc.Text = "Xem năm học";
            this.Btn_XemNamHoc.UseVisualStyleBackColor = false;
            this.Btn_XemNamHoc.Click += new System.EventHandler(this.Btn_XemNamHoc_Click);
            // 
            // Btn_XemHocKy
            // 
            this.Btn_XemHocKy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_XemHocKy.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_XemHocKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_XemHocKy.FlatAppearance.BorderSize = 0;
            this.Btn_XemHocKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_XemHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_XemHocKy.ForeColor = System.Drawing.Color.White;
            this.Btn_XemHocKy.Location = new System.Drawing.Point(21, 294);
            this.Btn_XemHocKy.Name = "Btn_XemHocKy";
            this.Btn_XemHocKy.Size = new System.Drawing.Size(154, 58);
            this.Btn_XemHocKy.TabIndex = 7;
            this.Btn_XemHocKy.Text = "Xem học kỳ";
            this.Btn_XemHocKy.UseVisualStyleBackColor = false;
            this.Btn_XemHocKy.Click += new System.EventHandler(this.Btn_XemHocKy_Click);
            // 
            // Btn_ThongKeDiem
            // 
            this.Btn_ThongKeDiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_ThongKeDiem.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_ThongKeDiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_ThongKeDiem.FlatAppearance.BorderSize = 0;
            this.Btn_ThongKeDiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ThongKeDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ThongKeDiem.ForeColor = System.Drawing.Color.White;
            this.Btn_ThongKeDiem.Location = new System.Drawing.Point(21, 85);
            this.Btn_ThongKeDiem.Name = "Btn_ThongKeDiem";
            this.Btn_ThongKeDiem.Size = new System.Drawing.Size(154, 58);
            this.Btn_ThongKeDiem.TabIndex = 6;
            this.Btn_ThongKeDiem.Text = "Thống kê điểm";
            this.Btn_ThongKeDiem.UseVisualStyleBackColor = false;
            this.Btn_ThongKeDiem.Click += new System.EventHandler(this.Btn_ThongKeDiem_Click);
            // 
            // Btn_KetQuaHocTap
            // 
            this.Btn_KetQuaHocTap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_KetQuaHocTap.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_KetQuaHocTap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_KetQuaHocTap.FlatAppearance.BorderSize = 0;
            this.Btn_KetQuaHocTap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_KetQuaHocTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_KetQuaHocTap.ForeColor = System.Drawing.Color.White;
            this.Btn_KetQuaHocTap.Location = new System.Drawing.Point(21, 15);
            this.Btn_KetQuaHocTap.Name = "Btn_KetQuaHocTap";
            this.Btn_KetQuaHocTap.Size = new System.Drawing.Size(154, 58);
            this.Btn_KetQuaHocTap.TabIndex = 5;
            this.Btn_KetQuaHocTap.Text = "Xem kết quả học tập";
            this.Btn_KetQuaHocTap.UseVisualStyleBackColor = false;
            this.Btn_KetQuaHocTap.Click += new System.EventHandler(this.Btn_KetQuaHocTap_Click);
            // 
            // Btn_LopHoc
            // 
            this.Btn_LopHoc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_LopHoc.BackColor = System.Drawing.Color.DarkOrange;
            this.Btn_LopHoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_LopHoc.FlatAppearance.BorderSize = 0;
            this.Btn_LopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LopHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LopHoc.ForeColor = System.Drawing.Color.White;
            this.Btn_LopHoc.Location = new System.Drawing.Point(21, 154);
            this.Btn_LopHoc.Name = "Btn_LopHoc";
            this.Btn_LopHoc.Size = new System.Drawing.Size(154, 58);
            this.Btn_LopHoc.TabIndex = 4;
            this.Btn_LopHoc.Text = "Xem lớp học";
            this.Btn_LopHoc.UseVisualStyleBackColor = false;
            this.Btn_LopHoc.Click += new System.EventHandler(this.Btn_LopHoc_Click);
            // 
            // pnMain
            // 
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(200, 32);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1132, 754);
            this.pnMain.TabIndex = 8;
            // 
            // HomePageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 813);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "HomePageAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStrip_Thoat;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Btn_DSKhoa;
        private System.Windows.Forms.ToolStripMenuItem Btn_DSGiangVien;
        private System.Windows.Forms.ToolStripMenuItem Btn_DSMonHoc;
        private System.Windows.Forms.ToolStripMenuItem Btn_DSSinhVien;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tbLoginedUsername;
        private System.Windows.Forms.Panel panel1;
        private RoundedButton Btn_XemNamHoc;
        private RoundedButton Btn_XemHocKy;
        private RoundedButton Btn_ThongKeDiem;
        private RoundedButton Btn_KetQuaHocTap;
        private RoundedButton Btn_LopHoc;
        private System.Windows.Forms.Panel pnMain;
    }
}