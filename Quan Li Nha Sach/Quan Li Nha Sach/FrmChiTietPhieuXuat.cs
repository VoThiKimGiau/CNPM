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
    public partial class FrmChiTietPhieuXuat : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter sanPhamAdapter, phieuXuatAdapter;
        private DataTable sanPhamDataTable;
        private DataTable chiTietPhieuXuatDataTable;
        private string maPhieuXuat;
        private string maNhanVien;
        private string maKhachHang;
        private string ngayNhap;
        private decimal tongTien;

        public FrmChiTietPhieuXuat(SqlConnection connection, string maPhieuXuat, string maNhanVien, string maKhachHang, string ngayNhap, decimal tongTien)
        {
            this.connection = connection;
            this.maPhieuXuat = maPhieuXuat;
            this.maNhanVien = maNhanVien;
            this.maKhachHang = maKhachHang;
            this.ngayNhap = ngayNhap;
            this.tongTien = tongTien;
            InitializeComponent();
        }

        private void cbbMatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedProduct = (DataRowView)cbbMatHang.SelectedItem;

            if (selectedProduct != null)
            {
                string maSP = selectedProduct["MaSP"].ToString();
                LoadProductDetails(maSP);
            }
        }

        private void LoadProductDetails(string maSP)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            string query = $"SELECT GiaBan FROM SanPham WHERE MaSP = '{maSP}'";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    txtDonGiaNhap.Text = result.ToString();
                }

                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRowView selectedProduct = (DataRowView)cbbMatHang.SelectedItem;

            if (selectedProduct != null)
            {
                string maSP = selectedProduct["MaSP"].ToString();
                string tenSP = selectedProduct["TenSP"].ToString();
                int soLuong = int.Parse(txtSL.Text);
                decimal donGia = decimal.Parse(txtDonGiaNhap.Text);

                // Thêm vào DataTable
                DataRow newRow = chiTietPhieuXuatDataTable.NewRow();
                newRow["MaPhieuXuat"] = maPhieuXuat;
                newRow["MaSP"] = maSP;
                newRow["TenSP"] = tenSP;
                newRow["SoLuong"] = soLuong;
                newRow["DonGia"] = donGia;

                chiTietPhieuXuatDataTable.Rows.Add(newRow);

                CalculateTotalAmount();
            }
        }

        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void FrmChiTietPhieuXuat_Load(object sender, EventArgs e)
        {
            if (chiTietPhieuXuatDataTable == null)
            {
                chiTietPhieuXuatDataTable = new DataTable();

                chiTietPhieuXuatDataTable.Columns.Add("MaPhieuXuat", typeof(string));
                chiTietPhieuXuatDataTable.Columns.Add("MaSP", typeof(string));
                chiTietPhieuXuatDataTable.Columns.Add("TenSP", typeof(string));
                chiTietPhieuXuatDataTable.Columns.Add("SoLuong", typeof(int));
                chiTietPhieuXuatDataTable.Columns.Add("DonGia", typeof(decimal));
            }

            foreach (DataRow row in chiTietPhieuXuatDataTable.Rows)
            {
                row["MaPhieuNhap"] = maPhieuXuat;
            }

            dgvChiTietPhieuXuat.DataSource = chiTietPhieuXuatDataTable;
            LoadDataForComboBox(cbbMatHang, $"SELECT * FROM SanPham", "MaSP", "TenSP");

            LoadDataForPhieuXuat(maPhieuXuat);
        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataRow row in chiTietPhieuXuatDataTable.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);

                totalAmount += soLuong * donGia;
            }

            txtThanhTien.Text = totalAmount.ToString("N2");

            tongTien = totalAmount;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
                if (dgvChiTietPhieuXuat.SelectedRows.Count > 0)
                {
                    int selectedIndex = dgvChiTietPhieuXuat.SelectedRows[0].Index;
                    chiTietPhieuXuatDataTable.Rows.RemoveAt(selectedIndex);

                    CalculateTotalAmount();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
                }
        }

        private void LoadDataForComboBox(ComboBox comboBox, string query, string valueMember, string displayMember)
        {
            SqlDataAdapter comboAdapter = new SqlDataAdapter(query, connection);
            DataTable comboDataTable = new DataTable();
            comboAdapter.Fill(comboDataTable);

            comboBox.DataSource = comboDataTable;
            comboBox.ValueMember = valueMember;
            comboBox.DisplayMember = displayMember;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu vào cơ sở dữ liệu
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CTPX", connection))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = builder.GetInsertCommand();
                    adapter.Update(chiTietPhieuXuatDataTable);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }

        private void LoadDataForPhieuXuat(string maPhieuNhap)
        {
            string query = $"SELECT * FROM CTPX WHERE MaPhieuXuat = '{maPhieuXuat}'";

            SqlDataAdapter chiTietAdapter = new SqlDataAdapter(query, connection);
            chiTietPhieuXuatDataTable.Clear();
            chiTietAdapter.Fill(chiTietPhieuXuatDataTable);

            dgvChiTietPhieuXuat.DataSource = chiTietPhieuXuatDataTable;
            CalculateTotalAmount();
        }
    }
}
