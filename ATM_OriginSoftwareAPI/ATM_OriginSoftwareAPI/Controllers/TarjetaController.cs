using Application;
using Application.Interfaces;
using Application.TarjetaCQ.Commands;
using Application.TarjetaCQ.Queries;
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

        [HttpGet]
        public async Task<IActionResult> GetTarjetaLogueada()
        {
            return Ok(SessionManager.GetInstance.obtenerTarjetaLogueada());
        }

        [HttpGet("id")]
        public async Task<IActionResult> ValidarNroTarjeta(string nroTarjeta)
        {
            if (!tarjetaQueries.ExisteTarjeta(nroTarjeta))
            {
                return NotFound(new
                {
                    IsSuccess = false,
                    mensajeError = "La tarjeta no existe.",
                    status = StatusCodes.Status404NotFound
                });
            }
            else if (tarjetaQueries.EstaBloqueada(nroTarjeta))
            {
                return BadRequest(new
                {
                    IsSuccess = false,
                    mensajeError = "La tarjeta se encuentra bloqueada.",
                    status = StatusCodes.Status400BadRequest
                });
            }
            SessionManager.GetInstance.setNroTarjeta(nroTarjeta);
            return Ok(new
            {
                IsSuccess = true,
                mensajeError = "Se validó correctamente la tarjeta.",
                status = StatusCodes.Status200OK
            });
        }

        [HttpGet("pin")]
        public async Task<IActionResult> LoguearTarjeta(int pin)
        {
            if (!tarjetaCommands.VerificarPIN(pin))
            {
                if (SessionManager.GetInstance.intentosDeIngreso >= 4)
                {
                    tarjetaCommands.BloquearTarjeta();
                    return BadRequest(new
                    {
                        IsSuccess = false,
                        mensajeError = "Se ha bloqueado la tarjeta.",
                        status = StatusCodes.Status400BadRequest
                    });
                }

                return BadRequest(new
                {
                    IsSuccess = false,
                    mensajeError = "PIN Incorrecto.",
                    status = StatusCodes.Status400BadRequest
                });
            }
            tarjetaCommands.IniciarSesion();
            return Ok(new
            {
                IsSuccess = true,
                mensajeError = "Se inició correctamente la sesión.",
                status = StatusCodes.Status200OK
            });
        }

        [HttpGet]
        public async Task<IActionResult> CerrarSesion()
        {
            tarjetaCommands.CerrarSesion();
            return Ok(new
            {
                IsSuccess = true,
                mensajeError = "Se cerró correctamente la sesión.",
                status = StatusCodes.Status200OK
            });
        }
    }
}
