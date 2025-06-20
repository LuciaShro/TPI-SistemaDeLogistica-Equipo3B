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

               
                datos.setearConsulta("insert into Usuario (NombreUser, Contraseña, Email,TipoUsuario, Activo) OUTPUT INSERTED.IDUsuario values (@NombreUser, @Contraseña, @Email, 1, 1)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@NombreUser", transportista.usuario.User);
                datos.setearParametro("@Contraseña", transportista.usuario.Password);
                datos.setearParametro("@Email", transportista.usuario.Email);
                int idUsuario = Convert.ToInt32(datos.obtenerValorSinCerrarConexion());


               /* Transportista nuevo = new Transportista();*/


                datos.setearConsulta("insert into Transportista (IDVehiculo, IDUsuario, Nombre, Apellido, Cuil, Telefono, Licencia, EstadoDisponibilidad, Activo, HoraInicio, HoraFin, Imagen) values (@IDVehiculo, @IDUsuario, @Nombre, @Apellido, @Cuil, @Telefono, @Licencia, 1, 1, @HoraInicio, @HoraFin, @Imagen)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDVehiculo", transportista.Vehiculo.idVehiculo); // asigno un vehiculo ya que aun no esta creado el abm de vehiculos
                datos.setearParametro("@IDUsuario", idUsuario);
                datos.setearParametro("@Nombre", transportista.Nombre);
                datos.setearParametro("@Apellido", transportista.Apellido);
                datos.setearParametro("@Cuil", transportista.CuilTransportista);
                datos.setearParametro("@Telefono", transportista.Telefono);
                datos.setearParametro("@Licencia", transportista.Licencia);
                datos.setearParametro("@HoraInicio", transportista.HoraInicio);
                datos.setearParametro("@HoraFin", transportista.HoraFin);
                datos.setearParametro("@Imagen", (object)transportista.Imagen ?? DBNull.Value);

                datos.ejecutarAccion();

                datos.setearConsulta("update Vehiculo set Disponible = 0 where IDVehiculo = @IDVehiculo");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDVehiculo", transportista.Vehiculo.idVehiculo);
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

        public Transportista returnTransportista(int id)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDTransportista, Nombre, Apellido, Cuil, Telefono FROM Transportista WHERE IDTransportista = @IDTransportista");
                gestionDatos.setearParametro("@IDTransportista", id);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Transportista t = new Transportista();
                    t.IdTransportista = (int)gestionDatos.Lector["IDTransportista"];
                    t.Nombre = (string)gestionDatos.Lector["Nombre"];
                    t.Apellido = (string)gestionDatos.Lector["Apellido"];
                    t.CuilTransportista = (long)gestionDatos.Lector["Cuil"];
                    t.Telefono = (string)gestionDatos.Lector["Telefono"];

                    return t;
                }

                throw new Exception("Transportista no encontrado con ese ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método buscarVehiculo: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
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
                datos.ejecutarAccion();
               

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
                datos.setearConsulta("select IDTransportista, Nombre, Apellido, Cuil, Telefono, Licencia, EstadoDisponibilidad, HoraInicio, HoraFin, Imagen from Transportista");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.IdTransportista = Convert.ToInt32(datos.Lector["IDTransportista"]);
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
                    transportista.Telefono = datos.Lector["Telefono"].ToString();
                    transportista.Licencia = datos.Lector["Licencia"].ToString();
                    transportista.EstadoDisponibilidad = Convert.ToBoolean(datos.Lector["EstadoDisponibilidad"]);
                    transportista.HoraInicio = TimeSpan.Parse(datos.Lector["HoraInicio"].ToString());
                    transportista.HoraFin = TimeSpan.Parse(datos.Lector["HoraFin"].ToString());
                    transportista.Imagen = datos.Lector["Imagen"].ToString();
                    transportista.IdTransportista = (int)datos.Lector["IDTransportista"];

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

        public List<Transportista> transportistasActivos ()
        {
            AccesoDatos datos = new AccesoDatos ();
            List<Transportista> lista = new List<Transportista>();

            try
            {

                datos.abrirConexion();
                datos.setearConsulta("select IDTransportista, Nombre, Apellido, Cuil, Telefono, Licencia, EstadoDisponibilidad, HoraInicio, HoraFin from Transportista where Activo=1");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.IdTransportista = Convert.ToInt32(datos.Lector["IDTransportista"]);
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
                    transportista.Telefono = datos.Lector["Telefono"].ToString();
                    transportista.Licencia = datos.Lector["Licencia"].ToString();
                    transportista.EstadoDisponibilidad = Convert.ToBoolean(datos.Lector["EstadoDisponibilidad"]);
                    transportista.HoraInicio = TimeSpan.Parse(datos.Lector["HoraInicio"].ToString());
                    transportista.HoraFin = TimeSpan.Parse(datos.Lector["HoraFin"].ToString());

                    lista.Add(transportista);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en mostrar Transportistas Activos: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Transportista> transportistasInactivos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Transportista> lista = new List<Transportista>();

            try
            {

                datos.abrirConexion();
                datos.setearConsulta("select IDTransportista, Nombre, Apellido, Cuil, Telefono, Licencia, EstadoDisponibilidad, HoraInicio, HoraFin from Transportista where Activo=0");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Transportista transportista = new Transportista();
                    transportista.IdTransportista = Convert.ToInt32(datos.Lector["IDTransportista"]);
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
                    transportista.Telefono = datos.Lector["Telefono"].ToString();
                    transportista.Licencia = datos.Lector["Licencia"].ToString();
                    transportista.EstadoDisponibilidad = Convert.ToBoolean(datos.Lector["EstadoDisponibilidad"]);
                    transportista.HoraInicio = TimeSpan.Parse(datos.Lector["HoraInicio"].ToString());
                    transportista.HoraFin = TimeSpan.Parse(datos.Lector["HoraFin"].ToString());

                    lista.Add(transportista);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en mostrar Transportistas Inactivos: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Transportista obtenerTransportista(int idTransportista)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select t.Nombre, t.Apellido, t.Cuil, t.Telefono, t.Licencia, t.Activo, t.HoraInicio, t.HoraFin, t.Imagen, usuario.Email from Transportista t inner join Usuario usuario on usuario.IDUsuario = t.IDUsuario where IDTransportista=@IDTransportista");
                datos.setearParametro("@IDTransportista", idTransportista);
                datos.ejecutarLectura();

                if (datos.Lector.Read()) {

                    Transportista transportista = new Transportista();
                    transportista.Nombre = datos.Lector["Nombre"].ToString();
                    transportista.Apellido = datos.Lector["Apellido"].ToString();
                    transportista.CuilTransportista = Convert.ToInt64(datos.Lector["Cuil"]);
                    transportista.Telefono = datos.Lector["Telefono"].ToString();
                    transportista.Licencia = datos.Lector["Licencia"].ToString();
                    transportista.Activo = Convert.ToBoolean(datos.Lector["Activo"]);
                    transportista.HoraInicio = TimeSpan.Parse(datos.Lector["HoraInicio"].ToString());
                    transportista.HoraFin = TimeSpan.Parse(datos.Lector["HoraFin"].ToString());

                    if (!DBNull.Value.Equals(datos.Lector["Imagen"]))
                        transportista.Imagen = datos.Lector["Imagen"].ToString();

                    transportista.usuario = new Usuario();
                    transportista.usuario.Email = datos.Lector["Email"].ToString();

                    return transportista;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener transportista", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void reactivarTransportista(int idTransportista)
        {

            AccesoDatos datos = new AccesoDatos();
            SqlTransaction transaccion = null;


            try
            {
                datos.abrirConexion();
                transaccion = datos.Conexion.BeginTransaction();
                datos.Comando.Connection = datos.Conexion;
                datos.Comando.Transaction = transaccion;

                datos.setearConsulta("update Transportista set Activo = 1 where IDTransportista = @IDTransportista ");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDTransportista", idTransportista);
                datos.ejecutarAccion();


                datos.setearConsulta("update Usuario set Activo = 1 where IDUsuario = (select IDUsuario from Transportista where IDTransportista=@IDTransportista)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@IDTransportista", idTransportista);

                datos.ejecutarAccion();

                transaccion.Commit();
            }
            catch (Exception ex)
            {

                if (transaccion != null)
                    transaccion.Rollback();

                throw new Exception("Error al reactivar el transportista y el usuario: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }


        }

        public void ModificarTransportista(Transportista transportista)
        {
            AccesoDatos datos = new AccesoDatos();
            SqlTransaction transaccion = null;

            try
            {
                datos.abrirConexion();
                transaccion = datos.Conexion.BeginTransaction();
                datos.Comando.Connection = datos.Conexion;
                datos.Comando.Transaction = transaccion;

                datos.setearConsulta("update Transportista set Nombre=@Nombre, Apellido= @Apellido, Cuil=@Cuil, Telefono=@Telefono, Licencia=@Licencia, HoraInicio=@HoraInicio, HoraFin=@HoraFin where IDTransportista=@IDTransportista");
                datos.setearParametro("@IDTransportista", transportista.IdTransportista);
                datos.setearParametro("@Nombre", transportista.Nombre);
                datos.setearParametro("@Apellido", transportista.Apellido);
                datos.setearParametro("@Cuil", transportista.CuilTransportista);
                datos.setearParametro("@Telefono", transportista.Telefono);
                datos.setearParametro("@Licencia", transportista.Licencia);
                datos.setearParametro("@HoraInicio", transportista.HoraInicio);
                datos.setearParametro("@HoraFin", transportista.HoraFin);

                datos.ejecutarAccion();

                datos.setearConsulta("UPDATE Usuario SET Email = @Email WHERE IDUsuario = (SELECT IDUsuario FROM Transportista WHERE IDTransportista = @IDTransportista)");
                datos.Comando.Parameters.Clear();
                datos.setearParametro("@Email", transportista.usuario.Email);
                datos.setearParametro("@IDTransportista", transportista.IdTransportista);
                datos.ejecutarAccion();

                transaccion.Commit();
            }
            catch (Exception ex)
            {

                if (transaccion != null)
                    transaccion.Rollback();

                throw new Exception("Error al modificar transportista y usuario: " + ex.Message);
            }
            finally {
                datos.cerrarConexion();
            }
        }
    }
}
