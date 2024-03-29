﻿using System.ComponentModel.DataAnnotations;

namespace WebCalculadora.Models
{
    public class UserLogin
    {
        string? Email;
        string? Password;
        int? idEstatus;

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

    }
}
