using System.Collections.Generic;
using Newtonsoft.Json;
using WebCalculadora.Models;

namespace WebCalculadora.Services
{
    public class PlanillaCabeceraBD
    {
        private HttpClient? client;
        private Reply? oR;

        public PlanillaCabeceraBD()
        {
            client = new();
            oR = new();
        }
        public async Task<int> POSTAsync(PlanillaCabecera model)
        {
            
            string url = "http://lanota.ddns.net/api/Planilla_Cabecera/CreatePlanilla";

            var request = new { Nombre_tabla = model.Nombre_tabla, Campos_Json = model.Campos_Json, user_id = model.User_id };

            HttpResponseMessage response = await client.PostAsJsonAsync(url, request);

            string responseBody = await response.Content.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(responseBody);            

            if(oR.result == 1)            
                return 1;                      
            return 0;
        }

        public async Task<List<string>> GET_NamesAsync(int user_id)
        {
            string url = "http://lanota.ddns.net/api/Planilla_Cabecera/GetNames/" + user_id;

            HttpResponseMessage response = await client.GetAsync(url);

            string respuesta = response.Content.ReadAsStringAsync().Result;

            oR = JsonConvert.DeserializeObject<Reply>(respuesta);

            var data =  oR.data;

            List<string> ls = JsonConvert.DeserializeObject<List<string>>(data.ToString());

            return ls;
        }

        public async Task<string> GetNamePlanillaById(int id)
        {
            string url = "http://lanota.ddns.net/api/Planilla_Cabecera/GetNamePlanillaByid/" + id;

            HttpResponseMessage response = await client.GetAsync(url);

            string result = await response.Content?.ReadAsStringAsync();

            oR = JsonConvert.DeserializeObject<Reply>(result);

            string? name = oR.data?.ToString();

            return name;
        }

        public async Task<PlanillaCabecera> GetColumnsByNameTable(int user_id,string selectedid)
        {
            string url = "http://lanota.ddns.net/api/Planilla_Cabecera/GetColumnsByNameTable/" + user_id + "/" + selectedid;

            HttpResponseMessage response = await client.GetAsync(url);

            string respuestajson = response.Content.ReadAsStringAsync().Result;

            oR = JsonConvert.DeserializeObject<Reply>(respuestajson);

            var data = oR.data;

            PlanillaCabecera? cabecera = JsonConvert.DeserializeObject<PlanillaCabecera>(data.ToString());

            return cabecera;
        }
    }
}
