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
    /// Controlador responsável pelo gerenciamento de clientes.
    /// Permite operações de consulta, criação, atualização e remoção de clientes.
    /// Apenas usuários com perfil de administrador têm acesso.
    /// </summary>
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;

        /// <summary>
        /// Retorna todos os clientes cadastrados.
        /// </summary>
        /// <returns>Lista de clientes ou status 404 se não houver clientes.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            if (clientes == null || !clientes.Any())
            {
                return NotFound("Clientes não encontrados.");
            }

            return Ok(clientes);
        }

        /// <summary>
        /// Retorna um cliente pelo seu id único.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns>O cliente encontrado ou status 404 se não existir.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return Ok(cliente);
        }
        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="dto">Dados para criação do cliente.</param>
        /// <returns>O cliente criado e o local onde pode ser consultado.</returns>
        [HttpPost]
        
        public async Task<IActionResult> Create([FromBody] CreateClienteDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            var cliente = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        /// <summary>
        /// Atualiza os dados de um cliente existente.
        /// </summary>
        /// <param name="id">Identificador do cliente.</param>
        /// <param name="dto">Dados atualizados do cliente.</param>
        /// <returns>Status 204 se a atualização for bem-sucedida.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateClienteDto dto)
        {
            await _clienteService.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um cliente pelo seu id.
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns>Status 204 se a remoção for bem-sucedida ou 404 se não encontrado.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}