using Newtonsoft.Json;
using ProjetCesiXamarin.Constant;
using ProjetCesiXamarin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetCesiXamarin.Services
{
    public class AccountService : BaseService
    {
        /// <summary>
        /// Appel l'API pour s'inscrire
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<bool> Login(LoginData loginData)
        {
            bool result = false;
            string json = JsonConvert.SerializeObject(loginData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsync("api/Auth/Login", content);
                if (response.IsSuccessStatusCode)
                {
                    string resultat = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<LoginResponse>>(resultat);

                    await SecureStorage.SetAsync("token", data.Data.AccessToken);
                    await SecureStorage.SetAsync("expiration", data.Data.Expiration.Ticks.ToString());
                    await SecureStorage.SetAsync("username", data.Data.User.UserName);
                    await SecureStorage.SetAsync("user", JsonConvert.SerializeObject(data.Data.User));

                    result = true;
                }
                else
                {
                    result = false;
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
