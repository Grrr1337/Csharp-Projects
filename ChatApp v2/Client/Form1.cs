using System;
using System.Collections.Generic;
using System.ComponentModel;
// ClientForm.cs
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    public partial class ClientForm : Form
    {
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;
        private bool isConnected = false;

        public ClientForm()
        {
            InitializeComponent();
            this.Text = "Client";
            this.ShowIcon = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtboxPORT.Text = "80";
            // Automatically fill the local IP address
            txtboxIP.Text = GetLocalIpAddress();
        }

        private string GetLocalIpAddress()
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }
            return "127.0.0.1"; // Default to localhost if no suitable IP is found
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                ConnectToServer();
            }
        }

        private void ConnectToServer()
        {
            int port;
            if (int.TryParse(txtboxPORT.Text, out port))
            {
                try
                {
                    tcpClient = new TcpClient(txtboxIP.Text, port);
                    reader = new StreamReader(tcpClient.GetStream());
                    writer = new StreamWriter(tcpClient.GetStream());
                    writer.AutoFlush = true;
                    isConnected = true;

                    // Start a new thread to listen for incoming messages
                    Thread receiveThread = new Thread(new ThreadStart(ReceiveMessages));
                    receiveThread.Start();

                    // Notify the client that it's connected to the server
                    writer.WriteLine("Connected to the server.");

                    AddMessageToChatScreen("Connected to server.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Invalid port number.");
            }
        }

        private void ReceiveMessages()
        {
            try
            {
                while (isConnected)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        AddMessageToChatScreen(message);
                    }
                }
            }
            catch (IOException)
            {
                // Server disconnected
                isConnected = false;
                AddMessageToChatScreen("Disconnected from server.");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (isConnected && !string.IsNullOrWhiteSpace(rtbMessage.Text))
            {
                SendMessage(rtbMessage.Text);
                rtbMessage.Clear();
            }
        }

        private void SendMessage(string message)
        {
            writer.WriteLine(message);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (isConnected)
            {
                tcpClient.Close();
                isConnected = false;
                AddMessageToChatScreen("Disconnected from server.");
            }
        }

        private void AddMessageToChatScreen(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { AddMessageToChatScreen(message); }));
            }
            else
            {
                rtbChatScreen.AppendText(message + "\n");
            }
        }
    }
}

