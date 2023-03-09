using Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Web_API.Data
{
    public class ApparcaContexto: DbContext
    {
        public ApparcaContexto(DbContextOptions<ApparcaContexto> options) : base(options)
        {
        }
        public DbSet<Plaza>? Plazas { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Reserva>? Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Poner el nombre de las tablas en singular
            modelBuilder.Entity<Plaza>().ToTable("Plazas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Reserva>().ToTable("Reservas");
            // Deshabilitar la eliminación en cascada en todas las relaciones
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in
            modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
