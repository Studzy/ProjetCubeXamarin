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
    public class ConsultationService : BaseService
    {
        public async Task<RechercheRessource> GetSearch(string recherche)
        {
            RechercheRessource ressource = null;
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("api/ConsultationAPI/Search?recherche=" + recherche);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ressource = JsonConvert.DeserializeObject<BaseResponse<RechercheRessource>>(content).Data;
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
