using System;
using System.Collections.Generic;
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
