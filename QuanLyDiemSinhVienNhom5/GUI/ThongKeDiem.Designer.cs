namespace QuanLyDiemSinhVienNhom5.GUI
{
    partial class ThongKeDiem
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
            this.pnMain = new System.Windows.Forms.Panel();
            this.Btn_DSSVKhongDat = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.Btn_DSSVTheoMonVaXepLoai = new QuanLyDiemSinhVienNhom5.GUI.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 18F);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 36);
            this.label1.TabIndex = 40;
            this.label1.Text = "Thống kê điểm";
            // 
            // pnMain
            // 
            this.pnMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnMain.Location = new System.Drawing.Point(49, 204);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1030, 530);
            this.pnMain.TabIndex = 47;
            // 
            // Btn_DSSVKhongDat
            // 
            this.Btn_DSSVKhongDat.BackColor = System.Drawing.Color.MediumVioletRed;
            this.Btn_DSSVKhongDat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DSSVKhongDat.FlatAppearance.BorderSize = 0;
            this.Btn_DSSVKhongDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_DSSVKhongDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_DSSVKhongDat.ForeColor = System.Drawing.Color.White;
            this.Btn_DSSVKhongDat.Location = new System.Drawing.Point(54, 135);
            this.Btn_DSSVKhongDat.Name = "Btn_DSSVKhongDat";
            this.Btn_DSSVKhongDat.Size = new System.Drawing.Size(471, 50);
            this.Btn_DSSVKhongDat.TabIndex = 45;
            this.Btn_DSSVKhongDat.Text = "Danh sách sinh viên không đạt một môn";
            this.Btn_DSSVKhongDat.UseVisualStyleBackColor = false;
            this.Btn_DSSVKhongDat.Click += new System.EventHandler(this.Btn_DSSVKhongDat_Click);
            // 
            // Btn_DSSVTheoMonVaXepLoai
            // 
            this.Btn_DSSVTheoMonVaXepLoai.BackColor = System.Drawing.Color.MediumVioletRed;
            this.Btn_DSSVTheoMonVaXepLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_DSSVTheoMonVaXepLoai.FlatAppearance.BorderSize = 0;
            this.Btn_DSSVTheoMonVaXepLoai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_DSSVTheoMonVaXepLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_DSSVTheoMonVaXepLoai.ForeColor = System.Drawing.Color.White;
            this.Btn_DSSVTheoMonVaXepLoai.Location = new System.Drawing.Point(54, 79);
            this.Btn_DSSVTheoMonVaXepLoai.Name = "Btn_DSSVTheoMonVaXepLoai";
            this.Btn_DSSVTheoMonVaXepLoai.Size = new System.Drawing.Size(471, 50);
            this.Btn_DSSVTheoMonVaXepLoai.TabIndex = 44;
            this.Btn_DSSVTheoMonVaXepLoai.Text = "Danh sách sinh viên theo lớp và xếp loại";
            this.Btn_DSSVTheoMonVaXepLoai.UseVisualStyleBackColor = false;
            this.Btn_DSSVTheoMonVaXepLoai.Click += new System.EventHandler(this.Btn_DSSVTheoMonVaXepLoai_Click);
            // 
            // ThongKeDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.Btn_DSSVKhongDat);
            this.Controls.Add(this.Btn_DSSVTheoMonVaXepLoai);
            this.Controls.Add(this.label1);
            this.Name = "ThongKeDiem";
            this.Size = new System.Drawing.Size(1130, 750);
            this.Load += new System.EventHandler(this.ThongKeDiem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private RoundedButton Btn_DSSVTheoMonVaXepLoai;
        private RoundedButton Btn_DSSVKhongDat;
        private System.Windows.Forms.Panel pnMain;
    }
}
