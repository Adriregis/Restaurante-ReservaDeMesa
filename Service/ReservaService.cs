using Restaurante.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Service
{
    public class ReservaService
    {
        private readonly ReservasContext _context;

        public ReservaService(ReservasContext context)
        {
            _context = context;
        }

        public List<Reserva> FindAll()
        {
            return _context.Reservas.ToList();
        }

        public Reserva? FindById(int id)
        {
            return _context.Reservas.FirstOrDefault(r => r.Id == id);
        }
        public void Create(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }
    }
}

