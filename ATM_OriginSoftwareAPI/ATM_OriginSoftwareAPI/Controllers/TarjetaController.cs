using Application;
using Application.Interfaces;
using Application.TarjetaCQ.Commands;
using Application.TarjetaCQ.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private TarjetaQueries tarjetaQueries;
        private TarjetaCommands tarjetaCommands;

        public TarjetaController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            tarjetaQueries = new TarjetaQueries(repoWrapper);
            tarjetaCommands = new TarjetaCommands(repoWrapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarjetas = await _repoWrapper.Tarjetas.GetAll().ToListAsync();
            return Ok(tarjetas);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ValidarNroTarjeta(string nroTarjeta)
        {
            if (!tarjetaQueries.ExisteTarjeta(nroTarjeta))
            {
                return NotFound("No se encontró la tarjeta.");
            } else if (tarjetaQueries.EstaBloqueada(nroTarjeta))
            {
                return BadRequest("La tarjeta se encuentra bloqueada.");
            }
            SessionManager.GetInstance.setNroTarjeta(nroTarjeta);
            return Ok("Se encontró correctamente la tarjeta.");
        }

        [HttpGet("pin")]
        public async Task<IActionResult> LoguearTarjeta(int pin)
        {
            if (!tarjetaCommands.VerificarPIN(pin))
            {
                if (SessionManager.GetInstance.intentosDeIngreso >= 4)
                {
                    tarjetaCommands.BloquearTarjeta();
                    return BadRequest("Se ha bloqueado la tarjeta.");
                }

                return BadRequest("PIN Incorrecto.");
            }
            tarjetaCommands.IniciarSesion();
            return Ok("Se ha iniciado correctamente la sesión.");
        }

        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            tarjetaCommands.CerrarSesion();
            return Ok("Se ha cerrado correctamente la sesión.");
        }
    }
}
