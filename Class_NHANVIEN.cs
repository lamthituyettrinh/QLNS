using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQLNS.LQTOSQL;
using System.Windows.Forms;
using System.IO;
using System.Data.Linq;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PhanMemQLNS
{
    class Class_NHANVIEN
    {
        SqlConnection con;
        Class_connect data;

        public Class_NHANVIEN()
        {
            // data = new Class_connect();
            string cnString = ConfigurationManager.ConnectionStrings["QLNS"].ConnectionString.ToString();
            con = new SqlConnection(cnString);
            con.Open();

        }

        public void loaddulieu(NHANVIEN f)
        {
            string sql = "SELECT * FROM NhanVien WHERE IsDelete = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            f.dgv_nhanvien.DataSource = dt;
            loadcomboluong(f);
        }

        public void loaddulieu(TIMNHANVIEN f)
        {
            string sql = "SELECT * FROM NhanVien WHERE IsDelete = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            f.dgv_nhanvien.DataSource = dt;
        }

        public void timkiem(TIMNHANVIEN f)
        {

            if (f.rdb_theoma.Checked)
            {
                string sql = "SELECT * FROM NhanVien WHERE IsDelete = 1 AND MaNV LIKE '%" + f.txt_manv.Text + "%'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                f.dgv_nhanvien.DataSource = dt;
            }
            else if (f.rdb_theoten.Checked)
            {
                string sql = "SELECT * FROM NhanVien WHERE IsDelete = 1 AND TenNV LIKE'%" + f.txt_manv.Text + "%'";
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
        public void loadcomboluong(NHANVIEN f)
        {
            string sql = "SELECT MaTinhLuong FROM BangLuong WHERE IsDelete = 1";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            var dt = new DataTable();
            dt.Load(dr);
            f.cbb_matinhluong.DataSource = dt;
            f.cbb_matinhluong.DisplayMember = "MaTinhLuong";
        }

        public void them(NHANVIEN f)
        {
            if (f.txt_manv.Text.Trim() == "")
            {
                MessageBox.Show("Mã Nhân Viên Không được bỏ trống", "Thông Báo");
                return;
            }
            else
            {
                string sqlfind = "SELECT * FROM NhanVien WHERE   MaNV = '" + f.txt_manv.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlfind, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);

                //  var sql = data.database().NhanViens.SingleOrDefault(a => a.MaNV == f.txt_manv.Text);
                if (dt == null || dt.Rows.Count == 0)
                {
                    string sql = "INSERT INTO NhanVien VALUES(@MaNV, @HoNV, @TenNV, @DiaChi, @GioiTinh, @SĐT , @MaTinhLuong , @GhiChu , @IsDelete)";
                    SqlCommand cmd2 = new SqlCommand(sql, con);
                    cmd2.Parameters.AddWithValue("MaNV", f.txt_manv.Text);
                    cmd2.Parameters.AddWithValue("HoNV", f.txt_honv.Text);
                    cmd2.Parameters.AddWithValue("TenNV", f.txt_tennv.Text);
                    cmd2.Parameters.AddWithValue("DiaChi", f.txt_diachi.Text);
                    cmd2.Parameters.AddWithValue("GioiTinh", f.rdb_nam.Checked ? "Nam" : "Nữ");
                    cmd2.Parameters.AddWithValue("SĐT", f.txt_dienthoai.Text);
                    cmd2.Parameters.AddWithValue("MaTinhLuong", f.cbb_matinhluong.Text);
                    cmd2.Parameters.AddWithValue("GhiChu", f.txt_ghichu.Text);
                    cmd2.Parameters.AddWithValue("IsDelete", 1);
                    cmd2.ExecuteNonQuery();

                    DialogResult thongbao = MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
                    if (thongbao == DialogResult.OK)
                    {
                        loaddulieu(f);
                    }
                }
                else
                {
                    MessageBox.Show("Mã Nhân Viên Đã trùng! Xin vui lòng kiểm tra lại.", "Thông Báo");
                    return;
                }

            }

        }

        public void xoa(NHANVIEN f)
        {
            if (f.txt_manv.Text.Trim() == "")
            {
                MessageBox.Show("Mã Nhân Viên Không được bỏ trống", "Thông Báo");
                return;
            }
            else
            {
                string sqlfind = "SELECT * FROM NhanVien WHERE IsDelete = 1 And MaNV = '" + f.txt_manv.Text  + "'";
                SqlCommand cmd2 = new SqlCommand(sqlfind, con);
                SqlDataReader dr = cmd2.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt == null && dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần Xóa!", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql22 = "UPDATE NhanVien SET IsDelete = 0 WHERE MaNV = @MaNV";
                    SqlCommand cmd = new SqlCommand(sql22, con);
                    cmd.Parameters.AddWithValue("@MaNV", f.txt_manv.Text);
                    cmd.ExecuteNonQuery();

                }
                DialogResult thongbao = MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK);
                if (thongbao == DialogResult.OK)
                {
                    loaddulieu(f);
                }
                loaddulieu(f);
            }
        }
        public void sua(NHANVIEN f)
        {
            if (f.txt_manv.Text.Trim() == "")
            {
                MessageBox.Show("Mã Nhân Viên Không được bỏ trống", "Thông Báo");
                return;
            }
            else
            {
                string sqlfind = "SELECT * FROM NhanVien WHERE IsDelete = 1 And MaNV = '" + f.txt_manv.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlfind, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt == null && dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên cần sửa!", "Thông Báo", MessageBoxButtons.OK);
                }
                else
                {
                    string sql22 = "UPDATE NhanVien SET HoNV= @HoNV,TenNV = @TenNV,DiaChi = @DiaChi,GioiTinh= @GioiTinh,SĐT = @SĐT ,MaTinhLuong= @MaTinhLuong ,GhiChu = @GhiChu ,IsDelete = @IsDelete WHERE MaNV = @MaNV";
                    SqlCommand cmd2 = new SqlCommand(sql22, con);
                    cmd2.Parameters.AddWithValue("HoNV", f.txt_honv.Text);
                    cmd2.Parameters.AddWithValue("TenNV", f.txt_tennv.Text);
                    cmd2.Parameters.AddWithValue("DiaChi", f.txt_diachi.Text);
                    cmd2.Parameters.AddWithValue("GioiTinh", f.rdb_nam.Checked ? "Nam" : "Nữ");
                    cmd2.Parameters.AddWithValue("SĐT", f.txt_dienthoai.Text);
                    cmd2.Parameters.AddWithValue("MaTinhLuong", f.cbb_matinhluong.Text);
                    cmd2.Parameters.AddWithValue("GhiChu", f.txt_ghichu.Text);
                    cmd2.Parameters.AddWithValue("IsDelete", 1);
                    cmd2.Parameters.AddWithValue("@MaNV", f.txt_manv.Text);
                    cmd2.ExecuteNonQuery();

                }
                DialogResult thongbao = MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK);
                if (thongbao == DialogResult.OK)
                {
                    loaddulieu(f);
                }
                loaddulieu(f);
            }

        }
    }
}
