using ProjetCesiXamarin.Constant;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProjetCesiXamarin.Services
{
    public class BaseService
    {
        private HttpClient _httpClient;

        public HttpClient HttpClient 
        {
            get
            {
                if (_httpClient == null)
                {
                    _httpClient = new HttpClient
                    {
                        BaseAddress = new Uri(ApiProjetCesiConstants.ApiProjetCesiEndpoint)
                    };

                    string token = string.Empty;

                    Task.Factory.StartNew(new Func<Task>(async () =>
                    {
                        string expiration = await SecureStorage.GetAsync("expiration");

                        if (!string.IsNullOrEmpty(expiration))
                        {
                            if (new DateTime(long.Parse(expiration)) < DateTime.Now)
                            {
                                SecureStorage.Remove("token");
                                SecureStorage.Remove("expiration");
                                SecureStorage.Remove("username");
                                SecureStorage.Remove("user");
                            }
                            else
                            {
                                token = await SecureStorage.GetAsync("token");
                            }
                        }
                    }))
                        .Unwrap()
                        .Wait();

                    if (!string.IsNullOrEmpty(token))
                        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                return _httpClient;
            }
        }
    }
}
