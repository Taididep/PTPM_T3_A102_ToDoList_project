namespace GUI
{
    partial class Frm_main
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
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.flp_congViec = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_danhMuc = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(270, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(26, 31);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 23);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // flp_congViec
            // 
            this.flp_congViec.Location = new System.Drawing.Point(12, 60);
            this.flp_congViec.Name = "flp_congViec";
            this.flp_congViec.Size = new System.Drawing.Size(322, 344);
            this.flp_congViec.TabIndex = 4;
            // 
            // flp_danhMuc
            // 
            this.flp_danhMuc.Location = new System.Drawing.Point(12, 410);
            this.flp_danhMuc.Name = "flp_danhMuc";
            this.flp_danhMuc.Size = new System.Drawing.Size(322, 41);
            this.flp_danhMuc.TabIndex = 5;            // 
            // Frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 729);
            this.Controls.Add(this.flp_danhMuc);
            this.Controls.Add(this.flp_congViec);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Name = "Frm_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Frm_main_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FlowLayoutPanel flp_congViec;
        private System.Windows.Forms.FlowLayoutPanel flp_danhMuc;
    }
}

