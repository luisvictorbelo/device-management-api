using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Enums;
using DeviceManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Infrastructure.Repositories
{
    public class EventoRepository(DeviceManagerDbContext context) : IEventoRepository
    {
        private readonly DeviceManagerDbContext _context = context;

        public async Task<Evento?> GetByIdAsync(Guid id)
        {
            return await _context.Eventos.FindAsync(id);
                
        }

        public async Task<Evento> CreateAsync(Evento evento)
        {
            _context.Eventos.Add(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        public async Task<IEnumerable<Evento>> GetByDispositivoAsync(Guid dispositivoId)
        {
            return await _context.Eventos
                .Where(e => e.DispositivoId == dispositivoId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Eventos
                .Where(e => e.DataHora >= startDate && e.DataHora <= endDate)
                .ToListAsync();
        }

        public async Task<Dictionary<TipoEvento, int>> GetResumoUltimos7DiasAsync()
        {
            var dataLimite = DateTime.UtcNow.AddDays(-7);

            return await _context.Eventos
                .Where(e => e.DataHora >= dataLimite)
                .GroupBy(e => e.Tipo)
                .Select(g => new { Tipo = g.Key, Count = g.Count() })
                .ToDictionaryAsync(g => g.Tipo, g => g.Count);
        }
    }
}