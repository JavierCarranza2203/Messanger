using System;
using System.Collections.Generic;
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
        private List<TcpClient> clients = new List<TcpClient>();
        private List<string> clientIPs = new List<string>(); // Para mostrar las IPs de los clientes
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
                    try
                    {
                        TcpClient client = server.AcceptTcpClient();
                        IPEndPoint clientEndPoint = (IPEndPoint)client.Client.RemoteEndPoint;

                        lock (clients)
                        {
                            clients.Add(client);
                            clientIPs.Add(clientEndPoint.Address.ToString());
                        }

                        Invoke(new Action(() => listMessages.Items.Add($"Cliente conectado desde {clientEndPoint.Address}")));

                        Thread clientThread = new Thread(() => HandleClient(client, clientEndPoint.Address.ToString()));
                        clientThread.IsBackground = true;
                        clientThread.Start();
                    }
                    catch (SocketException se)
                    {
                        Invoke(new Action(() => listMessages.Items.Add("Error al aceptar cliente: " + se.Message)));
                    }
                }
            }
            catch (Exception ex)
            {
                Invoke(new Action(() => MessageBox.Show("Error: " + ex.Message)));
            }
        }


        private void HandleClient(TcpClient client, string clientIP)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string fullMessage = $"{ServicioDeEncriptado.DecryptString(message)}";

                    Invoke(new Action(() => listMessages.Items.Add(fullMessage)));

                    // Enviar mensaje a todos los clientes conectados
                    BroadcastMessage(fullMessage, client);
                }
            }
            catch (Exception) { }
            finally
            {
                lock (clients)
                {
                    clients.Remove(client);
                    clientIPs.Remove(clientIP);
                }
                client.Close();
                Invoke(new Action(() => listMessages.Items.Add($"Cliente {clientIP} desconectado")));
            }
        }

        private void BroadcastMessage(string message, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            lock (clients)
            {
                foreach (TcpClient client in clients)
                {
                    if (client != sender) // No enviar el mensaje al que lo envió
                    {
                        try
                        {
                            NetworkStream stream = client.GetStream();
                            stream.Write(data, 0, data.Length);
                        }
                        catch { }
                    }
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                string localIP = GetLocalIPAddress();
                string fullMessage = $"{localIP}: {txtMessage.Text}";
                listMessages.Items.Add(fullMessage);
                BroadcastMessage(fullMessage, null);
                txtMessage.Clear();
            }
            else
            {
                MessageBox.Show("No hay clientes conectados.");
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
    }
}
