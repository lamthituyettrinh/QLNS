using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQLNS
{
    public partial class NHANVIEN : Form
    {
        Class_NHANVIEN nhanvien; 
        public NHANVIEN()
        {
            InitializeComponent();
            nhanvien = new Class_NHANVIEN();
            nhanvien.loaddulieu(this);
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.them(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
           
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.xoa(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
           
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.sua(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
           
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int donghientai = dgv_nhanvien.CurrentRow.Index;
                    cbb_matinhluong.Text = dgv_nhanvien.Rows[donghientai].Cells["MaTinhLuong"].Value.ToString();
                    txt_manv.Text = dgv_nhanvien.Rows[donghientai].Cells["MaNV"].Value.ToString();
                    txt_honv.Text = dgv_nhanvien.Rows[donghientai].Cells["HoNV"].Value.ToString();
                    txt_tennv.Text = dgv_nhanvien.Rows[donghientai].Cells["TenNV"].Value.ToString();
                    if (dgv_nhanvien.Rows[donghientai].Cells["GioiTinh"].Value.ToString() == "Nam")
                    {
                        rdb_nam.Checked = true;
                    }
                    else
                    {
                        rdb_nu.Checked = true;
                    }
                    txt_diachi.Text = dgv_nhanvien.Rows[donghientai].Cells["DiaChi"].Value.ToString();
                    txt_dienthoai.Text = dgv_nhanvien.Rows[donghientai].Cells["SĐT"].Value.ToString();
                    txt_ghichu.Text = dgv_nhanvien.Rows[donghientai].Cells["GhiChu"].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
           
        }

        private void dgv_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_dienthoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TIMNHANVIEN TNV = new TIMNHANVIEN();
            TNV.Show();
        }
    }
}
