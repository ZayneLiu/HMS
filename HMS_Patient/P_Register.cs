﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Patient
{
    public partial class P_Register : Form
    {
        public P_Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Center frm = new P_Center();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Tip_2 frm = new P_Tip_2();
            frm.Show();
        }
    }
}
