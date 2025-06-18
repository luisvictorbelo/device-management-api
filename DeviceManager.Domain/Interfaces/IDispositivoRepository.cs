using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;

namespace DeviceManager.Domain.Interfaces
{
    public interface IDispositivoRepository
    {
        Task<IEnumerable<Dispositivo>> GetAllAsync();
        Task<Dispositivo?> GetByIdAsync(Guid id);
        Task<Dispositivo> CreateAsync(Dispositivo dispositivo);
        Task UpdateAsync(Dispositivo dispositivo);
        Task DeleteAsync(Guid id);
    }
}