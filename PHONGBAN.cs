﻿using System;
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
    public partial class PHONGBAN : Form
    {
        Class_PhongBans phongban;  
        public PHONGBAN()
        {
            InitializeComponent();
            phongban = new Class_PhongBans();
            phongban.loaddulieu(this);
        }

        private void bt_find_Click(object sender, EventArgs e)
        {
            try
            {
                phongban.timkiem(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra!", "Thông Báo");
            }
        }
    }
}
