using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Quan_Li_Nha_Sach
{

    public partial class frm_MenuChung : Form
    {

        public frm_MenuChung()
        {
            InitializeComponent();

        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            QuanLySanPham f = new QuanLySanPham();
            f.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmLogin f = new frmLogin();
            f.Show();
            this.Close();
        }

        private void btnK_Click(object sender, EventArgs e)
        {
            QuanLyKho f = new QuanLyKho();
            f.Show();
            this.Close();
        }

        private void frm_MenuChung_Load(object sender, EventArgs e)
        {
            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NB")
            {
                btnNK.Enabled = false;
                btnXK.Enabled = false;
                btnNV.Enabled = false;
                btnDT.Enabled = false;
                btnNCC.Enabled = false;
            }
            else if (id == "NK")
            {
                btnHD.Enabled = false;
                btnNV.Enabled = false;
                btnKH.Enabled = false;
                btnDT.Enabled = false;
            }
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            frmQuanLyHoaDon f = new frmQuanLyHoaDon();
            f.Show();
            this.Close();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            f.Show();
            this.Close();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang f = new frmQuanLyKhachHang();
            f.Show();
            this.Close();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            frmNCC f = new frmNCC();
            f.Show();
            this.Close();
        }

        private void btnNK_Click(object sender, EventArgs e)
        {
            FrmPhieuNhap f = new FrmPhieuNhap();
            f.Show();
            this.Close();
        }

        private void btnXK_Click(object sender, EventArgs e)
        {
            FrmPhieuXuat f = new FrmPhieuXuat();
            f.Show();
            this.Close();
        }

        private void btnDT_Click(object sender, EventArgs e)
        {
            frmThongKe f  = new frmThongKe();
            f.Show();
            this.Close();
        }
    }
}
