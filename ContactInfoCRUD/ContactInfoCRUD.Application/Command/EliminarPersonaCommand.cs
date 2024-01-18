using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class EliminarPersonaCommand : IRequest 
{
    public int PersonaId { get; set; }
}
