using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RetiroCQ.Queries
{
    public class RetiroQueries
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public RetiroQueries(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool ValidarMontoARetirar(int monto)
        {
            if (monto > SessionManager.GetInstance.obtenerTarjetaLogueada().Balance)
            {
                return false;
            }
            return true;
        }
    }
}
