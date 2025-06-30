using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionFacturas
    {
        public int AgregarFactura(FacturaPago factura, FormaDePago formaPago)
        {

            AccesoDatos gestionDatos = new AccesoDatos();
            int idGenerado = 0;

            try 
            {

                gestionDatos.setearProcedimiento("sp_AgregarFacturaConFormaDePago");

                gestionDatos.setearParametro("@MedioDePago", formaPago.medioDePago);
                gestionDatos.setearParametro("@FechaDePago", formaPago.fechaDePago);
                gestionDatos.setearParametro("@IDEstadoPago", formaPago.estadoDePago.idEstadoDePago);
                gestionDatos.setearParametro("@Numero", factura.NumeroFactura);
                gestionDatos.setearParametro("@FechaEmision", factura.FechaEmision);
                gestionDatos.setearParametro("@IDOrden", factura.OrdenesEnvio.idOrdenEnvio);
                gestionDatos.setearParametro("@Total", factura.Total);

                SqlParameter outputParam = new SqlParameter("@IDFactura", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                gestionDatos.Comando.Parameters.Add(outputParam);

                idGenerado = Convert.ToInt32(gestionDatos.obtenerValor());

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                gestionDatos.cerrarConexion();
            }

            return idGenerado;
        }

        public void ModificarFactura(FacturaPago factura)
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

        public FacturaPago obtenerFactura(int idFactura)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDFactura, Numero, FechaEmision, CUILEmisor, RazonSocial, IDFormadePago, IDOrden, Total FROM Factura WHERE IDFactura = @IDFactura");
                datos.setearParametro("@IDFactura", idFactura);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    FacturaPago factura = new FacturaPago();
                    factura.idFactura = (int)datos.Lector["IDFactura"];
                    factura.NumeroFactura = (int)datos.Lector["Numero"];
                    factura.FechaEmision = (DateTime)datos.Lector["FechaEmision"];
                    factura.cuilEmisor = (long)datos.Lector["CUILEmisor"];
                    factura.razonSocial = (string)datos.Lector["RazonSocial"];
                    factura.formaDePago.idFormaDePago = (int)datos.Lector["IDFormadePago"];
                    factura.OrdenesEnvio.idOrdenEnvio = (int)datos.Lector["IDOrden"];
                    factura.Total = (decimal)datos.Lector["Total"];

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

        public int returnIDFactura()
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDFactura FROM Factura ORDER BY IDFactura DESC");
                gestionDatos.ejecutarLectura();

                if (gestionDatos.Lector.Read())
                {
                    return (int)gestionDatos.Lector["IDFactura"];
                }

                throw new Exception("ID no encontrado.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDFactura: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public int returnIDFormaDePago()
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDFormaDePago FROM Factura ORDER BY IDFactura DESC");
                gestionDatos.ejecutarLectura();

                if (gestionDatos.Lector.Read())
                {
                    return (int)gestionDatos.Lector["IDFormaDePago"];
                }

                throw new Exception("ID no encontrado.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDFormaDePago: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

    }
}

