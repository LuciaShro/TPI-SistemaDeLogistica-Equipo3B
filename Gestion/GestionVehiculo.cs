﻿using System;
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
                datos.setearConsulta("insert into Vehiculo (Patente, CapacidadDeCarga, Disponible, IDEstadoVehiculo, Activo) values (@Patente, @CapacidadDeCarga, 1, 1, 1)");
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
                datos.setearConsulta("select v.IDVehiculo, v.Patente, v.CapacidadDeCarga, estadovehiculo.Descripcion from Vehiculo v inner join EstadoVehiculo estadovehiculo on estadovehiculo.IDEstadoVehiculo=v.IDEstadoVehiculo where v.Disponible=0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    Transportista transportista = new Transportista();
                    vehiculo.idVehiculo = (int)datos.Lector["IDVehiculo"];
                    vehiculo.Patente = datos.Lector["Patente"].ToString();
                    vehiculo.CapacidadCarga = Convert.ToSingle((decimal)datos.Lector["CapacidadDeCarga"]);



                    vehiculo.estadoVehiculo = new EstadoVehiculo();
                    vehiculo.estadoVehiculo.descripcioEstado = datos.Lector["Descripcion"].ToString();

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

        public void modificarVehiculo(Vehiculo vehiculo) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Vehiculo SET Patente = @Patente, CapacidadDeCarga = @CapacidadDeCarga, IDEstadoVehiculo = @IDEstadoVehiculo WHERE IDVehiculo = @IDVehiculo");

                gestionDatos.setearParametro("@Patente", vehiculo.Patente);
                gestionDatos.setearParametro("@CapacidadDeCarga", vehiculo.CapacidadCarga);
                gestionDatos.setearParametro("@IDEstadoVehiculo", vehiculo.estadoVehiculo.IDEstado);


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

        public void eliminarVehiculo(string Patente) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("UPDATE Vehiculo SET Activo = 0 WHERE Patente = @Patente");
                gestionDatos.setearParametro("@Patente", Patente);
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

        public List<Vehiculo> listarVehiculosSinAsignar() {
            AccesoDatos datos = new AccesoDatos();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                datos.abrirConexion();
                datos.setearConsulta("select v.IDVehiculo, v.Patente, v.CapacidadDeCarga, estadovehiculo.Descripcion from Vehiculo v inner join EstadoVehiculo estadovehiculo on estadovehiculo.IDEstadoVehiculo=v.IDEstadoVehiculo where v.Disponible=1");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.idVehiculo = (int)datos.Lector["IDVehiculo"];
                    vehiculo.Patente = datos.Lector["Patente"].ToString();
                    vehiculo.CapacidadCarga = Convert.ToSingle((decimal)datos.Lector["CapacidadDeCarga"]);

                    vehiculo.estadoVehiculo = new EstadoVehiculo();
                    vehiculo.estadoVehiculo.descripcioEstado = datos.Lector["Descripcion"].ToString();




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

        public Vehiculo buscarVehiculo(string Patente) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT Patente, CapacidadDeCarga, Disponible, IDEstadoVehiculo FROM Vehiculo WHERE Patente = @Patente");
                gestionDatos.setearParametro("@Patente", Patente);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Vehiculo v = new Vehiculo();
                    v.idVehiculo = (int)gestionDatos.Lector["IDVehiculo"];
                    v.Patente = (string)gestionDatos.Lector["Patente"];
                    v.CapacidadCarga = (float)gestionDatos.Lector["CapacidadDeCarga"];
                    v.Disponible = (bool)gestionDatos.Lector["Disponible"];
                    v.estadoVehiculo.IDEstado = (int)gestionDatos.Lector["IDEstadoVehiculo"];

                    return v;
                }

                throw new Exception("Vehiculo no encontrado con esa patente.");
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

        public List<Vehiculo> listarVehiculos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();

            try
            {
                datos.abrirConexion();
                datos.setearConsulta("select v.IDVehiculo, v.Patente, v.CapacidadDeCarga, estadovehiculo.Descripcion from Vehiculo v inner join EstadoVehiculo estadovehiculo on estadovehiculo.IDEstadoVehiculo=v.IDEstadoVehiculo");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Vehiculo vehiculo = new Vehiculo();
                    vehiculo.idVehiculo = (int)datos.Lector["IDVehiculo"];
                    vehiculo.Patente = datos.Lector["Patente"].ToString();
                    vehiculo.CapacidadCarga = Convert.ToSingle((decimal)datos.Lector["CapacidadDeCarga"]);


                    vehiculo.estadoVehiculo = new EstadoVehiculo();
                    vehiculo.estadoVehiculo.descripcioEstado = datos.Lector["Descripcion"].ToString();



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

    }
}
