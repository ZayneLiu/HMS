using System;
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
    public partial class P_Med : Form
    {
        public Form parent;
        public P_Med(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void P_Med_Load(object sender, EventArgs e)
        {

        }
    }
}
