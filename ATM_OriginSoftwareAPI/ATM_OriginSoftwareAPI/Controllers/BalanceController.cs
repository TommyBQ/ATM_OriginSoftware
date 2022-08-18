using Application;
using Application.BalancesCQ.Commands;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private BalanceCommands balanceCommands;

        public BalanceController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
            balanceCommands = new BalanceCommands(repoWrapper);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var balances = await _repoWrapper.Balances.GetAll().ToListAsync();
            return Ok(balances);
        }
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            balanceCommands.CrearRegistroBalance();
            return Ok("Se creó el registro de balance");
        }
        [HttpGet]
        public async Task<IActionResult> GetTarjetaLogueada()
        {
            return Ok(SessionManager.GetInstance.obtenerTarjetaLogueada());
        }
    }
}
