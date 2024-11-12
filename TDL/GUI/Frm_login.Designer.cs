namespace GUI
{
    partial class Frm_login
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
            this.uc_login = new UC.Uc_login();
            this.SuspendLayout();
            // 
            // uc_login
            // 
            this.uc_login.Location = new System.Drawing.Point(12, 12);
            this.uc_login.Name = "uc_login";
            this.uc_login.Size = new System.Drawing.Size(272, 140);
            this.uc_login.TabIndex = 1;
            // 
            // Frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 163);
            this.Controls.Add(this.uc_login);
            this.Name = "Frm_login";
            this.Text = "Frm_login";
            this.ResumeLayout(false);

        }

        #endregion

        private UC.Uc_login uc_login;
    }
}