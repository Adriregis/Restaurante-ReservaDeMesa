namespace Restaurante.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string? NomeCiente { get; set; }
        public string? TelefoneCliente { get; set; }
        public int NumeroPessoas { get; set; }
        public DateTime DataReserva { get; set; }
    }

}
    

