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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace Quan_Li_Nha_Sach
{
    public partial class QuanLySanPham : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_sp;
        DataSet ds_sp;
        DataView dv_sp;
        DataColumn[] key = new DataColumn[1];
        DBconnect db = new DBconnect();
        public QuanLySanPham()
        {
            InitializeComponent();
            conn = db.getConnection();
            string strSelect = "select * from SanPham";
            da_sp = new SqlDataAdapter(strSelect, conn);
            ds_sp = new DataSet();
            da_sp.Fill(ds_sp, "SanPham");
            //them khoa chinh
            key[0] = ds_sp.Tables["SanPham"].Columns[0];
            ds_sp.Tables["SanPham"].PrimaryKey = key;

            //Search
            dv_sp = new DataView(ds_sp.Tables["SanPham"]);

            // Hiển thị dữ liệu ban đầu trên DataGridView
            dataGridView_SP.DataSource = dv_sp;

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NK")
            {
                btn_them.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
            }
        }
        public bool KT_KhoaChinh(string pMa)
        {
            conn.Open();
            string selectString = "select * from SanPham where MaSP ='" + pMa + "'";
            SqlCommand cmd = new SqlCommand(selectString, conn);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                rd.Close();
                conn.Close();
                return false;
            }
            else
            {
                rd.Close();
                conn.Close();
                return true;
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {

                if (txt_maSP.Text == string.Empty || txt_TenSP.Text == string.Empty ||
                    txt_Gia.Text == string.Empty || cbb_LoaiSP.Text == string.Empty ||
                    cbb_NCC.Text == string.Empty)
                {
                    MessageBox.Show("Phải nhập đầy đủ thông tin!");
                    return;
                }

                if (KT_KhoaChinh(txt_maSP.Text) == true)
                {
                    try
                    {
                        //Tao 1 dong du lieu moi
                        DataRow newrow = ds_sp.Tables[0].NewRow();
                        newrow["MaSP"] = txt_maSP.Text;
                        newrow["MaNCC"] = cbb_NCC.SelectedValue.ToString();
                        newrow["MaLoai"] = cbb_LoaiSP.SelectedValue.ToString();
                        newrow["GiaBan"] = txt_Gia.Text;
                        newrow["TenSP"] = txt_TenSP.Text;
                        // Them dong du lieu vua tao vao DataSet
                        ds_sp.Tables[0].Rows.Add(newrow);
                        // Cap nhat trong CSDL
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_sp);
                        // Cap nhat trong dataSet
                        da_sp.Update(ds_sp, "SanPham");

                        //Xoa textbox
                        txt_maSP.Clear();
                        cbb_NCC.Text = "";
                        cbb_LoaiSP.Text = "";
                        txt_Gia.Clear();
                        txt_TenSP.Clear();

                        MessageBox.Show("Thêm thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi dữ liệu!");
                    }
                }
                else
                {
                    MessageBox.Show("Trùng mã sản phẩm");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        void Load_ComboBox_LoaiSP()
        {
            DataSet ds = new DataSet();
            string strselect = "Select * from LoaiSP";
            SqlDataAdapter da = new SqlDataAdapter(strselect, conn);
            da.Fill(ds, "LoaiSP");
            cbb_LoaiSP.DataSource = ds.Tables[0];
            cbb_LoaiSP.DisplayMember = "TenLoai";
            cbb_LoaiSP.ValueMember = "MaLoai";
        }
        void Load_ComboBox_NCC()
        {
            DataSet ds = new DataSet();
            string strselect = "Select * from NCC";
            SqlDataAdapter da = new SqlDataAdapter(strselect, conn);
            da.Fill(ds, "NCC");
            cbb_NCC.DataSource = ds.Tables[0];
            cbb_NCC.DisplayMember = "TenNCC";
            cbb_NCC.ValueMember = "MaNCC";
        }
        void Load_SanPham()
        {
            dataGridView_SP.DataSource = ds_sp.Tables[0];
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            Load_ComboBox_LoaiSP();
            Load_ComboBox_NCC();
            Load_SanPham();
            dataGridView_SP.AllowUserToAddRows = true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn xóa?", "Thông báo",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button2) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow dr = ds_sp.Tables["SanPham"].Rows.Find(txt_maSP.Text);

                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    SqlCommandBuilder cB = new SqlCommandBuilder(da_sp);
                    da_sp.Update(ds_sp, "SanPham");

                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn sửa?", "Thông báo",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button2) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow dr = ds_sp.Tables["SanPham"].Rows.Find(txt_maSP.Text);

                    if (dr != null)
                    {
                        //dr["MaSP"] = txt_maSP.Text;
                        dr["MaNCC"] = cbb_NCC.SelectedValue.ToString();
                        dr["MaLoai"] = cbb_LoaiSP.SelectedValue.ToString();
                        dr["GiaBan"] = txt_Gia.Text;
                        dr["TenSP"] = txt_TenSP.Text;
                    }

                    SqlCommandBuilder cB = new SqlCommandBuilder(da_sp);
                    da_sp.Update(ds_sp, "SanPham");
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại!");
            }
        }
        private void dataGridView_SP_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView_SP.CurrentRow.Index;

            txt_maSP.Text = dataGridView_SP.Rows[i].Cells[0].Value.ToString();
            cbb_NCC.SelectedValue = dataGridView_SP.Rows[i].Cells[1].Value.ToString();
            cbb_LoaiSP.SelectedValue = dataGridView_SP.Rows[i].Cells[2].Value.ToString();
            txt_Gia.Text = dataGridView_SP.Rows[i].Cells[3].Value.ToString();
            txt_TenSP.Text = dataGridView_SP.Rows[i].Cells[4].Value.ToString();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text;
            // Khai bao DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            txt_Search.Clear();
            da = new SqlDataAdapter("Select MaSP, MaNCC, MaLoai, GiaBan, TenSP from SanPham where TenSP like N'%" + keyword + "%'", conn);
            //Do du lieu tu DataAdapter vao dataSet
            da.Fill(ds, "SanPham");

            //Gan du lieu nguon cho dataGridView
            dataGridView_SP.DataSource = ds.Tables["SanPham"];
        }

        private void txt_Gia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != 32 && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void txt_maSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_maSP.Text.Length >= 5 && e.KeyCode != Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txt_TenSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_maSP.Text.Length >= 200 && e.KeyCode != Keys.Back)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}
