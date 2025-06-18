using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;

namespace DeviceManager.Application.Interfaces
{
    public interface IDispositivoService
    {
        Task<IEnumerable<DispositivoDto>> GetAllAsync();
        Task<DispositivoDto?> GetByIdAsync(Guid id);
        Task<DispositivoDto> CreateAsync(DispositivoDto dispositivoDto);
        Task UpdateAsync(Guid id, DispositivoDto dispositivoDto);
        Task DeleteAsync(Guid id);
    }
}