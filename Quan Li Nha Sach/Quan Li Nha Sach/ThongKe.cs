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

namespace Quan_Li_Nha_Sach
{
    public partial class frmThongKe : Form
    {
        SqlConnection connsql;
        DBconnect cn = new DBconnect();
        DataSet QL_NhaSach = new DataSet();
        SqlDataAdapter data;
        public frmThongKe()
        {
            InitializeComponent();
            connsql = cn.getConnection();
        }

        private void load_DGV_ThongKeSP()
        {
            //QL_NhaSach = new DataSet();
            string querySelect = "SELECT SP.MaSP, TenSP, TenLoai, SP.GiaBan, SUM(SOLUONG) AS 'SLMua', TongTien FROM SanPham SP, LoaiSP L, ChiTietDH CT, DonHang DH WHERE SP.MaLoai = L.MaLoai AND CT.MaSP = SP.MaSP AND CT.MaDH = DH.MaDH GROUP BY SP.MaSP, TenSP, TenLoai, SP.GiaBan, TongTien";
            data = new SqlDataAdapter(querySelect, connsql);
            data.Fill(QL_NhaSach, "ThongKeSP");
            DataColumn[] key = new DataColumn[1];
            key[0] = QL_NhaSach.Tables["ThongKeSP"].Columns["MaHD"];
            QL_NhaSach.Tables["ThongKeSP"].PrimaryKey = key;

            dtGV_ThongKeSP.Columns["MaSP"].DataPropertyName = "MaSP";
            dtGV_ThongKeSP.Columns["TenSP"].DataPropertyName = "TenSP";
            dtGV_ThongKeSP.Columns["TenLoai"].DataPropertyName = "TenLoai";
            dtGV_ThongKeSP.Columns["GiaBan"].DataPropertyName = "GiaBan";
            dtGV_ThongKeSP.Columns["DaBan"].DataPropertyName = "SLMua";
            dtGV_ThongKeSP.Columns["TongTien"].DataPropertyName = "TongTien";

            dtGV_ThongKeSP.DataSource = QL_NhaSach.Tables["ThongKeSP"];

        }

        private void load_DGV_ThongKeDH()
        {
            //QL_NhaSach = new DataSet();
            string querySelect = "select MaDH, TenNV, TenKH, NgayDat, TongTien from DonHang DH, NhanVien NV, KhachHang KH WHERE DH.MaNV = NV.MaNV AND DH.MaKH = KH.MaKH";
            data = new SqlDataAdapter(querySelect, connsql);
            data.Fill(QL_NhaSach, "ThongKeDH");
            DataColumn[] key = new DataColumn[1];
            key[0] = QL_NhaSach.Tables["ThongKeDH"].Columns["MaDH"];
            QL_NhaSach.Tables["ThongKeDH"].PrimaryKey = key;

            dtGV_ThongKeDH.Columns["MaDH"].DataPropertyName = "MaDH";
            dtGV_ThongKeDH.Columns["TenNV"].DataPropertyName = "TenNV";
            dtGV_ThongKeDH.Columns["TenKH"].DataPropertyName = "TenKH";
            dtGV_ThongKeDH.Columns["NgayDat"].DataPropertyName = "NgayDat";
            dtGV_ThongKeDH.Columns["TongTienDH"].DataPropertyName = "TongTien";

            dtGV_ThongKeDH.DataSource = QL_NhaSach.Tables["ThongKeDH"];

        }

        private void load_DGV_ThongKeCTDH()
        {
            //QL_NhaSach = new DataSet();
            string querySelect = "select * from ChiTietDH";
            data = new SqlDataAdapter(querySelect, connsql);
            data.Fill(QL_NhaSach, "ChiTietDH");
            DataColumn[] key = new DataColumn[2];
            key[0] = QL_NhaSach.Tables["ChiTietDH"].Columns["MaDH"];
            key[1] = QL_NhaSach.Tables["ChiTietDH"].Columns["MaSP"];
            QL_NhaSach.Tables["ChiTietDH"].PrimaryKey = key;

            dtGV_ThongKeCTDH.Columns["MaDH_CTDH"].DataPropertyName = "MaDH";
            dtGV_ThongKeCTDH.Columns["MaSP_CTDH"].DataPropertyName = "MaSP";
            dtGV_ThongKeCTDH.Columns["SoLuong"].DataPropertyName = "SoLuong";
            dtGV_ThongKeCTDH.Columns["GiaBan_CTDH"].DataPropertyName = "GiaBan";

            dtGV_ThongKeCTDH.DataSource = QL_NhaSach.Tables["ChiTietDH"];

        }

