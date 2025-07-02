using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Default.aspx", false);
        }

        protected bool validacionUsuario(Dominio.Usuario.TipoUsuario tipoEsperado)
        {
            if (Session["usuario"] != null)
            {
                var usuario = (Dominio.Usuario)Session["usuario"];
                return usuario.tipoUsuario == tipoEsperado;
            }
            return false;

        }
    }
}