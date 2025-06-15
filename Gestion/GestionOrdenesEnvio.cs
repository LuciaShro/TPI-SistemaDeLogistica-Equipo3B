using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static System.Net.Mime.MediaTypeNames;

namespace Gestion
{
    public class GestionOrdenesEnvio
    {
        public void agregarOrdenEnvio(OrdenesEnvio ordenEnvio, DetalleOrden detalleOrden)
        {

            AccesoDatos gestionDatos = new AccesoDatos();
            GestionCliente gestionCliente = new GestionCliente();
            GestionDestinatario gestionDestinatario = new GestionDestinatario();
            GestionDetalleOrden gestionDetalle = new GestionDetalleOrden();
            GestionPaquete gestionPaquete = new GestionPaquete();

            try
            {

                long cuilCliente = ordenEnvio.cliente.CUIL;
                long cuilDestinatario = ordenEnvio.destinatario.CUIL;

                int idCliente = gestionCliente.returnIDCliente(cuilCliente);
                int idUsuario = gestionCliente.returnIDUsuario(cuilCliente);
                int idDestinatario = gestionDestinatario.returnIDDestinatario(cuilDestinatario);



                gestionDatos.setearConsulta("INSERT INTO Rutas (PuntoPartida, PuntoDestino) " +
                                            " OUTPUT INSERTED.IDRuta VALUES (@PuntoPartida, @PuntoDestino)");

                gestionDatos.setearParametro("@PuntoPartida", ordenEnvio.ruta.PuntoPartida);
                gestionDatos.setearParametro("@PuntoDestino", ordenEnvio.ruta.PuntoDestino);

                int idRuta = Convert.ToInt32(gestionDatos.obtenerValor());

                gestionDatos.cerrarConexion();



                gestionDatos.setearConsulta("INSERT INTO OrdenesEnvio (IDUsuario, IDCliente, IDTransportista, IDRuta, IDEstadoOrdenEnvio, IDDestinatario, FechaCreacion, FechaEnvio, FechaEstimadaLlegada, FechaLlegada) " +
                                    "OUTPUT INSERTED.IDOrden " + "VALUES (@IDUsuario, @IDCliente, @IDTransportista, @IDRuta, @IDEstadoOrdenEnvio, @IDDestinatario, @FechaCreacion, @FechaEnvio, @FechaEstimadaLlegada, @FechaLlegada)");

                gestionDatos.setearParametro("@IDUsuario", idCliente); 
                gestionDatos.setearParametro("@IDCliente", idUsuario);
                //gestionDatos.setearParametro("@IDTransportista", ordenEnvio.transportistaAsignado);
                //gestionDatos.setearParametro("@IDEstadoOrdenEnvio", ordenEnvio.estado);
                gestionDatos.setearParametro("@IDDestinatario", idDestinatario);
                gestionDatos.setearParametro("@FechaCreacion", ordenEnvio.FechaCreacion);
                gestionDatos.setearParametro("@FechaEnvio", ordenEnvio.FechaEnvio);
                gestionDatos.setearParametro("@FechaEstimadaLlegada", ordenEnvio.FechaEstimadaLlegada);
                gestionDatos.setearParametro("@FechaLlegada", ordenEnvio.FechaDeLlegada);

                int idOrden = Convert.ToInt32(gestionDatos.obtenerValor());

                gestionDatos.cerrarConexion();


                int idPaquete = gestionPaquete.agregarPaquete(detalleOrden.paquete);

                gestionDatos.setearConsulta("INSERT INTO DetalleOrdenesEnvio (IDOrden, IDPaquete, Total) " +
                                              "VALUE (@IDOrden, @IDPaquete, @Total)");

                gestionDatos.setearParametro("@IDOrden", idOrden);
                gestionDatos.setearParametro("@IDPaquete", idPaquete);
                gestionDatos.setearParametro("@Total", detalleOrden.Total);


                gestionDatos.ejecutarAccion();

                gestionDatos.cerrarConexion();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                gestionDatos.cerrarConexion();
            }


        }

        public void modificarOrdenEnvio() { }

        public void eliminarOrdenEnvio(int id) { }

        public List<OrdenesEnvio> ListarOrdenes()
        {

            List<OrdenesEnvio> lista = new List<OrdenesEnvio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT OE.IDOrden, C.Nombre as NombreCliente, C.Apellido as ApellidoCliente, T.Nombre as NombreTransportista, T.Apellido as ApellidoTransportista, " +
                    "R.PuntoPartida, R.PuntoDestino, EO.Descripcion as EstadoOrden, D.Nombre as NombreDestinatario, D.Apellido as ApellidoDestinatario, OE.FechaCreacion, OE.FechaEnvio, " +
                    "OE.FechaEstimadaLlegada, OE.FechaLlegada, OE.CantidadPaquetes FROM OrdenesEnvio OE INNER JOIN Usuario U ON OE.IDUsuario = U.IDUsuario INNER JOIN Clientes C ON OE.IDCliente = C.IDCliente " +
                    "INNER JOIN Transportista T ON OE.IDTransportista = T.IDTransportista INNER JOIN Rutas R ON OE.IDRuta = R.IDRuta " +
                    "INNER JOIN EstadoOrdenesEnvio EO ON OE.IDEstadoOrdenEnvio = EO.IDEstadoOrdenEnvio INNER JOIN Destinatarios D ON OE.IDDestinatario = D.IDDestinatario;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    OrdenesEnvio aux = new OrdenesEnvio();
                    aux.idOrdenEnvio = (int)datos.Lector["IDOrden"];
                    aux.cliente = new Cliente();
                    aux.cliente.Nombre = datos.Lector["NombreCliente"].ToString();
                    aux.cliente.Apellido = datos.Lector["ApellidoCliente"].ToString();
                    aux.transportistaAsignado = new Transportista();
                    aux.transportistaAsignado.Nombre = datos.Lector["NombreTransportista"].ToString();
                    aux.transportistaAsignado.Apellido = datos.Lector["ApellidoTransportista"].ToString();
                    aux.ruta = new Ruta();
                    aux.ruta.PuntoPartida = datos.Lector["PuntoPartida"].ToString();
                    aux.ruta.PuntoDestino = datos.Lector["PuntoDestino"].ToString();
                    aux.estado = new EstadoOrdenEnvio();
                    aux.estado.DescripcionEstado = datos.Lector["EstadoOrden"].ToString();
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaEnvio = (DateTime)datos.Lector["FechaEnvio"];
                    aux.FechaEstimadaLlegada = (DateTime)datos.Lector["FechaEstimadaLlegada"];
                    aux.FechaDeLlegada = (DateTime)datos.Lector["FechaLlegada"];
                    //aux.CantidadTotalEnviada = (int)datos.Lector["CantidadPaquetes"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public bool buscarOrdenEnvio() { return false; }

        public void CalcularCantidadEnviada() { }

        public float CotizarEnvio() { return 0f; }
    }
}
