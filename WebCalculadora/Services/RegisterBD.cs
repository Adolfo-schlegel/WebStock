using System.Net;
using Nancy.Json;

namespace WebCalculadora.DataBase
{
    public class RegisterBD
    {
        public async Task<int> PostUser(Models.UserRegister register, string method = "POST")
        {
            try
            {
                string url = "http://lanota.ddns.net/api/register";
                var req = new { Email = register.Email1, Password = register.Password1 };

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.PostAsJsonAsync(url, req);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                return int.Parse(responseBody);
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
