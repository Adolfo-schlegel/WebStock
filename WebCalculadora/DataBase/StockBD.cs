using MySql.Data.MySqlClient;

namespace WebCalculadora.DataBase
{
    public class StockBD : Connection
    {
        List<Models.Stock> vs = new List<Models.Stock>();
        MySqlConnection Connection;
        MySqlCommand Command;
        MySqlDataReader Reader;

        public List<Models.Stock> Read()
        {
            string sql = "SELECT * FROM deposito_comp";
            Connection = Conectar();
            Command = new MySqlCommand(sql,Connection);
            Reader = Command.ExecuteReader();
            try
            {
                while (Reader.Read())
                {
                    Models.Stock stock = new Models.Stock();

                    stock.Id = Reader.GetInt16(0);
                    stock.Name = Reader.GetString(1);
                    stock.Marca = Reader.GetString(2);
                    stock.Modelo = Reader.GetString(3);
                    stock.Tipo = Reader.GetString(4);
                    stock.Area = Reader.GetString(5);
                    stock.Cantidad = Reader.GetInt16(6);
                    stock.Estado = Reader.GetString(7);

                    vs.Add(stock);
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en la conexion" + ex);
            }
            return vs;
        }
    }
}
