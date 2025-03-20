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
            byte[] buffer = new byte[1024];
            int bytesRead;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Invoke(new Action(() => listMessages.Items.Add(message)));
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
    }
}
