using AutoMapper;
using ContactInfoCRUD.Application.DTOs;
using ContactInfoCRUD.Domain.Repositories;
using MediatR;

namespace ContactInfoCRUD.Application.Querys;
public class GetPersonaByCedulaQuery : IRequest<PersonaDto>
{
    public string Cedula { get; set; }

    public GetPersonaByCedulaQuery(string cedula)
    {
        Cedula = cedula;
    }
}
