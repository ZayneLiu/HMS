﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doctor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            if (Server.Logics.Doctor_Logics.Is_Login_Info_Valid(Tbx_Username.Text, Tbx_Password.Text))
            {
                Doc_Personal_Center frm = new Doc_Personal_Center();
                frm.Show();
            }
            else 
            {
                MessageBox.Show("用户名或密码错误！");
            }
        }
    }
}
