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

        public async Task<bool> AjouterFavoris(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/AjouterFavoris?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> SupprimerFavoris(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/SupprimerFavoris?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> AjouterMettreDeCote(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/AjouterMettreDeCote?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> SupprimerMettreDeCote(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/SupprimerMettreDeCote?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> AjouterExploite(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/AjouterExploite?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<bool> SupprimerExploite(int ressourcedId)
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync($"api/RessourceAPI/SupprimerExploite?ressourceId={ressourcedId}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return false;
        }

        public async Task<CommentairesModel> PosterCommentaire(object data)
        {
            CommentairesModel commentaires = null;

            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await HttpClient.PostAsync("api/CommentaireAPI/AjouterCommentaire", content);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    commentaires = JsonConvert.DeserializeObject<BaseResponse<CommentairesModel>>(result).Data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return commentaires;
        }
    }
}
