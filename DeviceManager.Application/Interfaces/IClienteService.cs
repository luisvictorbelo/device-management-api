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
        Task<ClienteDto> CreateAsync(ClienteDto clienteDto);
        Task UpdateAsync(Guid id, ClienteDto clienteDto);
        Task DeleteAsync(Guid id);
    }
}