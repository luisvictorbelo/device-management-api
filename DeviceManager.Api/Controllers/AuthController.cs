using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers
{
    /// <summary>
    /// Controlador responsável pelos endpoints de autenticação, como login de usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        /// <summary>
        /// Autentica um usuário e retorna um token JWT caso o login seja bem-sucedido.
        /// </summary>
        /// <param name="loginDto">As credenciais de login do usuário.</param>
        /// <returns>Um objeto contendo o token de autenticação.</returns>
        /// <response code="200">Retorna o token JWT se a autenticação for bem-sucedida.</response>
        /// <response code="400">Se as credenciais de login forem inválidas.</response>
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            return Ok(new { Token = token });
        }
    }
}