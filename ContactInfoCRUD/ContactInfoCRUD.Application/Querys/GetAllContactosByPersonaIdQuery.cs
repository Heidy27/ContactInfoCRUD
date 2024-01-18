using MediatR;
using System.Collections.Generic;
using ContactInfoCRUD.Application.DTOs;

namespace ContactInfoCRUD.Application.Querys;
public class GetAllContactosByPersonaIdQuery : IRequest<IEnumerable<PersonaContactoDto>>
{
    public int PersonaId { get; set; }

    public GetAllContactosByPersonaIdQuery(int personaId)
    {
        PersonaId = personaId;
    }
}

public class GetContactoByIdQuery : IRequest<PersonaContactoDto>
{
    public int Id { get; set; }

    public GetContactoByIdQuery(int id)
    {
        Id = id;
    }
}
