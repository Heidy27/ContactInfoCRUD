using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class DeletePersonaContactoCommand : IRequest<Unit>
{
    public int PersonaContactoId { get; set; }
}
