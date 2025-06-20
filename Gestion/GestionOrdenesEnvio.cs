﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http;
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



                gestionDatos.setearConsulta("INSERT INTO OrdenesEnvio (IDUsuario, IDCliente, IDTransportista, IDRuta, IDEstadoOrdenEnvio, IDDestinatario, FechaCreacion, FechaEnvio, FechaEstimadaLlegada, FechaLlegada, Activo) " +
                                    "OUTPUT INSERTED.IDOrden " + "VALUES (@IDUsuario, @IDCliente, @IDTransportista, @IDRuta, @IDEstadoOrdenEnvio, @IDDestinatario, @FechaCreacion, @FechaEnvio, @FechaEstimadaLlegada, @FechaLlegada, @Activo)");

                gestionDatos.setearParametro("@IDUsuario", idUsuario); 
                gestionDatos.setearParametro("@IDCliente", idCliente);
                gestionDatos.setearParametro("@IDTransportista", ordenEnvio.idTransportistaAsignado);
                gestionDatos.setearParametro("@IDRuta", idRuta);
                gestionDatos.setearParametro("@IDEstadoOrdenEnvio", ordenEnvio.estado.idEstado);
                gestionDatos.setearParametro("@IDDestinatario", idDestinatario);
                gestionDatos.setearParametro("@FechaCreacion", ordenEnvio.FechaCreacion);
                gestionDatos.setearParametro("@FechaEnvio", ordenEnvio.FechaEnvio);
                gestionDatos.setearParametro("@FechaEstimadaLlegada", ordenEnvio.FechaEstimadaLlegada);
                gestionDatos.setearParametro("@FechaLlegada", ordenEnvio.FechaDeLlegada);
                gestionDatos.setearParametro("@Activo", 1);

                int idOrden = Convert.ToInt32(gestionDatos.obtenerValor());
                ordenEnvio.idOrdenEnvio = idOrden;
                detalleOrden.Orden = ordenEnvio;

                gestionDatos.cerrarConexion();


                int idPaquete = gestionPaquete.agregarPaquete(detalleOrden.paquete);

                gestionDatos.setearConsulta("INSERT INTO DetalleOrdenesEnvio (IDOrden, IDPaquete, Total, Activo) " +
                                              "VALUES (@IDOrden, @IDPaquete, @Total, 1)");

                gestionDatos.setearParametro("@IDOrden", detalleOrden.Orden.idOrdenEnvio);
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

        public void modificarOrdenEnvio(OrdenesEnvio orden) {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE OrdenesEnvio SET IDTransportista = @IDTransportista, IDEstadoOrdenEnvio = @IDEstadoOrdenEnvio WHERE IDOrden = @IDOrden");
                datos.setearParametro("@IDTransportista", orden.idTransportistaAsignado);
                datos.setearParametro("@IDEstadoOrdenEnvio", orden.estado.idEstado);
                datos.setearParametro("@IDOrden", orden.idOrdenEnvio);
                datos.ejecutarAccion();


                datos.setearConsulta("UPDATE Vehiculo SET IDEstadoVehiculo = @IDEstadoVehiculo WHERE IDVehiculo = (SELECT IDVehiculo FROM Transportista WHERE IDTransportista = @IDTransportista)");
                datos.setearParametro("@IDEstadoVehiculo", orden.transportista.Vehiculo.estadoVehiculo.IDEstado);
                datos.setearParametro("@IDTransportista", orden.idTransportistaAsignado);
                datos.ejecutarAccion();

            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarOrdenEnvio(int id) {
            
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update OrdenesEnvio set Activo=0 where IDOrden = @idOrden;" +
                    "update DetalleOrdenesEnvio set Activo=0 where IDOrden = @idOrden;");
                datos.setearParametro("idOrden", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<OrdenesEnvio> ListarOrdenes(string idOrden = "")
        {

            List<OrdenesEnvio> lista = new List<OrdenesEnvio>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT OE.IDOrden, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, T.IDTransportista AS IDTransportista, T.Nombre AS NombreTransportista," +
                    " T.Apellido AS ApellidoTransportista,V.Patente AS PatenteVehiculo, R.PuntoPartida, R.PuntoDestino,EO.IDEstadoOrdenEnvio, EO.Descripcion AS EstadoOrden, D.Nombre AS NombreDestinatario," +
                    " D.Apellido AS ApellidoDestinatario, D.Cuil AS CuilDestinatario, D.Email AS EmailDestinatario, D.Telefono AS TelefonoDestinatario, C.Cuil AS CuilCliente, " +
                    "C.Telefono AS TelefonoCliente, OE.FechaCreacion, OE.FechaEnvio, OE.FechaEstimadaLlegada, OE.FechaLlegada, U.Email AS EmailCliente, EV.IDEstadoVehiculo, EV.Descripcion AS DescripcionEstadoVehiculo, " +
                    "Pq.Largo, Pq.Alto, Pq.Ancho, Pq.Peso, Pq.valorDeclarado FROM OrdenesEnvio OE INNER JOIN Usuario U ON OE.IDUsuario = U.IDUsuario " +
                    "INNER JOIN Clientes C ON OE.IDCliente = C.IDCliente INNER JOIN Transportista T ON OE.IDTransportista = T.IDTransportista " +
                    "INNER JOIN Vehiculo V ON T.IDVehiculo = V.IDVehiculo " +
                    "INNER JOIN EstadoVehiculo EV ON V.IDEstadoVehiculo = EV.IDEstadoVehiculo " +
                    "INNER JOIN Rutas R ON OE.IDRuta = R.IDRuta INNER JOIN EstadoOrdenesEnvio EO ON OE.IDEstadoOrdenEnvio = EO.IDEstadoOrdenEnvio " +
                    "INNER JOIN Destinatarios D ON OE.IDDestinatario = D.IDDestinatario INNER JOIN DetalleOrdenesEnvio DO ON DO.IDOrden = OE.IDOrden " +
                    "INNER JOIN Paquete Pq ON Pq.IDPaquete = DO.IDPaquete ");
                if (idOrden != "")
                {
                    datos.Comando.CommandText += " WHERE OE.IDOrden = " + idOrden + " AND OE.Activo=1";
                }
                else
                {
                    datos.Comando.CommandText += " WHERE OE.Activo=1";
                }
                    datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    OrdenesEnvio aux = new OrdenesEnvio();
                    DetalleOrden detalle = new DetalleOrden();
                    Transportista transportista = new Transportista();
                    GestionTransportista gestionTransportista = new GestionTransportista();

                    aux.idOrdenEnvio = (int)datos.Lector["IDOrden"];
                    aux.cliente = new Cliente();
                    aux.cliente.Nombre = datos.Lector["NombreCliente"].ToString() +" "+ datos.Lector["ApellidoCliente"].ToString();
                    aux.cliente.Apellido = datos.Lector["ApellidoCliente"].ToString();
                    aux.cliente.CUIL = Convert.ToInt64(datos.Lector["CuilCliente"]);
                    aux.cliente.Usuario = new Usuario();
                    aux.cliente.Usuario.Email= datos.Lector["EmailCliente"].ToString();
                    aux.cliente.Telefono = datos.Lector["TelefonoCliente"].ToString();

                    aux.transportista = new Transportista();
                    aux.idTransportistaAsignado = (int)datos.Lector["IDTransportista"];
                    aux.transportista.IdTransportista = (int)datos.Lector["IDTransportista"];
                    aux.transportista.Nombre = datos.Lector["NombreTransportista"].ToString()+ " " + datos.Lector["ApellidoTransportista"].ToString();
                    aux.transportista.Apellido = datos.Lector["ApellidoTransportista"].ToString();
                    aux.transportista.Vehiculo = new Vehiculo();
                    aux.transportista.Vehiculo.Patente = datos.Lector["PatenteVehiculo"].ToString();

                    aux.transportista.Vehiculo.estadoVehiculo = new EstadoVehiculo();
                    aux.transportista.Vehiculo.estadoVehiculo.IDEstado = (int)datos.Lector["IDEstadoVehiculo"];
                    aux.transportista.Vehiculo.estadoVehiculo.descripcioEstado = datos.Lector["DescripcionEstadoVehiculo"].ToString();


                    aux.destinatario = new Destinatario();
                    aux.destinatario.Nombre = datos.Lector["NombreDestinatario"].ToString();
                    aux.destinatario.Apellido = datos.Lector["ApellidoDestinatario"].ToString();
                    aux.destinatario.CUIL = Convert.ToInt64(datos.Lector["CuilDestinatario"]);
                    aux.destinatario.Usuario = new Usuario();
                    aux.destinatario.Email = datos.Lector["EmailDestinatario"].ToString();
                    aux.destinatario.Telefono = datos.Lector["TelefonoDestinatario"].ToString();
                    aux.ruta = new Ruta();
                    aux.ruta.PuntoPartida = datos.Lector["PuntoPartida"].ToString();
                    aux.ruta.PuntoDestino = datos.Lector["PuntoDestino"].ToString();
                    aux.estado = new EstadoOrdenEnvio();
                    aux.estado.DescripcionEstado = datos.Lector["EstadoOrden"].ToString();
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaEnvio = (DateTime)datos.Lector["FechaEnvio"];
                    aux.FechaEstimadaLlegada = (DateTime)datos.Lector["FechaEstimadaLlegada"];
                    aux.FechaDeLlegada = (DateTime)datos.Lector["FechaLlegada"];


                    aux.paquete = new Paquete();
                    aux.paquete.ValorDeclarado = Convert.ToDecimal(datos.Lector["valorDeclarado"]);
                    aux.paquete.Largo = Convert.ToSingle(datos.Lector["Largo"]);
                    aux.paquete.Ancho = Convert.ToSingle(datos.Lector["Ancho"]);
                    aux.paquete.Alto = Convert.ToSingle(datos.Lector["Alto"]);
                    aux.paquete.Peso = Convert.ToSingle(datos.Lector["Peso"]);

                    aux.estado = new EstadoOrdenEnvio();
                    aux.estado.idEstado = (int)datos.Lector["IDEstadoOrdenEnvio"];
                    aux.estado.DescripcionEstado = datos.Lector["EstadoOrden"].ToString();


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

    }
}
