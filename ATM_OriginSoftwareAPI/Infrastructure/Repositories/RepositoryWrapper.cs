using Application.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ATMContext _repoContext;
        private ITarjetaRepository _tarjetas;
        private IRetiroRepository _retiros;
        private IBalanceRepository _balances;

        public ITarjetaRepository Tarjetas
        {
            get
            {
                if (_tarjetas == null)
                {
                    _tarjetas = new TarjetaRepository(_repoContext);
                }
                return _tarjetas;
            }
        }
        public IRetiroRepository Retiros
        {
            get
            {
                if (_retiros == null)
                {
                    _retiros = new RetiroRepository(_repoContext);
                }
                return _retiros;
            }
        }
        public IBalanceRepository Balances
        {
            get
            {
                if (_balances == null)
                {
                    _balances = new BalanceRepository(_repoContext);
                }
                return _balances;
            }
        }

        public RepositoryWrapper(ATMContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
