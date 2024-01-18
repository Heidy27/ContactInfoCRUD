using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class ActualizarPersonaContactoCommand : IRequest 
{
    public int PersonaContactoId { get; set; }
    public string NuevoCelular { get; set; }
    public string NuevoTelefono { get; set; }
    public string NuevoCorreo { get; set; }
    public string NuevaDireccion { get; set; }

}
