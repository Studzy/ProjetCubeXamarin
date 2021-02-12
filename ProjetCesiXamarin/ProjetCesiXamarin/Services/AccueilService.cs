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
    public class AccueilService : BaseService
    {
        public async Task<AccueilData> GetAccueilData()
        {
            AccueilData result = null;

            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("/AccueilAPI");

                if (response.IsSuccessStatusCode)
                {
                    string resultat = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<BaseResponse<AccueilData>>(resultat).Data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return result;
        }
    }
}
