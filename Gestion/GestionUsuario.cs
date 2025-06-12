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
                if (string.IsNullOrEmpty(usuario.User) || string.IsNullOrEmpty(usuario.Password))
                {
                    Console.WriteLine("Los campos no pueden estar vacíos");
                    return false;
                }

                datos.setearConsulta("select IDUsuario, TipoUsuario from USUARIO where NombreUser=@NombreUser and Contraseña=@Contraseña");
                datos.setearParametro("@NombreUser", usuario.User);
                datos.setearParametro("@Contraseña", usuario.Password);

                datos.ejecutarLectura();

                if (datos.Lector == null)
                {
                    Console.WriteLine("El lector no fue inicializado correctamente.");
                    return false;
                }

                while (datos.Lector.Read())
                {
                    usuario.idUsuario = (int)datos.Lector["IdUsuario"];
                    int tipo = (int)datos.Lector["TipoUsuario"];

                    switch (tipo)
                    {
                        case 3:
                            usuario.tipoUsuario = Usuario.TipoUsuario.admin;
                            break;
                        case 2:
                            usuario.tipoUsuario = Usuario.TipoUsuario.empleado;
                            break;
                        default:
                            usuario.tipoUsuario = Usuario.TipoUsuario.cliente;
                            break;
                    }

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

        public bool userExistente(string user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select 1 from Usuario where NombreUser=@NombreUser");
                datos.setearParametro("@NombreUser", user);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método userExistente: " + ex.Message, ex);
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
