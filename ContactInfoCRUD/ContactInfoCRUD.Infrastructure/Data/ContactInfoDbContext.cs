using Microsoft.EntityFrameworkCore;
using ContactInfoCRUD.Domain.Entities;

namespace ContactInfoCRUD.Infrastructure.Data
{
    public class ContactInfoDbContext : DbContext
    {
        public ContactInfoDbContext(DbContextOptions<ContactInfoDbContext> options)
            : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<PersonaContacto> PersonaContactos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Cedula).IsRequired();
            });

            modelBuilder.Entity<PersonaContacto>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Celular).HasMaxLength(20);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Correo).HasMaxLength(100);
                entity.Property(e => e.Dirección).HasMaxLength(200);
                entity.HasOne(d => d.Persona)
                      .WithMany(p => p.Contactos)
                      .HasForeignKey(d => d.PersonaId);
            });

            modelBuilder.Entity<Persona>().HasData(
               new Persona { Id = 1, Nombre = "Juan Perez", Cedula = "001-1234567-8" }
           );

            modelBuilder.Entity<PersonaContacto>().HasData(
                new PersonaContacto { Id = 1, PersonaId = 1, Celular = "800-000-0000", Telefono = "829-000-0000", Correo = "juan@example.com", Dirección = "Calle Ejemplo 123" }
            );
        }
    }
}
