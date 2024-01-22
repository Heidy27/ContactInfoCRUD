using ContactInfoCRUD.Application.DTOs;
using MediatR;

namespace ContactInfoCRUD.Application.Command;
public class GetPersonaCommand : IRequest<int> 
{
    public string Nombre { get; set; }
    public string Cedula { get; set; }
}
