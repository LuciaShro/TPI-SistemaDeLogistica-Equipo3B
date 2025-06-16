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

        public void modificarDestinatario() { }

        public void eliminarDestinatario() { }

        public void buscarDestinatario() { }

        public void listarDestinatario() { }

    }
}
