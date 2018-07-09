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
    public partial class P_Message : Form
    {
        public P_Message()
        {
            InitializeComponent();
        }

        private void P_Message_Load(object sender, EventArgs e)
        {
            var p = Server.Models.Patient.Get_Patient_By_ID(P_Login.P_ID);
            label_name.Text = p.P_Name;
        }
    }
}
