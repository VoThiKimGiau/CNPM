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

    public partial class FrmPhieuNhap : Form
    {
        private decimal tongTien;
        private SqlConnection connection;
        private SqlDataAdapter phieuNhapAdapter;
        private SqlDataAdapter nhanVienAdapter;
        private SqlDataAdapter nhaCungCapAdapter;
        private DataSet dataSet;
        private string maPhieuNhap;
        DBconnect db = new DBconnect();

        public FrmPhieuNhap()
        {
            connection = db.getConnection();

            string query = "SELECT * FROM PhieuNhap";

            InitializeComponent();

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NK")
            {
                mtbNgayNhap.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieuNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu nhập.");
                return;
            }

            string maPhieuNhap = txtMaPhieuNhap.Text;
            string maNhanVien = cbbNhanVienNhap.SelectedValue.ToString();
            string maNhaCungCap = cbbNhaCungCap.SelectedValue.ToString();
            string ngayNhap = DateTime.Now.ToString("yyyy-MM-dd");
            string query = "INSERT INTO PhieuNhap (MaPhieuNhap, MaNV, MaNCC, NgayLap) VALUES (@MaPhieuNhap, @MaNV, @MaNCC, @NgayLap)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);
                    command.Parameters.AddWithValue("@MaNV", maNhanVien);
                    command.Parameters.AddWithValue("@MaNCC", maNhaCungCap);
                    command.Parameters.AddWithValue("@NgayLap", ngayNhap);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Thêm phiếu nhập thành công.");
                }

                FrmChiTietPhieuNhap frmChiTiet = new FrmChiTietPhieuNhap(connection, maPhieuNhap, maNhanVien, maNhaCungCap, ngayNhap, tongTien);
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

        private void FrmPhieuNhap_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Open();
            }

            phieuNhapAdapter = new SqlDataAdapter("SELECT * FROM PhieuNhap", connection);
            nhanVienAdapter = new SqlDataAdapter("SELECT MaNV, TenNV FROM NhanVien", connection);
            nhaCungCapAdapter = new SqlDataAdapter("SELECT * FROM NCC", connection);

            dataSet = new DataSet();
            phieuNhapAdapter.Fill(dataSet, "PhieuNhap");
            nhanVienAdapter.Fill(dataSet, "NhanVien");

            LoadDataForComboBox(cbbNhaCungCap, "SELECT * FROM NCC", "MaNCC", "TenNCC");

            dgvHoaDonXuat.DataSource = dataSet.Tables["PhieuNhap"];

            cbbNhanVienNhap.DataSource = dataSet.Tables["NhanVien"];
            cbbNhanVienNhap.DisplayMember = "TenNV";
            cbbNhanVienNhap.ValueMember = "MaNV";

            mtbNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            dataSet.Tables["PhieuNhap"].Clear();

            phieuNhapAdapter.Fill(dataSet, "PhieuNhap");
            dgvHoaDonXuat.DataSource = dataSet.Tables["PhieuNhap"];
        }

        private void txtMaPhieuNhap_TextChanged(object sender, EventArgs e)
        {
            maPhieuNhap = txtMaPhieuNhap.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvHoaDonXuat.SelectedRows.Count > 0)
            {
                int selectedIndex = dgvHoaDonXuat.SelectedRows[0].Index;
                string maPhieuNhapCanXoa = dgvHoaDonXuat.Rows[selectedIndex].Cells["MaPhieuNhap"].Value.ToString();

                // Xóa chi tiết phiếu nhập trước
                string deleteChiTietQuery = $"DELETE FROM CTPN WHERE MaPhieuNhap = '{maPhieuNhapCanXoa}'";

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
                string deletePhieuNhapQuery = $"DELETE FROM PhieuNhap WHERE MaPhieuNhap = '{maPhieuNhapCanXoa}'";

                try
                {
                    using (SqlCommand deletePhieuNhapCommand = new SqlCommand(deletePhieuNhapQuery, connection))
                    {
                        connection.Open();
                        deletePhieuNhapCommand.ExecuteNonQuery();
                        MessageBox.Show("Xóa phiếu nhập thành công.");
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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}