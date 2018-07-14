﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Partial
{
    public partial class Admin_Ptient_Record : Form
    {
        public Form parent;
        public Admin_Ptient_Record(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Admin_Patient_Treatment_Detail frm = new Admin_Patient_Treatment_Detail(this);
            frm.Show();
            Hide();
        }
    }
}
