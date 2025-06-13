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
            dgvOrdenes.DataSource = ordenes.ListarOrdenes();    
            dgvOrdenes.DataBind();

        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarOrden.aspx");
        }
    }
}