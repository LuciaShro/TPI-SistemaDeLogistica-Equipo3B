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
    public partial class DetalleVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    GestionEstadoVehiculo gestionEstados = new GestionEstadoVehiculo();
                    ddlEstadoVehiculo.DataSource = gestionEstados.listarEstadoVehiculo();
                    ddlEstadoVehiculo.DataTextField = "descripcioEstado";
                    ddlEstadoVehiculo.DataValueField = "IDEstado";
                    ddlEstadoVehiculo.DataBind();

                    if (int.TryParse(Request.QueryString["id"], out int id))
                    {
                        GestionVehiculo gestion = new GestionVehiculo();
                        Vehiculo vehiculo = gestion.listarVehiculos(id.ToString())[0];

                        if (vehiculo != null)
                        {

                            lblPatente.Text = vehiculo.Patente ?? "--";
                            lblCapacidadCarga.Text = vehiculo.CapacidadCarga.ToString();
                            lblComentario.Text = vehiculo.Comentario ?? "--";
                            lblDisponibilidad.Text = vehiculo.Disponible ? "Disponible" : "No disponible";
                            lblEstado.Text = vehiculo.estadoVehiculo.descripcioEstado ?? "--";
                            ddlEstadoVehiculo.SelectedValue = vehiculo.estadoVehiculo.descripcioEstado.ToString();

                            if (vehiculo.Activo)
                            {
                                btnDarBajaVehiculo.Visible = true;
                            }
                            else
                            {
                                btnReactivarVehiculo.Visible = true;
                            }
                        }
                        else
                        {
                            Response.Redirect("Vehiculos.aspx");
                        }
                    }
                    else
                    {
                        Response.Redirect("Vehiculos.aspx");
                    }
                    }
                
            }

            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnDarBajaVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    new GestionVehiculo().darDeBajaVehiculo(id);
                   lblMensajePantallaVehiculo.Text = "Vehículo dado de baja exitosamente.";
                    btnDarBajaVehiculo.Visible = false;
                    btnReactivarVehiculo.Visible = true;
                }

                else
                {
                    Session.Add("error", "ID de vehiculo no válido.");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnReactivarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(Request.QueryString["id"], out int id))
                {
                    new GestionVehiculo().reactivarVehiculo(id);
                    lblMensajePantallaVehiculo.Text = "Vehículo reactivado exitosamente.";
                    btnReactivarVehiculo.Visible = false;
                    btnDarBajaVehiculo.Visible = true;
                }

                else
                {
                    Session.Add("error", "ID de vehiculo no válido.");
                }


            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void btnModificarVehiculo_Click(object sender, EventArgs e)
        {
            txtPatente.Text = lblPatente.Text == "--" ? "" : lblPatente.Text;
            txtCapacidadCarga.Text = lblCapacidadCarga.Text == "--" ? "" : lblCapacidadCarga.Text;
            txtComentario.Text = lblComentario.Text == "--" ? "" : lblComentario.Text;
            ddlDisponibilidad.Items.Add(new ListItem("Disponible", "true"));
            ddlDisponibilidad.Items.Add(new ListItem("No disponible", "false"));

            txtPatente.Visible = true;
            txtCapacidadCarga.Visible = true;
            txtComentario.Visible = true;
            ddlDisponibilidad.Visible = true;
            ddlEstadoVehiculo.Visible=true;

            lblPatente.Visible = false;
            lblCapacidadCarga.Visible = false;
            lblComentario.Visible = false;
            lblDisponibilidad.Visible = false;
            lblEstado.Visible = false;

            btnGuardarCambiosVehiculo.Visible = true;
            btnCancelarVehiculo.Visible = true;
            btnModificarVehiculo.Visible = false;

            int.TryParse(Request.QueryString["id"], out int id);
            GestionVehiculo gestionVehiculo = new GestionVehiculo();
            Vehiculo vehiculo = gestionVehiculo.obtenerVehiculoPorId(id);
            GestionEstadoVehiculo gestionEstado = new GestionEstadoVehiculo();
            ddlEstadoVehiculo.DataSource = gestionEstado.listarEstadoVehiculo();
            ddlEstadoVehiculo.DataTextField = "descripcioEstado";
            ddlEstadoVehiculo.DataValueField = "IDEstado";
            ddlEstadoVehiculo.DataBind();

            ddlEstadoVehiculo.SelectedValue = vehiculo.estadoVehiculo.IDEstado.ToString();
            ddlDisponibilidad.SelectedValue = vehiculo.Disponible.ToString().ToLower();

        }

        protected void btnGuardarCambiosVehiculo_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["id"], out int id))
            {
                Vehiculo vehiculo = new Vehiculo();


                vehiculo.idVehiculo = id;
                vehiculo.Patente = txtPatente.Text;
                vehiculo.CapacidadCarga = float.TryParse(txtCapacidadCarga.Text, out float cap) ? cap : 0;
                vehiculo.Comentario = txtComentario.Text;
                vehiculo.Disponible = ddlDisponibilidad.Text.ToLower() == "disponible";
                vehiculo.estadoVehiculo = new EstadoVehiculo();
                vehiculo.estadoVehiculo.IDEstado = int.Parse(ddlEstadoVehiculo.SelectedValue);
                vehiculo.estadoVehiculo.descripcioEstado = ddlEstadoVehiculo.SelectedItem.Text;


                try
                {
                    Page.Validate();
                    if (!Page.IsValid)
                    return;

                    GestionVehiculo gestion = new GestionVehiculo();
                    gestion.modificarVehiculo(vehiculo);

                    lblMensajePantallaVehiculo.Text = "Vehículo modificado correctamente.";
                    lblMensajePantallaVehiculo.CssClass = "text-success";

                    lblPatente.Text = vehiculo.Patente;
                    lblCapacidadCarga.Text = vehiculo.CapacidadCarga.ToString();
                    lblComentario.Text = vehiculo.Comentario;
                    lblDisponibilidad.Text = vehiculo.Disponible ? "Disponible" : "No disponible";
                    lblEstado.Text = vehiculo.estadoVehiculo.descripcioEstado;

                }
                catch (Exception ex)
                {
                    lblMensajePantallaVehiculo.Text = "Error al modificar el vehículo: " + ex.Message;
                    lblMensajePantallaVehiculo.CssClass = "text-danger";
                }

                ModoSoloLectura();
            }


        }

        protected void btnCancelarVehiculo_Click(object sender, EventArgs e)
        {
            ModoSoloLectura();
        }

        private void ModoSoloLectura()
        {
            lblPatente.Visible = true;
            lblCapacidadCarga.Visible = true;
            lblComentario.Visible = true;
            lblDisponibilidad.Visible = true;
            lblEstado.Visible = true;

            txtPatente.Visible = false;
            txtCapacidadCarga.Visible = false;
            txtComentario.Visible = false;
            ddlDisponibilidad.Visible = false;
            ddlEstadoVehiculo.Visible  = false;

            btnModificarVehiculo.Visible = true;
            btnGuardarCambiosVehiculo.Visible = false;
            btnCancelarVehiculo.Visible = false;
        }
    }
}