using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Messanger
{
    public partial class Servidor : Form
    {
        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private Thread serverThread;

        public Servidor()
        {
            InitializeComponent();
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            serverThread = new Thread(StartServer);
            serverThread.IsBackground = true;
            serverThread.Start();
            btnStartServer.Enabled = false;
        }

        private void StartServer()
        {
            try
            {
                string localIP = GetLocalIPAddress();
                server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
                Invoke(new Action(() => listMessages.Items.Add($"Servidor iniciado en {localIP}:5000")));

                while (true)
                {
                    client = server.AcceptTcpClient();
                    stream = client.GetStream();
                    Invoke(new Action(() => listMessages.Items.Add("Cliente conectado.")));

                    Thread receiveThread = new Thread(ReceiveMessages);
                    receiveThread.IsBackground = true;
                    receiveThread.Start();
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Error: " + ex.Message)));
            }
        }

        private string GetLocalIPAddress()
        {
            string localIP = "";
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Invoke(new Action(() => listMessages.Items.Add("Cliente: " + message)));
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => listMessages.Items.Add("Error recibiendo mensaje: " + ex.Message)));
                    break;
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                try
                {
                    byte[] message = Encoding.UTF8.GetBytes(txtMessage.Text);
                    stream.Write(message, 0, message.Length);
                    Invoke(new Action(() => listMessages.Items.Add("Yo: " + txtMessage.Text)));
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() => MessageBox.Show("Error enviando mensaje: " + ex.Message)));
                }
            }
            else
            {
                MessageBox.Show("No estás conectado al servidor.");
            }
        }
    }
}