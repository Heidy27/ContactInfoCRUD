using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class EliminarPersonaContactoCommand : IRequest 
{
    public int PersonaContactoId { get; set; }
}
