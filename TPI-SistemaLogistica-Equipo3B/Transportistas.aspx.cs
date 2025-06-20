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
    public partial class Transportistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GestionTransportista transportista = new GestionTransportista();
                Session.Add("listaTransportistas", transportista.listarTranportistas());
                dgvTransportistas.DataSource = Session["listaTransportistas"];
                dgvTransportistas.DataBind();
            }
        }

        protected void btnAñadirTransportista_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTransportista.aspx");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            GestionTransportista gestionTransportista = new GestionTransportista();
            var lista = gestionTransportista.listarTranportistas();
            dgvTransportistas.DataSource = lista;
            dgvTransportistas.DataBind();
        }

        protected void btnActivo_Click(object sender, EventArgs e)
        {
            GestionTransportista gestionTransportista = new GestionTransportista();
            var lista = gestionTransportista.transportistasActivos();
            dgvTransportistas.DataSource = lista;
            dgvTransportistas.DataBind();
        }

        protected void btnInactivo_Click(object sender, EventArgs e)
        {
            GestionTransportista gestionTransportista = new GestionTransportista();
            var lista = gestionTransportista.transportistasInactivos(); 
            dgvTransportistas.DataSource = lista;
            dgvTransportistas.DataBind();
        }

        protected void dgvTransportistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvTransportistas.SelectedDataKey.Value.ToString();
            Response.Redirect("AdminTransportistas.aspx?id=" + id);

           
        }

        protected void dgvTransportistas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvTransportistas.PageIndex = e.NewPageIndex;
            dgvTransportistas.DataSource = Session["listaTransportistas"]; 
            dgvTransportistas.DataBind();
        }
    }
}
