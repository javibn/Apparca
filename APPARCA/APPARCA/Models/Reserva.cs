namespace APPARCA.Models
{
    public class Reserva
    {
        public int Id { get; set; }


        public Plaza? PlazaReservada { get; set; }
        public int? PlazaId { get; set; }


        public User? Arrendatario { get; set; }
        public int? ArrendatarioId { get; set; }


        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFinal { get; set; }


        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public byte[]? Contrato { get; set; }
        public bool? Confirmada { get; set; }
    }
}
