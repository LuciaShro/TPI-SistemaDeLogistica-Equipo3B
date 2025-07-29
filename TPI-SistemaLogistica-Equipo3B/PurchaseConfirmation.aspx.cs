using Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class PurchaseConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string status = Request.QueryString["status"];
                string externalReference = Request.QueryString["external_reference"];

                if (status == "approved" && int.TryParse(externalReference, out int idVenta))
                {
                    try
                    {
                        var gestor = new GestionEstadoDePagos();
                        gestor.ActualizarEstadoPago(idVenta, 2); // 2 = Recibido

                        // Mostrar mensaje en pantalla o redirigir a página de éxito
                        // Response.Redirect("ConfirmacionFinal.aspx"); // opcional
                    }
                    catch (Exception ex)
                    {
                        // Podés loguearlo o mostrar un error
                        // Por ejemplo: lblMensaje.Text = "Ocurrió un error al actualizar el estado.";
                        Console.WriteLine(ex.Message);
                    }
                }
            }
    }
}