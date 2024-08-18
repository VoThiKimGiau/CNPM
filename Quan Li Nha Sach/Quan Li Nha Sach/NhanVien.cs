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
    public partial class NhanVien : Form
    {
        SqlConnection conn;
        SqlDataAdapter da_nv;
        DataView dv_nv;
        DataColumn[] key = new DataColumn[1];
        DBconnect db = new DBconnect();
        DataSet ds_nv = new DataSet();
    
        public NhanVien()
        {
            InitializeComponent();
            conn = db.getConnection();
        }
        void LoadDuLieuNhanVien()
        {
            string strsel = "select * from NhanVien ";
            SqlDataAdapter da_NV = new SqlDataAdapter(strsel, conn);
            da_NV.Fill(ds_nv, "NhanVien");
            dataGridView1.DataSource = ds_nv.Tables["NhanVien"];
            key[0] = ds_nv.Tables["NhanVien"].Columns[0];
            ds_nv.Tables["NhanVien"].PrimaryKey = key;
        }

        void Databingding(DataTable pDT)
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            NS.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();


            txtTenNV.DataBindings.Add("Text", pDT, "TenNV");
            txtMaNV.DataBindings.Add("Text", pDT, "MaNV");
            txtChucVu.DataBindings.Add("Text", pDT, "ChucVu");
            txtSDT.DataBindings.Add("Text", pDT, "SDT");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            NS.DataBindings.Add("Text", pDT, "NgaySinh");
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            LoadDuLieuNhanVien();

            dataGridView1.ReadOnly = true;

            dataGridView1.AllowUserToAddRows = false;

            txtMaNV.Enabled = false;
            txtTenNV.Enabled = false;
            txtChucVu.Enabled = false;
            NS.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;

            Databingding(ds_nv.Tables["NhanVien"]);

            btnLuu.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            // Khai bao DataSet
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            txtSearch.Clear();
            da = new SqlDataAdapter("Select * from NhanVien where TenNV like N'%" + keyword + "%'", conn);
            //Do du lieu tu DataAdapter vao dataSet
            da.Fill(ds, "NhanVien");

            //Gan du lieu nguon cho dataGridView
            dataGridView1.DataSource = ds.Tables["NhanVien"];
        }

        private void btnThem_Click(object sender, EventArgs e)
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

        public bool KT_KhoaChinh(string pMa)
        {
            conn.Open();
            string selectString = "select * from NhanVien where MaNV ='" + pMa + "'";
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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                
                    SqlDataAdapter da_NV = new SqlDataAdapter("select * from NhanVien", conn);
                    SqlCommandBuilder cmb = new SqlCommandBuilder(da_NV);
                    da_NV.Update(ds_nv, "NhanVien");

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
            DataRow dr = ds_nv.Tables["NhanVien"].Rows.Find(txtMaNV.Text);
            if (dr != null)
            {
                dr.Delete();

            }
            SqlDataAdapter da_NV = new SqlDataAdapter("select * from NhanVien", conn);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da_NV);
            da_NV.Update(ds_nv, "NhanVien");
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
