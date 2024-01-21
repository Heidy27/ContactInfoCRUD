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
    public class CrearPersonaContactoCommandHandler : IRequestHandler<CrearPersonaContactoCommand, int>
    {
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CrearPersonaContactoCommandHandler(
            IPersonaContactoRepository personaContactoRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _personaContactoRepository = personaContactoRepository ?? throw new ArgumentNullException(nameof(personaContactoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(CrearPersonaContactoCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var personaContacto = _mapper.Map<PersonaContacto>(command);

                await _personaContactoRepository.AddAsync(personaContacto);
                await _unitOfWork.CommitAsync();

                return personaContacto.Id;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un error al crear un contacto de persona.", ex);
            }
        }
    }
}
