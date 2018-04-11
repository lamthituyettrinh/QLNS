using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace PhanMemQLNS
{
    class Class_PhongBans
    {
        SqlConnection con;

        public Class_PhongBans()
        {
          
            string cnString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString.ToString();
            con = new SqlConnection(cnString);
            con.Open();
        }

        public void loaddulieu(PHONGBAN f)
        {
            string sql = "SELECT * FROM PhongBan WHERE IsDelete = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            f.dgv_nhanvien.DataSource = dt;
        }

        public void timkiem(PHONGBAN f)
        {
         
            if (f.rdb_theoma.Checked)
            {
                string sql = "SELECT * FROM PhongBan WHERE IsDelete = 1 AND MaPB LIKE '%"+ f.txt_manv.Text +"%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f.dgv_nhanvien.DataSource = dt;
            }
            else if (f.rdb_theoten.Checked)
            {
                string sql = "SELECT * FROM PhongBan WHERE IsDelete = 1 AND TenPB LIKE'%" + f.txt_manv.Text + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f.dgv_nhanvien.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Chọn phương thức tìm kiếm!", "Thông Báo");
                return;
            }
        
        }
    }
}
