using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
                    Invoke(new Action(() => listMessages.Items.Add("Servidor: " + message)));
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
                byte[] message = Encoding.UTF8.GetBytes(txtMessage.Text);
                stream.Write(message, 0, message.Length);
                listMessages.Items.Add("Cliente: " + txtMessage.Text);
                txtMessage.Clear();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                client = new TcpClient(txtServerIP.Text, 5000);
                stream = client.GetStream();
                listMessages.Items.Add("Conectado al servidor");

                receiveThread = new Thread(ReceiveMessages);
                receiveThread.IsBackground = true;
                receiveThread.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}