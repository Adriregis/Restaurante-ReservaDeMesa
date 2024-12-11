using Microsoft.EntityFrameworkCore;

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
