using Restaurante.Models;



namespace Restaurante.Service.Sedding
{
    public class SeedingService
    {
        private readonly ReservasContext _context;
        public SeedingService(ReservasContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            if (_context.Reservas.Any()
               )
            {
                return; 
            }

            Reserva r1 = new Reserva(1, "João Silva", "11987654321", 4, new DateTime(2023, 12, 25, 19, 0, 0));
            Reserva r2 = new Reserva(2, "Maria Oliveira", "21965432187", 2, new DateTime(2024, 1, 15, 20, 0, 0));
            Reserva r3 = new Reserva(3, "Carlos Mendes", "11998765432", 5, new DateTime(2024, 2, 10, 18, 30, 0));
            Reserva r4 = new Reserva(4, "Ana Costa", "31976543210", 3, new DateTime(2024, 3, 5, 13, 0, 0));
            Reserva r5 = new Reserva(5, "Lucas Pereira", "21987654321", 6, new DateTime(2024, 4, 20, 12, 0, 0));
            Reserva r6 = new Reserva(6, "Beatriz Lima", "11965478932", 2, new DateTime(2024, 5, 15, 17, 0, 0));
            Reserva r7 = new Reserva(7, "Paulo Moreira", "31987654321", 8, new DateTime(2024, 6, 10, 20, 0, 0));
            Reserva r8 = new Reserva(8, "Fernanda Almeida", "21965498732", 1, new DateTime(2024, 7, 25, 19, 30, 0));
            Reserva r9 = new Reserva(9, "Roberto Santos", "11987612345", 3, new DateTime(2024, 8, 15, 18, 0, 0));
            Reserva r10 = new Reserva(10, "Juliana Cardoso", "31965412378", 4, new DateTime(2024, 9, 10, 14, 0, 0));
            Reserva r11 = new Reserva(11, "Gustavo Souza", "11976543210", 5, new DateTime(2024, 10, 5, 21, 0, 0));
            Reserva r12 = new Reserva(12, "Carla Nunes", "31987654329", 2, new DateTime(2024, 11, 20, 16, 30, 0));
            Reserva r13 = new Reserva(13, "Leonardo Barreto", "21965478910", 7, new DateTime(2024, 12, 31, 22, 0, 0));
            Reserva r14 = new Reserva(14, "Patrícia Ferreira", "11965498765", 3, new DateTime(2025, 1, 15, 19, 0, 0));
            Reserva r15 = new Reserva(15, "Eduardo Campos", "31976543298", 2, new DateTime(2025, 2, 20, 20, 30, 0));
            Reserva r16 = new Reserva(16, "Isabela Mendes", "21976543210", 4, new DateTime(2025, 3, 10, 12, 0, 0));
            Reserva r17 = new Reserva(17, "Ricardo Martins", "31987654321", 6, new DateTime(2025, 4, 5, 14, 0, 0));
            Reserva r18 = new Reserva(18, "Amanda Vieira", "11987654310", 5, new DateTime(2025, 5, 18, 19, 30, 0));
            Reserva r19 = new Reserva(19, "Renata Albuquerque", "21965432109", 3, new DateTime(2025, 6, 15, 16, 0, 0));
            Reserva r20 = new Reserva(20, "Bruno Araújo", "31965498721", 2, new DateTime(2025, 7, 20, 13, 30, 0));

            await _context.Reservas.AddRangeAsync(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20
        );

            await _context.SaveChangesAsync();

        }

    }
} 
