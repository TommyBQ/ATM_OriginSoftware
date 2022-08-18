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
        public int codigoOperacion { get; set; }
        public int idTarjeta { get; set; }
        public DateTime fechaHoraOperacion { get; set; }
    }
}
