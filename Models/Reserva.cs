namespace Restaurante.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string TelefoneCliente { get; set; } = string.Empty;
        public int NumeroPessoas { get; set; }
        public DateTime DataReserva { get; set; }

        public Reserva()
        {
        }

        public Reserva(int id, string nomeCliente, string telefoneCliente, int numeroPessoas, DateTime dataReserva)
        {
            Id = id;
            NomeCliente = nomeCliente;
            TelefoneCliente = telefoneCliente;
            NumeroPessoas = numeroPessoas;
            DataReserva = dataReserva;
        }
    }
}

