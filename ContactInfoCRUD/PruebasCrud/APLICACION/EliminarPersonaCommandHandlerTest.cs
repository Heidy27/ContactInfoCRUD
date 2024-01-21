using Xunit;
using Moq;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Domain.Entities;

public class EliminarPersonaCommandHandlerTest
{
    [Fact]
    public async Task Handle_PersonaExists_DeletesPersona()
    {
        // Arrange
        var mockPersonaRepository = new Mock<IPersonaRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var persona = new Persona { Id = 1, Nombre = "Juan", Cedula = "001-2345678-9" };
        mockPersonaRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(persona);

        var handler = new EliminarPersonaCommandHandler(mockPersonaRepository.Object, mockUnitOfWork.Object);
        var command = new EliminarPersonaCommand { PersonaId = 1 };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockPersonaRepository.Verify(repo => repo.DeleteAsync(persona), Times.Once);
        mockUnitOfWork.Verify(uow => uow.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_PersonaDoesNotExist_ThrowsKeyNotFoundException()
    {
        // Arrange
        var mockPersonaRepository = new Mock<IPersonaRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockPersonaRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Persona)null);

        var handler = new EliminarPersonaCommandHandler(mockPersonaRepository.Object, mockUnitOfWork.Object);
        var command = new EliminarPersonaCommand { PersonaId = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command, CancellationToken.None));
    }
}
