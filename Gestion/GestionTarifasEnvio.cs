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
            TarifasEnvio tarifas = new TarifasEnvio();

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=1");
                datos.setearParametro("@PrecioPorKM", tarifas.PrecioPorKm);

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
            TarifasEnvio tarifas = new TarifasEnvio();

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=2");
                datos.setearParametro("@PrecioPorKM", tarifas.PrecioPorKm);

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
            TarifasEnvio tarifas = new TarifasEnvio();

            try
            {
                datos.setearConsulta("update TarifasEnvio set PrecioPorKM=@PrecioPorKM where IDCategoria=3");
                datos.setearParametro("@PrecioPorKM", tarifas.PrecioPorKm);

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
    }
}
