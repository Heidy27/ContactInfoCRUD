using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class GetPersonaContactoCommand : IRequest<int> 
{
    public int PersonaId { get; set; }
    public string Celular { get; set; }
    public string Telefono { get; set; }
    public string Correo { get; set; }
    public string Direccion { get; set; }
 
}
