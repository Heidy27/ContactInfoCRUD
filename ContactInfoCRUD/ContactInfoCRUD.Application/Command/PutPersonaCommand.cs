using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class PutPersonaCommand : IRequest<Unit>
{
    public int PersonaId { get; set; }
    public string NuevoNombre { get; set; }
    public string NuevaCedula { get; set; }

}
