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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente nuevo = new Cliente();
                nuevo.Usuario = new Usuario();
                nuevo.Direccion = new Direccion();
                GestionCliente gestionCliente = new GestionCliente();
                Direccion direccion = new Direccion();
                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                nuevo.CUIL = long.Parse(txtCuil.Text);
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Usuario.User = txtUsername.Text;
                nuevo.Usuario.Email = txtEmail.Text;
                nuevo.Direccion.Calle = txtCalle.Text;
                nuevo.Direccion.NumeroCalle = int.Parse(txtNumero.Text);
                nuevo.Direccion.Piso = txtPiso.Text;
                nuevo.Direccion.CodigoPostal =txtCP.Text;
                nuevo.Direccion.Provincia = txtProvincia.Text;
                nuevo.Direccion.Ciudad = txtCiudad.Text;
                nuevo.Usuario.Password = txtPassword.Text;

                gestionCliente.agregarCliente(nuevo);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}