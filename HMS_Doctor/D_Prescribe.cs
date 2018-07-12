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
    public partial class D_Prescribe : Form
    {
        public D_Prescribe()
        {
            InitializeComponent();

        }

        private void label_Add_Med_Click(object sender, EventArgs e)
        {
            var Med_Add = Server.Models.Med.Get_Med_By_Id(int.Parse (listView1.SelectedItems[0].SubItems[0].Text) );
            listView2.Items.Add(new ListViewItem(new string[]
                {
                    Med_Add.M_ID .ToString (),
                    Med_Add .M_Name ,
                    Med_Add.M_Category ,
                    Med_Add .M_Unit ,
                    Med_Add .M_Price.ToString (),
                    Med_Add .M_Effect 
                }));
        }

        private void D_Prescribe_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            listView2.Clear();
            var Med = Server.Models.Med.Get_All_Meds ();
            foreach (var Meds in Med)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        Meds.M_ID .ToString (),
                        Meds.M_Name ,
                        Meds .M_Category,
                        Meds.M_Unit,
                        Meds.M_Price.ToString(),
                        Meds .M_Effect,
                        Meds.M_Stock .ToString ()
                    }));
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

            D_Treatment frm  = new D_Treatment();
            frm.Show();
            Hide();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            Hide();
            frm.Show();
        }
    }
}
