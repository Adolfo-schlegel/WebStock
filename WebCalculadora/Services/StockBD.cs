using System.Net;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;
using Nancy.Json;
using System.Collections.Generic;

namespace WebCalculadora.DataBase
{
    public class StockBD
    {
        public static HttpClient client = new HttpClient();

        public async Task<List<Models.Stock>> Read()
        {
            string url = "http://lanota.ddns.net/api/Stock";

            HttpResponseMessage response = await client.GetAsync(url);

            string respuesta = await response.Content.ReadAsStringAsync();

            List<Models.Stock>? ls = JsonConvert.DeserializeObject<List<Models.Stock>>(respuesta);

            return ls;
        }

        public async Task<string> Set(Models.Stock oStock)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("http://lanota.ddns.net/api/Stock", oStock);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        public async Task<string> Delete(int id, string method = "Delete")
        {
           HttpResponseMessage response = await client.DeleteAsync("http://lanota.ddns.net/api/Stock/" + id);

           response.EnsureSuccessStatusCode();
           string responseBody = await response.Content.ReadAsStringAsync();

           return responseBody;           
        }

        public async Task<string> Put(Models.Stock oStock)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PutAsJsonAsync("http://lanota.ddns.net/api/Stock", oStock);

            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }

        public async Task<Models.Stock> Read_id(int id)
        {
            string url = "http://lanota.ddns.net/api/Stock/" + id;
            HttpResponseMessage response = await client.GetAsync(url);

            string resultContent = response.Content.ReadAsStringAsync().Result;

            List<Models.Stock>? ls = JsonConvert.DeserializeObject<List<Models.Stock>>(resultContent);

            response.EnsureSuccessStatusCode();
            return ls[0];   
        }
    }
}
