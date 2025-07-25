﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionDetalleOrden
    {
        public void agregarDetalleOrden(DetalleOrden detalleOrden)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {

                gestionDatos.setearConsulta("INSERT INTO DetalleOrdenesEnvio (IDOrden, IDPaquete, Total) " +
                                            "VALUE (@IDOrden, @IDPaquete, @Total, @Activo)");

                gestionDatos.setearParametro("@IDOrden", detalleOrden.Orden);
                gestionDatos.setearParametro("@IDPaquete", detalleOrden.paquete.idPaquete);
                gestionDatos.setearParametro("@Total", detalleOrden.Total);
                gestionDatos.setearParametro("@Activo", 1);

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


    }
}
