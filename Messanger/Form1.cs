using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;


namespace Messanger
{
    public partial class Servidor : Form
    {
        private TcpListener server;
        private NetworkStream stream;
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
            byte[] buffer = new byte[4096]; // Tamaño del buffer
            int bytesRead;

            try
            {
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (receivedData.StartsWith("[FILE]"))
                    {
                        // Extraer información del archivo
                        string[] parts = receivedData.Split('|');
                        string fileName = parts[1];
                        int fileSize = int.Parse(parts[2]);

                        Invoke(new Action(() => listMessages.Items.Add($"Recibiendo archivo: {fileName} ({fileSize} bytes)")));

                        // Recibir los bytes del archivo
                        byte[] fileBuffer = new byte[fileSize];
                        int totalReceived = 0;
                        while (totalReceived < fileSize)
                        {
                            int remaining = fileSize - totalReceived;
                            int chunkSize = Math.Min(4096, remaining);
                            int chunkRead = stream.Read(fileBuffer, totalReceived, chunkSize);
                            totalReceived += chunkRead;
                        }

                        // Guardar el archivo en el escritorio
                        string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                        File.WriteAllBytes(savePath, fileBuffer);

                        Invoke(new Action(() => listMessages.Items.Add($"Archivo guardado en: {savePath}")));
                    }
                    else
                    {
                        // Es un mensaje normal, lo desencriptamos y mostramos
                        string fullMessage = $"{ServicioDeEncriptado.DecryptString(receivedData)}";
                        Invoke(new Action(() => listMessages.Items.Add(fullMessage)));

                        // Enviar mensaje a todos los clientes conectados
                        BroadcastMessage(fullMessage, client);
                    }
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
            byte[] data = Encoding.UTF8.GetBytes(ServicioDeEncriptado.EncriptarCadena(message));

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

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (clients.Count == 0)
            {
                MessageBox.Show("No hay clientes conectados.");
                return;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                byte[] fileData = File.ReadAllBytes(filePath);
                string fileName = Path.GetFileName(filePath);
                int fileSize = fileData.Length;

                // Enviar encabezado del archivo
                string header = $"[FILE]|{fileName}|{fileSize}";
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);

                lock (clients)
                {
                    foreach (TcpClient client in clients)
                    {
                        try
                        {
                            NetworkStream clientStream = client.GetStream();
                            clientStream.Write(headerBytes, 0, headerBytes.Length);
                            Thread.Sleep(100); // Evita colisiones de paquetes

                            // Enviar archivo en bloques de 4096 bytes
                            int bufferSize = 4096;
                            int totalSent = 0;
                            while (totalSent < fileSize)
                            {
                                int remaining = fileSize - totalSent;
                                int chunkSize = Math.Min(bufferSize, remaining);
                                byte[] buffer = new byte[chunkSize];
                                Array.Copy(fileData, totalSent, buffer, 0, chunkSize);
                                clientStream.Write(buffer, 0, chunkSize);
                                totalSent += chunkSize;
                            }
                        }
                        catch (Exception ex)
                        {
                            listMessages.Items.Add("Error al enviar archivo: " + ex.Message);
                        }
                    }
                }

                listMessages.Items.Add("Archivo enviado: " + fileName);
            }
        }
    }
}
