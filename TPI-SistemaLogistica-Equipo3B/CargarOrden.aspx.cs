using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

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

        protected void btnCotizar_Click(object sender, EventArgs e)
        {

            OrdenesEnvio ordenesEnvio = new OrdenesEnvio();
            Cliente cliente = new Cliente();
            Destinatario destinatario = new Destinatario();
            Paquete paquete = new Paquete();
            AccesoDatos gestion = new AccesoDatos();
            
            cliente.Nombre = txtNombreOrigen.Text;
            cliente.Apellido = txtApellidoOrigen.Text;
            cliente.Telefono = txtTelefonoOrigen.Text;
            cliente.Direccion.Calle = txtCalleOrigen.Text;
            cliente.Direccion.Numero = int.Parse(txtNumeroOrigen.Text);
            cliente.Direccion.CodigoPostal = txtCPOrigen.Text;
            cliente.Direccion.Ciudad = txtCiudadOrigen.Text;
            cliente.Direccion.Provincia = txtProvinciaOrigen.Text;
            cliente.Direccion.Piso = txtPisoOrigen.Text;
            cliente.InfoAdicional = txtInfoOrigen.Text;


            destinatario.Nombre = txtNombreDestino.Text;
            destinatario.Apellido = txtApellidoDestino.Text;
            destinatario.Telefono = txtTelefonoDestino.Text;
            destinatario.Direccion.Calle = txtCalleDestino.Text;
            destinatario.Direccion.Numero = int.Parse(txtNumeroDestino.Text);
            destinatario.Direccion.CodigoPostal = txtCPDestino.Text;
            destinatario.Direccion.Ciudad = txtCiudadDestino.Text;
            destinatario.Direccion.Provincia = txtProvinciaDesino.Text;
            destinatario.Direccion.Piso = txtPisoDestino.Text;
            destinatario.InfoAdicional = txtInfoDestino.Text;

            paquete.Largo = float.Parse(txtLargo.Text);
            paquete.Ancho = float.Parse(txtAncho.Text);
            paquete.Alto = float.Parse(txtAlto.Text);
            paquete.Peso = float.Parse(txtPeso.Text);
            paquete.ValorDeclarado = decimal.Parse(txtValor.Text);
        }
    }
}