namespace Server
{
    partial class ServerForm
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
            this.txtboxIP = new System.Windows.Forms.TextBox();
            this.txtboxPORT = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.rtbChatScreen = new System.Windows.Forms.RichTextBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.groupBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtboxIP
            // 
            this.txtboxIP.Location = new System.Drawing.Point(47, 24);
            this.txtboxIP.Name = "txtboxIP";
            this.txtboxIP.Size = new System.Drawing.Size(131, 20);
            this.txtboxIP.TabIndex = 0;
            // 
            // txtboxPORT
            // 
            this.txtboxPORT.Location = new System.Drawing.Point(216, 24);
            this.txtboxPORT.Name = "txtboxPORT";
            this.txtboxPORT.Size = new System.Drawing.Size(80, 20);
            this.txtboxPORT.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(353, 19);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(85, 30);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(458, 19);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(85, 30);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // rtbChatScreen
            // 
            this.rtbChatScreen.Location = new System.Drawing.Point(12, 84);
            this.rtbChatScreen.Name = "rtbChatScreen";
            this.rtbChatScreen.Size = new System.Drawing.Size(560, 345);
            this.rtbChatScreen.TabIndex = 4;
            this.rtbChatScreen.Text = "";
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.lblPort);
            this.groupBoxServer.Controls.Add(this.lblIP);
            this.groupBoxServer.Controls.Add(this.txtboxIP);
            this.groupBoxServer.Controls.Add(this.txtboxPORT);
            this.groupBoxServer.Controls.Add(this.btnStop);
            this.groupBoxServer.Controls.Add(this.btnStart);
            this.groupBoxServer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(560, 66);
            this.groupBoxServer.TabIndex = 5;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Server controls";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(184, 28);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(26, 13);
            this.lblPort.TabIndex = 5;
            this.lblPort.Text = "Port";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(10, 28);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 13);
            this.lblIP.TabIndex = 4;
            this.lblIP.Text = "IP";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.groupBoxServer);
            this.Controls.Add(this.rtbChatScreen);
            this.Name = "ServerForm";
            this.ShowIcon = false;
            this.Text = "Server";
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxIP;
        private System.Windows.Forms.TextBox txtboxPORT;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox rtbChatScreen;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblIP;
    }
}

