using Xunit;
using Moq;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Application.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using ContactInfoCRUD.Domain.Entities;

public class GetContactoByIdQueryHandlerTest
{
    [Fact]
    public async Task Handle_ContactoExists_ReturnsContactoDto()
    {
        // Arrange
        var mockRepository = new Mock<IPersonaContactoRepository>();
        var mockMapper = new Mock<IMapper>();
        int contactoId = 1;
        var contacto = new PersonaContacto { Id = contactoId };
        var contactoDto = new PersonaContactoDto { Id = contactoId };

        mockRepository.Setup(repo => repo.GetByIdAsync(contactoId)).ReturnsAsync(contacto);
        mockMapper.Setup(m => m.Map<PersonaContactoDto>(contacto)).Returns(contactoDto);

        var handler = new GetContactoByIdQueryHandler(mockRepository.Object, mockMapper.Object);
        var query = new GetContactoByIdQuery(contactoId);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(contactoId, result.Id);
    }

    [Fact]
    public async Task Handle_ContactoDoesNotExist_ThrowsKeyNotFoundException()
    {
        // Arrange
        var mockRepository = new Mock<IPersonaContactoRepository>();
        var mockMapper = new Mock<IMapper>();
        int contactoId = 1;

        mockRepository.Setup(repo => repo.GetByIdAsync(contactoId)).ReturnsAsync((PersonaContacto)null);

        var handler = new GetContactoByIdQueryHandler(mockRepository.Object, mockMapper.Object);
        var query = new GetContactoByIdQuery(contactoId);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(query, CancellationToken.None));
    }
}
