using System.IdentityModel.Tokens.Jwt;
using System.Linq;


namespace WebCalculadora.Tools
{
    public class DecodedToken
    {
        public int Decoded(string token)
        {
            try
            {
                string id;
                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(token);

                id = decodedValue.Claims.First().Value;
                //name = decodedValue.Claims.ToList()[1].Value;

                return int.Parse(id);
            }
            catch (Exception ex)
            {
                return 0;
            }
        
        }        
    }
}
