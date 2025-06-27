using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionDetalleVenta
    {
        public VentaDetalle ObtenerDetalleVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            VentaDetalle detalle = new VentaDetalle();

            // Inicialización de objetos anidados
            detalle.estadoDePago = new EstadoDePago();
            detalle.EstadoEnvio = new EstadoOrdenEnvio();
            detalle.cliente = new Cliente();
            detalle.cliente.Direccion = new Direccion();
            detalle.destinatario = new Destinatario();
            detalle.destinatario.Direccion = new Direccion();
            detalle.cliente.Usuario = new Usuario();
            detalle.MetodoPago = new FormaDePago();
            detalle.paquete = new Paquete();
            detalle.paquete.Categoria = new Categoria();
            detalle.detalle = new DetalleOrden(); 

            datos.setearConsulta("EXEC sp_DetalleVenta @idVenta");
            datos.setearParametro("@idVenta", idVenta);
            datos.ejecutarLectura();

            if (datos.Lector.Read())
            {
                detalle.IdVenta = (int)datos.Lector["IDVenta"];
                detalle.estadoDePago.nombreEstado = datos.Lector["EstadoPago"].ToString();
                detalle.EstadoEnvio.DescripcionEstado = datos.Lector["EstadoEnvio"].ToString();

                // Paquete
                detalle.paquete.Alto = detalle.paquete.Alto = Convert.ToSingle(datos.Lector["Alto"]);
                detalle.paquete.Ancho = detalle.paquete.Alto = Convert.ToSingle(datos.Lector["Ancho"]);
                detalle.paquete.Largo = detalle.paquete.Alto = Convert.ToSingle(datos.Lector["Largo"]);
                detalle.paquete.Peso = detalle.paquete.Alto = Convert.ToSingle(datos.Lector["Peso"]);
                detalle.paquete.Cantidad = (int)datos.Lector["Cantidad"];
                detalle.paquete.ValorDeclarado = (decimal)datos.Lector["ValorDeclarado"];
                detalle.paquete.Categoria.DescripcionCategoria = datos.Lector["Categoria"].ToString();

                // Cliente
                detalle.cliente.Nombre = datos.Lector["Nombre"].ToString();
                detalle.cliente.Apellido = datos.Lector["Apellido"].ToString();
                detalle.cliente.CUIL = (long)datos.Lector["Cuil"];
                detalle.cliente.Telefono = datos.Lector["Telefono"].ToString();
                detalle.cliente.Direccion.Calle = datos.Lector["Calle"].ToString();
                detalle.cliente.Direccion.NumeroCalle = (int)datos.Lector["Numero"];
                detalle.cliente.Direccion.Piso = datos.Lector["Piso"].ToString();
                detalle.cliente.Direccion.CodigoPostal = datos.Lector["CodigoPostal"].ToString();
                detalle.cliente.Direccion.Ciudad = datos.Lector["Ciudad"].ToString();
                detalle.cliente.Direccion.Provincia = datos.Lector["Provincia"].ToString();

                // Destinatario
                detalle.destinatario.Nombre = datos.Lector["NombreDestinatario"].ToString();
                detalle.destinatario.Apellido = datos.Lector["ApellidoDestinatario"].ToString();
                detalle.destinatario.CUIL = (long)datos.Lector["CuilDestinatario"];
                detalle.destinatario.Telefono = datos.Lector["TelefonoDestinatario"].ToString();
                detalle.destinatario.Email = datos.Lector["EmailDestinatario"].ToString();
                detalle.destinatario.Direccion.Calle = datos.Lector["CalleDestinatario"].ToString();
                detalle.destinatario.Direccion.NumeroCalle = (int)datos.Lector["NumeroDestinatario"];
                detalle.destinatario.Direccion.Piso = datos.Lector["PisoDestinatario"].ToString();
                detalle.destinatario.Direccion.CodigoPostal = datos.Lector["CodigoPostalDestinatario"].ToString();
                detalle.destinatario.Direccion.Ciudad = datos.Lector["CiudadDestinatario"].ToString();
                detalle.destinatario.Direccion.Provincia = datos.Lector["ProvinciaDestinatario"].ToString();

                // Usuario y pago
                detalle.cliente.Usuario.Email = datos.Lector["Email"].ToString();
                detalle.MetodoPago.medioDePago = datos.Lector["MedioDePago"].ToString();
                detalle.detalle.Total = (decimal)datos.Lector["Total"];
            }

            datos.cerrarConexion();
            return detalle;
        }

    }
}
