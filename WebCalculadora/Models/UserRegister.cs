using System.ComponentModel.DataAnnotations;

namespace WebCalculadora.Models
{
    public class UserRegister
    {
        string Email;
        string Password;
        string Password2;

        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Dirección de Correo electrónico incorrecta.")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [DataType(DataType.EmailAddress)]
        public string Email1 { get => Email; set => Email = value; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                     MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password1 { get => Password; set => Password = value; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(15, ErrorMessage = "Longitud entre 6 y 15 caracteres.",
                     MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Compare("Password1", ErrorMessage = "Las contraseñas no coinciden")]
        public string Password21 { get => Password2; set => Password2 = value; }
    }
}
