using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;
using TPI_SistemaLogistica_Equipo3B.Models;

using TPI_SistemaLogistica_Equipo3B.Servicios;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class CargarOrden : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cliente"] != null)
                {
                    Cliente clienteLogueado = (Cliente)Session["cliente"];

                    txtNombreOrigen.Text = clienteLogueado.Nombre;
                    txtApellidoOrigen.Text = clienteLogueado.Apellido;
                    txtCUILOrigen.Text = clienteLogueado.CUIL.ToString();
                    txtTelefonoOrigen.Text = clienteLogueado.Telefono;
                    txtEmailOrigen.Text = clienteLogueado.Usuario.Email;
                    txtCalleOrigen.Text = clienteLogueado.Direccion.Calle;
                    txtNumeroOrigen.Text = clienteLogueado.Direccion.NumeroCalle.ToString();
                    txtCPOrigen.Text = clienteLogueado.Direccion.CodigoPostal;
                    txtCiudadOrigen.Text = clienteLogueado.Direccion.Ciudad;
                    txtProvinciaOrigen.Text = clienteLogueado.Direccion.Provincia;
                    txtPisoOrigen.Text = clienteLogueado.Direccion.Piso;

                }
                else
                {
                    Response.Redirect("ErrorLogin.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }


                //gvItems.DataSource = new List<ItemOrden>(); // Inicial vacío
                gvItems.DataSource = ViewState["Items"];
                gvItems.DataBind();

                //API LOCALIDADES/PROVINCIAS

                var geoService = new GeorefService();
                //var provincias = geoService.ObtenerProvinciasAsync().GetAwaiter().GetResult();
                var provincias = await geoService.ObtenerProvinciasAsync();

                ddlProvincias.DataSource = provincias;
                ddlProvincias.DataTextField = "nombre";
                ddlProvincias.DataValueField = "nombre";
                ddlProvincias.DataBind();
            }

        }

        protected async void ddlProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            var geoService = new GeorefService();
            var provinciaSeleccionada = ddlProvincias.SelectedValue;

            var localidades = await geoService.ObtenerLocalidadesPorProvinciaAsync(provinciaSeleccionada);

            ddlLocalidades.DataSource = localidades;
            ddlLocalidades.DataTextField = "nombre";
            ddlLocalidades.DataValueField = "nombre";
            ddlLocalidades.DataBind();
        }


        protected void btnCotizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLargo.Text) ||
                string.IsNullOrWhiteSpace(txtAncho.Text) ||
                string.IsNullOrWhiteSpace(txtAlto.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtValor.Text))
            {
                lblMensajePaquete.Text = "Todos los campos son obligatorios.";
                return;
            }

            if (!float.TryParse(txtLargo.Text, out float largo) ||
                !float.TryParse(txtAncho.Text, out float ancho) ||
                !float.TryParse(txtAlto.Text, out float alto) ||
                !float.TryParse(txtPeso.Text, out float peso) ||
                !int.TryParse(txtCantidad.Text, out int cantidad) ||
                !decimal.TryParse(txtValor.Text, out decimal valorDeclarado))
            {
                lblMensajePaquete.Text = "Por favor, ingresá valores numéricos válidos.";
                return;
            }

            if (largo <= 0 || ancho <= 0 || alto <= 0 || peso <= 0 || cantidad <= 0 || valorDeclarado < 0)
            {
                lblMensajePaquete.Text = "Los valores deben ser positivos.";
                return;
            }


            lblMensajePaquete.Text = "";

            Paquete paquete = new Paquete();
            ItemOrden item = new ItemOrden();
            paquete.Categoria = new Categoria();

            //List<ItemOrden> listaItems = new List<ItemOrden>();

            paquete.Largo = float.Parse(txtLargo.Text);
            paquete.Ancho = float.Parse(txtAncho.Text);
            paquete.Alto = float.Parse(txtAlto.Text);
            paquete.Peso = float.Parse(txtPeso.Text);
            paquete.Cantidad = int.Parse(txtCantidad.Text);
            paquete.ValorDeclarado = decimal.Parse(txtValor.Text);

            float volumen = paquete.Largo * paquete.Ancho * paquete.Alto;
            float pesoVolumetrico = volumen / 5000;

            if (pesoVolumetrico >= 1 && pesoVolumetrico <= 4)
                item.Precio = 2500;
            else if (pesoVolumetrico <= 10)
                item.Precio = 6000;
            else if (pesoVolumetrico <= 15)
                item.Precio = 21000;
            else if (pesoVolumetrico <= 20)
                item.Precio = 27000;
            else if (pesoVolumetrico <= 25)
                item.Precio = 37000;

            if (paquete.Peso <= 10)
            {
                item.Categoria = "Chico";
                paquete.Categoria.idCategoria = 1;
            }
            else
            {
                if (paquete.Peso <= 20)
                {
                    item.Categoria = "Mediano";
                    paquete.Categoria.idCategoria = 2;
                }
                else
                {
                    if (paquete.Peso <= 50)
                    {
                        item.Categoria = "Grande";
                        paquete.Categoria.idCategoria = 3;
                    }
                }
            }

            item.Descripcion = "Producto";

            // Obtener la lista anterior de ViewState o crear una nueva
            //List<ItemOrden> listaItems = ViewState["Items"] as List<ItemOrden> ?? new List<ItemOrden>();
            //listaItems.Add(item);

            // Guardar en ViewState para persistencia
            //ViewState["Items"] = listaItems;
            ViewState["Items"] = new List<ItemOrden> { item };

            // Refrescar GridView
            //gvItems.DataSource = listaItems;
            gvItems.DataSource = (List<ItemOrden>)ViewState["Items"];
            gvItems.DataBind();

            //decimal total = 0;
            decimal total = item.Precio;

            //for (int i = 0; i < listaItems.Count; i++)
            //{
            //    total += listaItems[i].Precio;
            //}

            //detalle.Cantidad = listaItems.Count; //Si se deja cantidad en detalle lo descomento
            //detalle.Cantidad = paquete.Cantidad;

            lblTotal.Text = total.ToString("N2");

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            OrdenesEnvio ordenesEnvio = new OrdenesEnvio();
            DetalleOrden detalleOrden = new DetalleOrden();
            Cliente cliente = new Cliente();
            cliente.Direccion = new Direccion();
            Destinatario destinatario = new Destinatario();
            destinatario.Direccion = new Direccion();
            Paquete paquete = new Paquete();
            paquete.Categoria = new Categoria();
            AccesoDatos gestionDatos = new AccesoDatos();
            GestionDestinatario gestionDestinatario = new GestionDestinatario();
            GestionTransportista gestionTransportista = new GestionTransportista();
            GestionOrdenesEnvio gestionOrdenesEnvio = new GestionOrdenesEnvio();
            GestionPaquete gestionPaquete = new GestionPaquete();

            cliente.Nombre = txtNombreOrigen.Text;
            cliente.Apellido = txtApellidoOrigen.Text;
            cliente.Telefono = txtTelefonoOrigen.Text;
            cliente.CUIL = long.Parse(txtCUILOrigen.Text);
            cliente.Direccion.Calle = txtCalleOrigen.Text;
            cliente.Direccion.NumeroCalle = int.Parse(txtNumeroOrigen.Text);
            cliente.Direccion.CodigoPostal = txtCPOrigen.Text;
            cliente.Direccion.Ciudad = txtCiudadOrigen.Text;
            cliente.Direccion.Provincia = txtProvinciaOrigen.Text;
            cliente.Direccion.Piso = txtPisoOrigen.Text;
            //cliente.InfoAdicional = txtInfoOrigen.Text;

            if (!validarDestinatario())
                return;

            destinatario.Nombre = txtNombreDestino.Text;
            destinatario.Apellido = txtApellidoDestino.Text;
            destinatario.Telefono = txtTelefonoDestino.Text;
            destinatario.Email = txtEmailDestino.Text;
            destinatario.CUIL = long.Parse(txtCUILDestino.Text);
            destinatario.Direccion.Calle = txtCalleDestino.Text;
            destinatario.Direccion.NumeroCalle = int.Parse(txtNumeroDestino.Text);
            destinatario.Direccion.CodigoPostal = txtCPDestino.Text;
            //api provincias y localidades
            destinatario.Direccion.Provincia = ddlProvincias.SelectedValue;
            destinatario.Direccion.Ciudad = ddlLocalidades.SelectedValue;

            destinatario.Direccion.Piso = txtPisoDestino.Text;
            //destinatario.InfoAdicional = txtInfoDestino.Text;

            if (!validarPaquete())
                return;

            paquete.Largo = float.Parse(txtLargo.Text);
            paquete.Ancho = float.Parse(txtAncho.Text);
            paquete.Alto = float.Parse(txtAlto.Text);
            paquete.Peso = float.Parse(txtPeso.Text);
            paquete.Cantidad = int.Parse(txtCantidad.Text);
            paquete.ValorDeclarado = decimal.Parse(txtValor.Text);

            paquete.Categoria.idCategoria = idCategoriaPaquete(paquete);

            gestionDestinatario.agregarDestinatario(destinatario);

            //Orden y detalle

            ordenesEnvio.cliente = cliente;
            ordenesEnvio.destinatario = destinatario;
            ordenesEnvio.idTransportistaAsignado = gestionTransportista.transportistaDisponible();

            ordenesEnvio.ruta = new Ruta();
            ordenesEnvio.estado = new EstadoOrdenEnvio();

            //SETEAR RUTAS EN TABLA RUTAS
            ordenesEnvio.ruta.PuntoPartida = cliente.Direccion.Provincia + cliente.Direccion.Ciudad + cliente.Direccion.Calle + cliente.Direccion.NumeroCalle;
            ordenesEnvio.ruta.PuntoDestino = destinatario.Direccion.Provincia + destinatario.Direccion.Ciudad + destinatario.Direccion.Calle + destinatario.Direccion.NumeroCalle;

            //SETEAR EN TABLA ORDEN

            //ordenesEnvio.FechaCreacion = DateTime.Now;
            //ordenesEnvio.FechaEnvio = ordenesEnvio.FechaCreacion.AddDays(2); ; //estos datos hay que revisarlos.
            //ordenesEnvio.FechaEstimadaLlegada = ordenesEnvio.FechaCreacion.AddDays(4);
            //ordenesEnvio.FechaDeLlegada = ordenesEnvio.FechaDeLlegada.AddDays(4);

            ordenesEnvio.FechaCreacion = new DateTime(2025, 6, 15);
            ordenesEnvio.FechaEnvio = new DateTime(2025, 6, 17);
            ordenesEnvio.FechaEstimadaLlegada = new DateTime(2025, 6, 20);
            ordenesEnvio.FechaDeLlegada = new DateTime(2025, 6, 20);

            ordenesEnvio.estado.idEstado = 3;

            //DETALLE ORDEN

            detalleOrden.paquete = paquete;
            detalleOrden.Total = decimal.Parse(lblTotal.Text);


            gestionOrdenesEnvio.agregarOrdenEnvio(ordenesEnvio, detalleOrden);
        }

        protected int idCategoriaPaquete(Paquete paquete)
        {
            ItemOrden item = new ItemOrden();

            float volumen = paquete.Largo * paquete.Ancho * paquete.Alto;
            float pesoVolumetrico = volumen / 5000;

            if (pesoVolumetrico >= 1 && pesoVolumetrico <= 4)
                item.Precio = 2500;
            else if (pesoVolumetrico <= 10)
                item.Precio = 6000;
            else if (pesoVolumetrico <= 15)
                item.Precio = 21000;
            else if (pesoVolumetrico <= 20)
                item.Precio = 27000;
            else if (pesoVolumetrico <= 25)
                item.Precio = 37000;

            if (paquete.Peso <= 10)
            {
                item.Categoria = "Chico";
                paquete.Categoria.idCategoria = 1;
            }
            else
            {
                if (paquete.Peso <= 20)
                {
                    item.Categoria = "Mediano";
                    paquete.Categoria.idCategoria = 2;
                }
                else
                {
                    if (paquete.Peso <= 50)
                    {
                        item.Categoria = "Grande";
                        paquete.Categoria.idCategoria = 3;
                    }
                }
            }

            decimal total = item.Precio;

            return paquete.Categoria.idCategoria;
        }

        protected bool validarPaquete()
        {
            if (string.IsNullOrWhiteSpace(txtLargo.Text) ||
                string.IsNullOrWhiteSpace(txtAncho.Text) ||
                string.IsNullOrWhiteSpace(txtAlto.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtValor.Text))
            {
                lblMensajePaquete.Text = "Todos los campos son obligatorios.";
                return false;
            }

            if (!float.TryParse(txtLargo.Text, out float largo) ||
                !float.TryParse(txtAncho.Text, out float ancho) ||
                !float.TryParse(txtAlto.Text, out float alto) ||
                !float.TryParse(txtPeso.Text, out float peso) ||
                !int.TryParse(txtCantidad.Text, out int cantidad) ||
                !decimal.TryParse(txtValor.Text, out decimal valorDeclarado))
            {
                lblMensajePaquete.Text = "Por favor, ingresá valores numéricos válidos.";
                return false;
            }

            if (largo <= 0 || ancho <= 0 || alto <= 0 || peso <= 0 || cantidad <= 0 || valorDeclarado < 0)
            {
                lblMensajePaquete.Text = "Los valores deben ser positivos.";
                return false;
            }

            lblMensajePaquete.Text = "";

            return true;
        }

        protected bool validarDestinatario()
        {
            if (string.IsNullOrWhiteSpace(txtNombreDestino.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoDestino.Text) ||
                string.IsNullOrWhiteSpace(txtTelefonoDestino.Text) ||
                string.IsNullOrWhiteSpace(txtEmailDestino.Text) ||
                string.IsNullOrWhiteSpace(txtCUILDestino.Text) ||
                string.IsNullOrWhiteSpace(txtCalleDestino.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroDestino.Text) ||
                string.IsNullOrWhiteSpace(txtCPDestino.Text) ||
                string.IsNullOrWhiteSpace(ddlLocalidades.Text) ||
                string.IsNullOrWhiteSpace(ddlProvincias.Text))
            {
                lblMensajeDestinatario.Text = "Todos los campos son obligatorios.";
                return false;
            }

            if (!long.TryParse(txtCUILDestino.Text, out long cuil) || cuil <= 0)
            {
                lblMensajeDestinatario.Text = "El CUIL debe ser un número válido y mayor a cero.";
                return false;
            }

            if (!int.TryParse(txtNumeroDestino.Text, out int numeroCalle) || numeroCalle <= 0)
            {
                lblMensajeDestinatario.Text = "El número de calle debe ser un número positivo.";
                return false;
            }

            if (!txtEmailDestino.Text.Contains("@") || !txtEmailDestino.Text.Contains("."))
            {
                lblMensajeDestinatario.Text = "Ingrese un correo electrónico válido.";
                return false;
            }

            if (txtTelefonoDestino.Text.Length < 6)
            {
                lblMensajeDestinatario.Text = "Ingrese un teléfono válido.";
                return false;
            }

            lblMensajeDestinatario.Text = "";

            return true;
        }


    }
}