using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

public class EliminarPersonaCommandHandler : IRequestHandler<EliminarPersonaCommand, Unit>
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EliminarPersonaCommandHandler(IPersonaRepository personaRepository, IUnitOfWork unitOfWork)
    {
        _personaRepository = personaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(EliminarPersonaCommand request, CancellationToken cancellationToken)
    {
        var persona = await _personaRepository.GetByIdAsync(request.PersonaId);
        if (persona == null)
        {
            throw new KeyNotFoundException("No se encontró la persona con el ID proporcionado.");
        }

        await _personaRepository.DeleteAsync(persona);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}