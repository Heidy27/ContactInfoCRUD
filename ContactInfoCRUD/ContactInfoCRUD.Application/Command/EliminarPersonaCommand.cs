using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class EliminarPersonaCommand : IRequest<Unit>
{
    public int PersonaId { get; set; }
}
