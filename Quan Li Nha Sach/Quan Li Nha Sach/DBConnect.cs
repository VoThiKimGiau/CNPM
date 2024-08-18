 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Quan_Li_Nha_Sach
{
    class DBconnect
    {
        //thuoc tinh
        SqlConnection conn;
        string chuoiketnoi = "Data Source=ZENO; Initial Catalog=QL_NhaSach; Integrated Security=True";


        //pthuc khoi tao
        public DBconnect()
        {
            conn = new SqlConnection(chuoiketnoi);
        }
        public DBconnect(string chuoikn)
        {
            conn = new SqlConnection(chuoikn);
        }
        public SqlConnection getConnection()
        {
            return conn;
        }

        //pthuc xu li
        public void Open()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

        }
        public void Close()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        public int getNonQuery(string chuoitruyvan)
        {
            Open();

            SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);

            //thuc thi
            int kq = cmd.ExecuteNonQuery();
            Close();
            return kq;
        }

        public DataTable getDataTable(string chuoitruyvan)
        {
            Open();
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);

            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public object getScalar(string chuoitruyvan)
        {
            Open();
            SqlCommand cmd = new SqlCommand(chuoitruyvan, conn);
            //thuc thi
            int kq = (int)cmd.ExecuteScalar();
            Close();
            return kq;
        }

        public int updatDtaTable(DataTable dtnew, string chuoitruyvan)
        {
            SqlDataAdapter da = new SqlDataAdapter(chuoitruyvan, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            int kq = da.Update(dtnew);
            return kq;
        }
    }
}
