using Calculo.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;

namespace Calculo.Executor
{
    public class CalculaJurosExecutor : ICalculaJurosExecutor
    {
        static HttpClient client = new HttpClient();

        public string CalcularJuros(JurosCompostos jurosCompostos)
        {
            double valorJuros = RunAsync();
           
            var valorResults = jurosCompostos.ValorInicial * (Math.Pow((Constantes.VALOR_UNICO + valorJuros),jurosCompostos.Tempo));

            return valorResults.ToString("#.##");
        }

        static double RunAsync()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(Constantes.URL_BASE)
            };

            RestRequest req = new RestRequest(Constantes.URL, Method.GET);

            IRestResponse response = client.Execute(req);

            return JsonConvert.DeserializeObject<double>(response.Content);             
        }
    }
}
