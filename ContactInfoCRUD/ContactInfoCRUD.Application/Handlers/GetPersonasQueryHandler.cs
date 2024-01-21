using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Application.Handlers
{
    public class GetPersonasQueryHandler : IRequestHandler<GetPersonasQuery, IEnumerable<PersonaDto>>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public GetPersonasQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PersonaDto>> Handle(GetPersonasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var personas = await _personaRepository.GetAllAsync();

                var personasDto = _mapper.Map<IEnumerable<PersonaDto>>(personas);

                return personasDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al obtener todas las personas.", ex);
            }
        }
    }
}
