using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ATMContext : DbContext
    {
        public ATMContext (DbContextOptions<ATMContext> options)
            : base(options)
        {
        }

        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Retiro> Retiros { get; set; }
        public DbSet<Balance> Balances { get; set; }
    }
}
