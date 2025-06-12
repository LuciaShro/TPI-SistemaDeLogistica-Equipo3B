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
                GestionUsuario gestionUsuario = new GestionUsuario();
                Direccion direccion = new Direccion();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Apellido = txtApellido.Text;
                //nuevo.CUIL = long.Parse(txtCuil.Text);
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Usuario.User = txtUsername.Text;
                nuevo.Usuario.Email = txtEmail.Text;
                nuevo.Direccion.Calle = txtCalle.Text;
                //nuevo.Direccion.NumeroCalle = int.Parse(txtNumero.Text);
                nuevo.Direccion.Piso = txtPiso.Text;
                nuevo.Direccion.CodigoPostal = txtCP.Text;
                nuevo.Direccion.Provincia = txtProvincia.Text;
                nuevo.Direccion.Ciudad = txtCiudad.Text;
                nuevo.Usuario.Password = txtPassword.Text;


                if (string.IsNullOrWhiteSpace(nuevo.Usuario.User) || string.IsNullOrWhiteSpace(nuevo.Nombre) || string.IsNullOrWhiteSpace(nuevo.Apellido) || string.IsNullOrWhiteSpace(nuevo.Telefono)
                 || string.IsNullOrWhiteSpace(nuevo.Direccion.Calle) || string.IsNullOrWhiteSpace(nuevo.Direccion.CodigoPostal) || string.IsNullOrWhiteSpace(nuevo.Direccion.Provincia) || string.IsNullOrWhiteSpace(nuevo.Direccion.Ciudad) || string.IsNullOrWhiteSpace(nuevo.Usuario.Password))

                {
                    lblMensaje.Text = "Por favor, completa todos los campos obligatorios";
                    return;
                }

                string cuilTexto = txtCuil.Text.Trim();

                if (string.IsNullOrWhiteSpace(cuilTexto) || cuilTexto.Length != 11 || !cuilTexto.All(char.IsDigit))
                {
                    lblMensaje.Text = "El CUIL debe contener 11 dígitos numéricos.";
                    return;
                }

                nuevo.CUIL = long.Parse(cuilTexto);


                if (nuevo.Telefono.Count(char.IsDigit) < 8)
                {
                    lblMensaje.Text = "El número de teléfono debe tener al menos 8 dígitos.";
                    return;
                }

                int numeroCalle;
                if (!int.TryParse(txtNumero.Text.Trim(), out numeroCalle))
                {
                    lblMensaje.Text = "El número de calle debe ser un número válido.";
                    return;
                }
                nuevo.Direccion.NumeroCalle = numeroCalle;

                if(txtPassword.Text != txtConfirmPassword.Text)
                {
                    lblMensaje.Text = "Las contraseñas no coinciden";
                    return;
                }



                if (!gestionCliente.cuilExistente(nuevo.CUIL) && !gestionUsuario.userExistente(nuevo.Usuario.User))
                {
                    gestionCliente.agregarCliente(nuevo);
                }
                else
                {
                    if (gestionCliente.cuilExistente(nuevo.CUIL))
                    {
                        lblMensaje.Text = "Ya se encuentra registrado un usuario con el CUIL indicado.";
                        return;
                    }

                    if (gestionUsuario.userExistente(nuevo.Usuario.User))
                    {
                        lblMensaje.Text = "Ya se encuentra registrada una persona con el Usuario indicado. Intenta con otro.";
                        return;
                    }
                    
                }
               
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }
    }
}