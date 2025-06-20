using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Application.DTOs
{
    public class UpdateDispositivoDto
    {
        [Required(ErrorMessage = "O número de série é obrigatório.")]
        [StringLength(50, ErrorMessage = "O número de série deve ter no máximo 50 caracteres.", MinimumLength = 1)]
        public string Serial { get; set; } = string.Empty;

        [Required(ErrorMessage = "O IMEI é obrigatório.")]
        [StringLength(15, ErrorMessage = "O IMEI deve ter exatamente 15 caracteres.", MinimumLength = 15)]
        public string IMEI { get; set; } = string.Empty;

        /// <summary>Data de aquisição do dispositivo.</summary>
        /// <example>2025-06-19</example>
        [DataType(DataType.Date, ErrorMessage = "Data de ativação inválida.")]
        public DateTime? DataAtivacao { get; set; }
    }
}