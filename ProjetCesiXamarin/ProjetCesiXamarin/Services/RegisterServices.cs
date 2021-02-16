﻿using Newtonsoft.Json;
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
        public async Task<bool> Register(string uri, RegisterData registerData)
        {
            bool result = false;
            string json = JsonConvert.SerializeObject(registerData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                HttpResponseMessage response = await HttpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    string resultat = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<LoginResponse>>(resultat);
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
