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
    public partial class TaoHD : Form
    {
        public TaoHD()
        {
            InitializeComponent();

            txt_catrucNV.Enabled = false;
            txt_ngay.Enabled = false;

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "QL")
                txt_ngay.Enabled = true;
        }

        bool xong = false;
        void hienthi_SP_cbo()
        {
            DBconnect db = new DBconnect();
            string chuoitruyvan = "select * from SanPham";
            DataTable dt = db.getDataTable(chuoitruyvan);

            cbo_sp.DataSource = dt;
            cbo_sp.DisplayMember = "TenSP";
            cbo_sp.ValueMember = "MaSP";

            xong = true;
        }
        void hienthi_NV_cbo()
        {
            DBconnect db = new DBconnect();
            string chuoitruyvan = "SELECT * FROM NhanVien WHERE MaNV LIKE 'NB%' OR MaNV LIKE 'QL%'";
            DataTable dt = db.getDataTable(chuoitruyvan);

            cbo_nv.DataSource = dt;
            cbo_nv.DisplayMember = "TenNV";
            cbo_nv.ValueMember = "MaNV";
        }
     


        void khoitaiGVD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaSP");
            dt.Columns.Add("TenSP");
            dt.Columns.Add("SOLUONG");

            dt.Columns.Add("GiaBan");
            dt.Columns.Add("THANHTIEN");

            // Tạo cột kiểu nút
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "Actions";
            buttonColumn.Name = "Xoa";
            buttonColumn.Text = "Xóa";
            buttonColumn.UseColumnTextForButtonValue = true;


            // Thêm cột vào DataGridView
            gvd_DSSP.Columns.Add(buttonColumn);

            gvd_DSSP.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hienthi_SP_cbo();
            hienthi_NV_cbo();
            txt_ngay.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);

            khoitaiGVD();

        }

        private void cbo_sp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(xong==true)
            {
                DBconnect db = new DBconnect();
                string selectedMaSP = cbo_sp.SelectedValue.ToString(); // Chuyển đổi giá trị MaSP sang kiểu chuỗi

                string chuoitruyvan = "SELECT * FROM SanPham WHERE MaSP = '" + selectedMaSP + "'";
                DataTable dt = db.getDataTable(chuoitruyvan);

                txt_tensp.Text = dt.Rows[0]["TenSP"].ToString();
                txt_dgia.Text = dt.Rows[0]["GiaBan"].ToString();
            }
        }

      
        double TongTien()
        {
            double tong = 0;
            for (int i = 0; i < gvd_DSSP.Rows.Count - 1; i++)
                tong = tong + double.Parse(gvd_DSSP.Rows[i].Cells["THANHTIEN"].Value.ToString());
            return tong;
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gvd_DSSP.DataSource;

            DataRow dr = dt.NewRow();
            dr["MaSP"] = cbo_sp.SelectedValue;
            dr["TenSP"] = txt_tensp.Text;
            
            dr["GiaBan"] = txt_dgia.Text;
            dr["SOLUONG"] = txt_sl.Text;

            dr["THANHTIEN"] = double.Parse(txt_dgia.Text) * double.Parse(txt_sl.Text);

            dt.Rows.Add(dr);
            txt_TTgvd.Text = TongTien().ToString();


            txt_thanhtien.Text = TongTien().ToString("N0") + "đ";
            //txt_thanhtien.Text = TongTien().ToString();

        }



        private string GenerateMaDH()
        {
            // Thực hiện truy vấn để lấy số lượng MaDH hiện có trong cơ sở dữ liệu
            string query = "SELECT COUNT(*) FROM DonHang";
            DBconnect db = new DBconnect();
            int count = (int)db.getScalar(query);
            // Tạo MaDH mới bằng cách kết hợp "DH" với số lượng hiện có
            string newMaDH = "DH" + (count + 1).ToString("D3");

            return newMaDH;
        }
    
        private void btn_taohd_Click(object sender, EventArgs e)
        {

            string mnv = cbo_nv.SelectedValue.ToString();
            //string mkh = cho_KH.SelectedValue.ToString();
            string mkh = txt_maKH.Text;


            string nht = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
            string chuoitv = "INSERT INTO DonHang (MaDH, MaNV, MaKH, NgayDat, TongTien) VALUES (@MaDH, @MaNV, @MaKH, @NgayTao, @ThanhTien)";

            DBconnect db = new DBconnect();
            SqlCommand cmd = new SqlCommand(chuoitv, db.getConnection());

            string mdh = GenerateMaDH(); // Lấy MaDH mới

            cmd.Parameters.AddWithValue("@MaDH", mdh);
            cmd.Parameters.AddWithValue("@MaNV", mnv);
            cmd.Parameters.AddWithValue("@MaKH", mkh);
            cmd.Parameters.AddWithValue("@NgayTao", nht);
            cmd.Parameters.AddWithValue("@ThanhTien", txt_TTgvd.Text);

            try
            {
                db.Open();
                cmd.ExecuteNonQuery();
                db.Close();
                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm đơn hàng thành công!");

                // Hoặc in thông báo ra console
                Console.WriteLine("Thêm đơn hàng thành công!");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi thực thi câu lệnh SQL
                Console.WriteLine("Lỗi: " + ex.Message);
            }

            DataTable dt = (DataTable)gvd_DSSP.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string msp = dt.Rows[i]["MaSP"].ToString();
                string sl = dt.Rows[i]["SoLuong"].ToString();
                string chuoitv2 = "INSERT INTO ChiTietDH (MaDH, MaSP, SoLuong) VALUES (@MaDH, @MaSP, @SoLuong)";

                SqlCommand cmd2 = new SqlCommand(chuoitv2, db.getConnection());
                cmd2.Parameters.AddWithValue("@MaDH", mdh);
                cmd2.Parameters.AddWithValue("@MaSP", msp);
                cmd2.Parameters.AddWithValue("@SoLuong", sl);

                db.Open();
                cmd2.ExecuteNonQuery();
                db.Close();
            }

        }

       

        private void cbo_nv_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBconnect db = new DBconnect();
            string selectedMaSP = cbo_nv.SelectedValue.ToString(); // Chuyển đổi giá trị MaSP sang kiểu chuỗi
           
            string chuoitruyvan = "SELECT * FROM NhanVien WHERE MaNV = '" + selectedMaSP + "'";
            DataTable dt = db.getDataTable(chuoitruyvan);

            if (dt.Rows.Count > 0)
            {
                // Truy cập vào dòng đầu tiên (dòng 0)
                DataRow firstRow = dt.Rows[0];

                string tenNV = firstRow["TenNV"].ToString();

                // Gán giá trị vào TextBox
                txt_catrucNV.Text = tenNV;
            }
            else
            {
                // Không có dữ liệu
                Console.WriteLine("Không có dữ liệu.");
            }
        }

      

        private void txt_dt_Leave(object sender, EventArgs e)
        {
            DBconnect db = new DBconnect();
            string selectedSoDienThoai = txt_dt.Text;

            string chuoitruyvan = "SELECT * FROM KhachHang WHERE SDT = '" + selectedSoDienThoai + "'";
            DataTable dt = db.getDataTable(chuoitruyvan);

            if (dt.Rows.Count > 0)
            {
                txt_tenKH.Text = dt.Rows[0]["TenKH"].ToString();
                txt_diachi.Text = dt.Rows[0]["DiaChi"].ToString();
                txt_maKH.Text = dt.Rows[0]["MaKH"].ToString();
            }
            else
            {
                MessageBox.Show("Khách hàng không tồn tại. Vui lòng tạo khách hàng mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Chuyển hướng đến form tạo khách hàng
                frmQuanLyKhachHang formTaoKhachHang = new frmQuanLyKhachHang();
                formTaoKhachHang.ShowDialog();

                // Đóng form hiện tại nếu cần
                this.Hide();
            }
        }

        private void gvd_DSSP_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gvd_DSSP.Columns["SOLUONG"].Index)
            {
                DataGridViewRow row = gvd_DSSP.Rows[e.RowIndex];
                double giaBan = Convert.ToDouble(row.Cells["GiaBan"].Value);
                int soLuong = Convert.ToInt32(row.Cells["SOLUONG"].Value);
                double thanhTien = giaBan * soLuong;
                row.Cells["THANHTIEN"].Value = thanhTien;

                txt_TTgvd.Text = TongTien().ToString("N0") + "đ";
                txt_thanhtien.Text = TongTien().ToString("N0") + "đ";
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {

        }

        private void gvd_DSSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvd_DSSP.Columns[e.ColumnIndex].Name == "Xoa")
            {
                if (e.RowIndex >= 0)
                {
                    DialogResult r = MessageBox.Show("Bạn có muốn xóa sản phẩm này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                    if (r == DialogResult.Yes)
                    {
                        gvd_DSSP.Rows.RemoveAt(e.RowIndex);
                        // Xử lý các hành động khác sau khi xóa dòng
                    }
                }
            }
        }

       
    }
}
