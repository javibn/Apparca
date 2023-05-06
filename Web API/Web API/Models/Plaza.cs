using System.Data.SqlTypes;

namespace Web_API.Models
{
    public class Plaza
    {
        public int Id { get; set; }
        public int ArrendadorId { get; set; }
        
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }

        public int Ancho { get; set; }
        public int Largo { get; set; }

        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }

        public float PrecioMes { get; set; }

        public byte[] Imagen { get; set; }


        public string HoraInicio { get; set; }
        public string HoraFinal { get; set; }

        public float PrecioMando { get; set; }
    }
}