        private void tinhTongDoanhThu()
        {
            double tongDT = 0;
            string s;
            foreach (DataGridViewRow row in dtGV_ThongKeDH.Rows)
            {
                s = row.Cells["TongTienDH"].Value.ToString();
                if (s != string.Empty)
                {
                    tongDT += double.Parse(s);
                }
            }

            lb_TongDoanhThu.Text = tongDT.ToString() + "đ";
        }

        private void load_Cbo_TinhTrang()
        {
            string[] listTT = { "Đã Bán", "Chưa Bán" };
            cbo_TinhTrang.DataSource = listTT;
            cbo_TinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void load_Cbo_TimKiem()
        {
            List<CboTimKiem> cbo = new List<CboTimKiem>();
            cbo.Add(new CboTimKiem("Mã Đơn Hàng", "MaDH"));
            cbo.Add(new CboTimKiem("Tên Nhân Viên", "TenNV"));
            cbo.Add(new CboTimKiem("Tên Khách Hàng", "TenKH"));
            cbo.Add(new CboTimKiem("Ngày Đặt", "NgayDat"));

            cbo_TimKiem.DisplayMember = "Text";
            cbo_TimKiem.ValueMember = "Name";
            cbo_TimKiem.DataSource = cbo;
            cbo_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void load_Cbo_TimKiemSP()
        {
            List<CboTimKiem> cbo = new List<CboTimKiem>();
            cbo.Add(new CboTimKiem("Mã Sản Phẩm", "MaSP"));
            cbo.Add(new CboTimKiem("Tên Sản Phẩm", "TenSP"));

            cboTimKiemSP.DisplayMember = "Text";
            cboTimKiemSP.ValueMember = "Name";
            cboTimKiemSP.DataSource = cbo;
            cboTimKiemSP.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            load_DGV_ThongKeSP();
            load_DGV_ThongKeDH();
            load_DGV_ThongKeCTDH();

            load_Cbo_TinhTrang();
            load_Cbo_TimKiem();
            load_Cbo_TimKiemSP();

            dtGV_ThongKeSP.ReadOnly = true;
            dtGV_ThongKeDH.ReadOnly = true;
            dtGV_ThongKeCTDH.ReadOnly = true;

            dtGV_ThongKeSP.AllowUserToAddRows = false;
            dtGV_ThongKeDH.AllowUserToAddRows = false;
            dtGV_ThongKeCTDH.AllowUserToAddRows = false;

            tinhTongDoanhThu();
        }

        private void load_DGV_ThongKeCTDH(string maDH)
        {
            if (maDH != string.Empty)
            {
                DataTable dtTable = QL_NhaSach.Tables["ChiTietDH"];
                DataRow[] tableTheoMa = dtTable.Select("MaDH = '" + maDH + "'");
                if (tableTheoMa.Length == 0)
                {
                    dtGV_ThongKeCTDH.DataSource = QL_NhaSach.Tables["ChiTietDH"];
                    return;
                }
                DataTable TableCopy = tableTheoMa.CopyToDataTable();
                dtGV_ThongKeCTDH.DataSource = TableCopy;
            }
            else load_DGV_ThongKeCTDH();
        }

        private void dtGV_ThongKeDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtGV_ThongKeDH.Rows[e.RowIndex];
                string maDH = selectedRow.Cells["MaDH"].Value.ToString();
                load_DGV_ThongKeCTDH(maDH.Trim());
            }
        }

