using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Messanger
{
    internal class ServicioDeBaseDeDatos
    {
        private static readonly string _strProgramFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        private static readonly string _strCarpeta = Path.Combine(_strProgramFiles, "DigiRack");
        private static readonly string _strArchivo = Path.Combine(_strCarpeta, "settings.enc");

        private static DataBaseConnection _connection;

        public static bool InicializarConexion()
        {
            if (!Directory.Exists(_strCarpeta)) { return false; }
            if (!File.Exists(_strArchivo)) { return false; }

            string cadena = servicioJson.LeerJSON(_strArchivo);

            _connection = servicioJson.DeserializarJSON(ServicioDeEncriptado.DecryptString(cadena));
            return true;
        }

        public static DataBaseConnection ObtenerObjeto() { return _connection; }

        public static MySqlConnection ObtenerConexion()
        {
            string cadenaDeConexion = $"Server={_connection.Host}; Port={_connection.Port}; Database={_connection.DataBaseName}; Uid={_connection.UserName}; Pwd={_connection.Password};";

            return new MySqlConnection(cadenaDeConexion);
        }

        public static void CrearArchivoDeConexion(DataBaseConnection db)
        {

            if (!Directory.Exists(_strCarpeta)) { Directory.CreateDirectory(_strCarpeta); }

            ServicioDeArchivosJSON<DataBaseConnection> servicioJson = new ServicioDeArchivosJSON<DataBaseConnection>();

            string json = servicioJson.FormatearJSON(db);

            string jsonEncriptado = ServicioDeEncriptado.EncriptarCadena(json);

            servicioJson.GuardarJSON(jsonEncriptado, _strArchivo);
        }

        public static bool ProbarConexion()
        {
            MySqlConnection _conn = ServicioDeBaseDeDatos.ObtenerConexion();
            _conn.Open();
            bool result = _conn.Ping();
            _conn.Close();

            return result;
        }
    }
}
