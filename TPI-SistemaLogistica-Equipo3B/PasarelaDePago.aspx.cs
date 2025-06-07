using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class PasarelaDePago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //pnlTransferencia.Visible = rblPago.SelectedValue == "Transferencia";
                SeleccionarMetodoPago("Transferencia");
            }
        }


        protected void btnTransferencia_Click(object sender, EventArgs e)
        {
            SeleccionarMetodoPago("Transferencia");
        }

        protected void btnMercadoPago_Click(object sender, EventArgs e)
        {
            SeleccionarMetodoPago("MercadoPago");
        }

        private void SeleccionarMetodoPago(string metodo)
        {
            pnlTransferencia.Visible = metodo == "Transferencia";

            btnTransferencia.CssClass = metodo == "Transferencia" ? "boton-pago boton-activo" : "boton-pago";
            btnMercadoPago.CssClass = metodo == "MercadoPago" ? "boton-pago boton-activo" : "boton-pago";

            ViewState["MetodoPagoSeleccionado"] = metodo;
        }

        protected void btnCompletarPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("MensajePago.aspx");
        }

    }
}