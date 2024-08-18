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
    public partial class FrmPhieuXuat : Form
    {
        DBconnect db = new DBconnect();
        private decimal tongTien;
        private SqlConnection connection;

        private SqlDataAdapter phieuXuatAdapter;
        private SqlDataAdapter nhanVienAdapter;
        private SqlDataAdapter khachHangAdapter;
        private DataSet dataSet;
        private string maPhieuXuat;

        public FrmPhieuXuat()
        {
            connection = db.getConnection();

            string query = "SELECT * FROM PhieuXuat";
            InitializeComponent();

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NK")
            {
                mtbNgayXuat.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuXuat.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu xuất.");
                return;
            }

            string maPhieuXuat = txtMaPhieuXuat.Text;
            string maNhanVien = cbbNhanVienNhap.SelectedValue.ToString();
            string maKhachHang = cbbKhachHang.SelectedValue.ToString();
            string ngayNhap = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "INSERT INTO PhieuXuat (MaPhieuXuat, MaNV, MaKH, NgayLap) VALUES (@MaPhieuXuat, @MaNV, @MaKH, @NgayLap)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieuXuat", maPhieuXuat);
                    command.Parameters.AddWithValue("@MaNV", maNhanVien);
                    command.Parameters.AddWithValue("@MaKH", maKhachHang);
                    command.Parameters.AddWithValue("@NgayLap", ngayNhap);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm phiếu xuát thành công.");
                }

                FrmChiTietPhieuXuat frmChiTiet = new FrmChiTietPhieuXuat(connection, maPhieuXuat, maNhanVien, maKhachHang, ngayNhap, tongTien);
                frmChiTiet.ShowDialog();

                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }

        private void FrmPhieuXuat_Load(object sender, EventArgs e)
        {

        }

        private void FrmPhieuNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
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

        private void RefreshDataGridView()
        {
            dataSet.Tables["PhieuXuat"].Clear();

            phieuXuatAdapter.Fill(dataSet, "PhieuNhap");
            dgvHoaDonNhap.DataSource = dataSet.Tables["PhieuNhap"];
        }

        private void txtMaPhieuXuat_TextChanged(object sender, EventArgs e)
        {
            maPhieuXuat = txtMaPhieuXuat.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvHoaDonNhap.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvHoaDonNhap.SelectedRows[0].Index;
                string maPhieuXuatCanXoa = dgvHoaDonNhap.Rows[selectedIndex].Cells["MaPhieuXuat"].Value.ToString();

                // Xóa chi tiết phiếu nhập trước
                string deleteChiTietQuery = $"DELETE FROM CTPX WHERE MaPhieuXuat = '{maPhieuXuatCanXoa}'";

                try
                {
                    using (SqlCommand deleteChiTietCommand = new SqlCommand(deleteChiTietQuery, connection))
                    {
                        connection.Open();
                        deleteChiTietCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa chi tiết phiếu nhập: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }

                // Sau khi xóa chi tiết, bạn có thể xóa phiếu nhập
                string deletePhieuNhapQuery = $"DELETE FROM PhieuXuat WHERE MaPhieuXuat = '{maPhieuXuatCanXoa}'";

                try
                {
                    using (SqlCommand deletePhieuNhapCommand = new SqlCommand(deletePhieuNhapQuery, connection))
                    {
                        connection.Open();
                        deletePhieuNhapCommand.ExecuteNonQuery();
                        MessageBox.Show("Xóa phiếu xuất thành công.");
                        RefreshDataGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa phiếu nhập: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu nhập để xóa.");
            }
        }

        private void FrmPhieuXuat_Load_1(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Open();
            }

            phieuXuatAdapter = new SqlDataAdapter("SELECT * FROM PhieuXuat", connection);
            nhanVienAdapter = new SqlDataAdapter("SELECT MaNV, TenNV FROM NhanVien", connection);
            khachHangAdapter = new SqlDataAdapter("SELECT * FROM KhachHang", connection);

            dataSet = new DataSet();
            phieuXuatAdapter.Fill(dataSet, "PhieuXuat");
            nhanVienAdapter.Fill(dataSet, "NhanVien");

            LoadDataForComboBox(cbbKhachHang, "SELECT * FROM KhachHang", "MaKH", "TenKH");

            dgvHoaDonNhap.DataSource = dataSet.Tables["PhieuXuat"];

            cbbNhanVienNhap.DataSource = dataSet.Tables["NhanVien"];
            cbbNhanVienNhap.DisplayMember = "TenNV";
            cbbNhanVienNhap.ValueMember = "MaNV";

            mtbNgayXuat.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}
