using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionRuta
    {
        public void agregarRuta(Ruta ruta)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("INSERT INTO Rutas (PuntoPartida, PuntoDestino) " +
                                           " VALUES (@PuntoPartida, @PuntoDestino)");

                gestionDatos.setearParametro("@PuntoPartida", ruta.PuntoPartida);
                gestionDatos.setearParametro("@PuntoDestino", ruta.PuntoDestino);

                gestionDatos.ejecutarAccion();

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

        public List<Ruta> listarRutas()
        {
            List<Ruta> lista = new List<Ruta>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT PuntoPartida, PuntoDestino FROM Rutas");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Ruta aux = new Ruta();
                    aux.idRuta = (int)gestionDatos.Lector["idRuta"];
                    aux.PuntoPartida = gestionDatos.Lector["PuntoPartida"].ToString();
                    aux.PuntoDestino = gestionDatos.Lector["PuntoDestino"].ToString();


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
                gestionDatos.cerrarConexion();
            }
        }

        public void modificarRuta(Ruta ruta) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Rutas SET PuntoPartida = @PuntoPartida, PuntoDestino = @PuntoDestino WHERE IdRuta = @IdRuta");

                gestionDatos.setearParametro("@PuntoPartida", ruta.PuntoPartida);
                gestionDatos.setearParametro("@PuntoDestino", ruta.PuntoDestino);
                gestionDatos.setearParametro("@IdRuta", ruta.idRuta);

                gestionDatos.ejecutarAccion();

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

        public void asignarRuta() { }
    }
}
