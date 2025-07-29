using Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class PurchasePending : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string externalReference = Request.QueryString["external_reference"];
                if (int.TryParse(externalReference, out int idVenta))
                {
                    try
                    {
                        var gestor = new GestionEstadoDePagos();
                        gestor.ActualizarEstadoPago(idVenta, 1); // 3 = Pendiente
                    }
                    catch (Exception ex)
                    {
                        lblMensajeError.Text = "Ocurrio un error al actualizar el estado: " + ex.Message;
                    }
                }
            }
        }
    }
    }
}