using Calculo.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Calculo.Executor
{
    public class CalculaJurosExecutor : ICalculaJurosExecutor
    {
        static HttpClient client = new HttpClient();

        public double CalcularJuros(JurosCompostos jurosCompostos)
        {
            double valorJuros = RunAsync();
           
            return Math.Round(
                jurosCompostos.ValorInicial * (
                Math.Pow((Constantes.VALOR_UNICO + valorJuros), 
                jurosCompostos.Tempo)), 
                Constantes.CASAS_DECIMAIS);

           // return valorTruncado;
        }

        static double RunAsync()
        {
            double valorJuros;

            var client = new RestClient
            {
                BaseUrl = new Uri("https://localhost:44384/")
            };

            var req = new RestRequest(Constantes.URL, Method.GET);

            var response = client.Execute(req);

            valorJuros = JsonConvert.DeserializeObject<double>(response.Content);

            return valorJuros;
        }
    }
}
