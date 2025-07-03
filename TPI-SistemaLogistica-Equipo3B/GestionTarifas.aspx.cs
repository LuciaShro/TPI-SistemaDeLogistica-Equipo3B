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
    public partial class GestionTarifas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GestionTarifasEnvio gestion = new GestionTarifasEnvio();

                var tarifaPequeno = gestion.listarTarifasEnvioCategoriaPequeño().FirstOrDefault();
                var tarifaMediano = gestion.listarTarifasEnvioCategoriaMediano().FirstOrDefault();
                var tarifaGrande = gestion.listarTarifasEnvioCategoriaGrande().FirstOrDefault();

                
                lblCategoriaPequeño.Text = tarifaPequeno != null ? tarifaPequeno.PrecioPorKm.ToString("N2") : "0.00";
                lblCategoriaMediano.Text = tarifaMediano != null ? tarifaMediano.PrecioPorKm.ToString("N2") : "0.00";
                lblCategoriaGrande.Text = tarifaGrande != null ? tarifaGrande.PrecioPorKm.ToString("N2") : "0.00";

                
                Session["tarifaPequeno"] = tarifaPequeno;
                Session["tarifaMediano"] = tarifaMediano;
                Session["tarifaGrande"] = tarifaGrande;
            }
            

        }

        protected void btnGuardarGrande_Click(object sender, EventArgs e)
        {
            GestionTarifasEnvio tarifas = new GestionTarifasEnvio();
            TarifasEnvio tarifasEnvio = new TarifasEnvio();

            decimal nuevoPrecio;
            if (decimal.TryParse(txtCategoriaPequeno.Text, out nuevoPrecio))
            {
                if (nuevoPrecio > 0)
                {
                    tarifasEnvio.PrecioPorKm = nuevoPrecio;
                    tarifas.actualizarPrecioCategoriaGrande(tarifasEnvio);
                    Response.Redirect("GestionTarifas.aspx", false);
                }
                else
                {
                    lblMensajeError.Text = "Para continuar debe insertar un número mayor a 0";
                    lblMensajeError.Visible = true;
                }
            }
        }

        protected void btnGuardarMediano_Click(object sender, EventArgs e)
        {
            GestionTarifasEnvio tarifas = new GestionTarifasEnvio();
            TarifasEnvio tarifasEnvio = new TarifasEnvio();

            decimal nuevoPrecio;
            if (decimal.TryParse(txtCategoriaPequeno.Text, out nuevoPrecio))
            {
                if (nuevoPrecio > 0)
                {
                    tarifasEnvio.PrecioPorKm = nuevoPrecio;
                    tarifas.actualizarPrecioCategoriaMediano(tarifasEnvio);
                    Response.Redirect("GestionTarifas.aspx", false);
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = "Para continuar debe insertar un número mayor a 0";
                }
            }
        }

        protected void btnGuardarPequeno_Click(object sender, EventArgs e)
        {
            GestionTarifasEnvio tarifas = new GestionTarifasEnvio();
            TarifasEnvio tarifasEnvio = new TarifasEnvio();

            decimal nuevoPrecio;
            if (decimal.TryParse(txtCategoriaPequeno.Text, out nuevoPrecio))
            {
                if (nuevoPrecio > 0)
                {
                    tarifasEnvio.PrecioPorKm = nuevoPrecio;
                    tarifas.actualizarPrecioCategoriaPequeño(tarifasEnvio);
                    Response.Redirect("GestionTarifas.aspx", false);
                }
                else
                {
                    lblMensajeError.Visible = true;
                    lblMensajeError.Text = "Para continuar debe insertar un número mayor a 0";
                }
            }
        }

        protected void btnModificarPequeno_Click(object sender, EventArgs e)
        {
            txtCategoriaPequeno.Visible = true;
            btnGuardarPequeno.Visible = true;

        }

        protected void btnModificarMediano_Click(object sender, EventArgs e)
        {
            txtCategoriaMediano.Visible = true;
            btnGuardarMediano.Visible = true;
        }

        protected void btnModificarGrande_Click(object sender, EventArgs e)
        {
            txtCategoriaGrande.Visible = true;  
            btnGuardarGrande.Visible=true;
        }
    }
}