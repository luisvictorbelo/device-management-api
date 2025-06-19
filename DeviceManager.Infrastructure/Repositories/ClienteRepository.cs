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
    public class ClienteRepository(DeviceManagerDbContext context) : IClienteRepository
    {
        private readonly DeviceManagerDbContext _context = context;

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}