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
    public class RegisterServices : BaseService
    {
        /// <summary>
        /// Appel l'API pour s'inscrire
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> Register(string uri, RegisterData registerData)
        {
            bool result = false;
            string message = null;
            string json = JsonConvert.SerializeObject(registerData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string resultat = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<LoginResponse>>(resultat);

                    if (data.StatusCode == 200)
                    {
                        result = true;
                    }
                    else
                    {
                        message = data.Message;
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                message = "Une erreur inconnue est surevenue.";
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return Tuple.Create(result, message);
        }
    }
}
