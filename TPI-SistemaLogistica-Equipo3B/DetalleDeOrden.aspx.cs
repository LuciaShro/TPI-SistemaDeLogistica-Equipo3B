using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class DetalleDeOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {


                string id = Request.QueryString["OrdenId"] != null ? Request.QueryString["OrdenId"].ToString() : "";
                if (id != null)
                {
                    GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
                    OrdenesEnvio seleccionado = (ordenes.ListarOrdenes(id))[0];

                    TxtTransportista.Text = seleccionado.idTransportistaAsignado.ToString();

                    txtIdOrden.Text = seleccionado.idOrdenEnvio.ToString();

                    TxtPuntoPartida.Text = seleccionado.ruta.PuntoPartida;
                    TxtPuntoDestino.Text = seleccionado.ruta.PuntoDestino;

                    txtNombreOrigen.Text = seleccionado.cliente.Nombre;
                    txtApellidoOrigen.Text = seleccionado.cliente.Apellido;
                    txtCUILOrigen.Text = seleccionado.cliente.CUIL.ToString();
                    txtEmailOrigen.Text = seleccionado.cliente.Usuario.Email;
                    txtTelefonoOrigen.Text = seleccionado.cliente.Telefono;

                    txtNombreDestino.Text = seleccionado.destinatario.Nombre;
                    txtApellidoDestino.Text = seleccionado.destinatario.Apellido;
                    txtEmailDestino.Text = seleccionado.destinatario.Email;
                    txtTelefonoDestino.Text = seleccionado.destinatario.Telefono;
                    txtCUILDestino.Text = seleccionado.destinatario.CUIL.ToString();


                    GestionEstado estados = new GestionEstado();
                    dllEstado.DataSource = estados.listarEstado();
                    dllEstado.DataTextField = "DescripcionEstado";
                    dllEstado.DataValueField = "idEstado";
                    dllEstado.DataBind();

                    dllEstado.SelectedValue = seleccionado.estado.idEstado.ToString();

                    //dllEstado.SelectedIndex= dllEstado.Items.IndexOf(
                    //    dllEstado.Items.FindByValue(id) );
                }

                if (Request.QueryString["OrdenId"] != null)
                {

                }
            }
            catch (Exception ex) {
                Session.Add("error", ex);
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        { 
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                GestionOrdenesEnvio orden = new GestionOrdenesEnvio();
                orden.eliminarOrdenEnvio(int.Parse(txtIdOrden.Text));
                Response.Redirect("Ordenes.aspx");
            }
            catch(Exception ex) {
                Session.Add("error", ex);
            }
            
        }

    }
}
