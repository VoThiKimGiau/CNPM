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
    public partial class frmQuanLyHoaDon : Form
    {
        SqlConnection connsql;
        SqlDataAdapter data;
        DBconnect db = new DBconnect();

        DataSet QL_NhaSach = new DataSet();
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
            connsql = db.getConnection();

        }


        public void load_DtGV_HoaDon()
        {
            QL_NhaSach = new DataSet();
            string selectStr = "select * from DonHang";
            data = new SqlDataAdapter(selectStr, connsql);
            data.Fill(QL_NhaSach, "DonHang");

            DataColumn[] key = new DataColumn[1];
            key[0] = QL_NhaSach.Tables["DonHang"].Columns["MaHD"];
            QL_NhaSach.Tables["DonHang"].PrimaryKey = key;

            dtGV_HoaDon.Columns["MaHD"].DataPropertyName = "MaDH";
            dtGV_HoaDon.Columns["MaNV"].DataPropertyName = "MaNV";
            dtGV_HoaDon.Columns["MaKH"].DataPropertyName = "MaKH";
            dtGV_HoaDon.Columns["NgayDat"].DataPropertyName = "NgayDat";
            dtGV_HoaDon.Columns["TongTien"].DataPropertyName = "TongTien";

            dtGV_HoaDon.DataSource = QL_NhaSach.Tables["DonHang"];
        }

        public void load_DtGV_CTHD()
        {
            string selectStr = "select * from ChiTietDH";
            data = new SqlDataAdapter(selectStr, connsql);
            data.Fill(QL_NhaSach, "ChiTietDH");

            DataColumn[] key = new DataColumn[3];
            key[0] = QL_NhaSach.Tables["ChiTietDH"].Columns["MaDH"];
            key[1] = QL_NhaSach.Tables["ChiTietDH"].Columns["MaSP"];
            QL_NhaSach.Tables["ChiTietDH"].PrimaryKey = key;

            dtGV_CTHD.Columns["MaHD_CTHD"].DataPropertyName = "MaDH";
            dtGV_CTHD.Columns["MaSP"].DataPropertyName = "MaSP";
            dtGV_CTHD.Columns["SoLuong"].DataPropertyName = "SoLuong";
            dtGV_CTHD.Columns["GiaBan"].DataPropertyName = "GiaBan";

            dtGV_CTHD.DataSource = QL_NhaSach.Tables["ChiTietDH"];
        }

        private void tinhTongDoanhThu()
        {

            decimal tongDoanhThu = 0;

            foreach (DataRow row in QL_NhaSach.Tables["DonHang"].Rows)
            {
                if (row["TongTien"] != DBNull.Value)
                {
                    decimal tongTien = Convert.ToDecimal(row["TongTien"]);
                    tongDoanhThu += tongTien;
                }
            }

            lb_TongDoanhThu.Text = tongDoanhThu.ToString("N0") + "đ";
        }



        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            load_DtGV_HoaDon();

            dtGV_HoaDon.ReadOnly = true;
            dtGV_CTHD.ReadOnly = true;

            dtGV_HoaDon.AllowUserToAddRows = false;
            dtGV_CTHD.AllowUserToAddRows = false;

            tinhTongDoanhThu();
            load_DtGV_CTHD();
        }

        private void loadDGV_CTHD(string maHD)
        {
            if (maHD != string.Empty)
            {
                DataTable dtTable = QL_NhaSach.Tables["ChiTietDH"];
                DataRow[] tableTheoMa = dtTable.Select("MaDH = '" + maHD + "'");
                if (tableTheoMa.Length == 0)
                {
                    dtGV_CTHD.DataSource = QL_NhaSach.Tables["ChiTietDH"];
                    return;
                }
                DataTable TableCopy = tableTheoMa.CopyToDataTable();
                dtGV_CTHD.DataSource = TableCopy;
            }
            else load_DtGV_HoaDon();
        }

        private void dtGV_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtGV_HoaDon.Rows[e.RowIndex];

                string maTK = selectedRow.Cells["MaHD"].Value.ToString();
                loadDGV_CTHD(maTK.Trim());
            }
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có Xoá hoá đơn cùng những chi tiết của hoá đơn đang được chọn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                if (dtGV_HoaDon.SelectedCells.Count > 0)
                {
                    try
                    {
                        // Thêm cột primary key
                        DataColumn primaryKeyColumn = QL_NhaSach.Tables["DonHang"].Columns["MaDH"];
                        QL_NhaSach.Tables["DonHang"].PrimaryKey = new DataColumn[] { primaryKeyColumn };

                        // Lấy ô đầu tiên được chọn
                        DataGridViewCell selectedCell = dtGV_HoaDon.SelectedCells[0];

                        // Lấy dòng tương ứng với chỉ số dòng
                        DataGridViewRow selectedRow = dtGV_HoaDon.Rows[selectedCell.RowIndex];

                        string maHD = selectedRow.Cells["MaHD"].Value.ToString();
                        //Xoá chi tiết hoá đơn trước
                        connsql.Open();
                        SqlCommand command = new SqlCommand("DELETE FROM ChiTietDH WHERE MaDH = @MaHD", connsql);
                        command.Parameters.AddWithValue("@MaHD", maHD);
                        command.ExecuteNonQuery();
                        // Cập nhật lại dtGV_CTHD
                        DataRow[] dataRow = QL_NhaSach.Tables["ChiTietDH"].Select("MaDH = '" + maHD + "'");
                        foreach (DataRow deleteRow in dataRow)
                        {
                            deleteRow.Delete();
                        }
                        QL_NhaSach.Tables["ChiTietDH"].AcceptChanges();
                        dtGV_CTHD.DataSource = QL_NhaSach.Tables["ChiTietDH"];

                        //Xoá Hoá đơn
                        command = new SqlCommand("DELETE FROM DonHang WHERE MaDH = @MaHD", connsql);
                        command.Parameters.AddWithValue("@MaHD", maHD);
                        command.ExecuteNonQuery();
                        QL_NhaSach.Tables["DonHang"].Rows.Find(maHD).Delete();
                        QL_NhaSach.Tables["DonHang"].AcceptChanges();
                        connsql.Close();
                        MessageBox.Show("Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                        connsql.Close();
                    }

                }
                else MessageBox.Show("Thất bại");
            }
        }




        private void btn_them_Click(object sender, EventArgs e)
        {
            TaoHD form2 = new TaoHD();
            //form2.FormClosed += Form2_FormClosed;
            form2.ShowDialog();

            load_DtGV_HoaDon();
            load_DtGV_CTHD();
            tinhTongDoanhThu();


            dtGV_HoaDon.FirstDisplayedScrollingRowIndex = dtGV_HoaDon.Rows.Count - 1;
            dtGV_CTHD.FirstDisplayedScrollingRowIndex = dtGV_CTHD.Rows.Count - 1;

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string searchMaDH = txt_search.Text;
            // Tạo một cột mới làm khóa chính
            DataColumn primaryKeyColumn = QL_NhaSach.Tables["DonHang"].Columns["MaDH"];
            QL_NhaSach.Tables["DonHang"].PrimaryKey = new DataColumn[] { primaryKeyColumn };



            DataRow[] foundRows = QL_NhaSach.Tables["DonHang"].Select("MaDH = '" + searchMaDH + "'");

            if (foundRows.Length > 0)
            {
                DataTable dtResult = QL_NhaSach.Tables["DonHang"].Clone();
                foreach (DataRow row in foundRows)
                {
                    dtResult.ImportRow(row);
                }

                dtGV_HoaDon.DataSource = dtResult;
            }
            else
            {
                dtGV_HoaDon.DataSource = null;
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
