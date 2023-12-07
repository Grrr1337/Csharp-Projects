// ServerForm.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    public partial class ServerForm : Form
    {
        private TcpListener tcpListener;
        private List<TcpClient> clients = new List<TcpClient>();
        private bool isServerRunning = false;
        private readonly object lockObject = new object();


        public ServerForm()
        {
            InitializeComponent();
            this.Text = "Server";
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Server started");
            if (!isServerRunning)
            {
                StartServer();
            }
        }

        private void StartServer()
        {
            isServerRunning = true;
            int port;

            if (int.TryParse(txtboxPORT.Text, out port))
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                try
                {
                    tcpListener.Start();

                    // Start a new thread to listen for incoming client connections
                    Thread listenerThread = new Thread(new ThreadStart(ListenForClients));
                    listenerThread.Start();

                    AddMessageToChatScreen("Server started. Waiting for connections...");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error starting server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isServerRunning = false;
                }
            }
            else
            {
                MessageBox.Show("Invalid port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void StopServer()
        {
            isServerRunning = false;
            try
            {
                tcpListener.Stop();
                AddMessageToChatScreen("Server stopped.");

                // Close all client connections
                lock (lockObject)
                {
                    foreach (TcpClient client in clients)
                    {
                        client.Close();
                    }
                    clients.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping server: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListenForClients()
        {
            while (isServerRunning)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                lock (lockObject)
                {
                    clients.Add(client);
                }

                // Notify that a new client has joined
                NotifyClientJoin(client);

                // Start a new thread to handle the client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object clientObj)
        {
            TcpClient tcpClient = (TcpClient)clientObj;
            StreamReader reader = new StreamReader(tcpClient.GetStream());
            try
            {
                while (isServerRunning)
                {
                    string message = reader.ReadLine();
                    if (message != null)
                    {
                        // Extract the port number as the "username"
                        IPEndPoint clientEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                        string username = clientEndPoint.Port.ToString();

                        // Broadcast the message with the username
                        BroadcastMessage($"{username}: {message}");
                    }
                }
            }
            catch (IOException)
            {
                // Client disconnected
                lock (lockObject)
                {
                    clients.Remove(tcpClient);
                }

                // Extract the port number as the "username"
                IPEndPoint clientEndPoint = (IPEndPoint)tcpClient.Client.RemoteEndPoint;
                string username = clientEndPoint.Port.ToString();

                // Notify that the client has left
                NotifyClientLeave(tcpClient);
            }
        }


        private void NotifyClientLeave(TcpClient client)
        {
            // Get the client's IP address and port
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            string clientInfo = $"{clientEndPoint.Address}:{clientEndPoint.Port}";
            string username = clientEndPoint.Port.ToString();

            // Notify in the chat screen that a client has left
            // AddMessageToChatScreen($"Client {clientInfo} left.");
            AddMessageToChatScreen($"Client {username} left.");
        }


        private void NotifyClientJoin(TcpClient client)
        {


            // Get the client's IP address and port
            // IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            // string clientInfo = $"{clientEndPoint.Address}:{clientEndPoint.Port}";

            // Notify in the chat screen that a new client has joined
            // AddMessageToChatScreen($"Client {clientInfo} joined.");


            // Get the client's IP address and port
            IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

            // Extract the port number as the "username"
            string username = clientEndPoint.Port.ToString();

            // Notify in the chat screen that a new client has joined
            AddMessageToChatScreen($"Client {username} joined.");
        }


        private void BroadcastMessage(string message)
        {
            lock (lockObject)
            {
                foreach (TcpClient client in clients)
                {
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.WriteLine(message);
                    writer.Flush();
                }
            }

            AddMessageToChatScreen(message);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isServerRunning)
            {
                StopServer();
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

