
namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    partial class FormLogin
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
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.llbSignupInstead = new System.Windows.Forms.LinkLabel();
            this.lbNotif = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPassword.Location = new System.Drawing.Point(334, 127);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.PlaceholderText = "Enter your password here!";
            this.tbPassword.Size = new System.Drawing.Size(220, 25);
            this.tbPassword.TabIndex = 6;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbUsername.Location = new System.Drawing.Point(334, 78);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.PlaceholderText = "Enter your username here!";
            this.tbUsername.Size = new System.Drawing.Size(220, 25);
            this.tbUsername.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(230, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password:";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbUsername.Location = new System.Drawing.Point(225, 76);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(84, 21);
            this.lbUsername.TabIndex = 5;
            this.lbUsername.Text = "Username:";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.OldLace;
            this.btnLogin.Location = new System.Drawing.Point(299, 218);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(128, 40);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Log in";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // llbSignupInstead
            // 
            this.llbSignupInstead.AutoSize = true;
            this.llbSignupInstead.Location = new System.Drawing.Point(258, 261);
            this.llbSignupInstead.Name = "llbSignupInstead";
            this.llbSignupInstead.Size = new System.Drawing.Size(218, 15);
            this.llbSignupInstead.TabIndex = 10;
            this.llbSignupInstead.TabStop = true;
            this.llbSignupInstead.Text = "Don\'t have an account? Sign up instead.";
            this.llbSignupInstead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSignupInstead_LinkClicked);
            // 
            // lbNotif
            // 
            this.lbNotif.AutoSize = true;
            this.lbNotif.ForeColor = System.Drawing.Color.Red;
            this.lbNotif.Location = new System.Drawing.Point(334, 60);
            this.lbNotif.Name = "lbNotif";
            this.lbNotif.Size = new System.Drawing.Size(0, 15);
            this.lbNotif.TabIndex = 11;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lbNotif);
            this.Controls.Add(this.llbSignupInstead);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUsername);
            this.Name = "FormLogin";
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel llbSignupInstead;
        private System.Windows.Forms.Label lbNotif;
    }
}