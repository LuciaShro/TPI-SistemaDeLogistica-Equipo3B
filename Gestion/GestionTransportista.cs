using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionTransportista
    {
        public void agregarTranportista (Transportista transportista) { 
            
            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1)");
                datos.setearParametro("@NombreUser", transportista.usuario.User);
                datos.setearParametro("@Contraseña", transportista.usuario.Password);
                datos.setearParametro("@Email", transportista.usuario.Email);
                int idUsuario = Convert.ToInt32(datos.obtenerValor());
                datos.cerrarConexion();

                Transportista nuevo = new Transportista();
                

                datos.setearConsulta("insert into Transportista (IDVehiculo, IDUsuario, Nombre, Apellido, Cuil, Telefono, Licencia, Activo, EstadoDisponibilidad, HoraInicio, HoraFin, Imagen) values (@IDVehiculo, @IDUsuario, @Nombre, @Apellido, @Cuil, @Telefono, @Licencia, 1, 1, @HoraInicio, @HoraFin, @Imagen)");
                datos.setearParametro("@IDVehiculo", 1); // asigno un vehiculo ya que aun no esta creado el abm de vehiculos
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@Nombre", transportista.Nombre);
                datos.setearParametro("@Apellido", transportista.Apellido);
                datos.setearParametro("@Cuil", transportista.CuilTransportista);
                datos.setearParametro("@Telefono", transportista.Telefono);
                datos.setearParametro("@Licencia", transportista.Licencia);
                datos.setearParametro("@HoraInicio", transportista.HoraInicio);
                datos.setearParametro("@HoraFin", transportista.HoraFin);
                datos.setearParametro("@Imagen", transportista.Imagen);

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

        public bool cuilExistente(long cuil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select 1 from Transportista where Cuil=@Cuil");
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

        public void darBajaTransportista() { }

        public void listarTranportistas() { }

        public int transportistaDisponible()
        {
            AccesoDatos gestionDatos = new AccesoDatos();
            List<int> transportistasDisponibles = new List<int>();
            Random rand = new Random();

            try
            {
                gestionDatos.setearConsulta("select IDTransportista, EstadoDisponibilidad from Transportista where Activo = 1 AND EstadoDisponibilidad = 1");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    transportistasDisponibles.Add((int)gestionDatos.Lector["IDTransportista"]);
                }

                if (transportistasDisponibles.Count > 0)
                {
                    int indice = rand.Next(transportistasDisponibles.Count);
                    return transportistasDisponibles[indice];
                }
                else
                {
                    throw new Exception("No hay transportistas disponibles.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método cuilExistente: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public bool buscarTransportista () { return false; }

        public void transportistasDisponibles() { }
    }
}
