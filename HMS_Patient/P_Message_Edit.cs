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
    
    public partial class P_Message_Edit : Form
    {
        public Form parent;
        public P_Message_Edit(Form form)
        {
            InitializeComponent();
            parent = form;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
