using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public bool Status { get; set; }

        public ICollection<Dispositivo> Dispositivos { get; set; } = [];
    }
}