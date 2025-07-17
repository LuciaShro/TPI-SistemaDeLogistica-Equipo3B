using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;


namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class Inicio : System.Web.UI.Page
    {

        public string etiquetasJson;
        public string valoresJson;
        public string provinciasJson;
        public string cantidadesJson;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    List<string> etiquetas = new List<string>();
                    List<int> valores = new List<int>();

                    string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["flashship"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT MedioDePago, COUNT(*) AS Cantidad FROM FormaDePago GROUP BY MedioDePago;";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            etiquetas.Add(reader["MedioDePago"].ToString());
                            valores.Add(Convert.ToInt32(reader["Cantidad"]));
                        }
                    }

                    etiquetasJson = JsonConvert.SerializeObject(etiquetas);
                    valoresJson = JsonConvert.SerializeObject(valores);

                    List<string> provincias = new List<string>();
                    List<int> cantidades = new List<int>();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string queryProvincias = "SELECT  TOP 5 dire.Provincia, COUNT(*) AS Cantidad FROM Direccion as dire inner join Destinatarios as d ON d.IDDirección = dire.IDDireccion WHERE dire.Provincia <> 'Ciudad Autónoma de Buenos Aires' group by dire.Provincia ORDER BY Cantidad DESC;";
                        SqlCommand cmd = new SqlCommand(queryProvincias, con);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            provincias.Add(reader["Provincia"].ToString());
                            cantidades.Add(Convert.ToInt32(reader["Cantidad"]));
                        }
                    }

                    provinciasJson = JsonConvert.SerializeObject(provincias);
                    cantidadesJson = JsonConvert.SerializeObject(cantidades);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}