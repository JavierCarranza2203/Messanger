using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger
{
    internal class Usuario
    {
        private int _intId;
        private string _strNombreDeUsuario;
        private string _strContrasenia;
        private bool _blnEsAdmin;

        public Usuario(int id, string nombreUsuario, string contrasenia, bool esAdmin)
        {
            this._intId = id;
            this._strNombreDeUsuario = nombreUsuario;
            this._strContrasenia = contrasenia;
            this._blnEsAdmin = esAdmin;
        }

        public int Id { get { return _intId; } }
        public string NombreUsuario { get { return _strNombreDeUsuario; } }
        public bool EsAdmin { get { return _blnEsAdmin; } }
        public string Contrasenia { get { return ServicioDeEncriptado.EncriptarCadena(this._strContrasenia); } }
    }
}
