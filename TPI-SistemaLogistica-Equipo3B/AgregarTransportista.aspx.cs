using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class AgregarTransportista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GestionVehiculo vehiculo = new GestionVehiculo();
            ddlVehiculosDisponibles.DataSource = vehiculo.listarVehiculosSinAsignar();
           
            ddlVehiculosDisponibles.DataTextField = "Patente"; // Mostrar esto al usuario
            ddlVehiculosDisponibles.DataValueField = "IDVehiculo"; // Valor real del ítem
            ddlVehiculosDisponibles.DataBind();
            ddlVehiculosDisponibles.Items.Insert(0, new ListItem("-- Seleccionar vehículo --", ""));

            // desplegable en jornada laboral inicio
            ddlInicioJornadaLaboral.Items.Add("-- Seleccionar un horario --");
            ddlInicioJornadaLaboral.Items.Add("8:00");
            ddlInicioJornadaLaboral.Items.Add("14:00");

            // desplegable en jornada laboral fin
            ddlFinJornadaLaboral.Items.Add("-- Seleccionar un horario --");
            ddlFinJornadaLaboral.Items.Add("14:00");
            ddlFinJornadaLaboral.Items.Add("20:00");



        }

        protected void btnCargarFoto_Click(object sender, EventArgs e)
        {
            if (fileUploadFoto.HasFile)
            {
                string nombreArchivo = Path.GetFileName(fileUploadFoto.FileName);
                string rutaCarpeta = Server.MapPath("~/Imagenes/Transportista/");
                string rutaCompleta = Path.Combine(rutaCarpeta, nombreArchivo);

              

                fileUploadFoto.SaveAs(rutaCompleta);

                imgPreview.ImageUrl = "~/Imagenes/Transportista/" + nombreArchivo;


                Session["RutaImagen"] = imgPreview.ImageUrl;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Transportista transportista = new Transportista();
                GestionTransportista gestion = new GestionTransportista();
                GestionUsuario usuarioGestion = new GestionUsuario();
                transportista.Vehiculo = new Vehiculo();
                transportista.usuario = new Usuario();

                transportista.Nombre = txtNombreTransportista.Text;
                transportista.Apellido = txtApellidoTranportista.Text;
                transportista.CuilTransportista = long.Parse(txtCuilTransportista.Text);
                transportista.Telefono = txtTelefonoTransportista.Text;
                transportista.Licencia = txtLicenciaTransportista.Text;
                transportista.HoraInicio = TimeSpan.Parse(txtInicioJornadaLaboral.Text);
                transportista.HoraFin = TimeSpan.Parse(txtFinJornadaLaboral.Text);
                transportista.usuario.User = txtUsuarioTransportista.Text;
                transportista.usuario.Password = txtContraseñaTransportista.Text;
                transportista.usuario.Email = txtEmailTransportista.Text;
                
                if (Session["RutaImagen"] != null)
                {
                    transportista.Imagen = Session["RutaImagen"].ToString();
                }
                else
                {
                    transportista.Imagen = null;
                }

                if(string.IsNullOrWhiteSpace(transportista.Nombre) || string.IsNullOrWhiteSpace(transportista.Apellido) || string.IsNullOrWhiteSpace(transportista.Telefono) ||
                 string.IsNullOrWhiteSpace(transportista.Licencia) || string.IsNullOrWhiteSpace(transportista.usuario.User) || string.IsNullOrEmpty(transportista.usuario.Password) || string.IsNullOrWhiteSpace(transportista.usuario.Email))
                {
                    lblMensajeEnPantalla.Text = "Los cambos deben estar todos completos";
                    return;
                } 
                
                if(txtContraseñaTransportista.Text != txtConfirmarContraseñaTransportista.Text)
                {
                    lblMensajeEnPantalla.Text = "Las contraseñas no coinciden";
                    return;
                }

                if (gestion.cuilExistente(transportista.CuilTransportista))
                {
                    lblMensajeEnPantalla.Text = "Ya se encuentra registrado un Transportista con el CUIL indicado.";
                    return;
                }

                if (usuarioGestion.userExistente(transportista.usuario.User))
                {
                    lblMensajeEnPantalla.Text = "Ya se encuentra registrado un Transportista con el usuario indicado. Intentar nuevamente";
                    return;
                }

                gestion.agregarTranportista(transportista);
                lblMensajeEnPantalla.Text = "Registro exitoso";



            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
           
        }
    }
}