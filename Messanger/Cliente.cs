using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

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


            using (InputForm ipForm = new InputForm())
            {
                if (ipForm.ShowDialog() == DialogResult.OK)
                {
                    ServicioDeBaseDeDatos.InicializarConexion();
                    txtServerIP.Text = ServicioDeBaseDeDatos.ObtenerObjeto().Host;

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
                else
                {
                    MessageBox.Show("Debes ingresar una IP para conectarte.");
                    this.Close(); // Cierra la app si no ingresa IP
                }




            }
        }





        //private void btnConnect_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        client = new TcpClient();
        //        client.Connect(txtServerIP.Text, 5000);
        //        stream = client.GetStream();
        //        listMessages.Items.Add($"Conectado al servidor {txtServerIP.Text}");

        //        receiveThread = new Thread(ReceiveMessages);
        //        receiveThread.IsBackground = true;
        //        receiveThread.Start();
        //    }
        //    catch (SocketException ex)
        //    {
        //        MessageBox.Show("No se pudo conectar con el servidor: " + ex.Message);
        //    }
        //}

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[4096];
            int bytesRead;

            try
            {
                while (true)
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        // El servidor cerró la conexión
                        Invoke(new Action(() => listMessages.Items.Add("El servidor cerró la conexión.")));
                        break;
                    }

                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    if (receivedData.StartsWith("[FILE]"))
                    {
                        string[] parts = receivedData.Split('|');
                        if (parts.Length < 3)
                        {
                            Invoke(new Action(() => listMessages.Items.Add("Formato de archivo inválido.")));
                            continue;
                        }

                        string fileName = parts[1];
                        int base64Size = int.Parse(parts[2]);

                        // Preguntar si quiere recibir el archivo
                        DialogResult result = MessageBox.Show($"¿Deseas recibir el archivo {fileName} ({base64Size} bytes en Base64)?",
                                                             "Recepción de archivo",
                                                             MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            // Recibir los datos en Base64
                            byte[] base64Buffer = new byte[base64Size];
                            int totalReceived = 0;
                            while (totalReceived < base64Size)
                            {
                                int remaining = base64Size - totalReceived;
                                int chunkSize = Math.Min(buffer.Length, remaining);
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
                            if (File.Exists(savePath))
                            {
                                Invoke(new Action(() => listMessages.Items.Add($"El archivo {fileName} ya existe en el escritorio.")));
                            }
                            else
                            {
                                File.WriteAllBytes(savePath, fileData);
                                Invoke(new Action(() => listMessages.Items.Add($"Archivo guardado en: {savePath}")));
                            }
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
                Invoke(new Action(() => listMessages.Items.Add($"Error: {ex.Message}")));
            }
            finally
            {
                // Cerrar la conexión y liberar recursos
                stream?.Close();
                client?.Close();
                Invoke(new Action(() => listMessages.Items.Add("Conexión cerrada.")));
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

                // Convertir el archivo a Base64
                string fileBase64 = Convert.ToBase64String(fileData);

                // Enviar encabezado del archivo
                string header = $"[FILE]|{fileName}|{fileBase64.Length}"; // Tamaño del Base64, no del archivo original
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                stream.Write(headerBytes, 0, headerBytes.Length);
                Thread.Sleep(100);

                // Enviar archivo en Base64
                byte[] base64Bytes = Encoding.UTF8.GetBytes(fileBase64);
                stream.Write(base64Bytes, 0, base64Bytes.Length);

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