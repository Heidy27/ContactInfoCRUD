﻿// <auto-generated />
using ContactInfoCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ContactInfoCRUD.Infrastructure.Migrations
{
    [DbContext(typeof(ContactInfoDbContext))]
    [Migration("20240120213010_NewMigration")]
    partial class NewMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContactInfoCRUD.Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("PERSONA", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Cedula = "002-1234567-8",
                            Nombre = "Laura"
                        });
                });

            modelBuilder.Entity("ContactInfoCRUD.Domain.Entities.PersonaContacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("Dirección")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("PERSONACONTACTO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Celular = "823-000-0000",
                            Correo = "juan@example.com",
                            Dirección = "Calle Ejemplo 123",
                            PersonaId = 2,
                            Telefono = "829-030-0000"
                        });
                });

            modelBuilder.Entity("ContactInfoCRUD.Domain.Entities.PersonaContacto", b =>
                {
                    b.HasOne("ContactInfoCRUD.Domain.Entities.Persona", "Persona")
                        .WithMany("Contactos")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("ContactInfoCRUD.Domain.Entities.Persona", b =>
                {
                    b.Navigation("Contactos");
                });
#pragma warning restore 612, 618
        }
    }
}
