namespace TDL.Client
{
    partial class frm_main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nguoiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhomNguoiDungToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manHinhChucNangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themNguoiDungVaoNhomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phanQuyenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiepVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thongKeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongToolStripMenuItem,
            this.nghiepVuToolStripMenuItem,
            this.thongKeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nguoiDungToolStripMenuItem,
            this.nhomNguoiDungToolStripMenuItem,
            this.manHinhChucNangToolStripMenuItem,
            this.themNguoiDungVaoNhomToolStripMenuItem,
            this.phanQuyenToolStripMenuItem});
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.heThongToolStripMenuItem.Text = "he thong";
            // 
            // nguoiDungToolStripMenuItem
            // 
            this.nguoiDungToolStripMenuItem.Name = "nguoiDungToolStripMenuItem";
            this.nguoiDungToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.nguoiDungToolStripMenuItem.Tag = "SF001";
            this.nguoiDungToolStripMenuItem.Text = "nguoi dung";
            this.nguoiDungToolStripMenuItem.Click += new System.EventHandler(this.nguoiDungToolStripMenuItem_Click);
            // 
            // nhomNguoiDungToolStripMenuItem
            // 
            this.nhomNguoiDungToolStripMenuItem.Name = "nhomNguoiDungToolStripMenuItem";
            this.nhomNguoiDungToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.nhomNguoiDungToolStripMenuItem.Tag = "SF002";
            this.nhomNguoiDungToolStripMenuItem.Text = "nhom nguoi dung";
            // 
            // manHinhChucNangToolStripMenuItem
            // 
            this.manHinhChucNangToolStripMenuItem.Name = "manHinhChucNangToolStripMenuItem";
            this.manHinhChucNangToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.manHinhChucNangToolStripMenuItem.Tag = "SF003";
            this.manHinhChucNangToolStripMenuItem.Text = "man hinh chuc nang";
            // 
            // themNguoiDungVaoNhomToolStripMenuItem
            // 
            this.themNguoiDungVaoNhomToolStripMenuItem.Name = "themNguoiDungVaoNhomToolStripMenuItem";
            this.themNguoiDungVaoNhomToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.themNguoiDungVaoNhomToolStripMenuItem.Tag = "SF004";
            this.themNguoiDungVaoNhomToolStripMenuItem.Text = "them nguoi dung vao nhom";
            this.themNguoiDungVaoNhomToolStripMenuItem.Click += new System.EventHandler(this.themNguoiDungVaoNhomToolStripMenuItem_Click);
            // 
            // phanQuyenToolStripMenuItem
            // 
            this.phanQuyenToolStripMenuItem.Name = "phanQuyenToolStripMenuItem";
            this.phanQuyenToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.phanQuyenToolStripMenuItem.Tag = "SF005";
            this.phanQuyenToolStripMenuItem.Text = "phan quyen";
            // 
            // nghiepVuToolStripMenuItem
            // 
            this.nghiepVuToolStripMenuItem.Name = "nghiepVuToolStripMenuItem";
            this.nghiepVuToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.nghiepVuToolStripMenuItem.Text = "nghiep vu";
            // 
            // thongKeToolStripMenuItem
            // 
            this.thongKeToolStripMenuItem.Name = "thongKeToolStripMenuItem";
            this.thongKeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.thongKeToolStripMenuItem.Text = "thong ke";
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.Text = "frm_Main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_main_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem heThongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nguoiDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhomNguoiDungToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manHinhChucNangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themNguoiDungVaoNhomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phanQuyenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghiepVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thongKeToolStripMenuItem;
    }
}