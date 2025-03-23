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
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }
        public string ServerIP { get; private set; }

        private void InputForm_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is TextBox && c.Text == string.Empty)
                        throw new ArgumentException("Debe llenar todos los campos");
                }

                DataBaseConnection miConexion = new DataBaseConnection(
                    txtDbUser.Text, 
                    txtDbPassword.Text, 
                    txtServerIP.Text, 
                    txtDbPort.Text, 
                    txtDbName.Text
                );

                ServicioDeBaseDeDatos.CrearArchivoDeConexion(miConexion);

                if (ServicioDeBaseDeDatos.InicializarConexion() == false)
                    throw new Exception("No es posible crear el archivo de conexión, verifique que WAZAGRAM se ejecuta como administrador");

                if (ServicioDeBaseDeDatos.ProbarConexion() == false)
                    throw new Exception("No es posible establecer la conexión, verifique los datos");

                MessageBox.Show("Archivo y conexión creados correctamente");

                Cliente frmCliente = new Cliente();
                frmCliente.ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
