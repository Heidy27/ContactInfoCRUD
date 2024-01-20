using Xunit;
using Moq;
using ContactInfoCRUD.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Tests
{
    public class PersonaRepositoryTests
    {
        private readonly ContactInfoDbContext _context;

        public PersonaRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ContactInfoDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new ContactInfoDbContext(options);
        }

        [Fact]
        public async Task AddAsync_AddsPersonaSuccessfully()
        {
            // Arrange
            var repository = new PersonaRepository(_context);
            var persona = new Persona { Nombre = "Test", Cedula = "123456789" };

            // Act
            await repository.AddAsync(persona);
            await _context.SaveChangesAsync();

            // Assert
            var count = await _context.Personas.CountAsync();
            Assert.Equal(1, count);
            var savedPersona = await _context.Personas.FirstOrDefaultAsync();
            Assert.Equal("Test", savedPersona.Nombre);
            Assert.Equal("123456789", savedPersona.Cedula);
        }

        // Puedes agregar más pruebas para UpdateAsync, DeleteAsync, etc.
    }
}
