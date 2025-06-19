using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Gestion
{
    public class GestionDestinatario
    {
        public void agregarDestinatario(Destinatario destinatario)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {

                gestionDatos.setearConsulta("INSERT INTO Direccion (Calle, CodigoPostal, Provincia, Piso, Numero, Ciudad) " +
                                            " OUTPUT INSERTED.IDDireccion VALUES(@Calle, @CodigoPostal, @Provincia, @Piso, @Numero, @Ciudad)");

                gestionDatos.setearParametro("@Calle", destinatario.Direccion.Calle);
                gestionDatos.setearParametro("@CodigoPostal", destinatario.Direccion.CodigoPostal);
                gestionDatos.setearParametro("@Provincia", destinatario.Direccion.Provincia);
                gestionDatos.setearParametro("@Piso", destinatario.Direccion.Piso);
                gestionDatos.setearParametro("@Numero", destinatario.Direccion.Numero);
                gestionDatos.setearParametro("@Ciudad", destinatario.Direccion.Ciudad);

                int idDireccion = Convert.ToInt32(gestionDatos.obtenerValor());

                gestionDatos.cerrarConexion();



                gestionDatos.setearConsulta("INSERT INTO Destinatarios (IDDirección, Cuil, Nombre, Apellido, Email, Telefono) " +
                                    "VALUES (@IDDireccion, @CUIL, @Nombre, @Apellido, @Email, @Telefono)");

                gestionDatos.setearParametro("@IDDireccion", idDireccion);
                gestionDatos.setearParametro("@CUIL", destinatario.CUIL);
                gestionDatos.setearParametro("@Nombre", destinatario.Nombre);
                gestionDatos.setearParametro("@Apellido", destinatario.Apellido);
                gestionDatos.setearParametro("@Email", destinatario.Email);
                gestionDatos.setearParametro("@Telefono", destinatario.Telefono);

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

        public int returnIDDestinatario(long cuil)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT IDDestinatario, Cuil FROM Destinatarios where Cuil=@Cuil");
                datos.setearParametro("@Cuil", cuil);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    return (int)datos.Lector["IDDestinatario"];
                }

                throw new Exception("Cliente no encontrado con ese CUIL.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método returnIDCliente: " + ex.Message, ex);
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificarDestinatario(Destinatario destinatario)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("UPDATE Destinatarios SET IDDirección = @IDDirección, Cuil = @Cuil, Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Email = @Email WHERE Cuil = @Cuil");

                gestionDatos.setearParametro("@IDDIreccion", destinatario.Direccion.idDireccion);
                gestionDatos.setearParametro("@Cuil", destinatario.CUIL);
                gestionDatos.setearParametro("@Nombre", destinatario.Nombre);
                gestionDatos.setearParametro("@Apellido", destinatario.Apellido);
                gestionDatos.setearParametro("@Telefono", destinatario.Telefono);
                gestionDatos.setearParametro("@Email", destinatario.Email);

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

        public void eliminarDestinatario(long cuil)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.abrirConexion();
                gestionDatos.setearConsulta("UPDATE Destinatarios SET Activo = 0 WHERE Cuil = @Cuil");
                gestionDatos.setearParametro("@Cuil", cuil);
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

        public Destinatario buscarDestinatario(long Cuil)
        {
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDDestinatario, Cuil, Nombre, Apellido, Telefono, Email FROM Destinatarios WHERE Cuil = @Cuil");
                gestionDatos.setearParametro("@Cuil", Cuil);
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Destinatario destinatario = new Destinatario();
                    destinatario.idDestinatario = (int)gestionDatos.Lector["IDDestinatario"];
                    destinatario.CUIL = (long)gestionDatos.Lector["Cuil"];
                    destinatario.Nombre = gestionDatos.Lector["Nombre"].ToString();
                    destinatario.Apellido = gestionDatos.Lector["Apellido"].ToString();
                    destinatario.Telefono = gestionDatos.Lector["Telefono"].ToString();
                    destinatario.Email = gestionDatos.Lector["Email"].ToString();

                    return destinatario;
                }

                throw new Exception("Destinatario no encontrado con esa Cuil.");
            }
            catch (Exception ex)
            {

                throw new Exception("Error en método buscarDestinatario: " + ex.Message, ex);
            }

            finally
            {
                gestionDatos.cerrarConexion();
            }
        }

        public List<Destinatario> listarDestinatario() 
        {
            List<Destinatario> lista = new List<Destinatario>();
            AccesoDatos gestionDatos = new AccesoDatos();

            try
            {
                gestionDatos.setearConsulta("SELECT IDDestinatario, Cuil, Nombre, Apellido, Telefono, Email FROM Destinatarios");
                gestionDatos.ejecutarLectura();

                while (gestionDatos.Lector.Read())
                {
                    Destinatario destinatario = new Destinatario();
                    destinatario.idDestinatario = (int)gestionDatos.Lector["IDDestinatario"];
                    destinatario.CUIL = (long)gestionDatos.Lector["Cuil"];
                    destinatario.Nombre = gestionDatos.Lector["Nombre"].ToString();
                    destinatario.Apellido = gestionDatos.Lector["Apellido"].ToString();
                    destinatario.Telefono = gestionDatos.Lector["Telefono"].ToString();
                    destinatario.Email = gestionDatos.Lector["Email"].ToString();


                    lista.Add(destinatario);
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

    }
}
