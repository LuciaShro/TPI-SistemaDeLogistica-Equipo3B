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