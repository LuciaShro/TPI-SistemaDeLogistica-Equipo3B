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
                
                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1)");
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

        public void modificarCliente () { }

        public void eliminarCliente() { }

        public void buscarCliente () { }

        public void listarClientes() { }
    }
}
