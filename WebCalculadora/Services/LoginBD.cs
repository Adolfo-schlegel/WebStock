using System.Net;
using Nancy.Json;
using Newtonsoft.Json;
using System.Text.Json;

namespace WebCalculadora.DataBase
{
    public class LoginBD
    {
        public HttpClient client = new HttpClient();

        public async Task<int> ValidateUserAsync(Models.UserLogin user, string method = "POST")
        {
            try
            {
                string url = "http://lanota.ddns.net/api/login";

                var response = new { Email = user.Email1, Password = user.Password1 };

                HttpResponseMessage request = await client.PostAsJsonAsync(url, response);

                string resultContent = await request.Content.ReadAsStringAsync();

                request.EnsureSuccessStatusCode();

                return  int.Parse(resultContent);
            }
            catch(Exception ex)
            {
                return 0;
            }

        }
    }
}
