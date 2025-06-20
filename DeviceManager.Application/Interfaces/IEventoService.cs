using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Application.Interfaces
{
    public interface IEventoService
    {
        Task<EventoDto?> GetByIdAsync(Guid id);
        Task<EventoDto> CreateAsync(CreateEventoDto eventoDto);
        Task<IEnumerable<EventoDto>> GetByDispositivoAsync(Guid dispositivoId);
        Task<IEnumerable<EventoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<TipoEvento, int>> GetResumoUltimos7DiasAsync();
    }
}