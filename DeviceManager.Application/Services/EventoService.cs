using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Enums;
using DeviceManager.Domain.Interfaces;

namespace DeviceManager.Application.Services
{
    public class EventoService(IEventoRepository repository, IMapper mapper) : IEventoService
    {
        private readonly IEventoRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<EventoDto?> GetByIdAsync(Guid id)
        {
            var evento = await _repository.GetByIdAsync(id);
            return _mapper.Map<EventoDto?>(evento);
        }

        public async Task<EventoDto> CreateAsync(CreateEventoDto dto)
        {
            var evento = _mapper.Map<Evento>(dto);
            evento.Tipo = Enum.Parse<TipoEvento>(dto.Tipo);

            var createdEvento = await _repository.CreateAsync(evento);

            return _mapper.Map<EventoDto>(createdEvento);
        }

        public async Task<IEnumerable<EventoDto>> GetByDispositivoAsync(Guid dispositivoId)
        {
            var eventos = await _repository.GetByDispositivoAsync(dispositivoId);
            return _mapper.Map<IEnumerable<EventoDto>>(eventos);
        }

        public async Task<IEnumerable<EventoDto>> GetByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            var eventos = await _repository.GetByPeriodAsync(startDate, endDate);
            return _mapper.Map<IEnumerable<EventoDto>>(eventos);
        }

        public async Task<Dictionary<TipoEvento, int>> GetResumoUltimos7DiasAsync()
        {
            return await _repository.GetResumoUltimos7DiasAsync();
        }
    }
}