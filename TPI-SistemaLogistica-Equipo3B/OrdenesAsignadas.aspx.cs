using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestion;
using Dominio;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class OrdenesAsignadas : System.Web.UI.Page
    {
        public List<OrdenesEnvio> ListaOrdenes {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;

                }
                var usuario = (Usuario)Session["usuario"];
                int idTransportista = usuario.idUsuario;

                GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
                List<OrdenesEnvio> todas = ordenes.ListarOrdenes();

                ListaOrdenes = todas.FindAll(o => o.idTransportistaAsignado == idTransportista);

                rptOrdenes.DataSource = ListaOrdenes;
                rptOrdenes.DataBind();
            }
        }
    }
}