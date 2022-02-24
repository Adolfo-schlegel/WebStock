using Newtonsoft.Json;
using WebCalculadora.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebCalculadora.Services
{
    public class UserStockBD
    {
        HttpClient client = new HttpClient();
        public async Task<List<UserStock>> Get_stock(User model)
        {
            Reply? oR = new Reply();

            string url = "http://lanota.ddns.net/api/UserStock/stock";

            HttpResponseMessage response = await client.PostAsJsonAsync(url, model);//debo mandar el token en el handler

            string respuesta = await response.Content.ReadAsStringAsync();

            oR  = JsonConvert.DeserializeObject<Reply>(respuesta);

            var stock = oR.data;

            List<UserStock> objs = JsonConvert.DeserializeObject<List<UserStock>>(stock.ToString());
            
            return objs;
        }

        public async Task<Reply> SetStockAsync(UserStock model)
        {
            Reply oR = new Reply();
            
            try
            {
                string url = "http://lanota.ddns.net/api/UserStock/AddStock";

                HttpResponseMessage response = await client.PostAsJsonAsync(url, model);
                string respuesta = await response.Content.ReadAsStringAsync();

                oR = JsonConvert.DeserializeObject<Reply>(respuesta);

                return oR;

            }
            catch(Exception)
            {
                oR.result = 0;
                oR.message = "Error, en la peticion HttpClient";
            }

            return oR;
        }

        public async Task<Reply> ModifyStock(UserStock model)
        {
            Reply oR = new Reply();

            try
            {
                string url = "http://lanota.ddns.net/api/UserStock/ModifyStock";

                HttpResponseMessage response = await client.PutAsJsonAsync(url, model);//debo mandar el token en el handler

                string respuesta = await response.Content.ReadAsStringAsync();

                oR = JsonConvert.DeserializeObject<Reply>(respuesta);

            }
            catch (Exception)
            {

            }

            return oR;
        }

        public async Task<UserStock> ReadIdAsync(int id)
        {
            Reply oR = new Reply();

            try
            {
                string url = "http://lanota.ddns.net/api/UserStock/GetStockById/" + id;

                HttpResponseMessage response = await client.GetAsync(url);

                string respuesta = response.Content.ReadAsStringAsync().Result;

                oR = JsonConvert.DeserializeObject<Reply>(respuesta);

                var stock = oR.data;

                List<UserStock>? ls = JsonConvert.DeserializeObject<List<UserStock>>(stock.ToString());

                return ls[0];
            }
            catch (Exception)
            {
                return null;
            }
        }


        public async Task<Reply> Delete(int id)
        {
            Reply oR = new Reply();

            try
            {
                string url = "http://lanota.ddns.net/api/UserStock/DeleteStock/" + id;

                HttpResponseMessage response = await client.DeleteAsync(url);
                string respuesta = await response.Content.ReadAsStringAsync();

                oR = JsonConvert.DeserializeObject<Reply>(respuesta);

                return oR;
            }
            catch (Exception)
            {
                return null;
            }

            return oR;
        }
    }
}
