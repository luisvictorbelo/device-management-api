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
    /// Controlador responsável pelo gerenciamento de eventos.
    /// Permite operações de consulta e criação de eventos.
    /// Apenas usuários com perfil de administrador têm acesso.
    /// </summary>
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController(IEventoService eventoService) : ControllerBase
    {
        private readonly IEventoService _eventoService = eventoService;

        /// <summary>
        /// Retorna um evento pelo seu id único.
        /// </summary>
        /// <param name="id">Id do evento.</param>
        /// <returns>O evento encontrado ou status 404 se não existir.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            return Ok(evento);
        }

        /// <summary>
        /// Cria um novo evento.
        /// </summary>
        /// <param name="dto">Dados para criação do evento.</param>
        /// <returns>O evento criado e o local onde pode ser consultado.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventoDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Dados do evento inválidos.");
            }

            var evento = await _eventoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        /// <summary>
        /// Retorna todos os eventos de um dispositivo específico.
        /// </summary>
        /// <param name="dispositivoId">Id do dispositivo.</param>
        /// <returns>Lista de eventos do dispositivo.</returns>
        [HttpGet("dispositivo/{dispositivoId}")]
        public async Task<IActionResult> GetByDispositivo([FromRoute] Guid dispositivoId)
        {
            var eventos = await _eventoService.GetByDispositivoAsync(dispositivoId);
            return Ok(eventos);
        }

        /// <summary>
        /// Retorna todos os eventos ocorridos em um determinado período.
        /// </summary>
        /// <param name="startDate">Data de início do período.</param>
        /// <param name="endDate">Data de término do período.</param>
        /// <returns>Lista de eventos no período especificado.</returns>
        [HttpGet("periodo")]
        public async Task<IActionResult> GetByPeriod([FromQuery(Name = "inicio")] DateTime startDate, [FromQuery(Name = "fim")] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("A data de início não pode ser maior que a data de término.");
            }

            if (startDate == default || endDate == default)
            {
                return BadRequest("Datas inválidas.");
            }
            var eventos = await _eventoService.GetByPeriodAsync(startDate, endDate);
            return Ok(eventos);
        }
    }
}