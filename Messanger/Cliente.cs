using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Messanger
{
    public partial class Cliente : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread receiveThread;

        public Cliente()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient();
                client.Connect(txtServerIP.Text, 5000);
                stream = client.GetStream();
                listMessages.Items.Add($"Conectado al servidor {txtServerIP.Text}");

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("No se pudo conectar con el servidor: " + ex.Message);
            }
        }


        private void ReceiveMessages()
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (receivedData.StartsWith("[FILE]"))
                    {
                        // Extraer información del archivo
                        string[] parts = receivedData.Split('|');
                        string fileName = parts[1];
                        int fileSize = int.Parse(parts[2]);

                        Invoke(new Action(() => listMessages.Items.Add($"Recibiendo archivo: {fileName} ({fileSize} bytes)")));

                        // Recibir el archivo en bloques
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
                        Invoke(new Action(() => listMessages.Items.Add(ServicioDeEncriptado.DecryptString(receivedData))));
                    }
                }
                catch
                {
                    break;
                }
            }
        }


        private void btnSend_Click(object sender, EventArgs e)
        {
            if (stream != null)
            {
                try
                {
                    string clientIP = GetLocalIPAddress();
                    string fullMessage = $"{clientIP}: {txtMessage.Text}";
                    byte[] message = Encoding.UTF8.GetBytes(ServicioDeEncriptado.EncriptarCadena(fullMessage));
                    stream.Write(message, 0, message.Length);
                    listMessages.Items.Add(fullMessage);
                    txtMessage.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error enviando mensaje: " + ex.Message);
                }
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
            if (stream == null)
            {
                MessageBox.Show("No estás conectado al servidor.");
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
                stream.Write(headerBytes, 0, headerBytes.Length);
                Thread.Sleep(100);

                // Enviar archivo en bloques de 4096 bytes
                int bufferSize = 4096;
                int totalSent = 0;
                while (totalSent < fileSize)
                {
                    int remaining = fileSize - totalSent;
                    int chunkSize = Math.Min(bufferSize, remaining);
                    byte[] buffer = new byte[chunkSize];
                    Array.Copy(fileData, totalSent, buffer, 0, chunkSize);
                    stream.Write(buffer, 0, chunkSize);
                    totalSent += chunkSize;
                }

                listMessages.Items.Add("Archivo enviado: " + fileName);
            }
        }
    }
}
