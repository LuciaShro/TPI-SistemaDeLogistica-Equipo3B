using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionVehiculo
    {
        public void agregarVehiculo(Vehiculo vehiculo) {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.abrirConexion();
                datos.setearConsulta("insert into Vehiculo (Patente, CapacidadDeCarga, Disponible, IDEstadoVehiculo) values (@Patente, @CapacidadDeCarga, 1, 1)");
                datos.setearParametro("@Patente", vehiculo.Patente);
                datos.setearParametro("@CapacidadDeCarga", vehiculo.CapacidadCarga);

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

        public List<Vehiculo> vehiculosAsignados()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                datos.setearConsulta("select Patente, CapacidadDeCarga from Vehiculo where IDEstadoVehiculo=2");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.idVehiculo = (int)datos.Lector["IDVehiculo"];
                    vehiculo.Patente = datos.Lector["Patente"].ToString();
                    




                    listaVehiculos.Add(vehiculo);
                }

                return listaVehiculos;


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

        public void modificarVehiculo() { }

        public void eliminarVehiculo() { }

        public List<Vehiculo> listarVehiculosSinAsignar() {
            AccesoDatos datos = new AccesoDatos();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                datos.abrirConexion();
                datos.setearConsulta("select IDVehiculo, Patente from Vehiculo where Disponible=1 and IDEstadoVehiculo=1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.idVehiculo = (int)datos.Lector["IDVehiculo"];
                    vehiculo.Patente = datos.Lector["Patente"].ToString();
                    




                    listaVehiculos.Add(vehiculo);
                }

                return listaVehiculos;

            }
            catch (Exception)
            {

                throw;
            }
            finally { 
                datos.cerrarConexion();
            
            }
        
        }

        public bool buscarVehiculo() { return false; }
    }
}
