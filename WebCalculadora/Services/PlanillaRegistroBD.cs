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
            string url = "http://lanota.ddns.net/api/Planilla_Registros/GetStock/" + cabecera_id;

            HttpResponseMessage Response = await client.GetAsync(url);

            string result = await Response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            registros = JsonConvert.DeserializeObject<List<PlanillaRegistros>>(oR.data.ToString());
               
            return registros;
        }

        public async Task<int> PostStockAsync(PlanillaRegistros model)
        {
            string url = "http://lanota.ddns.net/api/Planilla_Registros/PostStock";

            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }
    }
}
