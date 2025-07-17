using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class PasarelaDePago : System.Web.UI.Page
    {
        protected int idOrden
        {
            get
            {
                if (Session["IDOrden"] != null)
                    return (int)Session["IDOrden"];
                return 0; // o podés lanzar una excepción si es obligatorio
            }
        }

        protected decimal total
        {
            get
            {
                if (Session["Total"] != null)
                    return (decimal)Session["Total"];
                return 0m;
            }
        }

        //protected Cliente clienteLogueado
        //{
        //    get
        //    {
        //        return Session["cliente"] as Cliente;
        //    }
        //}

        //protected int idCliente
        //{
        //    get
        //    {
        //        var cliente = clienteLogueado;
        //        return cliente != null ? cliente.id : 0;
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("IDOrden Session: " + Session["IDOrden"]);
            System.Diagnostics.Debug.WriteLine("Total Session: " + Session["Total"]);
            //System.Diagnostics.Debug.WriteLine("Cliente Session: " + Session["cliente"]);

            if (idOrden == 0 || total == 0)
            {
                // Podés redirigir o mostrar error porque faltan datos en sesión
                lblError.Text = "No se encontraron los datos de la orden o cliente.";
                //btnCompletarPago.Enabled = false;
                return;
            }

            if (!IsPostBack)
            {
                lblEnvio.Text = total.ToString("C");
                lblTotal.Text = total.ToString("C");

                // Cargo la selección del método de pago desde Session o pongo "Transferencia" por defecto
                string metodo = Session["MetodoPagoSeleccionado"]?.ToString() ?? "Transferencia";
                SeleccionarMetodoPago(metodo);
            }

            //if (!IsPostBack)
            //{

            //    if (Session["IDOrden"] != null && Session["Total"] != null && Session["IDCliente"] != null)
            //    {
            //        idOrden = (int)Session["IDOrden"];
            //        total = (decimal)Session["Total"];
            //        Cliente clienteLogueado = (Cliente)Session["cliente"];
            //        idCliente = clienteLogueado.id;

            //        lblEnvio.Text = total.ToString("C");
            //        lblTotal.Text = total.ToString("C");
            //    }

            //    //System.Diagnostics.Debug.WriteLine("ID del cliente: " + idCliente);
            //    SeleccionarMetodoPago("Transferencia");
            //}
        }


        protected void btnTransferencia_Click(object sender, EventArgs e)
        {
            SeleccionarMetodoPago("Transferencia");
            Session["MetodoPagoSeleccionado"] = "Transferencia";
            btnTransferencia.CssClass = "boton-pago boton-activo";
            btnMercadoPago.CssClass = "boton-pago";
        }

        protected void btnMercadoPago_Click(object sender, EventArgs e)
        {
            SeleccionarMetodoPago("MercadoPago");
            Session["MetodoPagoSeleccionado"] = "Mercado Pago";
            btnMercadoPago.CssClass = "boton-pago boton-activo";
            btnTransferencia.CssClass = "boton-pago";
        }


        private void SeleccionarMetodoPago(string metodo)
        {
            pnlTransferencia.Visible = metodo == "Transferencia";

            btnTransferencia.CssClass = metodo == "Transferencia" ? "boton-pago boton-activo" : "boton-pago";
            btnMercadoPago.CssClass = metodo == "MercadoPago" ? "boton-pago boton-activo" : "boton-pago";

            //ViewState["MetodoPagoSeleccionado"] = metodo;
        }

        /* protected void btnCompletarPago_Click(object sender, EventArgs e)
         {
             int orden = idOrden;
             decimal monto = total;
             //int clienteId = idCliente;

             string metodoSeleccionado = Session["MetodoPagoSeleccionado"]?.ToString();

             if (string.IsNullOrEmpty(metodoSeleccionado))
             {
                 lblError.Text = "Por favor selecciona un método de pago.";
                 return;
             }

             FacturaPago factura = new FacturaPago();
             GestionFacturas gestionFactura = new GestionFacturas();
             Venta venta = new Venta();
             GestionVenta gestionVenta = new GestionVenta();
             FormaDePago formaPago = new FormaDePago();
             factura.formaDePago = new FormaDePago();
             GestionOrdenesEnvio gestionOrden = new GestionOrdenesEnvio();

             factura.OrdenesEnvio = new OrdenesEnvio();
             factura.OrdenesEnvio.idOrdenEnvio = orden;
             factura.Total = monto;
             factura.FechaEmision = DateTime.Now;
             factura.FechaVencimiento = DateTime.Now.AddDays(5);
             factura.NumeroFactura = gestionFactura.returnIDFactura();
             factura.NumeroFactura += 1;

             switch (metodoSeleccionado)
             {
                 case "Mercado Pago":
                     formaPago.medioDePago = "Mercado Pago";
                     break;
                 case "Transferencia":
                     formaPago.medioDePago = "Transferencia";
                     break;
                 default:
                     formaPago.medioDePago = "NULL";
                     break;
             }

             formaPago.fechaDePago = DateTime.Now;
             formaPago.estadoDePago = new EstadoDePago();
             formaPago.estadoDePago.idEstadoDePago = 1;
             formaPago.Cliente = new Cliente();
             //int idCliente = gestionOrden.returnIDClienteOrden(idOrden);

             //Cliente clienteLogueado = (Cliente)Session["cliente"];
             //idCliente = clienteLogueado.id;




             int idFactura = gestionFactura.AgregarFactura(factura, formaPago);

             venta.OrdenesEnvio = new OrdenesEnvio();
             venta.OrdenesEnvio.idOrdenEnvio = idOrden;
             venta.Factura = new FacturaPago();
             venta.Factura.idFactura = idFactura;
             gestionVenta.AgregarVenta(venta);

             try
             {
                 Response.Redirect("MensajePago.aspx");
             }
             catch (Exception ex)
             {
                 lblError.Text = "Ocurrió un error al completar el pago: " + ex.Message;
                 System.Diagnostics.Debug.WriteLine("IDCliente recibido: " + formaPago.Cliente.id);

             }
         }*/

        protected void btnCompletarPago_Click(object sender, EventArgs e)
        {
            int orden = idOrden;
            decimal monto = total;

            string metodoSeleccionado = Session["MetodoPagoSeleccionado"]?.ToString();
            if (string.IsNullOrEmpty(metodoSeleccionado))
            {
                lblError.Text = "Por favor selecciona un método de pago.";
                return;
            }

            FacturaPago factura = new FacturaPago();
            GestionFacturas gestionFactura = new GestionFacturas();
            Venta venta = new Venta();
            GestionVenta gestionVenta = new GestionVenta();
            FormaDePago formaPago = new FormaDePago();
            factura.formaDePago = new FormaDePago();
            GestionOrdenesEnvio gestionOrden = new GestionOrdenesEnvio();

            factura.OrdenesEnvio = new OrdenesEnvio();
            factura.OrdenesEnvio.idOrdenEnvio = orden;
            factura.Total = monto;
            factura.FechaEmision = DateTime.Now;
            factura.FechaVencimiento = DateTime.Now.AddDays(5);
            factura.NumeroFactura = gestionFactura.returnIDFactura() + 1;

            formaPago.medioDePago = metodoSeleccionado;
            formaPago.fechaDePago = DateTime.Now;
            formaPago.estadoDePago = new EstadoDePago { idEstadoDePago = 1 };
            formaPago.Cliente = new Cliente();

            if (metodoSeleccionado == "Mercado Pago")
            {
                string urlBase = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
                MercadoPagoGestion mp = new MercadoPagoGestion(urlBase);
                string descripcion = $"Pago de envío ID #{orden}";
                string linkPago = mp.PagarMercadoPago(descripcion, monto);

                Session["IDFacturaPendiente"] = factura.NumeroFactura;
                Response.Redirect(linkPago);
                return;
            }

            // Solo se ejecuta si eligió Transferencia
            int idFactura = gestionFactura.AgregarFactura(factura, formaPago);
            venta.OrdenesEnvio = new OrdenesEnvio { idOrdenEnvio = orden };
            venta.Factura = new FacturaPago { idFactura = idFactura };
            gestionVenta.AgregarVenta(venta);

            try
            {
                Response.Redirect("MensajePago.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al completar el pago: " + ex.Message;
            }
        }


    }
}