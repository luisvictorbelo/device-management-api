using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.DTOs;
using DeviceManager.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispositivoController(IDispositivoService dispositivoService) : ControllerBase
    {
        private readonly IDispositivoService _dispositivoService = dispositivoService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dispositivos = await _dispositivoService.GetAllAsync();
            if (dispositivos == null || !dispositivos.Any())
            {
                return NotFound("No devices found.");
            }

            return Ok(dispositivos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var dispositivo = await _dispositivoService.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound("Device not found.");
            }

            return Ok(dispositivo);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DispositivoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid device data.");
            }

            var dispositivo = await _dispositivoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = dispositivo.Id }, dispositivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DispositivoDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Device ID mismatch.");
            }

            await _dispositivoService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var dispositivo = await _dispositivoService.GetByIdAsync(id);
            if (dispositivo == null)
            {
                return NotFound("Device not found.");
            }

            await _dispositivoService.DeleteAsync(id);
            return NoContent();
        }
    }
}