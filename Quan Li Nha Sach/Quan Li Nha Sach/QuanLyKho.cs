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
    public partial class QuanLyKho : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_k;
        DataSet ds_sp;
        DataView dv_sp; //Search
        DataColumn[] key = new DataColumn[1];
        DBconnect db = new DBconnect();
        public QuanLyKho()
        {
            InitializeComponent();
            conn = db.getConnection();
            string strSelect = "select * from Kho";
            da_k = new SqlDataAdapter(strSelect, conn);
            ds_sp = new DataSet();
            da_k.Fill(ds_sp, "Kho");
            //them khoa chinh
            key[0] = ds_sp.Tables["Kho"].Columns[0];
            ds_sp.Tables["Kho"].PrimaryKey = key;

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NB")
            {
                btn_Sua.Enabled = false;
                btn_them.Enabled = false;
                btn_Xoa.Enabled = false;
            }
        }
        public bool KT_KhoaChinh(string pMa)
        {
            conn.Open();
            string selectString = "select * from Kho where MaSP ='" + pMa + "'";
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
        void Load_ComboBox_SanPham()
        {
            DataSet ds = new DataSet();
            string strselect = "Select * from SanPham";
            SqlDataAdapter da = new SqlDataAdapter(strselect, conn);
            da.Fill(ds, "SanPham");
            cbb_MaSP.DataSource = ds.Tables[0];
            cbb_MaSP.DisplayMember = "TenSP";
            cbb_MaSP.ValueMember = "MaSP";
        }
        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            Load_ComboBox_SanPham();
            dataGridView_Kho.DataSource = ds_sp.Tables[0];
            dv_sp = new DataView(ds_sp.Tables[0]); // Show Tìm kiếm
            dataGridView_Kho.AllowUserToAddRows = true;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbb_MaSP.SelectedValue.ToString() == string.Empty || txt_SLK.Text == string.Empty)
                {
                    MessageBox.Show("Phải nhập đầy đủ thông tin!");
                    return;
                }

                if (KT_KhoaChinh(cbb_MaSP.SelectedValue.ToString()) == true)
                {
                    try
                    {
                        //Tao 1 dong du lieu moi
                        DataRow newrow = ds_sp.Tables[0].NewRow();
                        newrow["MaSP"] = cbb_MaSP.SelectedValue.ToString();
                        newrow["SLKho"] = txt_SLK.Text;
                        // Them dong du lieu vua tao vao DataSet
                        ds_sp.Tables[0].Rows.Add(newrow);
                        // Cap nhat trong CSDL
                        SqlCommandBuilder cB = new SqlCommandBuilder(da_k);
                        // Cap nhat trong dataSet
                        da_k.Update(ds_sp, "Kho");

                        //xoa textbox
                        txt_SLK.Clear();
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

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn sửa?", "Thông báo",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                     MessageBoxDefaultButton.Button2) ==
                    System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow dr = ds_sp.Tables["Kho"].Rows.Find(cbb_MaSP.SelectedValue.ToString());

                    if (dr != null)
                    {
                        dr["SLKho"] = txt_SLK.Text;
                    }

                    SqlCommandBuilder cB = new SqlCommandBuilder(da_k);
                    da_k.Update(ds_sp, "Kho");
                    MessageBox.Show("Sửa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại!");
            }
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
                    DataRow dr = ds_sp.Tables["Kho"].Rows.Find(cbb_MaSP.SelectedValue.ToString());

                    if (dr != null)
                    {
                        dr.Delete();
                    }

                    SqlCommandBuilder cB = new SqlCommandBuilder(da_k);
                    da_k.Update(ds_sp, "Kho");

                    MessageBox.Show("Xóa thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!");
            }
        }

        private void dataGridView_Kho_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int i = dataGridView_Kho.CurrentRow.Index;

            cbb_MaSP.SelectedValue = dataGridView_Kho.Rows[i].Cells[0].Value.ToString();
            txt_SLK.Text = dataGridView_Kho.Rows[i].Cells[1].Value.ToString();
        }

        private void txt_SLK_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back && e.KeyChar != 32 && e.KeyChar != '.')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string keyword = txt_Search.Text;
            // Khai bao DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            txt_Search.Clear();
            da = new SqlDataAdapter("Select MaSP, SLKho from Kho where MaSP like '%" + keyword + "%'", conn);
            //Do du lieu tu DataAdapter vao dataSet
            da.Fill(ds, "Kho");

            //Gan du lieu nguon cho dataGridView
            dataGridView_Kho.DataSource = ds.Tables["Kho"];
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}
