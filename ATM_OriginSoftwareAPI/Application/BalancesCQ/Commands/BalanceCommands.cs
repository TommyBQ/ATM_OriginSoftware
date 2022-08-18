using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BalancesCQ.Commands
{
    public class BalanceCommands
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public BalanceCommands(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void CrearRegistroBalance()
        {
            Balance balance = new Balance();
            balance.IdTarjeta = SessionManager.GetInstance.getIdTarjeta();
            balance.FechaHoraOperacion = DateTime.Now;

            _repoWrapper.Balances.Insert(balance);
            _repoWrapper.Save();
        }
    }
}
