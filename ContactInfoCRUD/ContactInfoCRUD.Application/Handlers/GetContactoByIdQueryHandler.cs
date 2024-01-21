using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

public class GetContactoByIdQueryHandler : IRequestHandler<GetContactoByIdQuery, PersonaContactoDto>
{
    private readonly IPersonaContactoRepository _personaContactoRepository;
    private readonly IMapper _mapper;

    public GetContactoByIdQueryHandler(IPersonaContactoRepository personaContactoRepository, IMapper mapper)
    {
        _personaContactoRepository = personaContactoRepository ?? throw new ArgumentNullException(nameof(personaContactoRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<PersonaContactoDto> Handle(GetContactoByIdQuery request, CancellationToken cancellationToken)
    {
        var contacto = await _personaContactoRepository.GetByIdAsync(request.Id);
        if (contacto == null)
        {
            throw new KeyNotFoundException($"No se encontró el contacto con el ID: {request.Id}.");
        }
        return _mapper.Map<PersonaContactoDto>(contacto);
    }
}
