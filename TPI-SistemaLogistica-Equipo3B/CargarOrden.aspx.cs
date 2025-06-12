using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class CargarOrden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {

            OrdenesEnvio ordenesEnvio = new OrdenesEnvio();
            Cliente cliente = new Cliente();
            Destinatario destinatario = new Destinatario();
            Paquete paquete = new Paquete();
            AccesoDatos gestion = new AccesoDatos();
            
            cliente.Nombre = txtNombreOrigen.Text;
            cliente.Apellido = txtApellidoOrigen.Text;
            cliente.Telefono = txtTelefonoOrigen.Text;
            cliente.Direccion.Calle = txtCalleOrigen.Text;
            cliente.Direccion.Numero = int.Parse(txtNumeroOrigen.Text);
            cliente.Direccion.CodigoPostal = txtCPOrigen.Text;
            cliente.Direccion.Ciudad = txtCiudadOrigen.Text;
            cliente.Direccion.Provincia = txtProvinciaOrigen.Text;
            cliente.Direccion.Piso = txtPisoOrigen.Text;
            cliente.InfoAdicional = txtInfoOrigen.Text;


            destinatario.Nombre = txtNombreDestino.Text;
            destinatario.Apellido = txtApellidoDestino.Text;
            destinatario.Telefono = txtTelefonoDestino.Text;
            destinatario.Direccion.Calle = txtCalleDestino.Text;
            destinatario.Direccion.Numero = int.Parse(txtNumeroDestino.Text);
            destinatario.Direccion.CodigoPostal = txtCPDestino.Text;
            destinatario.Direccion.Ciudad = txtCiudadDestino.Text;
            destinatario.Direccion.Provincia = txtProvinciaDesino.Text;
            destinatario.Direccion.Piso = txtPisoDestino.Text;
            destinatario.InfoAdicional = txtInfoDestino.Text;

            paquete.Largo = float.Parse(txtLargo.Text);
            paquete.Ancho = float.Parse(txtAncho.Text);
            paquete.Alto = float.Parse(txtAlto.Text);
            paquete.Peso = float.Parse(txtPeso.Text);
            paquete.ValorDeclarado = decimal.Parse(txtValor.Text);

            try
            {
                datos.setearConsulta("SELECT IDCliente, Cuil FROM Clientes WHERE Cuil = @Cuil");
                datos.setearParametro("@Documento", cliente.Documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    //string encontrado = datos.Lector["Documento"].ToString();
                    //cliente.ClienteId = (int)datos.Lector["Id"];
                    //lblMensajeDNINuevo.Text = "";
                    //lblMensajeDNIencontrado.Text = "El documento ya está registrado: " + encontrado;

                    //dniText.Text = "";
                    //nombre.Text = "";
                    //apellido.Text = "";
                    //email.Text = "";
                    //direccion.Text = "";
                    //ciudad.Text = "";
                    //codigoPostal.Text = "";

                    //lblMensajeDNINuevo.Text = "";


                }
                else
                {
                    //datos.cerrarConexion();
                    //datos.limpiarParametros();

                    //datos.setearConsulta("INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                    //                     "VALUES (@Documento, @NombreCliente, @ApellidoCliente, @CorreoCliente, @Direccion, @Ciudad, @Cp)");

                    //datos.setearParametro("@Documento", cliente.Documento);
                    //datos.setearParametro("@NombreCliente", cliente.NombreCliente);
                    //datos.setearParametro("@ApellidoCliente", cliente.ApellidoCliente);
                    //datos.setearParametro("@CorreoCliente", cliente.CorreoCliente);
                    //datos.setearParametro("@Direccion", cliente.Direccion);
                    //datos.setearParametro("@Ciudad", cliente.Ciudad);
                    //datos.setearParametro("@Cp", cliente.Cp);

                    //datos.ejecutarAccion();
                    //lblMensajeDNIencontrado.Text = "";
                    //lblMensajeDNINuevo.Text = "Cliente registrado exitosamente.";
                    //dniText.Text = "";
                    //nombre.Text = "";
                    //apellido.Text = "";
                    //email.Text = "";
                    //direccion.Text = "";
                    //ciudad.Text = "";
                    //codigoPostal.Text = "";

                    //datos.cerrarConexion();
                    //datos.limpiarParametros();

                    //datos.setearConsulta("SELECT Id FROM Clientes WHERE Documento = @Documento");
                    //datos.setearParametro("@Documento", cliente.Documento);
                    //datos.ejecutarLectura();

                    //if (datos.Lector.Read())
                    //{
                    //    cliente.ClienteId = (int)datos.Lector["Id"];
                    //}

                }

            }
            catch(Exception ex) 
            {
                Response.Write("Error: " + ex.Message);

            }
        }
    }
}