using Newtonsoft.Json;
using WebCalculadora.Models;

namespace WebCalculadora.Services
{
    public class PlanillaRegistroBD
    {
        List<PlanillaRegistros>? registros;
        HttpClient client;
        Reply? oR = new();
        string url = "http://lanota.ddns.net/api/Planilla_Registros/";
        public PlanillaRegistroBD()
        {
            client = new();
            oR = new();
            registros = new();
        }
        public async Task<List<PlanillaRegistros>> GetStockAsync(int cabecera_id)
        {
            url += "GetStock/" + cabecera_id;

            HttpResponseMessage Response = await client.GetAsync(url);

            string result = await Response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            registros = JsonConvert.DeserializeObject<List<PlanillaRegistros>>(oR.data.ToString());
               
            return registros;
        }
        public async Task<List<string>> GetStockItemAsync(int? id)
        {
            url += "GetStockItem/" + id;

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            string result = await responseMessage.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            List<string> lstItem =JsonConvert.DeserializeObject<List<string>>(oR.data.ToString());

            return lstItem;
        }
        public async Task<int> PostStockAsync(PlanillaRegistros model)
        {
            url += "PostStock";

            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }

        public async Task<int> DeleteStockByIdAsync(int id)
        {
            url += "DeleteStockById/" + id;

            HttpResponseMessage response = await client.DeleteAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }

        public async Task<List<string>> ModifyStockByAsync(PlanillaRegistros model)
        {
            return null;
        }
    }
}
