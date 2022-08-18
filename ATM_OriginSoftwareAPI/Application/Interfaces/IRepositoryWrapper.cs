using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositoryWrapper
    {
        ITarjetaRepository Tarjetas { get; }
        IRetiroRepository Retiros { get; }
        IBalanceRepository Balances { get; }
        void Save();
    }
}
