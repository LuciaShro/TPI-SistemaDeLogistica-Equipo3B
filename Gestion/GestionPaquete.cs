using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionPaquete
    {
        public int agregarPaquete(Paquete paquete)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("INSERT INTO Paquete (IDCategoria, Cantidad, valorDeclarado, Peso, Alto, Ancho, Largo) " +
                                            "OUTPUT INSERTED.IDPaquete "+ "VALUES (@IDCategoria, @Cantidad, @valorDeclarado, @Peso, @Alto, @Ancho, @Largo)");

                gestionDatos.setearParametro("@IDCategoria", paquete.IDCategoria);
                gestionDatos.setearParametro("@Cantidad", paquete.Cantidad);
                gestionDatos.setearParametro("@valorDeclarado", paquete.ValorDeclarado);
                gestionDatos.setearParametro("@Peso", paquete.Peso);
                gestionDatos.setearParametro("@Alto", paquete.Alto);
                gestionDatos.setearParametro("@Ancho",paquete.Ancho);
                gestionDatos.setearParametro("@Largo",paquete.Largo);

                int idPquete = Convert.ToInt32(gestionDatos.obtenerValor());

                gestionDatos.ejecutarAccion();

                gestionDatos.cerrarConexion();

                return idPquete;
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

        public void modificarPaquete() { }

        public void eliminarPaquete() { }

        public void listarPaquetes() { }

        public bool buscarPaquete() { return false; }
    }
}
