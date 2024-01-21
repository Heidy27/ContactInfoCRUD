using MediatR;
using ContactInfoCRUD.Domain.Entities;
using ContactInfoCRUD.Domain.Repositories;
using ContactInfoCRUD.Domain.Interfaces;
using AutoMapper;
using ContactInfoCRUD.Application.Command;

namespace ContactInfoCRUD.Application.Handlers
{
    public class CrearPersonaCommandHandler : IRequestHandler<CrearPersonaCommand, int>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPersonaCommandHandler(
            IPersonaRepository personaRepository,
            IPersonaContactoRepository personaContactoRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _personaRepository = personaRepository ?? throw new ArgumentNullException(nameof(personaRepository));
            _personaContactoRepository = personaContactoRepository ?? throw new ArgumentNullException(nameof(personaContactoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(CrearPersonaCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var persona = new Persona
                {
                    Nombre = command.Nombre,
                    Cedula = command.Cedula,
                };

                await _personaRepository.AddAsync(persona);

                return await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al crear una persona.", ex);
            }
        }
    }
}
