using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;
using static Dominio.Usuario;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class DetalleDeOrden : System.Web.UI.Page
    {
        public int TipoUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    string id = Request.QueryString["OrdenId"] != null ? Request.QueryString["OrdenId"].ToString() : "";
                    if (id != null)
                    {
                        GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
                        OrdenesEnvio seleccionado = (ordenes.ListarOrdenCompleta(id))[0];

                        // datos transportista
                        GestionTransportista transportista = new GestionTransportista();
                        dllTransportista.DataSource = transportista.listarTranportistas();
                        dllTransportista.DataTextField = "Apellido";
                        dllTransportista.DataValueField = "IDTransportista";
                        dllTransportista.DataBind();
                        txtTransportista.Text = seleccionado.transportista.Nombre;
                        dllTransportista.SelectedValue = seleccionado.transportista.IdTransportista.ToString();

                        // datos patente
                        GestionVehiculo gestionVehiculo = new GestionVehiculo();
                        txtVehiculo.Text = seleccionado.transportista.Vehiculo.Patente;

                        // dato id
                        txtIdOrden.Text = seleccionado.idOrdenEnvio.ToString();

                        // datos puntos
                        TxtPuntoPartida.Text = seleccionado.ruta.PuntoPartida;
                        TxtPuntoDestino.Text = seleccionado.ruta.PuntoDestino;

                        // datos cliente
                        txtNombreOrigen.Text = seleccionado.cliente.Nombre;
                        txtCUILOrigen.Text = seleccionado.cliente.CUIL.ToString();
                        txtEmailOrigen.Text = seleccionado.cliente.Usuario.Email;
                        txtTelefonoOrigen.Text = seleccionado.cliente.Telefono;

                        // datos destinatario
                        txtNombreDestino.Text = seleccionado.destinatario.Nombre;
                        txtEmailDestino.Text = seleccionado.destinatario.Email;
                        txtTelefonoDestino.Text = seleccionado.destinatario.Telefono;
                        txtCUILDestino.Text = seleccionado.destinatario.CUIL.ToString();
                        txtDireccion.Text = seleccionado.destinatario.Direccion.Calle;
                        txtPiso.Text = seleccionado.destinatario.Direccion.Piso;
                        txtProvincia.Text = seleccionado.destinatario.Direccion.Provincia;
                        txtCiudad.Text = seleccionado.destinatario.Direccion.Ciudad;
                        txtCodigoPostal.Text = seleccionado.destinatario.Direccion.CodigoPostal;

                        // datos paquete
                        txtLargo.Text = seleccionado.paquete.Alto.ToString();
                        txtAlto.Text = seleccionado.paquete.Alto.ToString();
                        txtAncho.Text = seleccionado.paquete.Ancho.ToString();
                        txtPeso.Text = seleccionado.paquete.Peso.ToString();
                        txtValor.Text = seleccionado.paquete.ValorDeclarado.ToString();

                        // estado de orden
                        GestionEstado estados = new GestionEstado();
                        dllEstado.DataSource = estados.listarEstado();
                        dllEstado.DataTextField = "DescripcionEstado";
                        dllEstado.DataValueField = "idEstado";
                        TxtEstadoOrden.Text = seleccionado.estado.DescripcionEstado.ToString();
                        dllEstado.DataBind();
                        dllEstado.SelectedValue = seleccionado.estado.idEstado.ToString();

                        // estado de vechiculo
                        GestionEstadoVehiculo estadosVehiculo = new GestionEstadoVehiculo();
                        dllEstadoVehiculo.DataSource = estadosVehiculo.listarEstadoVehiculo();
                        dllEstadoVehiculo.DataTextField = "descripcioEstado";
                        dllEstadoVehiculo.DataValueField = "IDEstado";
                        txtEstadoVehiculo.Text = seleccionado.transportista.Vehiculo.estadoVehiculo.descripcioEstado.ToString();
                        dllEstadoVehiculo.DataBind();
                        dllEstadoVehiculo.SelectedValue = seleccionado.transportista.Vehiculo.estadoVehiculo.IDEstado.ToString();
                        hdnIdVehiculo.Value = seleccionado.transportista.Vehiculo.idVehiculo.ToString();
                         

                        //if (Session["TipoUsuario"] != null)
                        //{
                        //    TipoUsuario = Convert.ToInt32(Session["TipoUsuario"]);
                        //}

                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenesEnvio orden = new OrdenesEnvio();
                orden.idOrdenEnvio = int.Parse(txtIdOrden.Text);

                orden.idTransportistaAsignado = int.Parse(dllTransportista.SelectedValue);
                orden.estado = new EstadoOrdenEnvio();
                orden.estado.idEstado = int.Parse(dllEstado.SelectedValue);
                orden.transportista = new Transportista();
                orden.transportista.Vehiculo = new Vehiculo();
                orden.transportista.Vehiculo.estadoVehiculo = new EstadoVehiculo();
                orden.transportista.Vehiculo.estadoVehiculo.IDEstado = int.Parse(dllEstadoVehiculo.SelectedValue);

                GestionOrdenesEnvio gestion = new GestionOrdenesEnvio();
                gestion.modificarOrdenEnvio(orden);
                Response.Redirect("Ordenes.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                GestionOrdenesEnvio orden = new GestionOrdenesEnvio();
                orden.eliminarOrdenEnvio(int.Parse(txtIdOrden.Text));
                Response.Redirect("Ordenes.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }

        }

        protected void btnEntregado_Click(object sender, EventArgs e)
        {
            GestionOrdenesEnvio gestion = new GestionOrdenesEnvio();
            int idOrden = Convert.ToInt32(txtIdOrden.Text);
            int estadoActual = gestion.ObtenerEstadoOrden(idOrden);
            if (estadoActual == 3)
            {
                throw new Exception("La orden no puede ser cambiada a 'Entregada' ya que actualmente se encuentra en ese mismo estado.");
            }
            else if (estadoActual == 1)
            {
                throw new Exception("La orden no puede ser cambiada a 'Entregada' ya que se encuentra 'Pendiente', primero deber ser cambiada a 'En camino'.");
            }
                try
                {
                    gestion.ActualizarEstadoYFechaLlegada(idOrden, 3);
                    EmailService emailService = new EmailService();
                    emailService.armarCorreo("migue8935@gmail.com", txtNombreDestino.Text, idOrden.ToString(), 3);
                    emailService.enviarMail();



                    Response.Redirect("OrdenesAsignadas.aspx");
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex.Message);
                }
        }
        protected void btnDemorado_Click(object sender, EventArgs e)
        {
            GestionOrdenesEnvio gestion = new GestionOrdenesEnvio();
            int idOrden = Convert.ToInt32(txtIdOrden.Text);
            int estadoActual = gestion.ObtenerEstadoOrden(idOrden);
            if (estadoActual == 3)
            {
                throw new Exception("La orden no puede ser cambiada a 'Demorado' ya que se encuentra Entregada.");
            }
            try
            {
                gestion.ActualizarEstadoYFechaDemora(idOrden, 1);
                EmailService emailService = new EmailService();
                emailService.armarCorreo("migue8935@gmail.com", txtNombreDestino.Text, idOrden.ToString(), 2);
                emailService.enviarMail();
                Response.Redirect("OrdenesAsignadas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnActualizarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                int idVehiculo = int.Parse(hdnIdVehiculo.Value);
                int idEstadoNuevo = int.Parse(dllEstadoVehiculo.SelectedValue);
                string comentario = ComentarioEstadoVehiculo.Text;

                GestionOrdenesEnvio gestion = new GestionOrdenesEnvio();
                gestion.actualizarEstadoVehiculo(idEstadoNuevo,comentario, idVehiculo);
                Response.Redirect("OrdenesAsignadas.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        public bool validacionUsuario(Dominio.Usuario.TipoUsuario tipoEsperado)
        {
            if (Session["usuario"] != null)
            {
                var usuario = (Dominio.Usuario)Session["usuario"];
                return usuario.tipoUsuario == tipoEsperado;
            }
            return false;

        }
    }

}