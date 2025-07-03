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
    public partial class ResumenFacturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string estado = Request.QueryString["estado"];
                GestionFacturas gestionFacturas = new GestionFacturas();

                List<FacturaPago> facturas;

                if (estado == "canceladas")
                {
                    facturas = gestionFacturas.listarFacturasCanceladas();
                    canceladasLink.Visible = false;
                }
                else
                {
                    facturas = gestionFacturas.listarFacturas();
                }
                   

                rptFacturas.DataSource = facturas;
                rptFacturas.DataBind();

                lblTotalFacturado.Text = facturas.Sum(f => f.Total).ToString("C");
                lblCantidadTotal.Text = $"de {facturas.Count} facturas";
                lblCantidadFacturas.Text = facturas.Count.ToString();
            }
        }

        protected string GetClaseEstado(string estado)
        {
            switch (estado.ToUpper())
            {
                case "RECIBIDO":
                    return "entregado";
                case "CANCELAR ORDEN":
                    return "cancelado";
                default:
                    return ""; 
            }
        }
    }
}