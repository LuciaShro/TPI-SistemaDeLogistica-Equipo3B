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
    public partial class AdminTransportistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    GestionTransportista gestion = new GestionTransportista();
                    Transportista transportista = gestion.obtenerTransportista(id);

                    if (transportista != null)
                    {
                        lblEmail.Text = transportista.usuario.Email ?? "--";
                        lblNombre.Text = transportista.Nombre ?? "--";
                        lblApellido.Text = transportista.Apellido ?? "--";
                        lblCuil.Text = transportista.CuilTransportista.ToString();
                        lblTelefono.Text = transportista.Telefono ?? "--";
                        lblLicencia.Text = transportista.Licencia ?? "--";
                        lblEstado.Text = transportista.Activo ? "Activo" : "Inactivo";
                        lblHorarioInicio.Text = transportista.HoraInicio.ToString(@"hh\:mm");
                        lblHorarioFin.Text = transportista.HoraFin.ToString(@"hh\:mm");
                    }

                    if (transportista.Activo)
                    {
                        btnDarBajaTransportista.Visible = true;
                    }
                    else
                    {
                        btnReactivarTransportista.Visible= true;
                    }
                }
                else
                {
                    Response.Redirect("Transportistas.aspx");
                }
            }
        }

        protected void btnDarBajaTransportista_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    GestionTransportista gestionTransportista = new GestionTransportista();

                    gestionTransportista.darBajaTransportista(id);
                    lblMensajePantalla.Text = "Transportista dado de baja exitosamente";
                }

                else
                {
                   Session.Add("error", "ID de transportista no válido.");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnReactivarTransportista_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    GestionTransportista gestionTransportista = new GestionTransportista();

                    gestionTransportista.reactivarTransportista(id);
                    lblMensajePantalla.Text = "Transportista reactivado exitosamente";
                }

                else
                {
                    Session.Add("error", "ID de transportista no válido.");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtEmail.Text = lblEmail.Text == "--" ? "" : lblEmail.Text;
            txtNombre.Text = lblNombre.Text == "--" ? "" : lblNombre.Text;
            txtApellido.Text = lblApellido.Text == "--" ? "" : lblApellido.Text;
            txtCuil.Text = lblCuil.Text == "--" ? "" : lblCuil.Text;
            txtTelefono.Text = lblTelefono.Text == "--" ? "" : lblTelefono.Text;
            txtLicencia.Text = lblLicencia.Text == "--" ? "" : lblLicencia.Text;
            txtHorarioInicio.Text = lblHorarioInicio.Text == "--" ? "" : lblHorarioInicio.Text;
            txtHorarioFin.Text = lblHorarioFin.Text == "--" ? "" : lblHorarioFin.Text;


            txtEmail.Visible = true;
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtCuil.Visible = true;
            txtTelefono.Visible = true;
            txtLicencia.Visible = true;
            txtHorarioInicio.Visible = true;
            txtHorarioFin.Visible = true;

        
            lblEmail.Visible = false;
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblCuil.Visible = false;
            lblTelefono.Visible = false;
            lblLicencia.Visible = false;
            lblHorarioInicio.Visible = false;
            lblHorarioFin.Visible = false;

            
            btnGuardarCambios.Visible = true;
            btnCancelar.Visible = true;

            
            btnModificar.Visible = false;
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int id))
            {
                Transportista t = new Transportista();
                t.IdTransportista = id;
                t.usuario = new Usuario();
                t.usuario.Email = txtEmail.Text;
                t.Nombre = txtNombre.Text;
                t.Apellido = txtApellido.Text;
                t.CuilTransportista = long.TryParse(txtCuil.Text, out long cuil) ? cuil : 0;
                t.Telefono = txtTelefono.Text;
                t.Licencia = txtLicencia.Text;
                t.HoraInicio = TimeSpan.TryParse(txtHorarioInicio.Text, out TimeSpan hIni) ? hIni : TimeSpan.Zero;
                t.HoraFin = TimeSpan.TryParse(txtHorarioFin.Text, out TimeSpan hFin) ? hFin : TimeSpan.Zero;

                try
                {
                    GestionTransportista gestion = new GestionTransportista();
                    gestion.ModificarTransportista(t);

                    lblMensajePantalla.Text = "Transportista modificado correctamente.";
                    lblMensajePantalla.CssClass = "text-success";

                    
                    lblNombre.Text = t.Nombre;
                    lblApellido.Text = t.Apellido;
                    lblCuil.Text = t.CuilTransportista.ToString();
                    lblTelefono.Text = t.Telefono;
                    lblLicencia.Text = t.Licencia;
                    lblHorarioInicio.Text = t.HoraInicio.ToString(@"hh\:mm");
                    lblHorarioFin.Text = t.HoraFin.ToString(@"hh\:mm");

                   
                }
                catch (Exception ex)
                {
                    lblMensajePantalla.Text = "Error al modificar el transportista: " + ex.Message;
                    lblMensajePantalla.CssClass = "text-danger";
                }
            }


        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ModoSoloLectura();
        }

        private void ModoSoloLectura()
        {
            
            lblEmail.Visible = true;
            lblNombre.Visible = true;
            lblApellido.Visible = true;
            lblCuil.Visible = true;
            lblTelefono.Visible = true;
            lblLicencia.Visible = true;
            lblHorarioInicio.Visible = true;
            lblHorarioFin.Visible = true;

           
            txtEmail.Visible = false;
            txtNombre.Visible = false;
            txtApellido.Visible = false;
            txtCuil.Visible = false;
            txtTelefono.Visible = false;
            txtLicencia.Visible = false;
            txtHorarioInicio.Visible = false;
            txtHorarioFin.Visible = false;

            
            btnModificar.Visible = true;

            
            btnGuardarCambios.Visible = false;
            btnCancelar.Visible = false;
        }
    }
}