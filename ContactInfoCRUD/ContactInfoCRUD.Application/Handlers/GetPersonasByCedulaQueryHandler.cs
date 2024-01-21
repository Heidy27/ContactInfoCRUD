using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Application.Querys;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactInfoCRUD.Application.Handlers
{
    public class GetPersonasByCedulaQueryHandler : IRequestHandler<GetPersonaByCedulaQuery, PersonaDto>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public GetPersonasByCedulaQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonaDto> Handle(GetPersonaByCedulaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var persona = await _personaRepository.GetByCedulaAsync(request.Cedula);

                if (persona == null)
                {
                    throw new KeyNotFoundException($"No se encontró una persona con la cédula: {request.Cedula}");
                }

                var personaDto = _mapper.Map<PersonaDto>(persona);

                return personaDto;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al buscar persona por cédula.", ex);
            }
        }
    }
}
