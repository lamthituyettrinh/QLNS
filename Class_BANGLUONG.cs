using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemQLNS.LQTOSQL;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace PhanMemQLNS
{
    class Class_BANGLUONG
    {
        Class_connect data;
        public Class_BANGLUONG()
        {
            data = new Class_connect();
        }

        public void loaddulieu(BANGLUONG f)
        {
            var sql = data.database().BangLuongs.Where(a=>a.IsDelete == 1);
            f.dgv_bangluong.DataSource = sql;
        }


        

        public void them(BANGLUONG f)
        {
            BangLuong bl = new BangLuong();
            bl.MaTinhLuong = f.cbb_matinhluong.Text;
            bl.HeSoLuong = f.txt_hesoluong.Text;
            bl.LuongCoBan_Ngay = f.txt_luongcoban.Text;
            bl.Thuong = f.txt_thuong.Text;
            bl.TamUng = f.txt_tamung.Text;
            bl.NgayTao = Convert.ToDateTime(f.dt_ngaytao.Text);

            bl.IsDelete = 1;
            data.database().BangLuongs.InsertOnSubmit(bl);
            data.database().SubmitChanges();

            DialogResult thongbao = MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK);
            if(thongbao == DialogResult.OK)
            {
                loaddulieu(f);
            }
        }


        public void xoa(BANGLUONG f)
        {
            var sql = data.database().BangLuongs.SingleOrDefault(a => a.MaTinhLuong == f.cbb_matinhluong.Text);
            sql.IsDelete = 0;
            data.database().SubmitChanges();
            loaddulieu(f);
        }
        public void sua(BANGLUONG f)
        {
            var sql = data.database().BangLuongs.SingleOrDefault(a => a.MaTinhLuong == f.cbb_matinhluong.Text);
            sql.HeSoLuong = f.txt_hesoluong.Text;
            sql.LuongCoBan_Ngay = f.txt_luongcoban.Text;
            sql.Thuong = f.txt_thuong.Text;
            sql.TamUng = f.txt_tamung.Text;
           // sql.NgayTao = f.dt_ngaytao; 
            sql.NgayTao = Convert.ToDateTime(f.dt_ngaytao.Text);
     

            data.database().SubmitChanges();
            loaddulieu(f);
        }

        public void loaddulieucbbbc(BANGLUONG f1)
        {
            var sql = data.database().BangCongs.Where(a => a.IsDelete == 1);
            f1.cbb_matinhluong.DataSource = sql;
            f1.cbb_matinhluong.DisplayMember = "TongCong";
            f1.cbb_matinhluong.ValueMember = "TongCong";
        }


        public void loaddulieucong(BANGLUONG f)
        {
            var sql = data.database().laytongcong(f.cbb_matinhluong.Text);
            f.txt_tongcong.Text = sql.Value.ToString();

        }
    }
}
