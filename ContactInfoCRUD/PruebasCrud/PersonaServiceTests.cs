using Xunit;
using Moq;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Interfaces; // Importa la interfaz IUnitOfWork
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Application.Services;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactInfoCRUD.Application.DTOs;

namespace ContactInfoCRUD.Tests
{
    public class PersonaServiceTests
    {
        private readonly Mock<IPersonaRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork; 
        private readonly PersonaService _service;

        public PersonaServiceTests()
        {
            _mockRepository = new Mock<IPersonaRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockUnitOfWork = new Mock<IUnitOfWork>(); 
            _service = new PersonaService(_mockRepository.Object, _mockMapper.Object, _mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetAllPersonasAsync_ReturnsAllPersonas()
        {
            // Arrange
            var personas = new List<Persona> { new Persona { Nombre = "Test", Cedula = "123456789" } };
            _mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(personas);

            // Configurar el mock de AutoMapper si se utiliza en el servicio
            _mockMapper.Setup(mapper => mapper.Map<IEnumerable<PersonaDto>>(It.IsAny<IEnumerable<Persona>>()))
                       .Returns(personas.Select(persona => new PersonaDto { Nombre = persona.Nombre, Cedula = persona.Cedula }));

            // Act
            var result = await _service.GetAllPersonasAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Count());
        }

    }
}
