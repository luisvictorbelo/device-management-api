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
    public class DispositivoService(IDispositivoRepository repository, IMapper mapper) : IDispositivoService 
    {
        private readonly IDispositivoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<DispositivoDto>> GetAllAsync()
        {
            var dispositivos = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<DispositivoDto>>(dispositivos);
        }

        public async Task<DispositivoDto?> GetByIdAsync(Guid id)
        {
            var dispositivo = await _repository.GetByIdAsync(id);
            return _mapper.Map<DispositivoDto?>(dispositivo);
        }

        public async Task<DispositivoDto> CreateAsync(DispositivoDto dispositivoDto)
        {
            var dispositivo = _mapper.Map<Dispositivo>(dispositivoDto);
            var createdDispositivo = await _repository.CreateAsync(dispositivo);
            return _mapper.Map<DispositivoDto>(createdDispositivo);
        }

        public async Task UpdateAsync(Guid id, DispositivoDto dispositivoDto)
        {
            var dispositivo = _mapper.Map<Dispositivo>(dispositivoDto);
            dispositivo.Id = id;
            await _repository.UpdateAsync(dispositivo);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}