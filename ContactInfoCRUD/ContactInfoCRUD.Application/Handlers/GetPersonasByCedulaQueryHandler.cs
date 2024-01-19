using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

namespace ContactInfoCRUD.Application.Handlers;
public class GetPersonasByCedulaQueryHandler : IRequestHandler<GetPersonaByCedulaQuery, PersonaDto>
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IMapper _mapper;

    public GetPersonasByCedulaQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
    {
        _personaRepository = personaRepository;
        _mapper = mapper;
    }

    public async Task<PersonaDto> Handle(GetPersonaByCedulaQuery request, CancellationToken cancellationToken)
    {
        // Aquí implementa la lógica para obtener la persona por cédula desde el repositorio
        var persona = await _personaRepository.GetByCedulaAsync(request.Cedula);

        // Mapea la entidad Persona a PersonaDto
        var personaDto = _mapper.Map<PersonaDto>(persona);

        return personaDto;
    }
}
