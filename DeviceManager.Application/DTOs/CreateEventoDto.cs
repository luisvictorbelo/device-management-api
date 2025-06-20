using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Application.DTOs
{
    public class CreateEventoDto
    {
        [Required(ErrorMessage = "O tipo de evento é obrigatório.")]
        public required string Tipo { get; set; }

        [Required(ErrorMessage = "A data e hora do evento são obrigatórias.")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de data e hora inválido.")]
        /// <summary>Data do evento</summary>
        /// <example>2025-06-19T14:30:00</example>
        public required DateTime DataHora { get; set; }
        [Required(ErrorMessage = "O ID do dispositivo é obrigatório.")]
        public Guid DispositivoId { get; set; }
    }
}