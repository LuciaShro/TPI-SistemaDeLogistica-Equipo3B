using Dominio;
using Gestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPI_SistemaLogistica_Equipo3B
{
    public partial class AgregarVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo();
            GestionVehiculo gestionVehiculo = new GestionVehiculo();


            if (string.IsNullOrWhiteSpace(txtPatente.Text))
            {
                lblMensajePantalla.Text = "La patente debe ser indicada para guardar el vehiculo";
                return;
            }

            if(txtCapacidadCarga.Text == null)
            {
                lblMensajePantalla.Text = "La capacidad de carga debe ser completada";
                return;
            }

            try
            {
                vehiculo.Patente = txtPatente.Text;
                vehiculo.CapacidadCarga = float.Parse(txtCapacidadCarga.Text); 

                if(vehiculo.CapacidadCarga <= 0)
                {
                    lblMensajePantalla.Text = "La capacidad de carga debe ser un número mayor a 0";
                    return;
                }
            }
            catch (FormatException)
            {
                lblMensajePantalla.Text = "La capacidad de carga debe ser un número válido.";
                return;
            }

            gestionVehiculo.agregarVehiculo(vehiculo);
            lblMensajePantalla.Text = "Vehiculo guardado exitosamente";
            
        }
    }
}