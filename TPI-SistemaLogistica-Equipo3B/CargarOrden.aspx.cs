using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class CargarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cliente"] != null)
                {
                    Cliente clienteLogueado = (Cliente)Session["cliente"];

                    txtNombreOrigen.Text = clienteLogueado.Nombre;
                    txtTelefonoOrigen.Text = clienteLogueado.Telefono;
                    txtEmailOrigen.Text = clienteLogueado.Usuario.Email;
                    txtDireccionOrigen.Text = clienteLogueado.Direccion.Calle;
                    txtCalleOrigen.Text = clienteLogueado.Direccion.NumeroCalle.ToString();
                    txtCPOrigen.Text = clienteLogueado.Direccion.CodigoPostal;
                    txtLocalidadOrigen.Text = clienteLogueado.Direccion.Ciudad;
                    txtProvinciaOrigen.Text = clienteLogueado.Direccion.Provincia;
                    txtPisoOrigen.Text = clienteLogueado.Direccion.Piso;

                }
                else
                {
                    Response.Redirect("ErrorLogin.aspx");
                }
            }

        }
    }
}