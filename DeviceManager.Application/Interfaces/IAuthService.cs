using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Domain.Entities;

namespace DeviceManager.Application.Interfaces
{
    public interface IAuthService
    {
        public string GenerateToken(string email, string perfil);
        public Task<string> LoginAsync(LoginDto loginDto);

        // public Task<User> RegisterAsync(CreateUserDto createUserDto);
    }
}