using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Application.DTOs
{
    public class CreateUserDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;

        public string Perfil { get; set; } = default!;
    }
}