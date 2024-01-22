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
            // Configuración de las entidades según el esquema de la base de datos Oracle

            // Configuración para la entidad Persona
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("PERSONA"); 

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired();
                entity.Property(e => e.Cedula).IsRequired();
            });

            // Configuración para la entidad PersonaContacto
            modelBuilder.Entity<PersonaContacto>(entity =>
            {
                entity.ToTable("PERSONACONTACTO"); 

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Celular).HasMaxLength(20);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Correo).HasMaxLength(100);
                entity.Property(e => e.Dirección).HasMaxLength(200);
                entity.HasOne(d => d.Persona)
                      .WithMany(p => p.Contactos)
                      .HasForeignKey(d => d.PersonaId);
            });

            // Datos de semilla (opcional)
            modelBuilder.Entity<Persona>().HasData(
                new Persona { Id = 2, Nombre = "Laura", Cedula = "002-1234567-8" }
            );

            modelBuilder.Entity<PersonaContacto>().HasData(
                new PersonaContacto { Id = 2, PersonaId = 2, Celular = "823-000-0000", Telefono = "829-030-0000", Correo = "juan@example.com", Dirección = "Calle Ejemplo 123" }
            );
        }
    }
}
