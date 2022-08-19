using Application.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RetiroCQ.Commands
{
    public class RetiroCommands
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public RetiroCommands(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public void CrearRegistroRetiro(int monto)
        {
            Retiro retiroARealizar = new Retiro();
            retiroARealizar.IdTarjeta = SessionManager.GetInstance.getIdTarjeta();
            retiroARealizar.MontoRetirado = monto;
            retiroARealizar.FechaHoraOperacion = DateTime.Now;

            _repoWrapper.Retiros.Insert(retiroARealizar);
            _repoWrapper.Save();

            ModificarBalanceTarjeta(monto);
        }

        private void ModificarBalanceTarjeta(int montoRetirado)
        {
            Tarjeta tarjetaAModificar = SessionManager.GetInstance.obtenerTarjetaLogueada();
            tarjetaAModificar.Balance -= montoRetirado;

            _repoWrapper.Tarjetas.Update(tarjetaAModificar);
            _repoWrapper.Save();
        }
    }
}
