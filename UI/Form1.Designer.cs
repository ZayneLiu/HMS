namespace UI
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.在此登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.医生登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者登陆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者注册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在此登陆ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 在此登陆ToolStripMenuItem
            // 
            this.在此登陆ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.医生登陆ToolStripMenuItem,
            this.患者登陆ToolStripMenuItem,
            this.患者注册ToolStripMenuItem});
            this.在此登陆ToolStripMenuItem.Name = "在此登陆ToolStripMenuItem";
            this.在此登陆ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.在此登陆ToolStripMenuItem.Text = "在此登陆";
            // 
            // 医生登陆ToolStripMenuItem
            // 
            this.医生登陆ToolStripMenuItem.Name = "医生登陆ToolStripMenuItem";
            this.医生登陆ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.医生登陆ToolStripMenuItem.Text = "医生登陆";
            this.医生登陆ToolStripMenuItem.Click += new System.EventHandler(this.医生登陆ToolStripMenuItem_Click);
            // 
            // 患者登陆ToolStripMenuItem
            // 
            this.患者登陆ToolStripMenuItem.Name = "患者登陆ToolStripMenuItem";
            this.患者登陆ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.患者登陆ToolStripMenuItem.Text = "患者登陆";
            this.患者登陆ToolStripMenuItem.Click += new System.EventHandler(this.患者登陆ToolStripMenuItem_Click);
            // 
            // 患者注册ToolStripMenuItem
            // 
            this.患者注册ToolStripMenuItem.Name = "患者注册ToolStripMenuItem";
            this.患者注册ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.患者注册ToolStripMenuItem.Text = "患者注册";
            this.患者注册ToolStripMenuItem.Click += new System.EventHandler(this.患者注册ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 在此登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 医生登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者登陆ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 患者注册ToolStripMenuItem;
    }
}

