namespace Quan_Li_Nha_Sach
{
    partial class frmThongKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtGV_ThongKeCTDH = new System.Windows.Forms.DataGridView();
            this.MaDH_CTDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSP_CTDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CTDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGV_ThongKeSP = new System.Windows.Forms.DataGridView();
            this.MaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboTimKiemSP = new System.Windows.Forms.ComboBox();
            this.txtTimKiemSP = new System.Windows.Forms.TextBox();
            this.btnTimKiemSP = new System.Windows.Forms.Button();
            this.cbo_TinhTrang = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtGV_ThongKeDH = new System.Windows.Forms.DataGridView();
            this.MaDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTienDH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbo_TimKiem = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.lb_TongDoanhThu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMenu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeCTDH)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeSP)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeDH)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1314, 40);
            this.label1.TabIndex = 45;
            this.label1.Text = "Thống Kê";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtGV_ThongKeCTDH);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(622, 315);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Đơn Hàng";
            // 
            // dtGV_ThongKeCTDH
            // 
            this.dtGV_ThongKeCTDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGV_ThongKeCTDH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtGV_ThongKeCTDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_ThongKeCTDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDH_CTDH,
            this.MaSP_CTDH,
            this.SoLuong,
            this.GiaBan_CTDH});
            this.dtGV_ThongKeCTDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGV_ThongKeCTDH.Location = new System.Drawing.Point(3, 23);
            this.dtGV_ThongKeCTDH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGV_ThongKeCTDH.Name = "dtGV_ThongKeCTDH";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGV_ThongKeCTDH.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtGV_ThongKeCTDH.RowHeadersWidth = 51;
            this.dtGV_ThongKeCTDH.Size = new System.Drawing.Size(616, 290);
            this.dtGV_ThongKeCTDH.TabIndex = 47;
            // 
            // MaDH_CTDH
            // 
            this.MaDH_CTDH.HeaderText = "Mã Đơn Hàng";
            this.MaDH_CTDH.MinimumWidth = 6;
            this.MaDH_CTDH.Name = "MaDH_CTDH";
            // 
            // MaSP_CTDH
            // 
            this.MaSP_CTDH.HeaderText = "Mã sản phẩm";
            this.MaSP_CTDH.MinimumWidth = 6;
            this.MaSP_CTDH.Name = "MaSP_CTDH";
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            // 
            // GiaBan_CTDH
            // 
            this.GiaBan_CTDH.HeaderText = "Giá bán";
            this.GiaBan_CTDH.MinimumWidth = 6;
            this.GiaBan_CTDH.Name = "GiaBan_CTDH";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox2);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(692, 40);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(622, 715);
            this.panel4.TabIndex = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtGV_ThongKeSP);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 315);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(622, 400);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sản Phẩm";
            // 
            // dtGV_ThongKeSP
            // 
            this.dtGV_ThongKeSP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGV_ThongKeSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGV_ThongKeSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_ThongKeSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSP,
            this.TenSP,
            this.TenLoai,
            this.GiaBan,
            this.DaBan,
            this.TongTien});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGV_ThongKeSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtGV_ThongKeSP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGV_ThongKeSP.Location = new System.Drawing.Point(3, 103);
            this.dtGV_ThongKeSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtGV_ThongKeSP.Name = "dtGV_ThongKeSP";
            this.dtGV_ThongKeSP.RowHeadersWidth = 51;
            this.dtGV_ThongKeSP.RowTemplate.Height = 24;
            this.dtGV_ThongKeSP.Size = new System.Drawing.Size(616, 295);
            this.dtGV_ThongKeSP.TabIndex = 33;
            // 
            // MaSP
            // 
            this.MaSP.HeaderText = "Mã Sản Phẩm";
            this.MaSP.MinimumWidth = 6;
            this.MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            this.TenSP.HeaderText = "Tên Sản Phẩm";
            this.TenSP.MinimumWidth = 6;
            this.TenSP.Name = "TenSP";
            // 
            // TenLoai
            // 
            this.TenLoai.HeaderText = "Loại";
            this.TenLoai.MinimumWidth = 6;
            this.TenLoai.Name = "TenLoai";
            // 
            // GiaBan
            // 
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.MinimumWidth = 6;
            this.GiaBan.Name = "GiaBan";
            // 
            // DaBan
            // 
            this.DaBan.HeaderText = "Đã Bán";
            this.DaBan.MinimumWidth = 6;
            this.DaBan.Name = "DaBan";
            // 
            // TongTien
            // 
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.MinimumWidth = 6;
            this.TongTien.Name = "TongTien";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboTimKiemSP);
            this.panel1.Controls.Add(this.txtTimKiemSP);
            this.panel1.Controls.Add(this.btnTimKiemSP);
            this.panel1.Controls.Add(this.cbo_TinhTrang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 80);
            this.panel1.TabIndex = 0;
            // 
            // cboTimKiemSP
            // 
            this.cboTimKiemSP.FormattingEnabled = true;
            this.cboTimKiemSP.Location = new System.Drawing.Point(383, 6);
            this.cboTimKiemSP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboTimKiemSP.Name = "cboTimKiemSP";
            this.cboTimKiemSP.Size = new System.Drawing.Size(178, 32);
            this.cboTimKiemSP.TabIndex = 22;
            // 
            // txtTimKiemSP
            // 
            this.txtTimKiemSP.Location = new System.Drawing.Point(383, 43);
            this.txtTimKiemSP.Name = "txtTimKiemSP";
            this.txtTimKiemSP.Size = new System.Drawing.Size(178, 28);
            this.txtTimKiemSP.TabIndex = 20;
            // 
            // btnTimKiemSP
            // 
            this.btnTimKiemSP.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiemSP.Image")));
            this.btnTimKiemSP.Location = new System.Drawing.Point(566, 34);
            this.btnTimKiemSP.Name = "btnTimKiemSP";
            this.btnTimKiemSP.Size = new System.Drawing.Size(44, 40);
            this.btnTimKiemSP.TabIndex = 21;
            this.btnTimKiemSP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiemSP.UseVisualStyleBackColor = true;
            this.btnTimKiemSP.Click += new System.EventHandler(this.btnTimKiemSP_Click);
            // 
            // cbo_TinhTrang
            // 
            this.cbo_TinhTrang.FormattingEnabled = true;
            this.cbo_TinhTrang.Location = new System.Drawing.Point(20, 34);
            this.cbo_TinhTrang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_TinhTrang.Name = "cbo_TinhTrang";
            this.cbo_TinhTrang.Size = new System.Drawing.Size(143, 32);
            this.cbo_TinhTrang.TabIndex = 0;
            this.cbo_TinhTrang.SelectionChangeCommitted += new System.EventHandler(this.cbo_TinhTrang_SelectionChangeCommitted);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtGV_ThongKeDH);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 40);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(692, 715);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Doanh Thu";
            // 
            // dtGV_ThongKeDH
            // 
            this.dtGV_ThongKeDH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGV_ThongKeDH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtGV_ThongKeDH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_ThongKeDH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDH,
            this.TenNV,
            this.TenKH,
            this.NgayDat,
            this.TongTienDH});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Sitka Text", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGV_ThongKeDH.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtGV_ThongKeDH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGV_ThongKeDH.Location = new System.Drawing.Point(3, 143);
            this.dtGV_ThongKeDH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtGV_ThongKeDH.Name = "dtGV_ThongKeDH";
            this.dtGV_ThongKeDH.RowHeadersWidth = 51;
            this.dtGV_ThongKeDH.Size = new System.Drawing.Size(686, 570);
            this.dtGV_ThongKeDH.TabIndex = 46;
            this.dtGV_ThongKeDH.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_ThongKeDH_CellClick);
            // 
            // MaDH
            // 
            this.MaDH.HeaderText = "Mã Đơn Hàng";
            this.MaDH.MinimumWidth = 6;
            this.MaDH.Name = "MaDH";
            // 
            // TenNV
            // 
            this.TenNV.HeaderText = "Tên Nhân Viên";
            this.TenNV.MinimumWidth = 6;
            this.TenNV.Name = "TenNV";
            // 
            // TenKH
            // 
            this.TenKH.HeaderText = "Tên Khách Hàng";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            // 
            // NgayDat
            // 
            this.NgayDat.HeaderText = "Ngày Đặt";
            this.NgayDat.MinimumWidth = 6;
            this.NgayDat.Name = "NgayDat";
            // 
            // TongTienDH
            // 
            this.TongTienDH.HeaderText = "Tổng Tiền";
            this.TongTienDH.MinimumWidth = 6;
            this.TongTienDH.Name = "TongTienDH";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbo_TimKiem);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.lb_TongDoanhThu);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(686, 120);
            this.panel2.TabIndex = 1;
            // 
            // cbo_TimKiem
            // 
            this.cbo_TimKiem.FormattingEnabled = true;
            this.cbo_TimKiem.Location = new System.Drawing.Point(16, 18);
            this.cbo_TimKiem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbo_TimKiem.Name = "cbo_TimKiem";
            this.cbo_TimKiem.Size = new System.Drawing.Size(178, 32);
            this.cbo_TimKiem.TabIndex = 19;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(16, 54);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(178, 28);
            this.txtTimKiem.TabIndex = 17;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(199, 45);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(44, 40);
            this.btnTimKiem.TabIndex = 18;
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lb_TongDoanhThu
            // 
            this.lb_TongDoanhThu.AutoSize = true;
            this.lb_TongDoanhThu.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_TongDoanhThu.ForeColor = System.Drawing.Color.Tomato;
            this.lb_TongDoanhThu.Location = new System.Drawing.Point(246, 92);
            this.lb_TongDoanhThu.Name = "lb_TongDoanhThu";
            this.lb_TongDoanhThu.Size = new System.Drawing.Size(35, 25);
            this.lb_TongDoanhThu.TabIndex = 3;
            this.lb_TongDoanhThu.Text = "0đ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sitka Text", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(37, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng doanh thu:";
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(12, 0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(104, 40);
            this.btnMenu.TabIndex = 52;
            this.btnMenu.Text = "Về trang chủ";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 755);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmThongKe";
            this.Text = "Thống Kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeCTDH)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeSP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_ThongKeDH)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtGV_ThongKeCTDH;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtGV_ThongKeSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtGV_ThongKeDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDat;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTienDH;
        private System.Windows.Forms.Label lb_TongDoanhThu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDH_CTDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSP_CTDH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CTDH;
        private System.Windows.Forms.ComboBox cbo_TinhTrang;
        private System.Windows.Forms.ComboBox cbo_TimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboTimKiemSP;
        private System.Windows.Forms.TextBox txtTimKiemSP;
        private System.Windows.Forms.Button btnTimKiemSP;
        private System.Windows.Forms.Button btnMenu;
    }
}