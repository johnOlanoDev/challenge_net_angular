using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Data
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("APP_USER");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTES");
                modelBuilder.Entity<Cliente>().Property(c => c.Telefono).HasColumnName("TELEFONO_CONTACTO");
                modelBuilder.Entity<Cliente>().Property(c => c.Correo).HasColumnName("CORREO_CONTACTO");
            });
        }
    }
}