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

        private void btn_servidor_Click(object sender, EventArgs e)
        {
            IniciarSesion iniciarSesion = new IniciarSesion(true);
            iniciarSesion.ShowDialog();
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            if (ServicioDeBaseDeDatos.InicializarConexion())
            {
                IniciarSesion iniciarSesion = new IniciarSesion(false);
                iniciarSesion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Para entrar como cliente debe configurar las conexiones", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                InputForm form = new InputForm();
                form.ShowDialog();
            }
        }

        private void pnl_servidor_Click(object sender, EventArgs e)
        {
            //btn_servidor.PerformClick();
        }

        private void pnl_cliente_Click(object sender, EventArgs e)
        {
            //btn_cliente.PerformClick();
        }
    }
}
