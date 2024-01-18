using MediatR;
using System.Collections.Generic;
using ContactInfoCRUD.Application.DTOs;

namespace ContactInfoCRUD.Application.Querys;
public class GetPersonasQuery : IRequest<IEnumerable<PersonaDto>>
{
}
