using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class DeletePersonaCommand : IRequest<Unit>
{
    public int PersonaId { get; set; }
}
