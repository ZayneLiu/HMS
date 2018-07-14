using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMS_Doctor
{
    public partial class D_Inspect : Form
    {
        public D_Inspect()
        {
            InitializeComponent();
        }

        private void D_Inspect_Load(object sender, EventArgs e)
        {
            listView1.Items .Clear();
            var Inspect = Server.Models.Inspection.Get_All_Inspections ();
            foreach (var Inspeccts in Inspect)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        Inspeccts .I_ID .ToString (),
                        Inspeccts.I_Name ,
                        Inspeccts .I_Price .ToString ()
                    }));
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //if (Server .Models .Inspection.)
            D_Treatment frm = new D_Treatment();
            frm.Show();
            Hide();
        }

        private void labelD_Inspect_Click(object sender, EventArgs e)
        {
            var Med_Add = Server.Models.Inspection .Get_Inspection_By_ID(listView1.SelectedItems[0].Text);
            listView2.Items.Add(new ListViewItem(new string[]
                {
                    Med_Add .I_Name ,
                    Med_Add .I_Price .ToString ()
                }));
        }

        private void D_Inspect_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            D_Treatment frm = new D_Treatment();
            Hide();
            frm.Show();
        }
    }
}
