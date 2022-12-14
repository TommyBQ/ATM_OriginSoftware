using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class SessionManager
    {
        private static SessionManager _session;

        private Tarjeta tarjetaLogueada;
        private bool estaLogueado = false;
        public int intentosDeIngreso;

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) _session = new SessionManager();
                return _session;
            }
        }

        public void Login(Tarjeta tarjeta)
        {
            if (!_session.estaLogueado)
            {
                _session.tarjetaLogueada = tarjeta;
                _session.estaLogueado = true;
            }
            else
            {
                throw new Exception("Sesión ya iniciada.");
            }
        }

        public void Logout()
        {
            if (_session.estaLogueado)
            {
                _session.tarjetaLogueada = null;
                _session.estaLogueado = false;
            }
            _session.intentosDeIngreso = 0;
        }

        public Tarjeta obtenerTarjetaLogueada()
        {
            if (_session.tarjetaLogueada != null && _session.estaLogueado)
            {
                return _session.tarjetaLogueada;
            }
            else
            {
                throw new Exception("No hay tarjeta logueada.");
            }
        }

        public void setNroTarjeta(string numTarjeta)
        {
            if (!_session.estaLogueado)
            {
                _session.tarjetaLogueada = new Tarjeta();
                tarjetaLogueada.NroTarjeta = numTarjeta;
            }

        }
        public string getNroTarjeta()
        {
            if (_session.tarjetaLogueada != null)
            {
                return _session.tarjetaLogueada.NroTarjeta;
            }
            else
            {
                throw new Exception("No se ingresó num tarjeta.");
            }
        }

        public int getIdTarjeta()
        {
            if (_session.tarjetaLogueada != null)
            {
                return _session.tarjetaLogueada.IdTarjeta;
            }
            else
            {
                throw new Exception("No se ingresó num tarjeta.");
            }
        }

        private SessionManager()
        {

        }
    }
}
