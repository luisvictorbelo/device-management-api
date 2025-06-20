using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers
{
    /// <summary>
    /// Controlador responsável pelo gerenciamento de usuários.
    /// Permite consultar e criar usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Retorna um usuário pelo seu id único.
        /// </summary>
        /// <param name="id">Id do usuário.</param>
        /// <returns>O usuário encontrado ou status 404 se não existir.</returns>
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário. Crie com o perfil de administrador (Admin) para ter acesso aos endpoints.
        /// </summary>
        /// <param name="dto">Dados para criação do usuário.</param>
        /// <returns>O usuário criado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            return Ok(user);
        }
    }
}