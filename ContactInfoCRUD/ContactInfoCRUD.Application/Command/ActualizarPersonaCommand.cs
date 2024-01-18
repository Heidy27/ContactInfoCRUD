using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class ActualizarPersonaCommand : IRequest 
{
    public int PersonaId { get; set; }
    public string NuevoNombre { get; set; }
    public string NuevaCedula { get; set; }

}
