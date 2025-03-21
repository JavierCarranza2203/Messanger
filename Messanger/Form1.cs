using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

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
                        if (parts.Length < 3)
                        {
                            Invoke(new Action(() => listMessages.Items.Add("Formato de archivo inválido.")));
                            continue;
                        }

                        string fileName = parts[1];
                        int base64Size = int.Parse(parts[2]);

                        DialogResult result = MessageBox.Show($"¿Deseas recibir el archivo {fileName} ({base64Size} bytes en Base64)?",
                                                       "Recepción de archivo",
                                                       MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            Invoke(new Action(() => listMessages.Items.Add($"Recibiendo archivo: {fileName} ({base64Size} bytes en Base64)")));

                            // Recibir los datos en Base64
                            byte[] base64Buffer = new byte[base64Size];
                            int totalReceived = 0;
                            while (totalReceived < base64Size)
                            {
                                int remaining = base64Size - totalReceived;
                                int chunkSize = Math.Min(4096, remaining);
                                int chunkRead = stream.Read(base64Buffer, totalReceived, chunkSize);
                                if (chunkRead == 0)
                                {
                                    throw new EndOfStreamException("Conexión cerrada antes de recibir el archivo completo.");
                                }
                                totalReceived += chunkRead;
                            }

                            // Convertir Base64 a bytes
                            string base64Data = Encoding.UTF8.GetString(base64Buffer);
                            byte[] encryptedData = Convert.FromBase64String(base64Data);

                            // Desencriptar los datos
                            byte[] fileData = ServicioDeEncriptado.DesencriptarBytes(encryptedData);

                            // Guardar el archivo en el escritorio
                            string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                            File.WriteAllBytes(savePath, fileData);

                            Invoke(new Action(() => listMessages.Items.Add($"Archivo guardado en: {savePath}")));
                        }
                        else
                        {
                            // Notificar al servidor que el archivo fue rechazado
                            byte[] rejectMessage = Encoding.UTF8.GetBytes("[REJECT]");
                            stream.Write(rejectMessage, 0, rejectMessage.Length);

                            // Descartar los bytes restantes del archivo
                            int totalDiscarded = 0;
                            byte[] discardBuffer = new byte[4096];
                            while (totalDiscarded < base64Size)
                            {
                                int remaining = base64Size - totalDiscarded;
                                int chunkSize = Math.Min(discardBuffer.Length, remaining);
                                int chunkRead = stream.Read(discardBuffer, 0, chunkSize);
                                if (chunkRead == 0)
                                {
                                    throw new EndOfStreamException("Conexión cerrada antes de descartar el archivo completo.");
                                }
                                totalDiscarded += chunkRead;
                            }

                            Invoke(new Action(() => listMessages.Items.Add($"Rechazaste el archivo: {fileName}")));
                        }
                    }
                    else
                    {
                        // Es un mensaje normal, lo desencriptamos y mostramos
                        try
                        {
                            // Verificar si el mensaje es un Base64 válido
                            if (IsBase64String(receivedData))
                            {
                                // Convertir Base64 a bytes
                                byte[] encryptedData = Convert.FromBase64String(receivedData);

                                // Convertir el arreglo de bytes a una cadena Base64
                                string encryptedDataBase64 = Convert.ToBase64String(encryptedData);

                                // Desencriptar los datos
                                string fullMessage = ServicioDeEncriptado.DesencriptarCadena(encryptedDataBase64);

                                Invoke(new Action(() => listMessages.Items.Add(fullMessage)));

                                // Enviar mensaje a todos los clientes conectados
                                BroadcastMessage(fullMessage, client);
                            }
                            else
                            {
                                // Si no es un Base64 válido, mostrar el mensaje sin desencriptar
                                Invoke(new Action(() => listMessages.Items.Add($"Mensaje recibido (no encriptado): {receivedData}")));
                            }
                        }
                        catch (Exception ex)
                        {
                            Invoke(new Action(() => listMessages.Items.Add($"Error al desencriptar el mensaje: {ex.Message}")));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registrar la excepción y notificar al usuario
                Debug.WriteLine($"Error: {ex.Message}");
                Invoke(new Action(() => listMessages.Items.Add($"Error: {ex.Message}")));
            }
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

                // Convertir el archivo a Base64
                string fileBase64 = Convert.ToBase64String(fileData);

                // Enviar encabezado del archivo
                string header = $"[FILE]|{fileName}|{fileBase64.Length}"; // Tamaño del Base64, no del archivo original
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

                            // Enviar archivo en Base64
                            byte[] base64Bytes = Encoding.UTF8.GetBytes(fileBase64);
                            clientStream.Write(base64Bytes, 0, base64Bytes.Length);
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

        // Verifica si una cadena es un Base64 válido
        private bool IsBase64String(string base64)
        {
            try
            {
                Convert.FromBase64String(base64);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}