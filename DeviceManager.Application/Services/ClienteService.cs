using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Interfaces;

namespace DeviceManager.Application.Services
{
    public class ClienteService(IClienteRepository repository, IMapper mapper) : IClienteService
    {
        private readonly IClienteRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto?> GetByIdAsync(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClienteDto?>(cliente);
        }

        public async Task<ClienteDto> CreateAsync(CreateClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            var createdCliente = await _repository.CreateAsync(cliente);
            return _mapper.Map<ClienteDto>(createdCliente);
        }

        public async Task UpdateAsync(Guid id, UpdateClienteDto clienteDto)
        {
            var cliente = await _repository.GetByIdAsync(id) ?? throw new KeyNotFoundException("Cliente não encontrado.");
            _mapper.Map(clienteDto, cliente);
            await _repository.UpdateAsync(cliente);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}