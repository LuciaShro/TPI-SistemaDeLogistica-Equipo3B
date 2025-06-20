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

        }

        protected void btnAñadirTransportista_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarTransportista.aspx");
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {

        }

        protected void btnActivo_Click(object sender, EventArgs e)
        {
            GestionTransportista gestionTransportista = new GestionTransportista();
            
        }

        protected void btnInactivo_Click(object sender, EventArgs e)
        {

        }
    }
}