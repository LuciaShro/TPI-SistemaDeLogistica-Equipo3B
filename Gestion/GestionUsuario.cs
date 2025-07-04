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

        public Cliente LoginCliente (string username, string password) {

            Usuario usuario = new Usuario(username, password);

            if(Login(usuario)) { 
                if(usuario.tipoUsuario == Usuario.TipoUsuario.cliente) {

                    AccesoDatos datos = new AccesoDatos();

                    try
                    {
                        datos.setearConsulta("select c.IDCliente, c.Nombre, c.Apellido, c.Cuil, c.Telefono, d.Calle, d.CodigoPostal, d.Ciudad, d.Numero, d.Piso, d.Provincia, u.Email from clientes c inner join direccion d on d.IDDireccion=c.IDDireccion inner join usuario u on u.IDUsuario = c.IDUsuario where c.IDUsuario=@IDUsuario");
                        datos.setearParametro("@IDUsuario", usuario.idUsuario);

                        datos.ejecutarLectura();

                        if (datos.Lector.Read())
                        {
                            Cliente cliente = new Cliente();

                            cliente.id = Convert.ToInt32(datos.Lector["IDCliente"]);
                            cliente.Nombre = datos.Lector["Nombre"].ToString();
                            cliente.Apellido = datos.Lector["Apellido"].ToString();
                            cliente.CUIL = Convert.ToInt64(datos.Lector["Cuil"]);
                            cliente.Telefono = datos.Lector["Telefono"].ToString();
                            cliente.Usuario.idUsuario = Convert.ToInt32(datos.Lector["IDUsario"]);

                            cliente.Direccion = new Direccion
                            {
                                Calle = datos.Lector["Calle"].ToString(),
                                NumeroCalle = Convert.ToInt32(datos.Lector["Numero"]),
                                CodigoPostal = datos.Lector["CodigoPostal"].ToString(),
                                Ciudad = datos.Lector["Ciudad"].ToString(),
                                Provincia = datos.Lector["Provincia"].ToString(),
                                Piso = datos.Lector["Piso"].ToString()
                            };

                            usuario.Email = datos.Lector["Email"].ToString();

                            cliente.Usuario = usuario;

                            return cliente;

                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    finally {
                        datos.cerrarConexion();
                    }
                
                }
                
            }
            return null;

        }


        public Usuario loginEmpresa(string username, string password)
        {
            Usuario usuario = new Usuario(username, password);
            if (Login(usuario))
            {
                if (usuario.tipoUsuario == Usuario.TipoUsuario.admin || usuario.tipoUsuario == Usuario.TipoUsuario.empleado)
                {
                    AccesoDatos datos = new AccesoDatos();
                    try
                    {
                        datos.setearConsulta("SELECT Email FROM Usuario WHERE IDUsuario = @IDUsuario");
                        datos.setearParametro("@IDUsuario", usuario.idUsuario);
                        datos.ejecutarLectura();

                        if (datos.Lector.Read())
                        {
                            usuario.Email = datos.Lector["Email"].ToString();
                            return usuario;
                    }
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
            }
            return null;
        }
        public void agregarUsuario (Usuario usuario) {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaUsuario");
                datos.setearParametro("@NombreUser", usuario.User);
                datos.setearParametro("@Contraseña", usuario.Password);
                datos.setearParametro("@Email", usuario.Email);

                datos.ejecutarAccion();

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

        public void modificarUsuario () { }

        public void modificarContraseña (Usuario usuario) {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("update Usuario set Contraseña = @Contraseña where IDUsuario = @IDUsuario");
                datos.setearParametro("@IDUsuario", usuario.idUsuario);
                datos.setearParametro("@Contraseña", usuario.Password);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar usuario", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }

        public void eliminarUsuario () {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();

            try
            {
                datos.setearConsulta("delete from Usuario where IDUsuario=@IDUsuario");
                datos.setearParametro("@IDUsuario", usuario.idUsuario);

                datos.ejecutarAccion();
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

        public bool buscarUsuario (int id) { return false; }

        public List<Usuario> listarUsuarios () {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("select NombreUser, Email, Activo from Usuario");
                datos.ejecutarLectura();

                

                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.User = datos.Lector["NombreUser"].ToString();
                    usuario.Email = datos.Lector["Email"].ToString();
                    usuario.Activo = Convert.ToBoolean(datos.Lector["Activo"]);
                    lista.Add(new Usuario());
                }

                    return lista;
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

        public Usuario returnUsuario(int id)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDUsuario, NombreUser, Email, Activo FROM Usuario WHERE IDUsuario = @IDUsuario");
                gestionDatos.setearParametro("@IDUsuario", id);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Usuario usuario =new Usuario();
                    usuario.idUsuario = (int)gestionDatos.Lector["IDUsuario"];
                    usuario.User = (string)gestionDatos.Lector["NombreUser"];
                    usuario.Email = (string)gestionDatos.Lector["Email"];
                    //usuario.tipoUsuario = (enum)gestionDatos.Lector["TipoUsuario"];
                    usuario.Activo = (bool)gestionDatos.Lector["Activo"];

                    return usuario;
                }

                throw new Exception("Usuario no encontrado con ese ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnUsuario: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