        private void load_DGV_ThongKeSP_ChuaBan()
        {
            //QL_NhaSach = new DataSet();
            string querySelect = "SELECT SP.MaSP, TenSP, TenLoai, SP.GiaBan FROM SanPham SP, LoaiSP L WHERE SP.MaLoai = L.MaLoai AND SP.MaSP NOT IN (SELECT SP.MaSP FROM SanPham SP, LoaiSP L, ChiTietDH CT, DonHang DH WHERE SP.MaLoai = L.MaLoai AND CT.MaSP = SP.MaSP AND CT.MaDH = DH.MaDH GROUP BY SP.MaSP, TenSP, TenLoai, SP.GiaBan, TongTien)";
            data = new SqlDataAdapter(querySelect, connsql);
            data.Fill(QL_NhaSach, "ThongKeSPChuaBan");
            DataColumn[] key = new DataColumn[1];
            key[0] = QL_NhaSach.Tables["ThongKeSPChuaBan"].Columns["MaDH"];
            QL_NhaSach.Tables["ThongKeSPChuaBan"].PrimaryKey = key;

            dtGV_ThongKeSP.Columns["MaSP"].DataPropertyName = "MaSP";
            dtGV_ThongKeSP.Columns["TenSP"].DataPropertyName = "TenSP";
            dtGV_ThongKeSP.Columns["TenLoai"].DataPropertyName = "TenLoai";
            dtGV_ThongKeSP.Columns["GiaBan"].DataPropertyName = "GiaBan";
            dtGV_ThongKeSP.Columns["DaBan"].Visible = false;
            dtGV_ThongKeSP.Columns["TongTien"].Visible = false;

            dtGV_ThongKeSP.DataSource = QL_NhaSach.Tables["ThongKeSPChuaBan"];

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Đã Bán";
            column1.Name = "DaBan";

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Tổng Tiền";
            column2.Name = "TongTien";

            dtGV_ThongKeSP.Columns.Add(column1);
            dtGV_ThongKeSP.Columns.Add(column2);
        }

        private void cbo_TinhTrang_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbo_TinhTrang.SelectedIndex == 0)
                load_DGV_ThongKeSP();
            else load_DGV_ThongKeSP_ChuaBan();
        }

        private void load_DGV_ThongKeDH(string danhMuc, string chuoiTimKiem)
        {
            if (chuoiTimKiem == string.Empty)
            {
                dtGV_ThongKeDH.DataSource = QL_NhaSach.Tables["ThongKeDH"]; ;
                return;
            }

            DataTable dtTable = QL_NhaSach.Tables["ThongKeDH"];
            DataTable filteredTable = dtTable.Clone();

            foreach (DataRow row in dtTable.Rows)
            {
                if (row[danhMuc].ToString().Contains(chuoiTimKiem))
                {
                    filteredTable.ImportRow(row);
                }
            }

            dtGV_ThongKeDH.DataSource = filteredTable;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            load_DGV_ThongKeDH(cbo_TimKiem.SelectedValue.ToString(), txtTimKiem.Text);
        }

        private void load_DGV_ThongKeSP(DataTable table, string danhMuc, string chuoiTimKiem)
        {
            if (chuoiTimKiem == string.Empty)
            {
                dtGV_ThongKeSP.DataSource = table;
                return;
            }

            DataTable dtTable = table;
            DataTable filteredTable = dtTable.Clone();

            foreach (DataRow row in dtTable.Rows)
            {
                if (row[danhMuc].ToString().Contains(chuoiTimKiem))
                {
                    filteredTable.ImportRow(row);
                }
            }

            dtGV_ThongKeSP.DataSource = filteredTable;
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            if (cbo_TinhTrang.SelectedIndex == 0)
                load_DGV_ThongKeSP(QL_NhaSach.Tables["ThongKeSP"], cboTimKiemSP.SelectedValue.ToString(), txtTimKiemSP.Text);
            else load_DGV_ThongKeSP(QL_NhaSach.Tables["ThongKeSPChuaBan"], cboTimKiemSP.SelectedValue.ToString(), txtTimKiemSP.Text);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}
