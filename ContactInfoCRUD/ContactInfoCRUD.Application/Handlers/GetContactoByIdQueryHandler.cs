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
        _personaContactoRepository = personaContactoRepository;
        _mapper = mapper;
    }

    public async Task<PersonaContactoDto> Handle(GetContactoByIdQuery request, CancellationToken cancellationToken)
    {
        var contacto = await _personaContactoRepository.GetByIdAsync(request.Id);
        return _mapper.Map<PersonaContactoDto>(contacto);
    }
}
