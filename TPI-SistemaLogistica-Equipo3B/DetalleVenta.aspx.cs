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
    public partial class DetalleVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GestionDetalleVenta detalleVenta = new GestionDetalleVenta();

                if (Request.QueryString["VentaID"] != null)
                {
                    int idVenta = int.Parse(Request.QueryString["VentaID"]);
                    GestionDetalleVenta gestion = new GestionDetalleVenta();
                    VentaDetalle detalle = gestion.ObtenerDetalleVenta(idVenta);

                    lblVentaID.Text = idVenta.ToString();

                    lblCategoria.Text = detalle.paquete.Categoria.DescripcionCategoria;
                    lblCantidad.Text = detalle.paquete.Cantidad.ToString();
                    lblValorDeclarado.Text = detalle.paquete.ValorDeclarado.ToString();
                    lblPeso.Text = detalle.paquete.Peso.ToString();
                    lblAlto.Text = detalle.paquete.Alto.ToString();
                    lblAncho.Text = detalle.paquete.Ancho.ToString();
                    lblLargo.Text = detalle.paquete.Largo.ToString();
                    //lblPrecioEnvio.Text = detalle.detalle.Total.ToString();
                    lblSubtotal.Text = detalle.detalle.Total.ToString();

                    lblNombreCliente.Text = detalle.cliente.Nombre + " " + detalle.cliente.Apellido.ToString();
                    lblCUILCliente.Text = detalle.cliente.CUIL.ToString();
                    lblEmailCliente.Text = detalle.cliente.Usuario.Email;
                    lblTelefonoCliente.Text = detalle.cliente.Telefono;
                    lblCalleCliente.Text = detalle.cliente.Direccion.Calle;
                    lblNumeroCliente.Text = detalle.cliente.Direccion.NumeroCalle.ToString();
                    lblCiudadCliente.Text = detalle.cliente.Direccion.Ciudad;
                    lblProvinciaCliente.Text = detalle.cliente.Direccion.Provincia;
                    lblCPCliente.Text = detalle.cliente.Direccion.CodigoPostal.ToString();

                    lblEstadoPago.Text = detalle.estadoDePago.nombreEstado;
                    lblEstadoPago.CssClass += " " + GetClaseEstadoPago(detalle.estadoDePago.nombreEstado);
                    lblMetodoPago.Text = detalle.MetodoPago.medioDePago;
                    lblCostoEnvio.Text = detalle.detalle.Total.ToString();
                    lblTotalFinal.Text = detalle.detalle.Total.ToString();

                    lblEstadoEnvio.Text = detalle.EstadoEnvio.DescripcionEstado;
                    lblEstadoEnvio.CssClass += " " + GetClaseEstadoEnvio(detalle.EstadoEnvio.DescripcionEstado);

                    lblNombre.Text = detalle.destinatario.Nombre + " " + detalle.destinatario.Apellido;
                    lblCuil.Text = detalle.destinatario.CUIL.ToString();
                    lblEmailDestino.Text = detalle.destinatario.Email;
                    lblTelefonoDestino.Text = detalle.destinatario.Telefono;
                    lblCalleDestino.Text = detalle.destinatario.Direccion.Calle;
                    lblNumeroDestino.Text = detalle.destinatario.Direccion.NumeroCalle.ToString();
                    lblCiudadDestino.Text = detalle.destinatario.Direccion.Ciudad;
                    lblProvinciaDestino.Text = detalle.destinatario.Direccion.Provincia;
                    lblCPDestino.Text = detalle.destinatario.Direccion.CodigoPostal.ToString();

                    lblEstadoDePago.Text = "🧾 " + detalle.estadoDePago.nombreEstado;
                    lblEstadoDePago.CssClass += " " + GetClaseEstadoPago(detalle.estadoDePago.nombreEstado);

                    lblEstadoDeEnvio.Text = "📦 " + detalle.EstadoEnvio.DescripcionEstado;
                    lblEstadoDeEnvio.CssClass += " " + GetClaseEstadoEnvio(detalle.EstadoEnvio.DescripcionEstado);

                }
            }

        }

        public string GetClaseEstadoPago(string estado)
        {
            switch (estado?.ToLower())
            {
                case "pendiente":
                    return "estado-pendiente";
                case "recibido":
                    return "estado-recibido";
                case "rechazado":
                    return "estado-rechazado";
                case "pago en proceso":
                    return "estado-proceso";
                case "cancelar orden":
                    return "estado-cancelado";
                default:
                    return "";
            }
        }

        public string GetClaseEstadoEnvio(string estado)
        {
            switch (estado?.ToLower())
            {
                case "pendiente":
                    return "envio-pendiente";
                case "en transito":
                    return "envio-transito";
                case "entregado":
                    return "envio-entregado";
                case "reprogramado":
                    return "envio-reprogramado";
                case "demorado":
                    return "envio-demorado";
                case "cancelado":
                    return "envio-cancelado";
                default:
                    return "";
            }
        }

    }
}