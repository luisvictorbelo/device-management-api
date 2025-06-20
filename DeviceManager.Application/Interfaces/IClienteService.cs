using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;

namespace DeviceManager.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(Guid id);
        Task<ClienteDto> CreateAsync(CreateClienteDto clienteDto);
        Task UpdateAsync(Guid id, UpdateClienteDto clienteDto);
        Task DeleteAsync(Guid id);
    }
}