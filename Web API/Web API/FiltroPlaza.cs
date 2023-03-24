namespace Web_API
{
    public class FiltroPlaza
    {
        public FiltroPlaza(string latitudMaxima, string latitudMinima, string longitudMaxima, string longitudMinima)
        {
            this.LatitudMaxima= Double.Parse(latitudMaxima);
            this.LatitudMinima = Double.Parse(latitudMinima);
            this.LongitudMaxima= Double.Parse(longitudMaxima);
            this.LongitudMinima= Double.Parse(longitudMinima);
        }
        public double LatitudMaxima { get; set; }
        public double LatitudMinima { get; set; }
        public double LongitudMaxima { get; set; }
        public double LongitudMinima { get; set; }
    }
}
