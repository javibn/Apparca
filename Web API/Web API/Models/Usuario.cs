using MessagePack;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Web_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Apellidos { get; set; }

        public string? Correo { get; set; }


        public string? Telefono { get; set; }

        public string? Dni { get; set; }

        public string? password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }

        private string? _password;

        public string HashPassword(string? password)
        {
            if (string.IsNullOrWhiteSpace(password)) return null;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convertir los bytes en una cadena hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    builder.Append(hashedBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public string? rol { get; set; }



        public ICollection<Plaza>? Plazas { get; set; }
        public ICollection<Reserva>? ReservasComoArrendatario { get; set; }
        

    }
}
