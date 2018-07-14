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
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中任意项");
                return;
            }

            int selected_id = int.Parse(listView1.SelectedItems[0].Text);
            var right_items = listView_Prescribe_Meds.Items;
            foreach (ListViewItem item in right_items)
            {
                if (item.Text == selected_id.ToString())
                {
                    int count = int.Parse(item.SubItems["Count"].Text);
                    count++;
                }
                else
                {
                    var Med_Add = Server.Models.Med.Get_Med_By_Id(selected_id);
                    listView_Prescribe_Meds.Items.Add(new ListViewItem(new string[]
                        {
                            Med_Add.M_ID .ToString (),
                            Med_Add .M_Name ,
                            Med_Add.M_Category ,
                            Med_Add .M_Unit ,
                            Med_Add .M_Price.ToString (),
                            Med_Add .M_Effect
                        }));
                }
            }
        }

        private void D_Prescribe_Load(object sender, EventArgs e)
        {
            var Med = Server.Models.Med.Get_All_Meds();
            if (Med == null)
            {
                return;
            }
            foreach (var Meds in Med)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                    {
                        Meds.M_ID .ToString (),
                        Meds.M_Name ,
                        Meds .M_Category,
                        Meds.M_Effect,
                        1.ToString()
                    }));
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            var meds = listView_Prescribe_Meds.Items;
            int count = int.Parse(listView_Prescribe_Meds.Items["Count"].Text);
            foreach (ListViewItem item in meds)
            {
                int M_ID = int.Parse(item.Text);
                Server.Logics.Treatment_Record_Logics.Prescribe(D_Management_Patient.T_ID, M_ID, count);
            }
            var Med_Add = Server.Models.Med.Get_Med_By_Id(int.Parse(listView1.SelectedItems[0].Text));
            // 对应坐诊ID的药品记录进行Update
            if (Med_Add.SaveChanges())
            {
                D_Treatment frm = new D_Treatment();
                frm.Show();
                Hide();
            }
            MessageBox.Show("开药失败！");

        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            Hide();
            frm.Show();
        }


    }
}
