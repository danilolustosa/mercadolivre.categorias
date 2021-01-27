using MercadoLivreCategorias.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace MercadoLivreCategorias.Repository
{
    public class MercadoLivreRepository
    {
        public List<RootCategory> RootCategories()
        {
            var client = new RestClient("https://api.mercadolibre.com/sites/MLB/categories");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<RootCategory>>(response.Content);
        }

        public Category Category(string codigo)
        {
            var client = new RestClient($"https://api.mercadolibre.com/categories/{codigo}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<Category>(response.Content);
        }

    }
}
