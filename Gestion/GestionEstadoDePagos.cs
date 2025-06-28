using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionEstadoDePagos
    {
        public void ActualizarEstadoPago(int idVenta, int estadoPago) 
        { 
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("EXEC ActualizarEstadoPago @IDVenta, @IDEstadoPago;");
                gestionDatos.setearParametro("@IDVenta", idVenta);
                gestionDatos.setearParametro("@IDEstadoPago", estadoPago);
                gestionDatos.ejecutarAccion();
               
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método pagoRecibido: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
