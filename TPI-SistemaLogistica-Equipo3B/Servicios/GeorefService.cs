using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TPI_SistemaLogistica_Equipo3B.Models;

namespace TPI_SistemaLogistica_Equipo3B.Servicios
{
    public class GeorefService
    {
        private readonly HttpClient _httpClient;

        public GeorefService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Provincia>> ObtenerProvinciasAsync()
        {
            var response = await _httpClient
            .GetStringAsync("https://apis.datos.gob.ar/georef/api/provincias")
            .ConfigureAwait(false);

            var data = JsonConvert.DeserializeObject<ProvinciasResponse>(response);
            return data?.provincias ?? new List<Provincia>();


            //var response = await _httpClient.GetStringAsync("https://apis.datos.gob.ar/georef/api/provincias");
            //var data = JsonConvert.DeserializeObject<ProvinciasResponse>(response);
            //return data?.provincias ?? new List<Provincia>();
        }

        public async Task<List<Localidad>> ObtenerLocalidadesPorProvinciaAsync(string nombreProvincia)
        {
            var url = $"https://apis.datos.gob.ar/georef/api/localidades?provincia={nombreProvincia}&max=1000";

            var response = await _httpClient
                .GetStringAsync(url)
                .ConfigureAwait(false);

            var data = JsonConvert.DeserializeObject<LocalidadesResponse>(response);
            return data?.localidades ?? new List<Localidad>();

            //var url = $"https://apis.datos.gob.ar/georef/api/localidades?provincia={nombreProvincia}&max=1000";
            //var response = await _httpClient.GetStringAsync(url);
            //var data = JsonConvert.DeserializeObject<LocalidadesResponse>(response);
            //return data?.localidades ?? new List<Localidad>();
        }
    }
}