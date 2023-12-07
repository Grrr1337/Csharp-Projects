using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

/*
    Chat Application

    This C# Windows Forms application implements a simple chat program allowing communication between two instances: 
    one acting as the server and the other as the client. The program utilizes TCP/IP sockets for communication.

    Features:
    - Run one instance as the server to start listening for connections.
    - Run another instance as the client to connect to the server.
    - Send and receive text messages between the server and client.

    Usage Instructions:
    1. Run the server instance, input the desired port, and click "Start."
    2. Run the client instance, input the server's IP address and port, and click "Connect."
    3. Type messages in the lower text area, click "Send," and view the chat history in the upper text area.

    Troubleshooting:
    - If the program freezes during server startup, ensure the specified port is available.
    - For connection issues, double-check the IP address and port when connecting as a client.

    Dependencies:
    - .NET Framework v4.8

    Author: Grrr1337

    How to Use:
    - See README.md for detailed instructions.

    Additional Notes:
    - Customize the application as needed.
*/

namespace ChatApp
{
    public partial class ChatAppForm : Form
    {
        private TcpClient client;
        public StreamReader STR;
        public StreamWriter STW;
        public string recieve;
        public string TextToSend;

        public ChatAppForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ClientPortTxtbox.Text = "80";
            this.ServerPortTxtbox.Text = "80";

            // Automatically detect and set the local IP address
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(IPAddress address in localIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIPtxtbox.Text = address.ToString();
                }
            }

        }

        private void ServerStart_Click(object sender, EventArgs e)
        {
            // Start the server on a separate thread
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(ServerPortTxtbox.Text));
            listener.Start();

            // Run the blocking operation of accepting clients on a separate thread
            Task.Run(() =>
            {
                client = listener.AcceptTcpClient();
                STR = new StreamReader(client.GetStream());
                STW = new StreamWriter(client.GetStream(), Encoding.UTF8);
                STW.AutoFlush = true;

                // Start background worker for receiving messages
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            });
        }

        private void ClientConnect_Click(object sender, EventArgs e)
        {
            // Connect to the server as a client
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ClientIPtxtbox.Text), int.Parse(ClientPortTxtbox.Text));

            try
            {
                // Attempt to connect to the server
                client.Connect(IpEnd);  
                rtbChatScreen.AppendText("Connected to Server" + "\n");

                // Initialize stream readers and writers for communication
                STW = new StreamWriter(client.GetStream());
                STR = new StreamReader(client.GetStream());
                STW.AutoFlush = true;

                // Start background worker for receiving messages
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.WorkerSupportsCancellation = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Background worker for receiving messages
            while (client.Connected)
            {
                try
                {
                    // Receive and display messages from the server
                    recieve = STR.ReadLine();
                    this.rtbChatScreen.Invoke(new MethodInvoker(delegate ()
                    {
                        rtbChatScreen.AppendText("You: " + recieve + "\n");
                    }));
                    recieve = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            // Background worker for sending messages
            try
            {
                if (client.Connected)
                {
                    // Send the message to the server and update the UI
                    STW.WriteLine(TextToSend);
                    this.rtbChatScreen.Invoke(new MethodInvoker(() =>
                    {
                        rtbChatScreen.AppendText("Me: " + TextToSend + "\n");
                    }));
                }
                else
                {
                    MessageBox.Show("Sending Failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                // Cancel the background worker
                backgroundWorker2.CancelAsync();
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            // Send the message when the "Send" button is clicked
            if (rtbMessage.Text != "")
            {
                TextToSend = rtbMessage.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            rtbMessage.Text = "";
        }
    }
}
