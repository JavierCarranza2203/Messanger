using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Messanger
{
    public partial class IniciarSesion : Form
    {
        private bool esAdmin;
        public IniciarSesion(bool esAdmin)
        {
            InitializeComponent();
            this.Enabled = esAdmin;
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (txtContrasenia.Text == string.Empty || txtContrasenia.Text == string.Empty) throw new ArgumentException("Debe llenar todos los campos");

            if (ServicioDeBaseDeDatos.InicializarConexion() == false) throw new Exception("Archivo de conexión no configurado");

            using (MySqlConnection conn = ServicioDeBaseDeDatos.ObtenerConexion())
            {
                Usuario miUsuario = UsuarioController.BuscarUsuario(conn, txtUsuario.Text, txtContrasenia.Text);

                if (esAdmin != miUsuario.EsAdmin)
                {
                    throw new Exception("Usted no cuenta con permisos para acceder");
                }
                else
                {
                    if (esAdmin)
                    {
                        Servidor frmServidor = new Servidor();
                        frmServidor.ShowDialog();
                    }
                    else
                    {
                        Cliente frmCliente = new Cliente();
                        frmCliente.ShowDialog();
                    }
                }
            }
        }
    }
}
