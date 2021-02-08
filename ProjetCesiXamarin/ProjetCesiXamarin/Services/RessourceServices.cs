using Newtonsoft.Json;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCesiXamarin.Services
{
    public class RessourceServices
    {
        HttpClient _client;

        public RessourceServices()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// Appel l'API pour recuperer une ressource par son ID
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<RessourceData> GetRessourceByIdAsync(string uri)
        {
            RessourceData OpenWeatherData = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    OpenWeatherData = JsonConvert.DeserializeObject<RessourceData>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return OpenWeatherData;
        }
    }
}
