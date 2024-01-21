using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class EliminarPersonaContactoCommand : IRequest<Unit>
{
    public int PersonaContactoId { get; set; }
}
