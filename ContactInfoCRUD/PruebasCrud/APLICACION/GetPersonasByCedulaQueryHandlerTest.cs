using Xunit;
using Moq;
using AutoMapper;
using MediatR;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Entities;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using ContactInfoCRUD.Application.Handlers;

public class GetPersonasByCedulaQueryHandlerTests
{
    [Fact]
    public async Task Handle_CedulaExists_ReturnsPersonaDto()
    {
        // Arrange
        var mockRepository = new Mock<IPersonaRepository>();
        var mockMapper = new Mock<IMapper>();
        var cedula = "001-1234567-8";
        var persona = new Persona { Id = 1, Cedula = cedula };
        var personaDto = new PersonaDto { Id = 1, Cedula = cedula };

        mockRepository.Setup(repo => repo.GetByCedulaAsync(cedula)).ReturnsAsync(persona);
        mockMapper.Setup(mapper => mapper.Map<PersonaDto>(persona)).Returns(personaDto);

        var handler = new GetPersonasByCedulaQueryHandler(mockRepository.Object, mockMapper.Object);
        var query = new GetPersonaByCedulaQuery(cedula);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(cedula, result.Cedula);
    }

    [Fact]
    public async Task Handle_CedulaDoesNotExist_ThrowsApplicationExceptionWithKeyNotFoundException()
    {
        // Arrange
        var mockRepository = new Mock<IPersonaRepository>();
        var mockMapper = new Mock<IMapper>();
        var cedula = "001-1234567-9";

        mockRepository.Setup(repo => repo.GetByCedulaAsync(cedula)).ReturnsAsync((Persona)null);

        var handler = new GetPersonasByCedulaQueryHandler(mockRepository.Object, mockMapper.Object);
        var query = new GetPersonaByCedulaQuery(cedula);

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ApplicationException>(() => handler.Handle(query, CancellationToken.None));
        Assert.IsType<KeyNotFoundException>(exception.InnerException);
    }

}
