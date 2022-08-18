using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Operacion
    {
        [Key]
        private int codigoOperacion { get; set; }
        private int idTarjeta { get; set; }
        private DateTime fechaHoraOperacion { get ; set; }

        public int CodigoOperacion
        {
            get { return codigoOperacion; }
            set { codigoOperacion = value; }
        }
        public int IdTarjeta
        {
            get { return idTarjeta; }
            set { idTarjeta = value; }
        }
        public DateTime FechaHoraOperacion
        {
            get { return fechaHoraOperacion; }
            set { fechaHoraOperacion = DateTime.Now; }
        }
    }
}
