using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionCliente
    {
        public void agregarCliente (Cliente cliente) 
        { 
            AccesoDatos datos = new AccesoDatos ();
            
            try
            {
                
                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario, Activo) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1, 1)");
                datos.setearParametro("@NombreUser", cliente.Usuario.User);
                datos.setearParametro("@Contraseña", cliente.Usuario.Password);
                datos.setearParametro("@Email", cliente.Usuario.Email);
                int idUsuario = Convert.ToInt32(datos.obtenerValor());
                datos.cerrarConexion();

                datos.setearConsulta("insert into Direccion (Calle, CodigoPostal,Provincia,Piso,Numero,Ciudad) OUTPUT INSERTED.IDDireccion values (@Calle, @CodigoPostal, @Provincia, @Piso, @Numero, @Ciudad)");
                datos.setearParametro("@Calle", cliente.Direccion.Calle);
                datos.setearParametro("@CodigoPostal", cliente.Direccion.CodigoPostal);
                datos.setearParametro("@Provincia", cliente.Direccion.Provincia);
                datos.setearParametro("@Piso", cliente.Direccion.Piso);
                datos.setearParametro("@Numero", cliente.Direccion.NumeroCalle);
                datos.setearParametro("@Ciudad", cliente.Direccion.Ciudad);
                int idDireccion = Convert.ToInt32(datos.obtenerValor());
                datos.cerrarConexion();

                datos.setearConsulta("insert into Clientes (IDUsuario, IDDireccion, Cuil, Nombre, Apellido, Telefono) values (@IDUsuario, @IDDireccion, @Cuil, @Nombre, @Apellido, @Telefono)");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDDireccion", idDireccion);
                datos.setearParametro("@Cuil", cliente.CUIL);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Telefono", cliente.Telefono);
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
        
        public void agregarClienteConSP (Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario, Activo) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1, 1)");
                datos.setearParametro("@NombreUser", cliente.Usuario.User);
                datos.setearParametro("@Contraseña", cliente.Usuario.Password);
                datos.setearParametro("@Email", cliente.Usuario.Email);
                int idUsuario = Convert.ToInt32(datos.obtenerValor());
                datos.cerrarConexion();

                datos.setearConsulta("insert into Direccion (Calle, CodigoPostal,Provincia,Piso,Numero,Ciudad) OUTPUT INSERTED.IDDireccion values (@Calle, @CodigoPostal, @Provincia, @Piso, @Numero, @Ciudad)");
                datos.setearParametro("@Calle", cliente.Direccion.Calle);
                datos.setearParametro("@CodigoPostal", cliente.Direccion.CodigoPostal);
                datos.setearParametro("@Provincia", cliente.Direccion.Provincia);
                datos.setearParametro("@Piso", cliente.Direccion.Piso);
                datos.setearParametro("@Numero", cliente.Direccion.NumeroCalle);
                datos.setearParametro("@Ciudad", cliente.Direccion.Ciudad);
                int idDireccion = Convert.ToInt32(datos.obtenerValor());
                datos.cerrarConexion();

                datos.setearProcedimiento("storedAltaCliente");
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@IDDireccion", idDireccion);
                datos.setearParametro("@Cuil", cliente.CUIL);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Telefono", cliente.Telefono);
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
        public bool cuilExistente (long cuil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select 1 from Clientes where Cuil=@Cuil");
                datos.setearParametro("@Cuil", cuil);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método cuilExistente: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public int returnIDCliente(long cuil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDCliente, Cuil FROM Clientes where Cuil=@Cuil");
                datos.setearParametro("@Cuil", cuil);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return (int)datos.Lector["IDCliente"];
                }

                throw new Exception("Cliente no encontrado con ese CUIL.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDCliente: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public Cliente returnCliente(long cuil)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDUsuario, IDDireccion, Cuil, Nombre, Apellido, Telefono FROM Clientes WHERE Cuil = @Cuil");
                gestionDatos.setearParametro("@Cuil", cuil);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Usuario = new Usuario(); 
                    cliente.Direccion = new Direccion();

                    cliente.Usuario.idUsuario = (int)gestionDatos.Lector["IDUsuario"];
                    cliente.Direccion.idDireccion = (int)gestionDatos.Lector["IDDireccion"];
                    cliente.CUIL = (long)gestionDatos.Lector["Cuil"];
                    cliente.Nombre = (string)gestionDatos.Lector["Nombre"];
                    cliente.Apellido = (string)gestionDatos.Lector["Apellido"];
                    cliente.Telefono = (string)gestionDatos.Lector["Telefono"];

                    return cliente;
                }

                throw new Exception("Cliente no encontrado con ese Cuil.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnCliente: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public int returnIDUsuario(long cuil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDUsuario, Cuil FROM Clientes where Cuil=@Cuil");
                datos.setearParametro("@Cuil", cuil);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return (int)datos.Lector["IDUsuario"];
                }

                throw new Exception("Cliente no encontrado con ese CUIL.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDCliente: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarCliente(Cliente cliente, Cliente cliente2)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();

                gestionDatos.setearProcedimiento_("sp_ModificarCliente");

             
                gestionDatos.setearParametro("@IDUsuario", cliente2.Usuario.idUsuario);
                gestionDatos.setearParametro("@Email", cliente.Usuario.Email);
             
                gestionDatos.setearParametro("@IDDireccion", cliente2.Direccion.idDireccion);
                gestionDatos.setearParametro("@Calle", cliente.Direccion.Calle);
                gestionDatos.setearParametro("@CodigoPostal", cliente.Direccion.CodigoPostal);
                gestionDatos.setearParametro("@Provincia", cliente.Direccion.Provincia);
                gestionDatos.setearParametro("@Ciudad", cliente.Direccion.Ciudad);
                gestionDatos.setearParametro("@Numero", cliente.Direccion.NumeroCalle);
                gestionDatos.setearParametro("@Piso", cliente.Direccion.Piso);
               
                gestionDatos.setearParametro("@CUIL_Anterior", cliente2.CUIL);
                gestionDatos.setearParametro("@CUIL_Nuevo", cliente.CUIL);
                gestionDatos.setearParametro("@Nombre", cliente.Nombre);
                gestionDatos.setearParametro("@Apellido", cliente.Apellido);
                gestionDatos.setearParametro("@Telefono", cliente.Telefono);

                gestionDatos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                gestionDatos.cerrarConexion();
            }
        }


        public void eliminacionFisicaCliente(int idCliente) {
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearConsulta("delete from Clientes where IDCliente = @IDCliente");
                datos.setearParametro("@IDCliente", idCliente);

                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw new Exception("Error al eliminar cliente", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        
        }

        public void buscarCliente () { }

        public List<Cliente> listarClientes() {
            AccesoDatos datos = new AccesoDatos();
            List<Cliente> lista = new List<Cliente>();

            try
            {
                datos.setearConsulta("select Cuil, Nombre, Apellido, Telefono, direccion.Calle, direccion.Ciudad, direccion.CodigoPostal, direccion.Numero, direccion.Provincia  from clientes c  inner join Direccion direccion on direccion.IDDireccion=c.IDDireccion");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                { 
                    Cliente cliente = new Cliente();
                    Direccion direccionCliente = new Direccion();
                    cliente.CUIL = Convert.ToInt64(datos.Lector["Cuil"]);
                    cliente.Nombre = datos.Lector["Nombre"].ToString();
                    cliente.Apellido = datos.Lector["Apellido"].ToString();
                    cliente.Telefono = datos.Lector["Telefono"].ToString();
                    direccionCliente.Calle = datos.Lector["Calle"].ToString();
                    direccionCliente.Ciudad = datos.Lector["Ciudad"].ToString();
                    direccionCliente.CodigoPostal = datos.Lector["CodigoPostal"].ToString();
                    direccionCliente.Provincia = datos.Lector["Provincia"].ToString();
                    direccionCliente.NumeroCalle = Convert.ToInt32(datos.Lector["Numero"]);






                    cliente.Direccion = direccionCliente;
                    lista.Add(new Cliente());
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

        public int returnIDClienteOrdenEnv(int idOrden)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT c.IDCliente FROM OrdenesEnvio AS oe INNER JOIN Clientes AS c ON c.IDCliente = oe.IDCliente WHERE oe.IDOrden = @IDOrden");
                datos.setearParametro("@IDOrden", idOrden);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return (int)datos.Lector["IDCliente"];
                }

                throw new Exception("Cliente no encontrado con ese ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDClienteOrdenEnv: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public long returnCuilCliente(int id)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT Cuil FROM Clientes WHERE IDCliente = @IDCLiente");
                gestionDatos.setearParametro("@IDCliente", id);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.CUIL = (long)gestionDatos.Lector["Cuil"];

                    return cliente.CUIL;
                }

                throw new Exception("Cliente no encontrado con ese ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnCuilCliente: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
