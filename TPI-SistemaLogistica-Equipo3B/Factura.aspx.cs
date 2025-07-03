using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class Factura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                string idFacturaParam = Request.QueryString["id"];

                if (!string.IsNullOrEmpty(idFacturaParam))
                {
                    int idFactura = int.Parse(idFacturaParam);

                    FacturaPago factura = new FacturaPago();
                    Cliente cliente = new Cliente();
                    OrdenesEnvio orden = new OrdenesEnvio();
                    ItemOrden item = new ItemOrden();   
                    GestionCliente gestionCliente = new GestionCliente();   
                    GestionFacturas gestionFactura = new GestionFacturas();
                    GestionOrdenesEnvio gestionOrden = new GestionOrdenesEnvio();
                    GestionItemsOrden gestionItems = new GestionItemsOrden();
                    factura.formaDePago = new FormaDePago();
                    factura.formaDePago.estadoDePago = new EstadoDePago();
                    cliente.Direccion = new Direccion();

                    factura = gestionFactura.obtenerFactura(idFactura);

                    lblEstadoPago.Text = factura.formaDePago.estadoDePago.nombreEstado;
                    lblRazonSocial.Text = factura.razonSocial.ToString();
                    lblCUilEmisor.Text = factura.cuilEmisor.ToString();
                    lblFechaEmision.Text = factura.FechaEmision.ToString();
                    lblFechaVencimiento.Text = factura.FechaVencimiento.ToString();
                    lblNumeroFactura.Text = factura.NumeroFactura.ToString();

                    int idCliente = gestionCliente.returnIDClienteOrdenEnv(factura.OrdenesEnvio.idOrdenEnvio);
                    long cuilCliente = gestionCliente.returnCuilCliente(idCliente);
                    cliente = gestionCliente.returnCliente(cuilCliente);

                    lblNombreCliente.Text = cliente.Nombre + " " + cliente.Apellido;
                    lblCuil.Text = cliente.CUIL.ToString();
                    lblDireccionCliente.Text = cliente.Direccion.Calle + " " + cliente.Direccion.NumeroCalle;
                    lblCPCDCliente.Text = cliente.Direccion.Ciudad + " " + cliente.Direccion.CodigoPostal;
                    lblProvCliente.Text = cliente.Direccion.Provincia;
               
                    item = gestionItems.returnItemOrden(factura.OrdenesEnvio.idOrdenEnvio);
                    var lista = new List<ItemOrden> { item };
                    rptItems.DataSource = lista;
                    rptItems.DataBind();

                    lblSubtotal.Text = item.Precio.ToString();
                    lblTotal.Text = item.Precio.ToString();
                }
                else
                {
                    Response.Redirect("ResumenFacturas.aspx");
                }

                
            }

        }

        //private void CargarFactura(int idFactura)
        //{
        //    FacturaPago f = new FacturaPago();
        //    GestionFacturas gestionFacturas = new GestionFacturas();

        //    rptItems.DataSource = gestionFacturas.;
        //    rptItems.DataBind();
        //}

    }
}