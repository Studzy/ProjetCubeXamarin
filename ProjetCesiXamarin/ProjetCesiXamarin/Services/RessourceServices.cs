using Newtonsoft.Json;
using ProjetCesiXamarin.Constant;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetCesiXamarin.Services
{
    public class RessourceServices : BaseService
    {
        /// <summary>
        /// Appel l'API pour recuperer une ressource par son ID
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<RessourceData> GetRessourceByIdAsync(int id)
        {
            RessourceData ressource = null;
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("api/RessourceAPI/" + id);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ressource = JsonConvert.DeserializeObject<BaseResponse<RessourceData>>(content).Data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return ressource;
        }
    }
}
