using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionEstado
    {
        public void agregarEstado () { }

        public void modificarEstado () { }

        public void eliminarEstado (int id) { }

        public List<EstadoOrdenEnvio> listarEstado () {
            List<EstadoOrdenEnvio> lista = new List<EstadoOrdenEnvio>();
            AccesoDatos gestionEstado = new AccesoDatos();

            try
            {
                gestionEstado.setearConsulta("SELECT Descripcion, IDEstadoOrdenEnvio FROM EstadoOrdenesEnvio");
                gestionEstado.ejecutarLectura();

                while (gestionEstado.Lector.Read())
                {
                    EstadoOrdenEnvio estado = new EstadoOrdenEnvio();
                    estado.idEstado = (int)gestionEstado.Lector["IDEstadoOrdenEnvio"];
                    estado.DescripcionEstado = gestionEstado.Lector["Descripcion"].ToString();

                    lista.Add(estado);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                gestionEstado.cerrarConexion();
            }
        }

        public void cambiarEstado () { }

    }
}
