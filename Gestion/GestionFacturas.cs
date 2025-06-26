using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionFacturas
    {
        public void AgregarFactura(Factura factura)
        {

            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("INSERT INTO Factura (Numero, FechaEmision, CUILEmisor, RazonSocial, IDFormadePago, IDOrden, Total) " +
                                           "VALUES (@Numero, @FechaEmision, @CUILEmisor, @RazonSocial, @IDFormadePago, @IDOrden, @Total)");

                gestionDatos.setearParametro("@Numero", factura.NumeroFactura);
                gestionDatos.setearParametro("@FechaEmision", factura.FechaEmision);
                gestionDatos.setearParametro("@CUILEmisor", factura.cuilEmisor);
                gestionDatos.setearParametro("@RazonSocial", factura.razonSocial);
                gestionDatos.setearParametro("@IDFormadePago", factura.formaDePago.idFormaDePago);
                gestionDatos.setearParametro("@IDOrden", factura.OrdenesEnvio.idOrdenEnvio);
                gestionDatos.setearParametro("@Total", factura.Total);

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

        public void ModificarFactura(Factura factura)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Factura SET Numero = @Numero, FechaEmision = @FechaEmision, CUILEmisor = @CUILEmisor, RazonSocial = @RazonSocial, IDFormadePago = @IDFormadePago, IDOrden = @IDOrden, Total = @Total WHERE IDFactura = @IDFactura");

                gestionDatos.setearParametro("@Numero", factura.NumeroFactura);
                gestionDatos.setearParametro("@FechaEmision", factura.FechaEmision);
                gestionDatos.setearParametro("@CUILEmisor", factura.cuilEmisor);
                gestionDatos.setearParametro("@RazonSocial", factura.razonSocial);
                gestionDatos.setearParametro("@IDFormadePago", factura.formaDePago.idFormaDePago);
                gestionDatos.setearParametro("@IDOrden", factura.OrdenesEnvio.idOrdenEnvio);
                gestionDatos.setearParametro("@Total", factura.Total);

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

        public void EliminarFactura(int id)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("UPDATE Factura SET Activo = 0 WHERE IDFactura = IDFactura");
                gestionDatos.setearParametro("@IDFactura", id);
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

        public Factura obtenerFactura(int idFactura)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDFactura, Numero, FechaEmision, CUILEmisor, RazonSocial, IDFormadePago, IDOrden, Total FROM Factura WHERE IDFactura = @IDFactura");
                datos.setearParametro("@IDFactura", idFactura);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    Factura factura = new Factura();
                    factura.idFactura = (int)datos.Lector["IDFactura"];
                    factura.NumeroFactura = (int)datos.Lector["Numero"];
                    factura.FechaEmision = (DateTime)datos.Lector["FechaEmision"];
                    factura.cuilEmisor = (long)datos.Lector["CUILEmisor"];
                    factura.razonSocial = (string)datos.Lector["RazonSocial"];
                    factura.formaDePago.idFormaDePago = (int)datos.Lector["IDFormadePago"];
                    factura.OrdenesEnvio.idOrdenEnvio = (int)datos.Lector["IDOrden"];
                    factura.Total = (float)datos.Lector["Total"];

                    return factura;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al obtener factura", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}

