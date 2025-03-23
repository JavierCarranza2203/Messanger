using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messanger
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (radCliente.Checked == true)
            {
                Cliente clientForm = new Cliente();
                clientForm.Show();
            }
            else if (radServer.Checked == true)
            {
                Servidor ServerForm = new Servidor();
                ServerForm.Show();
            }
        }

        private void btn_servidor_Click(object sender, EventArgs e)
        {
            Servidor ServerForm = new Servidor();
            ServerForm.Show();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            Cliente clientForm = new Cliente();
            clientForm.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Cliente clientForm = new Cliente();
            clientForm.Show();
        }

        private void pnl_servidor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnl_servidor_Click(object sender, EventArgs e)
        {
            Servidor ServerForm = new Servidor();
            ServerForm.Show();
        }
    }
}
