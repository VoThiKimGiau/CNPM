
namespace Quan_Li_Nha_Sach
{
    partial class QuanLySanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.dataGridView_SP = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.cbb_NCC = new System.Windows.Forms.ComboBox();
            this.cbb_LoaiSP = new System.Windows.Forms.ComboBox();
            this.txt_TenSP = new System.Windows.Forms.TextBox();
            this.txt_Gia = new System.Windows.Forms.TextBox();
            this.txt_maSP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_timkiem = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SP)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(669, 61);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(290, 35);
            this.txt_Search.TabIndex = 19;
            // 
            // dataGridView_SP
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_SP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_SP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column2,
            this.Column4,
            this.Column5});
            this.dataGridView_SP.Location = new System.Drawing.Point(546, 102);
            this.dataGridView_SP.Name = "dataGridView_SP";
            this.dataGridView_SP.RowHeadersWidth = 51;
            this.dataGridView_SP.RowTemplate.Height = 24;
            this.dataGridView_SP.Size = new System.Drawing.Size(1240, 574);
            this.dataGridView_SP.TabIndex = 17;
            this.dataGridView_SP.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_SP_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaSP";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "Mã Sản Phẩm";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 137;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "MaNCC";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Mã Nhà Cung Cấp";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 175;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaLoai";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column2.HeaderText = "Mã Loại";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GiaBan";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Giá Bán";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TenSP";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Column5.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column5.HeaderText = "Tên Sản Phẩm";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 400;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Sua);
            this.panel1.Controls.Add(this.btn_Xoa);
            this.panel1.Controls.Add(this.btn_them);
            this.panel1.Controls.Add(this.cbb_NCC);
            this.panel1.Controls.Add(this.cbb_LoaiSP);
            this.panel1.Controls.Add(this.txt_TenSP);
            this.panel1.Controls.Add(this.txt_Gia);
            this.panel1.Controls.Add(this.txt_maSP);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(-2, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 574);
            this.panel1.TabIndex = 16;
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Location = new System.Drawing.Point(209, 395);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(103, 44);
            this.btn_Sua.TabIndex = 13;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(400, 395);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(103, 44);
            this.btn_Xoa.TabIndex = 12;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(18, 395);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(102, 44);
            this.btn_them.TabIndex = 3;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // cbb_NCC
            // 
            this.cbb_NCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_NCC.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_NCC.FormattingEnabled = true;
            this.cbb_NCC.Location = new System.Drawing.Point(14, 345);
            this.cbb_NCC.Name = "cbb_NCC";
            this.cbb_NCC.Size = new System.Drawing.Size(522, 31);
            this.cbb_NCC.TabIndex = 10;
            // 
            // cbb_LoaiSP
            // 
            this.cbb_LoaiSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_LoaiSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_LoaiSP.FormattingEnabled = true;
            this.cbb_LoaiSP.Location = new System.Drawing.Point(14, 117);
            this.cbb_LoaiSP.Name = "cbb_LoaiSP";
            this.cbb_LoaiSP.Size = new System.Drawing.Size(522, 31);
            this.cbb_LoaiSP.TabIndex = 9;
            // 
            // txt_TenSP
            // 
            this.txt_TenSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TenSP.Location = new System.Drawing.Point(14, 186);
            this.txt_TenSP.Multiline = true;
            this.txt_TenSP.Name = "txt_TenSP";
            this.txt_TenSP.Size = new System.Drawing.Size(522, 35);
            this.txt_TenSP.TabIndex = 8;
            this.txt_TenSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_TenSP_KeyDown);
            // 
            // txt_Gia
            // 
            this.txt_Gia.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Gia.Location = new System.Drawing.Point(14, 265);
            this.txt_Gia.Multiline = true;
            this.txt_Gia.Name = "txt_Gia";
            this.txt_Gia.Size = new System.Drawing.Size(522, 35);
            this.txt_Gia.TabIndex = 7;
            this.txt_Gia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Gia_KeyPress);
            // 
            // txt_maSP
            // 
            this.txt_maSP.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maSP.Location = new System.Drawing.Point(14, 42);
            this.txt_maSP.Multiline = true;
            this.txt_maSP.Name = "txt_maSP";
            this.txt_maSP.Size = new System.Drawing.Size(522, 35);
            this.txt_maSP.TabIndex = 5;
            this.txt_maSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_maSP_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 4;
            this.label6.Text = "Tên sản phẩm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 319);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Nhà cung cấp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Loại sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giá bán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sản phẩm";
            // 
            // btn_timkiem
            // 
            this.btn_timkiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timkiem.Location = new System.Drawing.Point(546, 58);
            this.btn_timkiem.Name = "btn_timkiem";
            this.btn_timkiem.Size = new System.Drawing.Size(117, 38);
            this.btn_timkiem.TabIndex = 18;
            this.btn_timkiem.Text = "Tìm kiếm";
            this.btn_timkiem.UseVisualStyleBackColor = true;
            this.btn_timkiem.Click += new System.EventHandler(this.btn_timkiem_Click);
            // 
            // btn
            // 
            this.btn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn.Location = new System.Drawing.Point(-2, 3);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(146, 38);
            this.btn.TabIndex = 15;
            this.btn.Text = "Về trang chủ";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(597, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Quản Lý Sản Phẩm";
            // 
            // QuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1809, 747);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.dataGridView_SP);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_timkiem);
            this.Name = "QuanLySanPham";
            this.Text = "Quản Lý Sản Phẩm";
            this.Load += new System.EventHandler(this.SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SP)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridView dataGridView_SP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.ComboBox cbb_NCC;
        private System.Windows.Forms.ComboBox cbb_LoaiSP;
        private System.Windows.Forms.TextBox txt_TenSP;
        private System.Windows.Forms.TextBox txt_Gia;
        private System.Windows.Forms.TextBox txt_maSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_timkiem;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}