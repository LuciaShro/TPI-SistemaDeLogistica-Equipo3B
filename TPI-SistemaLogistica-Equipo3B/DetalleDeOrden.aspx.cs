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
            string id = Request.QueryString["OrdenId"] != null ? Request.QueryString["OrdenId"].ToString() : "";
            if (id != null)
            {
                GestionOrdenesEnvio ordenes = new GestionOrdenesEnvio();
                OrdenesEnvio seleccionado = (ordenes.ListarOrdenes(id))[0];


                TxtPuntoPartida.Text=seleccionado.ruta.PuntoPartida;
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

              

                TextEstadoEnvio.Text = seleccionado.estado.DescripcionEstado;

            }
        }
    }
}