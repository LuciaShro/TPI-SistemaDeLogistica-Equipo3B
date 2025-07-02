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
            //Usuario usuario;
            GestionUsuario gestionUser = new GestionUsuario();
            try
            {
                Cliente clienteLogueado = gestionUser.LoginCliente(txtEmail.Text, txtPassword.Text);
                //usuario = new Usuario(txtEmail.Text, txtPassword.Text);
                if (clienteLogueado != null)
                {
                    Session["cliente"] = clienteLogueado;
                    Session["usuario"] = clienteLogueado.Usuario;
                    Response.Redirect("CargarOrden.aspx", false);
                }
                else
                {
                    Usuario empresaLogueado = gestionUser.loginEmpresa(txtEmail.Text, txtPassword.Text);

                    if (empresaLogueado != null)
                    {
                        Session["usuario"] = empresaLogueado;
                        if (empresaLogueado.tipoUsuario == Usuario.TipoUsuario.admin)
                        {
                            Response.Redirect("Inicio.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("OrdenesAsignadas.aspx", false);
                        }

                    }

                    else
                    {
                        //Session.Add("error", "Usuario o contraseña incorrecta");
                        //Response.Redirect("Login.aspx", false);
                        lblError.Text = "Usuario o contraseña incorrecta";
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }

        }

        protected bool validacionUsuario(Dominio.Usuario.TipoUsuario tipoEsperado)
        {
            if (Session["usuario"] != null){
                var usuario = (Dominio.Usuario)Session["usuario"];
                return usuario.tipoUsuario == tipoEsperado;
            }
            return false;
            
        }
    }
}