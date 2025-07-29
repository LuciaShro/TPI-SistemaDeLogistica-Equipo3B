using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Gestion;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class HistorialEnviosCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarEnvios();
            }
        }

        private void cargarEnvios()
        {
            List<Envio> lista = new List<Envio>();
            AccesoDatos datos = new AccesoDatos();

            if (Session["cliente"] != null)
            {
                Cliente cliente = (Cliente)Session["cliente"];
                int idCliente = cliente.id;

                try
                {
                    datos.setearConsulta("SELECT oe.IDOrden, oe.FechaEnvio, estadoOE.Descripcion as estadoEnvio FROM OrdenesEnvio as oe INNER JOIN EstadoOrdenesEnvio as estadoOE ON estadoOE.IDEstadoOrdenEnvio = oe.IDEstadoOrdenEnvio INNER JOIN Clientes as c ON c.IDCliente = oe.IDCliente WHERE oe.IDCliente = @IDCliente ORDER BY oe.IDORDEN DESC");
                    datos.setearParametro("@IDCliente", idCliente);
                    datos.ejecutarLectura();

                    /* while (datos.Lector.Read())
                     {
                         Envio envio = new Envio();

                         envio.Codigo = (int)datos.Lector["IDOrden"];
                         envio.FechaEnvio = Convert.ToDateTime(datos.Lector["FechaEnvio"]);
                         envio.NombreEstado = datos.Lector["EstadoEnvio"].ToString();
                         envio.ColorEstado = GetColorPorEstado(envio.NombreEstado);
                         envio.DetalleEstado = GetDetallePorEstado(envio.NombreEstado);
                         lista.Add(envio);
                     }*/

                    while (datos.Lector.Read())
                    {
                        Envio envio = new Envio();

                        envio.Codigo = (int)datos.Lector["IDOrden"];
                        envio.FechaEnvio = datos.Lector["FechaEnvio"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(datos.Lector["FechaEnvio"]);

                        envio.NombreEstado = datos.Lector["estadoEnvio"].ToString();
                        envio.ColorEstado = GetColorPorEstado(envio.NombreEstado);
                        envio.DetalleEstado = GetDetallePorEstado(envio.NombreEstado);

                        lista.Add(envio);
                    }

                    //lblDebug.Text = "IDCliente actual: " + idCliente;
                    rptEnvios.DataSource = lista;
                    rptEnvios.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        public string GetColorPorEstado(string estado)
        {
            switch (estado.ToLower())
            {
                case "pendiente":
                    return "#f3ed7b"; // rosa fuerte
                case "en transito":
                    return "#cce5ff"; // rosa claro
                case "entregado":
                    return "#d1ecf1"; // azul
                case "reprogramado":
                    return "#f1b513"; // amarillo
                case "demorado":
                    return "#da3434f4"; // verde
                case "cancelado":
                      return "#b44949";
                default:
                    return "#ccc"; // gris neutro
            }
        }

        public string GetDetallePorEstado(string estado)
        {
            switch (estado.ToLower())
            {
                case "en transito":
                    return "Pieza en viaje";
                case "entregado":
                    return "La pieza llego a destino";
                case "pendiente":
                    return "Pendiente de envio";
                case "reprogramado":
                    return "El envio ha sido reprogramado";
                case "demorado":
                    return "El envio se encuentra demorado";
                case "cancelado":
                    return "El envio fue cancelado";
                default:
                    return "Estado desconocido";
            }
        }

    }
}