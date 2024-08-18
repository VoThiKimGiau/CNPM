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
    public partial class frmLogin : Form
    {
        DBconnect db = new DBconnect();
        SqlConnection conn;
        public frmLogin()
        {
            InitializeComponent();
            conn = db.getConnection();
        }
        
        private string getID(string username, string pass)
        {
            string id = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM PQ WHERE UserName ='" + username + "' and Pass='" + pass + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["MaNV"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                conn.Close();
            }
            return id;
        }

        public static string ID_USER = "";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ID_USER = getID(txtUN.Text, txtPass.Text);

            if (ID_USER != "")
            {
                frm_MenuChung f = new frm_MenuChung();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản và mật khẩu không đúng !");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ckShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckShowPass.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }
    }
}
