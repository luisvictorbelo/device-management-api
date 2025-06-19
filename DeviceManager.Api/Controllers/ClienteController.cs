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
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController(IClienteService clienteService) : ControllerBase
    {
        private readonly IClienteService _clienteService = clienteService;

        /// <summary>
        ///  Retorna todos os clientes.
        ///  Se não houver clientes, retorna um status 404 Not Found.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            if (clientes == null || !clientes.Any())
            {
                return NotFound("No clients found.");
            }

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Client not found.");
            }

            return Ok(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid client data.");
            }

            var cliente = await _clienteService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Client ID mismatch.");
            }

            await _clienteService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound("Client not found.");
            }

            await _clienteService.DeleteAsync(id);
            return NoContent();
        }
    }
}