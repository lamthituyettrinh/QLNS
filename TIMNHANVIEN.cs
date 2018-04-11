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
    public partial class TIMNHANVIEN : Form
    {
        Class_NHANVIEN nhanvien;
        public TIMNHANVIEN()
        {
            InitializeComponent();
            nhanvien = new Class_NHANVIEN();
            nhanvien.loaddulieu(this);
        }

        private void bt_find_Click(object sender, EventArgs e)
        {
            try
            {
                nhanvien.timkiem(this);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
        }
    }
}
