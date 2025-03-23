using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messanger
{
    internal class UsuarioController
    {
        public static Usuario BuscarUsuario(MySqlConnection conn, string usuario, string contrasenia)
        {
            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "SELECT id, nombre, esServidor FROM usuarios WHERE nombre = @n AND contrasenia = @c LIMIT 1";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@n", usuario);
                    cmd.Parameters.AddWithValue("@c", ServicioDeEncriptado.EncriptarCadena(contrasenia));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario(reader.GetInt32("id"), reader.GetString("nombre"), "", reader.GetBoolean("esAdmin"));
                        }
                        else
                        {
                            throw new UnauthorizedAccessException("Usuario o contraseña incorrectos");
                        }
                    }
                }
            }
        }

        public static bool AgregarUsuario(MySqlConnection conn, Usuario usuario)
        {
            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "CALL SP_AgregarNuevoUsuario(@nombre, @descripcion, @contrasenia, @esAdmin)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", usuario.NombreUsuario);
                    cmd.Parameters.AddWithValue("@contrasenia", usuario.Contrasenia);
                    cmd.Parameters.AddWithValue("@esAdmin", usuario.EsAdmin);
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
        }

        public static List<Usuario> ConsultarUsuariosAgregador(MySqlConnection conn)
        {
            List<Usuario> miListaUsuarios = new List<Usuario>();

            using (conn)
            {
                if (conn.State != System.Data.ConnectionState.Open) conn.Open();

                string query = "CALL SP_ConsultarUsuarios()";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            miListaUsuarios.Add(
                                new Usuario(
                                    reader.GetInt32("id"),
                                    reader.GetString("nombre"),
                                    ServicioDeEncriptado.EncriptarCadena(""),
                                    reader.GetBoolean("esAdmin")
                                )
                            );
                        }

                        return miListaUsuarios;
                    }
                }
            }
        }

        public static bool EliminarUsuario(MySqlConnection conn, int id)
        {
            return true;
        }
    }
}
