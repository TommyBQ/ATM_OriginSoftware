using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TarjetaRepository : RepositoryBase<Tarjeta>, ITarjetaRepository
    {
        public TarjetaRepository(ATMContext repositoryContext)
            : base(repositoryContext)
        {

        }

    }
}
