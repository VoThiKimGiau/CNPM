namespace Quan_Li_Nha_Sach
{
    partial class frmLogin
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
            this.labTitle = new System.Windows.Forms.Label();
            this.labUN = new System.Windows.Forms.Label();
            this.labPass = new System.Windows.Forms.Label();
            this.txtUN = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ckShowPass = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTitle.Location = new System.Drawing.Point(236, 27);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(91, 26);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "LOGIN";
            // 
            // labUN
            // 
            this.labUN.AutoSize = true;
            this.labUN.Location = new System.Drawing.Point(90, 83);
            this.labUN.Name = "labUN";
            this.labUN.Size = new System.Drawing.Size(113, 27);
            this.labUN.TabIndex = 1;
            this.labUN.Text = "UserName";
            // 
            // labPass
            // 
            this.labPass.AutoSize = true;
            this.labPass.Location = new System.Drawing.Point(90, 150);
            this.labPass.Name = "labPass";
            this.labPass.Size = new System.Drawing.Size(104, 27);
            this.labPass.TabIndex = 2;
            this.labPass.Text = "Password";
            // 
            // txtUN
            // 
            this.txtUN.Location = new System.Drawing.Point(194, 80);
            this.txtUN.Name = "txtUN";
            this.txtUN.Size = new System.Drawing.Size(218, 35);
            this.txtUN.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(194, 147);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(218, 35);
            this.txtPass.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(300, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 32);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ckShowPass
            // 
            this.ckShowPass.AutoSize = true;
            this.ckShowPass.Location = new System.Drawing.Point(194, 193);
            this.ckShowPass.Name = "ckShowPass";
            this.ckShowPass.Size = new System.Drawing.Size(206, 31);
            this.ckShowPass.TabIndex = 7;
            this.ckShowPass.Text = "Hiển thị mật khẩu";
            this.ckShowPass.UseVisualStyleBackColor = true;
            this.ckShowPass.CheckedChanged += new System.EventHandler(this.ckShowPass_CheckedChanged);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 382);
            this.Controls.Add(this.ckShowPass);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUN);
            this.Controls.Add(this.labPass);
            this.Controls.Add(this.labUN);
            this.Controls.Add(this.labTitle);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmLogin";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label labUN;
        private System.Windows.Forms.Label labPass;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ckShowPass;
        public System.Windows.Forms.TextBox txtUN;
        public System.Windows.Forms.TextBox txtPass;
    }
}