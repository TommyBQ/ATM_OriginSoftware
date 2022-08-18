using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TarjetaCQ.Commands
{
    public class TarjetaCommands
    {
        private readonly IRepositoryWrapper _repoWrapper;
        public TarjetaCommands(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public bool VerificarPIN(int pin)
        {
            var tarjeta = _repoWrapper.Tarjetas.GetByCondition(x => x.NroTarjeta == SessionManager.GetInstance.getNroTarjeta() && x.PIN == pin).FirstOrDefault();
            if (tarjeta == null)
            {
                SessionManager.GetInstance.intentosDeIngreso += 1;
                return false;
            }
            return true;
        }

        public void BloquearTarjeta()
        {
            var tarjeta = _repoWrapper.Tarjetas.GetByCondition(x => x.NroTarjeta == SessionManager.GetInstance.getNroTarjeta()).FirstOrDefault();
            tarjeta.EstaBloqueada = true;
            _repoWrapper.Tarjetas.Update(tarjeta);
            _repoWrapper.Save();
        }

        public void IniciarSesion()
        {
            var tarjeta = _repoWrapper.Tarjetas.GetByCondition(x => x.NroTarjeta == SessionManager.GetInstance.getNroTarjeta()).FirstOrDefault();
            SessionManager.GetInstance.Login(tarjeta);
        }

        public void CerrarSesion()
        {
            SessionManager.GetInstance.Logout();
        }
    }
}
