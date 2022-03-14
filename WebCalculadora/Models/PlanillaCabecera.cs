using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebCalculadora.Models
{
    public class PlanillaCabecera : PlanillaRegistros
    {
        private int count = 0;

        private List<string>? campos_Json = new List<string>();

        private string? nombreTabla;

        private List<SelectListItem>? lstDeNombres = new List<SelectListItem>();

        private int user_id;
        

        public List<string>? Campos_Json { get => campos_Json; set => campos_Json = value; }
        public int Count { get => count; set => count = value; }
        public string? Nombre_tabla { get => nombreTabla; set => nombreTabla = value; }
        public int User_id { get => user_id; set => user_id = value; }
        public List<SelectListItem>? LstDeNombres { get => lstDeNombres; set => lstDeNombres = value; }
    }
}
