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
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                FiltroAvanzado = false;
                GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
                Session.Add("listaOrdenes", ordenes.ListarOrdenes());
                dgvOrdenes.DataSource = Session["listaOrdenes"];
                dgvOrdenes.DataBind();
            }
        }

        protected void btnAñadir_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargarOrden.aspx");
        }

        protected void dgvOrdenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var algo = dgvOrdenes.SelectedRow.Cells[0];
            var id = dgvOrdenes.SelectedDataKey.Value.ToString();
            Response.Redirect("DetalleDeOrden.aspx?OrdenId="+ id);
        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<OrdenesEnvio> lista = (List<OrdenesEnvio>)Session["listaOrdenes"];
            List<OrdenesEnvio> listafiltrada = lista.FindAll(x => x.cliente.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.cliente.Apellido.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.estado.DescripcionEstado.ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.transportista.Nombre.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.FechaCreacion.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.FechaEnvio.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.FechaEstimadaLlegada.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper()) ||
            x.FechaDeLlegada.ToString().ToUpper().Contains(txtFiltro.Text.ToUpper())
            );
            dgvOrdenes.DataSource = listafiltrada;
            dgvOrdenes.DataBind();
        }

        protected void dgvOrdenes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenes.PageIndex= e.NewPageIndex;
            dgvOrdenes.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        
    }
}