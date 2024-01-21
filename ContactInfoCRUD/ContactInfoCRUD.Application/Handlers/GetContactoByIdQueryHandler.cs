using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        try
        {
            var contacto = await _personaContactoRepository.GetByIdAsync(request.Id);
            return _mapper.Map<PersonaContactoDto>(contacto);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Ocurrió un error al obtener el contacto por ID.", ex);
        }
    }
}
