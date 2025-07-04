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

                dgvOrdenesAsignadas.DataSource = ListaOrdenes;
                dgvOrdenesAsignadas.DataBind();
            }
        }

        protected void dgvOrdenesAsignadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idOrden = Convert.ToInt32(dgvOrdenesAsignadas.SelectedDataKey.Value);
            Response.Redirect("DetalleDeOrden.aspx?id=" + idOrden);
        }

        protected void dgvOrdenesAsignadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvOrdenesAsignadas.PageIndex = e.NewPageIndex;
            dgvOrdenesAsignadas.DataSource = ListaOrdenes;
            dgvOrdenesAsignadas.DataBind();
        }

        protected void btnComenzarViaje_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = (Usuario)Session["usuario"];
                int idTransportista = usuario.idUsuario;

                GestionOrdenesEnvio gestion = new GestionOrdenesEnvio();
                gestion.ComenzarViajeTransportista(idTransportista, DateTime.Today);

                ListaOrdenes = gestion.ListarOrdenes().Where(o => o.idTransportistaAsignado == idTransportista).ToList();

                EmailService emailService = new EmailService();
                foreach (var orden in ListaOrdenes)
                {
                    string provincia = gestion.ObtenerProvinciaOrden(orden.idOrdenEnvio);
                    emailService.armarCorreo(orden.destinatario.Email, orden.destinatario.Nombre, orden.idOrdenEnvio.ToString(), 1, provincia);
                    emailService.enviarMail();

                    gestion.ActualizarEstadoYFechaEnvio(orden.idOrdenEnvio, 1);
                }

                dgvOrdenesAsignadas.DataSource = ListaOrdenes;
                dgvOrdenesAsignadas.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}