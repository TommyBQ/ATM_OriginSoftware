using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("Retiro")]
    public class Retiro : Operacion
    {
        private int montoRetirado { get; set; }

        public int MontoRetirado
        {
            get { return montoRetirado; }
            set { montoRetirado = value; }
        }
    }
}
