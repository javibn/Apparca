namespace Web_API.Models
{
    public class ImagenesPlaza
    {
        public int Id { get; set; }
        public string? formatoImagen { get; set; }
        public byte[] Imagen { get; set; }

        public Plaza Plaza { get; set; }
        public int PlazaId { get; set; }
    }
}
