﻿using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

namespace ContactInfoCRUD.Application.Handlers;
public class GetPersonasQueryHandler : IRequestHandler<GetPersonasQuery, IEnumerable<PersonaDto>>
{
    private readonly IPersonaRepository _personaRepository;
    private readonly IMapper _mapper;

    public GetPersonasQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
    {
        _personaRepository = personaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PersonaDto>> Handle(GetPersonasQuery request, CancellationToken cancellationToken)
    {
        // Aquí implementa la lógica para obtener todas las personas desde el repositorio
        var personas = await _personaRepository.GetAllAsync();

        // Mapea las entidades Persona a PersonaDto
        var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);

        return personasDto;
    }
}
