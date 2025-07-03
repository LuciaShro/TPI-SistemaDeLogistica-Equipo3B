using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionItemsOrden
    {
        public ItemOrden returnItemOrden(int idOrden)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT det.Total, c.Nombre as Categoria FROM OrdenesEnvio AS oe INNER JOIN DetalleOrdenesEnvio AS det ON det.IDOrden = oe.IDOrden INNER JOIN Paquete AS p ON p.IDPaquete = det.IDPaquete INNER JOIN Categoria AS c ON c.IDCategoria = p.IDCategoria WHERE oe.IDOrden = @IDOrden");
                gestionDatos.setearParametro("@IDOrden", idOrden);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    ItemOrden item = new ItemOrden();
                    item.Precio = (decimal)gestionDatos.Lector["Total"];
                    item.Total = (decimal)gestionDatos.Lector["Total"];
                    item.Categoria = gestionDatos.Lector["Categoria"].ToString();

                    return item;
                }

                throw new Exception("Orden no encontrada con ese ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnItemOrden: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
