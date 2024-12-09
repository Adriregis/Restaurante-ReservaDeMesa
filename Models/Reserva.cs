namespace Restaurante.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string TelefoneCliente { get; set; } = string.Empty;
        public int NumeroPessoas { get; set; }
        public DateTime DataReserva { get; set; }
    }



}



