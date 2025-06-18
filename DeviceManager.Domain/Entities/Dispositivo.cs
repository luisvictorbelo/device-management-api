using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Domain.Entities
{
    public class Dispositivo
    {
        public Guid Id { get; set; }
        public required string Serial { get; set; }
        public required string IMEI { get; set; }
        public DateTime? DataAtivacao { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<Evento> Eventos { get; set; } = [];
    }
}