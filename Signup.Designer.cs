
namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    partial class FormSignup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSignup = new System.Windows.Forms.Button();
            this.lbUsername = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRePassword = new System.Windows.Forms.TextBox();
            this.llbLoginInstead = new System.Windows.Forms.LinkLabel();
            this.lbCredentialNotif = new System.Windows.Forms.Label();
            this.lbDupPassNotif = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSignup
            // 
            this.btnSignup.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSignup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSignup.ForeColor = System.Drawing.Color.OldLace;
            this.btnSignup.Location = new System.Drawing.Point(319, 278);
            this.btnSignup.Name = "btnSignup";
            this.btnSignup.Size = new System.Drawing.Size(128, 40);
            this.btnSignup.TabIndex = 0;
            this.btnSignup.Text = "Sign up";
            this.btnSignup.UseVisualStyleBackColor = false;
            this.btnSignup.Click += new System.EventHandler(this.btnSignup_Click);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbUsername.Location = new System.Drawing.Point(260, 73);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(84, 21);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Username:";
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbUsername.Location = new System.Drawing.Point(369, 75);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.PlaceholderText = "Enter your username here!";
            this.tbUsername.Size = new System.Drawing.Size(235, 25);
            this.tbUsername.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(265, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPassword.Location = new System.Drawing.Point(369, 130);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.PlaceholderText = "Enter your password here!";
            this.tbPassword.Size = new System.Drawing.Size(235, 25);
            this.tbPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(200, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Re-enter password:";
            // 
            // tbRePassword
            // 
            this.tbRePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRePassword.Location = new System.Drawing.Point(369, 183);
            this.tbRePassword.Name = "tbRePassword";
            this.tbRePassword.PasswordChar = '*';
            this.tbRePassword.PlaceholderText = "Re-enter your password here!";
            this.tbRePassword.Size = new System.Drawing.Size(235, 25);
            this.tbRePassword.TabIndex = 2;
            // 
            // llbLoginInstead
            // 
            this.llbLoginInstead.AutoSize = true;
            this.llbLoginInstead.Location = new System.Drawing.Point(273, 321);
            this.llbLoginInstead.Name = "llbLoginInstead";
            this.llbLoginInstead.Size = new System.Drawing.Size(219, 15);
            this.llbLoginInstead.TabIndex = 4;
            this.llbLoginInstead.TabStop = true;
            this.llbLoginInstead.Text = "Already have an account? Login instead.";
            this.llbLoginInstead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbLoginInstead_LinkClicked);
            // 
            // lbCredentialNotif
            // 
            this.lbCredentialNotif.AutoSize = true;
            this.lbCredentialNotif.ForeColor = System.Drawing.Color.Red;
            this.lbCredentialNotif.Location = new System.Drawing.Point(369, 58);
            this.lbCredentialNotif.Name = "lbCredentialNotif";
            this.lbCredentialNotif.Size = new System.Drawing.Size(0, 15);
            this.lbCredentialNotif.TabIndex = 5;
            // 
            // lbDupPassNotif
            // 
            this.lbDupPassNotif.AutoSize = true;
            this.lbDupPassNotif.ForeColor = System.Drawing.Color.Red;
            this.lbDupPassNotif.Location = new System.Drawing.Point(369, 164);
            this.lbDupPassNotif.Name = "lbDupPassNotif";
            this.lbDupPassNotif.Size = new System.Drawing.Size(0, 15);
            this.lbDupPassNotif.TabIndex = 6;
            // 
            // FormSignup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lbDupPassNotif);
            this.Controls.Add(this.lbCredentialNotif);
            this.Controls.Add(this.llbLoginInstead);
            this.Controls.Add(this.tbRePassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.btnSignup);
            this.Name = "FormSignup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign up";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSignup;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRePassword;
        private System.Windows.Forms.LinkLabel llbLoginInstead;
        private System.Windows.Forms.Label lbCredentialNotif;
        private System.Windows.Forms.Label lbDupPassNotif;
    }
}

