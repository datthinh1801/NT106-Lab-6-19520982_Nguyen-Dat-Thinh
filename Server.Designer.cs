
namespace Lab5_19520982_Nguyen_Dat_Thinh
{
    partial class Server
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
            this.lbUserCountHeader = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lbNumRoomHeader = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lbUserCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRoomCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUserCountHeader
            // 
            this.lbUserCountHeader.AutoSize = true;
            this.lbUserCountHeader.Location = new System.Drawing.Point(638, 23);
            this.lbUserCountHeader.Name = "lbUserCountHeader";
            this.lbUserCountHeader.Size = new System.Drawing.Size(98, 15);
            this.lbUserCountHeader.TabIndex = 1;
            this.lbUserCountHeader.Text = "Number of users:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(663, 352);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(113, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(663, 398);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(113, 40);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lbNumRoomHeader
            // 
            this.lbNumRoomHeader.AutoSize = true;
            this.lbNumRoomHeader.Location = new System.Drawing.Point(638, 84);
            this.lbNumRoomHeader.Name = "lbNumRoomHeader";
            this.lbNumRoomHeader.Size = new System.Drawing.Size(139, 15);
            this.lbNumRoomHeader.TabIndex = 1;
            this.lbNumRoomHeader.Text = "Number of active rooms:";
            // 
            // rtbLog
            // 
            this.rtbLog.Location = new System.Drawing.Point(14, 23);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(612, 414);
            this.rtbLog.TabIndex = 3;
            this.rtbLog.Text = "";
            // 
            // lbUserCount
            // 
            this.lbUserCount.AutoSize = true;
            this.lbUserCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbUserCount.Location = new System.Drawing.Point(638, 48);
            this.lbUserCount.Name = "lbUserCount";
            this.lbUserCount.Size = new System.Drawing.Size(19, 21);
            this.lbUserCount.TabIndex = 4;
            this.lbUserCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(638, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // lbRoomCount
            // 
            this.lbRoomCount.AutoSize = true;
            this.lbRoomCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbRoomCount.Location = new System.Drawing.Point(638, 111);
            this.lbRoomCount.Name = "lbRoomCount";
            this.lbRoomCount.Size = new System.Drawing.Size(19, 21);
            this.lbRoomCount.TabIndex = 4;
            this.lbRoomCount.Text = "0";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRoomCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbUserCount);
            this.Controls.Add(this.rtbLog);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lbNumRoomHeader);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbUserCountHeader);
            this.Name = "Server";
            this.Text = "Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbUserCountHeader;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lbNumRoomHeader;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.Label lbUserCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRoomCount;
    }
}