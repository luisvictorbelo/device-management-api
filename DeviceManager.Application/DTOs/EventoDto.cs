using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Application.DTOs
{
    public class EventoDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }

        public Guid DispositivoId { get; set; }
    }
}