using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionZona
    {
        public List<Zona> listarZonas() {

            AccesoDatos datos = new AccesoDatos();
            List<Zona> lista = new List<Zona>();

            try
            {
                datos.setearConsulta("select IDZona, Nombre from Zona");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Zona zona = new Zona();
                    zona.IDZona = (int)datos.Lector["IDZona"];
                    zona.Nombre = datos.Lector["Nombre"].ToString();

                    lista.Add(zona);
                }

                return lista;


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


    }
}
