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
            if (Session["cliente"] != null)
            {
                Cliente cliente = (Cliente)Session["cliente"];

                txtNombreCliente.Text = cliente.Nombre;
                txtApellidoCliente.Text = cliente.Apellido;
                txtCuil.Text = cliente.CUIL.ToString();
                txtTelClietne.Text = cliente.Usuario.Email;
                txtCorreoCliente.Text = cliente.Telefono;

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
        }

        protected void btnModificarPerfil_Click(object sender, EventArgs e)
        {
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

            //btnGuardar.Visible = true;
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    Cliente cliente = new Cliente();
        //    Direccion direccion = new Direccion();
        //    GestionCliente gestionCliente = new GestionCliente();

        //    cliente.Nombre = txtNombreCliente.Text;
        //    cliente.Apellido = txtApellidoCliente.Text;
        //    cliente.CUIL = long.Parse(txtCuil.Text);
        //    cliente.Telefono = txtTelClietne.Text;
        //    cliente.Usuario.Email = txtCorreoCliente.Text;

        //    direccion.Calle = txtCalleCliente.Text;
        //    direccion.NumeroCalle = int.Parse(txtNumeroCliente.Text);
        //    direccion.CodigoPostal = txtCPCliente.Text;
        //    direccion.Piso = txtPisoCliente.Text;
        //    direccion.Ciudad = txtCiudadCliente.Text;
        //    direccion.Provincia = txtProvCliente.Text;

        //    gestionCliente.modificarCliente(cliente, direccion);
        //}
    }
}