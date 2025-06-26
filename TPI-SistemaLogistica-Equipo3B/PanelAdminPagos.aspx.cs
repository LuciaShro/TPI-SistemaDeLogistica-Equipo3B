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
                GestionVenta gestionVenta = new GestionVenta();
                rptPedidos.DataSource = gestionVenta.listarVenta();
                rptPedidos.DataBind();
            }
        }

        protected void rptPedidos_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            int ventaId = int.Parse(e.CommandArgument.ToString());

            switch (e.CommandName)
            {
                case "PagoProceso":
                    // Lógica para marcar como en proceso
                    break;
                case "PagoRecibido":
                    // Lógica para marcar como recibido
                    break;
                case "PagoRechazado":
                    // Lógica para marcar como rechazado
                    break;
                case "CancelarOrden":
                    // Lógica para cancelar orden
                    break;
            }

            // Recargar datos
            Page_Load(null, null);
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
                    return "estado-proceso";
                case "rechazado":
                    return "estado-rechazado";
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
                    return "envio-proceso";
                case "entregado":
                    return "envio-recibido";
                default:
                    return "";
            }
        }
    }
}
