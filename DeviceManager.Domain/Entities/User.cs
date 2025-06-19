using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;

        public string Perfil { get; set; } = "Admin";
    }
}