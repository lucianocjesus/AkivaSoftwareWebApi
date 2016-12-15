using System;
using System.ComponentModel.DataAnnotations;

namespace AkivaSoftwareWebRest.Api.Models
{
    public class UserModelView
    {
        public Guid Id { get; set; }

        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        [MinLength(3, ErrorMessage = "O nome não pode ter menos do que 3 caracteres")]
        [Required(ErrorMessage = "O nome do usuario é obrigatório")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "O email não pode ter mais de 250 caracteres")]
        [MinLength(3, ErrorMessage = "O email não pode ter menos do que 3 caracteres")]
        [Required(ErrorMessage = "O email do usuario é obrigatório")]
        [EmailAddress(ErrorMessage = "Digite um endereço de email valido")]
        public string Email { get; set; }

    }
}