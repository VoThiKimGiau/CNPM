using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Li_Nha_Sach
{
    public partial class frmNCC : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_ncc;
        DataView dv_nv;
        DataColumn[] key = new DataColumn[1];
        DBconnect db = new DBconnect();
        DataSet ds_ncc = new DataSet();

        public frmNCC()
        {
            InitializeComponent();
            conn = db.getConnection();

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NK")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = false;
            }    
        }

        void LoadDuLieuNCC()
        {
            string strsel = "select * from NCC ";
            SqlDataAdapter da_NV = new SqlDataAdapter(strsel, conn);
            da_NV.Fill(ds_ncc, "NCC");
            dataGridView1.DataSource = ds_ncc.Tables["NCC"];
            key[0] = ds_ncc.Tables["NCC"].Columns[0];
            ds_ncc.Tables["NCC"].PrimaryKey = key;
        }

        void Databingding(DataTable pDT)
        {
            txtMaNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();


            txtTenNCC.DataBindings.Add("Text", pDT, "TenNCC");
            txtMaNCC.DataBindings.Add("Text", pDT, "MaNCC");
            txtEmail.DataBindings.Add("Text", pDT, "Email");
            txtSDT.DataBindings.Add("Text", pDT, "SDT");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            LoadDuLieuNCC();

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;

            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtEmail.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            Databingding(ds_ncc.Tables["NCC"]);

            btnLuu.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            // Khai bao DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            txtSearch.Clear();
            da = new SqlDataAdapter("Select * from NCC where TenNCC like N'%" + keyword + "%'", conn);
            //Do du lieu tu DataAdapter vao dataSet
            da.Fill(ds, "NCC");

            //Gan du lieu nguon cho dataGridView
            dataGridView1.DataSource = ds.Tables["NCC"];
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                btnLuu.Enabled = true;
                //+ Cho phép thêm các dòng tiếp theo trên datagridview
                dataGridView1.AllowUserToAddRows = true;
                dataGridView1.ReadOnly = false;


                //Không được sửa các dòng trên datagridview đã có dữ liệu
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    dataGridView1.Rows[i].ReadOnly = true;
                }
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da_NV = new SqlDataAdapter("select * from NCC", conn);
                SqlCommandBuilder cmb = new SqlCommandBuilder(da_NV);
                da_NV.Update(ds_ncc, "NCC");

                MessageBox.Show("Thành công");
                btnLuu.Enabled = false;
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;

            dataGridView1.ReadOnly = false;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                dataGridView1.Rows[i].ReadOnly = false;
            dataGridView1.Columns[0].ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;
        }



        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRow dr = ds_ncc.Tables["NCC"].Rows.Find(txtMaNCC.Text);
            if (dr != null)
            {
                dr.Delete();

            }
            SqlDataAdapter da_NV = new SqlDataAdapter("select * from NCC", conn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_NV);
            da_NV.Update(ds_ncc, "NCC");
            MessageBox.Show("Xóa thành công");

        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
            {
                if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    e.Cancel = true;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "Không được để trống cột nào";
                    break;
                }
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            frm_MenuChung f = new frm_MenuChung();
            f.Show();
            this.Close();
        }
    }
}
