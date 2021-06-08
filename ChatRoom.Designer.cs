
namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    partial class ChatRoom
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
            this.rtbInbox = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewPeers = new System.Windows.Forms.ListView();
            this.lbRoomCode = new System.Windows.Forms.Label();
            this.rtbTyping = new System.Windows.Forms.RichTextBox();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbErrorNotif = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbInbox
            // 
            this.rtbInbox.Location = new System.Drawing.Point(36, 46);
            this.rtbInbox.Name = "rtbInbox";
            this.rtbInbox.ReadOnly = true;
            this.rtbInbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbInbox.Size = new System.Drawing.Size(597, 335);
            this.rtbInbox.TabIndex = 0;
            this.rtbInbox.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(653, 402);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(103, 44);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Room code:";
            // 
            // listViewPeers
            // 
            this.listViewPeers.HideSelection = false;
            this.listViewPeers.Location = new System.Drawing.Point(653, 75);
            this.listViewPeers.Name = "listViewPeers";
            this.listViewPeers.Size = new System.Drawing.Size(103, 306);
            this.listViewPeers.TabIndex = 3;
            this.listViewPeers.TileSize = new System.Drawing.Size(40, 20);
            this.listViewPeers.UseCompatibleStateImageBehavior = false;
            this.listViewPeers.View = System.Windows.Forms.View.List;
            // 
            // lbRoomCode
            // 
            this.lbRoomCode.AutoSize = true;
            this.lbRoomCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRoomCode.Location = new System.Drawing.Point(657, 24);
            this.lbRoomCode.Name = "lbRoomCode";
            this.lbRoomCode.Size = new System.Drawing.Size(0, 19);
            this.lbRoomCode.TabIndex = 4;
            // 
            // rtbTyping
            // 
            this.rtbTyping.Location = new System.Drawing.Point(36, 402);
            this.rtbTyping.Name = "rtbTyping";
            this.rtbTyping.Size = new System.Drawing.Size(597, 44);
            this.rtbTyping.TabIndex = 5;
            this.rtbTyping.Text = "";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbTitle.Location = new System.Drawing.Point(227, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(253, 21);
            this.lbTitle.TabIndex = 6;
            this.lbTitle.Text = "Supremely Powerful Chat Room";
            // 
            // lbErrorNotif
            // 
            this.lbErrorNotif.AutoSize = true;
            this.lbErrorNotif.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNotif.Location = new System.Drawing.Point(36, 384);
            this.lbErrorNotif.Name = "lbErrorNotif";
            this.lbErrorNotif.Size = new System.Drawing.Size(0, 15);
            this.lbErrorNotif.TabIndex = 7;
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbUsername.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbUsername.Location = new System.Drawing.Point(36, 15);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(0, 15);
            this.lbUsername.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(653, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Active users:";
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lbErrorNotif);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.rtbTyping);
            this.Controls.Add(this.lbRoomCode);
            this.Controls.Add(this.listViewPeers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbInbox);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatRoom_FormClosing);
            this.Load += new System.EventHandler(this.ChatRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbInbox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewPeers;
        private System.Windows.Forms.Label lbRoomCode;
        private System.Windows.Forms.RichTextBox rtbTyping;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbErrorNotif;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label label2;
    }
}