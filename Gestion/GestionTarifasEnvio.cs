using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionTarifasEnvio
    {
        public void actualizarPrecioCategoriaPequeño(TarifasEnvio tarifasEnvio) {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=1");
                datos.setearParametro("@PrecioPorKM", tarifasEnvio.PrecioPorKm);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void actualizarPrecioCategoriaMediano(TarifasEnvio tarifasEnvio)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=2");
                datos.setearParametro("@PrecioPorKM", tarifasEnvio.PrecioPorKm);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public void actualizarPrecioCategoriaGrande (TarifasEnvio tarifasEnvio)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=3");
                datos.setearParametro("@PrecioPorKM", tarifasEnvio.PrecioPorKm);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public decimal ObtenerPrecioCategoria(int idCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearConsulta("SELECT PrecioPorKM from TarifasEnvio where IDCategoria=@IDCategoria");
                datos.setearParametro("@IDCategoria", idCategoria);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return Convert.ToDecimal(datos.Lector["PrecioPorKM"]);
                }
                return 0;

            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener el precio", ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<TarifasEnvio> listarTarifasEnvioCategoriaPequeño()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TarifasEnvio> lista = new List<TarifasEnvio>();

            try
            {
                datos.setearConsulta("select PrecioPorKM from TarifasEnvio where IDCategoria=1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TarifasEnvio tarifas = new TarifasEnvio();
                    tarifas.PrecioPorKm = Convert.ToDecimal(datos.Lector["PrecioPorKM"]);

                    lista.Add(tarifas);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en mostrar tarifas: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<TarifasEnvio> listarTarifasEnvioCategoriaMediano()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TarifasEnvio> lista = new List<TarifasEnvio>();

            try
            {
                datos.setearConsulta("select PrecioPorKM from TarifasEnvio where IDCategoria=2");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TarifasEnvio tarifas = new TarifasEnvio();
                    tarifas.PrecioPorKm = Convert.ToDecimal(datos.Lector["PrecioPorKM"]);

                    lista.Add(tarifas);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en mostrar tarifas: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<TarifasEnvio> listarTarifasEnvioCategoriaGrande()
        {
            AccesoDatos datos = new AccesoDatos();
            List<TarifasEnvio> lista = new List<TarifasEnvio>();

            try
            {
                datos.setearConsulta("select PrecioPorKM from TarifasEnvio where IDCategoria=3");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TarifasEnvio tarifas = new TarifasEnvio();
                    tarifas.PrecioPorKm = Convert.ToDecimal(datos.Lector["PrecioPorKM"]);

                    lista.Add(tarifas);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Error en mostrar tarifas: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
