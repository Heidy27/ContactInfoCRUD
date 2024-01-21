using ContactInfoCRUD.Application.Command;
using ContactInfoCRUD.Domain.Interfaces;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

namespace ContactInfoCRUD.Application.Handlers
{
    public class EliminarPersonaContactoCommandHandler : IRequestHandler<EliminarPersonaContactoCommand, Unit>
    {
        private readonly IPersonaContactoRepository _personaContactoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EliminarPersonaContactoCommandHandler(IPersonaContactoRepository personaContactoRepository, IUnitOfWork unitOfWork)
        {
            _personaContactoRepository = personaContactoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(EliminarPersonaContactoCommand request, CancellationToken cancellationToken)
        {
            var personaContacto = await _personaContactoRepository.GetByIdAsync(request.PersonaContactoId);
            if (personaContacto == null)
            {
                throw new KeyNotFoundException("No se encontró la persona de contacto con el ID proporcionado.");
            }

            await _personaContactoRepository.DeleteAsync(personaContacto);

            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
