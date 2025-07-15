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
                gestionDatos.setearParametro("@FechaVencimiento", factura.FechaVencimiento);
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
                datos.setearConsulta("SELECT f.IDFactura, f.Numero, f.FechaEmision, f.FechaVencimiento, f.CUILEmisor, f.RazonSocial, fp.MedioDePago, f.IDOrden, f.Total, ep.Estado FROM Factura as f INNER JOIN FormaDePago as fp ON fp.IDFormaDePago = f.IDFormadePago INNER JOIN EstadoDePago as ep ON ep.IDEstadoPago = fp.IDEstadoPago WHERE IDFactura = @IDFactura");
                datos.setearParametro("@IDFactura", idFactura);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    FacturaPago factura = new FacturaPago();
                    factura.formaDePago = new FormaDePago(); 
                    factura.OrdenesEnvio = new OrdenesEnvio();
                    factura.formaDePago.estadoDePago = new EstadoDePago();

                    factura.idFactura = Convert.ToInt32(datos.Lector["IDFactura"]);
                    factura.NumeroFactura = Convert.ToInt32(datos.Lector["Numero"]);
                    factura.FechaEmision = Convert.ToDateTime(datos.Lector["FechaEmision"]);
                    factura.FechaVencimiento = Convert.ToDateTime(datos.Lector["FechaVencimiento"]);
                    factura.cuilEmisor = Convert.ToInt64(datos.Lector["CUILEmisor"]);
                    factura.razonSocial = datos.Lector["RazonSocial"].ToString();
                    factura.formaDePago.medioDePago = datos.Lector["MedioDePago"].ToString();
                    factura.formaDePago.estadoDePago.nombreEstado = datos.Lector["Estado"].ToString();
                    factura.OrdenesEnvio.idOrdenEnvio = Convert.ToInt32(datos.Lector["IDOrden"]);
                    factura.Total = Convert.ToDecimal(datos.Lector["Total"]);

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
                gestionDatos.setearConsulta("SELECT TOP 1 IDFactura FROM Factura ORDER BY IDFactura DESC");
                gestionDatos.ejecutarLectura();

                if (gestionDatos.Lector.Read())
                {
                    if (!gestionDatos.Lector.IsDBNull(0))
                        return Convert.ToInt32(gestionDatos.Lector[0]);
                }

                return 0;

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

        public List<FacturaPago> listarFacturas()
        {
            List<FacturaPago> lista = new List<FacturaPago>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDFactura ,Numero, FechaEmision, FechaVencimiento, CUILEmisor, RazonSocial, fp.MedioDePago, f.IDOrden,f.Total, fp.FechaDePago, estadoP.Estado, c.Nombre +  ' '  + c.Apellido as Nombre FROM Factura AS F inner join FormaDePago AS fp ON fp.IDFormaDePago = f.IDFormadePago\r\ninner join EstadoDePago AS estadoP ON estadoP.IDEstadoPago = fp.IDEstadoPago\r\ninner join OrdenesEnvio AS od ON od.IDOrden = f.IDOrden inner join Clientes AS c ON c.IDCliente = od.IDCliente where fp.IDEstadoPago = 2;");

                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    FacturaPago factura = new FacturaPago();
                    factura.formaDePago = new FormaDePago();
                    factura.OrdenesEnvio = new OrdenesEnvio();
                    factura.formaDePago.estadoDePago = new EstadoDePago();
                    factura.OrdenesEnvio.cliente = new Cliente();

                    factura.idFactura = Convert.ToInt32(gestionDatos.Lector["IDFactura"]);
                    factura.NumeroFactura = Convert.ToInt32(gestionDatos.Lector["Numero"]);
                    factura.FechaEmision = Convert.ToDateTime(gestionDatos.Lector["FechaEmision"]);
                    factura.FechaVencimiento = Convert.ToDateTime(gestionDatos.Lector["FechaVencimiento"]);
                    factura.cuilEmisor = Convert.ToInt64(gestionDatos.Lector["CUILEmisor"]);
                    factura.OrdenesEnvio.idOrdenEnvio = Convert.ToInt32(gestionDatos.Lector["IDOrden"]);
                    factura.Total = Convert.ToDecimal(gestionDatos.Lector["Total"]);
                    factura.formaDePago.medioDePago = gestionDatos.Lector["MedioDePago"].ToString();
                    factura.formaDePago.fechaDePago = Convert.ToDateTime(gestionDatos.Lector["FechaDePago"]);
                    factura.formaDePago.estadoDePago.nombreEstado = gestionDatos.Lector["Estado"].ToString();
                    factura.OrdenesEnvio.cliente.Nombre = gestionDatos.Lector["Nombre"].ToString();

                    lista.Add(factura);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public List<FacturaPago> listarFacturasCanceladas()
        {
            List<FacturaPago> lista = new List<FacturaPago>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDFactura ,Numero, FechaEmision, CUILEmisor, RazonSocial, fp.MedioDePago, f.IDOrden,f.Total, fp.FechaDePago, estadoP.Estado, c.Nombre +  ' '  + c.Apellido as Nombre FROM Factura AS F inner join FormaDePago AS fp ON fp.IDFormaDePago = f.IDFormadePago inner join EstadoDePago AS estadoP ON estadoP.IDEstadoPago = fp.IDEstadoPago inner join OrdenesEnvio AS od ON od.IDOrden = f.IDOrden inner join Clientes AS c ON c.IDCliente = od.IDCliente where fp.IDEstadoPago = 4;");

                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    FacturaPago factura = new FacturaPago();
                    factura.formaDePago = new FormaDePago();
                    factura.OrdenesEnvio = new OrdenesEnvio();
                    factura.formaDePago.estadoDePago = new EstadoDePago();
                    factura.OrdenesEnvio.cliente = new Cliente();

                    factura.idFactura = Convert.ToInt32(gestionDatos.Lector["IDFactura"]);
                    factura.NumeroFactura = Convert.ToInt32(gestionDatos.Lector["Numero"]);
                    factura.FechaEmision = Convert.ToDateTime(gestionDatos.Lector["FechaEmision"]);
                    factura.cuilEmisor = Convert.ToInt64(gestionDatos.Lector["CUILEmisor"]);
                    factura.OrdenesEnvio.idOrdenEnvio = Convert.ToInt32(gestionDatos.Lector["IDOrden"]);
                    factura.Total = Convert.ToDecimal(gestionDatos.Lector["Total"]);
                    factura.formaDePago.medioDePago = gestionDatos.Lector["MedioDePago"].ToString();
                    factura.formaDePago.fechaDePago = Convert.ToDateTime(gestionDatos.Lector["FechaDePago"]);
                    factura.formaDePago.estadoDePago.nombreEstado = gestionDatos.Lector["Estado"].ToString();
                    factura.OrdenesEnvio.cliente.Nombre = gestionDatos.Lector["Nombre"].ToString();

                    lista.Add(factura);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public string AsignarPaqueteConCapacidad(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("AsignarPaqueteConControlDeCapacidad");
                datos.setearParametro("@IDVenta", idVenta);
                return datos.obtenerValor().ToString();
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

    }
}

