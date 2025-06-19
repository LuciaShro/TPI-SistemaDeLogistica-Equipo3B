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

                gestionDatos.setearParametro("@IDCategoria", paquete.Categoria.idCategoria);
                gestionDatos.setearParametro("@Cantidad", paquete.Cantidad);
                gestionDatos.setearParametro("@valorDeclarado", paquete.ValorDeclarado);
                gestionDatos.setearParametro("@Peso", paquete.Peso);
                gestionDatos.setearParametro("@Alto", paquete.Alto);
                gestionDatos.setearParametro("@Ancho",paquete.Ancho);
                gestionDatos.setearParametro("@Largo",paquete.Largo);

                int idPquete = Convert.ToInt32(gestionDatos.obtenerValor());

                //gestionDatos.ejecutarAccion();

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

        public void modificarPaquete(Paquete paquete) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Paquete SET IDCategoria = @IDCategoria, Cantidad = @Cantidad, valorDeclarado = @valorDeclarado, Peso = @Peso, Alto = @Alto, Ancho = @Ancho, Largo = @Largo WHERE IDPaquete = @IDPaquete");

                gestionDatos.setearParametro("@IDCategoria", paquete.Categoria.idCategoria);
                gestionDatos.setearParametro("@Cantidad", paquete.Cantidad);
                gestionDatos.setearParametro("@valorDeclarado", paquete.ValorDeclarado);
                gestionDatos.setearParametro("@Peso", paquete.Peso);
                gestionDatos.setearParametro("@Alto", paquete.Alto);
                gestionDatos.setearParametro("@Ancho", paquete.Ancho);
                gestionDatos.setearParametro("@Largo", paquete.Largo);

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

        public void eliminarPaquete() { } ///NO TIENE SENTIDO

        public List<Paquete> listarPaquetes() 
        {
            List<Paquete> lista = new List<Paquete>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDCategoria, Cantidad, valorDeclarado, Peso, Alto, Ancho, Largo FROM Paquete");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Paquete paquete = new Paquete();
                    paquete.Categoria.idCategoria = (int)gestionDatos.Lector["IDCategoria"];
                    paquete.Cantidad = (int)gestionDatos.Lector["Cantidad"];
                    paquete.ValorDeclarado = (decimal)gestionDatos.Lector["ValorDeclarado"];
                    paquete.Peso = (float)gestionDatos.Lector["Peso"];
                    paquete.Alto =  (float)gestionDatos.Lector["Alto"];
                    paquete.Ancho = (float)gestionDatos.Lector["Ancho"];
                    paquete.Largo = (float)gestionDatos.Lector["Largo"];


                    lista.Add(paquete);
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

        public Paquete buscarPaquete(int idPaquete) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDCategoria, Cantidad, valorDeclarado, Peso, Alto, Ancho, Largo FROM Paquete WHERE IDPaquete = @IDPaquete");
                gestionDatos.setearParametro("@IDPaquete", idPaquete);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Paquete paquete = new Paquete();
                    paquete.Categoria.idCategoria = (int)gestionDatos.Lector["IDCategoria"];
                    paquete.Cantidad = (int)gestionDatos.Lector["Cantidad"];
                    paquete.ValorDeclarado = (decimal)gestionDatos.Lector["ValorDeclarado"];
                    paquete.Peso = (float)gestionDatos.Lector["Peso"];
                    paquete.Alto = (float)gestionDatos.Lector["Alto"];
                    paquete.Ancho = (float)gestionDatos.Lector["Ancho"];
                    paquete.Largo = (float)gestionDatos.Lector["Largo"];

                    return paquete;
                }

                throw new Exception("Paquete no encontrado con esa ID.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método buscarPaquete: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
