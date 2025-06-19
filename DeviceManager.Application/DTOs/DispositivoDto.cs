using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Application.DTOs
{
    public class DispositivoDto
    {
        public Guid Id { get; set; }
        public string Serial { get; set; } = string.Empty;
        public string IMEI { get; set; } = string.Empty;
        public DateTime? DataAtivacao { get; set; }
        public Guid ClienteId { get; set; }
    }
}