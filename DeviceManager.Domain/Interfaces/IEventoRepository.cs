using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Enums;

namespace DeviceManager.Domain.Interfaces
{
    public interface IEventoRepository
    {
        Task<Evento> CreateAsync(Evento evento);
        Task<IEnumerable<Evento>> GetByDispositivoAsync(Guid dispositivoId);
        Task<IEnumerable<Evento>> GetByPeriodAsync(DateTime startDate, DateTime endDate);
        Task<Dictionary<TipoEvento, int>> GetResumoUltimos7DiasAsync();
    }
}