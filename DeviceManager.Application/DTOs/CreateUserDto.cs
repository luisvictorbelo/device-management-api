using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Application.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; } = default!;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(15, ErrorMessage = "A senha deve ter no mínimo 1 e no máximo 15 caracteres.", MinimumLength = 1)]
        public string Password { get; set; } = default!;

        [Required(ErrorMessage = "O perfil é obrigatório.")]
        public string Perfil { get; set; } = default!;
    }
}