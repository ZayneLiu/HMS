namespace HMS_Partial
{
    partial class Admin_Patient_Treatment_Detail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_Detail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listView_Inspections = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView_Meds = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_T_Time = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_P_Name = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_T_ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_D_Name = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label_D_Department = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(17, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 42);
            this.panel3.TabIndex = 43;
            this.panel3.Click += new System.EventHandler(this.label8_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::HMS_Partial.Properties.Resources.Back;
            this.pictureBox2.Location = new System.Drawing.Point(-3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.label8_Click);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(40, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 28);
            this.label8.TabIndex = 39;
            this.label8.Text = "返回";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label_Detail
            // 
            this.label_Detail.AutoSize = true;
            this.label_Detail.Location = new System.Drawing.Point(242, 143);
            this.label_Detail.Name = "label_Detail";
            this.label_Detail.Size = new System.Drawing.Size(41, 12);
            this.label_Detail.TabIndex = 93;
            this.label_Detail.Text = "label2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(195, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 17);
            this.label9.TabIndex = 94;
            this.label9.Text = "内容：";
            // 
            // listView_Inspections
            // 
            this.listView_Inspections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.listView_Inspections.Location = new System.Drawing.Point(268, 177);
            this.listView_Inspections.Name = "listView_Inspections";
            this.listView_Inspections.Size = new System.Drawing.Size(162, 193);
            this.listView_Inspections.TabIndex = 90;
            this.listView_Inspections.UseCompatibleStateImageBehavior = false;
            this.listView_Inspections.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "检查名称";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "费用";
            // 
            // listView_Meds
            // 
            this.listView_Meds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader4});
            this.listView_Meds.Location = new System.Drawing.Point(12, 177);
            this.listView_Meds.Name = "listView_Meds";
            this.listView_Meds.Size = new System.Drawing.Size(250, 193);
            this.listView_Meds.TabIndex = 89;
            this.listView_Meds.UseCompatibleStateImageBehavior = false;
            this.listView_Meds.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "药品名称";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "单价";
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 1;
            this.columnHeader2.Text = "数量";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "药品功效";
            // 
            // label_T_Time
            // 
            this.label_T_Time.AutoSize = true;
            this.label_T_Time.Location = new System.Drawing.Point(245, 103);
            this.label_T_Time.Name = "label_T_Time";
            this.label_T_Time.Size = new System.Drawing.Size(41, 12);
            this.label_T_Time.TabIndex = 83;
            this.label_T_Time.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(171, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 84;
            this.label5.Text = "就诊时间：";
            // 
            // label_P_Name
            // 
            this.label_P_Name.AutoSize = true;
            this.label_P_Name.Location = new System.Drawing.Point(85, 145);
            this.label_P_Name.Name = "label_P_Name";
            this.label_P_Name.Size = new System.Drawing.Size(41, 12);
            this.label_P_Name.TabIndex = 85;
            this.label_P_Name.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(14, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 86;
            this.label3.Text = "被诊病人：";
            // 
            // label_T_ID
            // 
            this.label_T_ID.AutoSize = true;
            this.label_T_ID.Location = new System.Drawing.Point(85, 103);
            this.label_T_ID.Name = "label_T_ID";
            this.label_T_ID.Size = new System.Drawing.Size(41, 12);
            this.label_T_ID.TabIndex = 87;
            this.label_T_ID.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(14, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 88;
            this.label2.Text = "就诊编号：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(150, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 42);
            this.label6.TabIndex = 82;
            this.label6.Text = "记录详情";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(315, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 84;
            this.label11.Text = "坐诊医生：";
            // 
            // label_D_Name
            // 
            this.label_D_Name.AutoSize = true;
            this.label_D_Name.Location = new System.Drawing.Point(389, 103);
            this.label_D_Name.Name = "label_D_Name";
            this.label_D_Name.Size = new System.Drawing.Size(41, 12);
            this.label_D_Name.TabIndex = 83;
            this.label_D_Name.Text = "label2";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(315, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 17);
            this.label13.TabIndex = 84;
            this.label13.Text = "所在科室：";
            // 
            // label_D_Department
            // 
            this.label_D_Department.AutoSize = true;
            this.label_D_Department.Location = new System.Drawing.Point(389, 143);
            this.label_D_Department.Name = "label_D_Department";
            this.label_D_Department.Size = new System.Drawing.Size(41, 12);
            this.label_D_Department.TabIndex = 83;
            this.label_D_Department.Text = "label2";
            // 
            // label_Total
            // 
            this.label_Total.AutoSize = true;
            this.label_Total.Location = new System.Drawing.Point(371, 384);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(47, 12);
            this.label_Total.TabIndex = 96;
            this.label_Total.Text = "label15";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(291, 377);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 22);
            this.label16.TabIndex = 95;
            this.label16.Text = "总金额：";
            // 
            // Admin_Patient_Treatment_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 400);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label_Detail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listView_Inspections);
            this.Controls.Add(this.listView_Meds);
            this.Controls.Add(this.label_D_Department);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label_D_Name);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_T_Time);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_P_Name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_T_ID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_Patient_Treatment_Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Pat_Treatment_Detail";
            this.Load += new System.EventHandler(this.Admin_Patient_Treatment_Detail_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label_Detail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView listView_Inspections;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView listView_Meds;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label_T_Time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_P_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_T_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_D_Name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label_D_Department;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label16;
    }
}