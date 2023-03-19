using System.Data.SqlTypes;

namespace Web_API.Models
{
    public class Plaza
    {
        public int Id { get; set; }
        
        public Usuario? Arrendador { get; set; }
        public int ArrendadorId { get; set; }
        
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public string? Direccion { get; set; }

        public int Ancho { get; set; }
        public int Largo { get; set; }

        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }

        public string PrecioMes { get; set; }

        public ICollection<ImagenesPlaza> Imagenes { get; set; }


        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }

        public float? PrecioMando { get; set; }
        public bool? EsVerificada { get; set; }
    }
}
