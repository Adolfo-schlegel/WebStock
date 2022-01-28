using System.Net;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Text.Json;
using System.Web;
using Nancy.Json;

namespace WebCalculadora.DataBase
{
    public class StockBD : Connection
    {
        

        public async Task<List<Models.Stock>> Read()
        {
            string url = "http://lanota.ddns.net/api/values";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string respuesta = await reader.ReadToEndAsync();

            List<Models.Stock> ls = JsonConvert.DeserializeObject<List<Models.Stock>>(respuesta);

            return ls;
        }
        public string Set<T>(T objectRequest, string method = "POST")
        {
            string url = "http://lanota.ddns.net/api/values";
            string result = "";

            try
            {

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                //peticion
                WebRequest request = WebRequest.Create(url);

                //headers
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 10000; //tiempo en el que si no se manda nada, te tira un error controlado 

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }

                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                result = e.Message;

            }

            return result;
        }
    }
}
