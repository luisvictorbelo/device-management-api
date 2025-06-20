using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers
{
    /// <summary>
    /// Controlador responsável por fornecer dados resumidos para o dashboard.
    /// Requer autenticação do usuário.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController(IEventoService eventoService) : ControllerBase
    {
        private readonly IEventoService _eventoService = eventoService;

        /// <summary>
        /// Retorna um resumo dos eventos ocorridos nos últimos 7 dias.
        /// </summary>
        /// <returns>Resumo dos eventos ou status 404 se não houver eventos no período.</returns>
        [HttpGet]
        public async Task<IActionResult> GetResumoUltimos7Dias()
        {
            var resumo = await _eventoService.GetResumoUltimos7DiasAsync();
            if (resumo == null || resumo.Count == 0)
            {
                return NotFound("Eventos não encontrados nos últimos 7 dias.");
            }

            return Ok(resumo);
        }
    }
}