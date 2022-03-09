using System.Collections.Generic;
using Newtonsoft.Json;
using WebCalculadora.Models;

namespace WebCalculadora.Services
{
    public class PlanillaCabeceraBD
    {
        public async Task<int> POSTAsync(PlanillaCabecera model)
        {
            
            string url = "https://localhost:7057/api/Planilla_Cabecera/CreatePlanilla";
            Reply? oR = new Reply();
            HttpClient client = new HttpClient();
            
            var request = new { Nombre_tabla = model.Nombre_tabla, Campos_Json = model.Campos_Json, user_id = model.User_id };

            HttpResponseMessage response = await client.PostAsJsonAsync(url, request);

            string responseBody = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(responseBody);            

            if(oR.result == 1)            
                return 1;                      
            return 0;
        }

        public async Task<List<PlanillaCabecera>> GETAsync(int user_id, string planilla_name)
        {
            string url = "https://localhost:7057/api/Planilla_Cabecera/GetCabecera" + user_id;
            Reply? oR = new Reply();
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.PostAsJsonAsync(url,planilla_name);

            string respuesta = response.Content.ReadAsStringAsync().Result;

            oR = JsonConvert.DeserializeObject<Reply>(respuesta);

            var data =  oR.data;

            List<PlanillaCabecera> ls = JsonConvert.DeserializeObject<List<PlanillaCabecera>>((string)data);
            
            return ls;
        }
    }
}
