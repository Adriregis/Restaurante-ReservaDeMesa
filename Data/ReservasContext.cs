using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante
{
    public class ReservasContext : DbContext
    {
        public ReservasContext(DbContextOptions<ReservasContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurante.Models.Reserva> Reservas { get; set; } = default!;
    }
}
