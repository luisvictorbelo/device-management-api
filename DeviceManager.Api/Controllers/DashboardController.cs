using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceManager.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManager.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController(IEventoService eventoService) : ControllerBase
    {
        private readonly IEventoService _eventoService = eventoService;

        [HttpGet]
        public async Task<IActionResult> GetResumoUltimos7Dias()
        {
            var resumo = await _eventoService.GetResumoUltimos7DiasAsync();
            if (resumo == null || resumo.Count == 0)
            {
                return NotFound("No events found in the last 7 days.");
            }

            return Ok(resumo);
        }
    }
}