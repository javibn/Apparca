namespace Web_API
{
    public class FiltroPlaza
    {
        public FiltroPlaza(string latitudMaxima, string latitudMinima, string longitudMaxima, 
            string longitudMinima, string horaInicio, string horaFinal, string fechaInicial, 
            string fechaFinal, string precio, string ancho)
        {
            this.LatitudMaxima= Double.Parse(latitudMaxima);
            this.LatitudMinima = Double.Parse(latitudMinima);
            this.LongitudMaxima= Double.Parse(longitudMaxima);
            this.LongitudMinima= Double.Parse(longitudMinima);
            if(horaInicio != "undefined")
            {
                this.HoraInicio = TimeOnly.Parse(horaInicio);
            }
            if (horaFinal != "undefined")
            {
                this.HoraFinal = TimeOnly.Parse(horaFinal);
            }
            if (fechaInicial != "undefined")
            {
                this.FechaInicial = DateTime.Parse(fechaInicial);
            }
            if (fechaFinal != "undefined")
            {
                this.FechaFinal= DateTime.Parse(fechaFinal);
            }
            
            this.Precio = float.Parse(precio);
            this.Ancho = int.Parse(ancho);
        }
        public double LatitudMaxima { get; set; }
        public double LatitudMinima { get; set; }
        public double LongitudMaxima { get; set; }
        public double LongitudMinima { get; set; }
        public TimeOnly HoraInicio { get; set; } = TimeOnly.MaxValue;
        public TimeOnly HoraFinal { get; set; } = new TimeOnly(0);
        public DateTime FechaInicial { get; set; } = new DateTime();
        public DateTime FechaFinal { get; set; } = new DateTime(2200, 1, 1);
        public float Precio { get; set; }
        public int Ancho { get; set; }
    }
}
