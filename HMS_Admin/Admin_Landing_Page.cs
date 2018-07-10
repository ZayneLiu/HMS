using System;
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
    public partial class Admin_Landing_Page : Form
    {
        public Admin_Landing_Page()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Hide();
            new Dialog_On_Exit(this).Show();
        }

        private void Meds_Management_Click(object sender, EventArgs e)
        {
            Hide();
            new Med_Management.Meds_Management_Landing_Page(this).Show();
        }
    }
}
