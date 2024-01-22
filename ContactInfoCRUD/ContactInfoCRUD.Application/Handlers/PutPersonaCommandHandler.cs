using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

public class PutPersonaCommandHandler : IRequestHandler<PutPersonaCommand, Unit>
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PutPersonaCommandHandler(IPersonaRepository personaRepository, IUnitOfWork unitOfWork)
    {
        _personaRepository = personaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(PutPersonaCommand request, CancellationToken cancellationToken)
    {
        var persona = await _personaRepository.GetByIdAsync(request.PersonaId);
        if (persona == null)
        {
            throw new KeyNotFoundException("No se encontró la persona con el ID proporcionado.");
        }

        // Actualizamos los datos básicos de la persona
        persona.Nombre = request.NuevoNombre;
        persona.Cedula = request.NuevaCedula;

        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}
