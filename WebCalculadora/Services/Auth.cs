using System.Net;
using Nancy.Json;
using Newtonsoft.Json;
using System.Text.Json;
using WebCalculadora.Models;
namespace WebCalculadora.Services
{
    public class Auth
    {
        public HttpClient client = new HttpClient();
        public Reply? reply = new Reply();
        public async Task<Reply> AuthUser(UserLogin user)
        {
            try
            {
                string url = "http://lanota.ddns.net/api/Login/Auth";

                var response = new { Email = user.Email1, Password = user.Password1 };

                HttpResponseMessage request = await client.PostAsJsonAsync(url, response);

                string resultContent = await request.Content.ReadAsStringAsync();

                reply = JsonConvert.DeserializeObject<Reply>(resultContent);

                request.EnsureSuccessStatusCode();                

                return reply;
            }
            catch(Exception ex)
            {
                reply.result = 0;
                return reply;
            }

        }
    }
}
