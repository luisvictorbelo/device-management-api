using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Domain.Entities;

namespace DeviceManager.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(CreateUserDto dto);
        Task<UserDto?> GetByIdAsync(Guid id);
    }

}