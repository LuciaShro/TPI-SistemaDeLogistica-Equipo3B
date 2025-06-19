using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion
{
    public class GestionDireccion
    {
        public int agregarDireccion (Direccion direccion) {

            AccesoDatos datos = new AccesoDatos ();

            try
            {
                datos.setearProcedimiento("storedAltaDireccion");
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@CodigoPosta", direccion.CodigoPostal);
                datos.setearParametro("@Provincia", direccion.Provincia);
                datos.setearParametro("@Piso", direccion.Piso);
                datos.setearParametro("@Numero", direccion.NumeroCalle);
                datos.setearParametro("@Ciudad", direccion.Ciudad);

                int idDireccion = Convert.ToInt32(datos.obtenerValor());
                return idDireccion;

               

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        
        }

        public void modificarDireccion() { }

        public void eliminarDireccion() { }
    }
}
