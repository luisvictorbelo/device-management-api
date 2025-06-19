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
    public class EventoController(IEventoService eventoService) : ControllerBase
    {
        private readonly IEventoService _eventoService = eventoService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EventoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid event data.");
            }

            var evento = await _eventoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        [HttpGet("dispositivo/{dispositivoId}")]
        public async Task<IActionResult> GetByDispositivo(Guid dispositivoId)
        {
            var eventos = await _eventoService.GetByDispositivoAsync(dispositivoId);
            return Ok(eventos);
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetByPeriod(DateTime startDate, DateTime endDate)
        {
            var eventos = await _eventoService.GetByPeriodAsync(startDate, endDate);
            return Ok(eventos);
        }
    }
}