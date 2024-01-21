using AutoMapper;
using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

public class ActualizarPersonaContactoCommandHandler : IRequestHandler<ActualizarPersonaContactoCommand, Unit>
{
    private readonly IPersonaContactoRepository _personaContactoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ActualizarPersonaContactoCommandHandler(IPersonaContactoRepository personaContactoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _personaContactoRepository = personaContactoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(ActualizarPersonaContactoCommand request, CancellationToken cancellationToken)
    {
        var contacto = await _personaContactoRepository.GetByIdAsync(request.PersonaContactoId);
        if (contacto == null)
        {
            throw new KeyNotFoundException("No se encontró el contacto con el ID proporcionado.");
        }

        _mapper.Map(request, contacto);

        await _personaContactoRepository.UpdateAsync(contacto);
        await _unitOfWork.CommitAsync();

        return Unit.Value;
    }
}
