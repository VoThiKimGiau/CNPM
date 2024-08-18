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
    public partial class frmQuanLyKhachHang : Form
    {
        SqlConnection connsql;
        DBconnect cn = new DBconnect();
        DataTable KhachHang;
        SqlDataAdapter data;
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            connsql = cn.getConnection();

            string id = frmLogin.ID_USER;
            id = id.Substring(0, 2);
            if (id == "NB")
            {
                btnLuu.Enabled = false;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        private void load_DGV_KhachHang()
        {
            KhachHang = new DataTable();
            string querySelect = "Select * from KhachHang";
            data = new SqlDataAdapter(querySelect, connsql);
            data.Fill(KhachHang);
            DataColumn[] key = new DataColumn[1];
            key[0] = KhachHang.Columns["MaKH"];
            KhachHang.PrimaryKey = key;

            dtGV_KhachHang.Columns["MaKH"].DataPropertyName = "MaKH";
            dtGV_KhachHang.Columns["TenKH"].DataPropertyName = "TenKH";
            dtGV_KhachHang.Columns["DiaChi"].DataPropertyName = "DiaChi";
            dtGV_KhachHang.Columns["SDT"].DataPropertyName = "SDT";
            dtGV_KhachHang.Columns["Email"].DataPropertyName = "Email";

            dtGV_KhachHang.DataSource = KhachHang;

        }

        private void dataBingDing(DataTable pDT)
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtEmail.DataBindings.Clear();

            txtMaKH.DataBindings.Add("Text", pDT, "MaKH");
            txtTenKH.DataBindings.Add("Text", pDT, "TenKH");
            txtDiaChi.DataBindings.Add("Text", pDT, "DiaChi");
            txtSDT.DataBindings.Add("Text", pDT, "SDT");
            txtEmail.DataBindings.Add("Text", pDT, "Email");
        }

        private void load_Cbo_TimKiem()
        {
            List<CboTimKiem> cbo = new List<CboTimKiem>();
            cbo.Add(new CboTimKiem("Mã Khách Hàng", "MaKH"));
            cbo.Add(new CboTimKiem("Họ Tên", "TenKH"));
            cbo.Add(new CboTimKiem("Địa Chỉ", "DiaChi"));
            cbo.Add(new CboTimKiem("Số điện thoại", "SDT"));
            cbo.Add(new CboTimKiem("Email", "Email"));

            cbo_TimKiem.DisplayMember = "Text";
            cbo_TimKiem.ValueMember = "Name";
            cbo_TimKiem.DataSource = cbo;
            cbo_TimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            load_DGV_KhachHang();
            dataBingDing(KhachHang);
            load_Cbo_TimKiem();

            dtGV_KhachHang.ReadOnly = true;
            dtGV_KhachHang.AllowUserToAddRows = false;
        }

        private void load_DGV_KhachHang(string danhMuc, string chuoiTimKiem)
        {
            if (chuoiTimKiem == string.Empty)
            {
                dtGV_KhachHang.DataSource = KhachHang;
                return;
            }

            DataTable dtTable = KhachHang;
            DataTable filteredTable = dtTable.Clone();

            foreach (DataRow row in dtTable.Rows)
            {
                if (row[danhMuc].ToString().Contains(chuoiTimKiem))
                {
                    filteredTable.ImportRow(row);
                }
            }

            dtGV_KhachHang.DataSource = filteredTable;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            load_DGV_KhachHang(cbo_TimKiem.SelectedValue.ToString(), txtTimKiem.Text);
        }

        private void xoaThongTinKH()
        {
            foreach (Control item in gB_TTKH.Controls)
            {
                if (item.GetType() == typeof(TextBox) || item.GetType() == typeof(ComboBox))
                    item.Text = "";
            }
        }

        private void ngatDataBingDing()
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
        }

        private void khoaTextBox()
        {
            foreach (Control item in gB_TTKH.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    item.Enabled = false;
            }
        }

        private void moTextBox()
        {
            foreach (Control item in gB_TTKH.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                    item.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            xoaThongTinKH();

            ngatDataBingDing();

            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            moTextBox();

            dtGV_KhachHang.FirstDisplayedScrollingRowIndex = dtGV_KhachHang.Rows.Count - 1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ngatDataBingDing();

            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            moTextBox();

            //format khi click chuột vào sẽ tự động nằm bên phải
            foreach (Control item in gB_TTKH.Controls)
            {
                if (item.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)item;
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.SelectionLength = 0;
                }
            }

            txtMaKH.Enabled = false;
        }

        private void resetDuLieu()
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtTimKiem.Clear();

            khoaTextBox();
            
            dataBingDing(KhachHang);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetDuLieu();

            frmQuanLyKhachHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Lưu thay đổi khách hàng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.No)
                return;
            else
            {
                try
                {
                    if (txtMaKH.Enabled == true) //Them
                    {
                        if (txtMaKH.Text == string.Empty)
                        {
                            MessageBox.Show("Bạn phải nhập Mã khách hàng!!!");
                            return;
                        }
                        if (txtTenKH.Text == string.Empty)
                        {
                            MessageBox.Show("Bạn phải nhập Tên khách hàng!!!");
                            return;
                        }
                        if (txtSDT.Text.Trim().Length != 10)
                        {
                            MessageBox.Show("Số điện thoại phải đủ 10 số!!!");
                            return;
                        }
                        DataRow dr = KhachHang.Rows.Find(txtMaKH.Text);
                        if (dr == null)
                        {
                            DataRow insertRow = KhachHang.NewRow();
                            insertRow["MaKH"] = txtMaKH.Text;
                            insertRow["TenKH"] = txtTenKH.Text;
                            insertRow["DiaChi"] = txtDiaChi.Text;
                            insertRow["SDT"] = txtSDT.Text;
                            insertRow["Email"] = txtEmail.Text;
                            KhachHang.Rows.Add(insertRow);
                        }
                        else
                        {
                            MessageBox.Show("Trung Mã khách hàng!!!");
                            return;
                        }
                    }
                    else    //Sua
                    {

                        DataRow updateRow = KhachHang.Rows.Find(txtMaKH.Text);
                        if (updateRow != null)
                        {
                            updateRow["TenKH"] = txtTenKH.Text;
                            updateRow["DiaChi"] = txtDiaChi.Text;
                            updateRow["SDT"] = txtSDT.Text;
                            updateRow["Email"] = txtEmail.Text;
                        }
                    }
                    SqlCommandBuilder cB = new SqlCommandBuilder(data);
                    data.Update(KhachHang);
                    MessageBox.Show("Thành công");
                    xoaThongTinKH();
                    resetDuLieu();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Hủy bỏ ký tự không hợp lệ
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn xoá khách hàng này chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (r == DialogResult.Yes)
            {
                try
                {
                    DataRow deleteRow = KhachHang.Rows.Find(txtMaKH.Text);
                    deleteRow.Delete();
                    SqlCommandBuilder cB = new SqlCommandBuilder(data);
                    data.Update(KhachHang);
                    MessageBox.Show("Thành công");
                    //load_DGV_KhachHang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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
