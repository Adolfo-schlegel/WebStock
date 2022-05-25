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
            string url = "http://serverapistock.ddns.net/api/Planilla_Registros/GetStock/" + cabecera_id;

            HttpResponseMessage Response = await client.GetAsync(url);

            string result = await Response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            registros = JsonConvert.DeserializeObject<List<PlanillaRegistros>>(oR.data.ToString());
               
            return registros;
        }
        public async Task<List<string>> GetStockItemAsync(int? id)
        {
            string url = "http://serverapistock.ddns.net/api/Planilla_Registros/GetStockItem/" + id;

            HttpResponseMessage responseMessage = await client.GetAsync(url);

            string result = await responseMessage.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            List<string> lstItem =JsonConvert.DeserializeObject<List<string>>(oR.data.ToString());

            return lstItem;
        }
        public async Task<int> PostStockAsync(PlanillaRegistros model)
        {
            string url = "http://serverapistock.ddns.net/api/Planilla_Registros/PostStock";

            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }

        public async Task<int> DeleteStockByIdAsync(int id)
        {
            string url = "http://serverapistock.ddns.net/api/Planilla_Registros/DeleteStockById/" + id;

            HttpResponseMessage response = await client.DeleteAsync(url);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }

        public async Task<int> ModifyStockAsync(PlanillaCabecera model)
        {
            string url = "https://localhost:7057/api/Planilla_Registros/UpdateStock";

            HttpResponseMessage response = await client.PutAsJsonAsync(url,model);

            string result = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            return oR.result;
        }
    }
}
