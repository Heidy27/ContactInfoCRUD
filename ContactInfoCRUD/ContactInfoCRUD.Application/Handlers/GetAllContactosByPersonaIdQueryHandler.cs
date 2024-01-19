using MediatR;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;

namespace ContactInfoCRUD.Application.Handlers;
public class GetAllContactosByPersonaIdQueryHandler : IRequestHandler<GetAllContactosByPersonaIdQuery, IEnumerable<PersonaContactoDto>>
{
    private readonly IPersonaContactoRepository _personaContactoRepository;
    private readonly IMapper _mapper;

    public GetAllContactosByPersonaIdQueryHandler(IPersonaContactoRepository personaContactoRepository, IMapper mapper)
    {
        _personaContactoRepository = personaContactoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonaContactoDto>> Handle(GetAllContactosByPersonaIdQuery request, CancellationToken cancellationToken)
    {
        var contactos = await _personaContactoRepository.GetByPersonaIdAsync(request.PersonaId);
        var contactosDto = _mapper.Map<IEnumerable<PersonaContactoDto>>(contactos);
        return contactosDto;
    }
}
