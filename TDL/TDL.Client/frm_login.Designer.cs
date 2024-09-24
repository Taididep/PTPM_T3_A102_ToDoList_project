namespace TDL.Client
{
    partial class frm_login
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
            this.uc_login1 = new TDL.Client.UserControls.uc_login();
            this.SuspendLayout();
            // 
            // uc_login1
            // 
            this.uc_login1.Location = new System.Drawing.Point(172, 58);
            this.uc_login1.Name = "uc_login1";
            this.uc_login1.Size = new System.Drawing.Size(205, 117);
            this.uc_login1.TabIndex = 0;
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 242);
            this.Controls.Add(this.uc_login1);
            this.Name = "frm_login";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.uc_login uc_login1;
    }
}

