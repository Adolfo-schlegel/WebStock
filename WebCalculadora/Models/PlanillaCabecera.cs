namespace WebCalculadora.Models
{
    public class PlanillaCabecera
    {
        private int count = 0;

        private List<string> ls = new List<string>();

        private string? nombre;

        private int user_id;
        public List<string> Campos_Json { get => ls; set => ls = value; }
        public int Count { get => count; set => count = value; }
        public string? Nombre_tabla { get => nombre; set => nombre = value; }
        public int User_id { get => user_id; set => user_id = value; }
    }
}
