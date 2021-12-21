using MySql.Data.MySqlClient;


namespace WebCalculadora.DataBase
{
    public class Connection
    {
        public MySqlConnection Conectar()
        {
            try
            {
                string ConnectionString = "Database = stock_eet2; Data Source = localhost; Port = 3306; user id = root; password = 10deagosto";
                MySqlConnection conectar = new MySqlConnection(ConnectionString);
                conectar.Open();
                return conectar;
            }
            catch (Exception ex)
            {              
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
