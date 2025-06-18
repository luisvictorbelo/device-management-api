using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public required TipoEvento Tipo { get; set; }
        public required DateTime DataHora { get; set; }
        public Guid DispositivoId { get; set; }
        public Dispositivo Dispositivo { get; set; } = null!;
    }
}