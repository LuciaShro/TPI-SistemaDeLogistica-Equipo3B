using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionUsuario
    {
        public bool Login (Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos ();
            
            try
            {
                datos.setearConsulta("select IDUsuario, TipoUsuario from USUARIOS where NombreUser=@NombreUser and Contraseña=@Contraseña");
                datos.setearParametro("@NombreUser", usuario.User);
                datos.setearParametro("@Contraseña", usuario.Password);

                datos.ejecutarLectura();
                if(string.IsNullOrEmpty(usuario.User) || string.IsNullOrEmpty(usuario.Password) )
                {
                    Console.WriteLine("Los campos no pueden estar vacíos");
                    return false;
                }
                while (datos.Lector.Read())
                {
                    usuario.idUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.tipoUsuario = (int)datos.Lector["TipoUsuario"] == 3 ? Usuario.TipoUsuario.admin : (int)datos.Lector["TipoUser"] == 2 ? Usuario.TipoUsuario.empleado: Usuario.TipoUsuario.cliente;
                    return true;
                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregarUsuario () { }

        public void modificarUsuario () { }

        public void modificarContraseña () { }

        public void eliminarUsuario () { }

        public bool buscarUsuario (int id) { return false; }

        public void listarUsuarios () { }
    }
}
