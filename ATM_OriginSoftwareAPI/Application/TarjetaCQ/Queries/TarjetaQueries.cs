using Application.Interfaces;
using Domain.Models;

namespace Application.TarjetaCQ.Queries
{
    public class TarjetaQueries
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public TarjetaQueries(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
        public bool ExisteTarjeta(string num)
        {
            var tarjeta = _repoWrapper.Tarjetas.GetByCondition(x => x.NroTarjeta == num).FirstOrDefault();
            if (tarjeta == null)
            {
                return false;
            }
            return true;
        }

        public bool EstaBloqueada(string num)
        {
            var tarjeta = _repoWrapper.Tarjetas.GetByCondition(x => x.NroTarjeta == num).FirstOrDefault();
            if (tarjeta.EstaBloqueada)
            {
                return true;
            }
            return false;
        }

    }
}
