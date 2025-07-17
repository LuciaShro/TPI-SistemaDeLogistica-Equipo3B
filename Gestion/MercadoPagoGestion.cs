using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MercadoPago.Client.Preference; 
using MercadoPago.Config; 
using MercadoPago.Resource.Preference;

namespace Gestion
{
    public class MercadoPagoGestion
    {
        private PreferenceRequest request;

        private List<PreferenceItemRequest> listaPreferenceItemRequest;

        private Preference preference;

        private PreferenceClient client;

        private string success; 
        
        private string failure; 
        
        private string pending;

        public Preference Preferencia
        {
            get { return preference; }
        }

        public MercadoPagoGestion(string urlBase) {

            MercadoPagoConfig.AccessToken = ConfigurationManager.AppSettings["MERCADO_PAGO_TOKEN"];

            string baseUrl = urlBase.TrimEnd('/').Replace("http://", "https://");

            // se agrega el reemplazo de http por https para las url de regreso
            success = baseUrl + "/PurchaseConfirmation.aspx";
            failure = baseUrl + "/PurchaseFailure.aspx";
            pending = baseUrl + "/PurchasePending.aspx";
        
        }

        public string PagarMercadoPago(string descripcion, decimal total)
        {
            try
            {
                listaPreferenceItemRequest = new List<PreferenceItemRequest>
        {
            new PreferenceItemRequest
            {
                Title = descripcion,
                Quantity = 1,
                CurrencyId = "ARS",
                UnitPrice = total
            }
        };

                CrearPreferenceRequest();

                client = new PreferenceClient();
                preference = client.Create(request);
                return preference.SandboxInitPoint;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Pagar con Mercado Pago", ex);
            }
        }


        private void CrearPreferenceRequest()
        {
            //Armamos la referencia externa que se envía a Mercado Pago. 
            //Acá lo ideal sería que sea un Id de compra interno de nuestro sistema, ya que en otro escenario 
            //vamos a querer identificar a qué operación pertenece determinado pago.
            string externalReference = string.Concat("Compra-", DateTime.Now);
            request = new PreferenceRequest
            {
                Items = listaPreferenceItemRequest,
                BackUrls = new PreferenceBackUrlsRequest
                {
                    Success = success,
                    Failure = failure,
                    Pending = pending
                },
                AutoReturn = "approved",
                ExternalReference = externalReference

            };

        }



    }
}
