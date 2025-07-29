using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Gestion;
using TPI_SistemaLogistica_Equipo3B.Models;

using TPI_SistemaLogistica_Equipo3B.Servicios;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json;
using static TPI_SistemaLogistica_Equipo3B.Servicios.MapBoxService;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class CargarOrden : System.Web.UI.Page
    {
        private MapBoxService _mapboxService;
        //protected int idCliente = 0;
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mapboxAccessToken = ConfigurationManager.AppSettings["MapboxAccessToken"];
                _mapboxService = new MapBoxService(mapboxAccessToken);

                if (Session["cliente"] != null)
                {
                    Cliente clienteLogueado = (Cliente)Session["cliente"];

                    //idCliente = clienteLogueado.id;
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

            else
            {
                // Para PostBacks, asegúrate de que el servicio se reinicialice
                string mapboxAccessToken = ConfigurationManager.AppSettings["MapboxAccessToken"];
                _mapboxService = new MapBoxService(mapboxAccessToken);
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

        private string BuildFullAddress(string street, string number, string city, string province, string postalCode, string floorInfo = "")
        {
            StringBuilder address = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(street))
            {
                address.Append(street.Trim());
            }
            if (!string.IsNullOrWhiteSpace(number))
            {
                address.Append($" {number.Trim()}");
            }
            if (!string.IsNullOrWhiteSpace(floorInfo))
            {
                address.Append($", {floorInfo.Trim()}");
            }
            if (!string.IsNullOrWhiteSpace(city))
            {
                address.Append($", {city.Trim()}");
            }
            if (!string.IsNullOrWhiteSpace(province))
            {
                address.Append($", {province.Trim()}");
            }
            if (!string.IsNullOrWhiteSpace(postalCode))
            {
                address.Append($", {postalCode.Trim()}");
            }

            return address.ToString().TrimStart(',', ' ').TrimEnd(','); // Limpiar comas y espacios iniciales/finales
        }


        protected async void btnCotizar_Click(object sender, EventArgs e)
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


            // realizar busqueda del precio dependiendo la categoria
            GestionTarifasEnvio gestionTarifas = new GestionTarifasEnvio();
            decimal precioPorKm = gestionTarifas.ObtenerPrecioCategoria(paquete.Categoria.idCategoria);



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

            // realizo una prueba 

            //decimal total = item.Precio;

            //for (int i = 0; i < listaItems.Count; i++)
            //{
            //    total += listaItems[i].Precio;
            //}

            //detalle.Cantidad = listaItems.Count; //Si se deja cantidad en detalle lo descomento
            //detalle.Cantidad = paquete.Cantidad;


            // realizo una prueba
            //lblTotal.Text = total.ToString("N2");


            // prueba para la llamada a la api de mapbox
            string origenAddress = BuildFullAddress(
                txtCalleOrigen.Text,
                txtNumeroOrigen.Text,
                txtCiudadOrigen.Text,
                txtProvinciaOrigen.Text,
                txtCPOrigen.Text,
                txtPisoOrigen.Text
            );

            string destinoAddress = BuildFullAddress(
                txtCalleDestino.Text,
                txtNumeroDestino.Text,
                ddlLocalidades.SelectedItem?.Text, 
                ddlProvincias.SelectedItem?.Text,  
                txtCPDestino.Text,
                txtPisoDestino.Text
            );

            if (string.IsNullOrWhiteSpace(origenAddress) || string.IsNullOrWhiteSpace(destinoAddress))
            {
                lblMensajePaquete.Text = "Por favor, ingrese direcciones de origen y destino completas para cotizar.";
                return;
            }

          
            GeocodingResponse origenGeo = await _mapboxService.GetCoordinatesFromAddress(origenAddress);
            if (origenGeo == null || !origenGeo.Features.Any())
            {
                lblMensajePaquete.Text = $"No se pudieron encontrar coordenadas para la dirección de origen: '{origenAddress}'. Verifique la dirección. Mensaje de Mapbox: {origenGeo?.Message ?? "N/A"}";
                return;
            }
            double startLng = origenGeo.Features[0].Center[0];
            double startLat = origenGeo.Features[0].Center[1];

           
            GeocodingResponse destinoGeo = await _mapboxService.GetCoordinatesFromAddress(destinoAddress);
            if (destinoGeo == null || !destinoGeo.Features.Any())
            {
                lblMensajePaquete.Text = $"No se pudieron encontrar coordenadas para la dirección de destino: '{destinoAddress}'. Verifique la dirección. Mensaje de Mapbox: {destinoGeo?.Message ?? "N/A"}";
                return;
            }
            double endLng = destinoGeo.Features[0].Center[0];
            double endLat = destinoGeo.Features[0].Center[1];

           
            var routeData = await _mapboxService.GetRouteData(startLng, startLat, endLng, endLat);

            double distanciaKm = 0;
            double duracionMinutos = 0;


            if (routeData != null && routeData.Routes != null && routeData.Routes.Any())
            {
                var route = routeData.Routes.First();

                
                distanciaKm = route.Distance / 1000; 
                duracionMinutos = route.Duration / 60;
                // lblMensajePaquete.Text = $"Distancia: {distanciaKm:N2} km, Duración: {duracionMinutos:N2} minutos.";
                //lblMensajePaquete.Text = $"Distancia: {distanciaKm:N2} km, Duración: {(int)Math.Round(duracionMinutos)} minutos.";

                //lblTotal.Text = "Calculando..."; 

                lblDistanciaKm.Text = $"{distanciaKm:N2} km";
                lblDuracionMinutos.Text = $"{(int)Math.Round(duracionMinutos)} minutos";

                lblMensajePaquete.Text = $"Distancia: {distanciaKm:N2} km, Duración: {(int)Math.Round(duracionMinutos)} minutos.";



                if (route.Geometry != null && route.Geometry.Coordinates != null)
                {
                    var geometryCoordinatesJson = JsonConvert.SerializeObject(route.Geometry.Coordinates);

                    ScriptManager.RegisterStartupScript(this, GetType(), "DrawRoute",
                        $"drawRouteOnMap({geometryCoordinatesJson}, {startLng.ToString(CultureInfo.InvariantCulture)}, {startLat.ToString(CultureInfo.InvariantCulture)}, {endLng.ToString(CultureInfo.InvariantCulture)}, {endLat.ToString(CultureInfo.InvariantCulture)});", true);
                }
            }
            else if (routeData != null && !string.IsNullOrEmpty(routeData.Message))
            {
                lblMensajePaquete.Text = $"Error de Mapbox al calcular la ruta: {routeData.Message} (Código: {routeData.Code})";

                lblDistanciaKm.Text = "N/A";
                lblDuracionMinutos.Text = "N/A";
            }
            else
            {
                lblMensajePaquete.Text = "No se pudo obtener la ruta o los datos son inválidos. Verifique las direcciones ingresadas.";
                lblDistanciaKm.Text = "N/A";
                lblDuracionMinutos.Text = "N/A";
            }

            // se realiza el guardado para poder recibirlo en el cargar orden
            ViewState["DistanciaKm"] = distanciaKm;
            ViewState["DuracionMin"] = duracionMinutos;

            // precio segun categoria
            decimal totalItem = item.Precio;
            
            // calculo de la distancia por el precio de 1 km
            decimal distanciaTotal = (decimal)distanciaKm * precioPorKm;

            // conversion para que quede en decimal
            decimal distanciaTotalDecimal = (decimal)distanciaTotal;

            // total de la suma por categoria y por distancia
            decimal total = totalItem + distanciaTotalDecimal;


            // se muestra el total en pantalla
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
            GestionCliente gestionCliente = new GestionCliente();

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
            //int idCliente = gestionCliente.returnIDCliente(27443338749);

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
            //int idCliente = gestionCliente.returnIDCliente(cliente.CUIL);
            //Cliente clienteLogueado = (Cliente)Session["cliente"];
            //int idCliente = clienteLogueado.id;

            ordenesEnvio.ruta = new Ruta();
            ordenesEnvio.estado = new EstadoOrdenEnvio();

            //SETEAR RUTAS EN TABLA RUTAS
            if (ViewState["DistanciaKm"] != null)
            ordenesEnvio.ruta.DistanciaEnKM = Convert.ToDecimal(ViewState["DistanciaKm"]);

            if (ViewState["DuracionMin"] != null)
            ordenesEnvio.ruta.TiempoEstimadoMinutos = Convert.ToDecimal(ViewState["DuracionMin"]);

            ordenesEnvio.ruta.PuntoPartida = cliente.Direccion.Provincia + " " + cliente.Direccion.Ciudad;
            ordenesEnvio.ruta.PuntoDestino = destinatario.Direccion.Provincia + " " + destinatario.Direccion.Ciudad;


            //SETEAR EN TABLA ORDEN

            //ordenesEnvio.FechaEnvio = ordenesEnvio.FechaCreacion.AddDays(2); ; //estos datos hay que revisarlos.
            //ordenesEnvio.FechaEstimadaLlegada = ordenesEnvio.FechaCreacion.AddDays(4);
            //ordenesEnvio.FechaDeLlegada = ordenesEnvio.FechaDeLlegada.AddDays(4);

            ordenesEnvio.FechaCreacion = new DateTime();
            ordenesEnvio.FechaCreacion = DateTime.Now;

            //VER DEPENDE DE ASIGNACIÓN DE ORDEN A TRANSPORTISTA
            ordenesEnvio.FechaEnvio = new DateTime();
            ordenesEnvio.FechaEnvio = DateTime.Now;
            ordenesEnvio.FechaEstimadaLlegada = null;
            ordenesEnvio.FechaDeLlegada = null;
            ordenesEnvio.estado.idEstado = 1; //reset en la tabla asi lo paso a 1

            //DETALLE ORDEN

            detalleOrden.paquete = paquete;
            detalleOrden.Total = decimal.Parse(lblTotal.Text);

            decimal total = decimal.Parse(lblTotal.Text);

            ordenesEnvio.idOrdenEnvio = gestionOrdenesEnvio.agregarOrdenEnvio(ordenesEnvio, detalleOrden);

            Session["IDOrden"] = ordenesEnvio.idOrdenEnvio;
            Session["Total"] = total;

            System.Diagnostics.Debug.WriteLine("IDOrden: " + ordenesEnvio.idOrdenEnvio);
            System.Diagnostics.Debug.WriteLine("Total: " + total);

            Response.Redirect("PasarelaDePago.aspx");

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