namespace UC
{
    partial class Uc_login
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
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.Btn_login = new System.Windows.Forms.Button();
            this.txt_username = new UC.Controls.Txt_username();
            this.txt_password = new UC.Controls.Txt_password();
            this.SuspendLayout();
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Location = new System.Drawing.Point(30, 27);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(55, 13);
            this.lb_username.TabIndex = 2;
            this.lb_username.Text = "Username";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.Location = new System.Drawing.Point(30, 60);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(53, 13);
            this.lb_password.TabIndex = 3;
            this.lb_password.Text = "Password";
            // 
            // Btn_login
            // 
            this.Btn_login.Location = new System.Drawing.Point(154, 92);
            this.Btn_login.Name = "Btn_login";
            this.Btn_login.Size = new System.Drawing.Size(75, 23);
            this.Btn_login.TabIndex = 4;
            this.Btn_login.Text = "Login";
            this.Btn_login.UseVisualStyleBackColor = true;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(91, 24);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(138, 20);
            this.txt_username.TabIndex = 1;
            this.txt_username.Text = "admin";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(91, 57);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(138, 20);
            this.txt_password.TabIndex = 0;
            this.txt_password.Text = "123456";
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // Uc_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_login);
            this.Controls.Add(this.lb_password);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.txt_password);
            this.Name = "Uc_login";
            this.Size = new System.Drawing.Size(272, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.Txt_password txt_password;
        private Controls.Txt_username txt_username;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Button Btn_login;
    }
}
