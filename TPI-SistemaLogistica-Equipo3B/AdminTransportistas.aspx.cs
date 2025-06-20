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
    public partial class AdminTransportistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDarBajaTransportista_Click(object sender, EventArgs e)
        {
            try
            {
                Transportista transportista = new Transportista();
                GestionTransportista gestionTransportista = new GestionTransportista();

                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}