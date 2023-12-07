namespace ChatApp
{
    partial class ChatAppForm
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
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.lblServerPORT = new System.Windows.Forms.Label();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.ServerStart = new System.Windows.Forms.Button();
            this.ServerPortTxtbox = new System.Windows.Forms.TextBox();
            this.ServerIPtxtbox = new System.Windows.Forms.TextBox();
            this.groupBoxClient = new System.Windows.Forms.GroupBox();
            this.lblClientPORT = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this.ClientConnect = new System.Windows.Forms.Button();
            this.ClientPortTxtbox = new System.Windows.Forms.TextBox();
            this.ClientIPtxtbox = new System.Windows.Forms.TextBox();
            this.rtbChatScreen = new System.Windows.Forms.RichTextBox();
            this.rtbMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.groupBoxServer.SuspendLayout();
            this.groupBoxClient.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Controls.Add(this.lblServerPORT);
            this.groupBoxServer.Controls.Add(this.lblServerIP);
            this.groupBoxServer.Controls.Add(this.ServerStart);
            this.groupBoxServer.Controls.Add(this.ServerPortTxtbox);
            this.groupBoxServer.Controls.Add(this.ServerIPtxtbox);
            this.groupBoxServer.Location = new System.Drawing.Point(12, 12);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(530, 100);
            this.groupBoxServer.TabIndex = 0;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "Server";
            // 
            // lblServerPORT
            // 
            this.lblServerPORT.AutoSize = true;
            this.lblServerPORT.Location = new System.Drawing.Point(241, 37);
            this.lblServerPORT.Name = "lblServerPORT";
            this.lblServerPORT.Size = new System.Drawing.Size(37, 13);
            this.lblServerPORT.TabIndex = 4;
            this.lblServerPORT.Text = "PORT";
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(42, 44);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(17, 13);
            this.lblServerIP.TabIndex = 3;
            this.lblServerIP.Text = "IP";
            // 
            // ServerStart
            // 
            this.ServerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerStart.Location = new System.Drawing.Point(403, 26);
            this.ServerStart.Name = "ServerStart";
            this.ServerStart.Size = new System.Drawing.Size(100, 35);
            this.ServerStart.TabIndex = 2;
            this.ServerStart.Text = "START";
            this.ServerStart.UseVisualStyleBackColor = true;
            this.ServerStart.Click += new System.EventHandler(this.ServerStart_Click);
            // 
            // ServerPortTxtbox
            // 
            this.ServerPortTxtbox.Location = new System.Drawing.Point(284, 37);
            this.ServerPortTxtbox.Name = "ServerPortTxtbox";
            this.ServerPortTxtbox.Size = new System.Drawing.Size(76, 20);
            this.ServerPortTxtbox.TabIndex = 1;
            // 
            // ServerIPtxtbox
            // 
            this.ServerIPtxtbox.Location = new System.Drawing.Point(65, 37);
            this.ServerIPtxtbox.Name = "ServerIPtxtbox";
            this.ServerIPtxtbox.Size = new System.Drawing.Size(142, 20);
            this.ServerIPtxtbox.TabIndex = 0;
            // 
            // groupBoxClient
            // 
            this.groupBoxClient.Controls.Add(this.lblClientPORT);
            this.groupBoxClient.Controls.Add(this.lblClientIP);
            this.groupBoxClient.Controls.Add(this.ClientConnect);
            this.groupBoxClient.Controls.Add(this.ClientPortTxtbox);
            this.groupBoxClient.Controls.Add(this.ClientIPtxtbox);
            this.groupBoxClient.Location = new System.Drawing.Point(12, 118);
            this.groupBoxClient.Name = "groupBoxClient";
            this.groupBoxClient.Size = new System.Drawing.Size(530, 100);
            this.groupBoxClient.TabIndex = 1;
            this.groupBoxClient.TabStop = false;
            this.groupBoxClient.Text = "Client";
            // 
            // lblClientPORT
            // 
            this.lblClientPORT.AutoSize = true;
            this.lblClientPORT.Location = new System.Drawing.Point(241, 48);
            this.lblClientPORT.Name = "lblClientPORT";
            this.lblClientPORT.Size = new System.Drawing.Size(37, 13);
            this.lblClientPORT.TabIndex = 4;
            this.lblClientPORT.Text = "PORT";
            // 
            // lblClientIP
            // 
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(42, 53);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(17, 13);
            this.lblClientIP.TabIndex = 3;
            this.lblClientIP.Text = "IP";
            // 
            // ClientConnect
            // 
            this.ClientConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClientConnect.Location = new System.Drawing.Point(403, 37);
            this.ClientConnect.Name = "ClientConnect";
            this.ClientConnect.Size = new System.Drawing.Size(100, 35);
            this.ClientConnect.TabIndex = 2;
            this.ClientConnect.Text = "CONNECT";
            this.ClientConnect.UseVisualStyleBackColor = true;
            this.ClientConnect.Click += new System.EventHandler(this.ClientConnect_Click);
            // 
            // ClientPortTxtbox
            // 
            this.ClientPortTxtbox.Location = new System.Drawing.Point(284, 45);
            this.ClientPortTxtbox.Name = "ClientPortTxtbox";
            this.ClientPortTxtbox.Size = new System.Drawing.Size(76, 20);
            this.ClientPortTxtbox.TabIndex = 1;
            // 
            // ClientIPtxtbox
            // 
            this.ClientIPtxtbox.Location = new System.Drawing.Point(65, 48);
            this.ClientIPtxtbox.Name = "ClientIPtxtbox";
            this.ClientIPtxtbox.Size = new System.Drawing.Size(142, 20);
            this.ClientIPtxtbox.TabIndex = 0;
            // 
            // rtbChatScreen
            // 
            this.rtbChatScreen.Location = new System.Drawing.Point(12, 224);
            this.rtbChatScreen.Name = "rtbChatScreen";
            this.rtbChatScreen.Size = new System.Drawing.Size(765, 282);
            this.rtbChatScreen.TabIndex = 2;
            this.rtbChatScreen.Text = "";
            // 
            // rtbMessage
            // 
            this.rtbMessage.Location = new System.Drawing.Point(12, 512);
            this.rtbMessage.Name = "rtbMessage";
            this.rtbMessage.Size = new System.Drawing.Size(589, 88);
            this.rtbMessage.TabIndex = 3;
            this.rtbMessage.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSend.Location = new System.Drawing.Point(607, 512);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(170, 88);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.lblAuthor);
            this.groupBoxInfo.Controls.Add(this.lblInfo);
            this.groupBoxInfo.Location = new System.Drawing.Point(548, 12);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(229, 206);
            this.groupBoxInfo.TabIndex = 5;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "App Info";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuthor.Location = new System.Drawing.Point(17, 106);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(133, 36);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "Author:\r\nVladimir Balabanov\r\n";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(17, 31);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(188, 54);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Application:\r\nClient Server programming \r\n( Chat Application )";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // ChatAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.rtbMessage);
            this.Controls.Add(this.rtbChatScreen);
            this.Controls.Add(this.groupBoxClient);
            this.Controls.Add(this.groupBoxServer);
            this.Name = "ChatAppForm";
            this.ShowIcon = false;
            this.Text = "Chat Application";
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.groupBoxClient.ResumeLayout(false);
            this.groupBoxClient.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Label lblServerPORT;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Button ServerStart;
        private System.Windows.Forms.TextBox ServerPortTxtbox;
        private System.Windows.Forms.TextBox ServerIPtxtbox;
        private System.Windows.Forms.GroupBox groupBoxClient;
        private System.Windows.Forms.Label lblClientPORT;
        private System.Windows.Forms.Label lblClientIP;
        private System.Windows.Forms.Button ClientConnect;
        private System.Windows.Forms.TextBox ClientPortTxtbox;
        private System.Windows.Forms.TextBox ClientIPtxtbox;
        private System.Windows.Forms.RichTextBox rtbChatScreen;
        private System.Windows.Forms.RichTextBox rtbMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

