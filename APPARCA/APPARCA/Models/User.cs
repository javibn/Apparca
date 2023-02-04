using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace APPARCA.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Correo { get; set; }

        
        public string? Telefono { get; set; }

        public string? Dni { get; set; }

        

        public ICollection<Plaza>? Plazas { get; set; }
        public ICollection<Reserva>? ReservasComoArrendatario { get; set; }

    }
}
