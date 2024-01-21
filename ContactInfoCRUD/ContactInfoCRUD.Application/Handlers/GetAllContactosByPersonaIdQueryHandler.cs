using MediatR;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using AutoMapper;

namespace ContactInfoCRUD.Application.Handlers
{
    public class GetAllContactosByPersonaIdQueryHandler : IRequestHandler<GetAllContactosByPersonaIdQuery, IEnumerable<PersonaContactoDto>>
    {
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IMapper _mapper;

        public GetAllContactosByPersonaIdQueryHandler(IPersonaContactoRepository personaContactoRepository, IMapper mapper)
        {
            _personaContactoRepository = personaContactoRepository ?? throw new ArgumentNullException(nameof(personaContactoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PersonaContactoDto>> Handle(GetAllContactosByPersonaIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var contactos = await _personaContactoRepository.GetByPersonaIdAsync(request.PersonaId);
                if (contactos == null)
                {
                    throw new ApplicationException("No se encontraron contactos para el ID de persona proporcionado.");
                }

                var contactosDto = _mapper.Map<IEnumerable<PersonaContactoDto>>(contactos);
                return contactosDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al obtener contactos por ID de persona.", ex);
            }
        }
    }
}
