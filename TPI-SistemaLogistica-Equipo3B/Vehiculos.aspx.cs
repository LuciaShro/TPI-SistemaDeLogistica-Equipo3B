using Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GestionVehiculo vehiculo = new GestionVehiculo();
                Session.Add("listaVehiculos", vehiculo.listarVehiculos());
                gvVehiculos.DataSource = Session["listaVehiculos"];
                gvVehiculos.DataBind();
            }
        }

        protected void btnAñadirVehiculo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarVehiculo.aspx");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            GestionVehiculo gestionVehiculo = new GestionVehiculo();
            var lista = gestionVehiculo.listarVehiculos();
            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();
        }

        protected void btnAsignados_Click(object sender, EventArgs e)
        {
            GestionVehiculo gestionVehiculo = new GestionVehiculo();
            var lista = gestionVehiculo.vehiculosAsignados();
            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();
        }

        protected void btnNoAsignados_Click(object sender, EventArgs e)
        {
            GestionVehiculo gestionVehiculo = new GestionVehiculo();
            var lista = gestionVehiculo.listarVehiculosSinAsignar();
            gvVehiculos.DataSource = lista;
            gvVehiculos.DataBind();
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}