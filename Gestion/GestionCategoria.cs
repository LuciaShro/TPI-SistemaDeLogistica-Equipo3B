using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionCategoria
    {
        public void AgregarCategoria (Categoria categoria) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("INSERT INTO Categoria (Nombre, Descripcion) " +
                                           " VALUES (@Nombre, @Descripcion)");

                gestionDatos.setearParametro("@Nombre", categoria.Nombre);
                gestionDatos.setearParametro("@Descripcion", categoria.DescripcionCategoria);

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
        public void ModificarCategoria (Categoria categoria) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Categoria SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Nombre = @Nombre");

                gestionDatos.setearParametro("@Nombre", categoria.Nombre);
                gestionDatos.setearParametro("@Descripcion", categoria.DescripcionCategoria);

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

        public void EliminarCategoria () 
        {
        }

        public List<Categoria> ListarCategorias() 
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT Nombre, Descripcion FROM Categoria");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.idCategoria = (int)gestionDatos.Lector["IDCategoria"];
                    cat.Nombre = gestionDatos.Lector["Nombre"].ToString();
                    cat.DescripcionCategoria = gestionDatos.Lector["Descripcion"].ToString();


                    lista.Add(cat);
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

        public Categoria buscarCategoria (string Nombre) 
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT Nombre, Descripcion FROM Categoria WHERE Nombre = @Nombre");
                gestionDatos.setearParametro("@Nombre", Nombre);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Categoria cat = new Categoria();
                    cat.idCategoria = (int)gestionDatos.Lector["IDCategoria"];
                    cat.Nombre = (string)gestionDatos.Lector["Nombre"];
                    cat.DescripcionCategoria = (string)gestionDatos.Lector["Descripcion"];

                    return cat;
                }

                throw new Exception("Categoria no encontrada con ese Nombre.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método buscarCategoria: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }
    }
}
