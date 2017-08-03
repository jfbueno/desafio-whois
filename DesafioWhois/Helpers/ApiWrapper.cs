using DesafioWhois.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioWhois.Helpers
{
    public static class ApiWrapper
    {
        private const string Key = "eafbcfe3994d98ab5bd94703ede7ed7d";
        private const string BaseUrl = "http://api.whoapi.com";
        
        public static async Task<Dominio> BuscarInformacoes(string dominio)
        {
            var clienteHttp = new HttpClient();
            var jsonString = await clienteHttp.GetStringAsync($"{BaseUrl}/?apikey={Key}&r=whois&domain={dominio}");

            var settings = new JsonSerializerSettings { ContractResolver = new JsonContractResolver() };
            var model = JsonConvert.DeserializeObject<Dominio>(jsonString, settings);

            return model;
        }
    }
}