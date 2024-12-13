using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Models;

namespace Restaurante.Controllers
{
    public class ReservasController : Controller
    {
        private readonly ReservasContext _context;

        public ReservasController(ReservasContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var reservas = _context.Reservas.ToList();
            return View(reservas);
        }
        
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }
            var reserva = _context.Reservas.FirstOrDefault(m => m.Id == id);
            if (reserva == null)
            var reservas = await _context.Reservas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservas == null)
            {
                return NotFound();
            }
            return View(reserva);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("NomeCliente,TelefoneCliente,NumeroPessoas,DataReserva")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reservas.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }
        
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
            return NotFound();
            }
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
            {
             return NotFound();
            }
            return View(reserva);
         }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,NomeCliente,TelefoneCliente,NumeroPessoas,DataReserva")] Reserva reserva)
        {
            if (id != reserva.Id)

            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Reservas.Any(e => e.Id == reserva.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserva);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }
            var reserva = _context.Reservas.FirstOrDefault(m => m.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return View(reserva);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Reservas == null)
            {
                return Problem("Entity set 'ReservasContext.Reservas'  is null.");
            }
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Reservas.Remove(reserva);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
