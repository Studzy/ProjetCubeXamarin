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
    public class CreationService : BaseService
    {
        public async Task<CreationData> GetBaseInfo()
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync("api/CreateArticleAPI/GetBaseInfos");
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<BaseResponse<CreationData>>(content).Data;
                    return data;
                }

            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }
    }
}
