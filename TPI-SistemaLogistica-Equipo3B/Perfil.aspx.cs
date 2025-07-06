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
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["cliente"] != null)
            //{
            //    Cliente cliente = (Cliente)Session["cliente"];

            //    txtNombreCliente.Text = cliente.Nombre;
            //    txtApellidoCliente.Text = cliente.Apellido;
            //    txtCuil.Text = cliente.CUIL.ToString();
            //    txtCorreoCliente.Text = cliente.Usuario.Email;
            //    txtTelClietne.Text = cliente.Telefono;

            //    txtCalleCliente.Text = cliente.Direccion.Calle;
            //    txtNumeroCliente.Text = cliente.Direccion.NumeroCalle.ToString();
            //    txtCiudadCliente.Text = cliente.Direccion.Ciudad;
            //    txtProvCliente.Text = cliente.Direccion.Provincia;
            //    txtCPCliente.Text = cliente.Direccion.CodigoPostal;
            //    txtPisoCliente.Text = cliente.Direccion.Piso;
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx");
            //}

            //btnGuardar.Visible = false;
            //btnModificarPerfil.Visible = true;

            //txtNombreCliente.ReadOnly = true;
            //txtApellidoCliente.ReadOnly = true;
            //txtCuil.ReadOnly = true;
            //txtCorreoCliente.ReadOnly = true;
            //txtTelClietne.ReadOnly = true;
            //txtCalleCliente.ReadOnly = true;
            //txtNumeroCliente.ReadOnly = true;
            //txtCPCliente.ReadOnly = true;
            //txtPisoCliente.ReadOnly = true;
            //txtCiudadCliente.ReadOnly = true;
            //txtProvCliente.ReadOnly = true;

            //Cliente cliente2 = (Cliente)Session["cliente2"];
            //if (cliente2 != null)
            //{
            //    Response.Write("CUIL anterior: " + cliente2.CUIL + "<br>");
            //}

            if (!IsPostBack)
            {
                if (Session["cliente"] != null)
                {
                    Cliente cliente = (Cliente)Session["cliente"];

                    txtNombreCliente.Text = cliente.Nombre;
                    txtApellidoCliente.Text = cliente.Apellido;
                    txtCuil.Text = cliente.CUIL.ToString();
                    txtCorreoCliente.Text = cliente.Usuario.Email;
                    txtTelClietne.Text = cliente.Telefono;

                    txtCalleCliente.Text = cliente.Direccion.Calle;
                    txtNumeroCliente.Text = cliente.Direccion.NumeroCalle.ToString();
                    txtCiudadCliente.Text = cliente.Direccion.Ciudad;
                    txtProvCliente.Text = cliente.Direccion.Provincia;
                    txtCPCliente.Text = cliente.Direccion.CodigoPostal;
                    txtPisoCliente.Text = cliente.Direccion.Piso;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

                btnGuardar.Visible = false;
                btnModificarPerfil.Visible = true;

                txtNombreCliente.ReadOnly = true;
                txtApellidoCliente.ReadOnly = true;
                txtCuil.ReadOnly = true;
                txtCorreoCliente.ReadOnly = true;
                txtTelClietne.ReadOnly = true;
                txtCalleCliente.ReadOnly = true;
                txtNumeroCliente.ReadOnly = true;
                txtCPCliente.ReadOnly = true;
                txtPisoCliente.ReadOnly = true;
                txtCiudadCliente.ReadOnly = true;
                txtProvCliente.ReadOnly = true;
            }

            Cliente cliente2 = (Cliente)Session["cliente2"];
            if (cliente2 != null)
            {
                Response.Write("CUIL anterior: " + cliente2.CUIL + "<br>");
            }
        }

        protected void btnModificarPerfil_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = true;
            btnModificarPerfil.Visible = false;

            txtNombreCliente.ReadOnly = false;
            txtApellidoCliente.ReadOnly = false;
            txtCuil.ReadOnly = false;
            txtCorreoCliente.ReadOnly = false;
            txtTelClietne.ReadOnly = false;
            txtCalleCliente.ReadOnly = false;
            txtNumeroCliente.ReadOnly = false;
            txtCPCliente.ReadOnly = false;
            txtPisoCliente.ReadOnly = false;
            txtCiudadCliente.ReadOnly = false;
            txtProvCliente.ReadOnly = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Visible = false;
            btnModificarPerfil.Visible = true;

            Cliente clienteOriginal = (Cliente)Session["cliente"];
            Cliente clienteNuevo = new Cliente();
            Cliente clienteBuscado = new Cliente();
            GestionCliente gestionCliente = new GestionCliente();
            GestionUsuario gestionUsuario = new GestionUsuario();
            clienteNuevo.Usuario = new Usuario();
            clienteNuevo.Direccion = new Direccion();
            clienteBuscado.Usuario = new Usuario();
            clienteBuscado.Direccion = new Direccion();

            clienteNuevo.Nombre = txtNombreCliente.Text;
            clienteNuevo.Apellido = txtApellidoCliente.Text;
            clienteNuevo.CUIL = long.Parse(txtCuil.Text);
            clienteNuevo.Telefono = txtTelClietne.Text;
            clienteNuevo.Usuario.Email = txtCorreoCliente.Text;

            int idCliente = gestionCliente.returnIDCliente(clienteOriginal.CUIL);
            clienteBuscado = gestionCliente.returnCliente(clienteOriginal.CUIL);

            clienteNuevo.Direccion.Calle = txtCalleCliente.Text;
            clienteNuevo.Direccion.NumeroCalle = int.Parse(txtNumeroCliente.Text);
            clienteNuevo.Direccion.CodigoPostal = txtCPCliente.Text;
            clienteNuevo.Direccion.Piso = txtPisoCliente.Text;
            clienteNuevo.Direccion.Ciudad = txtCiudadCliente.Text;
            clienteNuevo.Direccion.Provincia = txtProvCliente.Text;

            gestionCliente.modificarCliente(clienteNuevo, clienteBuscado);
        }

        protected void btnDarBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    GestionTransportista gestionTransportista = new GestionTransportista();

                    gestionTransportista.darBajaTransportista(id);
                    lblMensaje.Text = "Tu cuenta ha sido dada de baja exitosamente";
                }

                else
                {
                    Session.Add("error", "ID de cliente no válido.");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}