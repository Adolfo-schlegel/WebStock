using System.Net;
using Nancy.Json;
using Newtonsoft.Json;

namespace WebCalculadora.DataBase
{
    public class LoginBD
    {
        //get para mandar los datos y compararlos return okey

        public bool ValidateUser(Models.UserLogin user, string method = "POST")
        {
            try
            {
                string url = "http://lanota.ddns.net/api/login";
                string result = "";
                var response = new { Email = user.Email1, Password = user.Password1 };

                JavaScriptSerializer js = new JavaScriptSerializer();

                //serializamos el objeto
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(response);

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

                return Convert.ToBoolean(result);
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
