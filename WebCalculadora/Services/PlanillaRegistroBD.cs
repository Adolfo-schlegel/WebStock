using Newtonsoft.Json;
using WebCalculadora.Models;

namespace WebCalculadora.Services
{
    public class PlanillaRegistroBD
    {
        List<PlanillaRegistros>? registros;
        HttpClient client;
        Reply? oR = new();
        public PlanillaRegistroBD()
        {
            client = new();
            oR = new();
            registros = new();
        }
        public async Task<List<PlanillaRegistros>> GetStockAsync(int cabecera_id)
        {
            string url = "https://localhost:7057/api/Planilla_Registros/GetStock/" + cabecera_id;

            HttpResponseMessage Response = await client.GetAsync(url);

            string result = await Response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            registros = JsonConvert.DeserializeObject<List<PlanillaRegistros>>(oR.data.ToString());//si el objeto no tiene nada, va a ser null y dar error
               
            return registros;
        }
    }
}
