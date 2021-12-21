namespace WebCalculadora.Models
{
    public class Stock
    {
        int id;
        string name;
        string marca;
        string modelo;
        string tipo;
        string area;
        int cantidad;
        string estado;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Area { get => area; set => area = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}
