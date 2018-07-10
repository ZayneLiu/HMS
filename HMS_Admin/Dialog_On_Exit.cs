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
    public partial class Dialog_On_Exit : Form
    {
        Admin_Landing_Page Landing_Page;
        public Dialog_On_Exit(Admin_Landing_Page Landing_Page)
        {
            InitializeComponent();
            this.Landing_Page = Landing_Page;
        }

        private void Yes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void No_Click(object sender, EventArgs e)
        {
            Landing_Page.Show();
            Close();
        }
    }
}
