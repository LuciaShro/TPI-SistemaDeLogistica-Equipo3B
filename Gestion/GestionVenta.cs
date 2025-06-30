using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionVenta
    {
        public void AgregarVenta(Venta venta)
        {

            AccesoDatos gestionDatos = new AccesoDatos();
            int idGenerado = 0;

            try
            {
                gestionDatos.setearConsulta("INSERT INTO Venta (IDOrden, IDFactura) " +
                                           "VALUES (@IDOrden, @IDFactura);" +
                                           "SELECT SCOPE_IDENTITY();");

                gestionDatos.setearParametro("@IDOrden", venta.OrdenesEnvio.idOrdenEnvio);
                gestionDatos.setearParametro("@IDFactura", venta.Factura.idFactura);

                object resultado = gestionDatos.ejecutarScalar();

                if (resultado != null)
                    idGenerado = Convert.ToInt32(resultado);

                //gestionDatos.ejecutarAccion();

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

        public void ModificarVenta(Venta venta)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Venta SET IDOrden = @IDOrden, IDFactura = @IDFactura WHERE IDVenta = IDVenta");

                gestionDatos.setearParametro("@IDOrden", venta.OrdenesEnvio.idOrdenEnvio);
                gestionDatos.setearParametro("@IDFactura", venta.Factura.idFactura);

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

        public void EliminarVenta(int id)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("UPDATE Venta SET Activo = 0 WHERE IDVenta = IDVenta");
                gestionDatos.setearParametro("@IDVenta", id);
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

        public List<Venta> listarVenta()
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos gestionDatos = new AccesoDatos();
            // idventa -> tabla ventas
            // cliente, fecha, EstadoEnvio -> tabla orden
            // EstadoDelPago -> tabla Factura > tabla Forma de pago
            // total -> tabla detalle

            try
            {
                gestionDatos.setearConsulta("SELECT * FROM vw_ListadoVentas");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.OrdenesEnvio = new OrdenesEnvio();
                    venta.OrdenesEnvio.cliente = new Cliente();
                    venta.OrdenesEnvio.estado = new EstadoOrdenEnvio();
                    venta.Factura = new FacturaPago();
                    venta.Factura.formaDePago = new FormaDePago();
                    venta.Factura.formaDePago.estadoDePago = new EstadoDePago();

                    // Asignación segura con validaciones
                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("VentaID")))
                        venta.VentaID = Convert.ToInt32(gestionDatos.Lector["VentaID"]);

                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("Cliente")))
                        venta.OrdenesEnvio.cliente.Nombre = gestionDatos.Lector["Cliente"].ToString();

                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("EstadoEnvio")))
                        venta.OrdenesEnvio.estado.DescripcionEstado = gestionDatos.Lector["EstadoEnvio"].ToString();

                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("Fecha")))
                        venta.Factura.FechaEmision = Convert.ToDateTime(gestionDatos.Lector["Fecha"]);

                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("EstadoPago")))
                        venta.Factura.formaDePago.estadoDePago.nombreEstado = gestionDatos.Lector["EstadoPago"].ToString();

                    if (!gestionDatos.Lector.IsDBNull(gestionDatos.Lector.GetOrdinal("Total")))
                        venta.Factura.Total = Convert.ToDecimal(gestionDatos.Lector["Total"]);

                    lista.Add(venta);
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
    }
}
