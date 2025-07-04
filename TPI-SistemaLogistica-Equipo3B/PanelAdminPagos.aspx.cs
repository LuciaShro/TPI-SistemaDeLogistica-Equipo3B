using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class PanelAdminPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cargarRepeater();
                //GestionVenta gestionVenta = new GestionVenta();
                //rptPedidos.DataSource = gestionVenta.listarVenta();
                //rptPedidos.DataBind();
                CargarPedidos();

                
            }
        }
        private void CargarPedidos()
        {
            GestionVenta gestionVenta = new GestionVenta();
            rptPedidos.DataSource = gestionVenta.listarVenta();
            rptPedidos.DataBind();
        }


        protected void rptPedidos_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            GestionEstadoDePagos gestionEstado = new GestionEstadoDePagos();

            int ventaId = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "PagoProceso":
                    gestionEstado.ActualizarEstadoPago(ventaId, 1);
                    break;
                case "PagoRecibido":
                    gestionEstado.ActualizarEstadoPago(ventaId, 2);
                    try
                    {
                        GestionFacturas gestionFacturas = new GestionFacturas();
                        gestionFacturas.AsignarPaqueteConCapacidad(ventaId);
                        string resultado = gestionFacturas.AsignarPaqueteConCapacidad(ventaId);

                        if (resultado == "OK")
                        {
                            lblMensaje.Text = "El paquete fue asignado correctamente.";
                            lblMensaje.CssClass = "alert alert-success";
                        }
                        else if (resultado == "SIN_TRANSPORTISTA")
                        {
                            lblMensaje.Text = "No hay transportistas disponibles para esta zona o con capacidad suficiente.";
                            lblMensaje.CssClass = "alert alert-warning";
                        }
                        else if (resultado == "NO_PAGADO")
                        {
                            lblMensaje.Text = "El estado de pago aún no está marcado como 'Pagado'.";
                            lblMensaje.CssClass = "alert alert-warning";
                        }
                        else
                        {
                            lblMensaje.Text = "Error inesperado: " + resultado;
                            lblMensaje.CssClass = "alert alert-danger";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMensaje.Text = "❌ Error: " + ex.Message;
                        lblMensaje.CssClass = "alert alert-danger";
                        Session["error"] = ex;
                    }
                    break;
                case "PagoRechazado":
                    gestionEstado.ActualizarEstadoPago(ventaId, 3);
                    break;
                case "CancelarOrden":
                    gestionEstado.ActualizarEstadoPago(ventaId, 4);
                    break;
            }

            //Page_Load(null, null);
            CargarPedidos();
            //Response.Redirect(Request.RawUrl);
        }

        private void cargarRepeater()
        {
            GestionVenta gestion = new GestionVenta();
            List<Venta> lista = gestion.listarVenta();

            rptPedidos.DataSource = lista;
            rptPedidos.DataBind();
        }

        public string GetClaseEstadoPago(object estado)
        {
            string estadoStr = estado?.ToString().ToLower();

            System.Diagnostics.Debug.WriteLine("EstadoPago: " + estadoStr);

            switch (estadoStr)
            {
                case "pendiente":
                    return "estado-pendiente";
                case "recibido":
                    return "estado-recibido";
                case "rechazado":
                    return "estado-rechazado";
                case "cancelar orden":
                    return "estado-cancelado";
                default:
                    return "";
            }
        }

        public string GetClaseEstadoEnvio(object estado)
        {
            string estadoStr = estado?.ToString().ToLower();

            switch (estadoStr)
            {
                case "pendiente":
                    return "envio-pendiente";
                case "en transito":
                    return "envio-transito";
                case "entregado":
                    return "envio-entregado";
                case "reprogramado":
                    return "envio-reprogramado";
                case "demorado":
                    return "envio-demorado";
                case "cancelado":
                    return "envio-cancelado";
                default:
                    return "";
            }
        }

    }
}
