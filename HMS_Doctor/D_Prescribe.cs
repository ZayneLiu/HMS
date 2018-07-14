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
            if (listView_left.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选中任意项");
                return;
            }
            int stock = int.Parse(listView_left.SelectedItems[0].SubItems[listView_left.SelectedItems[0].SubItems.Count - 1].Text);
            int selected_id = int.Parse(listView_left.SelectedItems[0].Text);
            var right_items = listView_Prescribe_Meds.Items;
            if (stock == 0)
            {
                MessageBox.Show("该药品已没有库存");
                return;
            }
            if (right_items.Count == 0)
            {
                var med = Server.Models.Med.Get_Med_By_Id(selected_id);
                listView_Prescribe_Meds.Items.Add(new ListViewItem(new string[]
                    {
                        med.M_ID .ToString (),
                        med .M_Name ,
                        med.M_Category ,
                        med .M_Effect,
                        1.ToString()
                    }));
                listView_left.SelectedItems[0].SubItems[listView_left.SelectedItems[0].SubItems.Count - 1].Text = (stock - 1).ToString();
                return;
            }
            foreach (ListViewItem item in right_items)
            {
                if (item.Text == selected_id.ToString())
                {
                    int count = int.Parse(item.SubItems[item.SubItems.Count - 1].Text);
                    count++;
                    // 添加到右侧列表
                    item.SubItems[item.SubItems.Count - 1].Text = count.ToString();
                    // 左侧列表对应药品库存 -1
                    listView_left.SelectedItems[0].SubItems[listView_left.SelectedItems[0].SubItems.Count - 1].Text = (stock - 1).ToString();
                    return;
                }
            }
            var Med_Add = Server.Models.Med.Get_Med_By_Id(selected_id);
            listView_Prescribe_Meds.Items.Add(new ListViewItem(new string[]
                {
                    Med_Add.M_ID.ToString(),
                    Med_Add.M_Name,
                    Med_Add.M_Category,
                    Med_Add.M_Effect,
                    1.ToString()
                }));
        }

        private void D_Prescribe_Load(object sender, EventArgs e)
        {
            var meds = Server.Models.Med.Get_All_Meds();
            if (meds == null)
            {
                return;
            }
            foreach (var med in meds)
            {
                listView_left.Items.Add(new ListViewItem(new string[]
                    {
                        med.M_ID .ToString (),
                        med.M_Name ,
                        med .M_Category,
                        med.M_Unit,
                        med.M_Effect,
                        med.M_Stock.ToString()
                    }));
            }
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            bool failed = false;
            var meds = listView_Prescribe_Meds.Items;
            foreach (ListViewItem item in meds)
            {
                int count = int.Parse(item.SubItems[item.SubItems.Count -1].Text);
                int M_ID = int.Parse(item.Text);
                if (false == Server.Logics.Treatment_Record_Logics.Prescribe(D_Management_Patient.T_ID, M_ID, count))
                {
                    failed = true;
                }
            }
            if (failed)
            {
                MessageBox.Show("开药失败！");
                return;
            }
            MessageBox.Show("开药成功");
            Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            D_Management_Patient frm = new D_Management_Patient();
            Hide();
            frm.Show();
        }


    }
}
