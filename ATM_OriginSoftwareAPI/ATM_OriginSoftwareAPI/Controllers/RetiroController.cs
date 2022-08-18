using Application;
using Application.Interfaces;
using Application.RetiroCQ.Commands;
using Application.RetiroCQ.Queries;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RetiroController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private RetiroCommands retiroCommands;
        private RetiroQueries retiroQueries;

        public RetiroController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            retiroCommands = new RetiroCommands(repoWrapper);
            retiroQueries = new RetiroQueries(repoWrapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var retiros = await _repoWrapper.Retiros.GetAll().ToListAsync();
            return Ok(retiros);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int montoARetirar)
        {
            if (!retiroQueries.ValidarMontoARetirar(montoARetirar))
            {
                return BadRequest("No se puede retirar más de lo que se tiene en la cuenta.");
            }
            retiroCommands.CrearRegistroRetiro(montoARetirar);
            return Ok("Se creó el registro del retiro.");
        }
        [HttpGet]
        public async Task<IActionResult> GetTarjetaLogueada()
        {
            return Ok(SessionManager.GetInstance.obtenerTarjetaLogueada());
        }
    }
}
