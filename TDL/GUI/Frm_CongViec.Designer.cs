namespace GUI
{
    partial class Frm_CongViec
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
            this.txt_tieuDe = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dtp_ngayHetHan1 = new UC.Controls.dtp_ngayHetHan();
            this.SuspendLayout();
            // 
            // txt_tieuDe
            // 
            this.txt_tieuDe.Location = new System.Drawing.Point(12, 12);
            this.txt_tieuDe.Name = "txt_tieuDe";
            this.txt_tieuDe.Size = new System.Drawing.Size(347, 20);
            this.txt_tieuDe.TabIndex = 0;
            this.txt_tieuDe.Text = "Tiêu đề";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 65);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(346, 361);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "*Nội dung*";
            // 
            // dtp_ngayHetHan1
            // 
            this.dtp_ngayHetHan1.CustomFormat = "dddd dd/MM/yyyy";
            this.dtp_ngayHetHan1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_ngayHetHan1.Location = new System.Drawing.Point(13, 39);
            this.dtp_ngayHetHan1.Name = "dtp_ngayHetHan1";
            this.dtp_ngayHetHan1.Size = new System.Drawing.Size(145, 20);
            this.dtp_ngayHetHan1.TabIndex = 3;
            // 
            // Frm_CongViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 440);
            this.Controls.Add(this.dtp_ngayHetHan1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txt_tieuDe);
            this.Name = "Frm_CongViec";
            this.Text = "Frm_CongViec";
            this.Load += new System.EventHandler(this.Frm_CongViec_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_tieuDe;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private UC.Controls.dtp_ngayHetHan dtp_ngayHetHan1;
    }
}