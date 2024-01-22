using MediatR;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Domain.Interfaces;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using ContactInfoCRUD.Application.Command;

namespace ContactInfoCRUD.Application.Handlers
{
    public class CrearPersonaContactoCommandHandler : IRequestHandler<GetPersonaContactoCommand, int>
    {
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IPersonaRepository _personaRepository; 
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPersonaContactoCommandHandler(
            IPersonaContactoRepository personaContactoRepository,
            IPersonaRepository personaRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _personaContactoRepository = personaContactoRepository ?? throw new ArgumentNullException(nameof(personaContactoRepository));
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(GetPersonaContactoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                // Verificar si la persona con el ID especificado existe
                var personaExistente = await _personaRepository.GetByIdAsync(command.PersonaId);

                if (personaExistente == null)
                {
                    throw new KeyNotFoundException($"No se encontró una persona con el ID: {command.PersonaId}");
                }

                var personaContacto = _mapper.Map<PersonaContacto>(command);

                await _personaContactoRepository.AddAsync(personaContacto);
                await _unitOfWork.CommitAsync();

                if (personaContacto.Id <= 0)
                {
                    throw new ApplicationException("No se pudo crear el contacto de persona.");
                }

                return personaContacto.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al crear un contacto de persona.", ex);
            }
        }
    }
}
