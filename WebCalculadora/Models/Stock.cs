using System.ComponentModel.DataAnnotations;

namespace WebCalculadora.Models
{
    public class Stock
    {
        int id;
        string nombre;
        string marca;
        string modelo;
        string tipo;
        string area;
        int cantidad;
        string estado;

        
        public int Id { get => id; set => id = value; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Nombre { get => nombre; set => nombre = value; }
        [Display(Name = "Marca")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Marca { get => marca; set => marca = value; }
        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Modelo { get => modelo; set => modelo = value; }
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Tipo { get => tipo; set => tipo = value; }
        [Display(Name = "Area")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Area { get => area; set => area = value; }
        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int Cantidad { get => cantidad; set => cantidad = value; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Estado { get => estado; set => estado = value; }
    }
}
