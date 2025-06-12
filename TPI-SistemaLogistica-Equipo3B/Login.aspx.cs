using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario;
            GestionUsuario gestionUser = new GestionUsuario();
            try
            {
                usuario = new Usuario(txtEmail.Text, txtPassword.Text);
                if (gestionUser.Login(usuario))
                {
                    Session.Add("usuario", usuario);
                    Response.Redirect("Inicio.aspx", false);
                }
                else
                {
                    //Session.Add("error", "Usuario o contraseña incorrecta");
                    //Response.Redirect("Login.aspx", false);
                    lblError.Text = "Usuario o contraseña incorrecta";
                    lblError.Visible = true;
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }
    }
}