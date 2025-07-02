using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Globalization;

namespace TPI_SistemaLogistica_Equipo3B.Servicios
{
    public class MapBoxService
    {
        private readonly HttpClient _httpClient;
        private readonly string _mapboxAccessToken;

        // Constructor para inicializar el HttpClient y el token de acceso
        public MapBoxService(string mapboxAccessToken)
        {
            _httpClient = new HttpClient();
            _mapboxAccessToken = mapboxAccessToken;
        }


        public async Task<GeocodingResponse> GetCoordinatesFromAddress(string address)
        {
           
            string encodedAddress = Uri.EscapeDataString(address);

            
            string geocodingUrl = $"https://api.mapbox.com/geocoding/v5/mapbox.places/{encodedAddress}.json?access_token={_mapboxAccessToken}";

            Console.WriteLine($"[MapboxService] Solicitando URL de Geocodificación: {geocodingUrl}");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(geocodingUrl);
                string jsonResponse = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"[MapboxService] Respuesta de Geocodificación HTTP Status Code: {(int)response.StatusCode} - {response.ReasonPhrase}");
                Console.WriteLine($"[MapboxService] Respuesta de Geocodificación Body: {jsonResponse}");

                response.EnsureSuccessStatusCode(); 

                GeocodingResponse geoResponse = JsonConvert.DeserializeObject<GeocodingResponse>(jsonResponse);

                if (geoResponse == null)
                {
                    Console.WriteLine("[MapboxService] Deserialization of geocoding response resulted in null.");
                    return null;
                }

                if (geoResponse.Features == null || !geoResponse.Features.Any())
                {
                    Console.WriteLine($"[MapboxService] No features found for address: {address}. Message: {geoResponse.Message ?? "N/A"}");
                    return geoResponse; 
                }

                return geoResponse;
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"[MapboxService ERROR] HttpRequestException al geocodificar: {httpEx.Message}");
                return null;
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"[MapboxService ERROR] JsonException (Deserialization failed) al geocodificar: {jsonEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[MapboxService ERROR] Excepción inesperada al geocodificar: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Obtiene los datos de la ruta (distancia, duración, geometría) entre dos puntos.
        /// </summary>
        /// <param name="startLng">Longitud del punto de inicio.</param>
        /// <param name="startLat">Latitud del punto de inicio.</param>
        /// <param name="endLng">Longitud del punto final.</param>
        /// <param name="endLat">Latitud del punto final.</param>
        /// <param name="profile">Perfil de la ruta (por ejemplo, "mapbox/driving", "mapbox/walking").</param>
        /// <returns>Un objeto MapboxDirectionsResponse que contiene los detalles de la ruta, o null si hay un error.</returns>
        public async Task<MapboxDirectionsResponse> GetRouteData(
            double startLng, double startLat,
            double endLng, double endLat,
         string profile = "mapbox/driving")
        {
            string coordinates = $"{startLng.ToString(CultureInfo.InvariantCulture)},{startLat.ToString(CultureInfo.InvariantCulture)};{endLng.ToString(CultureInfo.InvariantCulture)},{endLat.ToString(CultureInfo.InvariantCulture)}";
            string url = $"https://api.mapbox.com/directions/v5/{profile}/{coordinates}?geometries=geojson&steps=false&alternatives=false&overview=full&access_token={_mapboxAccessToken}";


            Console.WriteLine($"[MapboxService] Solicitando URL: {url}");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                string responseBody = await response.Content.ReadAsStringAsync();

                
                Console.WriteLine($"[MapboxService] HTTP Status Code: {(int)response.StatusCode} - {response.ReasonPhrase}");

                Console.WriteLine($"[MapboxService] Response Body: {responseBody}");

                response.EnsureSuccessStatusCode(); 

                MapboxDirectionsResponse directionsResponse = JsonConvert.DeserializeObject<MapboxDirectionsResponse>(responseBody);

                if (directionsResponse == null)
                {
                    Console.WriteLine("[MapboxService] Deserialization resulted in null response.");
                    return null;
                }

               
                if (directionsResponse.Code != "Ok")
                {
                    Console.WriteLine($"[MapboxService] Mapbox API returned an error code: {directionsResponse.Code}. Message: {directionsResponse.Message ?? "N/A"}");
                    return null;
                }

                if (directionsResponse.Routes == null || directionsResponse.Routes.Count == 0)
                {
                    Console.WriteLine("[MapboxService] No routes found in Mapbox API response.");
                    return null;
                }

                return directionsResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"[MapboxService ERROR] HttpRequestException: {e.Message}");
                
                return null;
            }
            catch (JsonException e)
            {
                Console.WriteLine($"[MapboxService ERROR] JsonException (Deserialization failed): {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"[MapboxService ERROR] Unexpected Exception: {e.Message}");
                return null;
            }
        }
        

        public class MapboxDirectionsResponse
        {
            [JsonProperty("routes")]
            public List<Route> Routes { get; set; }

            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("waypoints")]
            public List<Waypoint> Waypoints { get; set; }

            
            [JsonProperty("message")]
            public string Message { get; set; }
        }

        public class Route
        {
            [JsonProperty("distance")]
            public double Distance { get; set; } // En metros

            [JsonProperty("duration")]
            public double Duration { get; set; } // En segundos

            [JsonProperty("geometry")]
            public Geometry Geometry { get; set; }

        }

        public class Geometry
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("coordinates")]
            public List<List<double>> Coordinates { get; set; } // Lista de [longitud, latitud]
        }

        public class Leg
        { 
            // [JsonProperty("summary")]
            // public string Summary { get; set; }
        }

        public class Waypoint
        {
            // [JsonProperty("name")]
            // public string Name { get; set; }
            // [JsonProperty("location")]
            // public List<double> Location { get; set; } // [longitude, latitude]
        }

        public class GeocodingResponse
        {
            [JsonProperty("features")]
            public List<Feature> Features { get; set; }

            [JsonProperty("message")] // Para errores de geocodificación
            public string Message { get; set; }
        }

        public class Feature
        {
            [JsonProperty("place_name")]
            public string Place_name { get; set; } // Nombre completo del lugar

            [JsonProperty("center")]
            public List<double> Center { get; set; } // [longitude, latitude]
        }



    }
}
