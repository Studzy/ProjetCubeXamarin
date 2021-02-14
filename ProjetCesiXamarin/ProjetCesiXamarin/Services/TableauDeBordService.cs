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
    public class TableauDeBordService : BaseService
    {
        public async Task<TableauDeBordData> GetRessourcesFavorites(TableauDeBordData tableauDeBordData)
        {
            TableauDeBordData result = null;

            try
            {
                string param = "?NomVue=" + tableauDeBordData.NomVue;
                HttpResponseMessage response = await HttpClient.GetAsync("api/AccueilAPI/TableauDeBord"+param);

                if (response.IsSuccessStatusCode)
                {
                    string resultat = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<BaseResponse<TableauDeBordData>>(resultat).Data;
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
