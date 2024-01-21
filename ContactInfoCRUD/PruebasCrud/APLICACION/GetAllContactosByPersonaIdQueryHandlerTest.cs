using Xunit;
using Moq;
using MediatR;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Application.Handlers;

public class GetAllContactosByPersonaIdQueryHandlerTest
{
    [Fact]
    public async Task Handle_ContactosExist_ReturnsMappedContactos()
    {
        // Arrange
        var mockPersonaContactoRepository = new Mock<IPersonaContactoRepository>();
        var mockMapper = new Mock<IMapper>();
        var personaId = 1;
        var contactos = new List<PersonaContacto> { new PersonaContacto { Id = 1, PersonaId = personaId } };
        var contactosDto = new List<PersonaContactoDto> { new PersonaContactoDto { Id = 1, PersonaId = personaId } };

        mockPersonaContactoRepository.Setup(repo => repo.GetByPersonaIdAsync(personaId)).ReturnsAsync(contactos);
        mockMapper.Setup(m => m.Map<IEnumerable<PersonaContactoDto>>(It.IsAny<IEnumerable<PersonaContacto>>())).Returns(contactosDto);

        var handler = new GetAllContactosByPersonaIdQueryHandler(mockPersonaContactoRepository.Object, mockMapper.Object);
        var query = new GetAllContactosByPersonaIdQuery(personaId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task Handle_ContactosDoNotExist_ThrowsApplicationException()
    {
        // Arrange
        var mockPersonaContactoRepository = new Mock<IPersonaContactoRepository>();
        var mockMapper = new Mock<IMapper>();
        var personaId = 1;

        mockPersonaContactoRepository.Setup(repo => repo.GetByPersonaIdAsync(personaId)).ReturnsAsync((IEnumerable<PersonaContacto>)null);

        var handler = new GetAllContactosByPersonaIdQueryHandler(mockPersonaContactoRepository.Object, mockMapper.Object);
        var query = new GetAllContactosByPersonaIdQuery(personaId);

        // Act & Assert
        await Assert.ThrowsAsync<ApplicationException>(() => handler.Handle(query, CancellationToken.None));
    }
}
