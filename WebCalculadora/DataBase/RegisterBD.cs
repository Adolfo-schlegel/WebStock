namespace WebCalculadora.DataBase
{
    public class RegisterBD
    {
        public string PostUser(string Correo, string Password, string password1)
        {
            if(Password == password1)
            {
                try
                {
                    return "logieado con exito";
                }
                catch(Exception)
                {
                    return "false";
                }
            }
            else
            {
                return "La contraseña no es correcta";
            }

            return "OK";
        }

        //.....
       
    }
}
