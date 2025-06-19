using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Domain.Entities;
using DeviceManager.Domain.Interfaces;
using DeviceManager.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace DeviceManager.Infrastructure.Repositories
{
    public class DispositivoRepository(DeviceManagerDbContext context) : IDispositivoRepository
    {
        private readonly DeviceManagerDbContext _context = context;

        public async Task<Dispositivo?> GetByIdAsync(Guid id)
        {
            return await _context.Dispositivos.FindAsync(id);
        }

        public async Task<IEnumerable<Dispositivo>> GetAllAsync()
        {
            return await _context.Dispositivos.AsNoTracking().ToListAsync();
        }

        public async Task<Dispositivo> CreateAsync(Dispositivo dispositivo)
        {
            _context.Dispositivos.Add(dispositivo);
            await _context.SaveChangesAsync();
            return dispositivo;
        }

        public async Task UpdateAsync(Dispositivo dispositivo)
        {
            _context.Dispositivos.Update(dispositivo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo != null)
            {
                _context.Dispositivos.Remove(dispositivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}