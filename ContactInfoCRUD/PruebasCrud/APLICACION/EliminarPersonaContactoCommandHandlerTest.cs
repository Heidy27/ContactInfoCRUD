using Xunit;
using Moq;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Application.Handlers;

public class EliminarPersonaContactoCommandHandlerTest
{
    [Fact]
    public async Task Handle_PersonaContactoExists_DeletesPersonaContacto()
    {
        // Arrange
        var mockPersonaContactoRepository = new Mock<IPersonaContactoRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var personaContacto = new PersonaContacto { Id = 1 };
        mockPersonaContactoRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(personaContacto);

        var handler = new EliminarPersonaContactoCommandHandler(mockPersonaContactoRepository.Object, mockUnitOfWork.Object);
        var command = new DeletePersonaContactoCommand { PersonaContactoId = 1 };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockPersonaContactoRepository.Verify(repo => repo.DeleteAsync(personaContacto), Times.Once);
        mockUnitOfWork.Verify(uow => uow.CommitAsync(), Times.Once);
    }

    [Fact]
    public async Task Handle_PersonaContactoDoesNotExist_ThrowsKeyNotFoundException()
    {
        // Arrange
        var mockPersonaContactoRepository = new Mock<IPersonaContactoRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        mockPersonaContactoRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((PersonaContacto)null);

        var handler = new EliminarPersonaContactoCommandHandler(mockPersonaContactoRepository.Object, mockUnitOfWork.Object);
        var command = new DeletePersonaContactoCommand { PersonaContactoId = 1 };

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command, CancellationToken.None));
    }
}
