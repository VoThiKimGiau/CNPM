
namespace Quan_Li_Nha_Sach
{
    partial class FrmPhieuXuat
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
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.txtMaPhieuXuat = new System.Windows.Forms.TextBox();
            this.mtbNgayXuat = new System.Windows.Forms.MaskedTextBox();
            this.cbbKhachHang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbNhanVienNhap = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDonNhap = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnMenu = new System.Windows.Forms.Button();
            this.grbThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).BeginInit();
            this.SuspendLayout();
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.txtMaPhieuXuat);
            this.grbThongTin.Controls.Add(this.mtbNgayXuat);
            this.grbThongTin.Controls.Add(this.cbbKhachHang);
            this.grbThongTin.Controls.Add(this.label5);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Controls.Add(this.cbbNhanVienNhap);
            this.grbThongTin.Controls.Add(this.label3);
            this.grbThongTin.Controls.Add(this.label4);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.ForeColor = System.Drawing.Color.White;
            this.grbThongTin.Location = new System.Drawing.Point(37, 37);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(814, 100);
            this.grbThongTin.TabIndex = 42;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông Tin";
            // 
            // txtMaPhieuXuat
            // 
            this.txtMaPhieuXuat.Location = new System.Drawing.Point(155, 66);
            this.txtMaPhieuXuat.Name = "txtMaPhieuXuat";
            this.txtMaPhieuXuat.Size = new System.Drawing.Size(160, 22);
            this.txtMaPhieuXuat.TabIndex = 37;
            this.txtMaPhieuXuat.TextChanged += new System.EventHandler(this.txtMaPhieuXuat_TextChanged);
            // 
            // mtbNgayXuat
            // 
            this.mtbNgayXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbNgayXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbNgayXuat.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbNgayXuat.Location = new System.Drawing.Point(147, 22);
            this.mtbNgayXuat.Margin = new System.Windows.Forms.Padding(4);
            this.mtbNgayXuat.Mask = "00/00/0000";
            this.mtbNgayXuat.Name = "mtbNgayXuat";
            this.mtbNgayXuat.Size = new System.Drawing.Size(160, 23);
            this.mtbNgayXuat.TabIndex = 34;
            this.mtbNgayXuat.ValidatingType = typeof(System.DateTime);
            // 
            // cbbKhachHang
            // 
            this.cbbKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbKhachHang.FormattingEnabled = true;
            this.cbbKhachHang.Location = new System.Drawing.Point(442, 62);
            this.cbbKhachHang.Margin = new System.Windows.Forms.Padding(4);
            this.cbbKhachHang.Name = "cbbKhachHang";
            this.cbbKhachHang.Size = new System.Drawing.Size(212, 25);
            this.cbbKhachHang.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Mã Phiếu Xuất";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "Ngày xuất";
            // 
            // cbbNhanVienNhap
            // 
            this.cbbNhanVienNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbNhanVienNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbNhanVienNhap.FormattingEnabled = true;
            this.cbbNhanVienNhap.Location = new System.Drawing.Point(442, 22);
            this.cbbNhanVienNhap.Margin = new System.Windows.Forms.Padding(4);
            this.cbbNhanVienNhap.Name = "cbbNhanVienNhap";
            this.cbbNhanVienNhap.Size = new System.Drawing.Size(212, 25);
            this.cbbNhanVienNhap.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(312, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "Nhân viên nhập";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(326, 65);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Khách Hàng";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.CadetBlue;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(366, 650);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(147, 48);
            this.btnXoa.TabIndex = 41;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BackColor = System.Drawing.Color.CadetBlue;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(93, 650);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(147, 48);
            this.btnThem.TabIndex = 38;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(123, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(603, 32);
            this.label2.TabIndex = 40;
            this.label2.Text = "QUẢN LÝ DANH SÁCH PHIẾU XUẤT HÀNG";
            // 
            // dgvHoaDonNhap
            // 
            this.dgvHoaDonNhap.AllowUserToAddRows = false;
            this.dgvHoaDonNhap.AllowUserToDeleteRows = false;
            this.dgvHoaDonNhap.AllowUserToOrderColumns = true;
            this.dgvHoaDonNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHoaDonNhap.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDonNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDonNhap.Location = new System.Drawing.Point(13, 159);
            this.dgvHoaDonNhap.Margin = new System.Windows.Forms.Padding(4);
            this.dgvHoaDonNhap.MultiSelect = false;
            this.dgvHoaDonNhap.Name = "dgvHoaDonNhap";
            this.dgvHoaDonNhap.ReadOnly = true;
            this.dgvHoaDonNhap.RowHeadersWidth = 51;
            this.dgvHoaDonNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDonNhap.Size = new System.Drawing.Size(842, 479);
            this.dgvHoaDonNhap.TabIndex = 39;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.BackColor = System.Drawing.Color.CadetBlue;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Location = new System.Drawing.Point(630, 650);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(147, 48);
            this.btnMenu.TabIndex = 43;
            this.btnMenu.Text = "Về trang chủ";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // FrmPhieuXuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(868, 711);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHoaDonNhap);
            this.Name = "FrmPhieuXuat";
            this.Text = "Quản Lý Danh Sách Phiếu Xuất";
            this.Load += new System.EventHandler(this.FrmPhieuXuat_Load_1);
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDonNhap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtMaPhieuXuat;
        private System.Windows.Forms.MaskedTextBox mtbNgayXuat;
        private System.Windows.Forms.ComboBox cbbKhachHang;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbNhanVienNhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoaDonNhap;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnMenu;
    }
}