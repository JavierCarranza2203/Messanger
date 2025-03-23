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
    public partial class IniciarSesion : Form
    {
        private bool esAdmin;
        public IniciarSesion(bool esAdmin)
        {
            InitializeComponent();
            this.Enabled = esAdmin;
        }
    }
}
