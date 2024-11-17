namespace UC.UserControls
{
    partial class Uc_congViec
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_tieuDe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_ngayHetHan = new System.Windows.Forms.Label();
            this.check_hoanThanh = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_tieuDe
            // 
            this.lb_tieuDe.AutoSize = true;
            this.lb_tieuDe.Location = new System.Drawing.Point(3, 9);
            this.lb_tieuDe.Name = "lb_tieuDe";
            this.lb_tieuDe.Size = new System.Drawing.Size(56, 13);
            this.lb_tieuDe.TabIndex = 0;
            this.lb_tieuDe.Text = "Công Việc";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lb_ngayHetHan);
            this.panel1.Controls.Add(this.lb_tieuDe);
            this.panel1.Location = new System.Drawing.Point(32, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 57);
            this.panel1.TabIndex = 1;
            // 
            // lb_ngayHetHan
            // 
            this.lb_ngayHetHan.AutoSize = true;
            this.lb_ngayHetHan.Location = new System.Drawing.Point(3, 33);
            this.lb_ngayHetHan.Name = "lb_ngayHetHan";
            this.lb_ngayHetHan.Size = new System.Drawing.Size(61, 13);
            this.lb_ngayHetHan.TabIndex = 1;
            this.lb_ngayHetHan.Text = "01-01-2024";
            // 
            // check_hoanThanh
            // 
            this.check_hoanThanh.AutoSize = true;
            this.check_hoanThanh.Checked = true;
            this.check_hoanThanh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_hoanThanh.Location = new System.Drawing.Point(5, 20);
            this.check_hoanThanh.Name = "check_hoanThanh";
            this.check_hoanThanh.Size = new System.Drawing.Size(15, 14);
            this.check_hoanThanh.TabIndex = 4;
            this.check_hoanThanh.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.check_hoanThanh);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(24, 57);
            this.panel2.TabIndex = 5;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(7, 28);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(22, 23);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "🗑";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_edit);
            this.panel3.Controls.Add(this.btn_delete);
            this.panel3.Location = new System.Drawing.Point(265, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(38, 57);
            this.panel3.TabIndex = 6;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(7, 3);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(22, 23);
            this.btn_edit.TabIndex = 7;
            this.btn_edit.Text = "✏";
            this.btn_edit.UseVisualStyleBackColor = true;
            // 
            // Uc_congViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Uc_congViec";
            this.Size = new System.Drawing.Size(306, 64);
            this.Load += new System.EventHandler(this.Uc_congViec_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_tieuDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_ngayHetHan;
        private System.Windows.Forms.CheckBox check_hoanThanh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_edit;
    }
}
