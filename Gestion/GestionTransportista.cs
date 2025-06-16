using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            SqlTransaction transaccion = null;

            try
            {
                datos.abrirConexion();
                transaccion = datos.Conexion.BeginTransaction();
                datos.Comando.Connection = datos.Conexion;
                datos.Comando.Transaction = transaccion;

               
                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@NombreUser", transportista.usuario.User);
                datos.setearParametro("@Contraseña", transportista.usuario.Password);
                datos.setearParametro("@Email", transportista.usuario.Email);
                int idUsuario = Convert.ToInt32(datos.obtenerValor());
                

               /* Transportista nuevo = new Transportista();*/
                

                datos.setearConsulta("insert into Transportista (IDVehiculo, IDUsuario, Nombre, Apellido, Cuil, Telefono, Licencia, Activo, EstadoDisponibilidad, HoraInicio, HoraFin, Imagen) values (@IDVehiculo, @IDUsuario, @Nombre, @Apellido, @Cuil, @Telefono, @Licencia, 1, 1, @HoraInicio, @HoraFin, @Imagen)");
                datos.Comando.Parameters.Clear();
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
                transaccion.Commit();
            }
            catch (Exception)
            {
                if (transaccion != null)
                    transaccion.Rollback();

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

        public void darBajaTransportista(int idTransportista) {

            AccesoDatos datos = new AccesoDatos();
            SqlTransaction transaccion = null;

           
            try
            {
                datos.abrirConexion();
                transaccion = datos.Conexion.BeginTransaction();
                datos.Comando.Connection = datos.Conexion;
                datos.Comando.Transaction = transaccion;

                datos.setearConsulta("update Transportista set Activo = 0 where IDTransportista = @IDTransportista ");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDTransportista", idTransportista);
               

                datos.setearConsulta("update Usuario set Activo = 0 where IDUsuario = (select IDUsuario from Transportista where IDTransportista=@IDTransportista)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDTransportista", idTransportista);

                datos.ejecutarAccion();

                transaccion.Commit();
            }
            catch (Exception ex)
            {

                if (transaccion != null)
                    transaccion.Rollback();

                throw new Exception("Error al dar de baja el transportista y el usuario: " + ex.Message, ex);
            }

            finally { 
                datos.cerrarConexion(); 
            }

        
        }

        public List<Transportista> listarTranportistas() {
            AccesoDatos datos = new AccesoDatos();
            List<Transportista> lista = new List<Transportista>();

            try
            {
                datos.abrirConexion();
                datos.setearConsulta(" select Nombre, Apellido, Cuil, Telefono, Licencia, EstadoDisponibilidad, HoraInicio, HoraFin, Imagen from Transportista");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
                    transportista.Telefono = datos.Lector["Telefono"].ToString();
                    transportista.Licencia = datos.Lector["Licencia"].ToString();
                    transportista.EstadoDisponibilidad = Convert.ToBoolean(datos.Lector["EstadoDisponibilidad"]);
                    transportista.HoraInicio = TimeSpan.Parse(datos.Lector["HoraInicio"].ToString());
                    transportista.HoraFin = TimeSpan.Parse(datos.Lector["HoraFin"].ToString());
                    transportista.Imagen = datos.Lector["Imagen"].ToString();

                    lista.Add(transportista);
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

        public List<Transportista> transportistasDisponibles() {
            AccesoDatos datos = new AccesoDatos();
            List<Transportista> listaTransportistasDisponibles = new List<Transportista>();

            try
            {
                datos.abrirConexion();
                datos.setearConsulta("select IDTransportista, Nombre, Apellido, Cuil from Transportista where EstadoDisponibilidad=1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
       

                    listaTransportistasDisponibles.Add(transportista);
                }

                return listaTransportistasDisponibles;
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
}
