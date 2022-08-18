using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Tarjeta")]
    public class Tarjeta
    {
        [Key]
        private int idTarjeta { get; set; }
        private string nroTarjeta { get; set; }
        private int _PIN { get; set; }
        private int balance { get; set; }
        private DateTime fechaVencimiento { get; set; }
        private bool estaBloqueada { get; set; }

        public int IdTarjeta
        {
            get { return idTarjeta; }
            set { idTarjeta = value; }
        }
        public string NroTarjeta
        {
            get { return nroTarjeta; }
            set { nroTarjeta = value; }
        }
        public int PIN
        {
            get { return _PIN; }
            set { _PIN = value; }
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }
        public bool EstaBloqueada
        {
            get { return estaBloqueada; }
            set { estaBloqueada = value; }
        }
    }
}
