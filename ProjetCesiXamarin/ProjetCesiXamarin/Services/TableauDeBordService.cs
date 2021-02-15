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
        public async Task<TableauDeBordData> GetRessourcesFavorites()
        {
            TableauDeBordData result = null;

            try
            {
                string param = "?NomVue=favoris";
                HttpResponseMessage response = await HttpClient.GetAsync("api/TableauDeBordApi"+param);

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

        public async Task<TableauDeBordData> GetRessourcesExploite()
        {
            TableauDeBordData result = null;

            try
            {
                string param = "?NomVue=exploitee";
                HttpResponseMessage response = await HttpClient.GetAsync("api/TableauDeBordApi" + param);

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

        public async Task<TableauDeBordData> GetRessourcesMisCote()
        {
            TableauDeBordData result = null;

            try
            {
                string param = "?NomVue=miscote";
                HttpResponseMessage response = await HttpClient.GetAsync("api/TableauDeBordApi" + param);

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

        public async Task<TableauDeBordData> GetRessourcesCrees()
        {
            TableauDeBordData result = null;

            try
            {
                string param = "?NomVue=crees";
                HttpResponseMessage response = await HttpClient.GetAsync("api/TableauDeBordApi" + param);

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
