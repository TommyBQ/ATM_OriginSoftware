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
        public int idTarjeta { get; set; }
        public string nroTarjeta { get; set; }
        public int PIN { get; set; }
        public int balance { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public bool estaBloqueada { get; set; }
    }
}
