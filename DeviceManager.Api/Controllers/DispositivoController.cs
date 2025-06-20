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
    /// Controlador responsável pelo gerenciamento de dispositivos.
    /// Permite operações de consulta, criação, atualização e remoção de dispositivos.
    /// Apenas usuários com perfil de administrador têm acesso.
    /// </summary>
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController(IDispositivoService dispositivoService) : ControllerBase
    {
        private readonly IDispositivoService _dispositivoService = dispositivoService;

        /// <summary>
        /// Retorna todos os dispositivos cadastrados.
        /// </summary>
        /// <returns>Lista de dispositivos ou status 404 se não houver dispositivos.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await _dispositivoService.GetAllAsync();
            if (dispositivos == null || !dispositivos.Any())
            {
                return NotFound("Dispositivos não encontrados.");
            }

            return Ok(dispositivos);
        }

        /// <summary>
        /// Retorna um dispositivo pelo seu id.
        /// </summary>
        /// <param name="id">Id do dispositivo.</param>
        /// <returns>O dispositivo encontrado ou status 404 se não existir.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var dispositivo = await _dispositivoService.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound("Dispositivo não encontrado.");
            }

            return Ok(dispositivo);
        }

        /// <summary>
        /// Cria um novo dispositivo.
        /// </summary>
        /// <param name="dto">Dados para criação do dispositivo.</param>
        /// <returns>O dispositivo criado e o local onde pode ser consultado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDispositivoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do dispositivo inválidos.");
            }

            var dispositivo = await _dispositivoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dispositivo.Id }, dispositivo);
        }

        /// <summary>
        /// Atualiza os dados de um dispositivo existente.
        /// </summary>
        /// <param name="id">Id do dispositivo.</param>
        /// <param name="dto">Dados atualizados do dispositivo.</param>
        /// <returns>Status 204 se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDispositivoDto dto)
        {
            await _dispositivoService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um dispositivo pelo seu id.
        /// </summary>
        /// <param name="id">Id do dispositivo.</param>
        /// <returns>Status 204 se a remoção for bem-sucedida ou 404 se não encontrado.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var dispositivo = await _dispositivoService.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound("Dispositivo não encontrado.");
            }

            await _dispositivoService.DeleteAsync(id);
            return NoContent();
        }
    }
}