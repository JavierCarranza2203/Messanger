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
            if (string.IsNullOrWhiteSpace(txtServerIP.Text))
            {
                MessageBox.Show("Por favor, ingresa una IP válida.");
                return;
            }

            ServerIP = txtServerIP.Text;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
