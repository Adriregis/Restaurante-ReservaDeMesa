using Restaurante.Models;
using System.Collections.Generic;
using System.Linq;

namespace Restaurante.Service
{
    public class ReservaService
    {
        private readonly ReservasContext _context;

        // Construtor com injeção de dependência do contexto
        public ReservaService(ReservasContext context)
        {
            _context = context;
        }

        // Método para buscar todas as reservas
        public List<Reserva> FindAll()
        {
            return _context.Reservas.ToList();
        }

        // Exemplo: Método para buscar reserva por ID
        public Reserva? FindById(int id)
        {
            return _context.Reservas.FirstOrDefault(r => r.Id == id);
        }

        // Exemplo: Método para criar uma nova reserva
        public void Create(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();
        }
    }
}
