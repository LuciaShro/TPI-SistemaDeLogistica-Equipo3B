using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionEstadoVehiculo
    {
        public void agregarEstadoVehiculo(EstadoVehiculo estadoVehiculo) {
            List<EstadoOrdenEnvio> lista = new List<EstadoOrdenEnvio>();
            AccesoDatos gestionDatos = new AccesoDatos();
            try
            {
                
                gestionDatos.setearConsulta("INSERT INTO EstadoVehiculo (Descripcion) " +
                                               " VALUES (@Descripcion)");

                gestionDatos.setearParametro("@Descripcion", estadoVehiculo.descripcioEstado);

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

        public void modificarEstadoVehiculo(EstadoVehiculo estadoVehiculo) {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE EstadoVehiculo SET Descripcion = @Descripcion WHERE IDEstadoVehiculo = @IDEstadoVehiculo");
                gestionDatos.setearParametro("@Descripcion", estadoVehiculo.descripcioEstado);
                gestionDatos.setearParametro("@IDEstadoVehiculo", estadoVehiculo.IDEstado);

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

        public void eliminarEstadoVehiculo(int id) {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("DELETE FROM EstadoVehiculo WHERE IDEstadoVehiculo = @IDEstadoVehiculo");
                gestionDatos.setearParametro("@IDEstadoVehiculo", id);
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

        public List<EstadoVehiculo> listarEstadoVehiculo()
        {
            List<EstadoVehiculo> lista = new List<EstadoVehiculo>();
            AccesoDatos gestionEstado = new AccesoDatos();

            try
            {
                gestionEstado.setearConsulta("SELECT IDEstadoVehiculo, Descripcion FROM EstadoVehiculo");
                gestionEstado.ejecutarLectura();

                while (gestionEstado.Lector.Read())
                {
                    EstadoVehiculo estado = new EstadoVehiculo();
                    estado.IDEstado = (int)gestionEstado.Lector["IDEstadoVehiculo"];
                    estado.descripcioEstado = gestionEstado.Lector["Descripcion"].ToString();

                    lista.Add(estado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gestionEstado.cerrarConexion();
            }
        }
    }
}
