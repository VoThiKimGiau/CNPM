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
    public partial class FrmChiTietPhieuNhap : Form
    {
        private SqlConnection connection;
        private SqlDataAdapter sanPhamAdapter, phieuNhapAdapter;
        private DataTable sanPhamDataTable;
        private DataTable chiTietPhieuNhapDataTable;
        private string maPhieuNhap;
        private string maNhanVien;
        private string maNhaCungCap;
        private string ngayNhap;
        private decimal tongTien;

        public FrmChiTietPhieuNhap(SqlConnection connection, string maPhieuNhap, string maNhanVien, string maNhaCungCap, string ngayNhap, decimal tongTien)
        {
            this.connection = connection;
            this.maPhieuNhap = maPhieuNhap;
            this.maNhanVien = maNhanVien;
            this.maNhaCungCap = maNhaCungCap;
            this.ngayNhap = ngayNhap;
            this.tongTien = tongTien;
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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


        private void txtDonGiaNhap_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();

        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalAmount();
        }

        private void dgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                DataRow newRow = chiTietPhieuNhapDataTable.NewRow();
                newRow["MaPhieuNhap"] = maPhieuNhap;
                newRow["MaSP"] = maSP;
                newRow["TenSP"] = tenSP;
                newRow["SoLuong"] = soLuong;
                newRow["DonGia"] = donGia;

                chiTietPhieuNhapDataTable.Rows.Add(newRow);

                CalculateTotalAmount();
            }
        }

        private void FrmChiTietPhieuNhap_Load(object sender, EventArgs e)
        {
            if (chiTietPhieuNhapDataTable == null)
            {
                chiTietPhieuNhapDataTable = new DataTable();

                chiTietPhieuNhapDataTable.Columns.Add("MaPhieuNhap", typeof(string));
                chiTietPhieuNhapDataTable.Columns.Add("MaSP", typeof(string));
                chiTietPhieuNhapDataTable.Columns.Add("TenSP", typeof(string));
                chiTietPhieuNhapDataTable.Columns.Add("SoLuong", typeof(int));
                chiTietPhieuNhapDataTable.Columns.Add("DonGia", typeof(decimal));
            }

            foreach (DataRow row in chiTietPhieuNhapDataTable.Rows)
            {
                row["MaPhieuNhap"] = maPhieuNhap;
            }

            dgvChiTietPhieuNhap.DataSource = chiTietPhieuNhapDataTable;
            LoadDataForComboBox(cbbMatHang, $"SELECT * FROM SanPham", "MaSP", "TenSP");

            LoadDataForPhieuNhap(maPhieuNhap);
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChiTietPhieuNhap.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvChiTietPhieuNhap.SelectedRows[0].Index;
                chiTietPhieuNhapDataTable.Rows.RemoveAt(selectedIndex);

                CalculateTotalAmount();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.");
            }
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;

            foreach (DataRow row in chiTietPhieuNhapDataTable.Rows)
            {
                int soLuong = Convert.ToInt32(row["SoLuong"]);
                decimal donGia = Convert.ToDecimal(row["DonGia"]);

                totalAmount += soLuong * donGia;
            }

            txtThanhTien.Text = totalAmount.ToString("N2");

            tongTien = totalAmount;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                // Lưu dữ liệu vào cơ sở dữ liệu
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CTPN", connection))
                {
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.InsertCommand = builder.GetInsertCommand();
                    adapter.Update(chiTietPhieuNhapDataTable);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message);
            }
        }

        private void LoadDataForPhieuNhap(string maPhieuNhap)
        {
            // Thực hiện truy vấn để lấy dữ liệu của phiếu nhập từ cơ sở dữ liệu
            string query = $"SELECT * FROM CTPN WHERE MaPhieuNhap = '{maPhieuNhap}'";

            SqlDataAdapter chiTietAdapter = new SqlDataAdapter(query, connection);
            chiTietPhieuNhapDataTable.Clear();
            chiTietAdapter.Fill(chiTietPhieuNhapDataTable);

            dgvChiTietPhieuNhap.DataSource = chiTietPhieuNhapDataTable;
            CalculateTotalAmount(); // Cập nhật tổng tiền sau khi load dữ liệu
        }
    }
}