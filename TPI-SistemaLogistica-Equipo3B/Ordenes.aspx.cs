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
    public partial class Ordenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    var listaOrdenes = ObtenerOrdenes(); // método que trae datos
            //    rptOrdenes.DataSource = listaOrdenes;
            //    rptOrdenes.DataBind();
            //}

            GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
            Session.Add("listaOrdenes", ordenes.ListarOrdenes());
            dgvOrdenes.DataSource = Session["listaOrdenes"];    
            dgvOrdenes.DataBind();

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarOrden.aspx");
        }

        protected void dgvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var algo = dgvOrdenes.SelectedRow.Cells[0];
            var id = dgvOrdenes.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleDeOrden.aspx?="+ id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Ordenes> lista = (List<Ordenes>)Session["listaOrdenes"];
        }
    }
}